using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void TestDebug()
    {
        Debug.Log("Test");
    }

    void OnMouseDown()
    { 
        // This method is called when the user clicks on the GameObject
        Debug.Log("GameObject clicked!");
        TriggerDialogue();
        // Trigger your custom event here 
        // e.g., Call a method or change a property
    }
}
