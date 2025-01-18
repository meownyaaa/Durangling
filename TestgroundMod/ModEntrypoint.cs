using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Durangling;

namespace TestgroundMod;

public static unsafe class ModEntrypoint
{
    [UnmanagedCallersOnly(EntryPoint = "DllMain", CallConvs = [typeof(CallConvStdcall)])]
    public static bool DllMain(nint hinstDLL, uint fdwReason, void* lpvReserved)
    {
        return DuranglingEntrypoint.Initialize([new TestgroundMod()], fdwReason);
    }
}