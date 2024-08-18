using R3;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Cysharp.Threading.Tasks;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private GameObject _heartUIPrefab;

    private List<Image> _heartsList;
    private PlayerHealth _playerHealth;
    private Color _disabledColor = new(1, 1, 1, 100 / 255f);
    private Color _enabledColor = Color.white;

    private IDisposable _playerHealthSubsctiption;

    [Inject]
    public void Construct(PlayerHealth playerHealth) {
        _playerHealth = playerHealth;
    }

    private void OnEnable() {
        _playerHealthSubsctiption = _playerHealth.Health.Subscribe(UpdateView);
    }

    private void OnDisable() {
        _playerHealthSubsctiption.Dispose();
    }

    private async UniTask InitializeView(int health) {        
        await UniTask.Yield();

        _heartsList = new List<Image>(health);
        for (int i = 0; i < health; i++) {
            var heart = Instantiate(_heartUIPrefab, transform);
            _heartsList.Add(heart.GetComponent<Image>());
        }
    }

    public async void UpdateView(int health) {
        if (_heartsList == null) 
            await InitializeView(health);

        for (int i = 0; i < _heartsList.Count; i++) {
            _heartsList[i].color = _disabledColor;
        }

        for (int i = 0; i < health; i++) {
            _heartsList[i].color = _enabledColor;
        }
    }
}
