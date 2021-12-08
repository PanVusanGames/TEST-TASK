using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/Weapon", order = 1)]
public class WeaponData : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private float _shotRate;
    [SerializeField] private float _spread;
    [SerializeField] private int _projectilesPerShot;
    [SerializeField] private AudioClip _shotClip;

    public int Damage => _damage;
    public float ShotRate => _shotRate;
    public float Spread => _spread;
    public int ProjectilesPerShot => _projectilesPerShot;
    public AudioClip ShotClip => _shotClip;
}