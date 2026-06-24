using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NRO_Server.DatabaseManager.Player;
using Newtonsoft.Json.Linq;
using NRO_Server.Application.Manager;
using NRO_Server.Application.Main;
using NRO_Server.Model;
using NRO_Server.Application.Constants;
using NRO_Server.Model.Character;
using NRO_Server.Model.Option;
using NRO_Server.Application.Handlers.Item;

namespace NRO_Server.Application.Threading
{
    public class AdminWebServer
    {
        private static HttpListener _listener;
        private static bool _isRunning = false;

        public static void Start()
        {
            if (_isRunning) return;

            _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:5000/");
            
            try
            {
                _listener.Start();
                _isRunning = true;
                Server.Gi().Logger.Info("Admin Web Server is running on port 5000");

                Task.Run(() => ListenAsync());
            }
            catch (Exception ex)
            {
                Server.Gi().Logger.Error($"Failed to start Admin Web Server: {ex.Message}");
            }
        }

        public static void Stop()
        {
            if (!_isRunning) return;

            _isRunning = false;
            _listener?.Stop();
            _listener?.Close();
            Server.Gi().Logger.Info("Admin Web Server stopped");
        }

        private static async Task ListenAsync()
        {
            while (_isRunning)
            {
                try
                {
                    var context = await _listener.GetContextAsync();
                    _ = Task.Run(() => HandleRequest(context));
                }
                catch (HttpListenerException)
                {
                    // Listener stopped
                }
                catch (Exception ex)
                {
                    Server.Gi().Logger.Error($"Admin Web Server Error: {ex.Message}");
                }
            }
        }

