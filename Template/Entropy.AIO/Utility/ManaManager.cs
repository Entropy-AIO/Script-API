namespace Entropy.AIO.Utility
{
    using Bases;
    using SDK.Extensions.Objects;
    using SDK.UI;
    using static Bases.Components;

    static class ManaManager
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The minimum mana needed to cast the Spell from the 'slot' SpellSlot.
        /// </summary>
        public static int GetNeededMana(SpellSlot slot, MenuComponent menuComponent)
        {
            var ignoreManaManagerMenu = General.IgnoreManaManagerBlue;
            if (ignoreManaManagerMenu != null &&
                LocalPlayer.Instance.HasBuff("crestoftheancientgolem") &&
                ignoreManaManagerMenu.Enabled)
            {
                return 0;
            }

            var cost = ChampionBase.GetSpellFromSlot(slot).Cost();
            return (int) (menuComponent.Value + cost / LocalPlayer.Instance.MaxMP * 100);
        }

        /// <summary>
        ///     The minimum health needed to cast the Spell from the 'slot' SpellSlot.
        /// </summary>
        public static int GetNeededHealth(SpellSlot slot, MenuComponent value)
        {
            var cost = ChampionBase.GetSpellFromSlot(slot).Cost();
            return (int) (value.Value + cost / LocalPlayer.Instance.MaxHP * 100);
        }

        #endregion
    }
}