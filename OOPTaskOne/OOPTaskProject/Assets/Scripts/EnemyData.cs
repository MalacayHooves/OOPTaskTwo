using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : UnitData
{
    // информацию для настройки компонента противников и содержит следующую информацию:
    // тип противника, здоровье, тип используемого снаряда, скорость атаки, дальность атаки и скорость перемещения;
    public EnemyType Type;

    [SerializeField] [Range(0.5f, 100)] protected float _attackRadius;


    public float AttackRadius => _attackRadius;
}
