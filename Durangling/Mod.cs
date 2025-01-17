using Durangling.Hooks;

namespace Durangling;

public static unsafe class Mod
{
    public static void AttachHooks()
    {
        Logger.Write(Logger.Level.Debug, "Attaching hooks...");
        BlockHooks.Attach();
        Logger.Write(Logger.Level.Debug, "Yeah!");
    }

    public static void DetachHooks()
    {
        Logger.Write(Logger.Level.Debug, "Detaching hooks...");
        BlockHooks.Detach();
        Logger.Write(Logger.Level.Debug, "Yeah!");
    }
    
    public static void OnDurangoInvoke(nint hModule, uint ul_reason_for_call, void* lpReserved)
    {
        Logger.Write(Logger.Level.Debug, "Invoked by WinDurango");
    }
}