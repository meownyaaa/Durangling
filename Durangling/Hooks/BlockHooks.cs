using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Durangling.Interop.PInvoke;
using Durangling.Minecraft.Classes;

namespace Durangling.Hooks;

public static unsafe class BlockHooks
{
    private static delegate* unmanaged<nint, nint, nint, float> TrueGetDestroySpeed = Block.Methods.GetDestroySpeed;

    public static void Attach()
    {
        void* i;

        i = TrueGetDestroySpeed;
        Detour.Attach(ref i, (delegate* unmanaged<nint, nint, nint, float>)&GetDestroySpeedHook);
    }

    public static void Detach()
    {
        void* i;

        i = TrueGetDestroySpeed;
        Detour.Detach(ref i, (delegate* unmanaged<nint, nint, nint, float>)&GetDestroySpeedHook);
    }

    [UnmanagedCallersOnly]
    private static float GetDestroySpeedHook(nint state, nint level, nint pos)
    {
        return 0.0f;
    }
}