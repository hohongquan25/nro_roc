﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NRO_Server.Application.IO;
using NRO_Server.Application.Main;
using NRO_Server.Application.Manager;
using NRO_Server.Application.Constants;
using Org.BouncyCastle.Math.Field;
using NRO_Server.Model;
using NRO_Server.Model.Character;
using NRO_Server.DatabaseManager;
using System.Security.Cryptography;

namespace NRO_Server.Application.Threading
{
    public class BossRunTime
    {
        private static BossRunTime Instance { get; set; } = null;

        public static bool IsStop = false;

        #region Super Broly Boss
        private static bool IsSuperBrolySpawn = false;
        private static List<int> SuperBrolyMaps = new List<int>{5, 29, 13, 20, 36, 38, 33};
        private static Boss superBroly = null;
        private static int superBrolyId = -1;
        private static bool IsSuperBrolyNotify = false;
        private static long superBrolySpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
        #endregion

        #region Black Goku
        private static List<int> BlackGokuMaps = new List<int>{92, 93, 94};
        private static Boss blackGoku = null;
        private static int blackGokuId = -1;
        private static bool IsBlackGokuSpawn = false;
        private static bool IsBlackGokuNotify = false;

        private static Boss superBlackGoku = null;
        private static int superBlackGokuId = -1;
        private static bool IsSuperBlackGokuSpawn = false;
        private static bool IsSuperBlackGokuNotify = false;
        private static long blackGokuSpawnTimeDelay = 1500000 + ServerUtils.CurrentTimeMillis();
        #endregion

        #region Fide

        private static List<int> FideMaps = new List<int>{80};
        private static int CurrentFideMapId = 0;
        private static int CurrentFideZoneId = 0;


        private static Boss fide01 = null;
        private static Boss fide02 = null;
        private static Boss fide03 = null;

        private static bool IsFide01Spawn = false;
        private static bool IsFide01Notify = false;
        private static int fide01Id = -1;
        private static long fide01SpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();

        private static bool IsFide02Spawn = false;
        private static bool IsFide02Notify = false;
        private static int fide02Id = -1;

        private static bool IsFide03Spawn = false;
        private static bool IsFide03Notify = false;
        private static int fide03Id = -1;

        #endregion

        #region thoxanh
        private static bool IsthoxanhSpawn = false;
        private static List<int> thoxanhMaps = new List<int> { 2 };
        private static Boss thoxanh = null;
        private static int thoxanhId = -1;
        private static bool IsthoxanhNotify = false;
        private static long thoxanhSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
        #endregion

        #region thodo
        private static bool IsthodoSpawn = false;
        private static List<int> thodoMaps = new List<int> { 8 };
        private static Boss thodo = null;
        private static int thodoId = -1;
        private static bool IsthodoNotify = false;
        private static long thodoSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
        #endregion

        #region thoden
        private static bool IsthodenSpawn = false;
        private static List<int> thodenMaps = new List<int> { 16 };
        private static Boss thoden = null;
        private static int thodenId = -1;
        private static bool IsthodenNotify = false;
        private static long thodenSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
        #endregion

        #region XBH

        private static List<int> XBHMaps = new List<int>{100};
        private static Boss xbh01 = null;
        private static Boss xbh02 = null;
        private static Boss xht03 = null;
        private static bool IsXbh01Spawn = false;
        private static bool IsXbh02Spawn = false;
        private static bool IsXht03Spawn = false;
        private static bool IsXbhNotify = false;
        private static int xbh01Id = -1;
        private static int xbh02Id = -1;
        private static int xht03Id = -1;
        private static long xbhSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();

        #endregion

        #region Cooler

        private static List<int> CoolerMaps = new List<int>{107,108,110};
        private static int CurrentCoolerMapId = 0;
        private static int CurrentCoolerZoneId = 0;

        private static Boss cooler01 = null;
        private static Boss cooler02 = null;

        private static bool IsCooler01Spawn = false;
        private static bool IsCooler01Notify = false;
        private static int cooler01Id = -1;
        private static long cooler01SpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();

        private static bool IsCooler02Spawn = false;
        private static bool IsCooler02Notify = false;
        private static int cooler02Id = -1;


        #endregion

        #region Boss thỏ phê cỏ
        // private static bool IsThoPheCoSpawn = false;
        // private static List<int> ThoPheCoMaps = new List<int>{0,5,7,14};
        // private static Boss ThoPheCo = null;
        // private static int ThoPheCoId = -1;
        // private static bool IsThoPheCoNotify = false;
        // private static long ThoPheCoSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
        #endregion

        #region Boss thỏ đại ca
         private static bool IsThoDaiCaSpawn = false;
         private static List<int> ThoDaiCaMaps = new List<int>{5, 29, 13, 20, 36, 38, 33};
         private static Boss ThoDaiCa = null;
         private static int ThoDaiCaId = -1;
         private static bool IsThoDaiCaNotify = false;
         private static long ThoDaiCaSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
        #endregion

        #region Chilled
        private static bool IsChilledSpawn = false;
        private static List<int> ChilledMaps = new List<int>{161};
        private static Boss Chilled = null;
        private static int ChilledId = -1;
        private static bool IsChilledNotify = false;
        private static long ChilledSpawnTimeDelay = 600000 + ServerUtils.CurrentTimeMillis();
        #endregion

        #region ClV
        private static bool IsClVSpawn = false;
        private static List<int> ClVMaps = new List<int> { 108, 109, 110 };
        private static Boss ClV = null;
        private static int ClVId = -1;
        private static bool IsClVNotify = false;
        private static long ClVSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
        #endregion

        #region Beerus
        private static bool IsBeerusSpawn = false;
        private static List<int> BeerusMaps = new List<int> { 42, 43, 44 };
        private static Boss Beerus = null;
        private static int BeerusId = -1;
        private static bool IsBeerusNotify = false;
        private static long BeerusSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
        #endregion

        #region Whis
        private static bool IsWhisSpawn = false;
        private static List<int> WhisMaps = new List<int> { 42, 43, 44 };
        private static Boss Whis = null;
        private static int WhisId = -1;
        private static bool IsWhisNotify = false;
        private static long WhisSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
        #endregion

        #region Zamasu
        private static bool IsZamasuSpawn = false;
        private static List<int> ZamasuMaps = new List<int> { 99 };
        private static Boss Zamasu = null;
        private static int ZamasuId = -1;
        private static bool IsZamasuNotify = false;
        private static long ZamasuSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
        #endregion

        #region Hit
        private static bool IsHitSpawn = false;
        private static List<int> HitMaps = new List<int> { 104 };
        private static Boss Hit = null;
        private static int HitId = -1;
        private static bool IsHitNotify = false;
        private static long HitSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
        #endregion

        #region Basil
        private static bool IsBasilSpawn = false;
        private static List<int> BasilMaps = new List<int> { 80 };
        private static Boss Basil = null;
        private static int BasilId = -1;
        private static bool IsBasilNotify = false;
        private static long BasilSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
        #endregion

        #region lavender
        private static bool IslavenderSpawn = false;
        private static List<int> lavenderMaps = new List<int> { 80 };
        private static Boss lavender = null;
        private static int lavenderId = -1;
        private static bool IslavenderNotify = false;
        private static long lavenderSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
        #endregion

        #region bergamo
        private static bool IsbergamoSpawn = false;
        private static List<int> bergamoMaps = new List<int> { 80 };
        private static Boss bergamo = null;
        private static int bergamoId = -1;
        private static bool IsbergamoNotify = false;
        private static long bergamoSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
        #endregion

        

        #region Buu
        private static bool IsBuuSpawn = false;
        private static List<int> BuuMaps = new List<int> { 0 };
        private static Boss Buu = null;
        private static int BuuId = -1;
        private static bool IsBuuNotify = false;
        private static long BuuSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
        #endregion
		
		#region  Boss Android		
        private static List<int> AndroidMaps = new List<int>{93,94};
        private static Boss Android19 = null;
        private static Boss Android20 = null;
        private static bool IsAndroid19Spawn = false;
        private static bool IsAndroid20Spawn = false;
        private static bool IsAndroidNotify = false;
        private static int Android19Id = -1;
        private static int Android20Id = -1;
        private static long AndroidSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
		#endregion
		
		#region  Boss TDST
		
        private static List<int> TDSTMaps = new List<int>{81,82,83};
        private static int CurrentTDSTMapId = 0;
        private static int CurrentTDSTZoneId = 0;


        private static Boss So4 = null;
        private static Boss So3 = null;
        private static Boss So1 = null;
        private static Boss TDT = null;

        private static bool IsSo4Spawn = false;
        private static bool IsSo4Notify = false;
        private static int So4Id = -1;
        private static long So4SpawnTimeDelay = 900000 + ServerUtils.CurrentTimeMillis();

        private static bool IsSo3Spawn = false;
        private static bool IsSo3Notify = false;
        private static int So3Id = -1;

        private static bool IsSo1Spawn = false;
        private static bool IsSo1Notify = false;
        private static int So1Id = -1;

        private static bool IsTDTSpawn = false;
        private static bool IsTDTNotify = false;
        private static int TDTId = -1;

		#endregion
		
