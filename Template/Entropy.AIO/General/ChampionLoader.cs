using Entropy.AIO.Champions.Annie;
using Entropy.AIO.Champions.Xerath;
using Entropy.AIO.Champions.Ashe;

using Entropy.SDK.Enumerations;
using Entropy.SDK.Extensions.Objects;

namespace Entropy.AIO.General
{
    using System;
    using System.Reflection;
    using ToolKit;
    using ToolKit.Enumerations;
    using static Bases.Components;

    static class ChampionLoader
    {
        //Version: MajorPatch.ChampionAdded.FeatureAdded.BugFix
        public const string VERSION = "0.0.0.0";

        //Commit: ChampName:Description(day/month/year)
        //If more than 1 champ use NEW: Champion1, Champion2 Added!(day/month/year)
        private const string Commit = "Example Purpose";

        public static void Initialize()
        {
            if (General.OrbwalkerOnlyMenuBool.Enabled)
            {
                GameConsole.Print(
                    $"<font color = \"#1a8cff\">AIO Version </font><font color = \"#FFFFFF\">{VERSION}</font><font color = \"#99ccff\"> - {Commit} </font><font color = \"#ff1a1a\">(Orbwalker Only)</font>");
                return;
            }


            try
            {
                var name = LocalPlayer.Instance.CharName;
                // Special Cases
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (name)
                {
                    case "Leblanc":
                        name = "LeBlanc";
                        break;
                }

                //var path = $"Entropy.AIO.Champions.{name}.{name}";
                //var type = Type.GetType(path, true);

                //Activator.CreateInstance(type);

                switch (LocalPlayer.Instance.GetChampion())
                {
                    case Champion.Ashe:
                        new Ashe();
                        break;
                    case Champion.Annie:
                        new Annie();
                        break;
                    case Champion.Xerath:
                        new Xerath();
                        break;
                    default:
                        Logging.Log($"AIO: {LocalPlayer.Instance.CharName} is not supported.", LogLevels.warning);
                        break;
                }

                GameConsole.Print("Template Loaded");

                /*GameConsole.Print(
                    $"<font color = \"#1a8cff\">AIO Version</font> <font color = \"#FFFFFF\">{VERSION}</font><font color = \"#99ccff\"> - {Commit}</font>");*/
            }
            catch (Exception e)
            {
                switch (e)
                {
                    case TargetInvocationException _:
                        Logging.Log($"AIO: Error occurred while trying to load {LocalPlayer.Instance.CharName}.",
                            LogLevels.error);
                        e.ToolKitLog();
                        break;
                    case TypeLoadException _:
                        Logging.Log($"AIO: {LocalPlayer.Instance.CharName} is not supported.", LogLevels.warning);
                        break;
                }
            }
        }
    }
}
