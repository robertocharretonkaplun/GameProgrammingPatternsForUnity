using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomEventTypes
{
  ACCION,
  TRADING,
  SUSPENSE,
  RESOURCE,
  INVESTIGATION,
  RARE
}

public class RoomDirector : MonoBehaviour
{
  public GameObject[] TradeEvents;
  public int AmountOfEventsPerRoom = 4;
  public List<RoomEventTypes> SelectedEvents;
  // Start is called before the first frame update
  void Start()
  {
    SelectedEvents = new List<RoomEventTypes>();
    for (int i = 0; i < AmountOfEventsPerRoom; i++)
    {
      int RandomEvent = Random.Range(0, AmountOfEventsPerRoom);
      SelectedEvents.Add((RoomEventTypes)RandomEvent);
    }

    foreach (var Event in SelectedEvents)
    {
      switch (Event)
      {
        case RoomEventTypes.ACCION:
          break;
        case RoomEventTypes.TRADING:
          var Tevent = Instantiate(TradeEvents[0], transform.position, transform.rotation);
          Tevent.transform.parent = transform;
          break;
        case RoomEventTypes.SUSPENSE:
          break;
        case RoomEventTypes.RESOURCE:
          break;
        case RoomEventTypes.INVESTIGATION:
          break;
        case RoomEventTypes.RARE:
          break;
        default:
          break;
      }
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
