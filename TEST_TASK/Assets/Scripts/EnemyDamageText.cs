using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDamageText : MonoBehaviour
{
    [SerializeField] private TextMeshPro _damageText;
    [SerializeField] private Animator _damageTextAnimator;

    private void Awake()
    {
        GetComponent<Enemy>().OnDamageDecreasePer += ShowText;
    }

    private void ShowText(int damageAmount)
    {
        _damageText.text = $"{damageAmount}";
        _damageTextAnimator.Play("Show");
    }
}
