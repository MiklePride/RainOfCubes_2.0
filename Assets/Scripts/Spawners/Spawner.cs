using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected SpawnableObject _prefab;

    protected ObjectPool<SpawnableObject> _pool;
    protected int _poolCapacity = 20;
    protected int _poolMaxSize = 20;

    public Stats Stats;

    private void Awake()
    {
        _pool = new ObjectPool<SpawnableObject>(
            createFunc: () => OnCreate(_prefab),
            actionOnGet: (element) => OnGetElement(element),
            actionOnRelease: (element) => OnRelease(element),
            actionOnDestroy: (element) => OnDestroyElement(element),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);

        Stats = new Stats();
    }

    protected SpawnableObject OnCreate(SpawnableObject element)
    {
        Stats.CreatedObjectsAmount++;

        return Instantiate(element);
    }

    protected virtual void OnGetElement(SpawnableObject element)
    {
        element.gameObject.SetActive(true);
        element.Returned += OnReturnToPool;
        Stats.ActiveObjectAmount = _pool.CountActive;
        Stats.AmountObjectsSpawnedForAllTime++;
    }

    protected void OnRelease(SpawnableObject element)
    {
        element.Returned -= OnReturnToPool;
        element.gameObject.SetActive(false);
        Stats.ActiveObjectAmount = _pool.CountActive;
    }

    protected virtual void OnReturnToPool(SpawnableObject element)
    {
        _pool.Release(element);
    }

    protected void OnDestroyElement(SpawnableObject element)
    {
        Destroy(element.gameObject);

        Stats.CreatedObjectsAmount = _pool.CountAll;
    }

    public void Initialize()
    {
        
    }

    public void Spawn()
    {
        _pool.Get();
    }
}