		#region  Boss PPKK
        private static List<int> PPKKMaps = new List<int>{97, 98, 99};
        private static Boss Pic = null;
        private static Boss Poc = null;
        private static Boss Kingkong = null;
        private static bool IsPicSpawn = false;
        private static bool IsPocSpawn = false;
        private static bool IsKingkongSpawn = false;
        private static bool IsPPKKNotify = false;
        private static int PicId = -1;
        private static int PocId = -1;
        private static int KingkongId = -1;
        private static long PPKKSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
		#endregion
		
		#region  Boss Android2
        private static List<int> Android2Maps = new List<int>{104};
        private static Boss Android13 = null;
        private static Boss Android14 = null;
        private static Boss Android15 = null;
        private static bool IsAndroid13Spawn = false;
        private static bool IsAndroid14Spawn = false;
        private static bool IsAndroid15Spawn = false;
        private static bool IsAndroid2Notify = false;
        private static int Android13Id = -1;
        private static int Android14Id = -1;
        private static int Android15Id = -1;
        private static long Android2SpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
		#endregion
		
		#region Xen

        private static List<int> XenMaps = new List<int>{ 99 };
        private static Boss Xen1 = null;
        private static Boss Xen2 = null;
        private static Boss Xen3 = null;
        private static Boss Xen4 = null;
        private static Boss Xen5 = null;
        private static Boss Xen6 = null;
        private static Boss Xen7 = null;
        private static bool IsXen1Spawn = false;
        private static bool IsXen2Spawn = false;
        private static bool IsXen3Spawn = false;
        private static bool IsXen4Spawn = false;
        private static bool IsXen5Spawn = false;
        private static bool IsXen6Spawn = false;
        private static bool IsXen7Spawn = false;
        private static bool IsXenNotify = false;
        private static int Xen1Id = -1;
        private static int Xen2Id = -1;
        private static int Xen3Id = -1;
        private static int Xen4Id = -1;
        private static int Xen5Id = -1;
        private static int Xen6Id = -1;
        private static int Xen7Id = -1;
        private static long XenSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
        #endregion
		
		#region SBH
        private static bool IsSBHSpawn = false;
        private static List<int> SBHMaps = new List<int> { 103 };
        private static Boss SBH = null;
        private static int SBHId = -1;
        private static bool IsSBHNotify = false;
        private static long SBHSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
        #endregion
		
		#region Tau77
        private static bool IsTau77Spawn = false;
        private static List<int> Tau77Maps = new List<int> { 20 };
        private static Boss Tau77 = null;
        private static int Tau77Id = -1;
        private static bool IsTau77Notify = false;
        private static long Tau77SpawnTimeDelay = 20000 + ServerUtils.CurrentTimeMillis();
        #endregion
		
		#region Bojack
        private static bool IsBojackSpawn = false;
        private static List<int> BojackMaps = new List<int> { 31, 32 };
        private static Boss Bojack = null;
        private static int BojackId = -1;
        private static bool IsBojackNotify = false;
        private static long BojackSpawnTimeDelay = 5000000 + ServerUtils.CurrentTimeMillis();
        #endregion
		
		#region Kuku
        private static bool IsKukuSpawn = false;
        private static List<int> KukuMaps = new List<int> { 70 };
        private static Boss Kuku = null;
        private static int KukuId = -1;
        private static bool IsKukuNotify = false;
        private static long KukuSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
        #endregion
		
		#region MDD
        private static bool IsMDDSpawn = false;
        private static List<int> MDDMaps = new List<int> { 74 };
        private static Boss MDD = null;
        private static int MDDId = -1;
        private static bool IsMDDNotify = false;
        private static long MDDSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
        #endregion
		
		#region Rambo
        private static bool IsRamboSpawn = false;
        private static List<int> RamboMaps = new List<int> { 77 };
        private static Boss Rambo = null;
        private static int RamboId = -1;
        private static bool IsRamboNotify = false;
        private static long RamboSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
        #endregion
		#region Boss NgoKhong
         private static bool IsNgoKhongSpawn = false;
         private static List<int> NgoKhongMaps = new List<int>{105,106};
         private static Boss NgoKhong = null;
         private static int NgoKhongId = -1;
         private static bool IsNgoKhongNotify = false;
         private static long NgoKhongSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
        #endregion

        public static BossRunTime Gi()
        {
            return Instance ??= new BossRunTime();
        }

        public BossRunTime()
        {
            
        }

