using UnityEngine;
using Mirror;

public class TopScript : NetworkBehaviour
{
    [SerializeField] private float suruklemeHizi = 5f;
    public Rigidbody2D rigidbody2d;

    public override void OnStartServer()
    {
        base.OnStartServer();

        // only simulate ball physics on server
        rigidbody2d.simulated = true;
    }


    [ServerCallback]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerControllerforOnline player = collision.gameObject.GetComponent<PlayerControllerforOnline>();

        if (player != null)
        {
            rigidbody2d.velocity = rigidbody2d.velocity;
        }
    }
}