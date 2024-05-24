using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // [SerializeField]
    // private Transform respawnPoint;
    // [SerializeField]
    // private GameObject player;
    
    [SerializeField]
    private float respawnTime;

    private float respawnTimeStart;

    private bool respawn;

    private CinemachineVirtualCamera CVC;

    [SerializeField]
    private Animator respawnAnimation;
    
    [SerializeField]
    private GameObject deadText;

    private void Start() 
    {
        CVC = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();

        if(SceneManager.GetActiveScene().name == "GormWithNPC")   //TODO: change to the real name of the real scene
        {
            PlayerPrefs.DeleteKey("HasAbility");
        }
        deadText.SetActive(false);
        
    }

    private void Update() 
    {
        CheckRespawn();    
    }

    public void Respawn()
    {
        respawnTimeStart = Time.time;
        respawn = true;
        deadText.SetActive(true);
    }

    public void CheckRespawn()
    {
        if(Time.time >= respawnTimeStart + respawnTime && respawn)
        {
            // var playerTemp = Instantiate(player, respawnPoint);
            // CVC.m_Follow = playerTemp.transform;
            respawn = false;
            RestartScene();
        }
    }


    public void RestartScene()
    {
        // // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // SceneController.instance.NextLevel();
        // deadText.SetActive(false);   
        StartCoroutine(LoadSceneAsync());

    }


    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        deadText.SetActive(false);
    }
    
}
