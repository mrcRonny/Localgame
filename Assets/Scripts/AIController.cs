using UnityEngine;

public class AIController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform ballTransform; // Reference to the ball's transform
    public Transform goalTransform; // Reference to the goal's transform
    public Transform owngoalTransfrom; // Reference to the goal's transform
    Rigidbody2D rb;
    Vector2 moveDirection;

    bool isBallContact = false;

    public void DisableRigidbody2DFromAI()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.simulated = false; // Rigidbody2D'yi etkisiz hale getir
        }
    }

    public void EnableRigidbody2DFromAI()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.simulated = true; // Rigidbody2D'yi etkisiz hale getir
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (ballTransform != null)
        {
            Vector2 direction = (Vector2)ballTransform.position - rb.position;
            moveDirection = direction.normalized;
        }
        else
        {
            moveDirection = Vector2.zero;
        }

        if (isBallContact)
        {
            ShootBall();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("top"))
        {
            isBallContact = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("top"))
        {
            isBallContact = false;
        }
    }

    void ShootBall()
    {
        Vector2 shootDirection;

        // Calculate the direction from the ball to the goal
        Vector2 directionToGoal = (goalTransform.position - ballTransform.position).normalized;

        // Check if the ball is moving towards the goal (simplified check)
        if (Vector2.Dot(ballTransform.GetComponent<Rigidbody2D>().velocity, directionToGoal) > 0)
        {
            // If the ball is moving towards the goal, shoot in its current direction
            shootDirection = ballTransform.GetComponent<Rigidbody2D>().velocity.normalized;
        }
        else
        {
            // If the ball is not moving towards the goal, let the ball continue in its natural direction
            shootDirection = ballTransform.GetComponent<Rigidbody2D>().velocity.normalized;
        }

        float shootForce = 9f; // Ayarlanabilir vuruş gücü

        // Apply force to the ball in the specified direction
        ballTransform.GetComponent<Rigidbody2D>().velocity = shootDirection * shootForce;

        // Reset the ball contact state to stop continuous shooting
        isBallContact = false;
    }


}
