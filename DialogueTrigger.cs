using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogues;

    public void TriggerDialogue(int index)
    {
        if (index < dialogues.Length)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogues[index]);
        }
    }
}