        private static async Task HandleRequest(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            response.AppendHeader("Access-Control-Allow-Origin", "*");
            response.AppendHeader("Access-Control-Allow-Methods", "POST, GET, OPTIONS");
            response.AppendHeader("Access-Control-Allow-Headers", "Content-Type");

            if (request.HttpMethod == "OPTIONS")
            {
                response.StatusCode = 200;
                response.Close();
                return;
            }

            string responseString = "";
            byte[] buffer;

            try
            {
                if (request.HttpMethod == "GET" && request.Url.AbsolutePath == "/")
                {
                    response.ContentType = "text/html; charset=utf-8";
                    responseString = GetHtmlContent();
                    buffer = Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                }
                else if (request.HttpMethod == "POST")
                {
                    string requestBody;
                    using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                    {
                        requestBody = await reader.ReadToEndAsync();
                    }

                    JObject json = JObject.Parse(requestBody);
                    JObject resJson = new JObject();

                    if (request.Url.AbsolutePath == "/api/get_character")
                    {
                        string name = json["name"]?.ToString().Trim();
                        var charOnline = ClientManager.Gi().GetCharacter(name);
                        
                        if (charOnline != null)
                        {
                            resJson["status"] = "success";
                            resJson["isOnline"] = true;
                            resJson["gold"] = charOnline.InfoChar.Gold;
                            resJson["diamond"] = charOnline.InfoChar.Diamond;
                            resJson["power"] = charOnline.InfoChar.Power;
                            resJson["potential"] = charOnline.InfoChar.Potential;
                        }
                        else
                        {
                            var charOffline = CharacterDB.GetByName(name);
                            if (charOffline != null)
                            {
                                resJson["status"] = "success";
                                resJson["isOnline"] = false;
                                resJson["gold"] = charOffline.InfoChar.Gold;
                                resJson["diamond"] = charOffline.InfoChar.Diamond;
                                resJson["power"] = charOffline.InfoChar.Power;
                                resJson["potential"] = charOffline.InfoChar.Potential;
                            }
                            else
                            {
                                resJson["status"] = "error";
                                resJson["message"] = "Không tìm thấy nhân vật";
                            }
                        }
                    }
                    else if (request.Url.AbsolutePath == "/api/update_stats")
                    {
                        string name = json["name"]?.ToString().Trim();
                        long gold = (long)json["gold"];
                        int diamond = (int)json["diamond"];
                        long power = (long)json["power"];
                        long potential = (long)json["potential"];

                        var charOnline = ClientManager.Gi().GetCharacter(name);
                        if (charOnline != null)
                        {
                            charOnline.InfoChar.Gold = gold;
                            charOnline.InfoChar.Diamond = diamond;
                            charOnline.InfoChar.Power = power;
                            charOnline.InfoChar.Potential = potential;
                            charOnline.CharacterHandler.SendMessage(Service.MeLoadInfo(charOnline));
                            charOnline.CharacterHandler.SendMessage(Service.MeLoadPoint(charOnline));
                            CharacterDB.Update((Character)charOnline);

                            resJson["status"] = "success";
                            resJson["message"] = "Đã cập nhật chỉ số trực tiếp vào game!";
                        }
                        else
                        {
                            var charOffline = CharacterDB.GetByName(name);
                            if (charOffline != null)
                            {
                                charOffline.InfoChar.Gold = gold;
                                charOffline.InfoChar.Diamond = diamond;
                                charOffline.InfoChar.Power = power;
                                charOffline.InfoChar.Potential = potential;
                                CharacterDB.Update(charOffline);

                                resJson["status"] = "success";
                                resJson["message"] = "Đã cập nhật chỉ số cho nhân vật offline!";
                            }
                            else
                            {
                                resJson["status"] = "error";
                                resJson["message"] = "Không tìm thấy nhân vật";
                            }
                        }
                    }
                    else if (request.Url.AbsolutePath == "/api/add_item")
                    {
                        string name = json["name"]?.ToString().Trim();
                        short itemId = (short)json["itemId"];
                        int quantity = (int)json["quantity"];
                        int setId = 0;
                        if (json["setId"] != null)
                        {
                            setId = (int)json["setId"];
                        }

                        var charOnline = ClientManager.Gi().GetCharacter(name);
                        if (charOnline != null)
                        {
                            var itemTemplate = ItemCache.ItemTemplate(itemId);
                            if (itemTemplate != null)
                            {
                                var itemAdd = ItemCache.GetItemDefault(itemId);
                                itemAdd.Quantity = quantity;

                                if (setId >= 127 && setId <= 135)
                                {
                                    itemAdd.Options.Add(new OptionItem() { Id = setId, Param = 0 });
                                    itemAdd.Options.Add(new OptionItem() { Id = LeaveItemHandler.GetSKHDescOption(setId), Param = 0 });
                                }

                                if (charOnline.CharacterHandler.AddItemToBag(true, itemAdd, "Admin Web"))
                                {
                                    charOnline.CharacterHandler.SendMessage(Service.SendBag(charOnline));
                                    charOnline.CharacterHandler.SendMessage(Service.ServerMessage($"Admin đã thêm {quantity} {itemTemplate.Name} vào hành trang."));
                                    CharacterDB.Update((Character)charOnline);

                                    resJson["status"] = "success";
                                    resJson["message"] = $"Đã thêm {quantity} {itemTemplate.Name} thành công!";
                                }
                                else
                                {
                                    resJson["status"] = "error";
                                    resJson["message"] = "Hành trang của nhân vật đã đầy!";
                                }
                            }
                            else
                            {
                                resJson["status"] = "error";
                                resJson["message"] = "ID Vật phẩm không hợp lệ!";
                            }
                        }
                        else
                        {
                            resJson["status"] = "error";
                            resJson["message"] = "Nhân vật đang Offline. Chỉ có thể thêm đồ khi nhân vật đang Online trong game để đảm bảo an toàn dữ liệu.";
                        }
                    }
                    else
                    {
                        resJson["status"] = "error";
                        resJson["message"] = "Invalid API endpoint";
                    }

                    response.ContentType = "application/json";
                    buffer = Encoding.UTF8.GetBytes(resJson.ToString());
                    response.ContentLength64 = buffer.Length;
                    await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                }
                else
                {
                    response.StatusCode = 404;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                buffer = Encoding.UTF8.GetBytes(ex.Message);
                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                Server.Gi().Logger.Error($"Admin Web Error: {ex.Message}");
            }
            finally
            {
                response.Close();
            }
        }

        private static string GetHtmlContent()
        {
            return @"
<!DOCTYPE html>
<html lang=""vi"">
<head>
    <meta charset=""UTF-8"">
    <title>NRO Admin Panel - Premium</title>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Outfit:wght@300;400;500;700&display=swap');
        
        :root {
            --glass-bg: rgba(25, 25, 35, 0.65);
            --glass-border: rgba(255, 255, 255, 0.1);
            --primary: #00f2fe;
            --secondary: #4facfe;
            --text-main: #f8f9fa;
            --text-muted: #adb5bd;
            --success: #00b09b;
            --error: #ff416c;
        }

        * {
            box-sizing: border-box;
            margin: 0;
            padding: 0;
            font-family: 'Outfit', sans-serif;
        }

        body {
            background: radial-gradient(circle at top right, #1a1a2e, #16213e, #0f3460);
            color: var(--text-main);
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
            overflow-x: hidden;
        }

        /* Abstract Background Elements */
        .bg-shape {
            position: fixed;
            border-radius: 50%;
            filter: blur(80px);
            z-index: -1;
            opacity: 0.5;
        }

        .shape1 {
            width: 400px;
            height: 400px;
            background: var(--primary);
            top: -100px;
            left: -100px;
        }

        .shape2 {
            width: 500px;
            height: 500px;
            background: #ff0844;
            bottom: -150px;
            right: -100px;
        }

        .container {
            background: var(--glass-bg);
            backdrop-filter: blur(16px);
            -webkit-backdrop-filter: blur(16px);
            border: 1px solid var(--glass-border);
            border-radius: 24px;
            padding: 40px;
            width: 90%;
            max-width: 600px;
            box-shadow: 0 25px 45px rgba(0, 0, 0, 0.3);
            position: relative;
            z-index: 1;
        }

        h1 {
            text-align: center;
            margin-bottom: 30px;
            font-weight: 700;
            font-size: 28px;
            background: linear-gradient(to right, var(--primary), var(--secondary));
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            text-transform: uppercase;
            letter-spacing: 2px;
        }

        .input-group {
            margin-bottom: 20px;
            position: relative;
        }

        label {
            display: block;
            margin-bottom: 8px;
            font-weight: 500;
            color: var(--text-muted);
            font-size: 14px;
        }

        input {
            width: 100%;
            padding: 15px;
            background: rgba(255, 255, 255, 0.05);
            border: 1px solid rgba(255, 255, 255, 0.1);
            border-radius: 12px;
            color: #fff;
            font-size: 16px;
            transition: all 0.3s ease;
            outline: none;
        }

        input:focus, select:focus {
            border-color: var(--primary);
            background: rgba(255, 255, 255, 0.08);
            box-shadow: 0 0 15px rgba(0, 242, 254, 0.2);
        }

        select {
            width: 100%;
            padding: 15px;
            background: rgba(255, 255, 255, 0.05);
            border: 1px solid rgba(255, 255, 255, 0.1);
            border-radius: 12px;
            color: #fff;
            font-size: 16px;
            transition: all 0.3s ease;
            outline: none;
        }

        select option {
            background: #1a1a2e;
            color: white;
        }
        select optgroup {
            background: #0f3460;
            color: #00f2fe;
        }

        button {
            width: 100%;
            padding: 15px;
            border: none;
            border-radius: 12px;
            background: linear-gradient(135deg, var(--secondary) 0%, var(--primary) 100%);
            color: white;
            font-size: 16px;
            font-weight: 700;
            cursor: pointer;
            transition: transform 0.2s, box-shadow 0.2s;
            text-transform: uppercase;
            letter-spacing: 1px;
            margin-top: 10px;
        }

        button:hover {
            transform: translateY(-2px);
            box-shadow: 0 10px 20px rgba(0, 242, 254, 0.3);
        }

        button:active {
            transform: translateY(0);
        }

        #actionPanel {
            display: none;
            animation: fadeIn 0.5s ease;
        }

        .tabs {
            display: flex;
            margin-bottom: 25px;
            border-radius: 12px;
            background: rgba(0,0,0,0.2);
            overflow: hidden;
            margin-top: 20px;
        }

        .tab {
            flex: 1;
            padding: 12px;
            text-align: center;
            cursor: pointer;
            font-weight: 600;
            color: var(--text-muted);
            transition: 0.3s;
        }

        .tab.active {
            background: linear-gradient(to right, rgba(79, 172, 254, 0.2), rgba(0, 242, 254, 0.2));
            color: var(--primary);
            border-bottom: 2px solid var(--primary);
        }

        .tab-content {
            display: none;
        }

        .tab-content.active {
            display: block;
            animation: fadeIn 0.4s ease;
        }

        .status-badge {
            text-align: center;
            margin-bottom: 25px;
            padding: 10px;
            border-radius: 8px;
            font-weight: 600;
            font-size: 14px;
            letter-spacing: 1px;
        }

        .status-online {
            background: rgba(0, 176, 155, 0.15);
            color: #00f2fe;
            border: 1px solid rgba(0, 176, 155, 0.3);
        }

        .status-offline {
            background: rgba(255, 65, 108, 0.15);
            color: #ff4b2b;
            border: 1px solid rgba(255, 65, 108, 0.3);
        }

        /* Stats Grid */
        .grid {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 15px;
        }

        /* Add Item Specific */
        .warning-text {
            color: #ff9a9e;
            font-size: 13px;
            text-align: center;
            margin-top: 15px;
            font-style: italic;
        }

        /* Toast Notification */
        #toast {
            visibility: hidden;
            min-width: 250px;
            margin-left: -125px;
            background-color: rgba(25, 25, 35, 0.9);
            border: 1px solid;
            color: #fff;
            text-align: center;
            border-radius: 8px;
            padding: 16px;
            position: fixed;
            z-index: 1000;
            left: 50%;
            bottom: 30px;
            font-size: 15px;
            font-weight: 500;
            backdrop-filter: blur(10px);
            transition: opacity 0.3s, bottom 0.3s;
            opacity: 0;
            transform: translateY(20px);
        }

        #toast.show {
            visibility: visible;
            opacity: 1;
            transform: translateY(0);
        }

