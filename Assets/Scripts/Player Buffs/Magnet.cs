using UnityEngine;
using Zenject;

public class Magnet : MonoBehaviour
{
    private CoinAttractionAbility _coinAttractionAbility;

    [Inject]
    public void Construct(CoinAttractionAbility coinAttractionAbilityUI) {
        _coinAttractionAbility = coinAttractionAbilityUI;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerHealth>()) {
            _coinAttractionAbility.enabled = true;
            _coinAttractionAbility.Activate();
            Destroy(gameObject);
        }
    }
}