        public void BossDie(int bossId)
        {
            try
            {
                if (bossId == superBrolyId && IsSuperBrolySpawn)
                {
                    superBroly = null;
                    IsSuperBrolySpawn = false;
                    superBrolyId = -1;
                    superBrolySpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == blackGokuId && IsBlackGokuSpawn)
                {
                    blackGoku = null;
                    IsBlackGokuSpawn = false;
                    blackGokuId = -1;
                    blackGokuSpawnTimeDelay = 150000 + ServerUtils.CurrentTimeMillis();
                    if (!IsSuperBlackGokuSpawn)
                    {
                        SpawnSuperBlackGoku();
                    }
                }
                else if (bossId == superBlackGokuId && IsSuperBlackGokuSpawn)
                {
                    superBlackGoku = null;
                    IsSuperBlackGokuSpawn = false;
                    superBlackGokuId = -1;
                    blackGokuSpawnTimeDelay = 150000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == fide01Id && IsFide01Spawn)
                {
                    fide01 = null;
                    IsFide01Spawn = false;
                    fide01Id = -1;
                    fide01SpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                    if (!IsFide02Spawn)
                    {
                        SpawnFideBoss(2);
                    }
                }
                else if (bossId == fide02Id && IsFide02Spawn)
                {
                    fide02 = null;
                    IsFide02Spawn = false;
                    fide02Id = -1;
                    fide01SpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                    if (!IsFide03Spawn)
                    {
                        SpawnFideBoss(3);
                    }
                }
                else if (bossId == fide03Id && IsFide03Spawn)
                {
                    fide03 = null;
                    IsFide03Spawn = false;
                    fide03Id = -1;
                    fide01SpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                
                else if (bossId == xbh01Id && IsXbh01Spawn)
                {
                    xbh01 = null;
                    IsXbh01Spawn = false;
                    xbh01Id = -1;
                    xbhSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == xbh02Id && IsXbh02Spawn)
                {
                    xbh02 = null;
                    IsXbh02Spawn = false;
                    xbh02Id = -1;
                    xbhSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == xht03Id && IsXht03Spawn)
                {
                    xht03 = null;
                    IsXht03Spawn = false;
                    xht03Id = -1;
                    xbhSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == cooler01Id && IsCooler01Spawn)
                {
                    cooler01 = null;
                    IsCooler01Spawn = false;
                    cooler01Id = -1;
                    cooler01SpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                    if (!IsCooler02Spawn)
                    {
                        SpawnCoolerBoss(2);
                    }
                }
                else if (bossId == cooler02Id && IsCooler02Spawn)
                {
                    cooler02 = null;
                    IsCooler02Spawn = false;
                    cooler02Id = -1;
                    cooler01SpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                } 
                // else if (bossId == ThoPheCoId && IsThoPheCoSpawn)
                // {
                //     ThoPheCo = null;
                //     IsThoPheCoSpawn = false;
                //     ThoPheCoId = -1;
                //     ThoPheCoSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                // }
                 else if (bossId == ThoDaiCaId && IsThoDaiCaSpawn)
                 {
                     ThoDaiCa = null;
                     IsThoDaiCaSpawn = false;
                     ThoDaiCaId = -1;
                     ThoDaiCaSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                 }
                else if (bossId == ChilledId && IsChilledSpawn)
                {
                    Chilled = null;
                    IsChilledSpawn = false;
                    ChilledId = -1;
                    ChilledSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == thoxanhId && IsthoxanhSpawn)
                {
                    thoxanh = null;
                    IsthoxanhSpawn = false;
                    thoxanhId = -1;
                    thoxanhSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == thodoId && IsthodoSpawn)
                {
                    thodo = null;
                    IsthodoSpawn = false;
                    thodoId = -1;
                    thodoSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == thodenId && IsthodenSpawn)
                {
                    thoden = null;
                    IsthodenSpawn = false;
                    thodenId = -1;
                    thodenSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == BasilId && IsBasilSpawn)
                {
                    Basil = null;
                    IsBasilSpawn = false;
                    BasilId = -1;
                    BasilSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == lavenderId && IslavenderSpawn)
                {
                    lavender = null;
                    IslavenderSpawn = false;
                    lavenderId = -1;
                    lavenderSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == bergamoId && IsbergamoSpawn)
                {
                    bergamo = null;
                    IsbergamoSpawn = false;
                    bergamoId = -1;
                    bergamoSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == ClVId && IsClVSpawn)
                {
                    ClV = null;
                    IsClVSpawn = false;
                    ClVId = -1;
                    ClVSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == BeerusId && IsBeerusSpawn)
                {
                    Beerus = null;
                    IsBeerusSpawn = false;
                    BeerusId = -1;
                    BeerusSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == ZamasuId && IsZamasuSpawn)
                {
                    Zamasu = null;
                    IsZamasuSpawn = false;
                    ZamasuId = -1;
                    ZamasuSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == HitId && IsHitSpawn)
                {
                    Hit = null;
                    IsHitSpawn = false;
                    HitId = -1;
                    HitSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == BuuId && IsBuuSpawn)
                {
                    Buu = null;
                    IsBuuSpawn = false;
                    BuuId = -1;
                    BuuSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == Android19Id && IsAndroid19Spawn)
                {
                    Android19 = null;
                    IsAndroid19Spawn = false;
                    Android19Id = -1;
                    AndroidSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == Android20Id && IsAndroid20Spawn)
                {
                    Android20 = null;
                    IsAndroid20Spawn = false;
                    Android20Id = -1;
                    AndroidSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == So4Id && IsSo4Spawn)
                {
                    So4 = null;
                    IsSo4Spawn = false;
                    So4Id = -1;
                    So4SpawnTimeDelay = 900000 + ServerUtils.CurrentTimeMillis();
                    if (!IsSo3Spawn)
                    {
                        SpawnTDSTBoss(2);
                    }
                }
                else if (bossId == So3Id && IsSo3Spawn)
                {
                    So3 = null;
                    IsSo3Spawn = false;
                    So3Id = -1;
                    So4SpawnTimeDelay = 900000 + ServerUtils.CurrentTimeMillis();
                    if (!IsSo1Spawn)
                    {
                        SpawnTDSTBoss(3);
                    }
                }
				else if (bossId == So1Id && IsSo1Spawn)
                {
                    So1 = null;
                    IsSo1Spawn = false;
                    So1Id = -1;
                    So4SpawnTimeDelay = 900000 + ServerUtils.CurrentTimeMillis();
                    if (!IsTDTSpawn)
                    {
                        SpawnTDSTBoss(4);
                    }
                }
                else if (bossId == TDTId && IsTDTSpawn)
                {
                    TDT = null;
                    IsTDTSpawn = false;
                    TDTId = -1;
                    So4SpawnTimeDelay = 900000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == Android13Id && IsAndroid13Spawn)
                {
                    Android13 = null;
                    IsAndroid13Spawn = false;
                    Android13Id = -1;
                    AndroidSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == Android14Id && IsAndroid14Spawn)
                {
                    Android14 = null;
                    IsAndroid14Spawn = false;
                    Android14Id = -1;
                    AndroidSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == Android15Id && IsAndroid15Spawn)
                {
                    Android15 = null;
                    IsAndroid15Spawn = false;
                    Android15Id = -1;
                    AndroidSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == PicId && IsPicSpawn)
                {
                    Pic = null;
                    IsPicSpawn = false;
                    PicId = -1;
                    PPKKSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == PocId && IsPocSpawn)
                {
                    Poc = null;
                    IsPocSpawn = false;
                    PocId = -1;
                    PPKKSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == KingkongId && IsKingkongSpawn)
                {
                    Kingkong = null;
                    IsKingkongSpawn = false;
                    KingkongId = -1;
                    PPKKSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == Xen1Id && IsXen1Spawn)
                {
                    Xen1 = null;
                    IsXen1Spawn = false;
                    Xen1Id = -1;
                    XenSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == Xen2Id && IsXen2Spawn)
                {
                    Xen2 = null;
                    IsXen2Spawn = false;
                    Xen2Id = -1;
                    XenSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == Xen3Id && IsXen3Spawn)
                {
                    Xen3 = null;
                    IsXen3Spawn = false;
                    Xen3Id = -1;
                    XenSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == Xen4Id && IsXen4Spawn)
                {
                    Xen4 = null;
                    IsXen4Spawn = false;
                    Xen4Id = -1;
                    XenSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == Xen5Id && IsXen5Spawn)
                {
                    Xen5 = null;
                    IsXen5Spawn = false;
                    Xen5Id = -1;
                    XenSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == Xen6Id && IsXen6Spawn)
                {
                    Xen6 = null;
                    IsXen6Spawn = false;
                    Xen6Id = -1;
                    XenSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == Xen7Id && IsXen7Spawn)
                {
                    Xen7 = null;
                    IsXen7Spawn = false;
                    Xen7Id = -1;
                    XenSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == SBHId && IsSBHSpawn)
                {
                    SBH = null;
                    IsSBHSpawn = false;
                    SBHId = -1;
                    SBHSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == BojackId && IsBojackSpawn)
                {
                    Bojack = null;
                    IsBojackSpawn = false;
                    BojackId = -1;
                    BojackSpawnTimeDelay = 120000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == Tau77Id && IsTau77Spawn)
                {
                    Tau77 = null;
                    IsTau77Spawn = false;
                    Tau77Id = -1;
                    Tau77SpawnTimeDelay = 60000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == KukuId && IsKukuSpawn)
                {
                    Kuku = null;
                    IsKukuSpawn = false;
                    KukuId = -1;
                    KukuSpawnTimeDelay = 900000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == MDDId && IsMDDSpawn)
                {
                    MDD = null;
                    IsMDDSpawn = false;
                    MDDId = -1;
                    MDDSpawnTimeDelay = 900000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == RamboId && IsRamboSpawn)
                {
                    Rambo = null;
                    IsRamboSpawn = false;
                    RamboId = -1;
                    RamboSpawnTimeDelay = 900000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == NgoKhongId && IsNgoKhongSpawn)
                 {
                     NgoKhong = null;
                     IsNgoKhongSpawn = false;
                     NgoKhongId = -1;
                     NgoKhongSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                 }
            }
            catch (Exception e)
            {
                Server.Gi().Logger.Error($"Error BossDie in BossRunTime.cs: {e.Message} \n {e.StackTrace}", e);
            }
            
        }

        public void StartBossRunTime()
        {
            new Thread(new ThreadStart(() =>
            {
                while (Server.Gi().IsRunning)
                {
                    var now = ServerUtils.TimeNow();
                    try
                    {
                        #region Super Broly

                        if ((superBrolySpawnTimeDelay < ServerUtils.CurrentTimeMillis())) 
                        {
                            superBrolySpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                            if (!IsSuperBrolySpawn)
                            {
                                IsSuperBrolySpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(SuperBrolyMaps.Count);
                                int sbRandomMap = SuperBrolyMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    superBroly = new Boss();
                                    superBroly.CreateBoss(DataCache.BOSS_SUPER_BROLY_TYPE);
                                    superBroly.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(superBroly);
                                    superBrolyId = superBroly.Id;
                                    IsSuperBrolySpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Super Broly " + superBrolyId + " vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                                    Server.Gi().Logger.Print("Boss Spawn Broly...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                    IsSuperBrolyNotify = true;
                                }
                            }
                            else if (!IsSuperBrolyNotify && superBroly != null && superBrolyId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Super Broly " + superBrolyId + " vừa xuất hiện tại " + superBroly.Zone.Map.TileMap.Name));
                                IsSuperBrolyNotify = true;
                            }
                            // Get Random Map
                        } 
                        else 
                        {
                            IsSuperBrolyNotify = false;
                        }

                        #endregion

                        #region Black Goku

                        if ((now.Hour == 7 || now.Hour == 8 || now.Hour == 10 ||now.Hour == 12 || now.Hour == 13 || now.Hour == 14 || now.Hour == 15 ||now.Hour == 19 || now.Hour == 22 || now.Hour == 1 || now.Hour == 3 || now.Hour == 4) && (blackGokuSpawnTimeDelay < ServerUtils.CurrentTimeMillis())) 
                        {
                            blackGokuSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                            if (!IsBlackGokuSpawn && !IsSuperBlackGokuSpawn) 
                            {
                                IsBlackGokuSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(BlackGokuMaps.Count);
                                int sbRandomMap = BlackGokuMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    blackGoku = new Boss();
                                    blackGoku.CreateBoss(DataCache.BOSS_BLACK_GOKU_TYPE);
                                    blackGoku.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(blackGoku);
                                    blackGokuId = blackGoku.Id;
                                    IsBlackGokuSpawn = true;
                                    IsBlackGokuNotify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Black Goku " + blackGokuId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print("Boss Spawn Black Goku...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                }
                                // Get Random Map
                            }
                            else if(!IsBlackGokuNotify && IsBlackGokuSpawn && blackGoku != null && blackGokuId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Black Goku " + blackGokuId + " vừa xuất hiện tại " + blackGoku.Zone.Map.TileMap.Name));
                                IsBlackGokuNotify = true;
                            }
                            else if(!IsSuperBlackGokuNotify && IsSuperBlackGokuSpawn && superBlackGoku != null && superBlackGokuId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Super Black Goku " + superBlackGokuId + " vừa xuất hiện tại " + superBlackGoku.Zone.Map.TileMap.Name));
                                IsSuperBlackGokuNotify = true;
                            }
                        }
                        else 
                        {
                            IsBlackGokuNotify = false;
                            IsSuperBlackGokuNotify = false;
                        }

                        #endregion
						
                        
                        #region Fide 01 02 03
                        if ((now.Hour == 6 || now.Hour == 8 || now.Hour == 10|| now.Hour == 12|| now.Hour == 14||now.Hour == 16 || now.Hour == 18 || now.Hour == 20 || now.Hour == 22 || now.Hour == 2 || now.Hour == 4) && (fide01SpawnTimeDelay < ServerUtils.CurrentTimeMillis())) 
                        {
                            fide01SpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                            if (!IsFide01Spawn && !IsFide02Spawn && !IsFide03Spawn)
                            {
                                IsFide01Spawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(FideMaps.Count);
                                int sbRandomMap = FideMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                CurrentFideMapId = sbRandomMap;
                                CurrentFideZoneId = sbRandomZoneNum;
                                if (zone != null)
                                {
                                    fide01 = new Boss();
                                    fide01.CreateBoss(DataCache.BOSS_FIDE_01_TYPE);
                                    fide01.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(fide01);
                                    fide01Id = fide01.Id;
                                    IsFide01Spawn = true;
                                    IsFide01Notify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Fide 01 " + fide01Id + " vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                                    Server.Gi().Logger.Print("Fide...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                }
                            }
                            else if (!IsFide01Notify && IsFide01Spawn && fide01Id != -1 && fide01 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Fide 01 " + fide01Id + " vừa xuất hiện tại " + fide01.Zone.Map.TileMap.Name));
                                IsFide01Notify = true;
                            }
                            else if (!IsFide02Notify && IsFide02Spawn && fide02Id != -1 && fide02 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Fide 02 "+fide02Id+" vừa xuất hiện tại " + fide02.Zone.Map.TileMap.Name));
                                IsFide02Notify = true;
                            }
                            else if (!IsFide03Notify && IsFide03Spawn && fide03Id != -1 && fide03 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Fide 03 "+fide03Id+" vừa xuất hiện tại " + fide03.Zone.Map.TileMap.Name));
                                IsFide03Notify = true;
                            }
                            // Get Random Map
                        } 
                        else 
                        {
                            IsFide01Notify = false;
                            IsFide02Notify = false;
                            IsFide03Notify = false;
                        }
                        #endregion

                        #region Xên bọ hung

                        if ((now.Hour == 6 || now.Hour == 8 ||now.Hour == 11 ||now.Hour == 12 ||now.Hour == 15 ||now.Hour == 16 ||now.Hour == 19 || now.Hour == 22 || now.Hour == 1 || now.Hour == 3) && (xbhSpawnTimeDelay < ServerUtils.CurrentTimeMillis())) 
                        {
                            xbhSpawnTimeDelay = 510000 + ServerUtils.CurrentTimeMillis();
                            if (!IsXbh01Spawn && !IsXbh02Spawn && !IsXht03Spawn)
                            {
                                
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(XBHMaps.Count);
                                int sbRandomMap = XBHMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    xbh01 = new Boss();
                                    xbh01.CreateBoss(DataCache.BOSS_XEN_01_TYPE);
                                    xbh01.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(xbh01);
                                    xbh01Id = xbh01.Id;

                                    xbh02 = new Boss();
                                    xbh02.CreateBoss(DataCache.BOSS_XEN_02_TYPE);
                                    xbh02.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(xbh02);
                                    xbh02Id = xbh02.Id;

                                    xht03 = new Boss();
                                    xht03.CreateBoss(DataCache.BOSS_XEN_HT_TYPE);
                                    xht03.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(xht03);
                                    xht03Id = xht03.Id;

                                    IsXbh01Spawn = true;
                                    IsXbh02Spawn = true;
                                    IsXht03Spawn = true;
                                    IsXbhNotify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat(" Xên Bọ Hung vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                                    Server.Gi().Logger.Print(" Xên Bọ Hung..: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                }
                            }
                            else if (!IsXbhNotify)
                            {
                                if (xbh01 != null && xbh01Id != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Xên Bọ Hung 1 vừa xuất hiện tại " + xbh01.Zone.Map.TileMap.Name));
                                }
                                else if (xbh02 != null && xbh02Id != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Xên Bọ Hung 2 vừa xuất hiện tại " + xbh02.Zone.Map.TileMap.Name));
                                }
                                else if (xht03 != null && xht03Id != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Xên Hoan Thien vừa xuất hiện tại " + xht03.Zone.Map.TileMap.Name));
                                }
                                IsXbhNotify = true;
                            }
                            // Get Random Map
                        } 
                        else 
                        {
                            IsXbhNotify = false;
                        }


                        #endregion

                        #region Cooler
                        if ((now.Hour == 23 || now.Hour == 0 ||now.Hour == 1 || now.Hour == 11 || now.Hour == 12 || now.Hour == 13) && (cooler01SpawnTimeDelay < ServerUtils.CurrentTimeMillis())) 
                        {
                            cooler01SpawnTimeDelay = 800000 + ServerUtils.CurrentTimeMillis();
                            if (!IsCooler01Spawn && !IsCooler02Spawn)
                            {
                                IsCooler01Spawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(CoolerMaps.Count);
                                int sbRandomMap = CoolerMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                CurrentCoolerMapId = sbRandomMap;
                                CurrentCoolerZoneId = sbRandomZoneNum;
                                if (zone != null)
                                {
                                    cooler01 = new Boss();
                                    cooler01.CreateBoss(DataCache.BOSS_COOLER_01_TYPE);
                                    cooler01.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(cooler01);
                                    cooler01Id = cooler01.Id;
                                    IsCooler01Spawn = true;
                                    IsCooler01Notify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Cooler 01 " + cooler01Id + " vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                                    Server.Gi().Logger.Print("Cooler...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                }
                            }
                            else if (!IsCooler01Notify && IsCooler01Spawn && cooler01Id != -1 && cooler01 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Cooler 01 " + cooler01Id + " vừa xuất hiện tại " + cooler01.Zone.Map.TileMap.Name));
                                IsCooler01Notify = true;
                            }
                            else if (!IsCooler02Notify && IsCooler02Spawn && cooler02Id != -1 && cooler02 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Cooler 02 "+cooler02Id+" vừa xuất hiện tại " + cooler02.Zone.Map.TileMap.Name));
                                IsCooler02Notify = true;
                            }
                            // Get Random Map
                        } 
                        else 
                        {
                            IsCooler01Notify = false;
                            IsCooler02Notify = false;
                        }
                        #endregion

                        #region Thỏ Phê Cỏ

                        // if ((ThoPheCoSpawnTimeDelay < ServerUtils.CurrentTimeMillis())) 
                        // {
                        //     ThoPheCoSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                        //     if (!IsThoPheCoSpawn)
                        //     {
                        //         var randChar = ClientManager.Gi().GetRandomCharacter();
                        //         if (randChar != null) 
                        //         {
                        //             var zone = randChar.Zone;
                        //             Server.Gi().Logger.Print("Boss Tho Phe Co Tim nguoi: " + randChar.Name);
                        //             if (zone != null)
                        //             {
                        //                 ThoPheCo = new Boss();
                        //                 ThoPheCo.CreateBoss(DataCache.BOSS_THO_PHE_CO_TYPE, randChar.InfoChar.X, randChar.InfoChar.Y);
                        //                 ThoPheCo.CharacterHandler.SetUpInfo();
                        //                 zone.ZoneHandler.AddBoss(ThoPheCo);
                        //                 ThoPheCoId = ThoPheCo.Id;
                        //                 IsThoPheCoSpawn = true;
                        //                 Server.Gi().Logger.Print("Boss Thỏ Phê Cỏ...: Map " + zone.Map.Id + " Zone: " + zone.Id + " Name: " + zone.Map.TileMap.Name);
                        //                 ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Thỏ Phê Cỏ " + ThoPheCoId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                        //                 IsThoPheCoNotify = true;
                        //             }
                        //         }
                        //     }
                        //     else if (!IsThoPheCoNotify && ThoPheCo != null && ThoPheCoId != -1)
                        //     {
                        //         // if (ThoPheCo.CharacterHandler != null)
                        //         // {
                        //         //     ThoPheCo.CharacterHandler.Update();
                        //         // }
                        //         // ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Thỏ Phê Cỏ " + ThoPheCoId + " vừa xuất hiện tại " + ThoPheCo.Zone.Map.TileMap.Name));
                        //         IsThoPheCoNotify = true;
                        //     }
                        //     // Get Random Map
                        // } 
                        // else 
                        // {
                        //     IsThoPheCoNotify = false;
                        // }

                        #endregion

                        #region Thỏ Đại Ca

                         if ((ThoDaiCaSpawnTimeDelay < ServerUtils.CurrentTimeMillis())) 
                         {
                             ThoDaiCaSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                             if (!IsThoDaiCaSpawn)
                             {
                                 IsThoDaiCaSpawn = true;
                                 int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                 int sbRandomMapIndex = ServerUtils.RandomNumber(ThoDaiCaMaps.Count);
                                 int sbRandomMap = ThoDaiCaMaps[sbRandomMapIndex];
                                 var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                 if (zone != null)
                                 {
                                     ThoDaiCa = new Boss();
                                     ThoDaiCa.CreateBoss(DataCache.BOSS_THO_DAI_CA_TYPE);
                                     ThoDaiCa.CharacterHandler.SetUpInfo();
                                     zone.ZoneHandler.AddBoss(ThoDaiCa);
                                     ThoDaiCaId = ThoDaiCa.Id;
                                     IsThoDaiCaSpawn = true;
                                     ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Thỏ Đại Ca " + ThoDaiCaId + " vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                                     IsThoDaiCaNotify = true;
                                 }
                             }
                             else if (!IsThoDaiCaNotify && ThoDaiCa != null && ThoDaiCaId != -1)
                             {
                                 ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Thỏ Đại Ca " + ThoDaiCaId + " vừa xuất hiện tại " + ThoDaiCa.Zone.Map.TileMap.Name));
                                 IsThoDaiCaNotify = true;
                             }
                             // Get Random Map
                         } 
                         else 
                         {
                             IsThoDaiCaNotify = false;
                         }

                        #endregion

                        #region Chilled

                         if ((ChilledSpawnTimeDelay < ServerUtils.CurrentTimeMillis())) 
                         {
                             ChilledSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                             if (!IsChilledSpawn)
                             {
                                 IsChilledSpawn = true;
                                 int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                 int sbRandomMapIndex = ServerUtils.RandomNumber(ChilledMaps.Count);
                                 int sbRandomMap = ChilledMaps[sbRandomMapIndex];
                                 var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                 if (zone != null)
                                 {
                                     Chilled = new Boss();
                                     Chilled.CreateBoss(DataCache.BOSS_CHILLED_TYPE);
                                     Chilled.CharacterHandler.SetUpInfo();
                                     zone.ZoneHandler.AddBoss(Chilled);
                                     ChilledId = Chilled.Id;
                                     IsChilledSpawn = true;
                                     ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Chilled " + ChilledId + " vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                                     IsChilledNotify = true;
                                 }
                             }
                             else if (!IsChilledNotify && Chilled != null && ChilledId != -1)
                             {
                                 ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Chilled " + ChilledId + " vừa xuất hiện tại " + Chilled.Zone.Map.TileMap.Name));
                                 IsChilledNotify = true;
                             }
                             // Get Random Map
                         } 
                         else 
                         {
                             IsChilledNotify = false;
                         }

                        #endregion

                        #region thoxanh

                        if ((thoxanhSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            thoxanhSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                            if (!IsthoxanhSpawn)
                            {
                                IsthoxanhSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(thoxanhMaps.Count);
                                int sbRandomMap = thoxanhMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    thoxanh = new Boss();
                                    thoxanh.CreateBoss(DataCache.BOSS_THOXANH_TYPE);
                                    thoxanh.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(thoxanh);
                                    thoxanhId = thoxanh.Id;
                                    IsthoxanhSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Thỏ bulma hồng " + thoxanhId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    IsthoxanhNotify = true;
                                }
                            }
                            else if (!IsthoxanhNotify && thoxanh != null && thoxanhId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Thỏ bulma hồng " + thoxanhId + " vừa xuất hiện tại " + thoxanh.Zone.Map.TileMap.Name));
                                IsthoxanhNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsthoxanhNotify = false;
                        }

                        #endregion

                        #region thodo

                        if ((thodoSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            thodoSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                            if (!IsthodoSpawn)
                            {
                                IsthodoSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(thodoMaps.Count);
                                int sbRandomMap = thodoMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    thodo = new Boss();
                                    thodo.CreateBoss(DataCache.BOSS_THODO_TYPE);
                                    thodo.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(thodo);
                                    thodoId = thodo.Id;
                                    IsthodoSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Thỏ bulma đỏ " + thodoId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    IsthodoNotify = true;
                                }
                            }
                            else if (!IsthodoNotify && thodo != null && thodoId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Thỏ bulma đỏ " + thodoId + " vừa xuất hiện tại " + thodo.Zone.Map.TileMap.Name));
                                IsthodoNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsthodoNotify = false;
                        }

                        #endregion

                        #region thoden

                        if ((thodenSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            thodenSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                            if (!IsthodenSpawn)
                            {
                                IsthodenSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(thodenMaps.Count);
                                int sbRandomMap = thodenMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    thoden = new Boss();
                                    thoden.CreateBoss(DataCache.BOSS_THODEN_TYPE);
                                    thoden.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(thoden);
                                    thodenId = thoden.Id;
                                    IsthodenSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Thỏ đen số 18 " + thodenId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    IsthodenNotify = true;
                                }
                            }
                            else if (!IsthodenNotify && thoden != null && thodenId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Thỏ đen số 18 " + thodenId + " vừa xuất hiện tại " + thoden.Zone.Map.TileMap.Name));
                                IsthodenNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsthodenNotify = false;
                        }

                        #endregion

                        #region Cooler Vàng

                        if ((ClVSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            ClVSpawnTimeDelay = 600000 + ServerUtils.CurrentTimeMillis();
                            if (!IsClVSpawn)
                            {
                                IsClVSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(ClVMaps.Count);
                                int sbRandomMap = ClVMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    ClV = new Boss();
                                    ClV.CreateBoss(DataCache.BOSS_COLER_VANG_TYPE);
                                    ClV.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(ClV);
                                    ClVId = ClV.Id;
                                    IsClVSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Cooler Vàng " + ClVId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print("Boss Spawn Cooler Vàng...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                    IsClVNotify = true;
                                }
                            }
                            else if (!IsClVNotify && ClV != null && ClVId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Cooler Vàng " + ClVId + " vừa xuất hiện tại " + ClV.Zone.Map.TileMap.Name));
                                IsClVNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsClVNotify = false;
                        }


                        #endregion

                        #region Beerus

                        if ((BeerusSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            BeerusSpawnTimeDelay = 700000 + ServerUtils.CurrentTimeMillis();
                            if (!IsBeerusSpawn)
                            {
                                IsBeerusSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(BeerusMaps.Count);
                                int sbRandomMap = BeerusMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    Beerus = new Boss();
                                    Beerus.CreateBoss(DataCache.BOSS_BEERUS_TYPE);
                                    Beerus.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Beerus);
                                    BeerusId = Beerus.Id;
                                    IsBeerusSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Beerus " + BeerusId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print("Boss Spawn Beerus...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                    IsBeerusNotify = true;
                                }
                            }
                            else if (!IsBeerusNotify && Beerus != null && BeerusId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Beerus " + BeerusId + " vừa xuất hiện tại " + Beerus.Zone.Map.TileMap.Name));
                                IsBeerusNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsBeerusNotify = false;
                        }


                        #endregion

                        #region Zamasu

                        if ((ZamasuSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            ZamasuSpawnTimeDelay = 800000 + ServerUtils.CurrentTimeMillis();
                            if (!IsZamasuSpawn)
                            {
                                IsZamasuSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(ZamasuMaps.Count);
                                int sbRandomMap = ZamasuMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    Zamasu = new Boss();
                                    Zamasu.CreateBoss(DataCache.BOSS_ZAMASU_TYPE);
                                    Zamasu.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Zamasu);
                                    ZamasuId = Zamasu.Id;
                                    IsZamasuSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Zamasu " + ZamasuId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print("Boss Spawn Zamasu...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                    IsZamasuNotify = true;
                                }
                            }
                            else if (!IsZamasuNotify && Zamasu != null && ZamasuId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Zamasu " + ZamasuId + " vừa xuất hiện tại " + Zamasu.Zone.Map.TileMap.Name));
                                IsZamasuNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsZamasuNotify = false;
                        }


                        #endregion

                        #region Hit

                        if ((HitSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            HitSpawnTimeDelay = 900000 + ServerUtils.CurrentTimeMillis();
                            if (!IsHitSpawn)
                            {
                                IsHitSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(HitMaps.Count);
                                int sbRandomMap = HitMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    Hit = new Boss();
                                    Hit.CreateBoss(DataCache.BOSS_HIT_TYPE);
                                    Hit.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Hit);
                                    HitId = Hit.Id;
                                    IsHitSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Hit " + HitId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print("Boss Spawn Hit...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                    IsHitNotify = true;
                                }
                            }
                            else if (!IsHitNotify && Hit != null && HitId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Hit " + HitId + " vừa xuất hiện tại " + Hit.Zone.Map.TileMap.Name));
                                IsHitNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsHitNotify = false;
                        }


                        #endregion

                        #region Basil

                        if ((BasilSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            BasilSpawnTimeDelay = 900000 + ServerUtils.CurrentTimeMillis();
                            if (!IsBasilSpawn)
                            {
                                IsBasilSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(BasilMaps.Count);
                                int sbRandomMap = BasilMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    Basil = new Boss();
                                    Basil.CreateBoss(DataCache.BOSS_BASIL_TYPE);
                                    Basil.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Basil);
                                    BasilId = Basil.Id;
                                    IsBasilSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Basil " + BasilId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print("Boss Spawn Basil...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                    IsBasilNotify = true;
                                }
                            }
                            else if (!IsBasilNotify && Basil != null && BasilId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Basil " + BasilId + " vừa xuất hiện tại " + Basil.Zone.Map.TileMap.Name));
                                IsBasilNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsBasilNotify = false;
                        }


                        #endregion

                        #region lavender

                        if ((lavenderSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            lavenderSpawnTimeDelay = 900000 + ServerUtils.CurrentTimeMillis();
                            if (!IslavenderSpawn)
                            {
                                IslavenderSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(lavenderMaps.Count);
                                int sbRandomMap = lavenderMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    lavender = new Boss();
                                    lavender.CreateBoss(DataCache.BOSS_LAVENDER_TYPE);
                                    lavender.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(lavender);
                                    lavenderId = lavender.Id;
                                    IslavenderSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS lavender " + lavenderId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print("Boss Spawn lavender...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                    IslavenderNotify = true;
                                }
                            }
                            else if (!IslavenderNotify && lavender != null && lavenderId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS lavender " + lavenderId + " vừa xuất hiện tại " + lavender.Zone.Map.TileMap.Name));
                                IslavenderNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IslavenderNotify = false;
                        }


                        #endregion

                        #region bergamo

                        if ((bergamoSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            bergamoSpawnTimeDelay = 900000 + ServerUtils.CurrentTimeMillis();
                            if (!IsbergamoSpawn)
                            {
                                IsbergamoSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(bergamoMaps.Count);
                                int sbRandomMap = bergamoMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    bergamo = new Boss();
                                    bergamo.CreateBoss(DataCache.BOSS_BERGAMO_TYPE);
                                    bergamo.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(bergamo);
                                    bergamoId = bergamo.Id;
                                    IsbergamoSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS bergamo " + bergamoId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print("Boss Spawn bergamo...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                    IsbergamoNotify = true;
                                }
                            }
                            else if (!IsbergamoNotify && bergamo != null && bergamoId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS bergamo " + bergamoId + " vừa xuất hiện tại " + bergamo.Zone.Map.TileMap.Name));
                                IsbergamoNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsbergamoNotify = false;
                        }


                        #endregion

                        #region Buu

                        if ((BuuSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            BuuSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                            if (!IsBuuSpawn)
                            {
                                IsBuuSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(BuuMaps.Count);
                                int sbRandomMap = BuuMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    Buu = new Boss();
                                    Buu.CreateBoss(DataCache.BOSS_BUU_TYPE);
                                    Buu.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Buu);
                                    BuuId = Buu.Id;
                                    IsBuuSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Buu " + BuuId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    IsBuuNotify = true;
                                }
                            }
                            else if (!IsBuuNotify && Buu != null && BuuId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Buu " + BuuId + " vừa xuất hiện tại " + Buu.Zone.Map.TileMap.Name));
                                IsBuuNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsBuuNotify = false;
                        }

                        #endregion

                        #region Whis

                        if ((WhisSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            WhisSpawnTimeDelay = 700000 + ServerUtils.CurrentTimeMillis();
                            if (!IsWhisSpawn)
                            {
                                IsWhisSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(WhisMaps.Count);
                                int sbRandomMap = WhisMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    Whis = new Boss();
                                    Whis.CreateBoss(DataCache.BOSS_WHIS_TYPE);
                                    Whis.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Whis);
                                    WhisId = Whis.Id;
                                    IsWhisSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Whis " + WhisId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print("Boss Spawn Whis...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                    IsWhisNotify = true;
                                }
                            }
                            else if (!IsWhisNotify && Whis != null && WhisId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Whis " + WhisId + " vừa xuất hiện tại " + Whis.Zone.Map.TileMap.Name));
                                IsWhisNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsWhisNotify = false;
                        }


                        #endregion
						
						#region Android
						if ((AndroidSpawnTimeDelay < ServerUtils.CurrentTimeMillis())) 
                        {
                            AndroidSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                            if (!IsAndroid19Spawn && !IsAndroid20Spawn)
                            {
                                
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(AndroidMaps.Count);
                                int sbRandomMap = AndroidMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    Android19 = new Boss();
                                    Android19.CreateBoss(DataCache.BOSS_ANDROID_19_TYPE);
                                    Android19.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Android19);
                                    Android19Id = Android19.Id;

                                    Android20 = new Boss();
                                    Android20.CreateBoss(DataCache.BOSS_ANDROID_20_TYPE);
                                    Android20.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Android20);
                                    Android20Id = Android20.Id;

                                    IsAndroid19Spawn = true;
                                    IsAndroid20Spawn = true;
                                    IsAndroidNotify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Android 19 và 20 vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                                    Server.Gi().Logger.Print("Android 19 và 20..: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                }
                            }
                            else if (!IsAndroidNotify)
                            {
                                if (Android19 != null && Android19Id != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Android 19 và 20 vừa xuất hiện tại " + Android19.Zone.Map.TileMap.Name));
                                }
                                else if (Android20 != null && Android20Id != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Android 19 và 20 vừa xuất hiện tại " + Android20.Zone.Map.TileMap.Name));
                                }
                                IsAndroidNotify = true;
                            }
                            // Get Random Map
                        } 
                        else 
                        {
                            IsAndroidNotify = false;
                        }
						#endregion
						
						if ((Android2SpawnTimeDelay < ServerUtils.CurrentTimeMillis())) 
                        {
                            Android2SpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                            if (!IsAndroid13Spawn && !IsAndroid14Spawn && !IsAndroid15Spawn)
                            {
                                
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(Android2Maps.Count);
                                int sbRandomMap = Android2Maps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    Android13 = new Boss();
                                    Android13.CreateBoss(DataCache.BOSS_ANDROID_13_TYPE);
                                    Android13.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Android13);
                                    Android13Id = Android13.Id;

                                    Android14 = new Boss();
                                    Android14.CreateBoss(DataCache.BOSS_ANDROID_14_TYPE);
                                    Android14.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Android14);
                                    Android14Id = Android14.Id;

                                    Android15 = new Boss();
                                    Android15.CreateBoss(DataCache.BOSS_ANDROID_15_TYPE);
                                    Android15.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Android15);
                                    Android15Id = Android15.Id;

                                    IsAndroid13Spawn = true;
                                    IsAndroid14Spawn = true;
                                    IsAndroid15Spawn = true;
                                    IsAndroid2Notify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Android 13, 14, 15 vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                                    Server.Gi().Logger.Print(" Android 13, 14, 15..: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                }
                            }
                            else if (!IsAndroid2Notify)
                            {
                                if (Android13 != null && Android13Id != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Android 13 vừa xuất hiện tại " + Android13.Zone.Map.TileMap.Name));
                                }
                                else if (Android14 != null && Android14Id != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Android 14 vừa xuất hiện tại " + Android14.Zone.Map.TileMap.Name));
                                }
                                else if (Android15 != null && Android15Id != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Android 15 vừa xuất hiện tại " + Android15.Zone.Map.TileMap.Name));
                                }
                                IsAndroid2Notify = true;
                            }
                            // Get Random Map
                        } 
                        else 
                        {
                            IsAndroid2Notify = false;
                        }
						
						if ((PPKKSpawnTimeDelay < ServerUtils.CurrentTimeMillis())) 
                        {
                            PPKKSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                            if (!IsPicSpawn && !IsPocSpawn && !IsKingkongSpawn)
                            {
                                
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(PPKKMaps.Count);
                                int sbRandomMap = PPKKMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    Pic = new Boss();
                                    Pic.CreateBoss(DataCache.BOSS_PIC_TYPE);
                                    Pic.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Pic);
                                    PicId = Pic.Id;

                                    Poc = new Boss();
                                    Poc.CreateBoss(DataCache.BOSS_POC_TYPE);
                                    Poc.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Poc);
                                    PocId = Poc.Id;

                                    Kingkong = new Boss();
                                    Kingkong.CreateBoss(DataCache.BOSS_KINGKONG_TYPE);
                                    Kingkong.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Kingkong);
                                    KingkongId = Kingkong.Id;

                                    IsPicSpawn = true;
                                    IsPocSpawn = true;
                                    IsKingkongSpawn = true;
                                    IsPPKKNotify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Pic, Poc, King Kong vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                                    Server.Gi().Logger.Print(" Android Pic, Poc, Kingkong..: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                }
                            }
                            else if (!IsPPKKNotify)
                            {
                                if (Pic != null && PicId != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Pic vừa xuất hiện tại " + Pic.Zone.Map.TileMap.Name));
                                }
                                else if (Poc != null && PocId != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Poc vừa xuất hiện tại " + Poc.Zone.Map.TileMap.Name));
                                }
                                else if (Kingkong != null && KingkongId != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS King Kong vừa xuất hiện tại " + Kingkong.Zone.Map.TileMap.Name));
                                }
                                IsPPKKNotify = true;
                            }
                            // Get Random Map
                        } 
                        else 
                        {
                            IsPPKKNotify = false;
                        }
						
						#region TDST 01 02 03
                        if ((So4SpawnTimeDelay < ServerUtils.CurrentTimeMillis())) 
                        {
                            So4SpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                            if (!IsSo4Spawn && !IsSo3Spawn && !IsSo1Spawn && !IsTDTSpawn)
                            {
                                IsSo4Spawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(TDSTMaps.Count);
                                int sbRandomMap = TDSTMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                CurrentTDSTMapId = sbRandomMap;
                                CurrentTDSTZoneId = sbRandomZoneNum;
                                if (zone != null)
                                {
                                    So4 = new Boss();
                                    So4.CreateBoss(DataCache.BOSS_SO4_TYPE);
                                    So4.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(So4);
                                    So4Id = So4.Id;
                                    IsSo4Spawn = true;
                                    IsSo4Notify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Số 4 " + So4Id + " vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                                    Server.Gi().Logger.Print("So4...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                }
                            }
                            else if (!IsSo4Notify && IsSo4Spawn && So4Id != -1 && So4 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Số 4 " + So4Id + " vừa xuất hiện tại " + So4.Zone.Map.TileMap.Name));
                                IsSo4Notify = true;
                            }
                            else if (!IsSo3Notify && IsSo3Spawn && So3Id != -1 && So3 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Số 3 "+ So3Id +" vừa xuất hiện tại " + So3.Zone.Map.TileMap.Name));
                                IsSo3Notify = true;
                            }
                            else if (!IsSo1Notify && IsSo1Spawn && So1Id != -1 && So1 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Số 1 "+ So1Id +" vừa xuất hiện tại " + So1.Zone.Map.TileMap.Name));
                                IsSo1Notify = true;
                            }
							else if (!IsTDTNotify && IsTDTSpawn && TDTId != -1 && TDT != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Tiểu đội trưởng "+ TDTId +" vừa xuất hiện tại " + TDT.Zone.Map.TileMap.Name));
                                IsTDTNotify = true;
                            }
                            // Get Random Map
                        } 
                        else 
                        {
                            IsSo4Notify = false;
                            IsSo3Notify = false;
                            IsSo1Notify = false;
                            IsTDTNotify = false;
                        }
                        #endregion
						
						#region Xen
						if ((XenSpawnTimeDelay < ServerUtils.CurrentTimeMillis())) 
                        {
                            XenSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                            if (!IsXen1Spawn && !IsXen2Spawn && !IsXen3Spawn && !IsXen4Spawn && !IsXen5Spawn && !IsXen6Spawn && !IsXen7Spawn)
                            {
                                
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(XenMaps.Count);
                                int sbRandomMap = XenMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    Xen1 = new Boss();
                                    Xen1.CreateBoss(DataCache.BOSS_XEN_CON_01_TYPE);
                                    Xen1.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Xen1);
                                    Xen1Id = Xen1.Id;

                                    Xen2 = new Boss();
                                    Xen2.CreateBoss(DataCache.BOSS_XEN_CON_02_TYPE);
                                    Xen2.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Xen2);
                                    Xen2Id = Xen2.Id;

                                    Xen3 = new Boss();
                                    Xen3.CreateBoss(DataCache.BOSS_XEN_CON_03_TYPE);
                                    Xen3.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Xen3);
                                    Xen3Id = Xen3.Id;

                                    Xen4 = new Boss();
                                    Xen4.CreateBoss(DataCache.BOSS_XEN_CON_04_TYPE);
                                    Xen4.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Xen4);
                                    Xen4Id = Xen4.Id;

                                    Xen5 = new Boss();
                                    Xen5.CreateBoss(DataCache.BOSS_XEN_CON_05_TYPE);
                                    Xen5.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Xen5);
                                    Xen5Id = Xen5.Id;


                                    Xen6 = new Boss();
                                    Xen6.CreateBoss(DataCache.BOSS_XEN_CON_06_TYPE);
                                    Xen6.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Xen6);
                                    Xen6Id = Xen6.Id;


                                    Xen7 = new Boss();
                                    Xen7.CreateBoss(DataCache.BOSS_XEN_CON_07_TYPE);
                                    Xen7.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Xen7);
                                    Xen7Id = Xen7.Id;


                                    IsXen1Spawn = true;
                                    IsXen2Spawn = true;
                                    IsXen3Spawn = true;
                                    IsXen4Spawn = true;
                                    IsXen5Spawn = true;
                                    IsXen6Spawn = true;
                                    IsXen7Spawn = true;
                                    IsXenNotify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("7 đứa con của xên vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                                    Server.Gi().Logger.Print("7 đứa con của xên..: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                }
                            }
                            else if (!IsXenNotify)
                            {
                                if (Xen1 != null && Xen1Id != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("7 đứa con của xên vừa xuất hiện tại " + Xen1.Zone.Map.TileMap.Name));
                                }
                                else if (Xen2 != null && Xen2Id != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("7 đứa con của xên vừa xuất hiện tại " + Xen2.Zone.Map.TileMap.Name));
                                }
				else if (Xen3 != null && Xen3Id != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("7 đứa con của xên vừa xuất hiện tại " + Xen3.Zone.Map.TileMap.Name));
                                }
				else if (Xen4 != null && Xen4Id != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("7 đứa con của xên vừa xuất hiện tại " + Xen4.Zone.Map.TileMap.Name));
                                }
				else if (Xen5 != null && Xen5Id != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("7 đứa con của xên vừa xuất hiện tại " + Xen5.Zone.Map.TileMap.Name));
                                }
				else if (Xen6 != null && Xen6Id != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("7 đứa con của xên vừa xuất hiện tại " + Xen6.Zone.Map.TileMap.Name));
                                }
				else if (Xen7 != null && Xen7Id != -1)
                                {
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("7 đứa con của xên vừa xuất hiện tại " + Xen7.Zone.Map.TileMap.Name));
                                }
                                IsXenNotify = true;
                            }
                            // Get Random Map
                        } 
                        else 
                        {
                            IsXenNotify = false;
                        }
						#endregion
						
