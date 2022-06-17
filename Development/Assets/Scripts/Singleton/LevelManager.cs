// Class that manage all the different managers

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
  public static LevelManager instance;

  private void Awake()
  {
    if (instance != null)
    {
      return;
    }
    else
    {
      instance = this;
    }
  }

  void Start()
  {
    // Init Game Manager
    GameManager.instance.Init();
  }

  void Update()
  {

  }
}
