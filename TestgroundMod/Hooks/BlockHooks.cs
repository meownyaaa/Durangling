using System.Runtime.InteropServices;
using Durangling;
using Minecraft.World.Levels.Blocks;

namespace TestgroundMod.Hooks;

public static unsafe class BlockHooks
{
    private static delegate* unmanaged<void*, void*, void*, float> TrueGetDestroySpeed = Block.Methods.GetDestroySpeed;

    public static void Attach()
    {
        void* i;

        i = TrueGetDestroySpeed;
        Detour.Attach(ref i, (delegate* unmanaged<void*, void*, void*, float>)&GetDestroySpeedHook);
    }

    public static void Detach()
    {
        void* i;

        i = TrueGetDestroySpeed;
        Detour.Detach(ref i, (delegate* unmanaged<void*, void*, void*, float>)&GetDestroySpeedHook);
    }

    [UnmanagedCallersOnly]
    private static float GetDestroySpeedHook(void* state, void* level, void* pos)
    {
        return 0.0f;
    }
}