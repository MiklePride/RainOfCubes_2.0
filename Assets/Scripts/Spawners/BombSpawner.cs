using UnityEngine;

public class BombSpawner : Spawner
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    private Vector3 _spawnPoint;

    private void OnEnable()
    {
        _cubeSpawner.CubeReturned += OnSpawnAtSpawnPoint;
    }

    private void OnDestroy()
    {
        _cubeSpawner.CubeReturned -= OnSpawnAtSpawnPoint;
    }

    private void OnSpawnAtSpawnPoint(Vector3 spawnPoint)
    {
        _spawnPoint = spawnPoint;

        Spawn();
    }

    protected override void OnGetElement(SpawnableObject element)
    {
        element.transform.position = _spawnPoint;

        base.OnGetElement(element);
    }
}
