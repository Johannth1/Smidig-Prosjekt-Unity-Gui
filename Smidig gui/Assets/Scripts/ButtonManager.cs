using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void ChangeSceneButton(string scene){
        SceneManager.LoadScene(scene);
    }
}
