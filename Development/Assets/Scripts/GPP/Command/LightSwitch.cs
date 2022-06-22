using System.Collections.Generic;

public class LightSwitch
{
  ICommand command;

  public LightSwitch(ICommand onCommand)
  {
    command = onCommand;
  }

  public void TogglePower()
  {
    command.Execute();
  }
}
