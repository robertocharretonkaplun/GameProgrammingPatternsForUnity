using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionControl : MonoBehaviour
{
  public Material mat;
  // Start is called before the first frame update
  void Start()
  {
    mat.EnableKeyword("_EMISSION");
  }

  // Update is called once per frame
  void Update()
  {

  }
}
