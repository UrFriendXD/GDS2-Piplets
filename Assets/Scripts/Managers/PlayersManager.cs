using System.Collections.Generic;
using Player;

public class PlayersManager : IGameService
{
    private readonly List<PlayerScript> _players = new List<PlayerScript>();
    
    public int AddPlayer(PlayerScript playerScript)
    {
        // Checks if player exists already and if not add to the list
        if (_players.Contains(playerScript)) return 0;
        _players.Add(playerScript);
        //Debug.Log(Players.IndexOf(playerScript));
        return _players.IndexOf(playerScript);
    }

    public PlayerScript GetPlayerFromID(int playerID)
    {
        return _players[playerID];
    }

    public List<PlayerScript> GetAllPlayers()
    {
        return _players;
    }
}
