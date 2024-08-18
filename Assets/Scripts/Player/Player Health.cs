using R3;
using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public Observable<int> Health => _health;
    public event Action OnHealthDecreased;

    [field: SerializeField] public float DamageCooldown { get; private set; } = 2;
    [field: SerializeField, Range(1, 3)] public int MaxHealth { get; private set; } = 3;

    private readonly ReactiveProperty<int> _health = new();
    private bool _isInvincible = false;

    private void Start() {
        _health.Value = MaxHealth;
    }

    public bool TryDecrease() {
        if (_isInvincible) return false;

        _health.Value--;
        if (_health.Value <= 0) {
            Debug.Log("Died");
            return true;
        }

        OnHealthDecreased.Invoke();
        StartInvincible(DamageCooldown);
        return true;
    }

    public void StartInvincible(float time) {
        _isInvincible = true;
        Invoke(nameof(StopInvincible), time);
    }

    private void StopInvincible() => _isInvincible = false;
}
