namespace Entropy.AIO.Champions.Xerath
{
    using System;
    using System.Collections.Generic;
    using Bases;
    using Misc;
    using SDK.Extensions.Geometry;
    using SDK.Geometry;
    using SDK.Rendering;
    using SDK.Spells;
    using SDK.TS;
    using SDK.Utils;
    using SharpDX;
    using SharpDX.Direct3D9;
    using static Bases.ChampionBase;
    using static Components;

    class Drawings : DrawingBase
    {
        private static readonly Font RFont = FontFactory.CreateNewFont(30, "Arial Black", FontWeight.Heavy);


        private static readonly Random rnd = new Random();

        private static readonly Color[] Colors = {Color.White, Color.LightBlue};

        public Drawings(params Spell[] spells)
        {
            this.Spells                   =  spells;
            TacticalMapRendering.OnRender += OnTacticalMapRender;
        }

        protected override void OnRender(EntropyEventArgs args)
        {
            base.OnRender(args);
            if (Q.IsCharging && DrawingMenu.QTriangles.Enabled)
            {
                var target = TargetSelector.GetBestTarget(Q.ChargedMaxRange);
                if (target != null)
                {
                    if (Game.ClockTime > QDrawing.Create)
                    {
                        QDrawing.Create = Game.ClockTime + 0.07f;
                        var r1    = rnd.NextFloat(0, 1);
                        var r2    = rnd.NextFloat(0, 1);
                        var r3    = rnd.NextFloat(0, 1);
                        var speed = Math.Max(1500f, r1 * 5000f);
                        var angle = r2 * (Math.PI * 2);
                        var range = Math.Max(333f, r3 * 444f);

                        var missile = new QDrawing(target,
                                                   speed,
                                                   new Vector2((float) (target.Position.X + range * Math.Cos(angle)),
                                                               (float) (target.Position.Z + range * Math.Sin(angle))),
                                                   target.Position.Y + 122f,
                                                   Game.ClockTime    + 1f,
                                                   Colors[rnd.Next(0, 2)]);

                        QDrawing.Missile.Add(missile);
                    }

                    var Timer = Game.ClockTime - QDrawing.LastDraw;
                    for (var i = 0; i < QDrawing.Missile.Count; i++)
                    {
                        var missile = QDrawing.Missile[i];
                        var p       = new Vector2(missile.Object.Position.X, missile.Object.Position.Z);

                        if (p.Distance(missile.Position) < 50 || Game.ClockTime > missile.Time)
                        {
                            QDrawing.Missile.Remove(missile);
                        }

                        missile.Y = Math.Max(missile.Object.Position.Y, missile.Y - Timer * 777f);
                        missile.Position =
                            missile.Position.Extend(p, Timer * 100f * missile.Speed / missile.Position.Distance(p));
                        new Triangle(new Vector3(missile.Position.X + 25,
                                                 missile.Y,
                                                 missile.Position.Y),
                                     new Vector3(missile.Position.X, missile.Y                     - 15, missile.Position.Y),
                                     new Vector3(missile.Position.X, missile.Y, missile.Position.Y + 25)).
                            Render(missile.Color, 2);
                    }

                    QDrawing.LastDraw = Game.ClockTime;
                }
            }

            if (Definitions.IsChannellingR && RSettings.FocusMouse.Enabled)
            {
                CircleRendering.Render(Color.White, RSettings.MouseRange.Value, Hud.CursorPositionUnclipped, 2);
            }
        }

        private static void OnTacticalMapRender()
        {
            if (DrawingMenu.RMinimapRange.Enabled)
            {
                TacticalMapRendering.RenderCircle(Color.White, LocalPlayer.Instance.Position, R.Range);
            }
        }

        public class QDrawing
        {
            public static List<QDrawing> Missile = new List<QDrawing>();

            public QDrawing(AIBaseClient obj, float speed, Vector2 pos, float y, float t, Color color)
            {
                this.Object   = obj;
                this.Speed    = speed;
                this.Position = pos;
                this.Y        = y;
                this.Time     = t;
                this.Color    = color;
            }

            public static float LastDraw { get; set; }
            public static float Create   { get; set; }

            public AIBaseClient Object   { get; set; }
            public float        Speed    { get; set; }
            public Vector2      Position { get; set; }
            public float        Y        { get; set; }
            public Color        Color    { get; set; }
            public float        Time     { get; set; }
        }
    }
}