using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public GameObject startBtn;
    public GameObject UiBarBottom;

    public void startPrototype(){
        startBtn.SetActive(false);
        UiBarBottom.SetActive(true);
    }
}