						#region SBH

                        if ((SBHSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            SBHSpawnTimeDelay = 1800000 + ServerUtils.CurrentTimeMillis();
                            if (!IsSBHSpawn)
                            {
                                IsSBHSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(SBHMaps.Count);
                                int sbRandomMap = SBHMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    SBH = new Boss();
                                    SBH.CreateBoss(DataCache.BOSS_SBH_TYPE);
                                    SBH.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(SBH);
                                    SBHId = SBH.Id;
                                    IsSBHSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Siêu bọ hung " + SBHId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print("Boss Spawn Sieu bo hung...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                    IsSBHNotify = true;
                                }
                            }
                            else if (!IsSBHNotify && SBH != null && SBHId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Siêu bọ hung " + SBHId + " vừa xuất hiện tại " + SBH.Zone.Map.TileMap.Name));
                                IsSBHNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsSBHNotify = false;
                        }


                        #endregion
						
						#region Tau77

                        if ((Tau77SpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            Tau77SpawnTimeDelay = 1200000 + ServerUtils.CurrentTimeMillis();
                            if (!IsTau77Spawn)
                            {
                                IsTau77Spawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(Tau77Maps.Count);
                                int sbRandomMap = Tau77Maps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    Tau77 = new Boss();
                                    Tau77.CreateBoss(DataCache.BOSS_Tau77_TYPE);
                                    Tau77.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Tau77);
                                    Tau77Id = Tau77.Id;
                                    IsTau77Spawn = true;
                                    //ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Tàu 77 " + Tau77Id + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print("Boss Spawn Tau 77...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                    IsTau77Notify = true;
                                }
                            }
                            else if (!IsTau77Notify && Tau77 != null && Tau77Id != -1)
                            {
                                //ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Tàu 77 " + Tau77Id + " vừa xuất hiện tại " + Tau77.Zone.Map.TileMap.Name));
                                IsTau77Notify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsTau77Notify = false;
                        }


                        #endregion
						
						#region Bojack

                        if ((BojackSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            BojackSpawnTimeDelay = 1200000 + ServerUtils.CurrentTimeMillis();
                            if (!IsBojackSpawn)
                            {
                                IsBojackSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(BojackMaps.Count);
                                int sbRandomMap = BojackMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    Bojack = new Boss();
                                    Bojack.CreateBoss(DataCache.BOSS_Bojack_TYPE);
                                    Bojack.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Bojack);
                                    BojackId = Bojack.Id;
                                    IsBojackSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Bojack " + BojackId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print("Boss Spawn Bojack...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                    IsBojackNotify = true;
                                }
                            }
                            else if (!IsBojackNotify && Bojack != null && BojackId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Bojack " + BojackId + " vừa xuất hiện tại " + Bojack.Zone.Map.TileMap.Name));
                                IsBojackNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsBojackNotify = false;
                        }


                        #endregion
						#region Kuku

                        if ((KukuSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            KukuSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                            if (!IsKukuSpawn)
                            {
                                IsKukuSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(KukuMaps.Count);
                                int sbRandomMap = KukuMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    Kuku = new Boss();
                                    Kuku.CreateBoss(DataCache.BOSS_KUKU_TYPE);
                                    Kuku.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Kuku);
                                    KukuId = Kuku.Id;
                                    IsKukuSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Kuku " + KukuId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print("Boss Spawn kuku...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                    IsKukuNotify = true;
                                }
                            }
                            else if (!IsKukuNotify && Kuku != null && KukuId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Kuku " + KukuId + " vừa xuất hiện tại " + Kuku.Zone.Map.TileMap.Name));
                                IsKukuNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsKukuNotify = false;
                        }


                        #endregion
						
						#region MDD

                        if ((MDDSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            MDDSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                            if (!IsMDDSpawn)
                            {
                                IsMDDSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(MDDMaps.Count);
                                int sbRandomMap = MDDMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    MDD = new Boss();
                                    MDD.CreateBoss(DataCache.BOSS_MDD_TYPE);
                                    MDD.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(MDD);
                                    MDDId = MDD.Id;
                                    IsMDDSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Mập đầu đinh " + MDDId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print("Boss Spawn MDD...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                    IsMDDNotify = true;
                                }
                            }
                            else if (!IsMDDNotify && MDD != null && MDDId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Mập đầu đinh " + MDDId + " vừa xuất hiện tại " + MDD.Zone.Map.TileMap.Name));
                                IsMDDNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsMDDNotify = false;
                        }


                        #endregion
						
						#region Rambo

                        if ((RamboSpawnTimeDelay < ServerUtils.CurrentTimeMillis()))
                        {
                            RamboSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                            if (!IsRamboSpawn)
                            {
                                IsRamboSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(RamboMaps.Count);
                                int sbRandomMap = RamboMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    Rambo = new Boss();
                                    Rambo.CreateBoss(DataCache.BOSS_RAMBO_TYPE);
                                    Rambo.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Rambo);
                                    RamboId = Rambo.Id;
                                    IsRamboSpawn = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Rambo " + RamboId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print("Boss Spawn Rambo...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                                    IsRamboNotify = true;
                                }
                            }
                            else if (!IsRamboNotify && Rambo != null && RamboId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Rambo " + RamboId + " vừa xuất hiện tại " + Rambo.Zone.Map.TileMap.Name));
                                IsRamboNotify = true;
                            }
                            // Get Random Map
                        }
                        else
                        {
                            IsRamboNotify = false;
                        }


