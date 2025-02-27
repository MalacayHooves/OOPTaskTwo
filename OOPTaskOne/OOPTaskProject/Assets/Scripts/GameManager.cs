﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Dictionary<EnemyData, Healther> _enemies = new Dictionary<EnemyData, Healther>();
    private List<ProjectileData> _missilesData = new List<ProjectileData>();

    [SerializeField] private GameObject _stone, _bullet, _rocket;
    [SerializeField] private List<GameObject> _enemyPrefabs = new List<GameObject>();
    
    //[SerializeField] private HealthBarScript healthBar;


    private void Start()
    {
        _player.GetComponent<PlayerController>().SetHealth(_player.GetComponent<PlayerController>().MaxHealth);
        for (int i = 0; i < 10; i++)
        {
            GameObject enemy = Instantiate(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Count)]);
            enemy.transform.position = new Vector3(Random.Range(-50, 50), 1, Random.Range(-50, 50));
            enemy.transform.rotation = Random.rotation;
            enemy.transform.eulerAngles = new Vector3(0, enemy.transform.eulerAngles.y, 0);
            EnemyData enemyData = enemy.GetComponent<EnemyData>();
            enemy.GetComponent<EnemyData>().SetHealth(enemy.GetComponent<EnemyData>().MaxHealth);
            Healther healther = enemy.GetComponent<Healther>();
            _enemies.Add(enemyData, healther);
        }
    }

    private void Update()
    {
        foreach (ProjectileData missile in _missilesData)
        {
            missile.remainingTime -= Time.deltaTime;
            if (missile.remainingTime <= 0)
            {
                Destroy(missile.gameObject);
            }
        }
        _missilesData.RemoveAll(missile => missile.remainingTime <= 0);



        foreach (EnemyData enemy in _enemies.Keys)
        {
            if (enemy.Health <= 0) _enemies[enemy].Kill();

            else if (Vector3.Distance(_player.transform.position, enemy.gameObject.transform.position) <= enemy.AttackRadius)
            {
                Aim(enemy.gameObject, _player);
               
                if (enemy.Timer <= 0)
                {
                    enemy.SetTimer(enemy.AttackSpeed);
                    Shooting(enemy.FirePoint, enemy.Missile);
                }
                else
                {
                    enemy.SetTimer(enemy.Timer - Time.deltaTime * 10);
                }
            }
        }

        _enemies = _enemies.Where(enemy => (enemy.Key.Health > 0)).ToDictionary(d => d.Key, d => d.Value);


        if (_player.GetComponent<PlayerController>().Health <= 0)
        {
            print("You're dead!");
            Application.Quit();
        }
    }

    private void Aim(GameObject shooter, GameObject target)
    {
        shooter.transform.LookAt(target.transform);
    }


    public void Shooting(GameObject firePoint, Missile missile)
    {        
        GameObject _missile;

        switch (missile)
        {
            case Missile.Stone:
                _missile = Instantiate(_stone, firePoint.transform.position,firePoint.transform.rotation);
                break;
            case Missile.Rocket:
                _missile = Instantiate(_rocket, firePoint.transform.position, firePoint.transform.rotation);
                break;
            case Missile.Bullet:
                _missile = Instantiate(_bullet, firePoint.transform.position, firePoint.transform.rotation);
                break;
            default:
                _missile = Instantiate(_bullet, firePoint.transform.position, firePoint.transform.rotation);
                break;
        }

        _missile.layer = firePoint.layer;  
        Rigidbody _missileRB = _missile.AddComponent<Rigidbody>();
        _missileRB.useGravity = false;
        ProjectileData _missileData = _missile.GetComponent<ProjectileData>();
        _missileRB.AddRelativeForce(transform.up * _missileData.movementSpeed * 10f, ForceMode.Acceleration);

        _missilesData.Add(_missileData);
    }
}
