using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Durangling;
using Durangling.Utilities;
using Minecraft.Client;
using Minecraft.Client.MiniGames;

namespace TestgroundMod.Hooks;

using unsafe Tick = delegate* unmanaged[Thiscall]<Minecraft.Client.Minecraft.Native*, byte, byte, void>;

public static unsafe class MinecraftHooks
{
    private static void* TrueTick = Minecraft.Client.Minecraft.NativeMethods.Tick;

    private static int _ticks;
    private static int _seconds;
    
    public static void Attach()
    {
        Detour.Attach(ref TrueTick, (Tick)(&TickHook));
    }

    public static void Detach()
    {
        Detour.Detach(ref TrueTick, (Tick)(&TickHook));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvThiscall)])]
    private static void TickHook(Minecraft.Client.Minecraft.Native* self, byte p1, byte p2)
    {
        _ticks++;
        if (_ticks % 20 == 0)
        {
            _seconds++;
            Logger.Write(Logger.Level.Info, $"{_seconds} seconds since first tick");
        }
        
        ((Tick)TrueTick)(self, p1, p2);
    }
}