using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoints : MonoBehaviour
{
  public static Transform[] Waypoints;


  private void Awake()
  {
    // Initialize the array of point
    Waypoints = new Transform[transform.childCount];

    // Set all the child points
    for (int i = 0; i < Waypoints.Length; i++)
    {
      Waypoints[i] = transform.GetChild(i);
    }

  }
}
