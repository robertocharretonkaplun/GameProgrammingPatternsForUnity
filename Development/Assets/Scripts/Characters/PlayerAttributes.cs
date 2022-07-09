using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerAttributes : MonoBehaviour
{
  public PlayerConfig playerConfig;
  ThirdPersonController controller;
  public ProgressBar StaminaBar;

  // Start is called before the first frame update
  void Start()
  {
    controller = GetComponent<ThirdPersonController>();
  }

  // Update is called once per frame
  void Update()
  {



    if (controller.GetSprintInput() && controller.GetMoveInput() != Vector2.zero)
    {
      playerConfig.Stamina -= 0.5f;
      if (playerConfig.Stamina <= 0.0f)
      {
        controller.SetSprintInput(false);
      }
    }
    else
    {
      if (playerConfig.Stamina <= StaminaBar.Max)
      {
        playerConfig.Stamina += 0.5f;
      }
    }

    StaminaBar.Current = playerConfig.Stamina;
  }
}
