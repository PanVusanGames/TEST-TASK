using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData _weaponData;
    [SerializeField] private Projectectile _projectectile;
    [SerializeField] private AudioSource _audioSource;

    private bool _canPerformShot;

    public IObjectPool<Projectectile> ProjectilePool { get; private set; }
    public int Damage => _weaponData.Damage;
    public float Spread => _weaponData.Spread;

    private void Awake()
    {       
        _canPerformShot = true;
    }

    public void PickedUpByPlayer()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        ResetRotation();

        ProjectilePool = new ObjectPool<Projectectile>(CreateProjectile, OnGet, OnRelease, maxSize: (_weaponData.ProjectilesPerShot * 10));
    }

    private Projectectile CreateProjectile()
    {
        return Instantiate(_projectectile);
    }

    private void OnGet(Projectectile projectile)
    {
        projectile.InitializeProjectileBasedOn(this);
    }

    private void OnRelease(Projectectile projectile)
    {
        projectile.Disable();
    }

    private void ResetRotation()
    {
        transform.localRotation = Quaternion.Euler(Vector3.zero);

        foreach (Transform child in transform)
        {
            child.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }

    public void TryToShot()
    {
        if (_canPerformShot)
        {
            Shot();
            StartCoroutine(ReloadWeapon());
        }
    }

    private void Shot()
    {
        StartCoroutine(SingleShot());
    }

    IEnumerator SingleShot()
    {
        for (int i = 0; i < _weaponData.ProjectilesPerShot; i++)
        {
            PlayShotAudio();
            ProjectilePool.Get();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void PlayShotAudio()
    {
        if (_audioSource.clip != _weaponData.ShotClip)
        {
            _audioSource.clip = _weaponData.ShotClip;
        }
        float randomPitch = UnityEngine.Random.Range(0.8f, 1.2f);
        _audioSource.pitch = randomPitch;

        _audioSource.Play();
    }

    IEnumerator ReloadWeapon()
    {
        _canPerformShot = false;

        float time = _weaponData.ShotRate;
        do
        {
            time = time - Time.deltaTime;
            yield return null;
        }
        while (time > 0);

        _canPerformShot = true;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
