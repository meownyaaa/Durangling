using System.Diagnostics.CodeAnalysis;
using Windows.Win32;

namespace Durangling.Modding;

public abstract class ModBase
{
    public readonly ModDetails Details;

    protected ModBase(ModDetails details)
    {
        Details = details;
    }

    [SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
    public virtual void Initialize()
    {
        Detour.RestoreAfterWith();
        Detour.TransactionBegin();
        Detour.UpdateThread(PInvoke.GetCurrentThread());
        AttachHooks();
        Detour.TransactionCommit();
    }

    [SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
    public virtual void Dispose()
    {
        Detour.TransactionBegin();
        Detour.UpdateThread(PInvoke.GetCurrentThread());
        DetachHooks();
        Detour.TransactionCommit();
    }

    protected virtual void AttachHooks()
    {
    }

    protected virtual void DetachHooks()
    {
    }
}