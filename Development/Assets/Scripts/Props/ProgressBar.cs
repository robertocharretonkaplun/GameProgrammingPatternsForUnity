using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
  public float Max;
  public float Current;
  public Image Mask;
  // Update is called once per frame
  void Update()
  {
    GetFillAmount();
  }

  public void GetFillAmount()
  {
    float fillAmount = Current / Max;
    Mask.fillAmount = fillAmount;
  }
}
