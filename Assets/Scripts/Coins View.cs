using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CoinsView : MonoBehaviour
{
    private Text _text;
    private CoinBank _coinBank;
    private readonly CompositeDisposable _coinBankSubscription = new();

    [Inject]
    public void Construct(CoinBank coinBank) {
        _coinBank = coinBank;
    }

    private void Awake() {
        _text = GetComponentInChildren<Text>();
    }

    private void OnEnable() {
        _coinBank.Balance.Subscribe(UpdateText).AddTo(_coinBankSubscription);
    }

    private void OnDisable() {
        _coinBankSubscription.Dispose();
    }

    private void UpdateText(int coinsAmount) {
        _text.text = coinsAmount.ToString();
    }
}
