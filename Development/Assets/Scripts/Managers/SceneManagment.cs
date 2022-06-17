using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
  public static void ChangeToRandomScene()
  {
    int SceneIndex = Random.Range(0, SceneManager.sceneCount);

    SceneManager.LoadScene(SceneIndex);
  }

  public static void LoadLevel_0()
  {
    SceneManager.LoadScene("MiniBackrooms");
  }
}
