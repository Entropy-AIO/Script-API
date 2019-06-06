using System.Reflection;

namespace Entropy.AIO.Bases
{
    using SDK.UI;
    using SDK.UI.Components;
    using SDK.UI.PermaShow;
    using static Components;

    static class MenuBase
    {
        public static Menu Root { get; private set; }
        public static Menu General { get; private set; }
        public static Menu Drawings { get; private set; }
        public static Menu Champion { get; private set; }
        public static Menu Gapcloser { get; set; }
        public static Menu Interrupter { get; set; }

        
        public static void Initialize()
        {
            General = new Menu("general", "基础菜单")
            {
                Components.General.CastOnSmallJungleMinionsMenuBool,

                new Menu("stormrazor", "岚切菜单")
                {
                    new MenuSeperator("stormsep", "充能前停止普攻:"),
                    Components.General.StormrazorComboMenubool,
                    Components.General.StormrazorLaneClearMenubool,
                    Components.General.StormrazorHarassMenubool,
                    Components.General.StormrazorLasthitMenubool
                }
            };

            Components.General.PreserveManaMenu.Attach(General);
            Components.General.PreserveSpellsMenu.Attach(General);

            Drawings = new Menu("Drawings", "线圈菜单")
            {
                DrawingMenu.SharpDXMode,
                DrawingMenu.CircleThickness,
                DrawingMenu.ColorQ,
                DrawingMenu.ColorW,
                DrawingMenu.ColorE,
                DrawingMenu.ColorR,
                DrawingMenu.ColorExtra
            };

            //This is for each champion have its configuration file
            Root = new Menu("aio", "弑神合集", true)
            {
                Components.General.OrbwalkerOnlyMenuBool.SetToolTip("按F7进行重载"),
                General,
                Drawings
            };

            Champion = new Menu(LocalPlayer.Instance.CharName.ToLower(), LocalPlayer.Instance.CharName);

            if (LocalPlayer.Instance.MaxMP >= 200)
            {
                General.Add(Components.General.IgnoreManaManagerBlue);
            }

            Root.Add(new MenuSeperator("sep1"));

            Root.Add(Champion);

            Root.Permashow($"弑神 - {LocalPlayer.Instance.CharName}", true);

            Root.Attach();
        }
    }
}