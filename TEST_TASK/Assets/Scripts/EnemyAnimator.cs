using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Enemy _enemy;
    private Animator _animator;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();

        _enemy.OnDamageTaken += DamageAnimation;
        _enemy.OnDeath += DeathAnimation;
    }

    private void DamageAnimation()
    {
        _animator.Play("Damage", -1, 0.0f);
    }

    private void DeathAnimation()
    {
        _animator.Play("Death");
        Unsubscribe();
    }

    private void Unsubscribe()
    {
        _enemy.OnDamageTaken -= DamageAnimation;
        _enemy.OnDeath -= DeathAnimation;
    }
}
