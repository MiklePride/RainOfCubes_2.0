using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : Spawner
{
    private const float Altitude = 30f;

    public event Action<Vector3> CubeReturned;

    protected override void OnGetElement(SpawnableObject element)
    {
        float minRandomValue = -15;
        float maxRandomValue = 15;
        element.transform.position = new Vector3(Random.Range(minRandomValue, maxRandomValue + 1), Altitude, Random.Range(minRandomValue, maxRandomValue + 1));

        base.OnGetElement(element);
    }

    protected override void OnReturnToPool(SpawnableObject element)
    {
        CubeReturned?.Invoke(element.transform.position);
        base.OnReturnToPool(element);
    }
}
