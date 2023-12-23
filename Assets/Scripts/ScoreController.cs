using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI TextBlue;
    public TextMeshProUGUI TextRed;

    private int maviSkor = 0;
    private int kirmiziSkor = 0;

    void Start()
    {
        GüncelSkorGoster();
    }

    void GüncelSkorGoster()
    {
        TextBlue.text = maviSkor.ToString();
        TextRed.text = kirmiziSkor.ToString();

    }

    public void MaviSkoruArttir(int artisMiktari)
    {
        maviSkor += artisMiktari;

        GüncelSkorGoster();
    }

    public void KirmiziSkoruArttir(int artisMiktari)
    {
        kirmiziSkor += artisMiktari;
        GüncelSkorGoster();
    }
}
