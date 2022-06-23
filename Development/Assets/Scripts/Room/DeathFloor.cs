using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{

  private void OnTriggerEnter(Collider other)
  {
    if (other.transform.tag == "Player")
    {
      SceneManagment.instance.LoadLevel_0();
    }
    
  }
}
