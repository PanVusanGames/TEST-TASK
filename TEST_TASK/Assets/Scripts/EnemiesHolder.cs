using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHolder : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;

    public event Action OnAllEnemiesDeath;

    private void Awake()
    {
        FindEveryEnemieInScene();
    }

    private void FindEveryEnemieInScene()
    {
        var enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            _enemies.Add(enemy);
        }
    }
    
    public void RemoveEnemyFromList(Enemy enemy)
    {
        _enemies.Remove(enemy);

        if (_enemies.Count < 1)
        {
            AllEnemiesAreDead();
        }
    }

    private void AllEnemiesAreDead()
    {
        OnAllEnemiesDeath?.Invoke();
    }
}
