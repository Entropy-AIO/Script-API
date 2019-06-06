namespace Entropy.AIO.Champions.Annie
{
    using System.Linq;
    using Bases;
    using SDK.Extensions.Geometry;
    using SDK.Geometry;
    using SDK.Rendering;
    using SDK.Spells;
    using SharpDX;
    using static Spells;
    using static Bases.ChampionBase;
    using static Bases.Components.DrawingMenu;
    using static Components.DrawsMenu;
    using static Misc.Definitions;

    class Drawings : DrawingBase
    {
        public Drawings(params Spell[] spells)
        {
            this.Spells       =  spells;
            Renderer.OnRender += OnRender;
        }

        protected override void OnRender(EntropyEventArgs args)
        {
            base.OnRender(args);

            if (WCone.Enabled && W.Ready)
            {
                var init      = LocalPlayer.Instance.Position;
                var end       = LocalPlayer.Instance.Position.Extend(Hud.CursorPositionUnclipped, W.Range);
                var direction = (end - init).Normalized();
                var sector    = new Sector(init, direction, 55f, W.Range, 9u);
                sector.Render(ColorW.Color);
            }

            if (FlashRRangeBool.Enabled && R.Ready && Flash.Ready)
            {
                DrawCircle(LocalPlayer.Instance, W.Range + Flash.Range, ColorExtra.Color);
            }

            TextRendering.Render($"{R.ToggleState}", Color.Red, LocalPlayer.Instance.Position);

            if (BurstTarget != null)
            {
                TextRendering.Render("Burst Target", Color.GreenYellow, BurstTarget.Position);
            }

            if (BurstableEnemiesBool.Enabled && R.Ready)
            {
                if (!BurstableEnemies.Any())
                {
                    return;
                }

                foreach (var enemy in BurstableEnemies.Where(x => x != null && x.IsValid))
                {
                    TextRendering.Render("Killable", ColorExtra.Color, enemy.Position);
                }
            }
        }
    }
}