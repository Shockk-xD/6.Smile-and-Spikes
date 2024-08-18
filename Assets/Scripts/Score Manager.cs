using R3;
using System;
using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ReadOnlyReactiveProperty<int> Score => _score;

    [SerializeField] private AnimationCurve _scoreIncreaseTime;

    private readonly ReactiveProperty<int> _score = new();
    private float _timeToWait;

    private void Start() {
        _score.Value = 0;

        StartCoroutine(ScoreAdding());
    }

    private IEnumerator ScoreAdding() {
        while (true) {
            _timeToWait = _scoreIncreaseTime.Evaluate(Time.time);
            yield return new WaitForSeconds(_timeToWait);
            _score.Value++;
        }
    }
}
