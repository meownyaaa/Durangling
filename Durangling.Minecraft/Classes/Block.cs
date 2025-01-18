using System.Runtime.InteropServices;
using Durangling.Minecraft.Interop;

namespace Durangling.Minecraft.Classes;

public unsafe class Block(Block.Native* handle) : NativeClassWrapper<Block.Native>(handle)
{
    public bool DebugArtToolsOn()
    {
        return Methods.DebugArtToolsOn(Handle) != 0;
    }

    public static float GetDestroySpeed(void* state, void* level, void* pos)
    {
        return Methods.GetDestroySpeed(state, level, pos);
    }
    
    [StructLayout(LayoutKind.Explicit, Pack = 0x1, Size = 0x98)]
    public struct Native
    {
        [FieldOffset(0x0)] public nint* VFTable;
    }

    public static class Methods
    {
        public static readonly delegate* unmanaged[Thiscall]<Native*, byte> DebugArtToolsOn;
        public static readonly delegate* unmanaged<void*, void*, void*, float> GetDestroySpeed;

        static Methods()
        {
            DebugArtToolsOn =(delegate* unmanaged[Thiscall]<Native*, byte>)HandleHelper.GetMainModuleHandle(0x140051660);
            GetDestroySpeed = (delegate* unmanaged<void*, void*, void*, float>)HandleHelper.GetMainModuleHandle(0x1401771b0);
        }
    }

}