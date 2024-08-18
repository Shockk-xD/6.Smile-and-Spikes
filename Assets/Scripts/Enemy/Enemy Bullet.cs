using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 3;

    private Rigidbody2D _rb;
    private Transform _playerTransform;

    [Inject]
    public void Construct(PlayerHealth playerHealth) {
        _playerTransform = playerHealth.transform;
    }

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();

        Setup();
        float secondsToDestroy = 5;
        Destroy(gameObject, secondsToDestroy);
    }

    private void Setup() {
        var toPlayer = _playerTransform.position - transform.position;
        var angleToRotate = Mathf.Atan2(toPlayer.y, toPlayer.x) * Mathf.Rad2Deg;
        float angleOffset = -90;
        transform.rotation = Quaternion.Euler(0, 0, angleToRotate + angleOffset);

        _rb.velocity = transform.up * _bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
    }
}
