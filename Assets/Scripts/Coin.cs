using UnityEngine;
using Zenject;

public class Coin : MonoBehaviour
{
    private CoinBank _coinBank;

    [Inject]
    public void Construct(CoinBank coinBank) {
        _coinBank = coinBank;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerHealth>()) {
            _coinBank.IncrementBalance();
            Destroy(gameObject);
        }
    }
}
