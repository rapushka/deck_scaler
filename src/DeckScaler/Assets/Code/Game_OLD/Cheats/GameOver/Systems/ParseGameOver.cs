using System.Collections.Generic;
using System.Text.RegularExpressions;
using DeckScaler.Cheats.Component;

namespace DeckScaler.Cheats.Systems
{
    public class ParseGameOver : ParseCheatBaseSystem
    {
        protected override string Pattern => "game over";

        protected override bool TryParse(IList<Group> groups)
        {
            CreateEntity.Cheat()
                .Add<GameOver>()
                ;
            return true;
        }
    }
}