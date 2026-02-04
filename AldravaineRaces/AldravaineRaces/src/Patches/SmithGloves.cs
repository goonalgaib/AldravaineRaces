using System;
using System.Linq;
using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace AldravaineRaces.src.Patches
{
    [HarmonyPatch(typeof(InventoryBase), nameof(InventoryBase.DropSlotIfHot))]
    public class PlayerDropSlotIfHotPatch
    {

        [HarmonyPrefix]
        public static bool Gear_Has_Heat_Resistant(ItemSlot slot, IPlayer player)
        {
            System.Diagnostics.Debug.WriteLine("Checking for heat resistant gloves...");
            System.Diagnostics.Debug.WriteLine($"Slot Empty: {slot.Empty}, Player: {player?.PlayerName}, GameMode: {player?.WorldData.CurrentGameMode}");
            if (slot.Empty || player == null || player.WorldData.CurrentGameMode == EnumGameMode.Creative) return false;

            System.Diagnostics.Debug.WriteLine("Player has gloves equipped, checking for heat resistance...");
            System.Diagnostics.Debug.WriteLine($"Player Entity: {player.Entity}");
            if (player.Entity?
                    .GetBehavior<EntityBehaviorPlayerInventory>() is not { Inventory: not null } playerInventory)
                return true;
            foreach (var itemSlot in playerInventory.Inventory)
            {
                System.Diagnostics.Debug.WriteLine($"Checking slot: {itemSlot.SlotId}, BackgroundIcon: {itemSlot.BackgroundIcon}, Empty: {itemSlot.Empty}");
                if (itemSlot.BackgroundIcon != "gloves")
                {
                    continue;
                }

                if (itemSlot.Empty)
                {
                    return true;
                }

                var itemstack = itemSlot.Itemstack;
                bool? isHeatResistant;
                if (itemstack == null)
                {
                    isHeatResistant = null;
                }
                else
                {
                    var attributes = itemstack.Collectible.Attributes;
                    isHeatResistant = attributes?.IsTrue("heatResistant");
                }
                return isHeatResistant != null && !isHeatResistant.Value;
            }
            return true;
        }
    }
}