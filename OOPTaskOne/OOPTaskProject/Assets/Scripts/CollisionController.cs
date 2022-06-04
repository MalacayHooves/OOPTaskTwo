using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private Healther _healther;

    private void Awake()
    {
        _healther = gameObject.GetComponent<Healther>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Missile")
        {
            int damage = collision.gameObject.GetComponent<ProjectileData>().damage;
            _healther.TakeDamage(damage);
            collision.gameObject.GetComponent<ProjectileData>().remainingTime = 0;
        }
    }
}
