using R3;

public class CoinBank
{
    public ReadOnlyReactiveProperty<int> Balance => _balance;

    private readonly ReactiveProperty<int> _balance = new();

    public CoinBank(int balance = 0) {
        _balance.Value = balance;
    }

    public void IncrementBalance() {
        _balance.Value++;
    }
}
