using UnityEngine;
using Zenject;

public class PlayerEnemyCollisionToggle : MonoBehaviour
{
    [SerializeField] private string _playerLayer = "Player Health";
    [SerializeField] private string _enemyLayer = "Player Damager";

    private int _playerLayerId;
    private int _enemyLayerId;
    private PlayerHealth _playerHealth;

    [Inject]
    public void Construct(PlayerHealth playerHealth) {
        _playerHealth = playerHealth;
    }

    private void Start() {
        _playerLayerId = LayerMask.NameToLayer(_playerLayer);
        _enemyLayerId = LayerMask.NameToLayer(_enemyLayer);
    }

    private void OnEnable() {
        _playerHealth.OnHealthDecreased += DisableCollision;
    }

    private void OnDisable() {
        _playerHealth.OnHealthDecreased -= DisableCollision;
    }

    private void DisableCollision() {
        Physics2D.IgnoreLayerCollision(_playerLayerId, _enemyLayerId, true);
        Invoke(nameof(EnableCollision), _playerHealth.DamageCooldown);
    }

    private void EnableCollision() {
        Physics2D.IgnoreLayerCollision(_playerLayerId, _enemyLayerId, false);
    } 
}
