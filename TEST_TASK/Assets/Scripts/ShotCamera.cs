using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCamera : MonoBehaviour
{
    private void Awake()
    {
        var player = FindObjectOfType<Player>();
        var offset = player.transform.position - Camera.main.transform.position;
        var thisCamera = GetComponent<Camera>();
        thisCamera.nearClipPlane = offset.z * 2f;
    }
}
