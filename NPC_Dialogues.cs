using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogues : MonoBehaviour
{
    public int dialogIndex;
    private bool triggerEntry;
    private DialogueTrigger trigger;

    private void Start()
    {
        trigger = GetComponent<DialogueTrigger>();
    }

    private void Update()
    {
        if(triggerEntry && Input.GetKeyDown(KeyCode.E))
        {
            trigger.TriggerDialogue(dialogIndex);
            dialogIndex += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            triggerEntry = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            triggerEntry = false;
        }
    }
}