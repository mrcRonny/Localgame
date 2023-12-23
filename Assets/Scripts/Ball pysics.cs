using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballpysics : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // Çarpışma anındaki hız ve yönü al
                Vector2 collisionNormal = collision.contacts[0].normal;
                Vector2 incomingDirection = rb.velocity.normalized;

                // Hareketi durdur
                rb.velocity = Vector2.zero;

                // Çarpışma normali ve giriş yönü arasındaki açıyı hesapla
                float angle = Vector2.SignedAngle(incomingDirection, collisionNormal);

                // Çarpışma açısına bağlı olarak geri tepme kuvvetini uygula
                float reflectionForce = 2f; // Geri tepme kuvvetini isteğe bağlı olarak ayarlayabilirsin
                Vector2 reflectionDirection = Quaternion.Euler(0, 0, angle) * -incomingDirection;
                rb.AddForce(reflectionDirection * reflectionForce, ForceMode2D.Impulse);
            }
        }
    }
    
}
