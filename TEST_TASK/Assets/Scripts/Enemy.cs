using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _hp;

    private BoxCollider _boxCollider;
    private EnemiesHolder _enemiesHolder;

    public int CurrentHP { get; private set; }

    public event Action OnDamageTaken;
    public event Action OnDeath;

    public event Action<int> OnDamageDecreasePer;

    private void Awake()
    {
        _enemiesHolder = FindObjectOfType<EnemiesHolder>();
        _boxCollider = GetComponent<BoxCollider>();

        SetCurrentHP();
    }

    private void SetCurrentHP()
    {
        CurrentHP = _hp;
    }

    public void DecreaseHP(int amount)
    {
        CurrentHP = CurrentHP - amount;
        OnDamageDecreasePer?.Invoke(amount);

        if (CurrentHP < 1)
        {
            Death();
        }

        OnDamageTaken?.Invoke();
    }

    private void Death()
    {
        _enemiesHolder.RemoveEnemyFromList(this);
        OnDeath?.Invoke();
        _boxCollider.enabled = false;
        Destroy(gameObject, 1f);
    }
}
