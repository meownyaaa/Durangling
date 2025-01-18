using System.Runtime.InteropServices;
using Minecraft.Client.Dlc;
using Minecraft.Interop;

namespace Minecraft.Client;

public unsafe class MinecraftApp(MinecraftApp.Native* handle) : NativeClassWrapper<MinecraftApp.Native>(handle)
{
    public void HandleDlc(DlcPack.Native* pack)
    {
        NativeMethods.HandleDlc(Handle, pack);
    }

    public void HandleDlc(DlcPack pack) => NativeMethods.HandleDlc(Handle, pack.Handle);

    [StructLayout(LayoutKind.Explicit, Pack = 0x1, Size = 0x9ed)]
    public struct Native
    {
        [FieldOffset(0x0)] public fixed byte _Fill[0x9ed];
    }

    public static class NativeMethods
    {
        public static readonly delegate* unmanaged[Thiscall]<Native*, DlcPack.Native*, void> HandleDlc;

        static NativeMethods()
        {
            HandleDlc =
                (delegate* unmanaged[Thiscall]<Native*, DlcPack.Native*, void>)HandleHelper.GetMainModuleHandle(
                    0x140790e90);
        }
    }
}