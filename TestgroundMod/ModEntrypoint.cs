using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Durangling;

namespace TestgroundMod;

public static unsafe class ModEntrypoint
{
    private static readonly TestgroundMod Instance = new();

    [UnmanagedCallersOnly(EntryPoint = "DllMain", CallConvs = [typeof(CallConvStdcall)])]
    public static bool DllMain(nint hinstDLL, uint fdwReason, void* lpvReserved)
    {
        return DuranglingEntrypoint.Initialize([Instance], fdwReason);
    }
}