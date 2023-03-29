// StaminaTweaks, Valheim mod that improves stamina
// Copyright (C) 2022 BurgersMcFly
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

namespace StaminaTweaks
{
    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    public class StaminaTweaks : BaseUnityPlugin
    {
        const string pluginGUID = "StaminaTweaks";
        const string pluginName = "Stamina Tweaks";
        const string pluginVersion = "1.0.1";
        public static readonly Harmony harmony = new Harmony("StaminaTweaks");
        void Awake()
        {
            harmony.PatchAll();

        }
        void OnDestroy()
        {
            harmony.UnpatchSelf();
        }
    }

    [HarmonyPatch(typeof(Attack), "GetAttackStamina")]
    public static class AxePickaxeTweaks
    {
        private static void Postfix(ref Attack __instance, ref float __result)
        {
            if (__instance.m_character.GetRightItem() != null && !LootSpawner.IsMonsterInRange(Player.m_localPlayer.transform.position, 20f))
            {
                switch (__instance.m_character.GetRightItem().m_shared.m_name)
                {
                    case "$item_axe_stone":
                    case "$item_axe_bronze":
                    case "$item_axe_flint":
                    case "$item_axe_iron":
                    case "$item_axe_blackmetal":
                    case "$item_axe_jotunbane":
                    case "$item_pickaxe_stone":
                    case "$item_pickaxe_iron":
                    case "$item_pickaxe_bronze":
                    case "$item_pickaxe_antler":
                    case "$item_pickaxe_blackmetal":
                    case "$item_battleaxe":
                    case "$item_battleaxe_crystal":
                        __result = 0f;
                        break;
                }
            }
        }
    }

    [HarmonyPatch(typeof(Player), "UseStamina")]
    public static class PlayerAndToolsTweaks
    {
        private static void Prefix(ref Player __instance, ref float v, ref float ___m_runStaminaDrain, ref float ___m_jumpStaminaUsage, ref float ___m_sneakStaminaDrain, ref float ___m_dodgeStaminaUsage, ref float ___m_encumberedStaminaDrain, ref float ___m_swimStaminaDrainMinSkill, ref float ___m_swimStaminaDrainMaxSkill)
        {

            if (!LootSpawner.IsMonsterInRange(Player.m_localPlayer.transform.position, 20f))
            {
                ___m_runStaminaDrain = 0f;
                ___m_jumpStaminaUsage = 0f;
                ___m_sneakStaminaDrain = 0f;
                ___m_dodgeStaminaUsage = 0f;
                ___m_encumberedStaminaDrain = 0f;
                ___m_swimStaminaDrainMinSkill = 0f;
                ___m_swimStaminaDrainMaxSkill = 0f;
            }
            else
            {
                ___m_runStaminaDrain = 10f;
                ___m_jumpStaminaUsage = 10f;
                ___m_sneakStaminaDrain = 5f;
                ___m_dodgeStaminaUsage = 10f;
                ___m_encumberedStaminaDrain = 10f;
                ___m_swimStaminaDrainMinSkill = 5f;
                ___m_swimStaminaDrainMaxSkill = 2f;
            }

            string name = new StackTrace().GetFrame(2).GetMethod().Name;
            if (__instance.GetRightItem() != null && !LootSpawner.IsMonsterInRange(Player.m_localPlayer.transform.position, 20f) && name.Contains("UpdatePlacement") || name.Contains("Repair") || name.Contains("RemovePiece"))
            {
                switch (__instance.GetRightItem().m_shared.m_name)
                {
                    case "$item_hammer":
                    case "$item_hoe":
                    case "$item_cultivator":
                        v = 0f;
                        break;
                }
            }

            if (__instance.GetRightItem() != null && !LootSpawner.IsMonsterInRange(Player.m_localPlayer.transform.position, 20f) && name.Contains("FixedUpdate") || name.Contains("PlayerAttackInput"))
            {
                switch (__instance.GetRightItem().m_shared.m_name)
                {
                    case "$item_fishingrod":
                        v = 0f;
                        break;
                }
            }
        }
    }

    [HarmonyPatch(typeof(Player), "UpdateStats")]
    public static class RegenerationTweaks
    {
        private static void Postfix(ref Player __instance)
        {
            if (__instance.GetRightItem() != null && !LootSpawner.IsMonsterInRange(Player.m_localPlayer.transform.position, 20f) && __instance.InAttack() && !__instance.IsSwiming() && !__instance.IsEncumbered())
            {
                {
                    switch (__instance.GetRightItem().m_shared.m_name)
                    {
                        case "$item_axe_stone":
                        case "$item_axe_bronze":
                        case "$item_axe_flint":
                        case "$item_axe_iron":
                        case "$item_axe_blackmetal":
                        case "$item_axe_jotunbane":
                        case "$item_pickaxe_stone":
                        case "$item_pickaxe_iron":
                        case "$item_pickaxe_bronze":
                        case "$item_pickaxe_antler":
                        case "$item_pickaxe_blackmetal":
                            __instance.AddStamina(0.05f);
                            break;
                    }
                }
            }

            if (__instance.IsSwiming() && !__instance.InAttack() && !LootSpawner.IsMonsterInRange(Player.m_localPlayer.transform.position, 20f))
            {
                __instance.AddStamina(0.05f);
            }

            if (__instance.IsEncumbered() && !__instance.InAttack() && !__instance.IsSwiming() && !LootSpawner.IsMonsterInRange(Player.m_localPlayer.transform.position, 20f))
            {
                __instance.AddStamina(0.05f);
            }
        }
    }
}


