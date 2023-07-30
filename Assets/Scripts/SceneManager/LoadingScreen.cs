using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private CheckIntenetConnection checkIntenetConnection;
    void Start()
    {
        StartCoroutine(LoadSceneSync());
    }

    IEnumerator LoadSceneSync()
    {
        yield return new WaitForSeconds(0.02f);
        if (checkIntenetConnection.CheckConnection())
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main");

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
        else
        {
            Debug.Log("NoConnection");
            StartCoroutine(LoadSceneSync());
        }
    }
}