        #toast.success { border-color: var(--success); }
        #toast.error { border-color: var(--error); }

        @keyframes fadeIn {
            from { opacity: 0; transform: translateY(10px); }
            to { opacity: 1; transform: translateY(0); }
        }

        @media (max-width: 480px) {
            .container { padding: 25px; }
            .grid { grid-template-columns: 1fr; }
        }
    </style>
</head>
<body>

    <div class=""bg-shape shape1""></div>
    <div class=""bg-shape shape2""></div>

    <div class=""container"">
        <h1>NRO Control Panel</h1>

        <div class=""input-group"">
            <label>Tên nhân vật</label>
            <input type=""text"" id=""charName"" placeholder=""Nhập tên nhân vật cần quản lý..."" />
        </div>
        <button onclick=""findCharacter()"">TÌM KIẾM DỮ LIỆU</button>

        <div id=""actionPanel"">
            <div id=""onlineStatus"" class=""status-badge""></div>

            <div class=""tabs"">
                <div class=""tab active"" onclick=""switchTab('stats')"">CHỈ SỐ</div>
                <div class=""tab"" onclick=""switchTab('items')"">VẬT PHẨM</div>
            </div>

            <!-- TAB 1: CHỈ SỐ -->
            <div id=""tab-stats"" class=""tab-content active"">
                <div class=""grid"">
                    <div class=""input-group"">
                        <label>Vàng (Gold)</label>
                        <input type=""number"" id=""gold"" />
                    </div>
                    <div class=""input-group"">
                        <label>Ngọc (Diamond)</label>
                        <input type=""number"" id=""diamond"" />
                    </div>
                    <div class=""input-group"">
                        <label>Sức mạnh (Power)</label>
                        <input type=""number"" id=""power"" />
                    </div>
                    <div class=""input-group"">
                        <label>Tiềm năng (Potential)</label>
                        <input type=""number"" id=""potential"" />
                    </div>
                </div>
                <button onclick=""updateStats()"">CẬP NHẬT CHỈ SỐ</button>
            </div>

