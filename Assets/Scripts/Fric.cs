using UnityEngine;
using Mirror;

public class TopunHiziniAzalt : NetworkBehaviour
{
    public float azalmaOrani = 0.02f; // Hızın her FixedUpdate'te azalacağı miktar
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        AzaltTopHizi();
    }

    void AzaltTopHizi()
    {
        // Topun hızını yavaşça azaltır
        rb.velocity -= rb.velocity * azalmaOrani;
    }
}