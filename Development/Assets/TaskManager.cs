using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Task
{
  public int ID;
  public string task;
  public bool IsCompleted;
}
[System.Serializable]
public class TaskContainer
{
  public Task[] Mission;
  public Task[] MainTask;
  public Task[] SecundaryTask;
}
public class TaskManager : MonoBehaviour
{
  public GameObject container;
  public TMP_Text Mission;
  public TMP_Text MainTask;
  public TMP_Text SecundaryTask;

  public TaskContainer[] tasks;

  public List<TMP_Text> TasksObjs;

  private int MissionCount;
  private int MainTaskCount;
  private int SecondaryTaskCount;
  // Start is called before the first frame update
  void Start()
  {
    foreach (TaskContainer task in tasks)
    {
      MissionCount = task.Mission.Length;
      MainTaskCount = task.MainTask.Length;
      SecondaryTaskCount = task.SecundaryTask.Length;

      foreach (Task M in task.Mission)
      {
        Mission.text = M.task;
        var mission = Instantiate(Mission, transform.position, Quaternion.identity);
        mission.transform.SetParent(container.transform);
        // Complete Task
        if (M.IsCompleted)
        {
          mission.fontStyle = FontStyles.Strikethrough;
        }
        TasksObjs.Add(mission);
      }
      
      foreach (Task MT in task.MainTask)
      {
        MainTask.text = MT.task;
        var mt = Instantiate(MainTask, transform.position, Quaternion.identity);
        mt.transform.SetParent(container.transform);

        // Complete Task
        if (MT.IsCompleted)
        {
          mt.fontStyle = FontStyles.Strikethrough;
        }

        TasksObjs.Add(mt);
      }
      
      foreach (Task ST in task.SecundaryTask)
      {
        SecundaryTask.text = ST.task;
        var st = Instantiate(SecundaryTask, transform.position, Quaternion.identity);
        st.transform.SetParent(container.transform);

        // Complete Task
        if (ST.IsCompleted)
        {
          st.fontStyle = FontStyles.Strikethrough;
        }
        TasksObjs.Add(st);
      }
    }

  }

  // Update is called once per frame
  void Update()
  {

  }

}

