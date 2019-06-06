using System.Reflection;

namespace Entropy.AIO.Bases
{
    using System.Linq;
    using SDK.Damage;
    using SDK.Enumerations;
    using SDK.Extensions.Objects;
    using SDK.Orbwalking;
    using SDK.Orbwalking.EventArgs;
    using ToolKit;
    using Utility;
    using static Components;
    using Utilities = SDK.Constants.Utilities;

    static class LogicBase
    {
        
        public static void Initialize()
        {
            Orbwalker.OnPreAttack += OnPreAttack;
            Spellbook.OnLocalCastSpell += OnLocalCastSpell;
        }

        private static void OnPreAttack(OnPreAttackEventArgs args)
        {
            if (args.Target == null)
            {
                return;
            }

            if (args.Target.IsStructure())
            {
                return;
            }

            var stormrazorSlot =
                LocalPlayer.Instance.InventorySlots.FirstOrDefault(s => s.IsValid && s.ItemID == (uint) ItemID.Stormrazor);
            if (stormrazorSlot != null)
            {
                switch (Orbwalker.Mode)
                {
                    case OrbwalkingMode.Combo when !General.StormrazorComboMenubool.Enabled: return;
                    case OrbwalkingMode.Harass when !General.StormrazorHarassMenubool.Enabled: return;
                    case OrbwalkingMode.Laneclear when !General.StormrazorLaneClearMenubool.Enabled: return;
                    case OrbwalkingMode.Lasthit when !General.StormrazorLasthitMenubool.Enabled: return;
                }

                if (!LocalPlayer.Instance.HasBuff("windbladebuff"))
                {
                    args.Cancel = true;
                }
            }
        }

        private static void OnLocalCastSpell(SpellbookLocalCastSpellEventArgs args)
        {
            var slot = args.Slot;
            if (!Utilities.SpellSlots.Contains(slot) || LocalPlayer.Instance.MaxMP <= 200)
            {
                return;
            }

            // Preserve Spells Logic, works fine.
            var menuValue = General.PreserveSpellsMenu.GetSlotValue(slot);
            if (menuValue > 0)
            {
                switch (Orbwalker.Mode)
                {
                    case OrbwalkingMode.Combo:
                    case OrbwalkingMode.Harass:
                        var target = Orbwalker.GetOrbwalkingTarget() as AIHeroClient;
                        if (target != null &&
                            target.GetRealHealth(DamageType.Physical) <=
                            LocalPlayer.Instance.GetAutoAttackDamage(target) * menuValue)
                        {
                            args.Execute = false;
                            Logging.Log(
                                $"Preserve Spells Logic: Denied {args.Slot} usage because {target.CharName} is killable within {menuValue} autos.");
                        }

                        break;
                }
            }
            // end of preserve spells logic

            // Start of Preserve Mana Logic

            // Dictionary to fill with data.
            var data = Utility.Utilities.PreserveManaData;

            // If menuoption is disabled, just return, and if the spell was before being preserved, remove it from the list.
            var menuOptionEnabled = General.PreserveManaMenu.IsSlotEnabled(slot);
            if (!menuOptionEnabled && data.ContainsKey(slot))
            {
                data.Remove(slot);
                Logging.Log($"Preserve Mana List: Removed {slot} (Disabled).");
                return;
            }

            // gets manacost from manacostarray.
            var manaCost = slot.GetManaCost();
            if (manaCost == 0)
            {
                return;
            }

            // if the spell is already registered inside the preservedataarray..
            if (data.ContainsKey(slot))
            {
                var registeredManaCost = data.FirstOrDefault(d => d.Key == slot).Value;
                if (registeredManaCost != manaCost)
                {
                    // ..and the registered mana cost is different from its actual cost, it means the spell updated its manacost by leveling up, thus we will remove it and readd it, updated.
                    data.Remove(slot);
                    Logging.Log($"Preserve Mana List: Updated {slot}'s Manacost (Old: {registeredManaCost}), (New: {manaCost}).");
                    data.Add(slot, manaCost);
                }
            }
            // else if the spell is enabled but not registered..
            else if (menuOptionEnabled && !data.ContainsKey(slot))
            {
                // .. add it to the preservedataarray.
                data.Add(slot, manaCost);
                Logging.Log($"Preserve Mana List: Added {slot}, Cost: {manaCost}.");
            }

            var sum = data.Where(s => General.PreserveManaMenu.IsSlotEnabled(s.Key)).Sum(s => s.Value);
            if (sum <= 0 ||
                data.Keys.Contains(slot) ||
                LocalPlayer.Instance.MP - manaCost >= sum)
            {
                return;
            }

            args.Execute = false;
            Logging.Log(
                $"Preserve Mana Logic: Denied {slot} usage because mana would drop lower than the total mana to preserve ({LocalPlayer.Instance.MP} - {manaCost} < {sum}).");
        }
    }
}