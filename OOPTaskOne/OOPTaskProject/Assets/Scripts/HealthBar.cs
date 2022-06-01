using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public UnitData unit;
    public void UpdateEnemyHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp((float)unit.Health / (float)unit.MaxHealth, 0f, 1f);
    }

    private void Update()
    {
        UpdateEnemyHealthBar();
    }
}
