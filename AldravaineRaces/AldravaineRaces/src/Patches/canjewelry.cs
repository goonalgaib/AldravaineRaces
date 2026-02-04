using canjewelry.src.be;
using canjewelry.src.blocks;
using canjewelry.src.jewelry;
using HarmonyLib;
using System;
using System.Linq;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.Client;
using Vintagestory.GameContent;
using Vintagestory.ServerMods;

namespace AldravaineRaces.src.Patches
{
    [HarmonyPatch(typeof(BlockGemCuttingTable), "OnBlockInteractStart")]
    public class Patch_GemCuttingTableAccess
    {
        public const string GemCutterTraitCode = "GemCutter";

        static bool Prefix(
            IWorldAccessor world,
            IPlayer byPlayer,
            BlockSelection blockSel,
            ref bool __result
        )
        {
            if (byPlayer?.Entity?.WatchedAttributes == null)
            {
                return true; // let original run
            }

            bool canUse = false;

            string classcode = byPlayer.Entity.WatchedAttributes.GetString("characterClass");
            CharacterClass charclass = byPlayer.Entity.Api.ModLoader.GetModSystem<CharacterSystem>().characterClasses.FirstOrDefault(c => c.Code == classcode);
            if (charclass != null) {
                if (charclass.Traits.Contains(GemCutterTraitCode))
                {
                     canUse = true; // allowed → run canJewelry code normally
                }
            }

            if (!canUse)
            {

                __result = true;   // interaction handled
                return false;      // skip original logic entirely
            }

            return true; // allowed → run canJewelry code normally
        }
    }

    [HarmonyPatch(typeof(BlockJewelGrinder), "OnBlockInteractStart")]
    public class Patch_BlockJewelGrinderAccess
    {
        public const string GemCutterTraitCode = "GemCutter";

        static bool Prefix(
            IWorldAccessor world,
            IPlayer byPlayer,
            BlockSelection blockSel,
            ref bool __result
        )
        {
            if (byPlayer?.Entity?.WatchedAttributes == null)
            {
                return true; // let original run
            }

            bool canUse = false;

            string classcode = byPlayer.Entity.WatchedAttributes.GetString("characterClass");
            CharacterClass charclass = byPlayer.Entity.Api.ModLoader.GetModSystem<CharacterSystem>().characterClasses.FirstOrDefault(c => c.Code == classcode);
            if (charclass != null)
            {
                if (charclass.Traits.Contains(GemCutterTraitCode))
                {
                    canUse = true; // allowed → run canJewelry code normally
                }
            }

            if (!canUse)
            {

                __result = true;   // interaction handled
                return false;      // skip original logic entirely
            }

            return true; // allowed → run canJewelry code normally
        }
    }

    [HarmonyPatch(typeof(JewelerSetBlock), "OnBlockInteractStart")]
    public class Patch_JewelerSetBlockAccess
    {
        public const string GemCutterTraitCode = "GemCutter";

        static bool Prefix(
            IWorldAccessor world,
            IPlayer byPlayer,
            BlockSelection blockSel,
            ref bool __result
        )
        {
            if (byPlayer?.Entity?.WatchedAttributes == null)
            {
                return true; // let original run
            }

            bool canUse = false;

            string classcode = byPlayer.Entity.WatchedAttributes.GetString("characterClass");
            CharacterClass charclass = byPlayer.Entity.Api.ModLoader.GetModSystem<CharacterSystem>().characterClasses.FirstOrDefault(c => c.Code == classcode);
            if (charclass != null)
            {
                if (charclass.Traits.Contains(GemCutterTraitCode))
                {
                    canUse = true; // allowed → run canJewelry code normally
                }
            }

            if (!canUse)
            {

                __result = true;   // interaction handled
                return false;      // skip original logic entirely
            }

            return true; // allowed → run canJewelry code normally
        }
    }
}