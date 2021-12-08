using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] private List<WeaponInWorldToPickUp> _weaponInWorldToPickUp;

    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _player.OnPlayerTakeWeaponInHands += DisableWeaponsThatAreNotInPlayersHands;
    }

    private void DisableWeaponsThatAreNotInPlayersHands()
    {
        foreach (var weaponInWorld in _weaponInWorldToPickUp)
        {
            if (weaponInWorld.Weapon != _player.Shooter.CurrentWeapon)
            {
                weaponInWorld.Weapon.Disable();
            }
        }

        foreach (var weaponInWorld in _weaponInWorldToPickUp)
        {
            weaponInWorld.Particle.Stop();
            weaponInWorld.Text.enabled = false;
        }

        _player.OnPlayerTakeWeaponInHands -= DisableWeaponsThatAreNotInPlayersHands;
    }
}

[Serializable]
public class WeaponInWorldToPickUp
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private Weapon _weapon;

    public ParticleSystem Particle => _particle;
    public TextMeshPro Text => _text;
    public Weapon Weapon => _weapon;
}
