using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsActivate : MonoBehaviour
{
    public GameObject wall1, wall2;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wall1.SetActive(true);
            wall2.SetActive(true);
        }
    }
    
}
