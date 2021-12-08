using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCleared : MonoBehaviour
{
    private Animator _animator;
    private Waypoint _waypoint;
    private AudioSource _audioSource;

    private void Awake()
    {
        FindObjectOfType<EnemiesHolder>().OnAllEnemiesDeath += EnableExitWaypoint;
        _waypoint = GetComponent<Waypoint>();
        _waypoint.enabled = false;
        _animator = GetComponent<Animator>();
        _audioSource = GetComponentInChildren<AudioSource>();
    }

    private void EnableExitWaypoint()
    {
        _waypoint.enabled = true;
        _animator.Play("Show");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            print("level cleared");
            _audioSource.Play();
            Invoke(nameof(RestartLevel), 1f);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
