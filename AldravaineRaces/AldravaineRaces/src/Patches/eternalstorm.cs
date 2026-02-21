using canjewelry.src.be;
using canjewelry.src.blocks;
using canjewelry.src.jewelry;
using EternalStorm;
using HarmonyLib;
using System;
using System.Linq;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.API.Server;
using Vintagestory.Client;
using Vintagestory.GameContent;
using Vintagestory.ServerMods;

namespace AldravaineRaces.src.Patches
{
    [HarmonyPatch(typeof(EternalStormModSystem), "Start")]
    public class Patch_EternalStorm_Start
    {
        static void Postfix(
            EternalStormModSystem __instance,
            ref EternalStormModConfig ___config,
            ref ICoreAPI ___api)
        {
            if (___config == null) return;

            ___api?.Logger.Notification("EternalStorm config overridden.");

            ___config.PlayerMaxSaturation = 5000f;
            //___config.LowStabilityDamage = 0f;
            //___config.LowStabilityHungerCost = 0f;
            //___config.StabilityPerGearUse = 0f;
            //___config.DamageOnTemporalGearUse = 0f;
            //___config.RiftDamageRadius = 4f;
            //___config.RiftDamagePerSecond = 3f;
            ___config.BorderStart = 999;
            ___config.BorderEnd = 1500;
            //___config.BorderSanityPerSecond = 0.01;

            ___api?.StoreModConfig(___config, EternalStormModSystem.ConfigName);
        }
    }
}