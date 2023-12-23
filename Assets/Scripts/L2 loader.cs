using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class L2loader : MonoBehaviour
{
    public StartFunctions startFunctions;
    LoadingScreen loadingScreen;

    public void LoadScene(int sceneID)
    {
        StartCoroutine(LoadScene_Coroutine(3));

        startFunctions = new StartFunctions();
        
    }

    IEnumerator LoadScene_Coroutine(int sceneID)
    {
        // Asenkron sahne yükleme işlemini başlat
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

        while (!operation.isDone)
        {
            // Yükleme işlemi tamamlanana kadar bekleyin
            yield return null;
        }
    }

}
