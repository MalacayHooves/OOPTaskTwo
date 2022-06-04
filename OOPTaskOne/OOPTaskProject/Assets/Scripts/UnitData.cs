using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//здоровье
//изменение здоровья
//стрелять пульками (параметр - тип пули)

public class UnitData : MonoBehaviour
{
    
    [SerializeField] [Range((int)50, (int)1000)] protected int _maxHealth = 100;
    [SerializeField] protected Missile _missile;

    [SerializeField] [Range(0.5f, 100)] protected float _attackSpeed;
    [SerializeField] protected float _timer;
    [SerializeField] [Range(0.5f, 100)] protected float _movementSpeed;
    [SerializeField] protected GameObject _firePoint;

    protected Healther healther;

    protected int _health;
    public int Health
    {
        get => _health;
    }

    public int MaxHealth => _maxHealth;    
    public float Timer => _timer;
    public GameObject FirePoint => _firePoint;
    public float AttackSpeed => _attackSpeed;
    public float MovementSpeed => _movementSpeed;
    public Missile Missile => _missile;

    
    public void SetTimer(float timer) => _timer = timer;

    public void SetHealth(int health) => _health = health;
}


public enum EnemyType : byte
{
    SeasonedWolf,
    RocketCarrier,
    Gunner
}

public enum Missile : byte
{
    Stone,
    Rocket,
    Bullet
}
