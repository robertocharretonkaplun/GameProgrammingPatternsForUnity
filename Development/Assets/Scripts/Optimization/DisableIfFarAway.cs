using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfFarAway : MonoBehaviour
{
  private GameObject itemActivatorObject;
  private WorldDetector activationScript;

  // --------------------------------------------------

  void Start()
  {
    itemActivatorObject = GameObject.Find("ItemActivator");
    activationScript = itemActivatorObject.GetComponent<WorldDetector>();

    StartCoroutine("AddToList");
  }

  IEnumerator AddToList()
  {
    yield return new WaitForSeconds(0.1f);

    activationScript.addList.Add(new ActivatorItem { item = this.gameObject });
  }
}
