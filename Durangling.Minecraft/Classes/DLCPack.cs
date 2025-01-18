using System.Runtime.InteropServices;
using Durangling.Minecraft.Interop;

namespace Durangling.Minecraft.Classes;

public unsafe class DLCPack(DLCPack.Native* handle) : NativeClassWrapper<DLCPack.Native>(handle)
{
    [StructLayout(LayoutKind.Explicit, Pack = 0x1, Size = 0x300)]
    public struct Native
    {
        [FieldOffset(0x228)] public int Id;
    }
}