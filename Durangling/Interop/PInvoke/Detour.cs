using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Durangling.Interop.PInvoke;

public static unsafe partial class Detour
{
    private const string LibName = "detours";
    
    [LibraryImport(LibName, EntryPoint = "DetourIsHelperProcess")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsHelperProcess();

    [LibraryImport(LibName, EntryPoint = "DetourRestoreAfterWith")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial long RestoreAfterWith();
    
    [LibraryImport(LibName, EntryPoint = "DetourUpdateThread")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial long UpdateThread(nint hThread);
    
    [LibraryImport(LibName, EntryPoint = "DetourTransactionBegin")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial long TransactionBegin();
    
    [LibraryImport(LibName, EntryPoint = "DetourTransactionCommit")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial long TransactionCommit();
    
    [LibraryImport(LibName, EntryPoint = "DetourAttach")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial long Attach(ref void* ppPointer, void* pDetour);
    
    [LibraryImport(LibName, EntryPoint = "DetourDetach")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial long Detach(ref void* ppPointer, void* pDetour);
}