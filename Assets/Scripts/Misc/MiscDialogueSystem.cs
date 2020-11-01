using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiscDialogueSystem : MonoBehaviour
{
    public Queue<string> sentences;
    public Dialogue[] Dialogues;
    public Text dialogueText;
    public Text name;
    public GameObject dialogueCanvas;
    void Start()
    {
        sentences = new Queue<string>();
        StartDialogueByIndex(0);
    }

    public void StartDialogueByIndex(int i)
    {
        StartDialogue(Dialogues[i]);
    }
    public void StartDialogue(Dialogue dialogue)
    {
        name.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        var routine = StartCoroutine(TypeSentence(sentence));
    }

IEnumerator TypeSentence(string sentence)
{
dialogueText.text = "";
foreach (char letter in sentence.ToCharArray())
{
    dialogueText.text += letter;
    yield return null;
}
}

    void EndDialogue()
    {
        dialogueCanvas.SetActive(false);
    }
}
