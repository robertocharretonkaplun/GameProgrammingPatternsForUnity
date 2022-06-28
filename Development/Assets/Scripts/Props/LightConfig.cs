using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightConfig : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (transform.parent.GetComponent<Renderer>().enabled == false)
    {
      gameObject.SetActive(false);
    }
    else
    {
      gameObject.SetActive(true);
    }
  }
}
