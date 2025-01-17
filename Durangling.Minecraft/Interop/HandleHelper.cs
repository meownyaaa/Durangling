using System.Diagnostics;

namespace Durangling.Minecraft.Interop;

public static unsafe class HandleHelper
{
    public const long BaseAddress = 0x140000000;
    
    public static void* GetMainModuleHandle(long address)
    {
        Process process = Process.GetCurrentProcess();
        Debug.Assert(process.MainModule != null);
        return (void*)(process.MainModule!.BaseAddress + (address - BaseAddress));
    }
}