using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Player _player;
    private Ray _ray;
    private Waypoint _waypoint;

    public bool IsMoving => _navMeshAgent.velocity.magnitude / _navMeshAgent.speed > 0.1f;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GetComponent<Player>();

        _player.OnPlayerTakeWeaponInHands += DisablePlayerMovement;
        _player.OnPlayerTakeWeaponInHands += ResetWaypoint;

        DisablePlayerMovement();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && _waypoint == null && !_player.Shooter.HasWeapon)
        {
            ShotRay();
            TryToSetPlayerWaypointToMove();
        }

        if (_waypoint != null)
        {
            MoveTowardsWaypoint();
        }
    }

    private void ShotRay()
    {
        _ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
    }

    private void TryToSetPlayerWaypointToMove()
    {
        RaycastHit rayHit = new RaycastHit();
        if (Physics.Raycast(_ray.origin, _ray.direction, out rayHit))
        {
            if (rayHit.collider.TryGetComponent(out Waypoint waypoint))
            {
                if (waypoint.enabled)
                {
                    SetWaypoint(waypoint);
                    EnablePlayerMovement();
                }
            }
        }
    }

    private void MoveTowardsWaypoint()
    {
        _navMeshAgent.destination = _waypoint.transform.position;
    }

    private void DisablePlayerMovement()
    {
        _navMeshAgent.enabled = false;
    }

    private void EnablePlayerMovement()
    {
        _navMeshAgent.enabled = true;
    }

    private void ResetWaypoint()
    {
        _waypoint = null;
    }
    private void SetWaypoint(Waypoint waypoint)
    {
        _waypoint = waypoint;
    }
}
