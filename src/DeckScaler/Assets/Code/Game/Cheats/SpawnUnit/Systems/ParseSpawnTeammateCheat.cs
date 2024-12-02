namespace DeckScaler.Cheats.Systems
{
    public class ParseSpawnTeammateCheat : ParseSpawnUnitCheatBase
    {
        protected override string Pattern => "spawn teammate (.+)";

        protected override string GroupID => Constants.TableID.Allies;

        protected override Side Side => Side.Player;
    }
}