using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;     //uses FIFO (first in first out) collection
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true); //opens dialogue box

        nameText.text = dialogue.name;
        //Debug.Log("Starting conversation with " + dialogue.name);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
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
        dialogueText.text = sentence;
        //Debug.Log(sentence);

    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false); //closes dialogue box
        //Debug.Log("End of conversation");
    }
}
