using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarScript : MonoBehaviour
{
    public Image healthBarImage;
    public PlayerController player;
    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp((float)player.health / (float)player.maxHealth, 0, 1f);
    }
}
