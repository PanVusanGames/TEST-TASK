using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Projectectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private TrailRenderer _trail;

    private IObjectPool<Projectectile> _projectilePool;

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.position = transform.position + transform.forward * Time.deltaTime * _speed;
    }

    public void InitializeProjectileBasedOn(Weapon weapon)
    {
        transform.position = weapon.transform.position;

        transform.rotation = weapon.transform.rotation;
        float randomSpread = UnityEngine.Random.Range(-weapon.Spread, weapon.Spread);
        transform.rotation = transform.rotation * Quaternion.Euler(Vector3.one * randomSpread);

        _damage = weapon.Damage;
        _projectilePool = weapon.ProjectilePool;

        _trail.emitting = true;

        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.DecreaseHP(_damage);
        }

        _projectilePool.Release(this);
    }

    internal void Disable()
    {
        _trail.emitting = false;
        gameObject.SetActive(false);
    }
}
