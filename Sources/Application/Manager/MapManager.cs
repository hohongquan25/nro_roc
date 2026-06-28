using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using NRO_Server.Application.Interfaces.Map;
using NRO_Server.DatabaseManager;
using NRO_Server.Model.Character;
using NRO_Server.Application.Interfaces.Character;

namespace NRO_Server.Application.Manager
{
    public class MapManager
    {
        public static int IdBase = 0;
        public static readonly ConcurrentDictionary<int, IMapCustom> Enrtys = new ConcurrentDictionary<int, IMapCustom>();
        private static readonly List<Threading.Map> Maps = new List<Threading.Map>();

        public static bool isDragonHasAppeared = false;
        public static long delayCallDragon = 0;

        public static Threading.Map Get(int id)
        {
            return Maps.FirstOrDefault(x => x.Id == id);
        }

        public static IMapCustom GetMapCustom(int id)
        {
            lock (Enrtys)
            {
                return Enrtys.Values.FirstOrDefault(x => x.Id == id);  
            }
        }

        public static void InitMapServer()
        {
            Cache.Gi().TILE_MAPS.ForEach(x =>
            {
                Maps.Add(new Threading.Map(x.Id, x, null));
            });
            InitNamekBalls();
        }

        public static long NamekDragonNextAvailableTime = 0;

        public static void InitNamekBalls(bool isAfterWish = false)
        {
            try
            {
                string filePath = "namek_time.txt";
                if (System.IO.File.Exists(filePath))
                {
                    long.TryParse(System.IO.File.ReadAllText(filePath), out NamekDragonNextAvailableTime);
                }
                
                if (isAfterWish) {
                    NamekDragonNextAvailableTime = NRO_Server.Application.IO.ServerUtils.CurrentTimeMillis() + (7L * 24 * 60 * 60 * 1000);
                    System.IO.File.WriteAllText(filePath, NamekDragonNextAvailableTime.ToString());
                }

                bool spawnStones = NamekDragonNextAvailableTime > NRO_Server.Application.IO.ServerUtils.CurrentTimeMillis();

                int[] namekMaps = new int[] { 7, 8, 9, 10, 11, 12, 13, 31, 32, 33, 34, 43 };
                for (int i = 0; i < 7; i++)
                {
                    int ballId = spawnStones ? 362 : (353 + i);
                    var mapId = namekMaps[NRO_Server.Application.IO.ServerUtils.RandomNumber(namekMaps.Length)];
                    var map = Get(mapId);
                    if (map != null)
                    {
                        var zone = map.Zones[NRO_Server.Application.IO.ServerUtils.RandomNumber(map.Zones.Count)];
                        if (zone != null)
                        {
                            var itemTemplate = NRO_Server.Application.Constants.ItemCache.ItemTemplate((short)ballId);
                            if (itemTemplate != null)
                            {
                                var item = new NRO_Server.Model.Item.Item()
                                {
                                    Id = itemTemplate.Id,
                                    Quantity = 1
                                };
                                var itemMap = new NRO_Server.Model.Item.ItemMap(-1, item)
                                {
                                    X = (short)NRO_Server.Application.IO.ServerUtils.RandomNumber(100, 500),
                                    Y = 300, // Will fall to ground automatically
                                    LeftTime = -1,
                                };
                                zone.ZoneHandler.LeaveItemMap(itemMap);
                            }
                        }
                    }
                }
            }
            catch (System.Exception) {}
        }

        public static void JoinMap(Character @char, int mapId, int zoneId, bool isDefault, bool isTeleport, int typeTeleport)
        {
            var map = Get(mapId);
            map?.JoinZone(@char, zoneId, isDefault, isTeleport, typeTeleport );
        }

        public static void OutMap(Character @char, int mapNextId)
        {
            var map = Get(@char.InfoChar.MapId);
            map?.OutZone(@char, mapNextId);
        }

        // For only once dragon apprea
        public static void SetDragonAppeared(bool toggle)
        {
            isDragonHasAppeared = toggle;
        }

        public static bool IsDragonHasAppeared()
        {
            return isDragonHasAppeared;
        }
    }
}