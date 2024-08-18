using UnityEngine;
using UnityEngine.UI;

public class RechargableAbilityView : MonoBehaviour
{
    private Image _abilityImage;
    private float _timer = 0;
    private float _timerTime = 1;

    public void SetTimer(float time) {
        _timer = _timerTime = time;
    }

    private void Start() {
        _abilityImage = GetComponent<Image>();
    }

    private void Update() {
        _timer -= Time.deltaTime;
        _abilityImage.fillAmount = _timer / _timerTime;

        if (_timer <= 0)
            Destroy(gameObject);
    }
}
