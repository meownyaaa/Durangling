using System.Runtime.InteropServices;
using Durangling;
using Minecraft.World.Blocks;

namespace TestgroundMod.Hooks;

using unsafe GetMiningSpeed = delegate* unmanaged<void*, void*, void*, float>;

public static unsafe class BlockHooks
{
    private static GetMiningSpeed TrueGetMiningSpeed = Block.NativeMethods.GetMiningSpeed;

    public static void Attach()
    {
        Detour.Attach(TrueGetMiningSpeed, (GetMiningSpeed)(&GetMiningSpeedHook));
    }

    public static void Detach()
    {
        Detour.Detach(TrueGetMiningSpeed, (GetMiningSpeed)(&GetMiningSpeedHook));
    }

    [UnmanagedCallersOnly]
    private static float GetMiningSpeedHook(void* state, void* level, void* pos)
    {
        return 0.0f;
    }
}