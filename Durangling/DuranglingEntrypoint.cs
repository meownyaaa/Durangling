using System.Runtime.Versioning;
using Windows.Win32;
using Durangling.Modding;
using Durangling.Utilities;

namespace Durangling;

[SupportedOSPlatform("windows10.0")]
public static unsafe class DuranglingEntrypoint
{
    private const int DLL_PROCESS_ATTACH = 1;
    private const int DLL_PROCESS_DETACH = 0;
    
    public static bool Main(ReadOnlySpan<ModBase> mods, nint hinstDLL, uint fdwReason, void* lpvReserved)
    {
        if (fdwReason is not (DLL_PROCESS_ATTACH or DLL_PROCESS_DETACH))
        {
            return true;
        }
        
        foreach (ModBase mod in mods)
        {
            Logger.Write(Logger.Level.Debug, $"{(fdwReason == DLL_PROCESS_ATTACH ? "Loading" : "Unloading")} {mod.Details.Name} ({mod.Details.Version})");
            switch (fdwReason)
            {
                case DLL_PROCESS_ATTACH:
                    mod.Initialize();
                    Logger.Write(Logger.Level.Debug, "Finished initializing");
                    break;
            
                case DLL_PROCESS_DETACH:
                    mod.Dispose();
                    Logger.Write(Logger.Level.Debug, "Finished disposing");
                    break;
            }
        }

        return true;
    }
}