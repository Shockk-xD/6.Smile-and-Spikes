using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class BlockLineSpawner : MonoBehaviour
{
    [field: SerializeField] public float Speed { get; private set; } = 3;
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private List<BlockLineContainer> _blockLines;

    private readonly float _speedIncreaseMultiplier = 0.01f;
    private DiContainer _container;
    private ScoreManager _scoreManager;

    [Inject]
    public void Construct(DiContainer container, ScoreManager scoreManager) {
        _container = container;
        _scoreManager = scoreManager;
    }

    public void SpawnBlockLine()
    {
        var blockLinePrefab = SelectBlockLinePrefab();

        _container.InstantiatePrefab(
            blockLinePrefab,
            _spawnPosition,
            Quaternion.identity,
            transform
            );
    }

    private void Update() {
        Speed += Time.deltaTime * _speedIncreaseMultiplier;
    }

    private GameObject SelectBlockLinePrefab() {
        int randIndex;
        foreach (var blockLine in _blockLines) {
            if (_scoreManager.Score.CurrentValue < blockLine.threshold) {
                randIndex = Random.Range(0, blockLine.blocks.Count);
                return blockLine.blocks[randIndex];
            }
        }

        randIndex = Random.Range(0, _blockLines[^1].blocks.Count);
        return _blockLines[^1].blocks[randIndex];
    }
}
