using UnityEngine;
using Zenject;

[RequireComponent(typeof(SpawnPrefab))]
public class OctagonEnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2;
    [SerializeField] private float _maxDistanceFromPlayer = 3;
    [SerializeField] private float _destroyY = -8;

    private Transform _playerTransform;
    private bool _hasReachedPlayer = false;
    private Vector2 _directionToPlayer;

    [Inject]
    public void Construct(PlayerHealth playerHealth) {
        _playerTransform = playerHealth.transform;
    }

    private void Update() {
        if (transform.position.y - _playerTransform.position.y >= _maxDistanceFromPlayer) {
            Move(Vector2.down);
        } else {
            if (!_hasReachedPlayer) {
                _hasReachedPlayer = true;
                _directionToPlayer = _playerTransform.position - transform.position;
                GetComponent<SpawnPrefab>().enabled = false;
            }
            Move(_directionToPlayer);
        }

        if (transform.position.y < _destroyY)
            Destroy(gameObject);
    }

    private void Move(Vector2 direction) {
        transform.Translate(_moveSpeed * Time.deltaTime * direction);
    }
}
