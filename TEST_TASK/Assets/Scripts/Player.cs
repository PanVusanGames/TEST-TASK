using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayerShooter))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimation))]
public class Player : MonoBehaviour
{
    public PlayerShooter Shooter { get; private set; }
    public PlayerMovement Movement { get; private set; }

    public event Action OnPlayerTakeWeaponInHands;

    private void Awake()
    {
        Shooter = GetComponent<PlayerShooter>();
        Movement = GetComponent<PlayerMovement>();

        FindObjectOfType<EnemiesHolder>().OnAllEnemiesDeath += DropWeapon;
    }

    private void SetPlayersCurrentWeaponAs(Weapon weapon)
    {
        Shooter.SetPlayersCurrentWeaponAs(weapon);
        OnPlayerTakeWeaponInHands?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Weapon weapon))
        {
            SetPlayersCurrentWeaponAs(weapon);
            weapon.PickedUpByPlayer();
        }
    }

    private void DropWeapon()
    {
        Shooter.DropWeapon();
    }

}
