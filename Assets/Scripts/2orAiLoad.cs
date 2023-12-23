using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AIor2Load : MonoBehaviour
{
    public StartFunctions startFunctions;
    public TextMeshProUGUI countdownText;
    public float countdownTime = 3f;

    public void Start()
    {
        StartCoroutine(StartGameWithCountdown());


        startFunctions = new StartFunctions();
    }

    IEnumerator StartGameWithCountdown()
    {
        for (int i = 0; i <= 100; i++)
        {
            countdownText.text = i.ToString() + "%";
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(3f);


        SceneManager.LoadScene("PlayAgainstAI"); //PlayAgainstAI
    }


}
