using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healther : MonoBehaviour
{
    private UnitData _unitData;

    public event System.Action OnHealthChange;

    private void Awake()
    {
        _unitData = GetComponent<UnitData>();
    }

    public void TakeDamage(int damage)
    {
        _unitData.SetHealth(_unitData.Health - damage);
        OnHealthChange?.Invoke();
    }

    public void Kill() => Destroy(gameObject);
}
