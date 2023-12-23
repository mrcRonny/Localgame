using UnityEngine;

public class CizgiKontrol : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Eğer çarpan nesnenin etiketi "Player" ise
        if (collision != null && collision.collider != null && collision.gameObject.CompareTag("Player"))
        {
            Collider2D myCollider = GetComponent<Collider2D>();

            // Eğer bu nesnenin Collider2D bileşeni varsa
            if (myCollider != null)
            {
                // "Player" etiketine sahip nesne çarptığında, bu çarpışmayı devre dışı bırak
                Physics2D.IgnoreCollision(collision.collider, myCollider);
            }
            else
            {
                Debug.LogWarning("Collider2D bileşeni eksik. Collision çarpışmasını devre dışı bırakamıyor.");
            }
        }
    }
}
