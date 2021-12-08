using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AfterAllEnemieDeathMenu : MonoBehaviour, IMenu
{
    [SerializeField] private GameObject _gameObjectToShow;
    private void Awake()
    {
        FindObjectOfType<EnemiesHolder>().OnAllEnemiesDeath += Open;
        Close();
    }

    public void Close()
    {
        _gameObjectToShow.SetActive(false);
    }

    public void Open()
    {
        _gameObjectToShow.SetActive(true);
    }
}
