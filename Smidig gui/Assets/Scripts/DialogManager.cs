using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject skuespillerTekst;
    public GameObject SpillerTekst;
    public GameObject valgUi;
    public Text nameText;
    public Text dialogText;
    public Text spillerText;
    public Text Choice1;
    public Text Choice2;
    private Queue<string> sentence;
    private Queue<string> choice;

    void Start(){
    sentence = new Queue<string>();
    choice = new Queue<string>();
    }

    public void StartDialog(Dialog dialog, Choices choices){
        Debug.Log("Starting conversation with " + dialog.navn);

        nameText.text = dialog.navn;
        sentence.Clear();
        choice.Clear();

        foreach(string line in dialog.sentences){
            sentence.Enqueue(line);
        }

        foreach(string line in choices.choices){
            choice.Enqueue(line);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if(sentence.Count == 0){
            skuespillerTekst.SetActive(false);
            Choice1.text = choice.Dequeue();
            Choice2.text = choice.Dequeue();
            valgUi.SetActive(true);
            EndDialog();
            return;
        }

        string dialogLine = sentence.Dequeue();
        dialogText.text = dialogLine;
        Debug.Log(dialogLine);
    }

    void EndDialog(){
        Debug.Log("End of conversation");
    }
}
