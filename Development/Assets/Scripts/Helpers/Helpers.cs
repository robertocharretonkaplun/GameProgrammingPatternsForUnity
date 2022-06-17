using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers : MonoBehaviour
{
  public static bool PlayerHasAllLevers()
  {
    var GM = GameManager.instance;

    if (GM.levers == GM.leversMax)
    {
      return true;
    }
    return false;
  }

  public static bool IsPlayerNearToArea(Vector3 _target, Vector3 _this, float _area)
  {
    float distance = Vector3.Distance(_target, _this);

    if (distance <= _area)
    {
      return true;
    }
    return false;
  }
}
