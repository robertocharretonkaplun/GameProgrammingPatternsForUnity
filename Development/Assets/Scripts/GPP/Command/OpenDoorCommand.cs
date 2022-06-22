using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorCommand : ICommand
{
  ExitDoor door;
  public OpenDoorCommand(ExitDoor _door)
  {
    door = _door;
  }

  public void Execute()
  {
    door.OpenDoor();
  }
}
