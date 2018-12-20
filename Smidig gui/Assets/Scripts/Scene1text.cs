using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scene1text : MonoBehaviour
{
 public GameObject snakkeboble;
 public GameObject valg;
 public GameObject SkuespillerTekstGO;
 public GameObject spillerTekstGO;
 public Text spillerTekst;
 public Text SkuespillerTekst;

 public void onClick(){
     valg.SetActive(true);
          SkuespillerTekstGO.SetActive(false);
          }

public void choiceClick(GameObject choice){
    spillerTekst = choice.GetComponent<Text>(); 
    spillerTekstGO.SetActive(true);
    valg.SetActive(false);

}


}
