namespace Durangling.Modding;

public readonly struct ModDetails
{
    public readonly string Name;
    public readonly Version Version;

    public ModDetails(string name, Version version)
    {
        Name = name;
        Version = version;
    }
}