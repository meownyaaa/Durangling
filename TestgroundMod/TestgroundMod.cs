using Durangling.Modding;
using TestgroundMod.Hooks;

namespace TestgroundMod;

public class TestgroundMod : ModBase
{
    public TestgroundMod() 
        : base(new ModDetails("Testground", new Version(0, 0, 1)))
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