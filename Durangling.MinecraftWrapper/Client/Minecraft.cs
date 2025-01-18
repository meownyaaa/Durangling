using System.Runtime.InteropServices;
using Minecraft.Client.MiniGames;
using Minecraft.Interop;

namespace Minecraft.Client;

public unsafe class Minecraft(Minecraft.Native* handle) : NativeClassWrapper<Minecraft.Native>(handle)
{
    public static Minecraft Instance => new(NativeMethods.GetInstance());

    public static bool InMiniGame(MiniGameId id, bool inMiniGame)
    {
        return NativeMethods.InMiniGame(id, (byte)(inMiniGame ? 1 : 0)) != 0;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 0x1, Size = 0x10)]
    public struct Native
    {
        [FieldOffset(0x0)] public fixed byte _Fill[0x10];
    }

    public static class NativeMethods
    {
        public static readonly delegate* unmanaged<Native*> GetInstance;
        public static readonly delegate* unmanaged<MiniGameId, byte, byte> InMiniGame;
        
        static NativeMethods()
        {
            GetInstance = (delegate* unmanaged<Native*>)HandleHelper.GetMainModuleHandle(Addresses.Minecraft.GetInstance);
            InMiniGame = (delegate* unmanaged<MiniGameId, byte, byte>)HandleHelper.GetMainModuleHandle(Addresses.Minecraft.InMiniGame);
        }
    }
}