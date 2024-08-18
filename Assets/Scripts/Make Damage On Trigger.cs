using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        var playerHealth = collision.GetComponent<PlayerHealth>();

        if (playerHealth) {
            playerHealth.TryDecrease();
        }
    }
}
