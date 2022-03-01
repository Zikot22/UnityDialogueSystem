using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private float typeSpeed;
    [SerializeField] private Transform DialogueWindow;
    private Queue<string> sentences;
    private TextMeshProUGUI dialogueText;
    private Transform contButton;

    void Start()
    {
        sentences = new Queue<string>();
        dialogueText = DialogueWindow.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        contButton = DialogueWindow.Find("Button");

    }

    public void StartDialogue(Dialogue dialogue)
    {
        DialogueWindow.gameObject.SetActive(true);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        contButton.gameObject.SetActive(false);
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        dialogueText.text = "";
        string sentence = sentences.Dequeue();
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
        contButton.gameObject.SetActive(true);
    }

    void EndDialogue()
    {
        DialogueWindow.gameObject.SetActive(false);
        dialogueText.text = "";
    }
}