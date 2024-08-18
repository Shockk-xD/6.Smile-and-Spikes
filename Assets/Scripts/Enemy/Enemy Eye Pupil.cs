using UnityEngine;
using Zenject;

public class EnemyEyePupil : MonoBehaviour
{
    [SerializeField] private Transform _pupil;
    [SerializeField] private float _radius = 1;

    private Transform _playerTransform;

    [Inject]
    public void Construct(PlayerHealth playerHealth) {
        _playerTransform = playerHealth.transform;
    }

    private void Update() {
        var toPlayer = (_playerTransform.position - transform.position).normalized;
        var localDirection = transform.InverseTransformDirection(toPlayer);
        _pupil.localPosition = localDirection * _radius;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
