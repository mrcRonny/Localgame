using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Mirror;
using JetBrains.Annotations;

public class PlayerControllerforOnline : NetworkBehaviour, IPointerDownHandler, IPointerUpHandler
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

    private TopSpawner script;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        kickButton.onClick.AddListener(OnKickButtonClicked);


        if (isLocalPlayer)
        {
            rb = GetComponent<Rigidbody2D>();

            script = FindObjectOfType<TopSpawner>();

            Canvas joystickCanvas = GameObject.Find("CanvasForSpawn").GetComponent<Canvas>();

            // Joystick'i canvas'a ekleyin
            joystick = Instantiate(joystick, joystickCanvas.transform);
            //kickArea = Instantiate(kickAreaPrefab, joystickCanvas.transform);
            kickButton = Instantiate(kickButton, joystickCanvas.transform);

            // Hareket ve vuruş işlemlerini kontrol et
            InvokeRepeating("FixedUpdate", 0f, 0.02f);

            // Buton tıklama event'ini dinle
            kickButton.onClick.AddListener(OnKickButtonClicked);
        }

    }




private void Update()
    {
        if (!isLocalPlayer)
            return;

        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;

        if (isKickButtonDown && kickArea.IsBallInside())
        {
            CmdKickBall();
            isKickButtonDown = false;
        }
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;

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

    [Command]
    void CmdKickBall()
    {
        if (kickArea.IsBallInside())
        {
            RpcKickBall();

            KickBallOnClient();
        }
    }

    [ClientRpc]
    void RpcKickBall()
    {
        if (isLocalPlayer)
        {
            KickBall();
        }
    }

    [Client]
    void KickBallOnClient()
    {
        KickBall();
    }

    void OnKickButtonClicked()
    {
        if (kickArea.IsBallInside() & script.BallTrue())
        {
            topRigidbody = GameObject.FindGameObjectWithTag("top").GetComponent<Rigidbody2D>();
            CmdKickBall();
        }
    }

    void KickBall()
    {
        Vector2 direction = topRigidbody.position - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector2 kickDirection = Quaternion.Euler(0, 0, angle) * Vector2.right;
        topRigidbody.velocity = kickDirection * shootPower * 3f;
    }
}
