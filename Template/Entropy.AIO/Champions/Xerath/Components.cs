namespace Entropy.AIO.Champions.Xerath
{
    using SDK.UI.Components;
    using SDK.UI.CustomComponents;

    public static class Components
    {
        public static class ComboMenu
        {
            public static readonly MenuBool QBool = new MenuBool("comboQ", "使用 Q");
            public static readonly MenuBool WBool = new MenuBool("comboW", "使用 W");
            public static readonly MenuBool EBool = new MenuBool("comboE", "使用 E");

            public static readonly MenuKeyBind ESemiAutoKeyBind =
                new MenuKeyBind("esemiautomatic", "半自动-E", WindowMessageWParam.E, KeybindType.Hold);

            public static readonly MenuWhitelist EWhitelist = new MenuWhitelist("E 白名单", MenuWhitelistType.Enemies, true);
            public static readonly MenuSlider    QCharge    = new MenuSlider("QCharge", "Q 额外距离", 0, 0, 200);
        }

        public static class RSettings
        {
            public static readonly MenuBool RBool = new MenuBool("comboR", "使用 R");
            public static readonly MenuList RMode = new MenuList("RMode", "R 模式", new[] {"正常", "自定义延迟", "发射按键"});

            public static readonly MenuKeyBind RSemiAutoKeyBind =
                new MenuKeyBind("ontap", "发射按键", WindowMessageWParam.T, KeybindType.Hold);

            public static readonly MenuSlider RDelay     = new MenuSlider("RDelay", "R发射间隔延迟", 0, 0, 1500);
            public static readonly MenuBool   PingOnKill = new MenuBool("PingOnKill", "提示可击杀目标 (本地)");
            public static readonly MenuBool   FocusMouse = new MenuBool("focusmouse", "集火鼠标附近目标", true);
            public static readonly MenuSlider MouseRange = new MenuSlider("mouseRange", "鼠标半径", 700, 300, 1500);
        }

        public static class HarassMenu
        {
            public static readonly MenuBool QBool = new MenuBool("harassQ", "使用 Q");
            public static readonly MenuBool WBool = new MenuBool("harassW", "使用 W");
        }

        public static class KillstealMenu
        {
            public static readonly MenuBool QBool = new MenuBool("killstealQ", "使用 Q");
            public static readonly MenuBool WBool = new MenuBool("killstealW", "使用 W");
            public static readonly MenuBool EBool = new MenuBool("killstealE", "使用 E", false);
        }


        public static class LaneClearMenu
        {
            public static readonly MenuKeyBind farmKey =
                new MenuKeyBind("farmKey", "技能清线开关", WindowMessageWParam.L, KeybindType.Toggle);

            public static readonly MenuBool       QBool = new MenuBool("farmQ", "Q 清线");
            public static readonly MenuSliderBool hitsQ = new MenuSliderBool("hitsQ", " ^- 如果命中 X 小兵", true, 3, 1, 6);
            public static readonly MenuBool       WBool = new MenuBool("farmW", "W 清线");
            public static readonly MenuSliderBool hitsW = new MenuSliderBool("hitsW", " ^- 如果命中 X 小兵", true, 3, 1, 6);
        }

        public static class JungleClearMenu
        {
            public static readonly MenuBool QBool = new MenuBool("farmQ", "Q 清野");
            public static readonly MenuBool WBool = new MenuBool("farmW", "W 清野");
            public static readonly MenuBool EBool = new MenuBool("farmE", "E 清野");
        }

        public static class GapCloserMenu
        {
            public static readonly MenuBool      EBool      = new MenuBool("enabled", "启用");
            public static readonly MenuAntiSpell EGapcloser = new MenuAntiSpell("防突进", MenuAntiType.Gapcloser);
        }

        public static class InterrupterMenu
        {
            public static readonly MenuBool EBool = new MenuBool("enabled", "启用");

            public static readonly MenuAntiSpell EInterrupter =
                new MenuAntiSpell("技能打断", MenuAntiType.Interrupter);
        }

        public static class DrawingMenu
        {
            public static readonly MenuBool QTriangles = new MenuBool("QTriangles", "显示 Q 蓄力特效", false);

            public static readonly MenuBool RMinimapRange = new MenuBool("rminimap", "小地图显示 R 范围");
        }
    }
}