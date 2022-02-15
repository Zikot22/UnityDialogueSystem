using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TextMeshProUGUI dialogueText;
    public GameObject contButton;
    [SerializeField] private float typeSpeed;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        contButton.SetActive(false);
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
        contButton.SetActive(true);
    }

    void EndDialogue()
    {
        contButton.SetActive(false);
        dialogueText.text = "";
    }
}