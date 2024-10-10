using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : SpawnableObject
{
    private bool _hasBeenCollision;

    public override event Action<SpawnableObject> Returned;

    private void OnEnable()
    {
        SetDefaultState();
        _hasBeenCollision = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Platform platform))
            Die();
    }

    private void Die()
    {
        if (_hasBeenCollision)
            return;

        SetRandomColor();
        StartRandomLifeTime();

        _hasBeenCollision = true;
    }

    private void SetRandomColor()
    {
        float minValue = 0f;
        float maxValue = 1f;
        Renderer.material.color = new Color(Random.Range(minValue, maxValue), Random.Range(minValue, maxValue), Random.Range(minValue, maxValue));
    }

    protected override IEnumerator StartCountDown()
    {
        yield return new WaitForSeconds(LifeTime);

        LifeTime = 0;
        Returned?.Invoke(this);
    }
}
