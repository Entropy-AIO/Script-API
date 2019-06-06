namespace Entropy.AIO.Bases
{
    using System.Collections.Generic;
    using System.Linq;
    using SDK.Caching;
    using SDK.Damage;
    using SDK.Events;
    using SDK.Extensions.Objects;
    using SDK.Rendering;
    using SDK.Spells;
    using SDK.UI.Components;
    using SharpDX;

    abstract class DrawingBase
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        // ReSharper disable once MemberCanBeProtected.Global
        public static Dictionary<AIBaseClient, float> DamageDictionary = new Dictionary<AIBaseClient, float>();

        protected DrawingBase()
        {
            Renderer.OnRender += OnRender;
            new CustomTick(100).OnTick += OnCustomTick;
            Renderer.OnEndScene += OnEndScene;
        }

        protected Spell[] Spells { get; set; }

        private static MenuBool GetMenuBoolOf(SpellSlot slot)
        {
            MenuBool menuBool = null;

            switch (slot)
            {
                case SpellSlot.Q:
                    menuBool = Components.DrawingMenu.QBool;
                    break;
                case SpellSlot.W:
                    menuBool = Components.DrawingMenu.WBool;
                    break;
                case SpellSlot.E:
                    menuBool = Components.DrawingMenu.EBool;
                    break;
                case SpellSlot.R:
                    menuBool = Components.DrawingMenu.RBool;
                    break;
            }

            return menuBool;
        }

        private static MenuBool GetDamageMenuBoolOf(SpellSlot slot)
        {
            MenuBool menuBool = null;

            switch (slot)
            {
                case SpellSlot.Q:
                    menuBool = Components.DrawingMenu.QDamageBool;
                    break;
                case SpellSlot.W:
                    menuBool = Components.DrawingMenu.WDamageBool;
                    break;
                case SpellSlot.E:
                    menuBool = Components.DrawingMenu.EDamageBool;
                    break;
                case SpellSlot.R:
                    menuBool = Components.DrawingMenu.RDamageBool;
                    break;
            }

            return menuBool;
        }

        protected virtual void OnRender(EntropyEventArgs args)
        {
            foreach (var spell in this.Spells)
            {
                var menuBoolOfSpell = GetMenuBoolOf(spell.Slot);

                if (menuBoolOfSpell == null || !menuBoolOfSpell.Enabled)
                {
                    continue;
                }

                var color = Color.White;

                switch (spell.Slot)
                {
                    case SpellSlot.Q:
                        color = Components.DrawingMenu.ColorQ.Color;
                        break;
                    case SpellSlot.W:
                        color = Components.DrawingMenu.ColorW.Color;
                        break;
                    case SpellSlot.E:
                        color = Components.DrawingMenu.ColorE.Color;
                        break;
                    case SpellSlot.R:
                        color = Components.DrawingMenu.ColorR.Color;
                        break;
                }

                DrawCircle(LocalPlayer.Instance, spell.Range, color);
            }
        }

        protected virtual void OnCustomTick(EntropyEventArgs args)
        {
            if (Components.DrawingMenu.SharpDXMode.Enabled)
            {
                Components.DrawingMenu.CircleThickness.Visible = true;
            }
            else
            {
                Components.DrawingMenu.CircleThickness.Visible = false;
            }

            foreach (var enemy in ObjectCache.EnemyHeroes)
            {
                if (enemy.IsValidTarget())
                {
                    var damage = this.Spells.Where(spell => GetDamageMenuBoolOf(spell.Slot).Enabled).
                        Sum(spell => spell.GetDamage(enemy));

                    if (Components.DrawingMenu.AutoDamageSliderBool.Enabled)
                    {
                        damage += Components.DrawingMenu.AutoDamageSliderBool.Value *
                                  LocalPlayer.Instance.GetAutoAttackDamage(enemy);
                    }

                    DamageDictionary[enemy] = damage;
                }
                else
                {
                    DamageDictionary[enemy] = 0;
                }
            }
        }

        private static void OnEndScene(EntropyEventArgs args)
        {
            foreach (var element in DamageDictionary.Where(e => e.Value > 0))
            {
                DrawDamage(element.Key, element.Value);
            }
        }

        protected static void DrawCircle(AIBaseClient obj, float radius, Color color)
        {
            if (Components.DrawingMenu.SharpDXMode.Enabled)
            {
                CircleRendering.Render(color, radius, obj, Components.DrawingMenu.CircleThickness.Value);
            }
            else
            {
                Renderer.DrawCircularRangeIndicator(LocalPlayer.Instance.Position, radius, color);
            }
        }

        protected static void DrawCircle(Vector3 worldPosition, float radius, Color color)
        {
            if (Components.DrawingMenu.SharpDXMode.Enabled)
            {
                CircleRendering.Render(color, radius, 1f, false, worldPosition);
            }
            else
            {
                Renderer.DrawCircularRangeIndicator(worldPosition, radius, color);
            }
        }

        private static void DrawDamage(AIBaseClient target, float damage, DamageType damageType = DamageType.Mixed)
        {
            DamageIndicatorRendering.Render(target, damage, damageType);
        }
    }
}