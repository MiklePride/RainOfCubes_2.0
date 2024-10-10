using System.Collections;
using UnityEngine;

public class Rain : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private float _repeatRate = 1f;

    private Coroutine _coroutine;

    private void Start()
    {
        _coroutine = StartCoroutine(StartRain());
    }

    private IEnumerator StartRain()
    {
        var wait = new WaitForSeconds(_repeatRate);

        while (enabled)
        {
            _cubeSpawner.Spawn();

            yield return wait;
        }
    }
}