            <!-- TAB 2: VẬT PHẨM -->
            <div id=""tab-items"" class=""tab-content"">
                <div class=""grid"">
                    <div class=""input-group"">
                        <label>ID Vật phẩm</label>
                        <input type=""number"" id=""itemId"" placeholder=""Ví dụ: 457 (Thỏi vàng)"" />
                    </div>
                    <div class=""input-group"">
                        <label>Số lượng</label>
                        <input type=""number"" id=""itemQty"" value=""1"" />
                    </div>
                    <div class=""input-group"" style=""grid-column: 1 / -1;"">
                        <label>Tùy chọn Set Kích Hoạt</label>
                        <select id=""setId"">
                            <option value=""0"">Không (Mặc định)</option>
                            <optgroup label=""Trái Đất"">
                                <option value=""127"">Set Kaioken</option>
                                <option value=""128"">Set Krillin</option>
                                <option value=""129"">Set Sôngôku</option>
                            </optgroup>
                            <optgroup label=""Namec"">
                                <option value=""130"">Set Picolo</option>
                                <option value=""131"">Set Liên hoàn</option>
                                <option value=""132"">Set Pikkoro Daimao</option>
                            </optgroup>
                            <optgroup label=""Xayda"">
                                <option value=""133"">Set Kakarot</option>
                                <option value=""134"">Set Ca Đíc</option>
                                <option value=""135"">Set Nappa</option>
                            </optgroup>
                        </select>
                    </div>
                </div>
                <button onclick=""addItem()"" style=""background: linear-gradient(135deg, #00b09b, #96c93d);"">THÊM VẬT PHẨM</button>
                <div class=""warning-text"">* Chỉ có thể thêm vật phẩm khi nhân vật đang Online trong game</div>
            </div>
        </div>
    </div>

    <div id=""toast"">Thông báo</div>

    <script>
        let currentStatus = false;

        function showToast(msg, type = 'success') {
            const toast = document.getElementById('toast');
            toast.textContent = msg;
            toast.className = `show ${type}`;
            setTimeout(() => { toast.className = toast.className.replace('show', ''); }, 3000);
        }

        function switchTab(tab) {
            document.querySelectorAll('.tab').forEach(t => t.classList.remove('active'));
            document.querySelectorAll('.tab-content').forEach(c => c.classList.remove('active'));
            
            event.target.classList.add('active');
            document.getElementById(`tab-${tab}`).classList.add('active');
        }

        async function findCharacter() {
            const name = document.getElementById('charName').value;
            if (!name) return showToast('Vui lòng nhập tên nhân vật', 'error');

            try {
                const res = await fetch('/api/get_character', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ name })
                });
                const data = await res.json();

