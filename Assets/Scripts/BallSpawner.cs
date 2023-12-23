using UnityEngine;
using Mirror;

public class TopSpawner : NetworkManager
{
    public GameObject ballPrefab; // Ball objesinin prefab'ı
    private PlayerControllerforOnline script;

    public Transform leftRacketSpawn;
    public Transform rightRacketSpawn;
    GameObject ball;

    private bool ballTrue = false;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        // add player at correct spawn position
        Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

        // spawn ball if two players
        if (numPlayers == 2)
        {
            GameObject ball = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
            NetworkServer.Spawn(ball);

            ballTrue = true;
        }
    }

    public bool BallTrue()
    {
        return ballTrue;
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        // destroy ball
        if (ball != null)
            NetworkServer.Destroy(ball);

        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }
}

