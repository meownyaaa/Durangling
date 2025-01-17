using System.Runtime.InteropServices;
using Durangling.DataTypes;
using Durangling.Interop;

namespace Durangling.Classes;

public unsafe class Minecraft(Minecraft.Native* handle) : INativeWrapper
{
    public readonly Native* Handle = handle;
    public bool IsValid => Handle != null;

    public static Minecraft GetInstance()
    {
        Logger.Write(Logger.Level.Debug, "Minecraft.GetInstance");
        return new Minecraft(Methods.GetInstance());
    }

    public static bool InMiniGame(EMiniGameId id, bool inMinigame)
    {
        Logger.Write(Logger.Level.Debug, "Minecraft.InMiniGame");
        return Methods.InMiniGame(id, (byte)(inMinigame ? 1 : 0)) != 0;
    }
    
    [StructLayout(LayoutKind.Explicit, Pack = 0x1)]
    public struct Native
    {
        [FieldOffset(0)] public nint* VTable;
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