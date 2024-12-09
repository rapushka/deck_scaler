namespace DeckScaler.Cheats.Systems
{
    public class ParseSpawnAsTeammateCheat : ParseSpawnUnitCheatBase
    {
        protected override string Pattern => "spawn teammate (.+)";
        protected override string Alias   => "st (.+)";

        protected override Side Side => Side.Player;
    }
}