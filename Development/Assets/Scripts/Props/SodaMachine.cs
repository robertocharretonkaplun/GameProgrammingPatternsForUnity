using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaMachine : Interaction
{
  [Header("Soda Machine Attributes")]
  public int AlmondCost = 1;

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    if (LevelManager.instance.GetGameManager().GetThirdPersonCharacter() != null)
    {
      CheckIfTargetIsClose(LevelManager.instance.GetGameManager().GetThirdPersonCharacter().transform.position);
    }

  }



}
