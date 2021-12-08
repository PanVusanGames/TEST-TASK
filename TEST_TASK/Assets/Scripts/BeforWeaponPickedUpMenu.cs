using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforWeaponPickedUpMenu : MonoBehaviour, IMenu
{
    [SerializeField] private GameObject _gameObjectToShow;

    private void Awake()
    {
        FindObjectOfType<Player>().OnPlayerTakeWeaponInHands += Close;
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
