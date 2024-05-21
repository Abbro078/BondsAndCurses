using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPoint;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float respawnTime;

    private float respawnTimeStart;

    private bool respawn;

    private CinemachineVirtualCamera CVC;
    
    private void Start() 
    {
        CVC = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();

        if(SceneManager.GetActiveScene().name == "Main")   //TODO: change to the real name of the real scene
        {
            PlayerPrefs.DeleteKey("HasAbility");
        }
    }

    private void Update() 
    {
        CheckRespawn();    
    }
    public void Respawn()
    {
        respawnTimeStart = Time.time;
        respawn = true;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
