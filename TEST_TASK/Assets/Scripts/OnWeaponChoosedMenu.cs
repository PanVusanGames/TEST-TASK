using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnWeaponChoosedMenu : MonoBehaviour, IMenu
{
    [SerializeField] private GameObject _gameObjectToShow;

    private void Awake()
    {
        FindObjectOfType<Player>().OnPlayerTakeWeaponInHands += Open;
        FindObjectOfType<EnemiesHolder>().OnAllEnemiesDeath += Close;

        Close();
    }

    public void Open()
    {
        _gameObjectToShow.SetActive(true);
    }

    public void Close()
    {
        _gameObjectToShow.SetActive(false);
    }
}
