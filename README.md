# Durangling

### experimental [WinDurango](https://github.com/WinDurango/WinDurango/) mod layer to support C#

### developing mods

1. clone repo
    - `git clone https://github.com/danilwhale/Durangling`
2. open solution inside repo in any IDE
3. optional: rename `TestgroundMod` to something else
4. start developing your mod
5. publish mod project
    - `dotnet publish <YourModProjectName>`
6. copy files from `<YourModProjectName>\bin\Release\net9.0\win-x64\publish` to `<GameFolderWithWinDurango>\Mods`
7. start the game