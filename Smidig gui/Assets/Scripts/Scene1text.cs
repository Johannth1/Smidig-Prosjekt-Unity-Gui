using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1text : MonoBehaviour
{
 public GameObject snakkeboble;
 public GameObject valg;
 public GameObject snakkebobleTekst;

 public void onClick(){
     snakkeboble.SetActive(false);
     valg.SetActive(true);
 }

 public void returnNavBar(){
     snakkeboble.SetActive(true);
     snakkebobleTekst.SetActive(false);
 }
}
