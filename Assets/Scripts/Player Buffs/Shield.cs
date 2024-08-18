using UnityEngine;
using Zenject;

public class Shield : MonoBehaviour
{
    private PlayerShield _playerShield;

    [Inject]
    public void Construct(PlayerShield playerShield) {
        _playerShield = playerShield;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerHealth>()) {
            _playerShield.enabled = true;
            _playerShield.Activate();
            Destroy(gameObject);
        }
    }
}
