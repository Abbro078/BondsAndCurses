using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCSystem : MonoBehaviour
{

    private bool playerDetected = false;
    public GameObject gorm;
    public GameObject npc;
    private PlayerCombatController playerCombatController;
    public int facingDirection {get; private set;}

    private Rigidbody2D rbNPC, rbGorm;

    public Dialogue dialogue;
    public DialogueManager dialogueManager;


    void Start()
    {
        playerCombatController = gorm.GetComponent<PlayerCombatController>();
        rbNPC = npc.GetComponent<Rigidbody2D>();
        rbGorm = gorm.GetComponent<Rigidbody2D>();
        facingDirection = 1;

        
    }
    
    void Update()
    {
        if(playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("new ability");
            PlayerPrefs.SetInt("HasAbility", 1);
            PlayerPrefs.Save();
            //playerCombatController.secondAttack = true;

            if(rbGorm.position.x < rbNPC.position.x && facingDirection>=1)
            {
                Flip();
            }
            else if(rbGorm.position.x > rbNPC.position.x && facingDirection<1)
            {
                Flip();
            }

            dialogueManager.StartDialogue(dialogue);
            
        }
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("enter");
        if(other.name == "Gorm")
        {
            playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerDetected = false;
        dialogueManager.EndDialogue();   
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        transform.parent.Rotate(0.0f, 180.0f, 0.0f);
    }
}
