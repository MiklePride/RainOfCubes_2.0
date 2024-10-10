using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody), typeof(MeshRenderer))]
public abstract class SpawnableObject : MonoBehaviour
{
    protected Rigidbody Rigidbody;
    protected MeshRenderer Renderer;
    protected Color DefaultColor;

    protected float LifeTime;
    protected int MinLifeTime = 2;
    protected int MaxLifeTime = 5;

    protected Coroutine Coroutine;

    public abstract event Action<SpawnableObject> Returned;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<MeshRenderer>();
        DefaultColor = Renderer.material.color;
    }

    protected abstract IEnumerator StartCountDown();

    protected void StartRandomLifeTime()
    {
        LifeTime = Random.Range(MinLifeTime, MaxLifeTime + 1);

        if (Coroutine != null)
        {
            StopCoroutine(StartCountDown());
        }

        Coroutine = StartCoroutine(StartCountDown());
    }

    protected void SetDefaultState()
    {
        Renderer.material.color = DefaultColor;
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.rotation = Quaternion.identity;
    }

    public void AddExplosionForce(Vector3 explosionPosition, float force, float radius)
    {
        float upwardsModifier = 0.5f;

        Rigidbody.AddExplosionForce(force, explosionPosition, radius, upwardsModifier, ForceMode.Impulse);
    }
}
