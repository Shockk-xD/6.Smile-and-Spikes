using DG.Tweening;
using UnityEngine;

public class StickEnemyIdleAnimation : MonoBehaviour
{
    [SerializeField] private float _duration = 0.25f;
    [SerializeField] private float _dumping = 0.1f;

    private Sequence _animationSequence;
    private Transform _skin;

    private float _localScaleY;

    private void Start() {
        _skin = transform.GetChild(0);
        _localScaleY = _skin.localScale.y;

        StartSequence();
    }

    private void OnEnable() {
        StartSequence();
    }

    private void StartSequence() {
        _animationSequence = DOTween.Sequence();

        _animationSequence.Append(_skin.DOLocalMoveX(_dumping, _duration))
                            .Join(_skin.DOScaleY(_localScaleY - _dumping, _duration))
                            .SetLoops(-1, LoopType.Yoyo);
    }

    private void ResetTransform() {
        _skin.localScale = new Vector3(_skin.localScale.x, _localScaleY, _skin.localScale.z);
        _skin.localPosition = Vector3.zero;
    }

    private void OnDisable() {
        _animationSequence.Pause();
        ResetTransform();
    }
}
