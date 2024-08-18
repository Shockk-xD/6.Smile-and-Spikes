using UnityEngine;
using Zenject;

public class BlockLineMover : MonoBehaviour
{
    private const float DESTROY_Y_POSITION = -11.05f;
    private BlockLineSpawner _spawner;

    [Inject]
    public void Construct(BlockLineSpawner spawner) {
        _spawner = spawner;
    }

    private void Update()
    {
        transform.Translate(_spawner.Speed * Time.deltaTime * Vector2.down);

        if (transform.position.y <= DESTROY_Y_POSITION)
        {
            _spawner.SpawnBlockLine();
            Destroy(gameObject);
        }
    }
}
