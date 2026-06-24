using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NRO_Server.Application.Constants;
using NRO_Server.Application.Handlers.Item;
using NRO_Server.Application.IO;
using NRO_Server.Application.Manager;
using NRO_Server.Application.Map;
using NRO_Server.Application.Threading;
using NRO_Server.DatabaseManager;
using NRO_Server.DatabaseManager.Player;
using NRO_Server.Main.Menu;
using NRO_Server.Model.Character;
using NRO_Server.Model.Clan;
using NRO_Server.Model.Info;
using NRO_Server.Model.Option;
using NRO_Server.Model.Template;
using NRO_Server.Model.SkillCharacter;
using Org.BouncyCastle.Math.Field;
using NRO_Server.Application.Interfaces.Character;

namespace NRO_Server.Application.Main.Menu
{
    public static class Menu
    {
        public static void OpenUiMenu(short npcId, Character character)
        {
            Server.Gi().Logger.Debug($"Menu NpcId Case 33: ------------------------------------ {npcId}");
            try
            {
                switch (npcId)
                {
					
                    //3 ông già
                    case 0:
                    case 1:
                    case 2:
                    {
                        switch (character.InfoChar.Task.Id)
                        {
                            case 0:
                            {
                                break;
                            }
                            case 1:
                            {
								if(character.InfoChar.Task.Index == 1)
								{
									character.InfoChar.Task.Id++;
									character.InfoChar.Task.Index = 0;
									character.InfoChar.Task.Count = 0;
                                    character.CharacterHandler.SendMessage(Service.SendTask(character));
                                    character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Tốt lắm, nhưng giờ ta đang đói, hãy đem về cho ta 10 chiếc đùi gà"));
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBaOngGia[0], MenuNpc.Gi().MenuBaOngGia[0], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
                                break;
                            }
                            case 2:
                            {
								if(character.InfoChar.Task.Index == 1)
								{
									character.InfoChar.Task.Id++;
									character.InfoChar.Task.Index = 0;
									character.InfoChar.Task.Count = 0;
                                    character.CharacterHandler.SendMessage(Service.SendTask(character));
                                    character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Đùi gà ngon đấy, ta sẽ chia sẻ chúng với con, ta nướng ở ngọn lửa đằng kia, có muốn ăn thì lại mà lấy nhé."));
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBaOngGia[0], MenuNpc.Gi().MenuBaOngGia[0], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
                                break;
                            }
							case 3:
                            {
								if(character.InfoChar.Task.Index == 2)
								{
									character.InfoChar.Task.Id++;
									character.InfoChar.Task.Index = 0;
                                    character.CharacterHandler.SendMessage(Service.SendTask(character));
                                    character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Giờ thì con đã có loli dưới tầng hầm ý nhầm, con đã biết sử dụng tiềm năng rồi, con cũng đã khoẻ hơn trước, thế tìm đập chetme con lợn lòi mẹ xem sao."));
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBaOngGia[0], MenuNpc.Gi().MenuBaOngGia[0], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
                                break;
                            }
							case 4:
                            {
								if(character.InfoChar.Task.Index == 3)
								{
									character.InfoChar.Task.Id = 7;
									character.InfoChar.Task.Index = 0;
									character.InfoChar.Task.Count = 0;
                                    character.CharacterHandler.SendMessage(Service.SendTask(character));
                                    character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Mạnh đấy, nhưng con à, con đập chết lợn lòi mẹ thế rồi, nhưng con lợn lòi con sẽ như thế nào? tội lỗi quá."));
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBaOngGia[0], MenuNpc.Gi().MenuBaOngGia[0], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
                                break;
                            }
							case 7:
                            {
								if(character.InfoChar.Task.Index == 3)
								{
									character.InfoChar.Task.Id++;
									character.InfoChar.Task.Index = 0;
									character.InfoChar.Task.Count = 0;
                                    character.CharacterHandler.SendMessage(Service.SendTask(character));
                                    character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Ta vừa lỡ đánh rớt viên ngọc rồng quý giá, con có thể tìm lại giúp ta được không?"));
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBaOngGia[0], MenuNpc.Gi().MenuBaOngGia[0], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
                                break;
                            }
							case 8:
                            {
								if(character.InfoChar.Task.Index == 2)
								{
									character.InfoChar.Task.Id++;
									character.InfoChar.Task.Index = 0;
									character.InfoChar.Task.Count = 0;
                                    character.CharacterHandler.SendMessage(Service.SendTask(character));
                                    character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Gụt chọp con zai. Hiện tại có 1 thầy mới ngon zai hơn ta, hãy đi tìm ổng đi :)"));
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBaOngGia[0], MenuNpc.Gi().MenuBaOngGia[0], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
                                break;
                            }
							case 9:
                            {
								if(character.InfoChar.Task.Index == 1)
								{
									character.InfoChar.Task.Id = 13;
									character.InfoChar.Task.Index = 0;
									character.InfoChar.Task.Count = 0;
                                    character.CharacterHandler.SendMessage(Service.SendTask(character));
                                    character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Lão già đấy ăn gan hùm à, con hãy ra tẩn cho ổng 1 trận cho ổng biết sự lợi hại của con đi"));
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBaOngGia[0], MenuNpc.Gi().MenuBaOngGia[0], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
                                break;
                            }
							case 25:
                            {
								if(character.InfoChar.Task.Index == 0)
								{
									character.InfoChar.Task.Index++;
									character.InfoChar.Task.Count = 0;
                                    character.CharacterHandler.SendMessage(Service.SendTask(character));
                                    character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Có 1 vị khách lạ vừa đáp đến trái đất, không rõ đó là ai, con hãy đi tìm hiểu xem"));
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBaOngGia[0], MenuNpc.Gi().MenuBaOngGia[0], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
                                break;
                            }
                            default:
                            {
                                // character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, MenuNpc.Gi().TextBaOngGia[0]));
                                //
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBaOngGia[0], MenuNpc.Gi().MenuBaOngGia[0], character.InfoChar.Gender));
                                character.TypeMenu = 0;
                                break;
                            }
                        }

                        break;
                    }
                    //Rương đồ
                    case 3:
                    {
                        character.CharacterHandler.SendMessage(Service.SendBox(character, 1));
                        break;
                    }
                    //Đậu thần
                    case 4:
                    {
                        var magicTree = MagicTreeManager.Get(character.Id);
                        if (magicTree == null) return;
                        var ngoc = magicTree.Diamond;
                        if (magicTree.IsUpdate)
                        {
                            character.CharacterHandler.SendMessage(Service.MagicTree1(new List<string>() {$"Nâng cấp\nnhanh\n{ngoc} ngọc", "Huỷ\nnâng cáp"}));
                        }
                        else
                        {
                            if (magicTree.Peas == magicTree.MaxPea)
                            {
                                character.CharacterHandler.SendMessage(Service.MagicTree1(new List<string>()
                                    {"Thu hoạch", $"Nâng cấp\n{ServerUtils.ConvertMilisecond(DataCache.UpgradeDauThanTime[magicTree.Level - 1])}\n{ServerUtils.GetMoney(DataCache.UpgradeDauThanGold[magicTree.Level - 1])}\nvàng"}));
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.MagicTree1(new List<string>() {"Thu hoạch", $"Nâng cấp\n{ServerUtils.ConvertMilisecond(DataCache.UpgradeDauThanTime[magicTree.Level - 1])}\n300 Tr\nvàng", $"Kết hạt\nnhanh\n{ngoc} ngọc"}));
                            }
                        }
                        break;
                    }
                    //Bumma
                    case 7:
                    {
						if(character.InfoChar.Task.Id == 7 && character.InfoChar.Task.Index == 2 && character.InfoChar.Gender == 0)
								{
									character.InfoChar.Task.Index++;
									character.InfoChar.Task.Count = 0;
                                    character.CharacterHandler.SendMessage(Service.SendTask(character));
                                    character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Ta là ông trùm buôn bán, muốn mua gì cứ tìm tới ta haha."));
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBumma[0], MenuNpc.Gi().MenuShopDistrict[0], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
                        
                        break;
                    }
                    //Dende
                    case 8:
                    {
						if(character.InfoChar.Task.Id == 7 && character.InfoChar.Task.Index == 2 && character.InfoChar.Gender == 1)
						{
							character.InfoChar.Task.Index++;
							character.InfoChar.Task.Count = 0;
                            character.CharacterHandler.SendMessage(Service.SendTask(character));
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Ta là ông trùm buôn bán, muốn mua gì cứ tìm tới ta haha."));
						}
						else 
						{
							character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextDende[0], MenuNpc.Gi().MenuShopDistrict[0], character.InfoChar.Gender));
							character.TypeMenu = 0;
						}
                        break;
                    }
                    //Appule
                    case 9:
                    {
						if(character.InfoChar.Task.Id == 7 && character.InfoChar.Task.Index == 2 && character.InfoChar.Gender == 2)
						{
							character.InfoChar.Task.Index++;
							character.InfoChar.Task.Count = 0;
                            character.CharacterHandler.SendMessage(Service.SendTask(character));
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Ta là ông trùm buôn bán, muốn mua gì cứ tìm tới ta haha."));
						}
						else 
						{
							character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextAppule[0], MenuNpc.Gi().MenuShopDistrict[0], character.InfoChar.Gender));
							character.TypeMenu = 0;
						}
                        break;
                    }
					case 40:
                        {
                            var timeServer = ServerUtils.CurrentTimeMillis();
                            if (character.Delay.GetGem > timeServer)
                            {
                                var delay = (character.Delay.GetGem - timeServer) / 1000;
                                if (delay < 1)
                                {
                                    delay = 1;
                                }

                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage(string.Format(TextServer.gI().DELAY_SEC,
                                        delay)));
                                return;
                            }
                            character.Delay.GetGem = 10000 + timeServer;
                            character.CharacterHandler.SendMessage(Service.Shop(character, 3, 53));
                            character.ShopId = 53;
                            character.TypeMenu = 3;
                            break;
                        }
                    //Brief
                    case 10:
                    {
                        character.CharacterHandler.SendMessage(character.InfoChar.MapId == 84
                            ? Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBrief[1],
                                new List<string>()
                                {
                                    character.InfoChar.Gender != 0
                                        ? character.InfoChar.Gender != 1 ? "Về Xayda" : "Về Namếc"
                                        : "Về\nTrái Đất"
                                }, character.InfoChar.Gender)
                            : Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBrief[0], MenuNpc.Gi().MenuBrief[0],
                                character.InfoChar.Gender));
                        break;
                    }
                    //Cargo
                    case 11:
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextCargo[0], MenuNpc.Gi().MenuCargo[0], character.InfoChar.Gender));
                        break;
                    }
                    //Cui
                    case 12:
                    {
                        switch (character.InfoChar.MapId)
                        {
                            case 19:
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextCui[1], MenuNpc.Gi().MenuCui[2], character.InfoChar.Gender));
                                break;
                            case 68:
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextCui[2], MenuNpc.Gi().MenuCui[3], character.InfoChar.Gender));
                                break;
                            default:
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextCui[0], MenuNpc.Gi().MenuCui[0], character.InfoChar.Gender));
                                break;
                        }

                        break;
                    }
                    //Quy lão
                    case 13:
                    {
                        if (character.InfoChar.LearnSkill != null)
                        {
                            var itemAdd = character.InfoChar.LearnSkill.ItemSkill;
                            var time = character.InfoChar.LearnSkill.Time - ServerUtils.CurrentTimeMillis();
                            var skillTemplate = Cache.Gi().SKILL_TEMPLATES.FirstOrDefault(skill => skill.Id == character.InfoChar.LearnSkill.ItemTemplateSkillId);

                            if (character.InfoChar.LearnSkill.Time <= ServerUtils.CurrentTimeMillis())
                            {
                                ItemHandler.AddLearnSkill(character, itemAdd, skillTemplate);
                                character.InfoChar.LearnSkill = null;
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[0], MenuNpc.Gi().MenuQuyLao[0], character.InfoChar.Gender));
                                character.TypeMenu = 0;
                            }
                            else
                            {
                                var itemTempalte = ItemCache.ItemTemplate(itemAdd.Id);
                                var ngoc = 5;
                                if (time / 600000 >= 2)
                                {
                                    ngoc += (int)time / 600000;
                                }

                                var menu = string.Format(TextServer.gI().ADDING_SKILL, skillTemplate.Name,
                                    itemTempalte.Level, ServerUtils.GetTime(time));
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, menu, new List<string>() {$"Học\nCấp tốc\n{ngoc} ngọc", "Huỷ","Bỏ qua"}, character.InfoChar.Gender));
                                character.TypeMenu = 3;
                            }
                        }
						else if (character.InfoChar.Gender == 0)
						{
							switch (character.InfoChar.Task.Id)
							{
								case 9:
								{
									if(character.InfoChar.Task.Index == 0)
									{
										character.InfoChar.Task.Index++;
										character.CharacterHandler.SendMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Haha, ngươi là thằng nhóc hỉ mũi chưa sạch mà ông già hay kể à, về nói với ổng là ta không thèm nhận ngươi làm đệ tử đâu"));
									}
									else 
									{
										character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[0], MenuNpc.Gi().MenuQuyLao[0], character.InfoChar.Gender));
										character.TypeMenu = 0;
									}
									break;
								}
								case 13:
								{
									if (character.InfoChar.Task.Index == 0 && character.ClanId != -1)
									{
										var clan = ClanManager.Get(character.ClanId);
										if (clan.CurrMember >= 5)
										{
											character.InfoChar.Task.Id++;
											character.InfoChar.Task.Index = 0;
											character.CharacterHandler.SendMeMessage(Service.SendTask(character));
											character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Khá khen cho ngươi là kiếm được khá nhiều bạn, nhưng ai mới là bạn thật của ngươi?"));
										}
										else {
											character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Mày bịp tao à, đã đủ 5 người quái đâu"));
										}
									}
									else 
									{
										character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[0], MenuNpc.Gi().MenuQuyLao[0], character.InfoChar.Gender));
										character.TypeMenu = 0;
									}
									break;
								}
								case 14:
								{
									if (character.InfoChar.Task.Index == 3)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Ái chà chà, bạn chất lượng đấy, nhưng giờ ta đang hơi chán, ngươi tìm gì cho ta vui vẻ xíu xem nào."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[0], MenuNpc.Gi().MenuQuyLao[0], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 15:
								{
									if (character.InfoChar.Task.Index == 2)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Hừ, có mỗi cuốn truyện tranh, thà haiten thì còn có hứng. Ấy ngươi đi làm nhiệm vụ tiếp đi, đứng đây làm chi?."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[0], MenuNpc.Gi().MenuQuyLao[0], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 16:
								{
									if (character.InfoChar.Task.Index == 4)
									{
										character.InfoChar.Task.Id = 18;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Bạn chất lượng phết ta :vv hỏi chúng nó xem đánh nhau không."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[0], MenuNpc.Gi().MenuQuyLao[0], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 18:
								{
									if (character.InfoChar.Task.Index == 4)
									{
										character.InfoChar.Task.Id = 21;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Ác chiến thế ku, nhưng trình chú còn non lắm, luyện tập thêm đi."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[0], MenuNpc.Gi().MenuQuyLao[0], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 21:
								{
									if (character.InfoChar.Task.Index == 6)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Ái chà chà, ái chà chà, kinh đếyyyy."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[0], MenuNpc.Gi().MenuQuyLao[0], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 22:
								{
									if (character.InfoChar.Task.Index == 3)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Cao thủ, cao thủ."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[0], MenuNpc.Gi().MenuQuyLao[0], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 23:
								{
									if (character.InfoChar.Task.Index == 4)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Một đội quân Fide vừa lao đến trái đất, chúng khá nguy hiểm, tìm và tiêu diệt chúng đi nào."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[0], MenuNpc.Gi().MenuQuyLao[0], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 24:
								{
									if (character.InfoChar.Task.Index == 3)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Hay quá, đội quân Fide đã bị tiêu diệt. Nhưng hình như ta thấy có 1 vị khách lạ vừa đến đây, tìm gặp ổng xem có chuyện gì xảy ra thế!"));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[0], MenuNpc.Gi().MenuQuyLao[0], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								default:
								{
									// character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, MenuNpc.Gi().TextBaOngGia[0]));
									//
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[0], MenuNpc.Gi().MenuQuyLao[0], character.InfoChar.Gender));
									character.TypeMenu = 0;
									break;
								}
							}
						}
						if (character.InfoChar.Task.Id == 25)
						{
							if (character.InfoChar.Task.Index == 2)
							{
								character.InfoChar.Task.Index++;
								character.InfoChar.Task.Count = 0;
								character.CharacterHandler.SendMeMessage(Service.SendTask(character));
								character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "OK, ngươi hãy đi theo vị khách ấy đến tương lai, còn thuốc này hãy giao lại cho ta, ta sẽ gánh vác trọng trách này cho ngươi :vv"));
							}
							else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[0], MenuNpc.Gi().MenuQuyLao[0], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
							break;
						}
                        else
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[0], MenuNpc.Gi().MenuQuyLao[0], character.InfoChar.Gender));
                            character.TypeMenu = 0;
                        }
                        break;
                    }
                    //Trưởng lão Guru
                    case 14:
                    {
                        if (character.InfoChar.Gender != 1)
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Nơi đây chỉ dành cho những chiến binh Namếc, hãy về hành tinh của mình đi."));
                            return;
                        }
                        if (character.InfoChar.LearnSkill != null)
                        {
                            var itemAdd = character.InfoChar.LearnSkill.ItemSkill;
                            var time = character.InfoChar.LearnSkill.Time - ServerUtils.CurrentTimeMillis();
                            var skillTemplate = Cache.Gi().SKILL_TEMPLATES.FirstOrDefault(skill => skill.Id == character.InfoChar.LearnSkill.ItemTemplateSkillId);

                            if (character.InfoChar.LearnSkill.Time <= ServerUtils.CurrentTimeMillis())
                            {
                                ItemHandler.AddLearnSkill(character, itemAdd, skillTemplate);
                                character.InfoChar.LearnSkill = null;
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
                                character.TypeMenu = 0;
                            }
                            else
                            {
                                var itemTempalte = ItemCache.ItemTemplate(itemAdd.Id);
                                var ngoc = 5;
                                if (time / 600000 >= 2)
                                {
                                    ngoc += (int)time / 600000;
                                }

                                var menu = string.Format(TextServer.gI().ADDING_SKILL, skillTemplate.Name,
                                    itemTempalte.Level, ServerUtils.GetTime(time));
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, menu, new List<string>() {$"Học\nCấp tốc\n{ngoc} ngọc", "Huỷ","Bỏ qua"}, character.InfoChar.Gender));
                                character.TypeMenu = 2;
                            }
                        }
						else if (character.InfoChar.Gender == 1)
						{
							switch (character.InfoChar.Task.Id)
							{
								case 9:
								{
									if(character.InfoChar.Task.Index == 0)
									{
										character.InfoChar.Task.Index++;
										character.CharacterHandler.SendMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Haha, ngươi là thằng nhóc hỉ mũi chưa sạch mà ông già hay kể à, về nói với ổng là ta không thèm nhận ngươi làm đệ tử đâu"));
									}
									else 
									{
										character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
										character.TypeMenu = 0;
									}
									break;
								}
								case 13:
								{
									if (character.InfoChar.Task.Index == 0 && character.ClanId != -1)
									{
										var clan = ClanManager.Get(character.ClanId);
										if (clan.CurrMember >= 5)
										{
											character.InfoChar.Task.Id++;
											character.CharacterHandler.SendMeMessage(Service.SendTask(character));
											character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Khá khen cho ngươi là kiếm được khá nhiều bạn, nhưng ai mới là bạn thật của ngươi?"));
										}
										else {
											character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Mày bịp tao à, đã đủ 5 người quái đâu"));
										}
									}
									else 
									{
										character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
										character.TypeMenu = 0;
									}
									break;
								}
								case 14:
								{
									if (character.InfoChar.Task.Index == 3)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Ái chà chà, bạn chất lượng đấy, nhưng giờ ta đang hơi chán, ngươi tìm gì cho ta vui vẻ xíu xem nào."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 15:
								{
									if (character.InfoChar.Task.Index == 2)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Hừ, có mỗi cuốn truyện tranh, thà haiten thì còn có hứng. Ấy ngươi đi làm nhiệm vụ tiếp đi, đứng đây làm chi?."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 16:
								{
									if (character.InfoChar.Task.Index == 4)
									{
										character.InfoChar.Task.Id = 18;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Bạn chất lượng phết ta :vv hỏi chúng nó xem đánh nhau không."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 18:
								{
									if (character.InfoChar.Task.Index == 4)
									{
										character.InfoChar.Task.Id = 21;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Ác chiến thế ku, nhưng trình chú còn non lắm, luyện tập thêm đi."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 21:
								{
									if (character.InfoChar.Task.Index == 6)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Ái chà chà, ái chà chà, kinh đếyyyy."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 22:
								{
									if (character.InfoChar.Task.Index == 3)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Cao thủ, cao thủ."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 23:
								{
									if (character.InfoChar.Task.Index == 4)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Một đội quân Fide vừa lao đến trái đất, chúng khá nguy hiểm, tìm và tiêu diệt chúng đi nào."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 24:
								{
									if (character.InfoChar.Task.Index == 3)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Hay quá, đội quân Fide đã bị tiêu diệt. Nhưng hình như ta thấy có 1 vị khách lạ vừa đến đây, tìm gặp ổng xem có chuyện gì xảy ra thế!"));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								default:
								{
									// character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, MenuNpc.Gi().TextBaOngGia[0]));
									//
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
									character.TypeMenu = 0;
									break;
								}
							}
						}
                        else
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
                            character.TypeMenu = 0;
                        }
                        break;
                    }
                    //Vua vegeta
                    case 15:
                    {
                        if (character.InfoChar.Gender != 2)
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Nơi đây chỉ dành cho những chiến binh Xayda, hãy về hành tinh của mình đi."));
                            return;
                        }
                        if (character.InfoChar.LearnSkill != null)
                        {
                            var itemAdd = character.InfoChar.LearnSkill.ItemSkill;
                            var time = character.InfoChar.LearnSkill.Time - ServerUtils.CurrentTimeMillis();
                            var skillTemplate = Cache.Gi().SKILL_TEMPLATES.FirstOrDefault(skill => skill.Id == character.InfoChar.LearnSkill.ItemTemplateSkillId);

                            if (character.InfoChar.LearnSkill.Time <= ServerUtils.CurrentTimeMillis())
                            {
                                ItemHandler.AddLearnSkill(character, itemAdd, skillTemplate);
                                character.InfoChar.LearnSkill = null;
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
                                character.TypeMenu = 0;
                            }
                            else
                            {
                                var itemTempalte = ItemCache.ItemTemplate(itemAdd.Id);
                                var ngoc = 5;
                                if (time / 600000 >= 2)
                                {
                                    ngoc += (int)time / 600000;
                                }

                                var menu = string.Format(TextServer.gI().ADDING_SKILL, skillTemplate.Name,
                                    itemTempalte.Level, ServerUtils.GetTime(time));
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, menu, new List<string>() {$"Học\nCấp tốc\n{ngoc} ngọc", "Huỷ","Bỏ qua"}, character.InfoChar.Gender));
                                character.TypeMenu = 2;
                            }
                        }
						else if (character.InfoChar.Gender == 2)
						{
							switch (character.InfoChar.Task.Id)
							{
								case 9:
								{
									if(character.InfoChar.Task.Index == 0)
									{
										character.InfoChar.Task.Index++;
										character.CharacterHandler.SendMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Haha, ngươi là thằng nhóc hỉ mũi chưa sạch mà ông già hay kể à, về nói với ổng là ta không thèm nhận ngươi làm đệ tử đâu"));
									}
									else 
									{
										character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
										character.TypeMenu = 0;
									}
									break;
								}
								case 13:
								{
									if (character.InfoChar.Task.Index == 0 && character.ClanId != -1)
									{
										var clan = ClanManager.Get(character.ClanId);
										if (clan.CurrMember >= 5)
										{
											character.InfoChar.Task.Id++;
											character.CharacterHandler.SendMeMessage(Service.SendTask(character));
											character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Khá khen cho ngươi là kiếm được khá nhiều bạn, nhưng ai mới là bạn thật của ngươi?"));
										}
										else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Mày bịp tao à, đã đủ 5 người quái đâu"));
										}
									}
									else 
									{
										character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
										character.TypeMenu = 0;
									}
									break;
								}
								case 14:
								{
									if (character.InfoChar.Task.Index == 3)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Ái chà chà, bạn chất lượng đấy, nhưng giờ ta đang hơi chán, ngươi tìm gì cho ta vui vẻ xíu xem nào."));
									}
									else 
									{
										character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[2], MenuNpc.Gi().MenuQuyLao[2], character.InfoChar.Gender));
										character.TypeMenu = 0;
									}
									break;
								}
								case 15:
								{
									if (character.InfoChar.Task.Index == 2)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Hừ, có mỗi cuốn truyện tranh, thà haiten thì còn có hứng. Ấy ngươi đi làm nhiệm vụ tiếp đi, đứng đây làm chi?."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 16:
								{
									if (character.InfoChar.Task.Index == 4)
									{
										character.InfoChar.Task.Id = 18;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Bạn chất lượng phết ta :vv hỏi chúng nó xem đánh nhau không."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 18:
								{
									if (character.InfoChar.Task.Index == 4)
									{
										character.InfoChar.Task.Id = 21;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Ác chiến thế ku, nhưng trình chú còn non lắm, luyện tập thêm đi."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 21:
								{
									if (character.InfoChar.Task.Index == 6)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Ái chà chà, ái chà chà, kinh đếyyyy."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 22:
								{
									if (character.InfoChar.Task.Index == 3)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Cao thủ, cao thủ."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 23:
								{
									if (character.InfoChar.Task.Index == 4)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Một đội quân Fide vừa lao đến trái đất, chúng khá nguy hiểm, tìm và tiêu diệt chúng đi nào."));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								case 24:
								{
									if (character.InfoChar.Task.Index == 3)
									{
										character.InfoChar.Task.Id++;
										character.InfoChar.Task.Index = 0;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Hay quá, đội quân Fide đã bị tiêu diệt. Nhưng hình như ta thấy có 1 vị khách lạ vừa đến đây, tìm gặp ổng xem có chuyện gì xảy ra thế!"));
									}
									else 
										{
											character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
											character.TypeMenu = 0;
										}
									break;
								}
								default:
								{
									// character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, MenuNpc.Gi().TextBaOngGia[0]));
									//
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
									character.TypeMenu = 0;
									break;
								}
							}
						}
                        else
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
                            character.TypeMenu = 0;
                        }
                        break;
                    }
                    //Uron
                    case 16:
                    {
                        var idShop = 15 + character.InfoChar.Gender;
                        character.CharacterHandler.SendMessage(Service.Shop(character, 0, idShop));
                        character.ShopId = idShop;
                        character.TypeMenu = 0;
                        break;
                    }
                    //Thần mèo
                     case 18:
                     {
						 if (character.InfoChar.Task.Id == 30 && character.InfoChar.Task.Index == 0)
							{
								if(character.InfoChar.OriginalDamage > 10000)
								{
									character.InfoChar.Task.Index++;
									character.InfoChar.Task.Count = 0;
									character.CharacterHandler.SendMeMessage(Service.SendTask(character));
									character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Ái chà chà mạnh phết rồi đấy, ra quân thôiiii"));
								}
							}
						else {
                         character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextThanMeo[0], MenuNpc.Gi().MenuThanMeo[0], character.InfoChar.Gender));
                         character.TypeMenu = 0;
						}
                         break;
                     }
                    //Thượng đế
                    case 19:
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextThuongDe[1], MenuNpc.Gi().MenuThuongDe[1], character.InfoChar.Gender));
                        character.TypeMenu = 0;
                        break;
                    }
					case 68:
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextPanchy[0], MenuNpc.Gi().MenuPanchy[0], character.InfoChar.Gender));
                        character.TypeMenu = 0;
                        break;
                    }
                    case 20:
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextThanVuTru[0], MenuNpc.Gi().MenuThanVuTru[0], character.InfoChar.Gender));
                        character.TypeMenu = 0;
                        break;
                    }
                    //Bà hạt mít
                    case 21:
                    {
                        switch (character.InfoChar.MapId)
                        {
                            case 5:
                            {
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBaHatMit[0], MenuNpc.Gi().MenuBaHatMit[3], character.InfoChar.Gender));
                                character.TypeMenu = 1;
                                break;
                            }
                            case 42:
                            case 43:
                            case 44:
                            case 84:
                            {
                                List<string> menuBaHatMit = new List<string>();
                                var bongTaiPorata2 = character.CharacterHandler.GetItemBagById(921);

                                menuBaHatMit = MenuNpc.Gi().MenuBaHatMit[(character.InfoChar.IsNhanBua ? 0 : 1)];

                                if (bongTaiPorata2 != null)
                                {
                                    menuBaHatMit[(character.InfoChar.IsNhanBua ? 5 : 4)] = "Mở chỉ số\nBông tai\nPorata cấp 2";
                                }

                                character.CharacterHandler.SendMessage(
                                    Service
                                        .OpenUiConfirm(npcId, MenuNpc.Gi().TextBaHatMit[0], menuBaHatMit, character.InfoChar.Gender));
                                character.TypeMenu = 0;
                                break;
                            }
                            case 46:
                            {
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBaHatMit[0], MenuNpc.Gi().MenuBaHatMit[15], character.InfoChar.Gender));
                                character.TypeMenu = 14;
                                break;
                            }
                        }

                        break;
                    }
                    //Bumma TL
                    case 37:
                    {
						switch(character.InfoChar.Task.Id)
						{
							case 25:
							{
								if (character.InfoChar.Task.Index == 3)
								{
									character.InfoChar.Task.Index++;
									character.InfoChar.Task.Count = 0;
									character.CharacterHandler.SendMeMessage(Service.SendTask(character));
									character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Ơn giời con đây rồi, ta đang chờ con nãy giờ đây :>"));
								}
								else if (character.InfoChar.Task.Index == 5)
								{
									character.InfoChar.Task.Id++;
									character.InfoChar.Task.Index = 0;
									character.InfoChar.Task.Count = 0;
									character.CharacterHandler.SendMeMessage(Service.SendTask(character));
									character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Chà, khoẻ đấy, không làm ta thất vọng, tiếp tục nào!"));
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBumma[0], MenuNpc.Gi().MenuShopDistrict[1], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
								break;
							}
							case 26:
							{
								if (character.InfoChar.Task.Index == 4)
								{
									character.InfoChar.Task.Id++;
									character.InfoChar.Task.Index = 0;
									character.InfoChar.Task.Count = 0;
									character.CharacterHandler.SendMeMessage(Service.SendTask(character));
									character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Mạnh thế, khoẻ thế, tiếp tục đi con zai"));
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBumma[0], MenuNpc.Gi().MenuShopDistrict[1], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
								break;
							}
							case 27:
							{
								if (character.InfoChar.Task.Index == 4)
								{
									character.InfoChar.Task.Id++;
									character.InfoChar.Task.Index = 0;
									character.InfoChar.Task.Count = 0;
									character.CharacterHandler.SendMeMessage(Service.SendTask(character));
									character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Mạnh thế, khoẻ thế, tiếp tục đi con zai"));
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBumma[0], MenuNpc.Gi().MenuShopDistrict[1], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
								break;
							}
							case 28:
							{
								if (character.InfoChar.Task.Index == 5)
								{
									character.InfoChar.Task.Id++;
									character.InfoChar.Task.Index = 0;
									character.InfoChar.Task.Count = 0;
									character.CharacterHandler.SendMeMessage(Service.SendTask(character));
									character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Không làm ta thất vọng nhề, quá ngon zai"));
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBumma[0], MenuNpc.Gi().MenuShopDistrict[1], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
								break;
							}
							case 29:
							{
								if (character.InfoChar.Task.Index == 5)
								{
									character.InfoChar.Task.Id++;
									character.InfoChar.Task.Index = 0;
									character.InfoChar.Task.Count = 0;
									character.CharacterHandler.SendMeMessage(Service.SendTask(character));
									character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Được vl luôn con zai, tối nay ta dẫn con đi chơi gái coi như trả công nhé :>"));
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBumma[0], MenuNpc.Gi().MenuShopDistrict[1], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
								break;
							}
							case 30:
							{
								if (character.InfoChar.Task.Index == 5)
								{
									character.InfoChar.Task.Id++;
									character.InfoChar.Task.Index = 0;
									character.InfoChar.Task.Count = 0;
									character.CharacterHandler.SendMeMessage(Service.SendTask(character));
									character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Không làm ta thất vọng nhề, quá ngon zai"));
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBumma[0], MenuNpc.Gi().MenuShopDistrict[1], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
								break;
							}
							default:
							{
								character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBumma[0], MenuNpc.Gi().MenuShopDistrict[1], character.InfoChar.Gender));
								character.TypeMenu = 0;
								break;
							}
						}
						break;
                    }
                    // Bò mộng
                    case 17:
                    {
                        if (character.InfoChar.Task.Id == 9 || character.InfoChar.Task.Id == 5)
                        {
                            character.InfoChar.Task.Id++;
                            character.InfoChar.Task.Index = 0;
                            character.InfoChar.Task.Count = 0;
                            character.CharacterHandler.SendMeMessage(Service.SendTask(character));
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Làm tốt lắm! Ngươi đã hoàn thành nhiệm vụ Thành Tích."));
                        }
                        else 
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Chức năng Thành Tích đang được cập nhật, quay lại sau nhé."));
                        }
                        break;
                    }
                    // Ca lích
                    case 38:
                    {
                        switch (character.InfoChar.MapId)
                        {
                            case 28:
                            {
								if(character.InfoChar.Task.Id == 25)
								{
									if (character.InfoChar.Task.Index == 1)
									{
										character.InfoChar.Task.Index++;
										character.InfoChar.Task.Count = 0;
										character.CharacterHandler.SendMeMessage(Service.SendTask(character));
										character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, MenuNpc.Gi().TextCalich[1]));
									}
									else 
									{
										character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextCalich[0], MenuNpc.Gi().MenuCalich[0], character.InfoChar.Gender));
										character.TypeMenu = 0;
									}
								}
								else 
								{
									character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextCalich[0], MenuNpc.Gi().MenuCalich[0], character.InfoChar.Gender));
									character.TypeMenu = 0;
								}
								break;
                            }
                            case 102:
                            {
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextCalich[0], MenuNpc.Gi().MenuCalich[1], character.InfoChar.Gender));
                                character.TypeMenu = 1;
                                break;
                            }
                        }
                        break;
                    }
                    //Santa
                    case 39:
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextSanta[0], MenuNpc.Gi().MenuSanta[0], character.InfoChar.Gender));
                        character.TypeMenu = 0;
                        break;
                    }
                    // case 40:
                    //{
                    //     character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextCTnew[0], MenuNpc.Gi().MenucT[0], character.InfoChar.Gender));
                    //    character.TypeMenu = 0;
                    //    break;
                    //}
                    // trung thu
                    case 41:
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextTrungThu[0], MenuNpc.Gi().MenuTrungThu[0], character.InfoChar.Gender));
                        character.TypeMenu = 0;
                        break;
                    }
                    //Quốc vương
                    case 42:
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuocVuong[0], MenuNpc.Gi().MenuQuocVuong[0], character.InfoChar.Gender));
                        character.TypeMenu = 0;
                        break;
                    }
                    // Giu ma
                    case 47:
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextGiuMa[0], MenuNpc.Gi().MenuGiuMa[0], character.InfoChar.Gender));
                        character.TypeMenu = 0;
                        break;
                    }
					//vados
					case 58:
					{
						character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, "[NGƯƠI CÓ MUỐN CƯỜNG HÓA CHO TRANG BỊ CỦA NGƯƠI ?]\nTa sẽ Nâng cấp trang bị [Kích Hoạt] Của ngươi\nKhi nâng cấp xong trang bị của ngươi sẽ tăng 1 bậc\nTrở thành [Trang bị Cường Hóa],\nNhưng ngươi sẽ phải trả Nguyên Liệu và Tiền Công", MenuNpc.Gi().MenuVados[0], character.InfoChar.Gender));
                        character.TypeMenu = 0;
                        break;
					}
					case 49:
                        {
                            switch (character.InfoChar.MapId)
                            {
                                case 0:
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextDuongTang[0], MenuNpc.Gi().MenuDuongTang[0], character.InfoChar.Gender));
                                    character.TypeMenu = 0;
                                    break;
                                case 123:
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextDuongTang[1], MenuNpc.Gi().MenuDuongTang[1], character.InfoChar.Gender));
                                    character.TypeMenu = 1;
                                    break;
                                case 122:
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextDuongTang[2], MenuNpc.Gi().MenuDuongTang[2], character.InfoChar.Gender));
                                    character.TypeMenu = 2;
                                    break;
                            }
                            break;
                        }
                    // Quả trứng
                    case 50:
                    {
                        if (character.InfoChar.ThoiGianTrungMaBu <= 0) return;
                        var seconds = (character.InfoChar.ThoiGianTrungMaBu - ServerUtils.CurrentTimeMillis()) / 1000;
                        if (seconds > 0) //chưa đủ thời gian nở
                        {
                            MenuNpc.Gi().MenuQuaTrung[0][0] = "Chờ\n" + ServerUtils.GetTimeAgo((int)seconds);
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuaTrung[0], MenuNpc.Gi().MenuQuaTrung[0], character.InfoChar.Gender));
                            character.TypeMenu = 0;
                        }
                        else 
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuaTrung[0], MenuNpc.Gi().MenuQuaTrung[1], character.InfoChar.Gender));
                            character.TypeMenu = 1;
                        }
                        break;
                    }
                    // Bill
                    case 55:
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBill[0], MenuNpc.Gi().MenuBill[0], character.InfoChar.Gender));
                        character.TypeMenu = 0;
                        break;
                    }
                    // Nồi bánh
                    case 66:
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextNoiBanh[0], MenuNpc.Gi().MenuNoiBanh[0], character.InfoChar.Gender));
                        character.TypeMenu = 0;
                        break;
                    }
					// Shop Gold Bar
                    case 74:
                    {
						if(character.CharacterHandler.GetItemBagById(457) == null || character.CharacterHandler.GetItemBagById(457).Quantity < 50)
                            {
								character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Tổn luồi, thỏi vàng đâu nôn ra"));
                                break;
                            }
						else {
							character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextGoldShop[0], MenuNpc.Gi().MenuGoldShop[0], character.InfoChar.Gender));
							character.TypeMenu = 0;
						}
                        break;
                    }
					
					// Cay thong duyt
                    case 75:
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextCayThong[0], MenuNpc.Gi().MenuCayThong[0], character.InfoChar.Gender));
                        character.TypeMenu = 0;
                        break;
                    }
                    // Mrpopo
                    case 67:
                    {
                        break;
                    }
                    default:
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, TextServer.gI().UPDATING));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Server.Gi().Logger.Error($"Error OpenUiMenu in Menu.cs: {e.Message} \n {e.StackTrace}", e);
            }
        }

        public static void MenuHandler(Message message, Character character)
        {
            try
            {
                var npcId = message.Reader.ReadByte();
                var menuId = message.Reader.ReadByte();
                var optionId = message.Reader.ReadByte();
                Server.Gi().Logger.Debug($"Menu Handler --------------------------- {npcId} - {menuId} - {optionId}");
                switch (npcId)
                {
                    //Đậu thần
                    case 4:
                    {
                        MenuDauThan(character, npcId, menuId, optionId);
                        break;
                    }
                    default:
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, TextServer.gI().UPDATING));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Server.Gi().Logger.Error($"Error Menu Handler in Menu.cs: {e.Message} \n {e.StackTrace}", e);
            }
            finally
            {
                message?.CleanUp();
            }
        }

        public static void UiConfirm(Message message, Character character)
        {
            try
            {
                var npcId = message.Reader.ReadShort();
                var select = message.Reader.ReadByte();
                switch (npcId)
                {
                    case 0:
                    case 1:
                    case 2:
                    {
                        // 3 ông già
                        ConfirmBaOngGia(character, npcId, select);
                        break;
                    }
                    case 5:
                    {
                        ConfirmMeo(character, npcId, select);
                        break;
                    }
                    case 7: {
                        ConfirmBumma(character, npcId, select);
                        break;
                    }
                    case 8: {
                        ConfirmDende(character, npcId, select);
                        break;
                    }
                    case 9: {
                        ConfirmAppule(character, npcId, select);
                        break;
                    }
                    case 10: {
                        ConfirmBrief(character, npcId, select);
                        break;
                    }
                    case 11: {
                        ConfirmCargo(character, npcId, select);
                        break;
                    }
                    case 12: {
                        ConfirmCui(character, npcId, select);
                        break;
                    }
                    case 13: {
                        ConfirmQuyLao(character, npcId, select);
                        break;
                    }
                    case 14: {
                        ConfirmTruongLaoGuru(character, npcId, select);
                        break;
                    }
                    case 15: {
                        ConfirmVuaVegeta(character, npcId, select);
                        break;
                    }
                    case 18: {
                        ConfirmThanMeo(character, npcId, select);
                        break;
                    }
                    case 19: {
                        ConfirmThuongDe(character, npcId, select);
                        break;
                    }
                    case 20: {
                        ConfirmThanVuTru(character, npcId, select);
                        break;
                    }
                    case 21: {
                        ConfirmBaHatMit(character, npcId, select);
                        break;
                    }
                    case 23: {
                        ConfirmGhiDanh(character, npcId, select);
                        break;
                    }
                    case 24: {
                        ConfirmRongThan(character, npcId, select);
                        break;
                    }
                    case 25: {
                        character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Sẽ mở vào ngày 10/11"));
                        break;
                    }
					case 27: {
                        ConfirmRongXuong(character, npcId, select);
                        break;
                    }
                    case 37: {
                        ConfirmBummaTL(character, npcId, select);
                        break;
                    }
                    case 38: {
                        ConfirmCalich(character, npcId, select);
                        break;
                    }
                    case 39: {
                        ConfirmSanta(character, npcId, select);
                        break;
                    }
					case 40: {
                        ConfirmCTnew(character, npcId, select);
                        break;
                    }
                     case 41: {
                         ConfirmTrungThu(character, npcId, select);
                         break;
                     }
                    case 42: {
                        ConfirmQuocVuong(character, npcId, select);
                        break;
                    }
					case 58:
                        {
                            ConfirmVados(character, npcId, select);
                            break;
                        }
                    case 47:
                    {
                        ConfirmGiuMa(character, npcId, select);
                        break;
                    }
					case 49:
                        ConfirmDuongTang(character, npcId, select);
                        break;
                    case 50: {
                        if (character.InfoChar.ThoiGianTrungMaBu <= 0)
                        {
                            UserDB.BanUser(character.Player.Id);
                            ClientManager.Gi().KickSession(character.Player.Session);
                            ServerUtils.WriteLog("hacktrung", $"Tên tài khoản {character.Player.Username} (ID:{character.Player.Id}) hack trứng");

                            var temp = ClientManager.Gi().GetPlayer(character.Player.Id);
                            if (temp != null)
                            {
                                ClientManager.Gi().KickSession(temp.Session);
                            }
                            return;
                        }
                        ConfirmQuaTrung(character, npcId, select);
                        break;
                    }
                    case 55: {
                        ConfirmBill(character, npcId, select);
                        break;
                    }
					case 64:
                        confirmMenuAdmin(character, npcId, select);
                        break;
                     case 66: {
                         ConfirmNoiBanh(character, npcId, select);
                         break;
                     }
					 case 74: {
                         ConfirmGoldShop(character, npcId, select);
                         break;
                     }
					 case 68: {
                        ConfirmPanchy(character, npcId, select);
                        break;
                    }
					case 75: {
                         ConfirmCayThong(character, npcId, select);
                         break;
                     }
                }
            }
            catch (Exception e)
            {
                Server.Gi().Logger.Error($"Error Ui Confirm in Menu.cs: {e.Message} \n {e.StackTrace}", e);
            }
            finally
            {
                message?.CleanUp();
            }
        }

        #region Menu COFIRM
		public static void confirmMenuAdmin(Character character, int npcId, int select)
        {
            switch (character.TypeMenu)
            { 
            case 0:

                    switch (select) {
                        case 0:
                            var inputItem = new List<InputBox>();

                            var inputTenCharacter = new InputBox()
                            {
                                Name = "Nhập tên nhân vật",
                                Type = 1,
                            };
                            inputItem.Add(inputTenCharacter);

                            var inputIdItem = new InputBox()
                            {
                                Name = "Nhập ID Item",
                                Type = 1,
                            };
                            inputItem.Add(inputIdItem);

                            var inputSoLuong = new InputBox()
                            {
                                Name = "Nhập Số Lượng",
                                Type = 1,
                            };
                            inputItem.Add(inputSoLuong);

                            character.CharacterHandler.SendMessage(Service.ShowInput("Menu Buff Item", inputItem));
                            character.TypeInput = 4;
                            break;
                        case 1:
                            {
                                var inputBoss = new List<InputBox>();

                                var inputIdBoss = new InputBox()
                                {
                                    Name = "Nhập ID Boss",
                                    Type = 1,
                                };
                                inputBoss.Add(inputIdBoss);


                                character.CharacterHandler.SendMessage(Service.ShowInput("Menu Spawm Boss", inputBoss));
                                character.TypeInput = 5;
                               // break;
                            }
                            break;
                        case 2:
                            {
                                var inputCheckGifcode = new List<InputBox>();

                                var inputCode = new InputBox()
                                {
                                    Name = "Nhập Giftcode",
                                    Type = 1,
                                };
                                inputCheckGifcode.Add(inputCode);
                                character.CharacterHandler.SendMessage(Service.ShowInput("Menu Check giftcode", inputCheckGifcode));
                                character.TypeInput = 12;
                            }
                            break;
                        case 3:
                            var inputTask = new List<InputBox>();

                            var inputIdCharacter = new InputBox()
                            {
                                Name = "Nhập Tên nhân vật",
                                Type = 1,
                            };
                            inputTask.Add(inputIdCharacter);

                            var inputId = new InputBox()
                            {
                                Name = "Nhập ID Nhiệm vụ",
                                Type = 1,
                            };
                            inputTask.Add(inputId);

                            var inputIndex = new InputBox()
                            {
                                Name = "Nhập Index Nhiệm vụ",
                                Type = 1,
                            };
                            inputTask.Add(inputIndex);

                            var inputCount = new InputBox()
                            {
                                Name = "Nhập Count Nhiệm vụ",
                                Type = 1,
                            };
                            inputTask.Add(inputCount);
                            character.CharacterHandler.SendMessage(Service.ShowInput("Menu Buff Nhiệm vụ", inputTask));
                            character.TypeInput = 9;
                            break;
                        case 4:
                            {
                                var inputDeathNote = new List<InputBox>();

                                var inputCharacterCanChet = new InputBox()
                                {
                                    Name = "Nhập Tên Character",
                                    Type = 1,
                                };
                                inputDeathNote.Add(inputCharacterCanChet);



                                character.CharacterHandler.SendMessage(Service.ShowInput("☠Death Note☠️", inputDeathNote));
                                character.TypeInput = 10;
                            }
                            break;
                        case 5:
                            {
                                var inputMap = new List<InputBox>();

                                var inputIdMap = new InputBox()
                                {
                                    Name = "Nhập ID Map",
                                    Type = 1,
                                };
                                inputMap.Add(inputIdMap);
                                character.CharacterHandler.SendMessage(Service.ShowInput("Menu Teleport To Map", inputMap));
                                character.TypeInput = 6;
                            }
                            break;
                        case 6:
                            {
                             //   var randChar = ClientManager.Gi().GetRandomCharacter();
                             //   Console.WriteLine("randChar: " + randChar.Name);
                                var inputBanned = new List<InputBox>();

                                var inputTenTaiKhoan = new InputBox()
                                {
                                    Name = "Nhập tên nhân vật",
                                    Type = 1,
                                };
                                inputBanned.Add(inputTenTaiKhoan);

                                var inputReason = new InputBox()
                                {
                                    Name = "Nhập lý do khóa",
                                    Type = 1,
                                };
                                inputBanned.Add(inputReason);
                                character.CharacterHandler.SendMessage(Service.ShowInput("Khóa tài khoản", inputBanned));
                                character.TypeInput = 3;
                            }
                            break;
                        case 7:
                            {
                                var inputTiemNang = new List<InputBox>();

                                var inputType = new InputBox()
                                {
                                    Name = "Nhập Type, 0) Sức Mạnh, 1) Tiềm Năng, 2) Tiềm Năng và Sức Mạnh",
                                    Type = 1,
                                };
                                inputTiemNang.Add(inputType);

                                var inputTnsm = new InputBox()
                                {
                                    Name = "Nhập Tiềm Năng",
                                    Type = 1,
                                };
                                inputTiemNang.Add(inputTnsm);


                              //  character.CharacterHandler.SendMessage(Service.ShowInput("Menu Buff Tiềm Năng và Sức Mạnh\nType: \n0) Tiềm năng\n1) Sức mạnh\n 2) Cả 2", inputTiemNang));
                                character.CharacterHandler.SendMessage(Service.ShowInput("Menu Buff Tiềm Năng và Sức Mạnh", inputTiemNang));
                                character.TypeInput = 7;
                            }
                            break;
                        case 8:
                                var inputChiso = new List<InputBox>();

                                var inputName = new InputBox()
                                {
                                    Name = "Nhập Tên Nhân Vật",
                                    Type = 1,
                                };
                                inputChiso.Add(inputName);

                                var inputHP = new InputBox()
                                {
                                    Name = "Nhập HP",
                                    Type = 1,
                                };
                                inputChiso.Add(inputHP);

                                var inputMP = new InputBox()
                                {
                                    Name = "Nhập MP",
                                    Type = 1,
                                };
                                inputChiso.Add(inputMP);

                                var inputSD = new InputBox()
                                {
                                    Name = "Nhập SD",
                                    Type = 1,
                                };
                                inputChiso.Add(inputSD);

                                var inputCM = new InputBox()
                                {
                                    Name = "Nhập Chí Mạng",
                                    Type = 1,
                                };
                                inputChiso.Add(inputCM);

                                var inputAmor = new InputBox()
                                {
                                    Name = "Nhập Giáp",
                                    Type = 1,
                                };
                                inputChiso.Add(inputAmor);

                                character.CharacterHandler.SendMessage(Service.ShowInput("Menu Buff Bẩn Chỉ Số", inputChiso));
                                character.TypeInput = 8;
                            break;
                        case 9:
                            var inputCongTien = new List<InputBox>();

                            var inputChar = new InputBox()
                            {
                                Name = "Nhập Tên Nhân Vật",
                                Type = 1,
                            };
                            inputCongTien.Add(inputChar);

                            var inputMoney = new InputBox()
                            {
                                Name = "Nhập Số Tiền Muốn Cộng",
                                Type = 1,
                            };
                            inputCongTien.Add(inputMoney);
                            character.CharacterHandler.SendMessage(Service.ShowInput("Menu Buff Money", inputCongTien));
                            character.TypeInput = 13;
                            break;
                    }
                    break;
            }
                    
        }
        private static void ConfirmBaOngGia(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0:
                {
                    switch(select)
                    {
                        //case 0://nạp
                        //{
                        //    // character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, MenuNpc.Gi().TextNapThe[0]));
                        //    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextNapThe[0], MenuNpc.Gi().MenuNapThe[0], character.InfoChar.Gender));
                        //    character.TypeMenu = 2;
                        //    character.ShopId = DataCache.SHOP_ID_NAPTHE + npcId;
                        //    break;
                        //}
                         case 0://Nhận 500k ngọc
                         {
                             var timeServer = ServerUtils.CurrentTimeMillis();
                             if (character.Delay.GetGem > timeServer)
                             {
                                 var delay = (character.Delay.GetGem - timeServer) / 1000;
                                 if (delay < 1)
                                 {
                                     delay = 1;
                                 }

                                 character.CharacterHandler.SendMessage(
                                     Service.ServerMessage(string.Format(TextServer.gI().DELAY_SEC,
                                         delay)));
                                 return;
                             }
                             character.PlusDiamond(500000);
                             character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                             character.Delay.GetGem = timeServer + 2000;
                             character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Bạn đã nhận được 500k ngọc"));
                             break;
                         }
                         case 1://Nhận Vàng
                                {
                                    var timeServer = ServerUtils.CurrentTimeMillis();
                                    if (character.Delay.GetGem > timeServer)
                                    {
                                        var delay = (character.Delay.GetGem - timeServer) / 1000;
                                        if (delay < 1)
                                        {
                                            delay = 1;
                                        }

                                        character.CharacterHandler.SendMessage(
                                            Service.ServerMessage(string.Format(TextServer.gI().DELAY_SEC,
                                                delay)));
                                        return;
                                    }
                                    //character.PlusGold(1000000000);
                                    //character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                                    character.Delay.GetGem = timeServer + 2000;
                                    character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Có cái nịt nề hê hê, nạp đi bạn ơi"));
                                    break;
                                }
                            //case 2://nhận lại đệ tử
                        //{
                          //  var timeServer = ServerUtils.CurrentTimeMillis();
                          //  if (character.Delay.GetGem > timeServer)
                          //  {
                          //      var delay = (character.Delay.GetGem - timeServer) / 1000;
                          //      if (delay < 1)
                          //      {
                          //          delay = 1;
                          //      }

                           //     character.CharacterHandler.SendMessage(
                           //         Service.ServerMessage(string.Format(TextServer.gI().DELAY_SEC,
                         //               delay)));
                          //      return;
                          //  }
                        //
                          //  if (character.InfoChar.IsHavePet == false && DiscipleDB.IsAlreadyExist(-character.Id)) //ko load được đệ
                           // {
                           //     character.InfoChar.IsHavePet = true;
                          //      character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Đệ tử của bạn đã trở lại vui lòng thoát hẳn game và đăng nhập lại"));
                           //     return;
                           // }
//
                           // if (character.Disciple == null && !DiscipleDB.IsAlreadyExist(-character.Id))
                            //{
                            //    var disciple = new Disciple();
                           //     disciple.CreateNewDisciple(character);
                            //    disciple.Player = character.Player;
                            //    disciple.CharacterHandler.SetUpInfo();
                           //     character.Disciple = disciple;
                            //    character.InfoChar.IsHavePet = true;
                           //     character.CharacterHandler.SendMessage(Service.Disciple(1, null));
                           //     DiscipleDB.Create(disciple);
                            //    character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Con đã nhận được đệ tử"));
                           // }
                           // else 
                           // {
                           //     character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Con đã có đệ tử rồi mà"));
                            //}
                           // character.Delay.GetGem = timeServer + 300000;
                           // break;
                        //}
                        case 2://đổi mật khẩu
                        {
                            var timeServer = ServerUtils.CurrentTimeMillis();
                            if (character.Delay.UseGiftCode > timeServer)
                            {
                                var delay = (character.Delay.UseGiftCode - timeServer) / 1000;
                                if (delay < 1)
                                {
                                    delay = 1;
                                }

                                character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().DELAY_SEC,
                                        delay)));
                                return;
                            }
                            // nhaapj mk hien tai
                            // nhap mk moi
                            // Nhap sdt dang ky
                            // Hiển thị menu input nhập seri và số thẻ
                            var inputDoiMatKhau = new List<InputBox>();

                            var inputMKHT = new InputBox(){
                                Name = TextServer.gI().INPUT_CURRENT_PASS,
                                Type = 1,
                            };
                            inputDoiMatKhau.Add(inputMKHT);

                            var inputMKM = new InputBox(){
                                Name = TextServer.gI().INPUT_NEW_PASS,
                                Type = 1,
                            };
                            inputDoiMatKhau.Add(inputMKM);

                            // var inputSDT = new InputBox(){
                            //     Name = TextServer.gI().INPUT_REG_SDT,
                            //     Type = 0,
                            // };
                            // inputDoiMatKhau.Add(inputSDT);

                            character.CharacterHandler.SendMessage(Service.ShowInput(TextServer.gI().INPUT_CHANGE_PASS, inputDoiMatKhau));
                            character.TypeInput = 2;
                            character.ShopId = npcId;
                            break;
                        }
                        //case 4: //bật tắt hiệu ứng
                        //{
                        //    if (character.InfoChar.HieuUngDonDanh)
                        //    {
                        //        character.InfoChar.HieuUngDonDanh = false;
                        //        character.CharacterHandler.SendMessage(Service.ServerMessage("Đã TẮT hiệu ứng đòn đánh"));
                        //    }
                        //    else 
                        //    {
                        //        character.InfoChar.HieuUngDonDanh = true;
                        //        character.CharacterHandler.SendMessage(Service.ServerMessage("Đã BẬT hiệu ứng đòn đánh"));
                        //    }
                        //    break;
                        //}
                        case 3://top nạp
                        {
                            var bangXepHangTopNap = Server.Gi().BangXepHang.GetListTopNap();
                            bangXepHangTopNap += $"\b{ServerUtils.Color("red")}Điểm tích nạp của bạn là: " + character.Player.DiemTichNap;
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, bangXepHangTopNap));
                           break;
                        }
                        case 4: 
                        {
                            var bangXepHangTopSM = Server.Gi().BangXepHang.GetList();
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, bangXepHangTopSM));
                            break;
                        }
                        case 5: // Hoàn thành nhiệm vụ
                        {
                            var maxTaskId = (short)(Cache.Gi().TASK_TEMPLATES_0.Count - 1);
                            if (character.InfoChar.Task.Id < maxTaskId)
                            {
                                character.InfoChar.Task.Id++;
                                character.InfoChar.Task.Index = 0;
                                character.InfoChar.Task.Count = 0;
                                character.CharacterHandler.SendMessage(Service.SendTask(character));
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Bạn đã được tự động qua nhiệm vụ tiếp theo!"));
                            }
                            else 
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Bạn đã ở nhiệm vụ cuối cùng!"));
                            }
                            break;
                        }
                        // case 5://đỏi máy chủ
                        // {
                        //     var delayChangeServer = character.InfoChar.ThoiGianDoiMayChu;
                        //     var timeServer = ServerUtils.CurrentTimeMillis();
                        //     if (delayChangeServer > timeServer)
                        //     {
                        //         var time = (delayChangeServer - timeServer) / 1000;
                        //         character.CharacterHandler.SendMessage(
                        //             Service.ServerMessage(string.Format(TextServer.gI().DELAY_CHANGE_SV, time)));
                        //         return;
                        //     }
                        //     character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBaOngGia[2], MenuNpc.Gi().MenuBaOngGia[1], character.InfoChar.Gender));
                        //     character.TypeMenu = 1;
                        //     break;
                        // }
                        
                    }
                    break;
                }
                case 1:
                {
                    var timeServer = ServerUtils.CurrentTimeMillis();
                    switch (select)
                    {
                        case 0:
                        {
                            if (DatabaseManager.Manager.gI().ServerPort == 14445)
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Bạn đang ở máy chủ này rồi"));
                                return;
                            }

                            character.InfoChar.ThoiGianDoiMayChu = timeServer + 1800000;
                            var userId = character.Player.Id;
                            character.Delay.DoiMayChu = true;
                            UserDB.UpdatePort(userId, 14445);
                            ClientManager.Gi().KickSession(character.Player.Session);
                            break;
                        }
                        case 1:
                        {
                            // if (DatabaseManager.Manager.gI().ServerPort == 14446)
                            // {
                            //     character.CharacterHandler.SendMessage(Service.ServerMessage("Bạn đang ở máy chủ này rồi"));
                            //     return;
                            // }
                            // character.InfoChar.ThoiGianDoiMayChu = timeServer + 1800000;
                            // if (!character.InfoChar.IsPremium)
                            // {
                            //     character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_PREMIUM));
                            //     return;
                            // }
                            // var userId = character.Player.Id;
                            // character.Delay.DoiMayChu = true;
                            // UserDB.UpdatePort(userId, 14446);
                            // ClientManager.Gi().KickSession(character.Player.Session);
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private static void ConfirmMeo(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                //Thách đấu
                case 0:
                {
                    if (DataCache.IdMapCustom.Contains(character.InfoChar.MapCustomId))
                    {
                        character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().DOT_NOT_TEST_HERE));
                        return;
                    }
                    var zone = MapManager.Get(character.InfoChar.MapId)?.GetZoneById(character.InfoChar.ZoneId);
                    if (zone == null) return;
                    var testChar =  (Character)zone.ZoneHandler.GetCharacter(character.Test.CheckId);
                    if(testChar == null) character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_FOUND_CHAR_IN_MAP));
                    else
                    {
                        switch (select)
                        {
                            //1,000 vàng
                            case 0:
                            {
                                if (character.InfoChar.Gold < 1000)
                                {
                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_GOLD));
                                    character.Test.GoldTest = 0;
                                }
                                else
                                {
                                    var text = string.Format(TextServer.gI().SEND_TEST, character.Name, ServerUtils.GetPower(character.InfoChar.Potential), 1000);
                                    character.Test.GoldTest = testChar.Test.GoldTest = 1000;
                                    testChar
                                        .CharacterHandler
                                        .SendMessage(Service
                                            .PlayerVsPLayer(3, character.Id, 1000, text));
                                }
                                break;
                            }
                            //10,000 vàng
                            case 1:
                            {
                                if (character.InfoChar.Gold < 10000)
                                {
                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_GOLD));
                                    character.Test.GoldTest = 0;
                                }
                                else
                                {
                                    var text = string.Format(TextServer.gI().SEND_TEST, character.Name, ServerUtils.GetPower(character.InfoChar.Potential), 10000);
                                    character.Test.GoldTest = testChar.Test.GoldTest = 10000;
                                    testChar
                                        .CharacterHandler
                                        .SendMessage(Service
                                            .PlayerVsPLayer(3, character.Id, 10000, text));
                                }
                                break;
                            }
                            //100,000 vàng
                            case 2:
                            {
                                if (character.InfoChar.Gold < 100000)
                                {
                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_GOLD));
                                    character.Test.GoldTest = 0;
                                }
                                else
                                {
                                    var text = string.Format(TextServer.gI().SEND_TEST, character.Name, ServerUtils.GetPower(character.InfoChar.Potential), 100000);
                                    character.Test.GoldTest = testChar.Test.GoldTest = 100000;
                                    testChar
                                        .CharacterHandler
                                        .SendMessage(Service
                                            .PlayerVsPLayer(3, character.Id, 100000, text));
                                }
                                break;
                            }
                        }
                    }
                    break;
                }
                //Nâng cấp đậu
                case 1:
                {
                    var magicTree = MagicTreeManager.Get(character.Id);
                    if(magicTree == null || select == 1) return;
                    lock (magicTree)
                    {
                        var levelTree = magicTree.Level;
                        var gold = DataCache.UpgradeDauThanGold[levelTree - 1];
                        if (character.InfoChar.Gold < gold)
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_GOLD));
                            return;
                        }
                        character.MineGold(gold);
                        magicTree.IsUpdate = true;
                        magicTree.Seconds = DataCache.UpgradeDauThanTime[levelTree - 1] + ServerUtils.CurrentTimeMillis();
                        magicTree.MagicTreeHandler.HandleNgoc();
                        character.CharacterHandler.SendMessage(Service.MagicTree0(magicTree));
                        character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                    }
                    break;
                }
                //Huỷ nâng cấp đậu
                case 2:
                {
                    var magicTree = MagicTreeManager.Get(character.Id);
                    if(magicTree == null || select == 1) return;
                    lock (magicTree)
                    {
                        var levelTree = magicTree.Level;
                        var gold = DataCache.UpgradeDauThanGold[levelTree - 1];
                        character.PlusGold(gold/2);
                        magicTree.IsUpdate = false;
                        if (magicTree.Peas == magicTree.MaxPea)
                        {
                            magicTree.Seconds = 0;
                        }
                        else
                        {
                            magicTree.Seconds = 60000 * magicTree.Level + ServerUtils.CurrentTimeMillis();
                        }
                        magicTree.MagicTreeHandler.HandleNgoc();
                        character.CharacterHandler.SendMessage(Service.MagicTree0(magicTree));
                        character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                    }
                    break;
                }
                //Kết bạn
                case 3:
                {
                    if(select != 0 || character.FriendTemp == null) return;
                    character.Friends.Add(character.FriendTemp);
                    var @char = ClientManager.Gi().GetCharacter(character.FriendTemp.Id);
                    @char?.CharacterHandler.SendMessage(Service.WorldChat((Character)character, string.Format(TextServer.gI().ADD_FRIEND, character.Name, @char.Name), 1));
                    character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().ADD_FRIEND_2, character.FriendTemp.Name)));
                    character.FriendTemp = null;
                    break;
                }
                //Xoá kết bạn
                case 4:
                {
                    if(select != 0 || character.FriendTemp == null) return;
                    character.Friends.RemoveAll(friend => friend.Id == character.FriendTemp.Id);
                    character.CharacterHandler.SendMessage(Service.ListFriend2(character.FriendTemp.Id));
                    character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().FRIEND_DELETE, character.FriendTemp.Name)));
                    character.FriendTemp = null;
                    break;
                }
                //Dịch chuyển tới người chơi
                case 5:
                {
                    if(select != 0 || character.EnemyTemp == null) return;
                    var charCheck = ClientManager.Gi().GetCharacter(character.EnemyTemp.Id);
                    if (charCheck == null)
                    {
                        character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().USER_OFFLINE));
                    }
                    else
                    {
                        var mapId = character.InfoChar.MapId;
                        if (DataCache.IdMapCustom.Contains(mapId))
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().TELEPORT_ERROR));
                        }
                        else
                        {

                        }
                    }

                    character.EnemyTemp = null;
                    break;
                }
                //Rời bang
                case 6:
                {
                    if(select != 0) return;
                    var clan = ClanManager.Get(character.ClanId);
                    if (clan == null) return;
                    var me = clan.ClanHandler.GetMember(character.Id);
                    if (clan.ClanHandler.RemoveMember(me.Id))
                    {
                        var lastMess = clan.Messages.LastOrDefault();
                        var id = lastMess != null ? lastMess.Id + 1 : 0;
                        clan.ClanHandler.Chat(new ClanMessage()
                        {
                            Type = 0,
                            Id = id,
                            PlayerId = -1,
                            PlayerName = "Thông báo",
                            Role = 0,
                            Time = ServerUtils.CurrentTimeSecond() - 1000000000,
                            Text = string.Format(TextServer.gI().LEAVE_CLAN, me.Name),
                            Color = 1,
                            NewMessage = true,
                        });
                        character.ClanId = -1;
                        character.InfoChar.Bag = -1;
                        clan.ClanHandler.SendUpdateClan();
                        if(character.InfoChar.PhukienPart == -1)character.CharacterHandler.SendZoneMessage(Service.SendImageBag(character.Id, -1));
                        character.CharacterHandler.SendMessage(Service.GetImageBag(null));
                        character.CharacterHandler.SendMessage(Service.MyClanInfo());
                        character.CharacterHandler.SendZoneMessage(Service.UpdateClanId(character.Id, -1));
                        clan.ClanHandler.UpdateClanId();
                        CharacterDB.Update(character);
                        ClanDB.Update(clan);
                    }
                    break;
                }
                //Xoá thù địch
                case 7:
                {
                    if(select != 0 || character.EnemyTemp == null) return;
                    character.Enemies.RemoveAll(enemy => enemy.Id == character.EnemyTemp.Id);
                    character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().ENEMY_DELETE, character.EnemyTemp.Name)));
                    character.EnemyTemp = null;
                    break;
                }
                //Đồng ý kích hoạt mã
                case 8:
                {
                    if(select != 0 || character.InfoChar.LockInventory.PassTemp == -1) return;
                    if (character.InfoChar.Gold < 50000)
                    {
                        character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_GOLD));
                        return;
                    }
                    character.MineGold(50000);
                    character.InfoChar.LockInventory.IsLock = true;
                    character.InfoChar.LockInventory.Pass = character.InfoChar.LockInventory.PassTemp;
                    character.InfoChar.LockInventory.PassTemp = -1;
                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().ACTIVE_LOCK_INVENTORY));
                    character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                    break;
                }
                //Mở/Khoá rương
                case 9:
                {
                    if(select != 0 || character.InfoChar.LockInventory.Pass == -1) return;
                    character.InfoChar.LockInventory.IsLock = !character.InfoChar.LockInventory.IsLock;
                    character.CharacterHandler.SendMessage(character.InfoChar.LockInventory.IsLock
                        ? Service.ServerMessage(TextServer.gI().SUCCESS_LOCK_INVENTORY)
                        : Service.ServerMessage(TextServer.gI().UNACTIVE_LOCK_INVENTORY));
                    break;
                }
                // Nội tại
                case 10:
                {
                    switch(select)
                    {
                        case 0: //Xem tất cả nội tại
                        {
                            character.CharacterHandler.SendMessage(Service.SpeacialSkill(character, 1));
                            break;
                        }
                        case 1: //Mở nội tại thường
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(5, string.Format(MenuNpc.Gi().TextNoiTai[1], DataCache.PRICE_UNLOCK_SPECIAL_SKILL),
                                    MenuNpc.Gi().MenuNoiTai[1], character.InfoChar.Gender));
                            character.TypeMenu = 11;
                            break;
                        }
                        case 2: //Mở nội tại VIP
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(5, string.Format(MenuNpc.Gi().TextNoiTai[2], ServerUtils.GetMoney(DataCache.PRICE_UNLOCK_SPECIAL_SKILL_VIP)),
                                    MenuNpc.Gi().MenuNoiTai[2], character.InfoChar.Gender));
                            character.TypeMenu = 12;
                            break;
                        }

                    }
                    break;
                }
                case 11://mở nội tại thường
                {
                    var specialSkillTemplate = Cache.Gi().SPECIAL_SKILL_TEMPLATES.FirstOrDefault(s => s.Key == character.InfoChar.Gender).Value;
                    if (specialSkillTemplate == null) return;
                    if(character.AllDiamond() < DataCache.PRICE_UNLOCK_SPECIAL_SKILL) {
                        character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_DIAMOND));
                        return;
                    }
                    character.MineDiamond(DataCache.PRICE_UNLOCK_SPECIAL_SKILL);

                    int RandomIndex = ServerUtils.RandomNumber(specialSkillTemplate.Count);
                    SpecialSkillTemplate SkillRandom = specialSkillTemplate[RandomIndex];

                    int ValueRandom = 0;
                    
                    if (SkillRandom.Vip == 1) {
                        ValueRandom = ServerUtils.RandomNumber(SkillRandom.Min, SkillRandom.Max/2);
                    }
                    else 
                    {
                        ValueRandom = ServerUtils.RandomNumber(SkillRandom.Min, SkillRandom.Max + 1);
                    }
                    
                    string InfoRandom = SkillRandom.InfoFormat.Replace("#", ValueRandom + "");

                    character.SpecialSkill.Id = SkillRandom.Id;
                    character.SpecialSkill.Info = InfoRandom;
                    character.SpecialSkill.Img = SkillRandom.Img;
                    character.SpecialSkill.SkillId = SkillRandom.SkillId;
                    character.SpecialSkill.Value = ValueRandom;
                    character.CharacterHandler.SendMessage(Service.ServerMessage("Bạn đã mở nội tại " + InfoRandom));
                    character.CharacterHandler.SendMessage(Service.SpeacialSkill(character, 0));
                    character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                    break;
                } 
                case 12://mở nội tại VIP
                {
                    var specialSkillTemplate = Cache.Gi().SPECIAL_SKILL_TEMPLATES.FirstOrDefault(s => s.Key == character.InfoChar.Gender).Value;
                    if (specialSkillTemplate == null) return;
                    if(character.InfoChar.Gold < DataCache.PRICE_UNLOCK_SPECIAL_SKILL_VIP) {
                        character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_GOLD));
                        return;
                    }
                    character.MineGold(DataCache.PRICE_UNLOCK_SPECIAL_SKILL_VIP);

                    int RandomIndex = ServerUtils.RandomNumber(specialSkillTemplate.Count);
                    SpecialSkillTemplate SkillRandom = specialSkillTemplate[RandomIndex];

                    int ValueRandom = 0;

                    ValueRandom = ServerUtils.RandomNumber(SkillRandom.Min, SkillRandom.Max + 1);
                    
                    string InfoRandom = SkillRandom.InfoFormat.Replace("#", ValueRandom + "");

                    character.SpecialSkill.Id = SkillRandom.Id;
                    character.SpecialSkill.Info = InfoRandom;
                    character.SpecialSkill.Img = SkillRandom.Img;
                    character.SpecialSkill.SkillId = SkillRandom.SkillId;
                    character.SpecialSkill.Value = ValueRandom;
                    character.CharacterHandler.SendMessage(Service.ServerMessage("Bạn đã mở nội tại " + InfoRandom));
                    character.CharacterHandler.SendMessage(Service.SpeacialSkill(character, 0));
                    character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                    break;
                }
            }
        }
        
        private static void ConfirmBumma(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0:
                {
                    if (character.InfoChar.Gender != 0)
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, MenuNpc.Gi().TextBumma[1]));
                    }
                    else if (select == 0)
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBumma[0], MenuNpc.Gi().MenuShopDistrict[1], character.InfoChar.Gender));
                        character.TypeMenu = 1;
                    }
                    break;
                }
                //Show shop
                case 1:
                {
                    if(select == 1) return;
                    var shopId = 12;
                    character.CharacterHandler.SendMessage(Service.Shop(character, 0, shopId));
                    character.ShopId = shopId;
                    character.TypeMenu = 0;
                    break;
                }
            }
        }

        private static void ConfirmBummaTL(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0:
                {
                    if(select == 1) return;
                    var shopId = 22;
                    character.CharacterHandler.SendMessage(Service.Shop(character, 0, shopId));
                    character.ShopId = shopId;
                    character.TypeMenu = 0;
                    break;
                }
            }
        }
        
        private static void ConfirmDende(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0:
                {
                    if (character.InfoChar.Gender != 1)
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, MenuNpc.Gi().TextDende[1]));
                    }
                    else if (select == 0)
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextDende[0], MenuNpc.Gi().MenuShopDistrict[1], character.InfoChar.Gender));
                        character.TypeMenu = 1;
                    }
                    break;
                }
                //Show shop
                case 1:
                {
                    if(select == 1) return;
                    var idShop = 13;
                    character.CharacterHandler.SendMessage(Service.Shop(character, 0, idShop));
                    character.ShopId = idShop;
                    character.TypeMenu = 0;
                    break;
                }
            }
        }
        
        private static void ConfirmAppule(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0:
                {
                    if (character.InfoChar.Gender != 2)
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, MenuNpc.Gi().TextAppule[1]));
                    }
                    else if (select == 0)
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextAppule[0], MenuNpc.Gi().MenuShopDistrict[1], character.InfoChar.Gender));
                        character.TypeMenu = 1;
                    }
                    break;
                }
                //Show shop
                case 1:
                {
                    if(select == 1) return;
                    var idShop = 14;
                    character.CharacterHandler.SendMessage(Service.Shop(character, 0, idShop));
                    character.ShopId = idShop;
                    character.TypeMenu = 0;
                    break;
                }
            }
        }
        
        private static void ConfirmBrief(Character character, short npcId, int select)
        {
            var map = MapManager.Get(character.InfoChar.MapId);
            if (map == null) return;
            Threading.Map mapJoin;
            if (map.Id == 84)
            {
                mapJoin = MapManager.Get(character.InfoChar.Gender + 24);
            }
            else
            {
                switch (select)
                {
                    case 0:
                    {
                        mapJoin = MapManager.Get(26);
                        break;
                    }
                    case 1:
                    {
                        mapJoin = MapManager.Get(25);
                        break;
                    }
                    case 2:
                    {
                        mapJoin = MapManager.Get(84);
                        break;
                    }
                    default:
                    {
                        return;
                    }
                }
            }

            if (mapJoin == null) return;
            var zoneJoin = mapJoin.GetZoneNotMaxPlayer();
            if (zoneJoin != null)
            {
                character.CharacterHandler.SendZoneMessage(Service.SendTeleport(character.Id, character.InfoChar.Teleport));
                map.OutZone(character, mapJoin.Id);
                zoneJoin.ZoneHandler.JoinZone(character, false, true, character.InfoChar.Teleport);
            }
            else
            {
                character.CharacterHandler.SendMessage(Service.OpenUiSay(5, TextServer.gI().MAX_NUMCHARS, false, character.InfoChar.Gender));
            }
        }
        
        private static void ConfirmCargo(Character character, short npcId, int select)
        {
            var map = MapManager.Get(character.InfoChar.MapId);
            if (map == null) return;
            Threading.Map mapJoin;
            switch (select)
            {
                case 0:
                {
                    mapJoin = MapManager.Get(24);
                    break;
                }
                case 1:
                {
                    mapJoin = MapManager.Get(26);
                    break;
                }
                case 2:
                {
                    mapJoin = MapManager.Get(84);
                    break;
                }
                default:
                {
                    return;
                }
            }

            if (mapJoin == null) return;
            var zoneJoin = mapJoin.GetZoneNotMaxPlayer();
            if (zoneJoin != null)
            {
                character.CharacterHandler.SendZoneMessage(Service.SendTeleport(character.Id, character.InfoChar.Teleport));
                map.OutZone(character, mapJoin.Id);
                zoneJoin.ZoneHandler.JoinZone(character, false, true, character.InfoChar.Teleport);
            }
            else
            {
                character.CharacterHandler.SendMessage(Service.OpenUiSay(5, TextServer.gI().MAX_NUMCHARS, false, character.InfoChar.Gender));
            }
        }
        
        private static void ConfirmCui(Character character, short npcId, int select)
        {
            var map = MapManager.Get(character.InfoChar.MapId);
            if (map == null) return;
            Threading.Map mapJoin = null;
            switch (map.Id)
            {
                case 19 when @select == 0:
                {
                    if (character.InfoChar.Power < 80000000000) {
                        character.CharacterHandler.SendMessage(Service.OpenUiSay(5, "Bạn cần đạt 80 tỷ sức mạnh mới có thể qua hành tinh Cold", false, character.InfoChar.Gender));
                        return;
                    }
					if (character.InfoChar.Task.Id < 31) {
                        character.CharacterHandler.SendMessage(Service.OpenUiSay(5, "Bạn chưa thể đến khu vực này", false, character.InfoChar.Gender));
                        return;
                    }
                    mapJoin = MapManager.Get(109);
                    break;
                }
                case 19:
                {
                    if (@select == 1)
                    {
						if (character.InfoChar.Task.Id < 21)
									{
										character.CharacterHandler.SendMessage(Service.OpenUiSay(5, "Bạn chưa thể đến khu vực này", false, character.InfoChar.Gender));
										return;
									}
                        mapJoin = MapManager.Get(68);
                    }
                    break;
                }
                case 68:
                {
                    if (@select == 0)
                    {
                        mapJoin = MapManager.Get(19);
                    }

                    break;
                }
                default:
                {
                    switch (@select)
                    {
                        case 0:
                        {
                            mapJoin = MapManager.Get(24);
                            break;
                        }
                        case 1:
                        {
                            mapJoin = MapManager.Get(25);
                            break;
                        }
                        case 2:
                        {
                            mapJoin = MapManager.Get(84);
                            break;
                        }
                        default:
                        {
                            return;
                        }
                    }

                    break;
                }
            }

            if (mapJoin == null) return;
            var zoneJoin = mapJoin.GetZoneNotMaxPlayer();
            if (zoneJoin != null)
            {
                character.CharacterHandler.SendZoneMessage(Service.SendTeleport(character.Id, character.InfoChar.Teleport));
                map.OutZone(character, mapJoin.Id);
                zoneJoin.ZoneHandler.JoinZone(character, false, true, character.InfoChar.Teleport);
            }
            else
            {
                character.CharacterHandler.SendMessage(Service.OpenUiSay(5, TextServer.gI().MAX_NUMCHARS, false, character.InfoChar.Gender));
            }
        }
        
        private static void ConfirmQuyLao(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                //Open menu 1
                case 0:
                {
                    switch (select)
                    {
                        //Nói chuyện
                        case 0: {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
                            character.TypeMenu = 1;
                            break;
                        }
                        //Kho báo dưới biển
                        case 1:
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, TextServer.gI().UPDATING));
                            break;
                        }
                    }
                    break;
                }
                //Open menu Nói chuyện
                case 1:
                {
                    switch (select)
                    {
                        case 0:
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, TextServer.gI().UPDATING));
                            break;
                        }
                        case 1:
                        {
                            if (character.InfoChar.LearnSkill != null)
                            {
                                var itemAdd = character.InfoChar.LearnSkill.ItemSkill;
                                var time = character.InfoChar.LearnSkill.Time - ServerUtils.CurrentTimeMillis();
                                var skillTemplate = Cache.Gi().SKILL_TEMPLATES.FirstOrDefault(skill => skill.Id == character.InfoChar.LearnSkill.ItemTemplateSkillId);
                                var itemTempalte = ItemCache.ItemTemplate(itemAdd.Id);
                                var ngoc = 5;
                                if (time / 600000 >= 2)
                                {
                                    ngoc += (int)time / 600000;
                                }

                                var menu = string.Format(TextServer.gI().ADDING_SKILL, skillTemplate.Name,
                                    itemTempalte.Level, ServerUtils.GetTime(time));
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, menu, new List<string>() {$"Học\nCấp tốc\n{ngoc} ngọc", "Huỷ","Bỏ qua"}, character.InfoChar.Gender));
                                character.TypeMenu = 3;
                            }
                            else
                            {
                                var idShop = 7 + character.InfoChar.Gender;
                                character.CharacterHandler.SendMessage(Service.Shop(character, 1, idShop));
                                character.ShopId = idShop;
                                character.TypeMenu = 0;
                            }
                            break;
                        }
                    }
                    break;
                }
                //Học skill
                case 2:
                {
                    switch (select)
                    {
                        //Đồng ý
                        case 0:
                        {
                            if(character.InfoChar.LearnSkillTemp == null) return;
                            var itemAdd = character.InfoChar.LearnSkillTemp.ItemSkill;
                            var time = character.InfoChar.LearnSkillTemp.Time + ServerUtils.CurrentTimeMillis();
                            var idSkill = character.InfoChar.LearnSkillTemp.ItemTemplateSkillId;
                            character.InfoChar.Potential -= itemAdd.BuyPotential;
                            character.InfoChar.LearnSkill = new LearnSkill()
                            {
                                ItemSkill = itemAdd,
                                Time = time,
                                ItemTemplateSkillId = idSkill,
                                Potential = (int)itemAdd.BuyPotential
                            };
                            character.InfoChar.LearnSkillTemp = null;
                            character.CharacterHandler.SendMessage(Service.MeLoadPoint(character));
                            character.CharacterHandler.SendMessage(Service.ClosePanel());
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Con đã học thành công, hãy cố gắng chờ đợi nha"));
                            break;
                        }
                        //Từ chối
                        case 1:
                        {
                            character.InfoChar.LearnSkillTemp = null;
                            break;
                        }
                    }
                    break;
                }
                //Open menu with learn skill
                case 3:
                {
                    switch (select)
                    {
                        //Đồng ý học nhanh
                        case 0:
                        {
                            if(character.InfoChar.LearnSkill == null) return;
                            var itemAdd = character.InfoChar.LearnSkill.ItemSkill;
                            var time = character.InfoChar.LearnSkill.Time - ServerUtils.CurrentTimeMillis();
                            var skillTemplate = Cache.Gi().SKILL_TEMPLATES.FirstOrDefault(skill => skill.Id == character.InfoChar.LearnSkill.ItemTemplateSkillId);
                            if (skillTemplate == null) return;
                            var ngoc = 5;
                            if (time / 600000 >= 2)
                            {
                                ngoc += (int)time / 600000;
                            }
                            if(character.AllDiamond() < ngoc) {
                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_DIAMOND));
                                return;
                            }
                            character.MineDiamond(ngoc);
                            character.InfoChar.LearnSkill = null;
                            character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                            ItemHandler.AddLearnSkill(character, itemAdd, skillTemplate);
                            break;
                        }
                        //Huỷ học skill
                        case 1:
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[3], MenuNpc.Gi().MenuMeo[1], character.InfoChar.Gender));
                            character.TypeMenu = 4;
                            break;
                        }
                        //Open menu 1
                        case 2:
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[0], MenuNpc.Gi().MenuQuyLao[0], character.InfoChar.Gender));
                            character.TypeMenu = 0;
                            break;
                        }
                    }
                    break;
                }
                //Huỷ học skill
                case 4:
                {
                    if(select != 0) return;
                    var plusPoint = character.InfoChar.LearnSkill.Potential / 2;
                    character.CharacterHandler.PlusPoint(0, plusPoint, false);
                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().CANCEL_LEARN_SKILL));
                    character.InfoChar.LearnSkill = null;   
                    character.InfoChar.LearnSkillTemp = null;   
                    break;
                }
            }
        }
		public static Boolean checkOption(Character character, int type)
        {


            var checkAo = character.ItemBody[0];
            var checkQuan = character.ItemBody[1];
            var checkGang = character.ItemBody[2];
            var checkGiay = character.ItemBody[3];
            var checkRada = character.ItemBody[4];
            if (character != null)
            {
                var g = character.InfoChar.Gender;
                switch (type)
                {
                    case 0:
                        if (g == 0)
                        {
                            if (checkAo.isHaveOption(127) || checkAo.isHaveOption(128) || checkAo.isHaveOption(129))
                            {
                                return true;
                              
                            }
                            return false;
                        }
                        if (g == 1)
                        {
                            if (checkAo.isHaveOption(130) || checkAo.isHaveOption(131) || checkAo.isHaveOption(132))
                            {
                                return true;
                                
                            }
                            //  break;
                            return false;
                        }
                        if (g == 2)
                        {
                            if (checkAo.isHaveOption(133) || checkAo.isHaveOption(134) || checkAo.isHaveOption(135))
                            {
                                return true;
                                
                            }
                            return false;
                        }
                        break;
                    case 1:
                        if (g == 0)
                        {
                            if (checkQuan.isHaveOption(127) || checkQuan.isHaveOption(128) || checkQuan.isHaveOption(129))
                            {
                                return true;
                            }
                            return false;
                        }
                        if (g == 1)
                        {
                            if (checkQuan.isHaveOption(130) || checkQuan.isHaveOption(131) || checkQuan.isHaveOption(132))
                            {
                                return true;
                                
                            }
                            return false;
                        }
                        if (g == 2)
                        {
                            if (checkQuan.isHaveOption(133) || checkQuan.isHaveOption(134) || checkQuan.isHaveOption(135))
                            {
                                return true;
                               
                            }
                            return false;
                        }
                        break;
                    case 2:
                        if (g == 0)
                        {
                            if (checkGang.isHaveOption(127) || checkGang.isHaveOption(128) || checkGang.isHaveOption(129))
                            {
                                return true;
                               
                            }
                            return false;
                        }
                        if (g == 1)
                        {
                            if (checkGang.isHaveOption(130) || checkGang.isHaveOption(131) || checkGang.isHaveOption(132))
                            {
                                return true;
                                
                            }
                            return false;
                        }
                        if (g == 2)
                        {
                            if (checkGang.isHaveOption(133) || checkGang.isHaveOption(134) || checkGang.isHaveOption(135))
                            {
                                return true;
                                
                            }
                            return false;
                        }
                        break;
                    case 3:

                        if (g == 0)
                        {
                            if (checkGiay.isHaveOption(127) || checkGiay.isHaveOption(128) || checkGiay.isHaveOption(129))
                            {
                                return true;
                                
                            }
                            return false;
                        }
                        if (g == 1)
                        {
                            if (checkGiay.isHaveOption(130) || checkGiay.isHaveOption(131) || checkGiay.isHaveOption(132))
                            {
                                return true;
                               
                            }
                            return false;
                        }
                        if (g == 2)
                        {
                            if (checkGiay.isHaveOption(133) || checkGiay.isHaveOption(134) || checkGiay.isHaveOption(135))
                            {
                                return true;
                                
                            }
                            return false;
                        }
                        break;
                    case 4:
                        if (g == 0)
                        {
                            if (checkRada.isHaveOption(127) || checkRada.isHaveOption(128) || checkRada.isHaveOption(129))
                            {
                                return true;
                               
                            }
                            return false;
                        }
                        if (g == 1)
                        {
                            if (checkRada.isHaveOption(130) || checkRada.isHaveOption(131) || checkRada.isHaveOption(132))
                            {
                                return true;
                                
                            }
                            return false;
                        }
                        if (g == 2)
                        {
                            if (checkRada.isHaveOption(133) || checkRada.isHaveOption(134) || checkRada.isHaveOption(135))
                            {
                                return true;
                               
                            }
                            return false;
                        }
                        break;
                }

            }
            return false;

        }
        public static Boolean checkToAddOptionCuongHoa(Character character)
        {
            if (typeCuongHoa == 0 && character.ItemBody[0].isHaveOption(135) || typeCuongHoa == 1 && character.ItemBody[1].isHaveOption(135) || typeCuongHoa == 2 && character.ItemBody[2].isHaveOption(135) || typeCuongHoa == 3 && character.ItemBody[3].isHaveOption(135) || typeCuongHoa == 4 && character.ItemBody[4].isHaveOption(135))
            {
                return true;
            }
            if (typeCuongHoa == 0 && character.ItemBody[0].isHaveOption(134) || typeCuongHoa == 1 && character.ItemBody[1].isHaveOption(134) || typeCuongHoa == 2 && character.ItemBody[2].isHaveOption(134) || typeCuongHoa == 3 && character.ItemBody[3].isHaveOption(134) || typeCuongHoa == 4 && character.ItemBody[4].isHaveOption(134))
            {
                return true;
            }
            if (typeCuongHoa == 0 && character.ItemBody[0].isHaveOption(133) || typeCuongHoa == 1 && character.ItemBody[1].isHaveOption(133) || typeCuongHoa == 2 && character.ItemBody[2].isHaveOption(133) || typeCuongHoa == 3 && character.ItemBody[3].isHaveOption(133) || typeCuongHoa == 4 && character.ItemBody[4].isHaveOption(133))
            {
                return true;
            }
            if (character.ItemBody[0].isHaveOption(132) || character.ItemBody[1].isHaveOption(132) || character.ItemBody[2].isHaveOption(132) || character.ItemBody[3].isHaveOption(132) || character.ItemBody[4].isHaveOption(132))
            {
                return true;
            }
            if (character.ItemBody[0].isHaveOption(131) || character.ItemBody[1].isHaveOption(131) || character.ItemBody[2].isHaveOption(131) || character.ItemBody[3].isHaveOption(131) || character.ItemBody[4].isHaveOption(131))
            {
                return true;
            }
            if (character.ItemBody[0].isHaveOption(130) || character.ItemBody[1].isHaveOption(130) || character.ItemBody[2].isHaveOption(130) || character.ItemBody[3].isHaveOption(130) || character.ItemBody[4].isHaveOption(130))
            {
                return true;
            }
            if (character.ItemBody[0].isHaveOption(129) || character.ItemBody[1].isHaveOption(129) || character.ItemBody[2].isHaveOption(129) || character.ItemBody[3].isHaveOption(129) || character.ItemBody[4].isHaveOption(129))
            {
                return true;
            }
            if (character.ItemBody[0].isHaveOption(128) || character.ItemBody[1].isHaveOption(128) || character.ItemBody[2].isHaveOption(128) || character.ItemBody[3].isHaveOption(128) || character.ItemBody[4].isHaveOption(128))
            {
                return true;
            }
            if (character.ItemBody[0].isHaveOption(127) || character.ItemBody[1].isHaveOption(127) || character.ItemBody[2].isHaveOption(127) || character.ItemBody[3].isHaveOption(127) || character.ItemBody[4].isHaveOption(127))
            {
                return true;
            }
            return false;
        }
        public static String getNameItem(Character character, int type, int typeItem, int itemBody)
        {
            switch (type)
            {
                case 0: // hien tai
                    if (character.InfoChar.Gender == 2)
                    {
                        if (typeItem == 0)
                        {
                            return "Áo Vải Thô";
                        }
                        if (typeItem == 1)
                        {
                            return "Áo Lông Đỏ";
                        }
                        if (typeItem == 2)
                        {
                            return "Áo Lưỡng Long";
                        }
                        if (typeItem == 3)
                        {
                            return "Áo Thần Linh Xayda";
                        }
                    }
                    if (character.InfoChar.Gender == 1)
                    {
                        if (typeItem == 0)
                        {
                            return "Áo Sợi len";
                        }
                        if (typeItem == 1)
                        {
                            return "Áo sắt Tron";
                        }
                        if (typeItem == 2)
                        {
                            return "Áo Vàng Zealot";
                        }
                        if (typeItem == 3)
                        {
                            return "Áo Thần Linh Namec";
                        }
                    }
                    if (character.InfoChar.Gender == 2)
                    {
                        if (typeItem == 0)
                        {
                            return "Áo Vải 3 lỗ";
                        }
                        if (typeItem == 1)
                        {
                            return "Áo bạc Goku";
                        }
                        if (typeItem == 2)
                        {
                            return "Áo Jean Calic";
                        }
                        if (typeItem == 3)
                        {
                            return "Áo Thần Linh";
                        }
                    }
                    break;
                case 1:
                    return ""; // sau khi cường hóa
                   

            }
            return "";
        }
        public static String getTextCost(int type)
        {
            return type * 2 + " [Đá Hắc hoả] và [Đá Vĩnh hằnng]";
        }
        public static int getCost(int cost)
        {
            return cost * 2;
        }
        public static int getTiLe(int level)
        {
            return 80 - level * 10;
        }
        public static int cost(int cost)
        {
            if (cost == 1)
            {
                return 2;
            }
            if (cost == 9)
            {
                return 4;

            }
            if (cost == 12)
            {
                return 6;
            }
            if (cost == 13)
            {
                return 8;
            }
            return 0;
        }
		private static void ConfirmVados(Character character, short NpcId, int select)
        {
            var checkAo = character.ItemBody[0];
            var checkQuan = character.ItemBody[1];
            var checkGang = character.ItemBody[2];
            var checkGiay = character.ItemBody[3];
            var checkRada = character.ItemBody[4];
            //if (checkAo != null || checkQuan != null || checkGang != null || checkGiay != null | checkRada != null)
            //{

            //    var templateQuan = ItemCache.ItemTemplate(checkQuan.Id);
            //    var templateGang = ItemCache.ItemTemplate(checkGang.Id);
            //    var templateGiay = ItemCache.ItemTemplate(checkGiay.Id);
            //    var templateRada = ItemCache.ItemTemplate(checkRada.Id);
            //}
            switch (character.TypeMenu)
            {
                case 0:
                    switch (select)
                    {
                        case 0:
                            if (checkAo == null)
                            {
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: [Không Tìm Thấy]" + "\n|2|Không thể Cường Hóa", MenuNpc.Gi().MenuVados[2], character.InfoChar.Gender));
                            }
                            else
                            {
                                var templateAo = ItemCache.ItemTemplate(checkAo.Id);
                                if (checkAo.Id == 0 || checkAo.Id == 1 || checkAo.Id == 2)
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateAo.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(1) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(1) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                }
                                else if (checkAo.Id == 230 || checkAo.Id == 234 || checkAo.Id == 238)
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateAo.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(2) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(2) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                }
                                else if (checkAo.Id == 233 || checkAo.Id == 237 || checkAo.Id == 241)
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateAo.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(3) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(3) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                }
                                //else if (checkAo.Id == 555 || checkAo.Id == 557 || checkAo.Id == 559)
                                //{
                                //    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateAo.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(5) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(5) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                //}
                                else
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: [Không Hợp Lệ]" + "\n|2|Không thể Cường Hóa", MenuNpc.Gi().MenuVados[2], character.InfoChar.Gender));
                                }
                            }
                            character.TypeMenu = 1;
                            break;
                        case 1:
                            if (checkQuan == null)
                            {
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: [Không Tìm Thấy]" + "\n|2|Không thể Cường Hóa", MenuNpc.Gi().MenuVados[2], character.InfoChar.Gender));
                            }
                            else
                            {
                                var templateQuan = ItemCache.ItemTemplate(checkQuan.Id);

                                if (checkQuan.Id == 6 + character.InfoChar.Gender)
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateQuan.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(1) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(1) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                }
                                else if (checkQuan.Id == 242 || checkQuan.Id == 246 || checkQuan.Id == 250)
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateQuan.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(2) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(2) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                }
                                else if (checkQuan.Id == 245 || checkQuan.Id == 249 || checkQuan.Id == 253)
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateQuan.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(3) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(3) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                }
                                //else if (checkQuan.Id == 556 || checkQuan.Id == 558 || checkQuan.Id == 560)
                                //{
                                //    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateQuan.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(5) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(5) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                //}
                                else
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: [Không Hợp Lệ]" + "\n|2|Không thể Cường Hóa", MenuNpc.Gi().MenuVados[2], character.InfoChar.Gender));
                                }
                            }
                            character.TypeMenu = 2;
                            break;
                        case 2:
                            if (checkGang == null)
                            {
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: [Không Tìm Thấy]" + "\n|2|Không thể Cường Hóa", MenuNpc.Gi().MenuVados[2], character.InfoChar.Gender));
                            }
                            else
                            {
                                var templateGang = ItemCache.ItemTemplate(checkGang.Id);
                                if (checkGang.Id == 21 + character.InfoChar.Gender)
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateGang.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(1) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(1) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                }
                                else if (checkGang.Id == 254 || checkGang.Id == 258 || checkGang.Id == 262)
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateGang.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(2) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(2) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                }
                                else if (checkGang.Id == 257 || checkGang.Id == 261 || checkGang.Id == 265)
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateGang.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(3) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(3) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                }
                                //else if (checkGang.Id == 562 || checkGang.Id == 564 || checkGang.Id == 566)
                                //{
                                //    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateGang.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(5) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(5) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                //}
                                else
                                {

                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: [Không Hợp Lệ]" + "\n|2|Không thể Cường Hóa", MenuNpc.Gi().MenuVados[2], character.InfoChar.Gender));
                                }

                            }
                            character.TypeMenu = 3;
                            break;

                        case 3:
                            if (checkGiay == null)
                            {
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: [Không Tìm Thấy]" + "\n|2|Không thể Cường Hóa", MenuNpc.Gi().MenuVados[2], character.InfoChar.Gender));
                            }
                            else
                            {
                                var templateGiay = ItemCache.ItemTemplate(checkGiay.Id);
                                if (checkGiay.Id == 27 + character.InfoChar.Gender)
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateGiay.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(1) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(1) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                }
                                else if (checkGiay.Id == 266 || checkGiay.Id == 270 || checkGiay.Id == 274)
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateGiay.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(2) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(2) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                }
                                else if (checkGiay.Id == 269 || checkGiay.Id == 273 || checkGiay.Id == 277)
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateGiay.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(3) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(3) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                }
                                //else if (checkGiay.Id == 563 || checkGiay.Id == 565 || checkGiay.Id == 567)
                                //{
                                //    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateGiay.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(5) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(5) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                //}
                                else
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: [Không Hợp Lệ]" + "\n|2|Không thể Cường Hóa", MenuNpc.Gi().MenuVados[2], character.InfoChar.Gender));
                                }
                            }
                            character.TypeMenu = 4;
                            break;
                        case 4:
                            if (checkRada == null)
                            {
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: [Không Tìm Thấy]" + "\n|2|Không thể Cường Hóa", MenuNpc.Gi().MenuVados[2], character.InfoChar.Gender));
                            }
                            else
                            {

                                var templateRada = ItemCache.ItemTemplate(checkRada.Id);
                                if (checkRada.Id == 12)
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateRada.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(1) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(1) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                }
                                else if (checkRada.Id == 278)
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateRada.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(2) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(2) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                }
                                else if (checkRada.Id == 281)
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateRada.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(3) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(3) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                }
                                ///else if (checkRada.Id == 561)
                                //{
                                //    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: " + templateRada.Name + "\n|2|Sau khi Cường Hóa trang bị của bạn sẽ tăng 1 bậc\nTiêu hao " + getTextCost(5) + "\n|0|Tỉ lệ Cường Hóa thành công: " + getTiLe(5) + "%", MenuNpc.Gi().MenuVados[1], character.InfoChar.Gender));
                                //}
                                else
                                {
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(NpcId, "|7|Vật phẩm Hiện Tại: [Không Hợp Lệ]" + "\n|2|Không thể Cường Hóa", MenuNpc.Gi().MenuVados[2], character.InfoChar.Gender));
                                }
                            }
                            character.TypeMenu = 5;
                            break;
                    }

                    break;
                case 1:
                    {

                        switch (select)
                        {
                            case 0:
                                if (character.ItemBody[0] == null)
                                {
                                    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Bạn chưa mặc Giáp"));
                                    break;
                                }

                                if (checkOption(character, 0))
                                {

                                    if (character.ItemBody[0].Id == 0 + character.InfoChar.Gender)
                                    {
                                        for (int dball = 1093; dball <= 1094; dball++)
                                        {
                                            if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 2)
                                            {
                                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                return;
                                            }
                                        }
                                        CuongHoaTrangBi(character, 0, 0);
                                        character.CharacterHandler.RemoveItemBody(0);
                                        for (short dball = 1093; dball <= 1094; dball++)
                                        {
                                            character.CharacterHandler.RemoveItemBagById(dball, 2, "Cường Hóa");
                                        }
                                        character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                        character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                    }
                                    else if (checkAo.Id == 230 || checkAo.Id == 234 || checkAo.Id == 238)
                                    {
                                        for (int dball = 1093; dball <= 1094; dball++)
                                        {
                                            if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 4)
                                            {
                                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                return;
                                            }
                                        }
                                        CuongHoaTrangBi(character, 1, 0);
                                        character.CharacterHandler.RemoveItemBody(0);
                                        for (short dball = 1093; dball <= 1094; dball++)
                                        {
                                            character.CharacterHandler.RemoveItemBagById(dball, 4, "Cường Hóa");
                                        }
                                        character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                        character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                    }
                                    else if (checkAo.Id == 233 || checkAo.Id == 237 || checkAo.Id == 241)
                                    {
                                        for (int dball = 1093; dball <= 1094; dball++)
                                        {
                                            if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 6)
                                            {
                                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                return;
                                            }
                                        }
                                        CuongHoaTrangBi(character, 2, 0);
                                        character.CharacterHandler.RemoveItemBody(0);
                                        for (short dball = 1093; dball <= 1094; dball++)
                                        {
                                            character.CharacterHandler.RemoveItemBagById(dball, 6, "Cường Hóa");
                                        }
                                        character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                        character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                    }
                                    else if (checkAo.Id == 555 || checkAo.Id == 557 || checkAo.Id == 559)
                                    {
                                        for (int dball = 1093; dball <= 1094; dball++)
                                        {
                                            if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 8)
                                            {
                                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                return;
                                            }
                                        }
                                        CuongHoaTrangBi(character, 3, 0);
                                        character.CharacterHandler.RemoveItemBody(0);
                                        for (short dball = 1093; dball <= 1094; dball++)
                                        {
                                            character.CharacterHandler.RemoveItemBagById(dball, 8, "Cường Hóa");
                                        }
                                        character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                        character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                    }
                                    else
                                    {
                                        character.CharacterHandler.SendMeMessage(Service.ServerMessage("Vật phẩm Cường Hóa không hợp lệ!"));
                                    }
                                    break;
                                }
                                else
                                {
                                    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Yêu cầu trang bị kích hoạt !"));
                                    break;
                                }


                                
                            case 1:
                                break;
                        }
                    }
                    break;
                case 2:
                    {

                        switch (select)
                        {
                            case 0:
                                if (character.ItemBody[1] == null)
                                {
                                    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Bạn chưa mặc Quần"));
                                    break;
                                }
                                else
                                {
                                    if (checkOption(character, 1))
                                    {

                                        if (checkQuan.Id == 6 + character.InfoChar.Gender)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 2)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 0, 1);
                                            character.CharacterHandler.RemoveItemBody(1);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 2, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }
                                        else if (checkQuan.Id == 242 || checkQuan.Id == 246 || checkQuan.Id == 250)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 4)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 1, 1);
                                            character.CharacterHandler.RemoveItemBody(1);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 4, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }
                                        else if (checkQuan.Id == 245 || checkQuan.Id == 249 || checkQuan.Id == 252)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 6)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 2, 1);
                                            character.CharacterHandler.RemoveItemBody(1);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 6, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }
                                        else if (checkQuan.Id == 556 || checkQuan.Id == 558 || checkQuan.Id == 560)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 8)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 3, 1);
                                            character.CharacterHandler.RemoveItemBody(1);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 8, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }
                                        else
                                        {
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Vật phẩm Cường Hóa không hợp lệ!"));
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        character.CharacterHandler.SendMeMessage(Service.ServerMessage("Yêu cầu trang bị kích hoạt !"));
                                        break;
                                    }
                                }
                        }
                        break;
                    }
                case 3:
                    {

                        switch (select)
                        {
                            case 0:
                                if (character.ItemBody[2] == null)
                                {
                                    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Bạn chưa mặc Găng"));
                                    break;
                                }
                                else
                                {
                                    if (checkOption(character, 2))
                                    {
                                        var templateGang = ItemCache.ItemTemplate(checkGang.Id);
                                        if (checkGang.Id == 21 + character.InfoChar.Gender)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 2)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 0, 2);
                                            character.CharacterHandler.RemoveItemBody(2);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 2, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }

                                        else if (templateGang.Level == 9)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 4)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 1, 2);
                                            character.CharacterHandler.RemoveItemBody(2);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 4, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }
                                        else if (templateGang.Level == 12)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 6)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 2, 2);
                                            character.CharacterHandler.RemoveItemBody(2);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 6, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }
                                        else if (templateGang.Level == 13)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 8)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 3, 2);
                                            character.CharacterHandler.RemoveItemBody(2);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 8, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }
                                        else
                                        {
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Vật phẩm Cường Hóa không hợp lệ!"));
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        character.CharacterHandler.SendMeMessage(Service.ServerMessage("Yêu cầu trang bị kích hoạt !"));
                                        break;
                                    }
                                }

                               
                        }
                    }
                    break;
                case 4:
                    {

                        switch (select)
                        {
                            case 0:
                                if (character.ItemBody[3] == null)
                                {
                                    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Bạn chưa mặc Giày"));
                                    break;
                                }
                                else
                                {
                                    if (checkOption(character, 3))
                                    {
                                        var templateGiay = ItemCache.ItemTemplate(checkGiay.Id);
                                        if (checkGiay.Id == 27 + character.InfoChar.Gender)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 2)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 0, 3);
                                            character.CharacterHandler.RemoveItemBody(3);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 2, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }

                                        else if (templateGiay.Level == 9)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 4)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 1, 3);
                                            character.CharacterHandler.RemoveItemBody(3);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 4, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }
                                        else if (templateGiay.Level == 12)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 6)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 2, 3);
                                            character.CharacterHandler.RemoveItemBody(3);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 6, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }
                                        else if (templateGiay.Level == 13)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 8)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 3, 3);
                                            character.CharacterHandler.RemoveItemBody(3);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 8, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }
                                        else
                                        {
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Vật phẩm Cường Hóa không hợp lệ!"));
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        character.CharacterHandler.SendMeMessage(Service.ServerMessage("Yêu cầu trang bị kích hoạt !"));
                                        break;
                                    }
                                }

                               
                        }
                    }
                    break;
                case 5:
                    {

                        switch (select)
                        {
                            case 0:
                                if (character.ItemBody[4] == null)
                                {
                                    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Bạn chưa mặc Rada"));
                                    break;
                                }
                                else
                                {
                                    if (checkOption(character, 4))
                                    {
                                        var templateRada = ItemCache.ItemTemplate(checkRada.Id);
                                        if (checkRada.Id == 12)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 2)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 0, 4);
                                            character.CharacterHandler.RemoveItemBody(4);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 2, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }

                                        else if (templateRada.Level == 9)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 4)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 1, 4);
                                            character.CharacterHandler.RemoveItemBody(4);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 4, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }
                                        else if (templateRada.Level == 12)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 6)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 2, 4);
                                            character.CharacterHandler.RemoveItemBody(4);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 6, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }
                                        else if (templateRada.Level == 13)
                                        {
                                            for (int dball = 1093; dball <= 1094; dball++)
                                            {
                                                if (character.CharacterHandler.GetItemBagById(dball) == null || character.CharacterHandler.GetItemBagById(dball).Quantity < 8)
                                                {
                                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_GENDER));
                                                    return;
                                                }
                                            }
                                            CuongHoaTrangBi(character, 3, 4);
                                            character.CharacterHandler.RemoveItemBody(4);
                                            for (short dball = 1093; dball <= 1094; dball++)
                                            {
                                                character.CharacterHandler.RemoveItemBagById(dball, 8, "Cường Hóa");
                                            }
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã Cường Hóa Thành Công !!"));
                                            character.CharacterHandler.SendMeMessage(Service.ServerChat(character.Name + " đã Cường Hóa thành công trang bị!!!"));
                                        }
                                        else
                                        {
                                            character.CharacterHandler.SendMeMessage(Service.ServerMessage("Vật phẩm Cường Hóa không hợp lệ!"));
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        character.CharacterHandler.SendMeMessage(Service.ServerMessage("Yêu cầu trang bị kích hoạt !"));
                                        break;
                                    }
                                }

                               
                        }
                    }
                    break;
            }
        }
        public static void CuongHoaTrangBi(Character character, int set, int type)
        {
            var itemCuongHoa = ItemCache.GetItemDefault(1);
            var itemTemplate = ItemCache.ItemTemplate(itemCuongHoa.Id);
            switch (set)
            {
                case 0:
                    switch (type)
                    {
                        case 0:

                            if (character.ItemBody[0] == null)
                            {
                                return;
                            }
                            if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(230);


                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(234);


                            }
                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(238);


                            }
                            break;
                        case 1:
                            if (character.ItemBody[1] == null)
                            {
                                return;
                            }
                            if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(242);


                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(246);

                            }

                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(250);


                            }
                            break;
                        case 2:
                            if (character.ItemBody[2] == null)
                            {
                                return;
                            }
                            if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(254);

                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(258);


                            }
                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(262);


                            }
                            break;
                        case 3:
                            if (character.ItemBody[3] == null)
                            {
                                return;
                            }
                            if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(266);

                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(270);


                            }
                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(274);


                            }
                            break;
                        case 4:
                            if (character.ItemBody[4] == null)
                            {
                                return;
                            }
                            if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(278);


                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(278);


                            }
                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(278);


                            }
                            break;
                    }
                    break;
                case 1:
                    switch (type)
                    {
                        case 0:

                            if (character.ItemBody[0] == null)
                            {
                                return;
                            }
                            if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(233);

                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(237);


                            }
                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(241);


                            }
                            break;
                        case 1:
                            if (character.ItemBody[1] == null)
                            {
                                return;
                            }
                            if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(245);


                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(249);

                            }

                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(253);


                            }
                            break;
                        case 2:
                            if (character.ItemBody[2] == null)
                            {
                                return;
                            }
                            if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(257);

                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(261);


                            }
                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(265);


                            }
                            break;
                        case 3:
                            if (character.ItemBody[3] == null)
                            {
                                return;
                            }
                            if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(269);

                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(273);


                            }
                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(277);


                            }
                            break;
                        case 4:
                            if (character.ItemBody[4] == null)
                            {
                                return;
                            }
                            if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(281);

                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(281);


                            }
                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(281);


                            }
                            break;

                    }
                    break;
                case 2:
                    switch (type)
                    {
                        case 0:

                            if (character.ItemBody[0] == null)
                            {
                                return;
                            }
                            if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(555);


                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(557);


                            }
                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(559);


                            }
                            break;
                        case 1:
                            if (character.ItemBody[1] == null)
                            {
                                return;
                            }
                            if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(556);


                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(558);

                            }

                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(560);

                            }
                            break;
                        case 2:
                            if (character.ItemBody[2] == null)
                            {
                                return;
                            }
                            if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(562);

                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(564);


                            }
                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(566);


                            }
                            break;
                        case 3:
                            if (character.ItemBody[3] == null)
                            {
                                return;
                            }
                            if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(563);

                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(565);


                            }
                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(567);


                            }
                            break;
                        case 4:
                            if (character.ItemBody[4] == null)
                            {
                                return;
                            }
                            itemCuongHoa = ItemCache.GetItemDefault(561);
                            break;

                    }
                    break;
                case 3:
                    switch (type)
                    {
                        case 0:
                            if (character.ItemBody[type] == null)
                            {
                                return;
                            }
                            else if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(650);
                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(652);
                            }
                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(654);
                            }

                            break;
                        case 1:
                            if (character.ItemBody[type] == null)
                            {
                                return;
                            }
                            else if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(651);
                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(653);
                            }
                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(655);
                            }
                            break;
                        case 2:
                            if (character.ItemBody[type] == null)
                            {
                                return;
                            }
                            else if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(657);
                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(659);
                            }
                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(661);
                            }
                            break;
                        case 3:
                            if (character.ItemBody[type] == null)
                            {
                                return;
                            }
                            else if (character.InfoChar.Gender == 0)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(658);
                            }
                            else if (character.InfoChar.Gender == 1)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(660);
                            }
                            else if (character.InfoChar.Gender == 2)
                            {
                                itemCuongHoa = ItemCache.GetItemDefault(662);
                            }
                            break;
                        case 4:
                            if (character.ItemBody[type] == null)
                            {
                                return;
                            }
                            itemCuongHoa = ItemCache.GetItemDefault(656);

                            break;
                    }
                    break;
            }
            var randomChiS = ServerUtils.RandomNumber(100);
            if (character.InfoChar.Gender == 0)
            {
                itemCuongHoa.Options.Add(new OptionItem()
                {
                    Id = 230,
                    Param = 0,
                });
                if (randomChiS <= 30)
                {
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 127,
                        Param = 0,

                    });
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 139,
                        Param = 0,

                    });
                }
                else if (randomChiS <= 60)
                {
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 128,
                        Param = 0,
                    });
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 140,
                        Param = 0,

                    });
                }
                else if (randomChiS <= 100)
                {
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 129,
                        Param = 0,
                    });
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 141,
                        Param = 0,

                    });
                }

            }
            else if (character.InfoChar.Gender == 1)
            {
                itemCuongHoa.Options.Add(new OptionItem()
                {
                    Id = 230,
                    Param = 0,
                });
                if (randomChiS <= 30)
                {
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 130,
                        Param = 0,

                    });
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 142,
                        Param = 0,

                    });
                }
                else if (randomChiS <= 50)
                {
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 131,
                        Param = 0,
                    });
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 143,
                        Param = 0,

                    });
                }
                else if (randomChiS <= 70)
                {
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 132,
                        Param = 0,
                    });
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 144,
                        Param = 0,

                    });
                }
            }
            else if (character.InfoChar.Gender == 2)
            {
                itemCuongHoa.Options.Add(new OptionItem()
                {
                    Id = 230,
                    Param = 0,
                });
                if (randomChiS <= 20)
                {
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 133,
                        Param = 0,

                    });
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 136,
                        Param = 0,

                    });
                }
                else if (randomChiS <= 50)
                {
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 134,
                        Param = 0,
                    });
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 137,
                        Param = 0,

                    });
                }
                else if (randomChiS <= 100)
                {
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 135,
                        Param = 0,
                    });
                    itemCuongHoa.Options.Add(new OptionItem()
                    {
                        Id = 138,
                        Param = 0,

                    });
                }
            }


            itemCuongHoa.Quantity = 1;
            character.CharacterHandler.AddItemToBag(false, itemCuongHoa, "Cường Hóa trang bị");
            character.CharacterHandler.SendMessage(Service.SendBag(character));

        }
        public static int typeCuongHoa = 0;

        private static void ConfirmTruongLaoGuru(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                //Open menu Nói chuyện
                case 0:
                {
                    switch (select)
                    {
                        case 0:
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, TextServer.gI().UPDATING));
                            break;
                        }
                        case 1:
                        {
                            if (character.InfoChar.LearnSkill != null)
                            {
                                var itemAdd = character.InfoChar.LearnSkill.ItemSkill;
                                var time = character.InfoChar.LearnSkill.Time - ServerUtils.CurrentTimeMillis();
                                var skillTemplate = Cache.Gi().SKILL_TEMPLATES.FirstOrDefault(skill => skill.Id == character.InfoChar.LearnSkill.ItemTemplateSkillId);
                                var itemTempalte = ItemCache.ItemTemplate(itemAdd.Id);
                                var ngoc = 5;
                                if (time / 600000 >= 2)
                                {
                                    ngoc += (int)time / 600000;
                                }

                                var menu = string.Format(TextServer.gI().ADDING_SKILL, skillTemplate.Name,
                                    itemTempalte.Level, ServerUtils.GetTime(time));
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, menu, new List<string>() {$"Học\nCấp tốc\n{ngoc} ngọc", "Huỷ","Bỏ qua"}, character.InfoChar.Gender));
                                character.TypeMenu = 2;
                            }
                            else
                            {
                                var idShop = 10;
                                character.CharacterHandler.SendMessage(Service.Shop(character, 1, idShop));
                                character.ShopId = idShop;
                                character.TypeMenu = 1;
                            }
                            break;
                        }
                    }
                    break;
                }
                //Học skill
                case 1:
                {
                    switch (select)
                    {
                        //Đồng ý
                        case 0:
                        {
                            if(character.InfoChar.LearnSkillTemp == null) return;
                            var itemAdd = character.InfoChar.LearnSkillTemp.ItemSkill;
                            var time = character.InfoChar.LearnSkillTemp.Time + ServerUtils.CurrentTimeMillis();
                            var idSkill = character.InfoChar.LearnSkillTemp.ItemTemplateSkillId;
                            character.InfoChar.Potential -= itemAdd.BuyPotential;
                            character.InfoChar.LearnSkill = new LearnSkill()
                            {
                                ItemSkill = itemAdd,
                                Time = time,
                                ItemTemplateSkillId = idSkill,
                                Potential = (int)itemAdd.BuyPotential
                            };
                            character.InfoChar.LearnSkillTemp = null;
                            character.CharacterHandler.SendMessage(Service.MeLoadPoint(character));
                            character.CharacterHandler.SendMessage(Service.ClosePanel());
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Con đã học thành công, hãy cố gắng chờ đợi nha"));
                            break;
                        }
                        //Từ chối
                        case 1:
                        {
                            character.InfoChar.LearnSkillTemp = null;
                            break;
                        }
                    }
                    break;
                }
                //Open menu with learn skill
                case 2:
                {
                    switch (select)
                    {
                        //Đồng ý học nhanh
                        case 0:
                        {
                            if(character.InfoChar.LearnSkill == null) return;
                            var itemAdd = character.InfoChar.LearnSkill.ItemSkill;
                            var time = character.InfoChar.LearnSkill.Time - ServerUtils.CurrentTimeMillis();
                            var skillTemplate = Cache.Gi().SKILL_TEMPLATES.FirstOrDefault(skill => skill.Id == character.InfoChar.LearnSkill.ItemTemplateSkillId);
                            if (skillTemplate == null) return;
                            var ngoc = 5;
                            if (time / 600000 >= 2)
                            {
                                ngoc += (int)time / 600000;
                            }
                            if(character.AllDiamond() < ngoc) {
                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_DIAMOND));
                                return;
                            }
                            character.MineDiamond(ngoc);
                            character.InfoChar.LearnSkill = null;
                            character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                            ItemHandler.AddLearnSkill(character, itemAdd, skillTemplate);
                            break;
                        }
                        //Huỷ học skill
                        case 1:
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[3], MenuNpc.Gi().MenuMeo[1], character.InfoChar.Gender));
                            character.TypeMenu = 3;
                            break;
                        }
                        //Open menu 1
                        case 2:
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
                            character.TypeMenu = 0;
                            break;
                        }
                    }
                    break;
                }
                //Huỷ học skill
                case 3:
                {
                    if(select != 0) return;
                    var plusPoint = character.InfoChar.LearnSkill.Potential / 2;
                    character.CharacterHandler.PlusPoint(0, plusPoint, false);
                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().CANCEL_LEARN_SKILL));
                    character.InfoChar.LearnSkill = null;   
                    character.InfoChar.LearnSkillTemp = null;   
                    break;
                }
            }
        }

        private static void ConfirmVuaVegeta(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                //Open menu Nói chuyện
                case 0:
                {
                    switch (select)
                    {
                        case 0:
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, TextServer.gI().UPDATING));
                            break;
                        }
                        case 1:
                        {
                            if (character.InfoChar.LearnSkill != null)
                            {
                                var itemAdd = character.InfoChar.LearnSkill.ItemSkill;
                                var time = character.InfoChar.LearnSkill.Time - ServerUtils.CurrentTimeMillis();
                                var skillTemplate = Cache.Gi().SKILL_TEMPLATES.FirstOrDefault(skill => skill.Id == character.InfoChar.LearnSkill.ItemTemplateSkillId);
                                var itemTempalte = ItemCache.ItemTemplate(itemAdd.Id);
                                var ngoc = 5;
                                if (time / 600000 >= 2)
                                {
                                    ngoc += (int)time / 600000;
                                }

                                var menu = string.Format(TextServer.gI().ADDING_SKILL, skillTemplate.Name,
                                    itemTempalte.Level, ServerUtils.GetTime(time));
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, menu, new List<string>() {$"Học\nCấp tốc\n{ngoc} ngọc", "Huỷ","Bỏ qua"}, character.InfoChar.Gender));
                                character.TypeMenu = 2;
                            }
                            else
                            {
                                var idShop = 11;
                                character.CharacterHandler.SendMessage(Service.Shop(character, 1, idShop));
                                character.ShopId = idShop;
                                character.TypeMenu = 2;
                            }
                            break;
                        }
                    }
                    break;
                }
                //Học skill
                case 1:
                {
                    switch (select)
                    {
                        //Đồng ý
                        case 0:
                        {
                            if(character.InfoChar.LearnSkillTemp == null) return;
                            var itemAdd = character.InfoChar.LearnSkillTemp.ItemSkill;
                            var time = character.InfoChar.LearnSkillTemp.Time + ServerUtils.CurrentTimeMillis();
                            var idSkill = character.InfoChar.LearnSkillTemp.ItemTemplateSkillId;
                            character.InfoChar.Potential -= itemAdd.BuyPotential;
                            character.InfoChar.LearnSkill = new LearnSkill()
                            {
                                ItemSkill = itemAdd,
                                Time = time,
                                ItemTemplateSkillId = idSkill,
                                Potential = (int)itemAdd.BuyPotential
                            };
                            character.InfoChar.LearnSkillTemp = null;
                            character.CharacterHandler.SendMessage(Service.MeLoadPoint(character));
                            character.CharacterHandler.SendMessage(Service.ClosePanel());
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Con đã học thành công, hãy cố gắng chờ đợi nha"));
                            break;
                        }
                        //Từ chối
                        case 1:
                        {
                            character.InfoChar.LearnSkillTemp = null;
                            break;
                        }
                    }
                    break;
                }
                //Open menu with learn skill
                case 2:
                {
                    switch (select)
                    {
                        //Đồng ý học nhanh
                        case 0:
                        {
                            if(character.InfoChar.LearnSkill == null) return;
                            var itemAdd = character.InfoChar.LearnSkill.ItemSkill;
                            var time = character.InfoChar.LearnSkill.Time - ServerUtils.CurrentTimeMillis();
                            var skillTemplate = Cache.Gi().SKILL_TEMPLATES.FirstOrDefault(skill => skill.Id == character.InfoChar.LearnSkill.ItemTemplateSkillId);
                            if (skillTemplate == null) return;
                            var ngoc = 5;
                            if (time / 600000 >= 2)
                            {
                                ngoc += (int)time / 600000;
                            }
                            if(character.AllDiamond() < ngoc) {
                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_DIAMOND));
                                return;
                            }
                            character.MineDiamond(ngoc);
                            character.InfoChar.LearnSkill = null;
                            character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                            ItemHandler.AddLearnSkill(character, itemAdd, skillTemplate);
                            break;
                        }
                        //Huỷ học skill
                        case 1:
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[3], MenuNpc.Gi().MenuMeo[1], character.InfoChar.Gender));
                            character.TypeMenu = 3;
                            break;
                        }
                        //Open menu 1
                        case 2:
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuyLao[1], MenuNpc.Gi().MenuQuyLao[1], character.InfoChar.Gender));
                            character.TypeMenu = 0;
                            break;
                        }
                    }
                    break;
                }
                //Huỷ học skill
                case 3:
                {
                    if(select != 0) return;
                    var plusPoint = character.InfoChar.LearnSkill.Potential / 2;
                    character.CharacterHandler.PlusPoint(0, plusPoint, false);
                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().CANCEL_LEARN_SKILL));
                    character.InfoChar.LearnSkill = null;   
                    character.InfoChar.LearnSkillTemp = null;   
                    break;
                }
            }
        }
		private static void ConfirmThanMeo(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                //Menu ban đầu
                case 0:
                {
                    switch (select)
                    {
                        case 0: // Thách đấu
                        {
                            if (character.InfoChar.Task.Id == 10 && character.InfoChar.Task.Index == 0)
                            {
                                character.InfoChar.Task.Index++;
                                character.InfoChar.Task.Count = 0;
                                character.CharacterHandler.SendMeMessage(Service.SendTask(character));
                                character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Khá lắm, con đã đủ tư cách để uống nước thánh. Nước thánh đây, uống đi rồi xuống núi tiêu diệt Tàu Pảy Pảy nhé!"));
                            }
                            else if (character.InfoChar.Task.Id == 9 && character.InfoChar.Task.Index == 3)
                            {
                                character.InfoChar.Task.Id++;
                                character.InfoChar.Task.Index = 0;
                                character.InfoChar.Task.Count = 0;
                                character.CharacterHandler.SendMeMessage(Service.SendTask(character));
                                character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Chào con, ta là Thần Mèo Karin. Con muốn thách đấu ta sao?"));
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, "Sức mạnh của con còn yếu lắm, hãy tu luyện thêm đi!"));
                            }
                            break;
                        }
                        case 1: // Từ chối
                        {
                            break;
                        }
                    }
                    break;
                }
			}
		}

     /*   private static void ConfirmThanMeo(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                //Menu ban đầu
                case 0: //Đổi điểm sự kiện
                {
                    switch (select)
                    {
                        case 0:
                        {
                            var thanMeo = MenuNpc.Gi().TextThanMeo[1];
                            thanMeo += $"\b{ServerUtils.Color("green")}Điểm sự kiện của bạn là: " + character.DiemSuKien;
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, thanMeo, MenuNpc.Gi().MenuThanMeo[1], character.InfoChar.Gender));
                            character.TypeMenu = 1;
                            break;
                        }
                        case 1:
                        {
                            // chọn đổi điểm tích nạp
                            break;
                        }
                    }
                    break;
                }
                case 1:
                {
                    if (select != 0) return;
                    //chấp nhận đổi điểm sự kiện
                    var mocDiem = 0;
                    var DiemSuKien = character.DiemSuKien;
                    var bagNull = character.LengthBagNull();
                    // - 300 điểm : x10 đá bảo vệ , 5 viên cs trung thu , 10tv
                    // - 500 điểm :  x15 đá bảo vệ , 10 viên cs trung thu .10tv
                    // - 1000 điểm : x20 đá bảo vệ , 25 viên cs trung thu , item lồng đèn tc , 20tv
                    // - 3000 điểm : x30 đá bảo vệ , x99 viên cs trung thu , item lồng đèn tc ,30 tv
                    // - 5000 điểm :x35 đá bảo vệ , x99 viên cs trung thu , item lồng đèn tc , 35tv , ngẫu nhiên item mèo mun , phóng lợn vv….
                    // - 7000 điểm :x50 đá bảo vệ , x99 viên cs trung thu , item lồng đèn , 40 tv , ngẫu nhiên item mèo mun , phóng lợn , pet cua vv…. , random trang bị hủy diệt 10% trở lên
                    // - 10000 điểm :x99 đá bảo vệ , x99 viên cs trung thu , item lồng đèn,50tv ,ngẫu nhiên item mèo mun , phóng lợn , pet cua vv…. , random trang bị hủy diệt 10% trở lên , cải trang vip nhất hiện tại.
                    if (DiemSuKien < 300)
                    {
                        character.CharacterHandler.SendMessage(
                            Service.DialogMessage("Bạn không đủ điểm để đổi"));
                        return;
                    }

                    if (DiemSuKien >= 300 && DiemSuKien <= 499)
                    {
                        if  (bagNull < 3)
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_BAG));
                            return;
                        }
                        var thoivang = ItemCache.GetItemDefault((short)457);
                        thoivang.Quantity = 10;
                        character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi điểm sự kiện tt 300 điểm");

                        var dabaove = ItemCache.GetItemDefault((short)987);
                        dabaove.Quantity = 10;
                        character.CharacterHandler.AddItemToBag(true, dabaove, "Đổi điểm sự kiện tt 300 điểm");

                        var cstrungthu = ItemCache.GetItemDefault((short)737);
                        cstrungthu.Quantity = 5;
                        character.CharacterHandler.AddItemToBag(true, cstrungthu, "Đổi điểm sự kiện tt 300 điểm");
                        character.CharacterHandler.SendMessage(Service.DialogMessage("Bạn đã đổi điểm sự kiện thành công, 10 tv, 10 dbv, 5 cs trung thu"));
                        mocDiem = 1;
                    }
                    else if (DiemSuKien >= 500 && DiemSuKien <= 999)
                    {
                        if  (bagNull < 3)
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_BAG));
                            return;
                        }
                        var thoivang = ItemCache.GetItemDefault((short)457);
                        thoivang.Quantity = 10;
                        character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi điểm sự kiện tt 500 điểm");

                        var dabaove = ItemCache.GetItemDefault((short)987);
                        dabaove.Quantity = 15;
                        character.CharacterHandler.AddItemToBag(true, dabaove, "Đổi điểm sự kiện tt 500 điểm");

                        var cstrungthu = ItemCache.GetItemDefault((short)737);
                        cstrungthu.Quantity = 10;
                        character.CharacterHandler.AddItemToBag(true, cstrungthu, "Đổi điểm sự kiện tt 500 điểm");
                        character.CharacterHandler.SendMessage(Service.DialogMessage("Bạn đã đổi điểm sự kiện thành công, 10 tv, 15 dbv, 10 cs trung thu"));
                        mocDiem = 2;
                    } 
                    else if (DiemSuKien >= 1000 && DiemSuKien <= 2999)
                    {
                        if  (bagNull < 4)
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_BAG));
                            return;
                        }
                        var thoivang = ItemCache.GetItemDefault((short)457);
                        thoivang.Quantity = 20;
                        character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi điểm sự kiện tt 1000 điểm");

                        var dabaove = ItemCache.GetItemDefault((short)987);
                        dabaove.Quantity = 20;
                        character.CharacterHandler.AddItemToBag(true, dabaove, "Đổi điểm sự kiện tt 1000 điểm");

                        var cstrungthu = ItemCache.GetItemDefault((short)737);
                        cstrungthu.Quantity = 25;
                        character.CharacterHandler.AddItemToBag(true, cstrungthu, "Đổi điểm sự kiện tt 1000 điểm");
                        mocDiem = 3;
                    } 
                    else if (DiemSuKien >= 3000 && DiemSuKien <= 4999)
                    {
                        if  (bagNull < 4)
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_BAG));
                            return;
                        }
                        var thoivang = ItemCache.GetItemDefault((short)457);
                        thoivang.Quantity = 30;
                        character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi điểm sự kiện tt 3000 điểm");

                        var dabaove = ItemCache.GetItemDefault((short)987);
                        dabaove.Quantity = 30;
                        character.CharacterHandler.AddItemToBag(true, dabaove, "Đổi điểm sự kiện tt 3000 điểm");

                        var cstrungthu = ItemCache.GetItemDefault((short)737);
                        cstrungthu.Quantity = 99;
                        character.CharacterHandler.AddItemToBag(true, cstrungthu, "Đổi điểm sự kiện tt 3000 điểm");
                        mocDiem = 4;
                    } 
                    else if (DiemSuKien >= 5000 && DiemSuKien <= 6999)
                    {
                        if  (bagNull < 5)
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_BAG));
                            return;
                        }
                        var thoivang = ItemCache.GetItemDefault((short)457);
                        thoivang.Quantity = 35;
                        character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi điểm sự kiện tt 5000 điểm");

                        var dabaove = ItemCache.GetItemDefault((short)987);
                        dabaove.Quantity = 35;
                        character.CharacterHandler.AddItemToBag(true, dabaove, "Đổi điểm sự kiện tt 5000 điểm");

                        var cstrungthu = ItemCache.GetItemDefault((short)737);
                        cstrungthu.Quantity = 99;
                        character.CharacterHandler.AddItemToBag(true, cstrungthu, "Đổi điểm sự kiện tt 5000 điểm");
                        mocDiem = 5;

                        var listitem = new List<short>() {993,995,996,997,998,999,1000,1001}; // item ngẫu nhiên
                        var itemrand = listitem[ServerUtils.RandomNumber(listitem.Count)];
                        var itemAdd = ItemCache.GetItemDefault(itemrand);
                        character.CharacterHandler.AddItemToBag(true, itemAdd, "Đổi điểm sự kiện tt 5000 điểm");
                    } 
                    else if (DiemSuKien >= 7000 && DiemSuKien <= 9999)
                    {
                        if  (bagNull < 6)
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_BAG));
                            return;
                        }
                        var thoivang = ItemCache.GetItemDefault((short)457);
                        thoivang.Quantity = 40;
                        character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi điểm sự kiện tt 7000 điểm");

                        var dabaove = ItemCache.GetItemDefault((short)987);
                        dabaove.Quantity = 50;
                        character.CharacterHandler.AddItemToBag(true, dabaove, "Đổi điểm sự kiện tt 7000 điểm");

                        var cstrungthu = ItemCache.GetItemDefault((short)737);
                        cstrungthu.Quantity = 99;
                        character.CharacterHandler.AddItemToBag(true, cstrungthu, "Đổi điểm sự kiện tt 7000 điểm");
                        mocDiem = 6;

                        var trunglinhthu = ItemCache.GetItemDefault((short)1088);
                        trunglinhthu.Quantity = 1;
                        character.CharacterHandler.AddItemToBag(true, trunglinhthu, "Đổi điểm sự kiện tt 7000 điểm");

                        var listitem = new List<short>() {993,995,996,997,998,999,1000,1001}; // item ngẫu nhiên
                        var itemrand = listitem[ServerUtils.RandomNumber(listitem.Count)];
                        var itemAdd = ItemCache.GetItemDefault(itemrand);
                        character.CharacterHandler.AddItemToBag(true, itemAdd, "Đổi điểm sự kiện tt 7000 điểm");

                        //trang bi huy diet
                        var chiso = ServerUtils.RandomNumber(10, 13);
                        switch (character.InfoChar.Gender)
                        {
                            case 0:
                            {
                                var listHD = new List<short>() {650,651,657,658,656}; // item ngẫu nhiên
                                var itemHDRand = listHD[ServerUtils.RandomNumber(listHD.Count)];
                                var itemHDAdd = ItemCache.GetItemDefault(itemHDRand);
                                itemHDAdd.Options.Where(option => DataCache.IdOptionGoc.Contains(option.Id)).ToList().ForEach(
                                    option => {
                                        option.Param += option.Param*chiso/100;
                                    });
                                character.CharacterHandler.AddItemToBag(true, itemHDAdd, "Đổi điểm sự kiện tt 7000 điểm");
                                break;
                            }
                            case 1:
                            {
                                var listHD = new List<short>() {652,653,659,660,656}; // item ngẫu nhiên
                                var itemHDRand = listHD[ServerUtils.RandomNumber(listHD.Count)];
                                var itemHDAdd = ItemCache.GetItemDefault(itemHDRand);
                                itemHDAdd.Options.Where(option => DataCache.IdOptionGoc.Contains(option.Id)).ToList().ForEach(
                                    option => {
                                        option.Param += option.Param*chiso/100;
                                    });
                                character.CharacterHandler.AddItemToBag(true, itemHDAdd, "Đổi điểm sự kiện tt 7000 điểm");
                                break;
                            }
                            case 2:
                            {
                                var listHD = new List<short>() {654,655,661,662,656}; // item ngẫu nhiên
                                var itemHDRand = listHD[ServerUtils.RandomNumber(listHD.Count)];
                                var itemHDAdd = ItemCache.GetItemDefault(itemHDRand);
                                itemHDAdd.Options.Where(option => DataCache.IdOptionGoc.Contains(option.Id)).ToList().ForEach(
                                    option => {
                                        option.Param += option.Param*chiso/100;
                                    });
                                character.CharacterHandler.AddItemToBag(true, itemHDAdd, "Đổi điểm sự kiện tt 7000 điểm");
                                break;
                            }
                        }
                    } 
                    else if (DiemSuKien >= 10000)
                    {
                        if  (bagNull < 6)
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_BAG));
                            return;
                        }
                        var thoivang = ItemCache.GetItemDefault((short)457);
                        thoivang.Quantity = 50;
                        character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi điểm sự kiện tt 10000 điểm");

                        var dabaove = ItemCache.GetItemDefault((short)987);
                        dabaove.Quantity = 99;
                        character.CharacterHandler.AddItemToBag(true, dabaove, "Đổi điểm sự kiện tt 10000 điểm");

                        var cstrungthu = ItemCache.GetItemDefault((short)737);
                        cstrungthu.Quantity = 99;
                        character.CharacterHandler.AddItemToBag(true, cstrungthu, "Đổi điểm sự kiện tt 10000 điểm");
                        mocDiem = 7;

                        var trunglinhthu = ItemCache.GetItemDefault((short)1088);
                        trunglinhthu.Quantity = 1;
                        character.CharacterHandler.AddItemToBag(true, trunglinhthu, "Đổi điểm sự kiện tt 10000 điểm");

                        var listitem = new List<short>() {993,995,996,997,998,999,1000,1001}; // item ngẫu nhiên
                        var itemrand = listitem[ServerUtils.RandomNumber(listitem.Count)];
                        var itemAdd = ItemCache.GetItemDefault(itemrand);
                        character.CharacterHandler.AddItemToBag(true, itemAdd, "Đổi điểm sự kiện tt 10000 điểm");

                        //trang bi huy diet
                        var chiso = ServerUtils.RandomNumber(10, 13);
                        switch (character.InfoChar.Gender)
                        {
                            case 0:
                            {
                                var listHD = new List<short>() {650,651,657,658,656}; // item ngẫu nhiên
                                var itemHDRand = listHD[ServerUtils.RandomNumber(listHD.Count)];
                                var itemHDAdd = ItemCache.GetItemDefault(itemHDRand);
                                itemHDAdd.Options.Where(option => DataCache.IdOptionGoc.Contains(option.Id)).ToList().ForEach(
                                    option => {
                                        option.Param += option.Param*chiso/100;
                                    });
                                character.CharacterHandler.AddItemToBag(true, itemHDAdd, "Đổi điểm sự kiện tt 10000 điểm");
                                break;
                            }
                            case 1:
                            {
                                var listHD = new List<short>() {652,653,659,660,656}; // item ngẫu nhiên
                                var itemHDRand = listHD[ServerUtils.RandomNumber(listHD.Count)];
                                var itemHDAdd = ItemCache.GetItemDefault(itemHDRand);
                                itemHDAdd.Options.Where(option => DataCache.IdOptionGoc.Contains(option.Id)).ToList().ForEach(
                                    option => {
                                        option.Param += option.Param*chiso/100;
                                    });
                                character.CharacterHandler.AddItemToBag(true, itemHDAdd, "Đổi điểm sự kiện tt 10000 điểm");
                                break;
                            }
                            case 2:
                            {
                                var listHD = new List<short>() {654,655,661,662,656}; // item ngẫu nhiên
                                var itemHDRand = listHD[ServerUtils.RandomNumber(listHD.Count)];
                                var itemHDAdd = ItemCache.GetItemDefault(itemHDRand);
                                itemHDAdd.Options.Where(option => DataCache.IdOptionGoc.Contains(option.Id)).ToList().ForEach(
                                    option => {
                                        option.Param += option.Param*chiso/100;
                                    });
                                character.CharacterHandler.AddItemToBag(true, itemHDAdd, "Đổi điểm sự kiện tt 10000 điểm");
                                break;
                            }
                        }
                    }
                    if (mocDiem >= 3)
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextThanMeo[2], MenuNpc.Gi().MenuThanMeo[2], character.InfoChar.Gender));
                        character.TypeMenu = 2;
                    }
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                    character.DiemSuKien = -10000;
                    break;
                }
                case 2://tự chọn lồng đèn
                {
                    switch (select)
                    {
                        case 0:
                        {
                            var ldKeoQuan = ItemCache.GetItemDefault((short)469);
                            ldKeoQuan.Quantity = 1;
                            character.CharacterHandler.AddItemToBag(true, ldKeoQuan, "Đổi điểm sự kiện tt tren 1k");
                            break;
                        }
                        case 1:
                        {
                            var ldOngSao = ItemCache.GetItemDefault((short)467);
                            ldOngSao.Quantity = 1;
                            character.CharacterHandler.AddItemToBag(true, ldOngSao, "Đổi điểm sự kiện tt tren 1k");
                            break;
                        }
                        case 2:
                        {
                            var ldCaChep = ItemCache.GetItemDefault((short)468);
                            ldCaChep.Quantity = 1;
                            character.CharacterHandler.AddItemToBag(true, ldCaChep, "Đổi điểm sự kiện tt tren 1k");
                            break;
                        }
                        case 3:
                        {
                            var ldConGa = ItemCache.GetItemDefault((short)802);
                            ldConGa.Quantity = 1;
                            character.CharacterHandler.AddItemToBag(true, ldConGa, "Đổi điểm sự kiện tt tren 1k");
                            break;
                        }
                        case 4:
                        {
                            var ldHoiAn = ItemCache.GetItemDefault((short)471);
                            ldHoiAn.Quantity = 1;
                            character.CharacterHandler.AddItemToBag(true, ldHoiAn, "Đổi điểm sự kiện tt tren 1k");
                            break;
                        }
                        default:
                        {
                            var ldKeoQuan = ItemCache.GetItemDefault((short)469);
                            ldKeoQuan.Quantity = 1;
                            character.CharacterHandler.AddItemToBag(true, ldKeoQuan, "Đổi điểm sự kiện tt tren 1k");
                            break;
                        }
                    }
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                    break;
                }
            }
        }*/
		private static void ConfirmPanchy(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                //Menu ban đầu
                case 0: //Đổi điểm sự kiện
                {
                    switch (select)
                    {
                        case 0:
                        {
                            var panchy = MenuNpc.Gi().TextPanchy[1];
                            panchy += $"\b{ServerUtils.Color("green")}Điểm sự kiện của bạn là: " + character.DiemSuKien;
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, panchy, MenuNpc.Gi().MenuPanchy[1], character.InfoChar.Gender));
                            character.TypeMenu = 1;
                            break;
                        }
                        case 1:
                        {
                            // chọn đổi điểm tích nạp
                            break;
                        }
                    }
                    break;
                }
                case 1:
                {
                    if (select != 0) return;
                    //chấp nhận đổi điểm sự kiện
                    var mocDiem = 0;
                    var DiemSuKien = character.DiemSuKien;
                    var bagNull = character.LengthBagNull();
                    // - 2500 điểm : x1 hộp quà 8/3
                    
                    if (DiemSuKien < 2500)
                    {
                        character.CharacterHandler.SendMessage(
                            Service.DialogMessage("Bạn không đủ điểm để đổi"));
                        return;
                    }

                    if (DiemSuKien >= 2500)
                    {
                        if  (bagNull < 2)
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_BAG));
                            return;
                        }
                        var thoivang = ItemCache.GetItemDefault((short)398);
                        thoivang.Quantity = 1;
                        character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi điểm sự kiện 2500 điểm");

                        
                        character.CharacterHandler.SendMessage(Service.DialogMessage("Bạn đã đổi điểm sự kiện thành công 1 hộp quà 8/3"));
                        mocDiem = 1;
                    }
                    
                    
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                    character.DiemSuKien = character.DiemSuKien - 2500;
                    break;
                }
                
            }
        }

        private static void ConfirmThuongDe(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                //Menu ban đầu
                case 0:
                {
                    switch (select)
                    {
                        //Quay ngọc may mắn
                        case 0:
                        {
                            var menu = MenuNpc.Gi().MenuThuongDe[2].ToList();
                            if (character.LuckyBox.Count > 0)
                            {
                                menu.Insert(2, $"Rương phụ \n{character.LuckyBox.Count}\nmón"); 
                                menu.Insert(3, $"Xóa tất cả\nRương phụ"); 
                            }
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextThuongDe[2], menu, character.InfoChar.Gender));
                            character.TypeMenu = 1;
                            break;
                        }
                        case 1://Đến Kaio
                        {
                            var karin = new Karin();
                            karin.GetMapById(48)
                                .JoinZone(character, 0, true, true, character.InfoChar.Teleport);
                            break;
                        }
                    }
                    break;
                }
                //Quay ngọc may mắn
                case 1:
                {
                    switch (select)
                    {
                        case 0:
                        {
                            if (character.LuckyBox.Count >= DataCache.LIMIT_SLOT_RUONG_PHU_THUONG_DE)
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().FULL_LUCKY_BOX));
                                break;
                            }
                            character.CharacterHandler.SendMessage(Service.LuckRoll0());
                            character.ShopId = 0;
                            break;
                        }
                        case 1:
                        {
                            // character.CharacterHandler.SendMessage(Service.LuckRoll0());
                            // character.ShopId = 1;
                            break;
                        }
                        case 2:
                        {
                            var luckRoll = character.LuckyBox;
                            if (character.LuckyBox.Count > 0)
                            {
                                character.CharacterHandler.SendMessage(Service.SubBox(luckRoll));
                                character.ShopId = 1111;
                            } 
                            break;
                        }
                        case 3:
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextThuongDe[3], MenuNpc.Gi().MenuThuongDe[3], character.InfoChar.Gender));
                            character.TypeMenu = 2;
                            break;
                        }
                    }

                    break;
                }
                case 2:
                {
                    if(select != 0) return;
                    character.LuckyBox.Clear();
                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().DELETED_ALL_LUCKY_BOX));
                    break;
                }
            }
        }
        
        private static void ConfirmThanVuTru(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                //Menu ban đầu
                case 0:
                {
                    if (select != 0) return;
                    var karin = new Karin();
                    karin.GetMapById(45)
                        .JoinZone(character, 0, true, true, character.InfoChar.Teleport);
                    break;
                }
            }
        }
        private static void ConfirmBaHatMit(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                //Menu vách núi
                case 0:
                {
                    if (!character.InfoChar.IsNhanBua) select += 1;
                    switch (select)
                    {
                        //Nhận bùa miễn phí
                        case 0:
                        {
                            var idAmulet = (short)DataCache.IdAmulet[ServerUtils.RandomNumber(DataCache.IdAmulet.Count)];
                            var timePlus = DataCache._1HOUR;
                            if (character.InfoChar.ItemAmulet.ContainsKey(idAmulet))
                            {
                                character.InfoChar.ItemAmulet[idAmulet] += timePlus;
                            }
                            else
                            {
                                character.InfoChar.ItemAmulet.TryAdd(idAmulet, timePlus + ServerUtils.CurrentTimeMillis());
                            }
                            character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().ADD_AMULET, ItemCache.ItemTemplate(idAmulet).Name)));
                            character.InfoChar.IsNhanBua = false;
                            // Setup Bùa
                            break;
                        }
                        //Cửa hàng bùa
                        case 1:
                        {
                            character.CharacterHandler.SendMessage(
                                Service
                                    .OpenUiConfirm(npcId, MenuNpc.Gi().TextBaHatMit[0], MenuNpc.Gi().MenuBaHatMit[2], character.InfoChar.Gender));
                            character.TypeMenu = 2;
                            break;
                        }
                        //Nâng cấp vật phẩm
                        case 2:
                        {
                            character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[4]));
                            character.ShopId = 0;
                            break;
                        }
                            //Làm phép nhập đá
                            case 3://nâng cấp linh thú
                                {
                                    character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[17]));
                                    character.ShopId = 12;
                                    break;
                                }
                            //Nhập ngọc rồng
                            case 4:
                        {
                            character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[6]));
                            character.ShopId = 2;
                            break;
                        }
                        //Nâng cấp bông tai porata
                        case 5:
                        {
                            var bongTaiPorata2 = character.CharacterHandler.GetItemBagById(921);
                            if (bongTaiPorata2 == null)
                            {
                                character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[13]));
                                character.ShopId = 7;
                            }
                            else 
                            {
                                character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[14]));
                                character.ShopId = 8;
                            }
                            break;
                        }
                    }
                    break;
                }
                //Đảo kame
                case 1:
                {
                    switch (select)
                    {
                        //Ép sao trang bị
                        case 0:
                        {
                            character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[11]));
                            character.ShopId = 3;
                            break;
                        }
                        //MENU - Pha lê hoá trang bị
                        case 1:
                        {
                            character.CharacterHandler.SendMessage(
                                Service
                                    .OpenUiConfirm(npcId, MenuNpc.Gi().TextBaHatMit[2], MenuNpc.Gi().MenuBaHatMit[9], character.InfoChar.Gender));
                            character.TypeMenu = 3;
                            break;
                        }
                            //MENU - Chuyển hoá trang bị
                            case 2://nở trứng linh thú
                                {
                                    character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[16]));
                                    character.ShopId = 9;
                                    break;
                                }
                        }
                    break;
                }
                //Cửa hàng bùa
                case 2:
                {
                    if (@select is < 0 or > 2) select = 0;
                    var idShop = select;
                    character.CharacterHandler.SendMessage(Service.Shop(character, 0, idShop));
                    character.ShopId = idShop;
                    character.TypeMenu = 0;
                    break;
                }
                //Menu Pha lê hoá
                case 3:
                {
                    if(select != 0) return;
                    character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[8]));
                    character.ShopId = 4;
                    break;
                }
                //MENU - Chuyển hoá trang bị
                case 4:
                    {
                        {
                            //menu linh thú
                            switch (select)
                            {
                                case 0://nở trứng linh thú
                                    {
                                        character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[16]));
                                        character.ShopId = 9;
                                        break;
                                    }
                                case 1://nâng cấp linh thú
                                    {
                                        character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[17]));
                                        character.ShopId = 10;
                                        break;
                                    }
                                case 2://nâng cấp linh thú
                                    {
                                        character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[18]));
                                        character.ShopId = 11;
                                        break;
                                    }
                                case 3://nâng cấp linh thú
                                    {
                                        character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[19]));
                                        character.ShopId = 12;
                                        break;
                                    }
                            }
                            break;
                        }
                    }
                //Nâng cấp trang bị
                case 5:
                {
                    var listArray = character.CombinneIndex;
                    var dungDaBaoVe = listArray[5];
                    var daBaoVeItemIndex = listArray[6];
                    var daBaoVe = false;
                    if (select == 1 && dungDaBaoVe == 1 && daBaoVeItemIndex != -1)
                    {
                        daBaoVe = true;
                        Console.WriteLine("Co su dung da bao ve");
                    }
                    else if (select != 0)
                    {
                        return;
                    }
                   
                    var trangBi = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    if (trangBi == null) return;
                    var da = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var soDaCanNangCap = listArray[2];
                    var gold = listArray[3];
                    var percentSuccess = listArray[4];
                    if (character.InfoChar.Gold < gold)
                    {
                        character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_GOLD));
                        return;
                    }
                    if (da.Quantity < soDaCanNangCap)
                    {
                        character.CharacterHandler.SendMessage(
                            Service.DialogMessage(TextServer.gI().NEED_ENOUGH_STONE));
                        return;
                    }

                    var optionCheck = trangBi.Options.FirstOrDefault(option => option.Id == 72);
                    if (percentSuccess/DataCache.DIV_FAKE_PERCENT_UPGRADE >= 1)
                    {
                        percentSuccess /= DataCache.DIV_FAKE_PERCENT_UPGRADE;
                    }
                    var percentRandom = ServerUtils.RandomNumber(100) < percentSuccess;
                    if (percentRandom)
                    {
                        if (optionCheck == null)
                        {
                            trangBi.Options.Add(new OptionItem()
                            {
                                Id = 72,
                                Param = 1
                            });
                        }
                        else
                        {
                            optionCheck.Param += 1;
                        }
                        trangBi.Options.Where(option => DataCache.IdOptionGoc.Contains(option.Id)).ToList().ForEach(
                            option => {
                                option.Param += option.Param/10;
                            });
                            
                        character.CharacterHandler.SendMessage(Service.SendCombinne2());
                    }
                    else
                    {
                        if (optionCheck != null)
                        {
                            // – cấp 0 lên cấp 1 xịt hay lên ko ảnh hưởng gì hết. Xác suất 80%
                            // – cấp 1 lên cấp 2 xịt hay lên ko ảnh hưởng. Xác suất 50%
                            // – cấp 2 lên cấp 3 xịt bị rớt xuống cấp 1 và giảm 1% chỉ số. Xác suất 20%
                            // – cấp 3 lên 4 xịt k giảm cấp và chỉ số. Xác suất 10%
                            // – cấp 4 lên 5 xịt rớt xuống 3 giảm 1% chỉ số. Xác suất 5%
                            // – cấp 5 lên 6 xịt ko sao. Xác suất 2%
                            // – cấp 6 lên 7 xịt xuống 5 và giảm 1% chỉ số. Xác suất 1%

                            if (optionCheck.Param > 0 && optionCheck.Param % 2 == 0 && !daBaoVe)
                            {
                                optionCheck.Param -= 1;
                                trangBi.Options.Where(option => DataCache.IdOptionGoc.Contains(option.Id)).ToList().ForEach(
                                    option =>
                                    {
                                        option.Param -= option.Param/10;
                                    });
                            }
                            
                        }
                        character.CharacterHandler.SendMessage(Service.SendCombinne3());
                    }
                    character.MineGold(gold);
                    if (daBaoVe)
                    {
                        character.CharacterHandler.RemoveItemBagByIndex(daBaoVeItemIndex, 1, false, reason:"Dùng đá bảo vệ");
                        Console.WriteLine("Xoa da bao ve");
                    }

                    character.CharacterHandler.RemoveItemBagByIndex(da.IndexUI, soDaCanNangCap, reason:"Dùng đá nâng cấp");
                    character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));

                    var checkDa = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var listIndexUi = new List<int>();
                    if (checkDa != null && checkDa.Id == da.Id)
                    {
                        listIndexUi.Add(trangBi.IndexUI);
                        listIndexUi.Add(da.IndexUI);
                    }
                    else
                    {
                        listIndexUi.Add(trangBi.IndexUI);
                    }
                    character.CharacterHandler.SendMessage(Service.SendCombinne1(listIndexUi));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    
                    break;
                }
                //Nhập đá
                case 6:
                {
                    if(select != 0) return;
                    var bagNull = character.LengthBagNull();
                    var listArray = character.CombinneIndex;
                    var item1 = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var item2 = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var idNew = (short) (220 + ServerUtils.RandomNumber(5));
                    var itemNew = ItemCache.GetItemDefault(idNew);

                    var itemBagNotMax = character.CharacterHandler.ItemBagNotMaxQuantity(itemNew.Id);
                    if (itemBagNotMax == null && bagNull < 1)
                    {
                        character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_BAG));
                        return;
                    }
                    switch (item1.Id)
                    {
                        case 225:
                        {
                            character.CharacterHandler.RemoveItemBagByIndex(item1.IndexUI, 10, false, reason:"Nhập đá");
                            character.CharacterHandler.RemoveItemBagByIndex(item2.IndexUI, 1, false, reason:"Nhập đá");
                            break;
                        }
                        default:
                        {
                            character.CharacterHandler.RemoveItemBagByIndex(item1.IndexUI, 1, false, reason:"Nhập đá");
                            character.CharacterHandler.RemoveItemBagByIndex(item2.IndexUI, 10, false, reason:"Nhập đá");
                            break;
                        }
                    }
                    character.MineGold(2000);
                    character.CharacterHandler.AddItemToBag(true, itemNew, "Nhập đá");
                    character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));

                    var listIndexUi = new List<int>();
                    var itemReturn = character.CharacterHandler.GetItemBagByIndex(item1.IndexUI);
                    if (itemReturn != null && itemReturn.Id == item1.Id)
                    {
                        listIndexUi.Add(item1.IndexUI);
                    }
                    itemReturn = character.CharacterHandler.GetItemBagByIndex(item2.IndexUI);
                    if (itemReturn != null && itemReturn.Id == item2.Id)
                    {
                        listIndexUi.Add(item2.IndexUI);
                    }
                    
                    character.CharacterHandler.SendMessage(Service.SendCombinne1(listIndexUi));
                    character.CharacterHandler.SendMessage(Service.SendCombinne4(ItemCache.ItemTemplate(itemNew.Id).IconId));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
                }
                //Nhập ngọc rông
                case 7:
                {
                    if(select != 0) return;
                    var bagNull = character.LengthBagNull();
                    var listArray = character.CombinneIndex;
                    if (listArray == null) return;
                    var ngocRong = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var idNew = (short) (ngocRong.Id - 1);
                    var itemNew = ItemCache.GetItemDefault(idNew);

                    var itemBagNotMax = character.CharacterHandler.ItemBagNotMaxQuantity(itemNew.Id);
                    if (itemBagNotMax == null && bagNull < 1)
                    {
                        character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_BAG));
                        return;
                    }
                    character.MineGold(2000);
                    character.CharacterHandler.RemoveItemBagByIndex(ngocRong.IndexUI, 7, reason:"Nhập ngọc");
                    character.CharacterHandler.AddItemToBag(true, itemNew, "Nhập ngọc");
                    character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));

                    character.CharacterHandler.SendMessage(Service.SendCombinne5(ItemCache.ItemTemplate(itemNew.Id).IconId));

                    var listIndexUi = new List<int>();
                    var itemReturn = character.CharacterHandler.GetItemBagByIndex(ngocRong.IndexUI);
                    if (itemReturn != null && itemReturn.Id == ngocRong.Id)
                    {
                        listIndexUi.Add(ngocRong.IndexUI);
                    }

                    character.CharacterHandler.SendMessage(Service.SendCombinne1(listIndexUi));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
                } 
                //Ép sao trang bị
                case 8:
                {
                    if(select != 0) return;
                    if (10 > character.AllDiamond())
                    {
                        character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_DIAMOND));
                        return;
                    }
                    var bagNull = character.LengthBagNull();
                    var listArray = character.CombinneIndex;
                    if (listArray == null) return;
                    var trangBi = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var ngocRong = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var optionId = listArray[2];
                    var optionParam = listArray[3];
                    if(trangBi == null || ngocRong == null) return;

                    var optionCheck = trangBi.Options.FirstOrDefault(opt => opt.Id == 102);
                    var optionUp = trangBi.Options.FirstOrDefault(opt => opt.Id == optionId);
                    if (optionCheck == null)
                    {
                        trangBi.Options.Add(new OptionItem()
                        {
                            Id = 102,
                            Param = 1
                        });
                    }
                    else
                    {
                        optionCheck.Param++;
                    }

                    if (optionUp == null)
                    {
                        trangBi.Options.Add(new OptionItem()
                        {
                            Id = optionId,
                            Param = optionParam
                        });
                    }
                    else
                    {
                        optionUp.Param += optionParam;
                    }
                    character.MineDiamond(10);
                    character.CharacterHandler.SendMessage(Service.SendCombinne2());
                    character.CharacterHandler.RemoveItemBagByIndex(ngocRong.IndexUI, 1, reason:"Ép ngọc rồng");
                    character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                    var itemReturn = character.ItemBag.FirstOrDefault(item =>
                        item.Id == trangBi.Id && item.Options.Count == trangBi.Options.Count && item.IndexUI != trangBi.IndexUI) ?? trangBi;
                    character.CharacterHandler.SendMessage(Service.SendCombinne1(new List<int>(){itemReturn.IndexUI}));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
                }
                //Pha lê hoá trang bị
                case 9:
                {
                    if(select != 0) return;
                    var listArray = character.CombinneIndex;
                    if (listArray == null) return;
                    var itemBag = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var lvOption = listArray[1];
                    if(itemBag == null) return;
                    var percentPhaLe = DataCache.PercentPhaLe[lvOption];
                    var goldPhaLe = percentPhaLe[0] * 1000000;
                    var diamondPhaLe = percentPhaLe[2];
                    if (character.InfoChar.Gold < goldPhaLe)
                    {
                        character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_GOLD));
                        return;
                    }
                    if (character.AllDiamond() < diamondPhaLe)
                    {
                        character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_DIAMOND));
                        return;
                    }

                    var percentSuccess = ServerUtils.RandomNumber(1, 100) <= (percentPhaLe[1]/DataCache.DIV_FAKE_PERCENT_PL);
                    if (percentSuccess)
                    {
                        var optionPlus = itemBag.Options.FirstOrDefault(option => option.Id == 107);
                        if (optionPlus != null)
                        {
                            optionPlus.Param++;
                        }
                        else
                        {
                            itemBag.Options.Add(new OptionItem()
                            {
                                Id = 107,
                                Param = 1
                            });
                        }
                        character.CharacterHandler.SendMessage(Service.SendCombinne2());
                    }
                    else
                    {
                        character.CharacterHandler.SendMessage(Service.SendCombinne3());
                    }
                    character.MineGold(goldPhaLe);
                    character.MineDiamond(diamondPhaLe);
                    character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                    character.CharacterHandler.SendMessage(Service.SendCombinne1(new List<int>(){itemBag.IndexUI}));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
                }
                //Chuyển hoá trang bị VÀNG / 10
                //Chuyển hoá trang bị NGỌC / 11
                case 10:
                case 11:
                {
                    if(select != 0) return;
                    var listArray = character.CombinneIndex;
                    var itemLuongLong = character.CharacterHandler.GetItemBagByIndex(listArray[0]); //old
                    var itemThan = character.CharacterHandler.GetItemBagByIndex(listArray[1]); //new đồ thần
                    var levelUp = listArray[2];
                    var checkMoney = listArray[3];
                    if(itemLuongLong == null || itemThan == null) return;
                    switch (character.TypeMenu)
                    {
                        case 10:
                        {
                            if (character.InfoChar.Gold < checkMoney)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.DialogMessage(TextServer.gI().NOT_ENOUGH_GOLD));
                                return;
                            }
                            else
                            {
                                character.MineGold(checkMoney);
                            }
                            break;
                        }
                        case 11:
                        {
                            if (character.AllDiamond() < checkMoney)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.DialogMessage(TextServer.gI().NOT_ENOUGH_DIAMOND));
                                return;
                            }
                            else
                            {
                                character.MineDiamond(checkMoney);
                            }
                            break;
                        }
                    }

                    var checkLevel = itemLuongLong.Options.FirstOrDefault(opt => opt.Id == 72)?.Param;
                    
                    var listOptionLlGoc = itemLuongLong.Options.Where(opt => DataCache.IdOptionGoc.Contains(opt.Id)).ToList();
                    itemThan.Options.ForEach(opt =>
                    {
                        var paramNew = 0;
                        var optCheck = listOptionLlGoc.FirstOrDefault(o => o.Id == opt.Id);
                        if (optCheck == null) return;
                        if (checkLevel == levelUp)
                        {
                            paramNew += optCheck.Param;
                        }
                        else
                        {
                            paramNew += optCheck.Param - optCheck.Param / 10;
                        }
                        opt.Param += paramNew;
                    });
                    var listCheckPlus = itemLuongLong.Options.Where(opt => itemThan.Options.FirstOrDefault(o => o.Id == opt.Id) == null).ToList();
                    itemThan.Options.AddRange(listCheckPlus);

                    character.CharacterHandler.RemoveItemBag(itemLuongLong.IndexUI, reason:"Chuyển hóa");
                    character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                    character.CharacterHandler.SendMessage(Service.SendCombinne4(ItemCache.ItemTemplate(itemThan.Id).IconId));
                    
                    var itemReturn = character.ItemBag.FirstOrDefault(item =>
                        item.Id == itemThan.Id && item.Options.Count == itemThan.Options.Count &&
                        item.IndexUI != itemThan.IndexUI) ?? itemThan;
                    character.CharacterHandler.SendMessage(Service.SendCombinne1(new List<int>(){itemReturn.IndexUI}));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
                }
                //Nâng cấp porata
                case 12:
                {
                    if(select != 0) return;
                    
                    var listArray = character.CombinneIndex;
                    var bongTaiPorata = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var manhVoBongTai = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var soNgocCanNangCap = listArray[2];
                    var soVangCanNangCap = listArray[3];
                    var percentSuccess = listArray[4];
                    var isThanhCong = false;

                    if (character.InfoChar.Gold < soVangCanNangCap)
                    {
                        character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_GOLD));
                        return;
                    }
                    if (character.AllDiamond() < soNgocCanNangCap)
                    {
                        character.CharacterHandler.SendMessage(Service.DialogMessage(TextServer.gI().NOT_ENOUGH_DIAMOND));
                        return;
                    }

                    var optionCheck = manhVoBongTai.Options.FirstOrDefault(option => option.Id == 31);
                    var percentRandom = ServerUtils.RandomNumber(100) < percentSuccess;
                    if (percentRandom)
                    {
                        // Thành công thì xóa số lượng 9999 item, xóa item bông tai và thêm item bông tai 2
                        if (optionCheck != null)
                        {
                            optionCheck.Param -= 9999;
                            if (optionCheck.Param <= 0)
                            {
                                character.CharacterHandler.RemoveItemBagByIndex(manhVoBongTai.IndexUI, 1, false, reason:"NC Porata");
                            }
                        }
                        character.CharacterHandler.RemoveItemBagByIndex(bongTaiPorata.IndexUI, 1, false, reason:"NC Porata");
                        var itemAdd = ItemCache.GetItemDefault(921);
                        itemAdd.Quantity = 1;
                        character.CharacterHandler.AddItemToBag(false, itemAdd, "Nâng cấp porata");
                        character.CharacterHandler.SendMessage(Service.SendCombinne2());
                        isThanhCong = true;
                    }
                    else
                    {
                        if (optionCheck != null)
                        {
                            optionCheck.Param -= 99;
                        }
                        character.CharacterHandler.SendMessage(Service.SendCombinne3());
                    }

                    character.MineGold(soVangCanNangCap);
                    character.MineDiamond(soNgocCanNangCap);
                    character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));

                    var checkManhVoBongTai = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var listIndexUi = new List<int>();
                    if (!isThanhCong)
                    {
                        if (checkManhVoBongTai != null && checkManhVoBongTai.Id == manhVoBongTai.Id)
                        {
                            listIndexUi.Add(bongTaiPorata.IndexUI);
                            listIndexUi.Add(manhVoBongTai.IndexUI);
                        }
                        else
                        {
                            listIndexUi.Add(bongTaiPorata.IndexUI);
                        }
                    }
                    character.CharacterHandler.SendMessage(Service.SendCombinne1(listIndexUi));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
                }
                // Mở option porata
                case 13:
                {
                    if(select != 0) return;
                    
                    var listArray = character.CombinneIndex;
                    var bongTaiPorata2 = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var manhHonBongTai = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var daXanhLam = character.CharacterHandler.GetItemBagByIndex(listArray[2]);
                    var soNgocCanNangCap = listArray[3];
                    var soVangCanNangCap = listArray[4];
                    var percentSuccess = listArray[5];

                    if (character.InfoChar.Gold < soVangCanNangCap)
                    {
                        character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_GOLD));
                        return;
                    }
                    if (character.AllDiamond() < soNgocCanNangCap)
                    {
                        character.CharacterHandler.SendMessage(Service.DialogMessage(TextServer.gI().NOT_ENOUGH_DIAMOND));
                        return;
                    }
                    // remove item đá xanh lam, và 99 cái mảnh hồn
                    character.CharacterHandler.RemoveItemBagByIndex(manhHonBongTai.IndexUI, 99, false, reason:"CS Porata");
                    character.CharacterHandler.RemoveItemBagByIndex(daXanhLam.IndexUI, 1, false, reason:"CS Porata");
                    // Remove tiền và ngọc
                    character.MineGold(soVangCanNangCap);
                    character.MineDiamond(soNgocCanNangCap);

                    var optionCheck = bongTaiPorata2.Options.FirstOrDefault(option => option.Id != 72);

                    var percentRandom = ServerUtils.RandomNumber(100) < percentSuccess;
                    if (percentRandom)
                    {
                        var optionRandom = DataCache.OptionPorata2[ServerUtils.RandomNumber(DataCache.OptionPorata2.Count)]; 
                        // Thành công thì lấy random option trong list
                        if (optionCheck != null)
                        {
                            optionCheck.Id = optionRandom[0];
                            optionCheck.Param = ServerUtils.RandomNumber(optionRandom[1], optionRandom[2]);
                        }
                        else 
                        {
                            bongTaiPorata2.Options.Add(new OptionItem()
                            {
                                Id = optionRandom[0],
                                Param = ServerUtils.RandomNumber(optionRandom[1], optionRandom[2])
                            });
                        }
                        character.CharacterHandler.SendMessage(Service.SendCombinne2());
                    }
                    else
                    {
                        character.CharacterHandler.SendMessage(Service.SendCombinne3());
                    }

                    character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));

                    var checkBongTaiPorata2 = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var listIndexUi = new List<int>();
                    if (checkBongTaiPorata2 != null && checkBongTaiPorata2.Id == bongTaiPorata2.Id)
                    {
                        listIndexUi.Add(bongTaiPorata2.IndexUI);
                    }

                    character.CharacterHandler.SendMessage(Service.SendCombinne1(listIndexUi));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
                }
                case 14:
                {
                    //menu linh thú
                    switch (select)
                    {
                        case 0://nở trứng linh thú
                        {
                            character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[16]));
                            character.ShopId = 9;
                            break;
                        }
                        case 1://nâng cấp linh thú
                        {
                            character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[17]));
                            character.ShopId = 10;
                            break;
                        }
                        case 2://nâng cấp linh thú
                        {
                            character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[18]));
                            character.ShopId = 11;
                            break;
                        }
                        case 3://nâng cấp linh thú
                        {
                            character.CharacterHandler.SendMessage(Service.SendCombinne0(MenuNpc.Gi().MenuBaHatMit[19]));
                            character.ShopId = 12;
                            break;
                        }
                    }
                    break;
                }
                case 15://nở trứng
                {
                    var listArray = character.CombinneIndex;

                    var trungLinhThu = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var honLinhThu = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    short trungLinhThuIcon = ItemCache.ItemTemplate(trungLinhThu.Id).IconId;

                    character.CharacterHandler.RemoveItemBagByIndex(trungLinhThu.IndexUI, 1, false, reason:"Nở trứng");
                    character.CharacterHandler.RemoveItemBagByIndex(honLinhThu.IndexUI, 99, false, reason:"Nở trứng");

                    if (listArray.Count == 3)
                    {
                        var thoiVang = character.CharacterHandler.GetItemBagByIndex(listArray[2]);
                        character.CharacterHandler.RemoveItemBagByIndex(thoiVang.IndexUI, 5, false, reason:"Nở trứng nhanh");
                    }

                    var linhThuNgauNhien = DataCache.ListPetD[ServerUtils.RandomNumber(DataCache.ListPetD.Count)];
                    var itemLinhThu = ItemCache.GetItemDefault(linhThuNgauNhien);
                    
                    var maSoLinhThu = ServerUtils.RandomNumber(100,100000);
                    var optionHiden = itemLinhThu.Options.FirstOrDefault(option => option.Id == 73);
                            
                    if (optionHiden != null) 
                    {
                        optionHiden.Param = maSoLinhThu;
                    }
                    else 
                    {
                        itemLinhThu.Options.Add(new OptionItem()
                        {
                            Id = 73,
                            Param = maSoLinhThu,
                        });
                    }
                    
                    character.CharacterHandler.SendMessage(Service.NpcChat(npcId, TextServer.gI().RANDOM_LINH_THU));
                    character.CharacterHandler.SendMessage(Service.SendCombinne6(trungLinhThuIcon, ItemCache.ItemTemplate(itemLinhThu.Id).IconId));

                    character.CharacterHandler.AddItemToBag(false, itemLinhThu, "Nở trứng");
                    character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));

                    character.CharacterHandler.SendMessage(Service.SendCombinne1(new List<int>()));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
                }
            }
        }
        
        private static void ConfirmGhiDanh(Character character, short npcId, int select)
        {
            throw new NotImplementedException();
        }

        private static void ConfirmRongThan(Character character, short npcId, int select)
        {
            // character.CharacterHandler.SendMessage(Service.ServerMessage("select: " + select));
            if (!character.InfoMore.VuaGoiRong) {
                UserDB.BanUser(character.Player.Id);
                ClientManager.Gi().KickSession(character.Player.Session);
                ServerUtils.WriteLog("hackrong", $"Tên tài khoản {character.Player.Username} (ID:{character.Player.Id}) hack rong");

                var temp = ClientManager.Gi().GetPlayer(character.Player.Id);
                if (temp != null)
                {
                    ClientManager.Gi().KickSession(temp.Session);
                }
                return;
            }
            character.InfoMore.VuaGoiRong = false;
            switch (select)
            {
                case 0: //2 ty vang
                {
                    character.PlusGold(2000000000);
                    character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                    break;
                }
                case 1://+1 gang tay tren nguoi
                {
                    var trangBi = character.ItemBody[2];

                    if (trangBi == null) 
                    {
                        character.CharacterHandler.SendMessage(Service.ServerMessage("Trên người của bạn không có găng tay"));
                        break;
                    }

                    var optionCheck = trangBi.Options.FirstOrDefault(option => option.Id == 72);
                    if (optionCheck == null)
                    {
                        trangBi.Options.Add(new OptionItem()
                        {
                            Id = 72,
                            Param = 1
                        });
                        trangBi.Options.Where(option => DataCache.IdOptionGoc.Contains(option.Id)).ToList().ForEach(
                                        option => option.Param += option.Param/10);
                        character.CharacterHandler.SendMessage(Service.SendBody(character));
                    }
                    else
                    {
                        if (optionCheck.Param < DataCache.MAX_LIMIT_UPGRADE - 1)
                        {
                            optionCheck.Param += 1;
                            trangBi.Options.Where(option => DataCache.IdOptionGoc.Contains(option.Id)).ToList().ForEach(
                                        option => option.Param += option.Param/10);
                            character.CharacterHandler.SendMessage(Service.SendBody(character));
                        }
                    }
                    break;
                }
                case 2://Doi ky nang de tu
                {
                    var disciple = character.Disciple;
                    var disciplePower = disciple.InfoChar.Power;
                    if (disciplePower >= 150000000 && disciple.Skills.Count >= 2)
                    {
                        var randomSkill = DataCache.IdSkillDisciple2[ServerUtils.RandomNumber(DataCache.IdSkillDisciple2.Count)];
                        disciple.Skills[1] = new SkillCharacter()
                        {
                            Id = randomSkill,
                            SkillId = Disciple.GetSkillId(randomSkill),
                            Point = 1,
                        };
                    }

                    if (disciplePower >= 1500000000 && disciple.Skills.Count >= 3)
                    {
                        var randomSkill = DataCache.IdSkillDisciple3[ServerUtils.RandomNumber(DataCache.IdSkillDisciple3.Count)];
                        disciple.Skills[2] = new SkillCharacter()
                        {
                            Id = randomSkill,
                            SkillId = Disciple.GetSkillId(randomSkill),
                            Point = 1,
                        };
                    }
                    break;
                }
                case 3://dep trai nhat vu tru
                {
                    var itemId = (character.InfoChar.Gender + 227);
                    var itemAdd = ItemCache.GetItemDefault((short)itemId);
                    itemAdd.Quantity = 1;
                    character.CharacterHandler.AddItemToBag(true, itemAdd, "Ước NR");
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                    break;
                }
            }
            // character.Zone.ZoneHandler.SendMessage(Service.CallDragon(1, 0, character));
            character.CharacterHandler.SendMessage(Service.CallDragon(1, 0, character));
            MapManager.SetDragonAppeared(false);
        }
		
		private static void ConfirmRongXuong(Character character, short npcId, int select)
        {
            // character.CharacterHandler.SendMessage(Service.ServerMessage("select: " + select));
            if (!character.InfoMore.VuaGoiRong) {
                UserDB.BanUser(character.Player.Id);
                ClientManager.Gi().KickSession(character.Player.Session);
                ServerUtils.WriteLog("hackrong", $"Tên tài khoản {character.Player.Username} (ID:{character.Player.Id}) hack rong");

                var temp = ClientManager.Gi().GetPlayer(character.Player.Id);
                if (temp != null)
                {
                    ClientManager.Gi().KickSession(temp.Session);
                }
                return;
            }
            character.InfoMore.VuaGoiRong = false;
            switch (select)
            {
                case 0: //2 ty vang
                {
                    character.PlusGold(2000000000);
                    character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                    break;
                }
                case 1://+1 gang tay tren nguoi
                {
                    var disciple = character.Disciple;
                    var trangBi = disciple.ItemBody[2];

                    if (trangBi == null) 
                    {
                        character.CharacterHandler.SendMessage(Service.ServerMessage("Trên người của đệ không có găng tay"));
                        break;
                    }

                    var optionCheck = trangBi.Options.FirstOrDefault(option => option.Id == 72);
                    if (optionCheck == null)
                    {
                        trangBi.Options.Add(new OptionItem()
                        {
                            Id = 72,
                            Param = 1
                        });
                        trangBi.Options.Where(option => DataCache.IdOptionGoc.Contains(option.Id)).ToList().ForEach(
                                        option => option.Param += option.Param/10);
                        disciple.CharacterHandler.SendMessage(Service.SendBody(disciple));
                    }
                    else
                    {
                        if (optionCheck.Param < DataCache.MAX_LIMIT_UPGRADE - 1)
                        {
                            optionCheck.Param += 1;
                            trangBi.Options.Where(option => DataCache.IdOptionGoc.Contains(option.Id)).ToList().ForEach(
                                        option => option.Param += option.Param/10);
                            disciple.CharacterHandler.SendMessage(Service.SendBody(disciple));
                        }
                    }
                    break;
                }
                case 2://Doi ky nang de tu
                {
                    var disciple = character.Disciple;
                    var disciplePower = disciple.InfoChar.Power;
                    //if (disciplePower >= 150000000 && disciple.Skills.Count >= 2)
                    //{
                    //    var randomSkill = DataCache.IdSkillDisciple2[ServerUtils.RandomNumber(DataCache.IdSkillDisciple2.Count)];
                    //    disciple.Skills[1] = new SkillCharacter()
                    //    {
                    //        Id = randomSkill,
                    //        SkillId = Disciple.GetSkillId(randomSkill),
                    //        Point = 1,
                    //    };
                    //}

                    if (disciplePower >= 1500000000 && disciple.Skills.Count >= 3)
                    {
                        var randomSkill = DataCache.IdSkillDisciple3[ServerUtils.RandomNumber(DataCache.IdSkillDisciple3.Count)];
                        disciple.Skills[2] = new SkillCharacter()
                        {
                            Id = randomSkill,
                            SkillId = Disciple.GetSkillId(randomSkill),
                            Point = 1,
                        };
                    }
					
					if (disciplePower >= 20000000000 && disciple.Skills.Count >= 4)
                    {
                        var randomSkill = DataCache.IdSkillDisciple4[ServerUtils.RandomNumber(DataCache.IdSkillDisciple4.Count)];
                        disciple.Skills[3] = new SkillCharacter()
                        {
                            Id = randomSkill,
                            SkillId = Disciple.GetSkillId(randomSkill),
                            Point = 1,
                        };
                    }
                    break;
                }
                case 3://dep trai nhat vu tru
                {
                    var itemId = (character.InfoChar.Gender + 227);
                    var itemAdd = ItemCache.GetItemDefault((short)itemId);
                    itemAdd.Quantity = 1;
                    character.CharacterHandler.AddItemToBag(true, itemAdd, "Ước NR");
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                    break;
                }
            }
            // character.Zone.ZoneHandler.SendMessage(Service.CallDragon(1, 0, character));
            character.CharacterHandler.SendMessage(Service.CallDragon(1, 1, character));
            MapManager.SetDragonAppeared(false);
        }
        
        private static void ConfirmCalich(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0: 
                {
                    switch(select)
                    {
                        case 0://Nói chuyện
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, MenuNpc.Gi().TextCalich[1]));
                            break;
                        }
                        case 1:
                        {
                            if(character.InfoChar.Task.Id < 24)
							{
								character.CharacterHandler.SendMessage(Service.OpenUiSay(5, "Bạn chưa thể đến khu vực này", false, character.InfoChar.Gender));
								return;
							}
							else
							{
								character.InfoMore.TransportMapId = 102;
								character.CharacterHandler.SendMessage(Service.Transport(20));
							}
                            // đến tương lai
                            break;
                        }
                    }
                    break;
                }
                case 1:
                {
                    if (select != 0) return;
                    character.InfoMore.TransportMapId = 24;
                    character.CharacterHandler.SendMessage(Service.Transport(20));
                    break;
                }
            }
        }

        private static void ConfirmSanta(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0: 
                {
                    switch(select)
                    {
                        case 0:
                        {
                            var inputGiftcode = new List<InputBox>();
                            var inputCode = new InputBox(){
                                Name = "Nhập mã quà tặng",
                                Type = 1,
                            };
                            inputGiftcode.Add(inputCode);
                            character.CharacterHandler.SendMessage(Service.ShowInput("Giftcode", inputGiftcode));
                            character.TypeInput = 1;
                            break;
                        }
                        case 1:
                        {
                            var idShop = 18 + character.InfoChar.Gender;
                            character.CharacterHandler.SendMessage(Service.Shop(character, 0, idShop));
                            character.ShopId = idShop;
                            character.TypeMenu = 0;
                            break;
                        }
                        case 2:
                        {
                            var idShop = 3 + character.InfoChar.Gender;
                            character.CharacterHandler.SendMessage(Service.Shop(character, 0, idShop));
                            character.ShopId = idShop;
                            character.TypeMenu = 0;
                            break;
                        }
                        case 3:
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, string.Format(MenuNpc.Gi().TextSanta[2], ServerUtils.GetMoneys(UserDB.GetVND(character.Player)), ServerUtils.GetMoneys(UserDB.GetTongVND(character.Player))), MenuNpc.Gi().MenuSanta[2], character.InfoChar.Gender));
                            character.TypeMenu = 1;
                            break;
                        }
                       
                        default:
                        {
                            character.CharacterHandler.SendMessage(Service.NpcChat(npcId, TextServer.gI().UPDATING));
                            break;
                        }
                    }
                    break;
                }
              
                case 1:
                {
                    switch(select)
                    {
                        case 0:
                                
                                    /// doi vang + ngoc 
                                    character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, string.Format(MenuNpc.Gi().TextSanta[5], ServerUtils.GetMoneys(UserDB.GetVND(character.Player))), MenuNpc.Gi().MenuSanta[3], character.InfoChar.Gender));
                                    character.TypeMenu = 2;

                                 



                                
                           
                            break;
                        
                        case 1:
                                // kich hoat thanh vien
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, string.Format(MenuNpc.Gi().TextSanta[4], ServerUtils.GetMoneys(UserDB.GetVND(character.Player))), MenuNpc.Gi().MenuSanta[6], character.InfoChar.Gender));
                                character.TypeMenu = 5;

                                break;
                            case 2:
                                //de tu vip
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, string.Format(MenuNpc.Gi().TextSanta[6], ServerUtils.GetMoneys(UserDB.GetVND(character.Player))), MenuNpc.Gi().MenuSanta[7], character.InfoChar.Gender));
                                character.TypeMenu = 6;

                                break;
                        }

                    break;
                }
                case 2:
                    switch (select)
                    {
                        case 0:
                        case 1:
                            if (DatabaseManager.Manager.gI().costDoiTien <= 1)
                            {
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, string.Format(MenuNpc.Gi().TextSanta[3] + "\n|1|Tình Trạng Khuyến Mãi [Không có Khuyến Mãi]", ServerUtils.GetMoneys(UserDB.GetVND(character.Player))), MenuNpc.Gi().MenuSanta[4 + select], character.InfoChar.Gender));
                                character.TypeMenu = 3 + select;
                                break;
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, string.Format(MenuNpc.Gi().TextSanta[3] + "\n|1|TÌnh Trạng Khuyến Mãi [Đang X" + DatabaseManager.Manager.gI().costDoiTien +"]", ServerUtils.GetMoneys(UserDB.GetVND(character.Player))), MenuNpc.Gi().MenuSanta[4 + select], character.InfoChar.Gender));
                                character.TypeMenu = 3 + select;
                                break;
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (select)
                    {
                        case 0:
                            if (UserDB.GetVND(character.Player) >= 20000)
                            {
                                var thoivang = ItemCache.GetItemDefault(457);
                                thoivang.Quantity = 30 * DatabaseManager.Manager.gI().costDoiTien;
                                var soluong = thoivang.Quantity;
                                character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi vàng");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_GOLD_BAR, soluong)));
                                UserDB.MineVND(character.Player, 20000);
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Không Đủ Tiền, Vui Lòng Nạp Thêm"));
                            }
                            break;
                        case 1:
                            if (UserDB.GetVND(character.Player) >= 20000)
                            {
                                var thoivang = ItemCache.GetItemDefault(457);
                                thoivang.Quantity = 200 * DatabaseManager.Manager.gI().costDoiTien;
                                var soluong = thoivang.Quantity;
                                character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi vàng");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_GOLD_BAR, soluong)));
                                UserDB.MineVND(character.Player, 20000);
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Không Đủ Tiền, Vui Lòng Nạp Thêm"));
                            }
                            break;
                        case 2:
                            if (UserDB.GetVND(character.Player) >= 50000)
                            {
                                var thoivang = ItemCache.GetItemDefault(457);
                                thoivang.Quantity = 500 * DatabaseManager.Manager.gI().costDoiTien;
                                var soluong = thoivang.Quantity;
                                character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi vàng");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_GOLD_BAR, soluong)));
                                UserDB.MineVND(character.Player, 50000);
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Không Đủ Tiền, Vui Lòng Nạp Thêm"));
                            }
                            break;
                        case 3:
                            if (UserDB.GetVND(character.Player) >= 100000)
                            {
                                var thoivang = ItemCache.GetItemDefault(457);
                                thoivang.Quantity = 1000 * DatabaseManager.Manager.gI().costDoiTien;
                                var soluong = thoivang.Quantity;
                                character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi vàng");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_GOLD_BAR, soluong)));
                                UserDB.MineVND(character.Player, 100000);
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Không Đủ Tiền, Vui Lòng Nạp Thêm"));
                            }
                            break;
                        case 4:
                            if (UserDB.GetVND(character.Player) >= 200000)
                            {
                                var thoivang = ItemCache.GetItemDefault(457);
                                thoivang.Quantity = 2000 * DatabaseManager.Manager.gI().costDoiTien;
                                var soluong = thoivang.Quantity;
                                character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi vàng");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_GOLD_BAR, soluong)));
                                UserDB.MineVND(character.Player, 200000);
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Không Đủ Tiền, Vui Lòng Nạp Thêm"));
                            }
                            break;
                        case 5:

                            if (UserDB.GetVND(character.Player) >= 500000)
                            {
                                var thoivang = ItemCache.GetItemDefault(457);
                                thoivang.Quantity = 5000 * DatabaseManager.Manager.gI().costDoiTien;
                                var soluong = thoivang.Quantity;
                                character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi vàng");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_GOLD_BAR, soluong)));
                                UserDB.MineVND(character.Player, 500000);
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Không Đủ Tiền, Vui Lòng Nạp Thêm"));
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (select)
                    {
                        case 0:
                            if (UserDB.GetVND(character.Player) >= 10000)
                            {
                                var thoivang = ItemCache.GetItemDefault(674);
                                thoivang.Quantity = 100 * DatabaseManager.Manager.gI().costDoiTien;
                                var soluong = thoivang.Quantity;
                                character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi đá ngũ sắc");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_DA, soluong)));
                                UserDB.MineVND(character.Player, 10000);
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Không Đủ Tiền, Vui Lòng Nạp Thêm"));
                            }
                            break;
                        case 1:
                            if (UserDB.GetVND(character.Player) >= 20000)
                            {
                                var thoivang = ItemCache.GetItemDefault(674);
                                thoivang.Quantity = 200 * DatabaseManager.Manager.gI().costDoiTien;
                                var soluong = thoivang.Quantity;
                                character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi đá ngũ sắc");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_DA, soluong)));
                                UserDB.MineVND(character.Player, 20000);
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Không Đủ Tiền, Vui Lòng Nạp Thêm"));
                            }
                            break;
                        case 2:
                            if (UserDB.GetVND(character.Player) >= 50000)
                            {
                                var thoivang = ItemCache.GetItemDefault(674);
                                thoivang.Quantity = 500 * DatabaseManager.Manager.gI().costDoiTien;
                                var soluong = thoivang.Quantity;
                                character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi đá ngũ sắc");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_DA, soluong)));
                                UserDB.MineVND(character.Player, 50000);
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Không Đủ Tiền, Vui Lòng Nạp Thêm"));
                            }
                            break;
                        case 3:
                            if (UserDB.GetVND(character.Player) >= 100000)
                            {
                                var thoivang = ItemCache.GetItemDefault(674);
                                thoivang.Quantity = 1000 * DatabaseManager.Manager.gI().costDoiTien;
                                var soluong = thoivang.Quantity;
                                character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi đá ngũ sắc");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_DA, soluong)));
                                UserDB.MineVND(character.Player, 100000);
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Không Đủ Tiền, Vui Lòng Nạp Thêm"));
                            }
                            break;
                        case 4:
                            if (UserDB.GetVND(character.Player) >= 200000)
                            {
                                var thoivang = ItemCache.GetItemDefault(674);
                                thoivang.Quantity = 2000 * DatabaseManager.Manager.gI().costDoiTien;
                                var soluong = thoivang.Quantity;
                                character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi đá ngũ sắc");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_DA, soluong)));
                                UserDB.MineVND(character.Player, 200000);
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Không Đủ Tiền, Vui Lòng Nạp Thêm"));
                            }
                            break;
                        case 5:

                            if (UserDB.GetVND(character.Player) >= 500000)
                            {
                                var thoivang = ItemCache.GetItemDefault(674);
                                thoivang.Quantity = 5000 * DatabaseManager.Manager.gI().costDoiTien;
                                var soluong = thoivang.Quantity;
                                character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi đá ngũ sắc");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_DA, soluong)));
                                UserDB.MineVND(character.Player, 500000);
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Không Đủ Tiền, Vui Lòng Nạp Thêm"));
                            }
                            break;
                    }
                    break;
                case 5:
                    switch (select)
                    {
                        case 0:
                            if (UserDB.GetVND(character.Player) < 20000)
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Không Đủ Tiền, Vui Lòng Nạp Thêm"));
                                return;
                            }
                            if (!character.InfoChar.IsPremium)
                            {
                                var thoivang = ItemCache.GetItemDefault(457);
                                thoivang.Quantity = 25;
                                character.PlusDiamond(100000);
                                var soluong = thoivang.Quantity;
                                character.CharacterHandler.AddItemToBag(true, thoivang, "Đổi vàng");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                                //  character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_GOLD_BAR, soluong)));
                                /// ------------->>>>
                                character.InfoChar.IsPremium = true;
                                UserDB.MineVND(character.Player, 10000);
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Kích hoạt thành viên thành công !!!, Chúc bạn chơi game vui vẻ"));
                                character.CharacterHandler.SendMessage(Service.MeLoadAll(character));
                            } else
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Bạn đã kích hoạt thành viên rồi !!"));
                            }
                            break;
                    }
                    break;
                case 6:
                    switch (select)
                    {
                        case 0:

                            if (UserDB.GetVND(character.Player) < 300000)
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Không Đủ Tiền, Vui Lòng Nạp Thêm"));
                                return;
                            }
                            if (character.Disciple == null)
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Yêu cầu bắt buộc phải có đệ tử"));
                                return;
                            }
                            
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Chưa có đâu hê hê hê"));
                            break;
							
						case 1:
						{
							if (UserDB.GetVND(character.Player) < 15000)
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage("Không Đủ Tiền, Vui Lòng Nạp Thêm"));
                                return;
                            }
							var itemAddd = ItemCache.GetItemDefault(1093);
							itemAddd.Quantity = 1;
							character.CharacterHandler.AddItemToBag(true, itemAddd, "Mua santa");
							var itemAddd2 = ItemCache.GetItemDefault(1094);
							itemAddd2.Quantity = 1;
							character.CharacterHandler.AddItemToBag(true, itemAddd2, "Mua santa");
							character.CharacterHandler.SendMessage(Service.SendBag(character));
                            UserDB.MineVND(character.Player, 15000);
                            character.CharacterHandler.SendMessage(Service.ServerMessage("Bạn nhận được 1 đá hắc hoả và 1 đá vĩnh hằng!"));
							break;
						}
                    }
                    break;
            }
        }
  
        private static void ConfirmTrungThu(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                //Menu chính
                case 0:
                {
                    switch (select)
                    {
                        case 0://shop
                        {
                            character.CharacterHandler.SendMessage(Service.Shop(character, 0, 23));
                            character.ShopId = 23;
                            break;
                        }
                        case 1:
                        {
                            var bangXepHangTrungThu = Server.Gi().BangXepHang.GetList();
                            bangXepHangTrungThu += $"\b{ServerUtils.Color("red")}Điểm sự kiện của bạn là: " + character.DiemSuKien;
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(npcId, bangXepHangTrungThu));
                            break;
                        }
                    }
                    break;
                }
            }
        }
        
        private static void ConfirmQuocVuong(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                //Menu chính
                case 0:
                {
                    switch (select)
                    {
                        case 0:
                        {
                            try
                            {
                                var limit = character.InfoChar.LitmitPower;
                                var LM = Cache.Gi().LIMIT_POWERS[limit];
                                var ngoc = 100*(limit+1); 
                                var text = string.Format(TextServer.gI().UPGRADE_LEVEL_ME, ServerUtils.GetPower(LM.Power), ngoc);
                                character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, text, MenuNpc.Gi().MenuQuocVuong[1], character.InfoChar.Gender));
                                character.TypeMenu = 1;
                            }
                            catch (Exception)
                            {
                                character.CharacterHandler.SendMessage(Service.NpcChat(npcId, "Con đã đạt giới hạn tối đa"));
                            }
                            break;
                        }
                        case 1:
                        {
                            break;
                        }
                    }
                    break;
                }
                case 1:
                {
                    switch (select)
                    {
                        case 0:
                        {
                            break;
                        }
                        case 1:
                        {
                            var limit = character.InfoChar.LitmitPower;
                            if (limit >= DataCache.MAX_LIMIT_POWER_LEVEL - 1)
                            {
                                character.CharacterHandler.SendMessage(Service.NpcChat(npcId, "Con đã đạt giới hạn tối đa"));
                                return;
                            }

                            var ngoc = 100*(limit+1);
                            if (ngoc > character.AllDiamond())
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_DIAMOND));
                                return;
                            }

                            character.InfoChar.IsPower = true;
                            character.InfoChar.LitmitPower += 1;
                            character.MineDiamond(ngoc);
                            character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                            character.CharacterHandler.SendMessage(Service.NpcChat(npcId, "Chúc mừng con đạt tới sức mạnh mới"));
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private static void ConfirmGiuMa(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                //Menu chính
                case 0:
                {
                    if (select != 0) return;
                    character.InfoMore.TransportMapId = 156;
                    character.CharacterHandler.SendMessage(Service.Transport(3, 1));
                    break;
                }   
            }
        }

        private static void ConfirmQuaTrung(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0://Chua đủ thời gian
                {
                    switch(select)
                    {
                        case 0://Chờ, bỏ qua
                        {
                            break;
                        }
                        case 1://Dùng tiền để nở trứng
                        {
                            var disciple = character.Disciple;
                            if (disciple != null)
                            {
                                var itemDiscipleBody = disciple.ItemBody.FirstOrDefault(item => item != null);

                                if (itemDiscipleBody != null)
                                {
                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().PLEASE_EMPTY_DISCIPLE_BODY));
                                    return;
                                }
                            }
                            // Kiểm tra trạng thái hợp thể
                            if (character.InfoChar.Fusion.IsFusion)
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().PLEASE_NOT_FUSION));
                                return;
                            }

                            if (character.InfoChar.Gold < DataCache.GIA_NO_TRUNG_MA_BU)
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_GOLD));
                                return;
                            }

                            // Kiểm tra sức mạnh đệ tử 20 tỷ
                            if (character.Disciple != null && character.Disciple.InfoChar.Power < 160000000)
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().DISCIPLE_NOT_ENOUGH_POWER_TO_OPEN_EGG));
                                return;
                            }

                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuaTrung[1], MenuNpc.Gi().MenuQuaTrung[2], character.InfoChar.Gender));
                            character.TypeMenu = 2;
                            break;
                        }
                    }
                    break;
                }
                case 1: //Menu đủ thời gian
                {
                    switch(select)
                    {
                        case 0: //Nở trứng
                        {
                            var disciple = character.Disciple;
                            if (disciple != null)
                            {
                                var itemDiscipleBody = disciple.ItemBody.FirstOrDefault(item => item != null);

                                if (itemDiscipleBody != null)
                                {
                                    character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().PLEASE_EMPTY_DISCIPLE_BODY));
                                    return;
                                }
                            }
                            // Kiểm tra trạng thái hợp thể
                            if (character.InfoChar.Fusion.IsFusion)
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().PLEASE_NOT_FUSION));
                                return;
                            }

                            if (character.Disciple != null && character.Disciple.InfoChar.Power < 160000000)
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().DISCIPLE_NOT_ENOUGH_POWER_TO_OPEN_EGG));
                                return;
                            }

                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextQuaTrung[1], MenuNpc.Gi().MenuQuaTrung[2], character.InfoChar.Gender));
                            character.TypeMenu = 3;
                            break;
                        }
                    }
                    break;
                }
                case 2:
                {
                    character.MineGold(DataCache.GIA_NO_TRUNG_MA_BU);
                    CreateDiscipleMabu(character, (sbyte)select);
                    break;
                }
                case 3:
                {
                    CreateDiscipleMabu(character, (sbyte)select);
                    break;
                }
            }
        }
        
        private static void ConfirmBill(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0:
                {
                    if (select != 0) return;
                    var fullThucAn = character.ItemBag.FirstOrDefault(item => DataCache.ListThucAn.Contains(item.Id) && item.Quantity >= 99);

                    if (character.InfoSet.IsFullSetThanLinh && fullThucAn != null)
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBill[2], MenuNpc.Gi().MenuBill[2], character.InfoChar.Gender));
                        character.TypeMenu = 2;
                    }
                    else 
                    {   
                        character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId, MenuNpc.Gi().TextBill[1], MenuNpc.Gi().MenuBill[1], character.InfoChar.Gender));
                        character.TypeMenu = 1;
                    }
                    break;
                }   
                case 2:
                {
                    if (select != 0) return;
                    character.CharacterHandler.SendMessage(Service.Shop(character, 3, 21));
                    character.ShopId = 21;
                    character.TypeMenu = 3;
                    break;
                }
            }
        }
		private static void ConfirmCayThong(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0:
                {
                    switch(select)
					{
						case 0:
						{ 
							if(character.CharacterHandler.GetItemBagById(457) == null || character.CharacterHandler.GetItemBagById(1095) == null || character.CharacterHandler.GetItemBagById(1096) == null || character.CharacterHandler.GetItemBagById(1097) == null)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Bạn không có đụ nguyên liệu"));
								break;
							}
                            
                            if (character.CharacterHandler.GetItemBagById(1095).Quantity < 5 ||
                                character.CharacterHandler.GetItemBagById(1096).Quantity < 5 ||
                                character.CharacterHandler.GetItemBagById(1097).Quantity < 5)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Bạn không có đụ nguyên liệu"));
                            } else if (character.CharacterHandler.GetItemBagById(457).Quantity < 5 )
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Bạn không có đụ thỏi vàng"));
                            } else if (character.LengthBagNull() < 1)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Hành trang cần ít nhất 1 ô trống"));
                            }
                            else
                            {
                                var randomRate = ServerUtils.RandomNumber(0.0, 100.0);
								var randomDate = ServerUtils.RandomNumber(0.0, 100.0);
								var gioitinh = character.InfoChar.Gender;
								var itemAdd2 = ItemCache.GetItemDefault(76);

								if (randomRate <= 7.0)
								{
									if(gioitinh == 0)
									{
										itemAdd2 = ItemCache.GetItemDefault(1088);
									}
									else if(gioitinh == 1)
									{
										itemAdd2 = ItemCache.GetItemDefault(1089);
									}
									else if(gioitinh == 2)
									{
										itemAdd2 = ItemCache.GetItemDefault(1090);
									}
									itemAdd2.Options.Add(new OptionItem()
									{
										Id = 93,
										Param = ServerUtils.RandomNumber(1, 3),
									});
								}
								else if (randomRate <= 14.0)
								{
									itemAdd2 = ItemCache.GetItemDefault(1079);
									if (randomDate >= 5)
									{

										itemAdd2.Options.Add(new OptionItem()
										{
											Id = 93,
											Param = ServerUtils.RandomNumber(1, 3),
										});
									}
								}
								else if (randomRate <= 50.0)
								{
									var listHD = new List<short>() {381, 382, 383, 384, 385}; // item ngẫu nhiên
									var itemHDRand = listHD[ServerUtils.RandomNumber(listHD.Count)];
									itemAdd2 = ItemCache.GetItemDefault(itemHDRand);
								}
								else
								{
									var gold = ServerUtils.RandomNumber(10000000,50000000);
									character.CharacterHandler.SendMessage(
										Service.ServerMessage(string.Format($"Bạn nhận được {ServerUtils.GetMoney(gold)} vàng")));
									character.PlusGold(gold);
									character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
								}
								itemAdd2.Reason = "Cay thong duyt";
								itemAdd2.Quantity = 1;
                                character.CharacterHandler.RemoveItemBagById(1095, 5, reason:"Cay Thong");
                                character.CharacterHandler.RemoveItemBagById(1096, 5, reason:"Cay Thong");
                                character.CharacterHandler.RemoveItemBagById(1097, 5, reason:"Cay Thong");
                                character.CharacterHandler.RemoveItemBagById(457, 5, reason:"Cay Thong");
								character.CharacterHandler.AddItemToBag(true, itemAdd2, "SuKien");
								character.CharacterHandler.SendMessage(Service.SendBag(character));
								var template2 = ItemCache.ItemTemplate(itemAdd2.Id);
								character.CharacterHandler.SendMessage(
								Service.ServerMessage(string.Format(TextServer.gI().ADD_ITEM,
								 $"x{itemAdd2.Quantity} {template2.Name}")));
                            }
                            break;
						}
						case 1:
						{
							if (character.CharacterHandler.GetItemBagById(457) == null || character.CharacterHandler.GetItemBagById(1095) == null || character.CharacterHandler.GetItemBagById(1096) == null || character.CharacterHandler.GetItemBagById(1097) == null || character.CharacterHandler.GetItemBagById(1098) == null)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Bạn không có đụ nguyên liệu"));
                                break;
                            }
                            
                            if (character.CharacterHandler.GetItemBagById(1095).Quantity < 8 ||
                                character.CharacterHandler.GetItemBagById(1096).Quantity < 8 ||
                                character.CharacterHandler.GetItemBagById(1097).Quantity < 8 ||
                                character.CharacterHandler.GetItemBagById(1098).Quantity < 8)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Bạn không có đụ nguyên liệu"));
                            } else if (character.CharacterHandler.GetItemBagById(457).Quantity < 15 )
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Bạn không có đụ thỏi vàng"));
                            } else if (character.LengthBagNull() < 1)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Hành trang cần ít nhất 1 ô trống"));
                            }
                            else
                            {
                                var randomRate = ServerUtils.RandomNumber(0.0, 100.0);
								var randomDate = ServerUtils.RandomNumber(0.0, 100.0);
								var gioitinh = character.InfoChar.Gender;
								var itemAdd2 = ItemCache.GetItemDefault(76);

								if (randomRate <= 14.0)
								{
									if(gioitinh == 0)
									{
										itemAdd2 = ItemCache.GetItemDefault(1088);
									}
									else if(gioitinh == 1)
									{
										itemAdd2 = ItemCache.GetItemDefault(1089);
									}
									else if(gioitinh == 2)
									{
										itemAdd2 = ItemCache.GetItemDefault(1090);
									}
									if (randomDate >= 3)
									{

										itemAdd2.Options.Add(new OptionItem()
										{
											Id = 93,
											Param = ServerUtils.RandomNumber(1, 3),
										});
									}
								}
								else if (randomRate <= 20.0)
								{
									itemAdd2 = ItemCache.GetItemDefault(1079);
									if (randomDate >= 10)
									{

										itemAdd2.Options.Add(new OptionItem()
										{
											Id = 93,
											Param = ServerUtils.RandomNumber(1, 3),
										});
									}
								}
								else if (randomRate <= 75.0)
								{
									var listHD = new List<short>() {381, 382, 383, 384, 385}; // item ngẫu nhiên
									var itemHDRand = listHD[ServerUtils.RandomNumber(listHD.Count)];
									itemAdd2 = ItemCache.GetItemDefault(itemHDRand);
								}
								else
								{
									var gold = ServerUtils.RandomNumber(10000000,50000000);
									character.CharacterHandler.SendMessage(
										Service.ServerMessage(string.Format($"Bạn nhận được {ServerUtils.GetMoney(gold)} vàng")));
									character.PlusGold(gold);
									character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
								}
								itemAdd2.Reason = "Cay thong duyt";
								itemAdd2.Quantity = 1;
                                character.CharacterHandler.RemoveItemBagById(1095, 8, reason:"Cay Thong");
                                character.CharacterHandler.RemoveItemBagById(1096, 8, reason:"Cay Thong");
                                character.CharacterHandler.RemoveItemBagById(1097, 8, reason:"Cay Thong");
                                character.CharacterHandler.RemoveItemBagById(1098, 8, reason:"Cay Thong");
                                character.CharacterHandler.RemoveItemBagById(457, 15, reason:"Cay Thong");
								character.CharacterHandler.AddItemToBag(true, itemAdd2, "SuKien");
								character.CharacterHandler.SendMessage(Service.SendBag(character));
								var template2 = ItemCache.ItemTemplate(itemAdd2.Id);
								character.CharacterHandler.SendMessage(
								Service.ServerMessage(string.Format(TextServer.gI().ADD_ITEM,
								 $"x{itemAdd2.Quantity} {template2.Name}")));
                            }
							break;
						}
						case 2:
						{
							break;
						}
					}
                    break;
                }
            }
        }
       
		private static void ConfirmGoldShop(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0:
                {
                var idShop = 53;
                            character.CharacterHandler.SendMessage(Service.Shop(character, 3, idShop));
                            character.ShopId = idShop;
                            character.TypeMenu = 3;
                            break;
                }
            }
        }
		private static void ConfirmCTnew(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0:
                {
                var idShop = 53;
                            character.CharacterHandler.SendMessage(Service.Shop(character, 3, idShop));
                            character.ShopId = idShop;
                            character.TypeMenu = 3;
                            break;
                }
            }
        }
        private static void ConfirmNoiBanh(Character character, short npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0:
                {
                    switch (select)
                    {
                        case 0:
                        { // nấu bằng ngọc type menu 1
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId,
                                MenuNpc.Gi().TextNoiBanh[1], MenuNpc.Gi().MenuNoiBanh[1], character.InfoChar.Gender));
                            character.TypeMenu = 1;
                            break;
                        }
                        case 1:
                        { // nấu bằng vàng type menu 2
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(npcId,
                                MenuNpc.Gi().TextNoiBanh[2], MenuNpc.Gi().MenuNoiBanh[1], character.InfoChar.Gender));
                            character.TypeMenu = 2;
                            break;
                        }
                    }

                    break;
                    }   
                case 1: // xử lý client đã chọn nấu bằng ngọc
                {
                    switch (select)
                    {
                        case 0:
                        { // kiểm tra trước tránh null chết sv
                            if (character.CharacterHandler.GetItemBagById(886) == null || character.CharacterHandler.GetItemBagById(886) == null || character.CharacterHandler.GetItemBagById(887) == null || character.CharacterHandler.GetItemBagById(888) == null || character.CharacterHandler.GetItemBagById(889) == null)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Bạn không có đủ nguyên liệu"));
                                break;
                            }

                            var randtile = ServerUtils.RandomNumber(1, 10);
                            if (character.CharacterHandler.GetItemBagById(886).Quantity < 10 ||
                                character.CharacterHandler.GetItemBagById(887).Quantity < 10 ||
                                character.CharacterHandler.GetItemBagById(888).Quantity < 10 ||
                                character.CharacterHandler.GetItemBagById(889).Quantity < 10)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Bạn không có đủ nguyên liệu"));
                            } else if (character.InfoChar.Diamond < 100)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Bạn không có đủ ngọc"));
                            } else if (character.LengthBagNull() < 1)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Hành trang cần ít nhất 1 ô trống"));
                            } else if (randtile < 5)
                            {
                                character.CharacterHandler.SendMessage(Service.NpcChat(npcId,
                                    "Ohhh nooo, bánh đã bị hỏng rồi... chúc bạn may mắn lần sau ^^"));
                                character.CharacterHandler.RemoveItemBagById(886, 10, reason:"Nấu bánh");
                                character.CharacterHandler.RemoveItemBagById(887, 10, reason:"Nấu bánh");
                                character.CharacterHandler.RemoveItemBagById(888, 10, reason:"Nấu bánh");
                                character.CharacterHandler.RemoveItemBagById(889, 10, reason:"Nấu bánh");
                                character.MineDiamond(100);
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.NpcChat(npcId,
                                    "Chúc mừng bạn đã làm bánh thành công"));
                                character.CharacterHandler.RemoveItemBagById(886, 10, reason:"Nấu bánh");
                                character.CharacterHandler.RemoveItemBagById(887, 10, reason:"Nấu bánh");
                                character.CharacterHandler.RemoveItemBagById(888, 10, reason:"Nấu bánh");
                                character.CharacterHandler.RemoveItemBagById(889, 10, reason:"Nấu bánh");
                                character.MineDiamond(100);
                                var itemAdd = ItemCache.GetItemDefault(891);
                                character.CharacterHandler.AddItemToBag(true, itemAdd, "Làm bánh");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                            }
                            break;
                        }
                        case 1:
                        { 
                            //hủy
                            break;
                        }
                    }

                    break;
                }
                case 2: //xử lý client đã chọn nấu bằng vàng
                {
                    switch (select)
                    {
                        case 0:
                        { // kiểm tra trước tránh null chết sv
                            if (character.CharacterHandler.GetItemBagById(886) == null || character.CharacterHandler.GetItemBagById(886) == null || character.CharacterHandler.GetItemBagById(887) == null || character.CharacterHandler.GetItemBagById(888) == null || character.CharacterHandler.GetItemBagById(889) == null)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Bạn không có đủ nguyên liệu"));
                                break;
                            }
                            
                            if (character.CharacterHandler.GetItemBagById(886).Quantity < 10 ||
                                character.CharacterHandler.GetItemBagById(887).Quantity < 10 ||
                                character.CharacterHandler.GetItemBagById(888).Quantity < 10 ||
                                character.CharacterHandler.GetItemBagById(889).Quantity < 10)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Bạn không có đủ nguyên liệu"));
                            } else if (character.InfoChar.Gold < 25000000)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Bạn không có đủ vàng"));
                            } else if (character.LengthBagNull() < 1)
                            {
                                character.CharacterHandler.SendMessage(
                                    Service.ServerMessage("Hành trang cần ít nhất 1 ô trống"));
                            }
                            else
                            {
                                character.CharacterHandler.SendMessage(Service.NpcChat(npcId,
                                    "Chúc mừng bạn đã làm bánh thành công"));
                                character.CharacterHandler.RemoveItemBagById(886, 10, reason:"Nấu bánh");
                                character.CharacterHandler.RemoveItemBagById(887, 10, reason:"Nấu bánh");
                                character.CharacterHandler.RemoveItemBagById(888, 10, reason:"Nấu bánh");
                                character.CharacterHandler.RemoveItemBagById(889, 10, reason:"Nấu bánh");
                                character.MineGold(2500000);
                                var itemAdd = ItemCache.GetItemDefault(891);
                                character.CharacterHandler.AddItemToBag(true, itemAdd, "Làm bánh");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                            }
                            break;
                        }
                        case 1:
                        { 
                            //hủy
                            break;
                        }
                    }

                    break;
                }
                
            }
        }
		private static void ConfirmDuongTang(Character character, short npcId, int select)
        {
            var map = MapManager.Get(character.InfoChar.MapId);
            if (map == null) return;
            Threading.Map mapJoin = null;
            switch (character.TypeMenu)
            {
                //Menu chính
                case 0:
                    {
                       switch (select)
                        {
                            case 0:
                            if (character.InfoChar.Task.Id < 0) {
                        character.CharacterHandler.SendMessage(Service.OpenUiSay(5, "Bạn chưa thể đến khu vực này", false, character.InfoChar.Gender));
                        return;
                    }
						mapJoin = MapManager.Get(123);
						break;
                            case 1:
                                break;
                        }
                    }
                    if (mapJoin == null) return;
                    var zoneJoin = mapJoin.GetZoneNotMaxPlayer();
                    if (zoneJoin != null)
                    {
                        character.CharacterHandler.SendZoneMessage(Service.SendTeleport(character.Id, character.InfoChar.Teleport));
                        map.OutZone(character, mapJoin.Id);
                        zoneJoin.ZoneHandler.JoinZone(character, false, true, character.InfoChar.Teleport);
                    }
                    else
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiSay(5, TextServer.gI().MAX_NUMCHARS, false, character.InfoChar.Gender));
                    }
                    break;
                case 1:
                    {
                        switch (select)
                        {
                            case 0:
                                mapJoin = MapManager.Get(0);
                                break;
                        }
                        
                    }
                    if (mapJoin == null) return;
                    var zoneJoin2 = mapJoin.GetZoneNotMaxPlayer();
                    if (zoneJoin2 != null)
                    {
                        character.CharacterHandler.SendZoneMessage(Service.SendTeleport(character.Id, character.InfoChar.Teleport));
                        map.OutZone(character, mapJoin.Id);
                        zoneJoin2.ZoneHandler.JoinZone(character, false, true, character.InfoChar.Teleport);
                    }
                    else
                    {
                        character.CharacterHandler.SendMessage(Service.OpenUiSay(5, TextServer.gI().MAX_NUMCHARS, false, character.InfoChar.Gender));
                    }
                    break;

                case 2:
                    {
                        switch (select)
                        {
                            case 0:
                                var giai = character.CharacterHandler.GetItemBagById(537);
                                var khai = character.CharacterHandler.GetItemBagById(538);
                                var phong = character.CharacterHandler.GetItemBagById(539);
                                var an = character.CharacterHandler.GetItemBagById(540);
                                if (giai != null && khai != null && phong != null && an != null) {
                                    if (giai.Quantity >= 10 && khai.Quantity >= 10 && phong.Quantity >= 10 && an.Quantity >= 10)
                                    {
                                        for (short dball = 537; dball <= 540; dball++)
                                        {
                                            character.CharacterHandler.RemoveItemBagById(dball, 10, "Ngũ Hành Sơn");
                                        }
                                        var randomRate = ServerUtils.RandomNumber(0.0, 100.0);
                                        var random = ServerUtils.RandomNumber(0.0, 100.0);
                                        var itemAdd2 = ItemCache.GetItemDefault(1);

                                        if (randomRate <= 20.0)
                                        {
                                            itemAdd2 = ItemCache.GetItemDefault(544);
                                        }
                                        else if (randomRate <= 40.0)
                                        {
                                            itemAdd2 = ItemCache.GetItemDefault(545);
                                        }
                                        else if (randomRate <= 60.0)
                                        {
                                            itemAdd2 = itemAdd2 = ItemCache.GetItemDefault(546);
                                        }
                                        else if (randomRate <= 80.0)
                                        {
                                            itemAdd2 = itemAdd2 = ItemCache.GetItemDefault(547);
                                        }
                                        else
                                        {
                                            itemAdd2 = itemAdd2 = ItemCache.GetItemDefault(543);
                                        }
                                        itemAdd2.Reason = "Ngũ Hành Sơnnn";
                                        itemAdd2.Options.Add(new OptionItem()
                                       {
                                            Id = 77,
                                            Param = ServerUtils.RandomNumber(50),
                                        }) ;
                                        itemAdd2.Options.Add(new OptionItem()
                                        {
                                            Id = 103,
                                            Param = ServerUtils.RandomNumber(50),
                                        });
                                        itemAdd2.Options.Add(new OptionItem()
                                        {
                                            Id = 50,
                                            Param = ServerUtils.RandomNumber(50),
                                        });
                                        itemAdd2.Options.Add(new OptionItem()
                                        {
                                            Id = 101,
                                            Param = ServerUtils.RandomNumber(50),
                                        });
                                        if (random <= 10)
                                        {

                                            itemAdd2.Options.Add(new OptionItem()
                                            {
                                                Id = 95,
                                                Param = ServerUtils.RandomNumber(30),
                                            });
                                        } else if (random <= 30)
                                        {
                                            itemAdd2.Options.Add(new OptionItem()
                                            {
                                                Id = 96,
                                                Param = ServerUtils.RandomNumber(30),
                                            });
                                        }
                                        itemAdd2.Quantity = 1;
                                        character.CharacterHandler.AddItemToBag(true, itemAdd2, "SuKien");
                                        character.CharacterHandler.SendMessage(Service.SendBag(character));
                                        var template2 = ItemCache.ItemTemplate(itemAdd2.Id);
                                        character.CharacterHandler.SendMessage(
                                        Service.ServerMessage(string.Format(TextServer.gI().ADD_ITEM,
                                         $"x{itemAdd2.Quantity} {template2.Name}")));
                                        break;
                                    } else
                                    {
                                        character.CharacterHandler.SendMessage(Service.ServerMessage("Không đủ Vật Phẩm"));
                                    }
                                } else
                                {
                                    character.CharacterHandler.SendMessage(Service.ServerMessage("Bạn Không Có Bùa"));
                                }
                                break;
                        }
                    }
                    break;
            }
        }
        #endregion
        #region Menu NOT COFIRM

        private static void MenuDauThan(Character character, int npcId, int menuId, int optionId)
        {
            var magicTree = MagicTreeManager.Get(character.Id);
            if(magicTree == null) return;
            lock (magicTree)
            {
                switch (menuId)
                {
                    //Thu hoạch // Dùng ngọc nâng cấp
                    case 0:
                    {
                        if (magicTree.IsUpdate)
                        {
                            var ngoc = magicTree.Diamond;
                            if (character.AllDiamond() < ngoc)
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_DIAMOND));
                                return;
                            }
                            character.MineDiamond(ngoc);
                            
                            magicTree.IsUpdate = false;
                            magicTree.Level++;
                            switch (magicTree.Level)
                            {
                                case < 8:
                                    magicTree.NpcId++;
                                    break;
                                case >= 10:
                                    magicTree.Level = 10;
                                    break;
                            }

                            magicTree.MaxPea += 2; 
                            magicTree.Peas = magicTree.MaxPea;
                            magicTree.Seconds = 0;
                            magicTree.Diamond = 0;
                            // MagicTreeDB.Update(magicTree);

                            magicTree.MagicTreeHandler.HandleNgoc();
                            character.CharacterHandler.SendMessage(Service.MagicTree0(magicTree));
                            character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                            MagicTreeDB.Update(magicTree);
                        }
                        else
                        {
                            if(magicTree.Peas == 0) return;
                            var quantityPea = magicTree.Peas;
                            var emptyBag = 10 - character.GetTotalDauThanBag();
                            var emptyBox = 20 - character.GetTotalDauThanBox();
                            var totalEmpty = emptyBag + emptyBox;
                            if (emptyBag <= 0 && emptyBox <= 0)
                            {
                                character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().MAX_PEAS));
                                return;
                            }
                            if(quantityPea > 0 && emptyBag > 0) {
                                if(quantityPea < emptyBag) {
                                    emptyBag = quantityPea;
                                    quantityPea = 0;
                                } else {
                                    quantityPea -= emptyBag;
                                }
                                var item = ItemCache.GetItemDefault((short)DataCache.IdDauThan[magicTree.Level - 1], emptyBag);
                                if(character.CharacterHandler.AddItemToBag(true, item, "Thu hoạch đậu")) {
                                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                                }
                            }
                            if(quantityPea > 0 && emptyBox > 0) {
                                if(quantityPea < emptyBox) {
                                    emptyBox = quantityPea;
                                    quantityPea = 0;
                                } else {
                                    quantityPea -= emptyBox;
                                }
                                var item = ItemCache.GetItemDefault((short)DataCache.IdDauThan[magicTree.Level - 1], emptyBox);
                                if(character.CharacterHandler.AddItemToBox(true, item)) {
                                    character.CharacterHandler.SendMessage(Service.SendBox(character));
                                }
                            }

                            if (totalEmpty > 0)
                            {
                                character.CharacterHandler.SendMessage(Service.MagicTree0(magicTree));
                            }
                            magicTree.Peas = quantityPea;
                            magicTree.Seconds = 60000 * magicTree.Level + ServerUtils.CurrentTimeMillis();
                            magicTree.IsUpdate = false;
                            magicTree.MagicTreeHandler.HandleNgoc();
                            character.CharacterHandler.SendMessage(Service.MagicTree2(quantityPea, magicTree.Level));
                        }
                        break;
                    }
                    //Nâng cấp
                    case 1:
                    {
                        if (magicTree.Level == 10)
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiSay(5, "Đậu thần đã đạt đến cấp độ tối đa", false, character.InfoChar.Gender));
                            return;
                        }
                        if (magicTree.IsUpdate)
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(5, MenuNpc.Gi().TextMeo[1], MenuNpc.Gi().MenuMeo[0], character.InfoChar.Gender));
                            character.TypeMenu = 2;
                        }
                        else
                        {
                            character.CharacterHandler.SendMessage(Service.OpenUiConfirm(5, MenuNpc.Gi().TextMeo[0], MenuNpc.Gi().MenuMeo[0], character.InfoChar.Gender));
                            character.TypeMenu = 1;
                        }
                        break;
                    }
                    //Kết hạt nhanh
                    case 2:
                    {
                        if(magicTree.IsUpdate || magicTree.Peas == magicTree.MaxPea) return;
                        var ngoc = magicTree.Diamond;
                        if (character.AllDiamond() < ngoc)
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_DIAMOND));
                            return;
                        }
                        character.MineDiamond(ngoc);
                        magicTree.Peas = magicTree.MaxPea;
                        magicTree.Seconds = 0;
                        magicTree.IsUpdate = false;
                        magicTree.MagicTreeHandler.HandleNgoc();
                        character.CharacterHandler.SendMessage(Service.MagicTree0(magicTree));
                        character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                        break;
                    }
                }
            }
            
        }
        

        #endregion
    
        #region Function
        private static void CreateDiscipleMabu(Character character, sbyte gender)
        {
            // Nếu có đệ thì đổi đệ
            var oldDisciple = character.Disciple;
            if (oldDisciple != null || DiscipleDB.IsAlreadyExist(-character.Id))
            {
                oldDisciple = new Disciple();
                oldDisciple.CreateNewMaBuDisciple(character, gender);
                oldDisciple.Player = character.Player;
                oldDisciple.CharacterHandler.SetUpInfo();
                character.Disciple = oldDisciple;
                DiscipleDB.Update(oldDisciple);
            }
            // không có thì tạo mới
            else
            {
                var disciple = new Disciple();
                disciple.CreateNewMaBuDisciple(character, gender);
                disciple.Player = character.Player;
                disciple.CharacterHandler.SetUpInfo();
                character.Disciple = disciple;
                character.InfoChar.IsHavePet = true;
                character.CharacterHandler.SendMessage(Service.Disciple(1, null));
                DiscipleDB.Create(disciple);
            }
            
            // var oldDisciple = character.Disciple;
            // if (oldDisciple != null)
            // {
            //     DiscipleDB.Delete(oldDisciple.Id);
            //     character.CharacterHandler.SendMessage(Service.Disciple(0, null)); 
            //     character.InfoChar.IsHavePet = false;
            //     character.Disciple = null;
            // }
            character.CharacterHandler.SendMessage(Service.NoTrungMaBu());
            character.InfoChar.ThoiGianTrungMaBu = 0;

            // Thread.Sleep(3000);
            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().GET_NEW_MABU_DISCIPLE));
            
        }
        #endregion
    }
}