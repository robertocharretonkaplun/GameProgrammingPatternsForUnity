using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player Configurations")]
public class PlayerConfig : ScriptableObject
{
  public float Health = 100f;
  public float Stamina = 100f;
  public float Food = 100f;
  public float Insanity = 100f;

    //if (transform.position.y <= -3f)
    //{
    //  SceneManagment.instance.LoadLevel_0();
    //}
}
