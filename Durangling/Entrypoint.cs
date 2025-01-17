using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Durangling.Classes;
using Durangling.Hooks;
using Durangling.Interop;
using Durangling.Interop.PInvoke;

namespace Durangling;

[SupportedOSPlatform("windows10.0")]
public static unsafe class Entrypoint
{
    private static bool _isFirstInvoke = true;

    [UnmanagedCallersOnly(EntryPoint = "DllMain", CallConvs = [typeof(CallConvStdcall)])]
    public static bool DllMain(nint hModule, uint ul_reason_for_call, void* lpReserved)
    {
        switch (ul_reason_for_call)
        {
            case 1: // DLL_PROCESS_ATTACH
                Detour.RestoreAfterWith();
                Detour.TransactionBegin();
                Detour.UpdateThread(Win32.GetCurrentThread());
                Mod.AttachHooks();
                Detour.TransactionCommit();
                break;
            case 0: // DLL_PROCESS_DETACH
                Detour.RestoreAfterWith();
                Detour.TransactionBegin();
                Detour.UpdateThread(Win32.GetCurrentThread());
                Mod.DetachHooks();
                Detour.TransactionCommit();
                break;
        }

        Mod.OnDurangoInvoke(hModule, ul_reason_for_call, lpReserved);
        return true;
    }
}