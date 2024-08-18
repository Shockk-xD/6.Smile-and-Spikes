using R3;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private IDisposable _scoreManagerSubscription;
    private ScoreManager _scoreManager;

    [Inject]
    public void Construct(ScoreManager scoreManager) {
        _scoreManager = scoreManager;
    }

    private void UpdateScoreView(int score) {
        _scoreText.text = score.ToString();
    }

    private void OnEnable() {
        _scoreManagerSubscription = _scoreManager.Score.Subscribe(UpdateScoreView);
    }

    private void OnDisable() {
        _scoreManagerSubscription.Dispose();
    }
}
