using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLamp : MonoBehaviour
{
  public GameObject lamp;
  public bool isPowerOn = false;
  public void TogglePower()
  {
    if (!isPowerOn)
    {
      lamp.SetActive(true);
      isPowerOn = true;
    }
    else
    {
      lamp.SetActive(false);
      isPowerOn = false;
    }
  }
}
