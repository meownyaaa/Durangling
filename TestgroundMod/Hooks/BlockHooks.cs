using System.Runtime.InteropServices;
using Durangling;
using Minecraft.World.Blocks;

namespace TestgroundMod.Hooks;

public static unsafe class BlockHooks
{
    private static delegate* unmanaged<void*, void*, void*, float> TrueGetMiningSpeed = Block.NativeMethods.GetMiningSpeed;

    public static void Attach()
    {
        void* i;

        i = TrueGetMiningSpeed;
        Detour.Attach(ref i, (delegate* unmanaged<void*, void*, void*, float>)&GetMiningSpeedHook);
    }

    public static void Detach()
    {
        void* i;

        i = TrueGetMiningSpeed;
        Detour.Detach(ref i, (delegate* unmanaged<void*, void*, void*, float>)&GetMiningSpeedHook);
    }

    [UnmanagedCallersOnly]
    private static float GetMiningSpeedHook(void* state, void* level, void* pos)
    {
        return 0.0f;
    }
}