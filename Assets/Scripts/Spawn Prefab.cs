using System;
using UnityEngine;
using Zenject;

public class SpawnPrefab : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _time;
    [SerializeField] private bool _repeat;
    [SerializeField] private float _repeatTime;

    private DiContainer _container;

    [Inject]
    public void Construct(DiContainer diContainer) {
        _container = diContainer;
    }

    private void Spawn() {
        var prefab = _container.InstantiatePrefab(_prefab);
        prefab.transform.position = transform.position;
    }

    private void OnEnable() {
        if (!_prefab) {
            throw new NullReferenceException();
        }

        if (_repeat) {
            InvokeRepeating(nameof(Spawn), _time, _repeatTime);
        } else {
            Invoke(nameof(Spawn), _time);
        }
    }

    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }
}
