using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinAttractionAbility : MonoBehaviour
{
    [SerializeField] private float _attractionRadius = 5;
    [SerializeField] private float _attractionFrequency = 0.5f;
    [SerializeField] private float _attractionSpeed = 1.5f;
    [SerializeField] private float _attractionTime = 5;

    [SerializeField] private PlayerAbilitiesView _view;

    private readonly List<Coin> _coins = new();

    public void Activate() {
        _view.Show<CoinAttractionAbility>(_attractionTime);
        CancelInvoke(nameof(Disactivate));
        Invoke(nameof(Disactivate), _attractionTime);
    }

    private void Disactivate() {
        this.enabled = false;
    }

    private void OnEnable() {
        InvokeRepeating(nameof(FindCoinsInRadius), 0, _attractionFrequency);
    }

    private void OnDisable() {
        CancelInvoke(nameof(FindCoinsInRadius));
    }

    private void FindCoinsInRadius() {
        var colliders = Physics2D.OverlapCircleAll(transform.position, _attractionRadius);

        foreach (var collider in colliders) {
            var coin = collider.GetComponent<Coin>();

            if (coin && !_coins.Contains(coin))
                _coins.Add(coin);
        }
    }

    private void Update() {
        Attract();
    }

    private void Attract() {
        foreach (var coin in _coins) {
            if (coin) {
                coin.transform.position = Vector2.MoveTowards(
                    coin.transform.position,
                    transform.position,
                    _attractionSpeed * Time.deltaTime
                    );
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _attractionRadius);
    }
}
