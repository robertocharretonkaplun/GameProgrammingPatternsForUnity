using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCongif : MonoBehaviour
{
  public Material[] WallMaterial;
  public bool HasBorders = true;
  public GameObject[] borders;
  // Start is called before the first frame update
  void Start()
  {
    if (LevelManager.instance.GetGameManager() != null)
    {

      GetComponent<Renderer>().material = WallMaterial[LevelManager.instance.GetGameManager().GetWallType()];
    }
    else
    {
      GetComponent<Renderer>().material = WallMaterial[1];

    }

    if (HasBorders)
    {
      foreach (var border in borders)
      {
        border.SetActive(true);
      }
    }
    else
    {
      foreach (var border in borders)
      {
        border.SetActive(false);
      }
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
