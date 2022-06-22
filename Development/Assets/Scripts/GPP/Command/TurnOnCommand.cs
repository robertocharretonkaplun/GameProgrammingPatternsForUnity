
public class TurnOnCommand : ICommand
{
  HandLamp handLamp;
  public TurnOnCommand(HandLamp _handLamp)
  {
    handLamp = _handLamp;
  }

  public void Execute()
  {
    handLamp.TogglePower();
  }
}
