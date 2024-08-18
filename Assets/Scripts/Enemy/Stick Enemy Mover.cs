using System.Collections;
using UnityEngine;

public class StickEnemyMover : MonoBehaviour
{
    [SerializeField] private float _jumpCooldown = 2;
    [SerializeField] private float _jumpChancePercent = 50;

    private const float X_OFFSET = 1.283f;
    private Animator _animator;

    private void Start() {
        _animator = GetComponent<Animator>();
        transform.localPosition = new Vector3(X_OFFSET, transform.localPosition.y, 0);
        InvokeRepeating(nameof(Jump), 0, _jumpCooldown);
    }

    private void Jump() {
        int randPercent = Random.Range(0, 101);

        if (randPercent <= _jumpChancePercent) {
            StartCoroutine(JumpAnimation());
        }
    }

    private IEnumerator JumpAnimation() {
        float animationTime = 0.5f;
        var destinyPosition = new Vector2(
                -transform.localPosition.x,
                transform.localPosition.y
            );
        var destinyScale = new Vector3(-transform.localScale.x, 1, 1);

        for (float s = 0; s < animationTime; s += Time.deltaTime) {
            float t = s / animationTime;

            transform.localPosition = Vector2.Lerp(
                transform.localPosition,
                destinyPosition,
                t
                );
            transform.localScale = Vector3.Lerp(
                transform.localScale,
                destinyScale,
                t
                );

            yield return null;
        }
    }
}
