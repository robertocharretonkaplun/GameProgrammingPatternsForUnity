using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
  ExitDoor door;
  OpenDoor openDoor;
  public HandLamp handLamp;
  LightSwitch lightSwitch;
  // Start is called before the first frame update
  void Start()
  {
    //handLamp = LevelManager.instance.GetGameManager().GetLamp();

    ICommand openDoorCommand = new OpenDoorCommand(door);
    openDoor = new OpenDoor(openDoorCommand);

    ICommand turnOnCommand = new TurnOnCommand(handLamp);
    lightSwitch = new LightSwitch(turnOnCommand);
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.R))
    {
      lightSwitch.TogglePower();
    }
    if (Input.GetKeyDown(KeyCode.O))
    {
      openDoor.Open();
    }
  }
}
