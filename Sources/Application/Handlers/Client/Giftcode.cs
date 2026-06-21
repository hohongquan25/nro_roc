using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Collections.Generic;
using NRO_Server.Main.Menu;
using NRO_Server.Application.Constants;
using NRO_Server.Application.IO;
using NRO_Server.Application.Main;
using NRO_Server.Application.Threading;
using NRO_Server.DatabaseManager;
using NRO_Server.DatabaseManager.Player;
using NRO_Server.Model.Option;
using NRO_Server.Model.Template;
using NRO_Server.Model.Character;
using Newtonsoft.Json;

namespace NRO_Server.Application.Handlers.Client
{
    public static class Giftcode
    {
        public static void HandleUseGiftcode(Model.Character.Character character, string code)
        {
            var timeServer = ServerUtils.CurrentTimeMillis();
            if (character.Delay.UseGiftCode > timeServer)
            {
                var delay = (character.Delay.UseGiftCode - timeServer) / 1000;
                if (delay < 1)
                {
                    delay = 1;
                }

                character.CharacterHandler.SendMessage(Service.DialogMessage(string.Format(TextServer.gI().DELAY_SEC,
                        delay)));
                return;
            }
            // kiểm tra hạn gift code
            // kiểm tra đã dùng gift code chưa
            var codeType = GiftcodeDB.CheckCodeValidType(code);
            if (codeType == -1)
            {
                character.Delay.UseGiftCode = timeServer + 30000;
                character.CharacterHandler.SendMessage(Service.OpenUiSay((short)character.ShopId, "Giftcode đã hết hạn hoặc hết lượt sử dụng."));
                return;
            }

            var isUsedThisCode = GiftcodeDB.CheckCharacterAlreadyUsedCode(code, character.Name, codeType);

            if (isUsedThisCode)
            {
                character.Delay.UseGiftCode = timeServer + 30000;
                character.CharacterHandler.SendMessage(Service.OpenUiSay((short)character.ShopId, "Bạn đã dùng Giftcode này rồi."));
                return;
            }
            // Sử dụng gift code
            character.Delay.UseGiftCode = timeServer + 30000;
            UseCode(character, code, codeType);
            
        }

        private static void UseCode(Model.Character.Character character, string code, int codeType)
        {
            if (codeType == 0)//Tân thủ
            {
                // 20 thoỉ vàng
                // Tặng 10 thỏi vàng
                var quatang1 = ItemCache.GetItemDefault((short)14);
                quatang1.Quantity = 10; //thỏi vàng
                character.CharacterHandler.AddItemToBag(true, quatang1, "Giftcode");
				
				// Tặng 10 thỏi vàng
                var quatang2 = ItemCache.GetItemDefault((short)15);
                quatang2.Quantity = 10; //thỏi vàng
                character.CharacterHandler.AddItemToBag(true, quatang2, "Giftcode");
				
				var quatang3 = ItemCache.GetItemDefault((short)16);
                quatang3.Quantity = 50; //thỏi vàng
                character.CharacterHandler.AddItemToBag(true, quatang3, "Giftcode");
				
				var quatang4 = ItemCache.GetItemDefault((short)17);
                quatang4.Quantity = 10; //thỏi vàng
                character.CharacterHandler.AddItemToBag(true, quatang4, "Giftcode");
                // 10 vé quay
               // character.PlusDiamond(100000000); // ngọc
                // 3678
				var quatang5 = ItemCache.GetItemDefault((short)18);
                quatang5.Quantity = 10; //thỏi vàng
                character.CharacterHandler.AddItemToBag(true, quatang5, "Giftcode");
				 // 20 thoỉ vàng
                // Tặng 10 thỏi vàng
                var quatang6 = ItemCache.GetItemDefault((short)19);
                quatang6.Quantity = 10; //thỏi vàng
                character.CharacterHandler.AddItemToBag(true, quatang6, "Giftcode");
				 // 20 thoỉ vàng
                // Tặng 10 thỏi vàng
                var quatang7 = ItemCache.GetItemDefault((short)20);
                quatang7.Quantity = 10; //thỏi vàng
                character.CharacterHandler.AddItemToBag(true, quatang7, "Giftcode");
				
                character.CharacterHandler.SendMessage(Service.SendBag(character));
                character.CharacterHandler.SendMessage(Service.OpenUiSay((short)character.ShopId, @"Đã nhận thành công 10 viên ngọc rồng 1 sao,10 viên ngọc rồng 2 sao,50 viên ngọc rồng 3 sao,10 viên ngọc rồng 4 sao,10 viên ngọc rồng 5 sao,10 viên ngọc rồng 6 sao,10 viên ngọc rồng 7 sao."));
				
				
            } 
			if (codeType == 1)//Tân thủ
            {
                // 20 thoỉ vàng
                // Tặng 10 thỏi vàng
                var quatang1 = ItemCache.GetItemDefault((short)16);
                quatang1.Quantity = 50; //thỏi vàng
                character.CharacterHandler.AddItemToBag(true, quatang1, "Giftcode");
				
				// Tặng 10 thỏi vàng
                var quatang2 = ItemCache.GetItemDefault((short)441);
                quatang2.Quantity = 50; //thỏi vàng
                character.CharacterHandler.AddItemToBag(true, quatang2, "Giftcode");
				
				var quatang3 = ItemCache.GetItemDefault((short)447);
                quatang3.Quantity = 50; //thỏi vàng
                character.CharacterHandler.AddItemToBag(true, quatang3, "Giftcode");
				
				var quatang4 = ItemCache.GetItemDefault((short)381);
                quatang4.Quantity = 99; //thỏi vàng
                character.CharacterHandler.AddItemToBag(true, quatang4, "Giftcode");
				
				var quatang5 = ItemCache.GetItemDefault((short)933);
                quatang5.Quantity = 4953; //thỏi vàng
                character.CharacterHandler.AddItemToBag(true, quatang5, "Giftcode");
                
				
                character.CharacterHandler.SendMessage(Service.SendBag(character));
                character.CharacterHandler.SendMessage(Service.OpenUiSay((short)character.ShopId, @"Đã nhận thành công 10 viên ngọc rồng 1 sao,10 viên ngọc rồng 2 sao,50 viên ngọc rồng 3 sao,10 viên ngọc rồng 4 sao,10 viên ngọc rồng 5 sao,10 viên ngọc rồng 6 sao,10 viên ngọc rồng 7 sao."));
				
				
            } 
            GiftcodeDB.UsedCode(code, character.Name, codeType);
        }
    }
}