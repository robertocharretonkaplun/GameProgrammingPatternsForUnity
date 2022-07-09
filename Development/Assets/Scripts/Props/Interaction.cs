using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
  [Header("Interaction Settings")]
  public GameObject InteractionText;
  public Transform InteractionPoint;
  public string InteractionContent;
  public float InteractionDistance = 3f;
  public float InteractionDistanceLimit = 1f;
  public bool IsInteracting = false;

  public void CheckIfTargetIsClose(Vector3 targetPosition)
  {


    if (Helpers.IsObjectNearToArea(targetPosition, InteractionPoint.position, InteractionDistanceLimit))
    {
      IsInteracting = true;
    }
    else
    {
      IsInteracting = false;
    }
    InteractionText.SetActive(IsInteracting);
  }

  private void OnDrawGizmosSelected()
  {
    
  }

}
