using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsActivate : MonoBehaviour
{
    [SerializeField]
    private GameObject walls;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            walls.SetActive(true);
        }
    }
    
}
