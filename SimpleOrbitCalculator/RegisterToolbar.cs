using UnityEngine;
using ToolbarControl_NS;


namespace SimpleOrbitCalculator
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class RegisterToolbar : MonoBehaviour
    {
        void Awake()
        {
            Debug.Log("SOC: RegisterToolbar");
            ToolbarControl.RegisterMod(SimpleOrbitCalculatorController.MODID, SimpleOrbitCalculatorController.MODNAME);
        }
    }
}