                if (data.status === 'success') {
                    document.getElementById('actionPanel').style.display = 'block';
                    document.getElementById('gold').value = data.gold;
                    document.getElementById('diamond').value = data.diamond;
                    document.getElementById('power').value = data.power;
                    document.getElementById('potential').value = data.potential;
                    
                    const statusEl = document.getElementById('onlineStatus');
                    currentStatus = data.isOnline;
                    
                    if (data.isOnline) {
                        statusEl.textContent = '⚫ TRẠNG THÁI: ONLINE (ĐANG TRONG GAME)';
                        statusEl.className = 'status-badge status-online';
                    } else {
                        statusEl.textContent = '⚪ TRẠNG THÁI: OFFLINE';
                        statusEl.className = 'status-badge status-offline';
                    }
                    showToast('Tải dữ liệu thành công!');
                } else {
                    document.getElementById('actionPanel').style.display = 'none';
                    showToast(data.message, 'error');
                }
            } catch (e) {
                showToast('Lỗi kết nối Server', 'error');
            }
        }

        async function updateStats() {
            const name = document.getElementById('charName').value;
            const payload = {
                name: name,
                gold: parseInt(document.getElementById('gold').value),
                diamond: parseInt(document.getElementById('diamond').value),
                power: parseInt(document.getElementById('power').value),
                potential: parseInt(document.getElementById('potential').value)
            };

            try {
                const res = await fetch('/api/update_stats', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(payload)
                });
                const data = await res.json();
                showToast(data.message, data.status);
            } catch (e) {
                showToast('Lỗi kết nối Server', 'error');
            }
        }

        async function addItem() {
            if (!currentStatus) {
                return showToast('Nhân vật đang Offline! Hãy vào game trước khi nhận đồ.', 'error');
            }

            const name = document.getElementById('charName').value;
            const itemId = document.getElementById('itemId').value;
            const quantity = document.getElementById('itemQty').value;
            const setId = document.getElementById('setId').value;

            if(!itemId || !quantity) return showToast('Vui lòng nhập ID và Số lượng', 'error');

            try {
                const res = await fetch('/api/add_item', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ 
                        name: name,
                        itemId: parseInt(itemId),
                        quantity: parseInt(quantity),
                        setId: parseInt(setId)
                    })
                });
                const data = await res.json();
                showToast(data.message, data.status);
            } catch (e) {
                showToast('Lỗi kết nối Server', 'error');
            }
        }
    </script>
</body>
</html>";
        }
    }
}
