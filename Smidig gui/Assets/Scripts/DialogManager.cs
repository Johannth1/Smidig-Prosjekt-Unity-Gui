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
    public Animator animator;

    void Start(){
    sentence = new Queue<string>();
    choice = new Queue<string>();
    }

    public void StartDialog(Dialog dialog, Choices choices){
        Debug.Log("Starting conversation with " + dialog.navn);

        animator.SetBool("isOpen", true);
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
            if(choice.Count != 0){
            skuespillerTekst.SetActive(false);
            Choice1.text = choice.Dequeue();
            Choice2.text = choice.Dequeue();
            valgUi.SetActive(true);
            EndDialog();
            return;
            }
        }

        string dialogLine = sentence.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogLine));
    }

    IEnumerator TypeSentence (string sentence){
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray()){
            dialogText.text += letter;
            yield return null;
        }
    }

    public void DisplayChoiceText(GameObject choice){
        valgUi.SetActive(false);
        spillerText.text = choice.GetComponent<Text>().text;
        SpillerTekst.SetActive(true);
    }

    void EndDialog(){
                animator.SetBool("isOpen", false);
        Debug.Log("End of conversation");
    }
    void EndChoice(){
        Debug.Log("End of choices");
    }
}
