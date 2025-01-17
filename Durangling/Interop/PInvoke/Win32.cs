using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Durangling.Interop.PInvoke;

public static unsafe partial class Win32
{
    [LibraryImport("kernel32", SetLastError = true)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial nint GetCurrentThread();
}