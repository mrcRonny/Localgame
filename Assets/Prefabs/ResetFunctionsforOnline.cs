using TMPro;
using UnityEngine;
using System.Collections;

public class ResetforOnline : MonoBehaviour
{
    public Transform Ball;
    public Transform Player1Prefab;
    public Transform Player2;
    public GameObject player1Prefab;
    public GameObject player2;
    public TextMeshProUGUI countdownText;
    public float countdownTime = 3f;
    PlayerControllerforOnline playerController1;
    PlayerController playerController2;
    public GameObject redLine;
    public GameObject blueLine;
    public AudioSource goalSound;
    public Animator animBlue;
    public Animator animRed;

    private Vector3 originalPlayer1Position; // Mevcut Player1'in başlangıç pozisyonunu tutacak değişken

    public void BaslangicPozisyonunaGetir()
    {
        Ball = GameObject.Find("Ball").transform;
        Player1Prefab = GameObject.FindWithTag("Player1").transform; // Mevcut Player1'i al

        // Mevcut Player1'in başlangıç pozisyonunu kaydet
        originalPlayer1Position = Player1Prefab.position;

        Player2 = GameObject.Find("Player2").transform;

        Debug.Log("ResetOyun fonksiyonu çağrıldı.");

        redLine.SetActive(false);
        blueLine.SetActive(false);

        if (goalSound != null)
        {
            goalSound.Play();
        }

        Invoke("ResetOyun", 5f);
    }

    public void ResetOyun()
    {
        Debug.Log("ResetOyun fonksiyonu çağrıldı.");

        animBlue.SetTrigger("Goal Blue Text Back");
        animRed.SetTrigger("Goal Red Text Back");

        Ball = GameObject.Find("Ball").transform;
        Player1Prefab = GameObject.FindWithTag("Player1").transform;
        Player2 = GameObject.Find("Player2").transform;

        Rigidbody2D topRigidbody = Ball.GetComponent<Rigidbody2D>();
        topRigidbody.velocity = Vector2.zero;

        redLine.SetActive(true);
        blueLine.SetActive(true);

        Ball.position = new Vector2(0, 0);
        Player2.position = new Vector2(5, 0);

        Ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        Ball.GetComponent<Rigidbody2D>().simulated = true;

        // Mevcut Player1'in pozisyonunu değiştir
        Player1Prefab.position = new Vector3(-5, 0, 0);

        StartCoroutine(StartGameWithCountdown());
    }

    IEnumerator StartGameWithCountdown()
    {
        playerController1 = Player1Prefab.GetComponent<PlayerControllerforOnline>();
        playerController2 = player2.GetComponent<PlayerController>();

        countdownText.gameObject.SetActive(true);

        if (playerController1 != null)
        {
            playerController1.enabled = false;
        }

        if (playerController2 != null)
        {
            playerController2.enabled = false;
        }

        RemoveRigidbodyFromAIControllers();

        for (int i = (int)countdownTime; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        if (playerController1 != null)
        {
            playerController1.enabled = true;
        }

        if (playerController2 != null)
        {
            playerController2.enabled = true;
        }

        EnableRigidbodyFromAIControllers();

        countdownText.gameObject.SetActive(false);
    }

    void RemoveRigidbodyFromAIControllers()
    {
        AIController[] aiControllers = FindObjectsOfType<AIController>();
        foreach (AIController ai in aiControllers)
        {
            ai.DisableRigidbody2DFromAI();
        }
    }

    void EnableRigidbodyFromAIControllers()
    {
        AIController[] aiControllers = FindObjectsOfType<AIController>();
        foreach (AIController ai in aiControllers)
        {
            ai.EnableRigidbody2DFromAI();
        }
    }
}
