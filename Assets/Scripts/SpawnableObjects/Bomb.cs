using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Bomb : SpawnableObject
{
    private float _force = 50f;
    private float _radius = 30f;

    public override event Action<SpawnableObject> Returned;

    private void OnEnable()
    {
        SetDefaultState();
        StartRandomLifeTime();
    }

    private void InterpolateAlphaChannel()
    {
        float targetValueAlpha = 0;
        Renderer.material.DOFade(targetValueAlpha, LifeTime);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out SpawnableObject spawnableObject))
                spawnableObject.AddExplosionForce(transform.position, _force, _radius);
        }
    }

    protected override IEnumerator StartCountDown()
    {
        InterpolateAlphaChannel();

        yield return new WaitForSeconds(LifeTime);

        LifeTime = 0;

        Explode();
        Returned?.Invoke(this);
    }
}
