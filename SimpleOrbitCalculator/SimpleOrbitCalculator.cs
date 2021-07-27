using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSP.UI.Screens;
using UnityEngine;
using ToolbarControl_NS;

namespace SimpleOrbitCalculator
{
    [KSPAddon(KSPAddon.Startup.SpaceCentre, true)]
    public class SimpleOrbitCalculatorController : MonoBehaviour
    {
        /// <summary>
        /// The plugin's name.
        /// </summary>
        public const string PluginName = "Simple Orbit Calculator";

        /// <summary>
        /// The plugin's directory under GameData.
        /// </summary>
        public const string PluginDirectoryName = "SimpleOrbitCalculator";

        /// <summary>
        /// The stock toolbar icon.
        /// </summary>
        private const string PluginIconButtonStock = "icon_button_stock";

        /// <summary>
        /// The Blizzy's toolbar icon.
        /// </summary>
        private const string PluginIconButtonBlizzy = "icon_button_blizzy";

        /// <summary>
        /// The ToolbarController object that is created.
        /// </summary>
        private static ToolbarControl toolbarControl = null;

        /// <summary>
        /// The calculator object that is created.
        /// </summary>
        private static GameObject calculator;

        internal const string MODID = "SOC_NS";
        internal const string MODNAME = PluginName;


        /// <summary>
        /// Called when the script is loaded.
        /// </summary>
        public void Start()
        {
            if (toolbarControl == null)
            {
                Debug.Log("SOC: SimpleorbitCalculator.Awake");

                toolbarControl = gameObject.AddComponent<ToolbarControl>();
                toolbarControl.AddToAllToolbars(OnAppLaunchToggleOn, OnAppLaunchToggleOff,
                   ApplicationLauncher.AppScenes.FLIGHT | ApplicationLauncher.AppScenes.MAPVIEW | ApplicationLauncher.AppScenes.SPACECENTER
                        | ApplicationLauncher.AppScenes.SPH | ApplicationLauncher.AppScenes.TRACKSTATION | ApplicationLauncher.AppScenes.VAB,
                    MODID,
                    "socButton",
                    String.Format("{0}/Textures/{1}", PluginDirectoryName, PluginIconButtonStock),
                     String.Format("{0}/Textures/{1}", PluginDirectoryName, PluginIconButtonBlizzy),
                    MODNAME
                );
            }
            DontDestroyOnLoad(this);
        }


        /// <summary>
        /// Sets the window as open. Should only be called by a button.
        /// </summary>
        private void OnAppLaunchToggleOn()
        {
            calculator = new GameObject("SOCWindow", typeof(CalculatorWindow));
        }

        /// <summary>
        /// Sets the windows as closed. Should only be called by a button.
        /// </summary>
        private void OnAppLaunchToggleOff()
        {
            Destroy(calculator);
        }

        /// <summary>
        /// Allows outside objects to turn the toolbar icon off.
        /// </summary>
        public static void SetApplauncherButtonFalse()
        {
            toolbarControl.SetFalse();
        }
    }
}
