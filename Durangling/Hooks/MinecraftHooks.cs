using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Durangling.Classes;
using Durangling.Interop.PInvoke;

namespace Durangling.Hooks;

public static unsafe class MinecraftHooks
{
    private static delegate* unmanaged<Minecraft.Native*> TrueGetInstance =
        Minecraft.Methods.GetInstance;

    public static void Attach()
    {
        void* i;

        i = TrueGetInstance;
        Detour.Attach(ref i, (delegate* unmanaged[Stdcall]<Minecraft.Native*>)&GetInstanceHook);
    }

    public static void Detach()
    {
        void* i;

        i = TrueGetInstance;
        Detour.Detach(ref i, (delegate* unmanaged[Stdcall]<Minecraft.Native*>)&GetInstanceHook);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    public static Minecraft.Native* GetInstanceHook()
    {
        Logger.Write(Logger.Level.Info, "Getting Minecraft instance!");
        return Minecraft.Methods.GetInstance();
    }
}