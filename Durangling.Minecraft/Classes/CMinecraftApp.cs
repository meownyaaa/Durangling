using System.Runtime.InteropServices;
using Durangling.Minecraft.Interop;

namespace Durangling.Minecraft.Classes;

public unsafe class CMinecraftApp(CMinecraftApp.Native* handle) : NativeClassWrapper<CMinecraftApp.Native>(handle)
{
    public void HandleDLC(DLCPack.Native* pack)
    {
        Methods.HandleDLC(Handle, pack);
    }

    public void HandleDLC(DLCPack pack) => Methods.HandleDLC(Handle, pack.Handle);

    [StructLayout(LayoutKind.Explicit, Pack = 0x1, Size = 0x9ed)]
    public struct Native
    {
    }

    public static class Methods
    {
        public static readonly delegate* unmanaged[Thiscall]<Native*, DLCPack.Native*, void> HandleDLC;

        static Methods()
        {
            HandleDLC =
                (delegate* unmanaged[Thiscall]<Native*, DLCPack.Native*, void>)HandleHelper.GetMainModuleHandle(
                    0x140790e90);
        }
    }
}