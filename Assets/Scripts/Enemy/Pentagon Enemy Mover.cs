using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class PentagonEnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private float _maxDistanceToPlayer = 3.5f;
    [SerializeField] private float _destroyY = -8;

    private Transform _player;

    [Inject]
    public void Construct(PlayerHealth playerHealth) {
        _player = playerHealth.transform;   
    }

    private void Start() {
        ApproachToPlayer();
    }

    private void Update() {
        transform.Translate(_speed * Time.deltaTime * Vector2.down);

        if (transform.position.y < _destroyY)
            Destroy(gameObject);
    }

    private async void ApproachToPlayer() {
        while (Mathf.Abs(transform.position.y - _player.position.y) > _maxDistanceToPlayer) {
            transform.position = new Vector2(
                Mathf.MoveTowards(
                    transform.position.x, 
                    _player.position.x, 
                    Time.deltaTime * _speed
                    ),
                transform.position.y
                );

            await UniTask.Yield(PlayerLoopTiming.Update);
        }
    }
}
