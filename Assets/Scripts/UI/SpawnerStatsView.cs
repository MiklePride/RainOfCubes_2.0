using TMPro;
using UnityEngine;

public class SpawnerStatsView : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private string _name;
    [SerializeField] private string _createdObjectsHeader = "Объектов создано: ";
    [SerializeField] private string _spawnedObjectsHeader = "Объектов заспавнено за всё время: ";
    [SerializeField] private string _activeObjectsHeader = "Активных Объектов: ";

    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _createdObjectsAmount;
    [SerializeField] private TMP_Text _spawnedObjectsAmount;
    [SerializeField] private TMP_Text _activeObjectsAmount;

    private void Start()
    {
        Initialize();
    }

    private void OnDestroy()
    {
        Stats stats = _spawner.GetStats();

        stats.CreatedObjectsAmountChenged -= OnUpdateCreatedObjects;
        stats.AmountObjectsSpawnedChenged -= OnUpdateSpawnedObjects;
        stats.ActiveObjectsAmountChenged -= OnUpdateActiveObjects;
    }

    private void OnUpdateCreatedObjects(int createdCount)
    {
        _createdObjectsAmount.text = $"{_createdObjectsHeader}  {createdCount}";
    }

    private void OnUpdateSpawnedObjects(int spawnedCount)
    {
        _spawnedObjectsAmount.text = $"{_spawnedObjectsHeader} {spawnedCount}";
    }

    private void OnUpdateActiveObjects(int activeObjectsCount)
    {
        _activeObjectsAmount.text = $"{_activeObjectsHeader} {activeObjectsCount}";
    }

    private void Initialize()
    {
        Stats stats = _spawner.GetStats();

        stats.CreatedObjectsAmountChenged += OnUpdateCreatedObjects;
        stats.AmountObjectsSpawnedChenged += OnUpdateSpawnedObjects;
        stats.ActiveObjectsAmountChenged += OnUpdateActiveObjects;

        _nameText.text = _name;
        _createdObjectsAmount.text = _createdObjectsHeader;
        _spawnedObjectsAmount.text = _spawnedObjectsHeader;
        _activeObjectsAmount.text = _activeObjectsHeader;
    }
}
