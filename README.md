# Durangling

### experimental [WinDurango](https://github.com/WinDurango/WinDurango/) mod layer to support C#

### developing mods

1. clone repo
    - `git clone https://github.com/danilwhale/Durangling`
2. open solution inside repo in any IDE
3. optional: rename `TestgroundMod` to something else
4. build Detours with `ReleaseMD | x64` configuration
5. start developing your mod
6. publish mod project
    - `dotnet publish <YourModProjectName>`
7. copy files from `<YourModProjectName>\bin\Release\net9.0\win-x64\publish` to `<GameFolderWithWinDurango>\Mods`
8. start the game