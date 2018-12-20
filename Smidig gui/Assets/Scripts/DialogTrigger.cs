using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
  public Dialog dialog;
  public Choices choices;

  public void TriggerDialog() {
    FindObjectOfType<DialogManager>().StartDialog(dialog, choices);
  }

}
