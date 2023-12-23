using UnityEngine;
using Mirror;


public class ServerControlledBall : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnPositionChanged))]
    private Vector3 syncedPosition;

    private void Start()
    {
        if (isServer)
        {
            // Sunucu tarafında hareketi başlat
            syncedPosition = transform.position;
        }
    }

    private void Update()
    {
        if (isServer)
        {
            // Sunucu tarafında hareketi güncelle
            syncedPosition = CalculateNewPosition();
        }
    }

    private Vector3 CalculateNewPosition()
    {
        // Burada topun yeni konumunu hesaplayın
        // Örneğin, kullanıcı girişi, bir algoritma veya başka bir şey kullanabilirsiniz.
        return transform.position;
    }

    private void OnPositionChanged(Vector3 oldPosition, Vector3 newPosition)
    {
        // Senkronize edilen konum değiştiğinde yapılacak işlemler
        transform.position = newPosition;
    }
}
