namespace Entropy.AIO.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bases;
    using SDK.Caching;
    using SDK.Damage;
    using SDK.Enumerations;
    using SDK.Extensions;
    using SDK.Extensions.Geometry;
    using SDK.Extensions.Objects;
    using SDK.Spells;
    using SDK.TS;
    using SDK.UI;
    using SDK.UI.Components;
    using SDK.UI.CustomComponents;

    static class Utilities
    {
        public static void AddAllSpellMenu(this Menu menu, bool onlyAntiMelees = false)
        {
            foreach (var enemy in ObjectCache.EnemyHeroes.Where(enemy =>
                enemy.IsMelee || !onlyAntiMelees))
            {
                var subSpellMenu = new Menu(enemy.CharName.ToLower(), enemy.CharName);
                {
                    foreach (var spell in enemy.Spellbook.GetSpells().
                        Where(spell =>
                            spell.SpellData != null && spell.Slot == SpellSlot.Q ||
                            spell.Slot == SpellSlot.W ||
                            spell.Slot == SpellSlot.E ||
                            spell.Slot == SpellSlot.R))
                    {
                        subSpellMenu.Add(new MenuBool($"{enemy.CharName.ToLower()}.{spell.SpellData.Name.ToLower()}",
                            $"Slot: {spell.Slot} ({spell.SpellData.Name})",
                            false));
                    }
                }

                menu.Add(subSpellMenu);
            }
        }

        public static AIHeroClient GetSemiAutoTarget(
            this Spell spell,
            DamageType type,
            MenuWhitelist whitelist,
            float customRange = -1f)
        {
            var killableTarget = ObjectCache.EnemyHeroes.FirstOrDefault(
                e => e.IsValidTarget(customRange < 0 ? spell.Range : customRange) &&
                     whitelist.IsWhitelisted(e) &&
                     !Invulnerable.IsInvulnerable(e, false, spell.GetDamage(e)) &&
                     e.GetRealHealth(type) < spell.GetDamage(e));
            if (killableTarget != null)
            {
                return killableTarget;
            }

            var selectedTarget = TargetSelector.SelectedTarget;
            if (selectedTarget != null &&
                selectedTarget.IsValidTarget(spell.Range) &&
                whitelist.IsWhitelisted(selectedTarget) &&
                !Invulnerable.IsInvulnerable(selectedTarget, false, spell.GetDamage(selectedTarget)))
            {
                return selectedTarget;
            }

            var nearestTarget = ObjectCache.EnemyHeroes.Where(e => e.IsValidTarget(spell.Range) &&
                                                                   whitelist.IsWhitelisted(e) &&
                                                                   !Invulnerable.IsInvulnerable(
                                                                       e,
                                                                       false,
                                                                       spell.GetDamage(e))).
                MinBy(o => o.Distance(Hud.CursorPositionUnclipped));
            if (nearestTarget != null)
            {
                return nearestTarget;
            }

            return null;
        }

        #region Public Methods and Operators

        /// <returns>
        ///     true if the sender is a hero, a turret or an important jungle monster; otherwise, false.
        /// </returns>
        public static bool ShouldShieldAgainstSender(AIBaseClient sender)
        {
            return ObjectCache.EnemyHeroes.Contains(sender) ||
                   ObjectCache.EnemyTurrets.Contains(sender) ||
                   ObjectCache.LargeJungleMinions.Concat(ObjectCache.LegendaryJungleMinions).Contains(sender);
        }

        /// <summary>
        ///     The PreserveMana Dictionary.
        /// </summary>
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public static Dictionary<SpellSlot, int> PreserveManaData = new Dictionary<SpellSlot, int>();


        /// <summary>
        ///     Gets the mana cost of a spell using the ManaCostArray.
        /// </summary>
        /// <param name="slot">
        ///     The spellslot.
        /// </param>
        /// <returns>
        ///     The mana cost.
        /// </returns>
        public static int GetManaCost(this SpellSlot slot)
        {
            var spell = ChampionBase.GetSpellFromSlot(slot);
            if (spell == null || spell.Level == 0)
            {
                return 0;
            }

            return (int)spell.Cost();
        }

        /// <summary>
        ///     Gets the angle by 'degrees' degrees.
        /// </summary>
        /// <param name="degrees">
        ///     The angle degrees.
        /// </param>
        /// <returns>
        ///     The angle by 'degrees' degrees.
        /// </returns>
        public static float GetAngleByDegrees(float degrees)
        {
            return (float) (degrees * Math.PI / 180);
        }

        public static float RangeMultiplier(float range)
        {
            if (LocalPlayer.Instance.HasItem(ItemID.RapidFirecannon) &&
                LocalPlayer.Instance.GetBuffStacks("itemstatikshankcharge") == 100)
            {
                return Math.Min(range * 0.35f, 150);
            }

            return 0;
        }

        #endregion
    }
}