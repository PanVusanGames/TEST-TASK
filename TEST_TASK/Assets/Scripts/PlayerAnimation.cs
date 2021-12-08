using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Player _player;
    private Animator _animator;


    private void Awake()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        string key = $"{nameof(_player.Movement.IsMoving)}";
        _animator.SetBool(key, _player.Movement.IsMoving);
    }
}
