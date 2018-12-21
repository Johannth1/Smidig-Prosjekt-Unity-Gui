using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class DialogManager : MonoBehaviour
{
    public GameObject skuespillerTekst;
    public GameObject valgUi;
    public GameObject sceneBackground;
    public Text nameText;
    public Text dialogText;
    public Text Choice1;
    public Text Choice2;
    private List<VideoClip> BackgroundClips;
    private List<string> sentence;
    private List<string> choice;
    public Animator animator;
	string nextDialogueElement;
	string choice1Info;
	string choice2Info;
    int sceneCount = 0;



	void Start(){
    sentence = new List<string>();
    choice = new List<string>();
    BackgroundClips = new List<VideoClip>();
    }

    public void StartDialog(Dialog dialog, Choices choices, Videoclips clips){
        Debug.Log("Starting conversation with " + dialog.navn);
        animator.SetBool("isOpen", true);
        nameText.text = dialog.navn;
        sentence.Clear();
        choice.Clear();
        BackgroundClips.Clear();
		nextDialogueElement = "s0";


		foreach (string line in dialog.sentences){
            sentence.Add(line);
        }

        foreach(string line in choices.choices){
			choice.Add(line);
		}

        foreach(VideoClip clip in clips.clips){
            BackgroundClips.Add(clip);
        }

        ChangeScene(BackgroundClips[sceneCount]);
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
		bool nextIsSentence = nextDialogueElement[0] == 's';
		int elementIndex = Int32.Parse(nextDialogueElement.Substring(1));

        if(dialogText.Equals("Du er min reddende engel! Det kan ikke sies om de som har dette grufulle yrket:s0")){
                    ChangeScene(BackgroundClips[sceneCount]);
        }




		if (nextIsSentence)
		{
			string[] info = sentence[elementIndex].Split(':');
			string dialogLine = info[0];
			nextDialogueElement = info[1];
			StopAllCoroutines();
            StartCoroutine(TypeSentence(dialogLine));
            Debug.Log(elementIndex);
            return;
        }
        skuespillerTekst.SetActive(false);
		string[] alternatives = choice[elementIndex].Split('=');
		choice1Info = alternatives[0];
		choice2Info = alternatives[1];
		Choice1.text = choice1Info.Split(':')[0];
        Choice2.text = choice2Info.Split(':')[0];
        valgUi.SetActive(true);
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
		string text = choice.GetComponent<Text>().text;
		string[] info1 = choice1Info.Split(':');
		if (text.Equals(info1[0]))
		{
			nextDialogueElement = info1[1];
			Debug.Log(nextDialogueElement);
		}
		else
		{
			nextDialogueElement = choice2Info.Split(':')[1];
		}
		dialogText.text = text;
        skuespillerTekst.SetActive(true);

    }

    void EndDialog(){
                animator.SetBool("isOpen", false);
        Debug.Log("End of conversation");
    }
    void EndChoice(){
        Debug.Log("End of choices");
    }


    void ChangeScene(VideoClip background) {
     sceneBackground.GetComponent<VideoPlayer>().clip = background;
             sceneCount++;
    }
}
