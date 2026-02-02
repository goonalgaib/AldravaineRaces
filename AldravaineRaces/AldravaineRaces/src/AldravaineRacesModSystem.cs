using AldravaineRaces.src.BlockBehaviors;
using AldravaineRaces.src.Chef;
using AldravaineRaces.src.CollectibleBehaviors;
using AldravaineRaces.src.EntityBehaviors;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using Vintagestory;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;
using Vintagestory.API.Util;
using Vintagestory.Client.NoObf;
using Vintagestory.GameContent;
using Vintagestory.ServerMods;


namespace AldravaineRaces.src {

    public class AldravaineRacesModSystem : ModSystem {

        public static Harmony harmony;

        public const string ClayformingPatchesCategory = "AldravaineRacesClayformingPatchesCatagory";
        public const string WearableLightsPatchesCategory = "AldravaineRacesWearableLightsPatchesCategory";
        public const string ToolkitPatchesCategory = "AldravaineRacesToolkitFunctionalityCategory";
        public const string SilverTonguePatchesCategory = "AldravaineRacesSilverTonguePatchCategory";
        public const string SpecialStockPatchesCategory = "AldravaineRacesSpecialStockPatchesCategory";
        //public const string ChefRosinPatchCategory = "AldravaineRacesChefRosinPatchCategory";
        public const string BlockSchematicPatchCategory = "AldravaineRacesBlockSchematicPatchCategory";
        public const string StaticTranslocatorPatchesCategory = "AldravaineRacesStaticTranslocatorBlockPatchCategory";
        public const string DragonskinPatchCategory = "AldravaineRacesDragonskinPatchCategory";

        public static ICoreAPI Api;
        public static ICoreClientAPI CApi;
        public static ICoreServerAPI SApi;
        public static ILogger Logger;
        public static string ModID;

        public const string FlaxRateStat = "flaxFiberChance";
        public const string BonusClayVoxelsStat = "clayformingPoints";

        public const string ToolkitRepairedAttribute = "toolkitRepairedLoss";

        public const float lossPerBasicTkRepair = 0.2f;
        public const float lossPerSimpleTkRepair = 0.15f;
        public const float lossPerStandardTkRepair = 0.1f;
        public const float lossPerAdvancedTkRepair = 0.05f;

        public override void StartPre(ICoreAPI api) {
            Api = api;
            Logger = Mod.Logger;
            ModID = Mod.Info.ModID;
        }

        public override void Start(ICoreAPI api) {
            api.RegisterCollectibleBehaviorClass("ClairvoyanceBehavior", typeof(ClairvoyanceBehavior));
            api.RegisterBlockEntityBehaviorClass("TranslocatorPOIBehavior", typeof(TranslocatorTrackerBlockEntityBehavior));

            api.RegisterEntityBehaviorClass("EntityBehaviorDread", typeof(DreadBehavior));
            api.RegisterEntityBehaviorClass("EntityBehaviorTemporalTraits", typeof(TemporalStabilityTraitBehavior));

            api.RegisterBlockEntityClass("POITrackerDummyBlockEntity", typeof(POITrackerDummyBlockEntity));
            api.RegisterBlockClass("BlockRefurbishedCrock", typeof(BlockRefurbishedCrock));;

            ApplyPatches();
        }

        public override void StartServerSide(ICoreServerAPI api) {
            SApi = api;
        }

        public override void StartClientSide(ICoreClientAPI api) {
            CApi = api;
        }

        public override void AssetsLoaded(ICoreAPI api) {
            
        }

        private static void ApplyPatches() {
            if (harmony != null) {
                return;
            }

            harmony = new Harmony(ModID);
            Logger.VerboseDebug("Harmony is starting Patches!");
            harmony.PatchCategory(ClayformingPatchesCategory);
            harmony.PatchCategory(WearableLightsPatchesCategory);
            harmony.PatchCategory(ToolkitPatchesCategory);
            harmony.PatchCategory(SilverTonguePatchesCategory);
            harmony.PatchCategory(SpecialStockPatchesCategory);
            //harmony.PatchCategory(ChefRosinPatchCategory);
            harmony.PatchCategory(BlockSchematicPatchCategory);
            harmony.PatchCategory(StaticTranslocatorPatchesCategory);
            harmony.PatchCategory(DragonskinPatchCategory);
            Logger.VerboseDebug("Finished patching for Trait purposes.");
        }

        private static void HarmonyUnpatch() {
            Logger?.VerboseDebug("Unpatching Harmony Patches.");
            harmony?.UnpatchAll(ModID);
            harmony = null;
        }

        public override void Dispose() {
            HarmonyUnpatch();
            Logger = null;
            ModID = null;
            Api = null;
            base.Dispose();
        }
    }
}
