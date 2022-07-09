using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
  public static EventSystem instance;

  private void Awake()
  {
    instance = this;

  }
  
  public event Action<int> OnDialogEnable;
  public void DialogInteractionEnter(int id)
  {
    if (OnDialogEnable != null)
    {
      OnDialogEnable(id);
    }
  }

  public event Action<int> OnDialogDesable;
  public void DialogInteractionExit(int id)
  {
    if (OnDialogDesable != null)
    {
      OnDialogDesable(id);
    }
  }
}
