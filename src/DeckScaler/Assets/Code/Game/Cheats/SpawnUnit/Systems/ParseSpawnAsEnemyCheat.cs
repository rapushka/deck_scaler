namespace DeckScaler.Cheats.Systems
{
    public class ParseSpawnAsEnemyCheat : ParseSpawnUnitCheatBase
    {
        protected override string Pattern => "spawn enemy (.+)";
        protected override string Alias   => "se (.+)";

        protected override Side Side => Side.Enemy;
    }
}