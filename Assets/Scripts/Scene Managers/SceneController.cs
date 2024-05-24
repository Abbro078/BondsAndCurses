using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    public Animator transitionAnimator;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel() 
    {
        StartCoroutine(LoadLevel());
    }

    // public void LoadScene(string sceneName)
    // {
    //     SceneManager.LoadSceneAsync(sceneName);
    // }

    IEnumerator LoadLevel()
    {
        transitionAnimator.SetTrigger("end");
        yield return new WaitForSeconds(1);
        // SceneManager.LoadScene("GormWithNPC"); //TODO: tide scene in buid settings
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnimator.SetTrigger("start");
    }
}
