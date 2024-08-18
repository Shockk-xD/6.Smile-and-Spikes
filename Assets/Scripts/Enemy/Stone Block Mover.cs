using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class StoneBlockMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

    private bool _blockMoving = false;

    private void Update() {
        if (!_blockMoving)
            transform.Translate(_speed * Time.deltaTime * Vector2.down, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerHealth>()) {
            HitAnimation();
        }
    }

    private void HitAnimation() {
        _blockMoving = true;
        var hitOffset = 0.1f;
        var destinyPosition = (Vector2)transform.position + Vector2.one * hitOffset;
        var hitRotationAngle = -20f;
        var destinyRotation = new Vector3(0, 0, hitRotationAngle);

        transform.DOLocalMove(destinyPosition, 0.5f);
        transform.DOLocalRotate(destinyRotation, 0.5f);

        _blockMoving = false;
        destinyRotation *= 2;

        transform.DOLocalRotate(destinyRotation, 1);
    }
}
