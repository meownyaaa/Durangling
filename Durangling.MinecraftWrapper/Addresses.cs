namespace Minecraft;

// Addresses of methods from Minecraft: Xbox One Edition 1.61.1924.0
internal static class Addresses
{
    public static class Minecraft
    {
        public const long GetInstance = 0x1408727a0;
        public const long InMiniGame = 0x140873320;
    }

    public static class MinecraftApp
    {
        public const long HandleDlc = 0x140790e90;
    }

    public static class Block
    {
        public const long IsDebugInformationVisible = 0x140051660;
        public const long GetMiningSpeed = 0x1401771b0;
    }
}