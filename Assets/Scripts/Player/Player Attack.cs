using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private RectTransform _joystickHandle;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _attackDelay = 0.3f;

    private Vector2 BulletDirection => _joystickHandle.position.normalized;
    private bool _canAttack = true;

    private void Update() {
        if (_canAttack && BulletDirection != Vector2.zero) {


            _canAttack = false;
            Invoke(nameof(EnableAttack), _attackDelay);
        }
    }

    private void CreateBullet() {
        var bullet = Instantiate(_bullet);
        bullet.transform.position = transform.position;
        bullet.transform.eulerAngles = BulletDirection; // ?
    }

    private void EnableAttack() => _canAttack = true;
}
