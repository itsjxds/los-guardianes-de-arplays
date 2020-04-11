using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TextMeshProUGUI nameUI;
    public TextMeshProUGUI sentenceUI;
    public GameObject dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            displayNextSentence();
        }
    }

    public void startDialogue (Dialogue dialogue)
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        dialogueBox.SetActive(true);

        nameUI.text = dialogue.name;

        displayNextSentence();
    }

    public void displayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            endDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        sentenceUI.text = sentence;
    }

    private void endDialogue ()
    {
        dialogueBox.SetActive(false);
    }


}
