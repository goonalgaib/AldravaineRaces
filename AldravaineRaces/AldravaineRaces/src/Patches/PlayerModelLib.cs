//using HarmonyLib;
//using PlayerModelLib;
//using System;
//using System.Reflection;
//using Vintagestory.API.Common;
//using Vintagestory.GameContent;


//namespace AldravaineRaces.src.Patches
//{
//    [HarmonyPatch]
//    public class Patch_applyTraitAttributes
//    {
//        static MethodBase TargetMethod()
//        {
//            return AccessTools.Method(
//                "PlayerModelLib.OtherPatches:applyTraitAttributes"
//            );
//        }

//        static void Postfix(CharacterSystem __instance, EntityPlayer eplr)
//        {
//            //if (eplr == null || eplr.Api == null) return;

//            //string name = eplr.Player?.PlayerName ?? eplr.GetName();
//            //string classCode = eplr.WatchedAttributes?.GetString("characterClass", "<none>");



//            //var api = eplr.Api;

//            //var skinBehavior = eplr.GetBehavior<PlayerSkinBehavior>();
//            //string modelCode = skinBehavior?.CurrentModelCode ?? "<null>";
//            //var modelSystem = api.ModLoader.GetModSystem<CustomModelsSystem>();
//            //if (modelCode == "<null>" || !modelSystem.CustomModels.TryGetValue(modelCode, out var model))
//            //{
//            //    api.Logger.Warning("[AldravaineRaces] No custom model found for code: " + modelCode);
//            //    return;
//            //}

//            //string[] extraTraits = model.ExtraTraits;
//            //foreach (string traitCode in extraTraits) {
//            //    if (!__instance.TraitsByCode.TryGetValue(traitCode, out Trait? trait)) continue;

//            //    foreach ((string attributeCode, double attributeValue) in trait.Attributes)
//            //    {
//            //        api.Logger.Debug($"[AldravaineRaces] Applying trait {traitCode} attribute {attributeCode} with value {attributeValue} to player {name} (class {classCode})");
//            //    }
//            //}
//            //eplr.WatchedAttributes.SetStringArray("extraTraits", extraTraits);

//            // Assuming eplr.Stats is your EntityStats object
//            var stats = eplr.Stats;

//            foreach (var categoryPair in stats) // categoryPair.Key = category name, categoryPair.Value = EntityFloatStats
//            {
//                string categoryName = categoryPair.Key;
//                EntityFloatStats floatStats = categoryPair.Value;

//                Console.WriteLine($"Category: {categoryName}, BlendType: {floatStats.BlendType}");

//                foreach (var statPair in floatStats.ValuesByKey) // statPair.Key = code, statPair.Value = EntityStat<float>
//                {
//                    string code = statPair.Key;
//                    float value = statPair.Value.Value;
//                    bool persistent = statPair.Value.Persistent;

//                    Console.WriteLine($"  {code} = {value} (Persistent: {persistent})");
//                }
//            }

//        }
//    }
//}