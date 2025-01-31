using Durangling.Modding;
using Minecraft.Client;
using TestgroundMod.Hooks;

namespace TestgroundMod;

public class TestgroundMod : Mod
{
    public TestgroundMod() 
        : base(new ModDetails("testground", "Testground", new Version(0, 0, 1)))
    {
    }

    protected override void AttachHooks()
    {
        BlockHooks.Attach();
    }

    protected override void DetachHooks()
    {
        BlockHooks.Detach();
    }
}