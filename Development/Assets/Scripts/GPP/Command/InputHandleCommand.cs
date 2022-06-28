
public class InputHandleCommand : ICommand
{
  InputHandle handle;

  public InputHandleCommand(InputHandle _handle)
  {
    handle = _handle;
  }

  public void Execute(float x, float y, float z)
  {
    handle.StorePosition(x,y,z);
  }
}
