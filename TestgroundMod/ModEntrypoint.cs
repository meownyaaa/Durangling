using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Durangling;

namespace TestgroundMod;

[SupportedOSPlatform("windows10.0")]
public static unsafe class ModEntrypoint
{
    [UnmanagedCallersOnly(EntryPoint = "DllMain", CallConvs = [typeof(CallConvStdcall)])]
    public static bool DllMain(nint hinstDLL, uint fdwReason, void* lpvReserved)
    {
        return DuranglingEntrypoint.Main([new TestgroundMod()], hinstDLL, fdwReason, lpvReserved);
    }
}