using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform _weaponTranform;
    [SerializeField] private Camera _shotCamera;

    public Weapon CurrentWeapon { get; private set; }
    public bool HasWeapon => CurrentWeapon != null;

    private void Update()
    {
        if (HasWeapon)
        {
            if (Input.touchCount > 0)
            {
                LookAtTouchPosition();
                CurrentWeapon.TryToShot();
            }
        }
    }

    private void LookAtTouchPosition()
    {
        Vector3 touchPosition = Input.GetTouch(0).position;
        touchPosition.z = _shotCamera.nearClipPlane;
        Vector3 worldPos = _shotCamera.ScreenToWorldPoint(touchPosition);

        transform.LookAt(worldPos);
    }

    public void SetPlayersCurrentWeaponAs(Weapon weapon)
    {
        CurrentWeapon = weapon;
        CurrentWeapon.transform.position = _weaponTranform.position;
        CurrentWeapon.transform.parent = _weaponTranform;
    }

    public void DropWeapon()
    {
        CurrentWeapon.transform.parent = null;
        CurrentWeapon = null;
    }
}
