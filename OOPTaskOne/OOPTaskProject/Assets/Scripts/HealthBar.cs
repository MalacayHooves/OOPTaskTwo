using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : UnitData
{
    public Image healthBarImage;
    public UnitData unit;
    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp((float)unit.Health / (float)unit.MaxHealth, 0f, 1f);
        print("healthBar's been updated!");
    }

    private void OnEnable()
    {
        unit.GetComponent<UnitData>().OnHealthChange += UpdateHealthBar;
    }

    private void OnDisable()
    {
        unit.GetComponent<UnitData>().OnHealthChange -= UpdateHealthBar;
    }
}
