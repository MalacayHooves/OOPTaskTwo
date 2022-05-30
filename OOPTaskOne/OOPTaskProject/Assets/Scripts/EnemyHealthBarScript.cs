using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBarScript : MonoBehaviour
{
    public Image healthBarImage;
    public EnemyData enemy;
    public void UpdateEnemyHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp((float)enemy.health / (float)enemy.maxHealth, 0f, 1f);
    }

    private void Update()
    {
        UpdateEnemyHealthBar();
    }
}
