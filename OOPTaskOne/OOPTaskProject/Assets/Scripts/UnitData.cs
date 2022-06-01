using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//здоровье
//изменение здоровья
//стрелять пульками (параметр - тип пули)

public class UnitData : MonoBehaviour
{
    
    [SerializeField][Range((int)50, (int)1000)] protected int _maxHealth = 100;
    [SerializeField] protected Missile _missile;

    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected float _timer;
    [SerializeField] protected float _attackRadius;
    [SerializeField] protected float _movementSpeed;
    [SerializeField] protected GameObject _firePoint;


    protected int _health;
    public int Health
    {
        get => _health;
    }

    public int MaxHealth => _maxHealth;    
    public float Timer => _timer;
    public GameObject FirePoint => _firePoint;
    public float AttackSpeed => _attackSpeed;
    public float AttackRadius => _attackRadius;
    public float MovementSpeed => _movementSpeed;
    public Missile Missile => _missile;

    public void SetHealth(int health) { if (health >= 0) _health = health; }
    public void SetTimer(float timer) => _timer = timer;
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
