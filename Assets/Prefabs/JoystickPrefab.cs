using Mirror;
using UnityEngine;

public class JoyStickController : NetworkBehaviour
{
    public GameObject joystickPrefab;

    [Command]
    void CmdSpawnJoystick(NetworkIdentity playerIdentity)
    {
        GameObject joystick = Instantiate(joystickPrefab);
        NetworkServer.Spawn(joystick);

        NetworkIdentity joystickIdentity = joystick.GetComponent<NetworkIdentity>();
        joystickIdentity.AssignClientAuthority(playerIdentity.connectionToClient);
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        if (isLocalPlayer)
        {
            CmdSpawnJoystick(this.netIdentity);
        }
    }

    [Command]
    void CmdSpawnJoystick()
    {
        Canvas[] canvases = FindObjectsOfType<Canvas>(); // Sahnedeki tüm Canvasları bul

        // İstenilen Canvas'ı belirlemek için özel bir kriter kullanarak seçin
        Canvas desiredCanvas = null;
        foreach (Canvas canvas in canvases)
        {
            // İstenilen kriteri burada belirleyin, örneğin, Canvas'ın adını kontrol edebilirsiniz
            if (canvas.name == "CanvasForSpawn")
            {
                desiredCanvas = canvas;
                break; // İstenilen Canvas'ı bulduk, döngüyü sonlandırın
            }
        }

        // İstenilen Canvas'ı bulamazsak hata verelim
        if (desiredCanvas == null)
        {
            Debug.LogError("Desired Canvas not found!");
            return;
        }

        // Joystick prefabını bulduğumuz Canvas altında instantiate edelim
        GameObject joystick = Instantiate(joystickPrefab, desiredCanvas.transform);

        // Network üzerinden bu joystick'i spawn edelim
        NetworkServer.Spawn(joystick, connectionToClient);
    }
}
