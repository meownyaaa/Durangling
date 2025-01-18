# Durangling

### experimental Minecraft: Xbox One Edition modding library

### prerequisites

testing:
- Windows 10 or newer
- Minecraft: Xbox One Edition *1.61.1924.0* dump with installed [WinDurango](https://github.com/WinDurango/WinDurango)
  - Alpha 2 will NOT work, use the last successful GitHub Actions build

developing:
- .NET SDK 9.0
- Visual Studio 2022 with 'Desktop development with C++' workload

### developing

1. clone repo
    - `git clone https://github.com/danilwhale/Durangling`
2. open `Durangling.sln` in any IDE (e.g. Visual Studio 2022, JetBrains Rider)
3. optional: rename `TestgroundMod` to something else
4. build Detours with `ReleaseMD | x64` configuration
5. start developing your mod
6. publish mod project
    - `dotnet publish <YourModProjectName>`
7. copy files from `<YourModProjectName>\bin\Release\net9.0\win-x64\publish` to `<MinecraftDumpFolder>\Mods`
8. start the game