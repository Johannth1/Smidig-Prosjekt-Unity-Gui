using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
     private Queue<string> sentence;

    void Start(){
    sentence = new Queue<string>();
    }

    public void StartDialog(Dialog dialog){
        Debug.Log("Starting conversation with " + dialog.navn);

        this.sentence.Clear();

        foreach(string line in dialog.sentences){
            sentence.Enqueue(line);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if(sentence.Count == 0){
            EndDialog();
            return;
        }

        string dialogLine = sentence.Dequeue();
        Debug.Log(dialogLine);
    }

    void EndDialog(){
        Debug.Log("End of conversation");
    }
}
