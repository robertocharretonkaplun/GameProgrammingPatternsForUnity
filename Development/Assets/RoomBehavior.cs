using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehavior : MonoBehaviour
{
  public GameObject[] Walls; // 0 - Up 1 - Down 2 - Right 3 - Left
  public GameObject[] Doors;
  public bool IsRoomEnable = true;
  //public bool[] TestStatus;
  private void Update()
  {
    //gameObject.SetActive(IsRoomEnable);
  }
  public void UpdateRoom(bool[] status)
  {
    for (int i = 0; i < status.Length; i++)
    {
      if (Doors.Length > 0)
      {
        Doors[i].SetActive(status[i]);
      }
      if (Walls.Length > 0)
      {
        Walls[i].SetActive(!status[i]);
      }
    }
  }
}
