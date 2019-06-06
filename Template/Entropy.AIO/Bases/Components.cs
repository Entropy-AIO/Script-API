namespace Entropy.AIO.Bases
{
    using System.Collections.Generic;
    using SDK.Enumerations;
    using SDK.Extensions.Objects;
    using SDK.UI;
    using SDK.UI.Components;
    using SDK.UI.CustomComponents;
    using SharpDX;

    class Components
    {
        public static class General
        {
            public static readonly MenuBool OrbwalkerOnlyMenuBool = new MenuBool("orbwalker", "只开启走砍", false);

            public static readonly MenuBool CastOnSmallJungleMinionsMenuBool =
                new MenuBool("junglesmall", "清野对小野怪释放技能", false);

            public static readonly MenuBool StormrazorComboMenubool = new MenuBool("Combo", "连招", false);
            public static readonly MenuBool StormrazorLaneClearMenubool = new MenuBool("LaneClear", "清线", false);
            public static readonly MenuBool StormrazorHarassMenubool = new MenuBool("Harass", "骚扰", false);
            public static readonly MenuBool StormrazorLasthitMenubool = new MenuBool("Lasthit", "尾兵", false);

            public static readonly MenuBool IgnoreManaManagerBlue =
                new MenuBool("nomanagerifblue", "蓝BUFF时无视蓝量管理器", false);

            public static readonly MenuSlot PreserveManaMenu =
                new MenuSlot($"{LocalPlayer.Instance.CharName.ToLower()}.保留蓝量菜单", false, false);

            public static readonly MenuSlot PreserveSpellsMenu =
                new MenuSlot($"{LocalPlayer.Instance.CharName.ToLower()}.保留技能菜单",
                    false,
                    0,
                    0,
                    10);
        }

        public static class DrawingMenu
        {
            public static readonly MenuBool SharpDXMode = new MenuBool("sharpDXMode", "SharpDX 模式");
            public static readonly MenuSlider CircleThickness = new MenuSlider("CircleThickness", "线圈粗度", 1, 1, 10);

            public static readonly MenuColor ColorQ = new MenuColor("color1", "Q 颜色", new Color(255, 0, 0));
            public static readonly MenuColor ColorW = new MenuColor("color2", "W 颜色", new Color(0, 255, 0));
            public static readonly MenuColor ColorE = new MenuColor("color3", "E 颜色", new Color(0, 0, 255));
            public static readonly MenuColor ColorR = new MenuColor("color4", "R 颜色", new Color(255, 255, 255));
            public static readonly MenuColor ColorExtra = new MenuColor("color5", "额外颜色", new Color(0, 0, 0));

            public static readonly MenuBool QBool = new MenuBool($"{LocalPlayer.Instance.CharName}.QR", "绘制 Q", false);
            public static readonly MenuBool WBool = new MenuBool($"{LocalPlayer.Instance.CharName}.WR", "绘制 W", false);

            public static readonly MenuBool EBool = new MenuBool($"{LocalPlayer.Instance.CharName}.ER",
                "绘制 E",
                LocalPlayer.Instance.GetChampion() == Champion.Twitch ||
                LocalPlayer.Instance.GetChampion() == Champion.Kalista);

            public static readonly MenuBool RBool = new MenuBool($"{LocalPlayer.Instance.CharName}.RR", "绘制 R", false);

            public static readonly MenuBool QDamageBool =
                new MenuBool($"{LocalPlayer.Instance.CharName}.QD", "绘制 Q 伤害", false);

            public static readonly MenuBool WDamageBool =
                new MenuBool($"{LocalPlayer.Instance.CharName}.WD", "绘制 W 伤害", false);

            public static readonly MenuBool EDamageBool = new MenuBool($"{LocalPlayer.Instance.CharName}.ED",
                "绘制 E 伤害",
                LocalPlayer.Instance.GetChampion() == Champion.Twitch ||
                LocalPlayer.Instance.GetChampion() == Champion.Kalista);

            public static readonly MenuBool RDamageBool =
                new MenuBool($"{LocalPlayer.Instance.CharName}.RD", "绘制 R 伤害", false);

            public static readonly MenuSliderBool AutoDamageSliderBool =
                new MenuSliderBool($"{LocalPlayer.Instance.CharName}.autos", "包含 X 下普攻伤害", false, 1, 1, 10);
        }

        public static class Gapcloser
        {
            public static Dictionary<string, Menu> AntiGapcloserSpellSlot = new Dictionary<string, Menu>();
            public static Dictionary<string, Menu> EnemyChampionName = new Dictionary<string, Menu>();
            public static Dictionary<string, MenuBool> EnemySpell = new Dictionary<string, MenuBool>();
        }
    }
}