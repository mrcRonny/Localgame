using Mirror;
using UnityEngine;

public class KickRedSpawn : NetworkBehaviour
{
    public GameObject kickRedPrefab;

    [Command]
    void CmdSpawnKickRed(NetworkIdentity playerIdentity)
    {
        GameObject kickRed = Instantiate(kickRedPrefab);
        NetworkServer.Spawn(kickRed);

        NetworkIdentity kickRedIdentity = kickRed.GetComponent<NetworkIdentity>();
        kickRedIdentity.AssignClientAuthority(playerIdentity.connectionToClient);
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        if (isLocalPlayer)
        {
            CmdSpawnKickRed(this.netIdentity);
        }
    }

    [Command]
    void CmdSpawnKickRed()
    {
        Canvas[] canvases = FindObjectsOfType<Canvas>();

        Canvas desiredCanvas = null;
        foreach (Canvas canvas in canvases)
        {
            if (canvas.name == "CanvasForSpawn")
            {
                desiredCanvas = canvas;
                break;
            }
        }

        if (desiredCanvas == null)
        {
            Debug.LogError("Arzu edilen Canvas bulunamadı!");
            return;
        }

        GameObject kickRed = Instantiate(kickRedPrefab, desiredCanvas.transform);

        NetworkServer.Spawn(kickRed, connectionToClient);
    }
}
