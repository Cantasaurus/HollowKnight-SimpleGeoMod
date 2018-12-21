using Modding;

namespace SimpleGeoMod
{
    public class SimpleGeoMod : Mod
    {
        public static PlayerData pd;
        public static SimpleGeoMod Instance;

        public override void Initialize()
        {
            Instance = this;
            Instance.LogDebug("Initializing GeoEditor");
            //Have to have two methods that do essentially the same as there are different hooks that need different 
            //parameters for if the user starts a new game or just loads a save game. 
            ModHooks.Instance.NewGameHook += injectMod;
            ModHooks.Instance.SavegameLoadHook += injectMod;
        }

        //Inject gui mod.
        public void injectMod(int id)
        {
            if (pd == null && PlayerData.instance != null)
            {
                pd = PlayerData.instance;
                //Test to see if playerdata instance was reachable as early as savegameloadhook. 
                pd.geo = 20000;
            }
        }

        public void injectMod()
        {
            if (pd == null && PlayerData.instance != null)
            {
                pd = PlayerData.instance;
                //Test to see if playerdata instance was reachable as early as savegameloadhook.
                pd.geo = 20000;
            }
        }
    }
}
