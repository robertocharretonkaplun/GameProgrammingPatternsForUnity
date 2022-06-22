using System.Collections.Generic;

class OpenDoor
{
  ICommand onCommand;

  public OpenDoor(ICommand _onCommand)
  {
    onCommand = _onCommand;
  }

  public void Open()
  {
    onCommand.Execute();
  }
}
