using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TerrorGameConfig", menuName = "GenerateTerrorGame")]
public class TerrorGameConfig : ScriptableObject
{
  [Header("GAME")]
  public bool Multiplayer = false;
  public bool Monsters = false;
  [Header("CONSOLE")]
  public bool PS5 = false;
  public bool PS4 = false;
  public bool XBOX = false;
  public bool NINTENDO = false;
  public bool PC = false;


}
