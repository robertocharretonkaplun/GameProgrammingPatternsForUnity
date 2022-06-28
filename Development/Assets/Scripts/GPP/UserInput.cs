using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
  public static UserInput instance;
  ExitDoor door;
  OpenDoor openDoor;
  public HandLamp handLamp;
  LightSwitch lightSwitch;
  InputHandle handle;
  InputHandleReciver handleReciver;
  // Start is called before the first frame update
  void Start()
  {
    //handLamp = LevelManager.instance.GetGameManager().GetLamp();

    ICommand openDoorCommand = new OpenDoorCommand(door);
    openDoor = new OpenDoor(openDoorCommand);

    ICommand turnOnCommand = new TurnOnCommand(handLamp);
    lightSwitch = new LightSwitch(turnOnCommand);

    // Input Handle Command
    ICommand inputHandleCommand = new InputHandleCommand(handle);
    handleReciver = new InputHandleReciver(inputHandleCommand);
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
    if (Input.GetMouseButtonDown(0))
    {
      Vector3 mousePos = Input.mousePosition;
      handleReciver.StorePosition(mousePos.x, mousePos.y, mousePos.z);
    }
  }
}
