using System.Runtime.InteropServices;
using Minecraft.Interop;

namespace Minecraft.World.Blocks;

public unsafe class Block(Block.Native* handle) : NativeClassWrapper<Block.Native>(handle)
{
    public bool IsDebugInformationVisible()
    {
        return NativeMethods.IsDebugInformationVisible(Handle) != 0;
    }

    public static float GetMiningSpeed(void* state, void* level, void* pos)
    {
        return NativeMethods.GetMiningSpeed(state, level, pos);
    }
    
    [StructLayout(LayoutKind.Explicit, Pack = 0x1, Size = 0x98)]
    public struct Native
    {
        [FieldOffset(0x0)] public fixed byte _Fill[0x98];
        
        [FieldOffset(0x0)] public nint* VFTable;
    }

    public static class NativeMethods
    {
        public static readonly delegate* unmanaged[Thiscall]<Native*, byte> IsDebugInformationVisible;
        public static readonly delegate* unmanaged<void*, void*, void*, float> GetMiningSpeed;

        static NativeMethods()
        {
            IsDebugInformationVisible =(delegate* unmanaged[Thiscall]<Native*, byte>)HandleHelper.GetMainModuleHandle(Addresses.Block.IsDebugInformationVisible);
            GetMiningSpeed = (delegate* unmanaged<void*, void*, void*, float>)HandleHelper.GetMainModuleHandle(Addresses.Block.GetMiningSpeed);
        }
    }

}