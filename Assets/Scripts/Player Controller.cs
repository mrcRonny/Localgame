using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float moveSpeed = 5f;
    public float shootPower = 5f;
    public FixedJoystick joystick;
    public Button kickButton;
    public KickArea kickArea;

    private Rigidbody2D rb;
    private Vector2 move;
    private bool isKickButtonDown = false;

    private Rigidbody2D topRigidbody;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        kickButton.onClick.AddListener(OnKickButtonClicked);

        topRigidbody = GameObject.FindGameObjectWithTag("top").GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;

        if (isKickButtonDown && kickArea.IsBallInside())
        {
            KickBall();
            isKickButtonDown = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isKickButtonDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isKickButtonDown = false;
    }

    private void OnKickButtonClicked()
    {
        if (kickArea.IsBallInside())
        {
            KickBall();
        }
    }

    void KickBall()
    {
        // Topun ve karakterin konumları arasındaki farkı hesaplayın
        Vector2 direction = topRigidbody.position - rb.position;

        // Açıyı radian cinsine dönüştürün ve 180 ile çarpın (dereceden radyana çevrim)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Karakterin yüzeyine göre topa vuruş yapın
        Vector2 kickDirection = Quaternion.Euler(0, 0, angle) * Vector2.right;

        // Vuruşu uygula
        topRigidbody.velocity = kickDirection * shootPower * 3f; // 5f ile çarpmayı artırabilirsiniz.
    }
}
