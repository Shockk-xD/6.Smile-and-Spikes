using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerShield : MonoBehaviour
{
    [SerializeField] private PlayerAbilitiesView _abilitiesView;
    [SerializeField] private float _actionTime = 5;

    private PlayerHealth _playerHealth;
    private SpriteRenderer _shieldImage;

    [Inject]
    public void Construct(PlayerHealth playerHealth) {
        _playerHealth = playerHealth;
    }

    private void Start() {
        _shieldImage = GetComponent<SpriteRenderer>();
    }

    public void Activate() {
        _abilitiesView.Show<PlayerShield>(_actionTime);
        _playerHealth.StartInvincible(_actionTime);
        _shieldImage.enabled = true;

        CancelInvoke(nameof(Disactivate));
        Invoke(nameof(Disactivate), _actionTime);
    }

    private void Disactivate() {
        _shieldImage.enabled = false;
    }
}
