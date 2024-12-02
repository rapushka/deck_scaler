namespace DeckScaler.Cheats.Systems
{
    public class ParseSpawnEnemyCheat : ParseSpawnUnitCheatBase
    {
        protected override string Pattern => "spawn enemy (.+)";
        protected override string Alias   => "se (.+)";

        protected override string GroupID => Constants.TableID.Enemies;

        protected override Side Side => Side.Enemy;
    }
}