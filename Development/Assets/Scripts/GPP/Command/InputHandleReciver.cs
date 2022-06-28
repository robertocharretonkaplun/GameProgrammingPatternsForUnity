
public class InputHandleReciver
{
  ICommand command;
  public InputHandleReciver(ICommand _command)
  {
    command = _command;
  }

  public void StorePosition(float x, float y, float z)
  {
    command.Execute(x, y, z);
  }
}
