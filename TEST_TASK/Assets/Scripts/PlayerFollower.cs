using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private Player _player;
    private Vector3 _offset;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _offset = transform.position - _player.transform.position;
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 position = _player.transform.position + _offset;

        position.x = transform.position.x;
        position.y = transform.position.y;

        transform.position = position;
    }
}