                        #endregion
						#region NgoKhong

                         if ((NgoKhongSpawnTimeDelay < ServerUtils.CurrentTimeMillis())) 
                         {
                             NgoKhongSpawnTimeDelay = 500000 + ServerUtils.CurrentTimeMillis();
                             if (!IsNgoKhongSpawn)
                             {
                                 IsNgoKhongSpawn = true;
                                 int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                 int sbRandomMapIndex = ServerUtils.RandomNumber(NgoKhongMaps.Count);
                                 int sbRandomMap = NgoKhongMaps[sbRandomMapIndex];
                                 var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                 if (zone != null)
                                 {
                                     NgoKhong = new Boss();
                                     NgoKhong.CreateBoss(DataCache.BOSS_NgoKhong_TYPE);
                                     NgoKhong.CharacterHandler.SetUpInfo();
                                     zone.ZoneHandler.AddBoss(NgoKhong);
                                     NgoKhongId = NgoKhong.Id;
                                     IsNgoKhongSpawn = true;
                                     ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Ngộ không " + NgoKhongId + " vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                                     IsNgoKhongNotify = true;
                                 }
                             }
                             else if (!IsNgoKhongNotify && NgoKhong != null && NgoKhongId != -1)
                             {
                                 ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Ngộ không " + NgoKhongId + " vừa xuất hiện tại " + NgoKhong.Zone.Map.TileMap.Name));
                                 IsNgoKhongNotify = true;
                             }
                             // Get Random Map
                         } 
                         else 
                         {
                             IsNgoKhongNotify = false;
                         }

