using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandle : MonoBehaviour
{
  Vector3 position; 
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }


  public void StorePosition(float x, float y, float z)
  {
    position.x = x;
    position.y = y;
    position.z = z;
  }

  public Vector3 GetPosition ()
  {
    return position;
  }
}
