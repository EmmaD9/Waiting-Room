using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

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
        StopAllCoroutines();    //Prevents multiple coroutines from running
        StartCoroutine(TypeSentence(sentence));     //types sentence out letter by letter

        //dialogueText.text = sentence;     //just makes the sentence appear all at once

        //Debug.Log(sentence);
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);  //waits 0.05 seconds between each letter
        }
    }


    void EndDialogue()
    {
        animator.SetBool("IsOpen", false); //closes dialogue box
        //Debug.Log("End of conversation");
    }
}