                        #endregion
                    }
                    catch (Exception e)
                    {
                        Server.Gi().Logger.Error($"Error StartBossRunTime in BossRunTime.cs: {e.Message} \n {e.StackTrace}", e);
                    }
                    Thread.Sleep(1000);
                }
                Server.Gi().Logger.Print("Boss Runtime is close Success...");
                IsStop = true;
            })).Start();
        }

        public void SpawnSuperBlackGoku()
        {
            try
            {
                IsSuperBlackGokuSpawn = true;
                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                int sbRandomMapIndex = ServerUtils.RandomNumber(BlackGokuMaps.Count);
                int sbRandomMap = BlackGokuMaps[sbRandomMapIndex];
                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                if (zone != null)
                {
                    superBlackGoku = new Boss();
                    superBlackGoku.CreateBoss(DataCache.BOSS_SUPER_BLACK_GOKU_TYPE);
                    superBlackGoku.CharacterHandler.SetUpInfo();
                    zone.ZoneHandler.AddBoss(superBlackGoku);
                    superBlackGokuId = superBlackGoku.Id;
                    IsSuperBlackGokuSpawn = true;
                    IsSuperBlackGokuNotify = true;
                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Super Black Goku " + superBlackGokuId + " vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                    Server.Gi().Logger.Print("Super Boss Spawn Black Goku...: Map " + sbRandomMap + " Zone: " + sbRandomZoneNum + " Name: " + zone.Map.TileMap.Name + " DataCache.CURRENT_BOSS_ID: " + DataCache.CURRENT_BOSS_ID);
                }
            }
            catch (Exception e)
            {
                Server.Gi().Logger.Error($"Error SpawnSuperBlackGoku in BossRunTime.cs: {e.Message} \n {e.StackTrace}", e);
            }

            
        }

        public void SpawnFideBoss(int type)
        {
            try
            {
                if (type == 2)
                {
                    IsFide02Spawn = true;
                    var zone = MapManager.Get(CurrentFideMapId)?.GetZoneById(CurrentFideZoneId);
                    if (zone != null)
                    {
                        fide02 = new Boss();
                        fide02.CreateBoss(DataCache.BOSS_FIDE_02_TYPE);
                        fide02.CharacterHandler.SetUpInfo();
                        zone.ZoneHandler.AddBoss(fide02);
                        fide02Id = fide02.Id;
                        IsFide02Notify = true;
                        IsFide02Spawn = true;
                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Fide 02 "+fide02Id+" vừa xuất hiện tại " + zone.Map.TileMap.Name));
                        Server.Gi().Logger.Print("Fide 2...: Map " + zone.Map.TileMap.Name);
                    }
                }
                else 
                {
                    IsFide03Spawn = true;
                    var zone = MapManager.Get(CurrentFideMapId)?.GetZoneById(CurrentFideZoneId);
                    if (zone != null)
                    {
                        fide03 = new Boss();
                        fide03.CreateBoss(DataCache.BOSS_FIDE_03_TYPE);
                        fide03.CharacterHandler.SetUpInfo();
                        zone.ZoneHandler.AddBoss(fide03);
                        fide03Id = fide03.Id;
                        IsFide03Notify = true;
                        IsFide03Spawn = true;
                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Fide 03 "+fide03Id+" vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                        Server.Gi().Logger.Print("Fide 3...: Map " + zone.Map.TileMap.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Server.Gi().Logger.Error($"Error SpawnFideBoss in BossRunTime.cs: {e.Message} \n {e.StackTrace}", e);
            }
        }
        public void SpawnCoolerBoss(int type)
        {
            try
            {
                if (type == 2)
                {
                    IsCooler02Spawn = true;
                    var zone = MapManager.Get(CurrentCoolerMapId)?.GetZoneById(CurrentCoolerZoneId);
                    if (zone != null)
                    {
                        cooler02 = new Boss();
                        cooler02.CreateBoss(DataCache.BOSS_COOLER_02_TYPE);
                        cooler02.CharacterHandler.SetUpInfo();
                        zone.ZoneHandler.AddBoss(cooler02);
                        cooler02Id = cooler02.Id;
                        IsCooler02Notify = true;
                        IsCooler02Spawn = true;
                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Cooler 02 "+cooler02Id+" vừa xuất hiện tại " + zone.Map.TileMap.Name));
                        Server.Gi().Logger.Print("Cooler 2...: Map " + zone.Map.TileMap.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Server.Gi().Logger.Error($"Error SpawnFideBoss in BossRunTime.cs: {e.Message} \n {e.StackTrace}", e);
            }
        }
		public void SpawnTDSTBoss(int type)
        {
            try
            {
                if (type == 2)
                {
                    IsSo3Spawn = true;
                    var zone = MapManager.Get(CurrentTDSTMapId)?.GetZoneById(CurrentTDSTZoneId);
                    if (zone != null)
                    {
                        So3 = new Boss();
                        So3.CreateBoss(DataCache.BOSS_SO3_TYPE);
                        So3.CharacterHandler.SetUpInfo();
                        zone.ZoneHandler.AddBoss(So3);
                        So3Id = So3.Id;
                        IsSo3Notify = true;
                        IsSo3Spawn = true;
                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Số 3 "+So3Id+" vừa xuất hiện tại " + zone.Map.TileMap.Name));
                        Server.Gi().Logger.Print("So 3...: Map " + zone.Map.TileMap.Name);
                    }
                }
                else if (type == 3)
                {
                    IsSo1Spawn = true;
                    var zone = MapManager.Get(CurrentTDSTMapId)?.GetZoneById(CurrentTDSTZoneId);
                    if (zone != null)
                    {
                        So1 = new Boss();
                        So1.CreateBoss(DataCache.BOSS_SO1_TYPE);
                        So1.CharacterHandler.SetUpInfo();
                        zone.ZoneHandler.AddBoss(So1);
                        So1Id = So1.Id;
                        IsSo1Notify = true;
                        IsSo1Spawn = true;
                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Số 1 "+So1Id+" vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                        Server.Gi().Logger.Print("So1...: Map " + zone.Map.TileMap.Name);
                    }
                }
				else
                {
                    IsTDTSpawn = true;
                    var zone = MapManager.Get(CurrentTDSTMapId)?.GetZoneById(CurrentTDSTZoneId);
                    if (zone != null)
                    {
                        TDT = new Boss();
                        TDT.CreateBoss(DataCache.BOSS_TDT_TYPE);
                        TDT.CharacterHandler.SetUpInfo();
                        zone.ZoneHandler.AddBoss(TDT);
                        TDTId = TDT.Id;
                        IsTDTNotify = true;
                        IsTDTSpawn = true;
                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("BOSS Tiểu đội trưởng "+TDTId+" vừa xuất hiện tại " + zone.Map.TileMap.Name ));
                        Server.Gi().Logger.Print("TDT...: Map " + zone.Map.TileMap.Name);
                    }
                }
			
            }
            catch (Exception e)
            {
                Server.Gi().Logger.Error($"Error SpawnTDSTBoss in BossRunTime.cs: {e.Message} \n {e.StackTrace}", e);
            }
        }
    }
}