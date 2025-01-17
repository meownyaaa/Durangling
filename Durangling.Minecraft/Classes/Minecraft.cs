using System.Runtime.InteropServices;
using Durangling.Minecraft.DataTypes;
using Durangling.Minecraft.Interop;

namespace Durangling.Minecraft.Classes;

public unsafe class Minecraft(Minecraft.Native* handle) : NativeClassWrapper<Minecraft.Native>(handle)
{
    public static Minecraft GetInstance()
    {
        return new Minecraft(Methods.GetInstance());
    }

    public static bool InMiniGame(EMiniGameId id, bool inMinigame)
    {
        return Methods.InMiniGame(id, (byte)(inMinigame ? 1 : 0)) != 0;
    }
    
    [StructLayout(LayoutKind.Explicit, Pack = 0x1)]
    public struct Native
    {
        [FieldOffset(0x0)] public nint* VFTable;
    }

    public static class Methods
    {
        public static readonly delegate* unmanaged<Native*> GetInstance;
        public static readonly delegate* unmanaged<EMiniGameId, byte, byte> InMiniGame;
        
        static Methods()
        {
            GetInstance = (delegate* unmanaged<Native*>)HandleHelper.GetMainModuleHandle(0x1408727a0);
            InMiniGame = (delegate* unmanaged<EMiniGameId, byte, byte>)HandleHelper.GetMainModuleHandle(0x140873320);
        }
    }
}