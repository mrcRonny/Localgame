using UnityEngine;
using Mirror;

public class CustomNetworkBehaviour : NetworkBehaviour
{
    // Bu metot, sunucu başladığında çağrılır.
    public override void OnStartServer()
    {
        // Önce temel işlemleri gerçekleştir
        base.OnStartServer();

        // Daha sonra RigidBody2D'nin Simulated özelliğini True olarak ayarla
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D != null)
        {
            rigidbody2D.simulated = true;
        }
    }
}