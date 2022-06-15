using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  
  public static GameManager instance;
  public int levers = 0;
  public int leversMax = 3;
  // Start is called before the first frame update
  void Start()
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

  // Update is called once per frame
  void Update()
  {
    
  }
}
