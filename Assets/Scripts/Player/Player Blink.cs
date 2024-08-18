using Cysharp.Threading.Tasks;
using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerBlink : MonoBehaviour
{
    private SpriteRenderer[] _sprites;
    private PlayerHealth _playerHealth;

    [Inject]
    public void Construct(PlayerHealth playerHealth) {
        _playerHealth = playerHealth;
    }

    private void Start() {
        _sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    private void OnEnable() {
        _playerHealth.OnHealthDecreased += Blinking;
    }

    private void OnDisable() {
        _playerHealth.OnHealthDecreased -= Blinking;
    }

    private async void Blinking() {
        for (int i = 0; i < 3; i++) {
            await ChangePlayerTransparency(transparency: 0);
            await ChangePlayerTransparency(transparency: 1);
        }
    }

    private async UniTask ChangePlayerTransparency(int transparency) {
        float blinkCount = 3;
        float timeToReach = _playerHealth.DamageCooldown / blinkCount;

        for (float s = 0; s < timeToReach / 2; s += Time.deltaTime) {
            float t = s / timeToReach;

            for (int j = 0; j < _sprites.Length; j++) {
                Color destinyColor = new Color(
                    _sprites[j].color.r,
                    _sprites[j].color.g,
                    _sprites[j].color.b,
                    transparency
                    );

                _sprites[j].color = Color.Lerp(_sprites[j].color, destinyColor, t);
            }

            await UniTask.Yield(PlayerLoopTiming.Update);
        }
    }
}
