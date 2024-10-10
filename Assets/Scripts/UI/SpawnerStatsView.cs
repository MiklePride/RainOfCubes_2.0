using TMPro;
using UnityEngine;

public class SpawnerStatsView : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private string _name;
    [SerializeField] private string _createdObjectsHeader = "�������� �������: ";
    [SerializeField] private string _spawnedObjectsHeader = "�������� ���������� �� �� �����: ";
    [SerializeField] private string _activeObjectsHeader = "�������� ��������: ";

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
        _spawner.Stats.CreatedObjectsAmountChenged -= OnUpdateCreatedObjects;
        _spawner.Stats.AmountObjectsSpawnedChenged -= OnUpdateSpawnedObjects;
        _spawner.Stats.ActiveObjectsAmountChenged -= OnUpdateActiveObjects;
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

    public void Initialize()
    {
        _spawner.Stats.CreatedObjectsAmountChenged += OnUpdateCreatedObjects;
        _spawner.Stats.AmountObjectsSpawnedChenged += OnUpdateSpawnedObjects;
        _spawner.Stats.ActiveObjectsAmountChenged += OnUpdateActiveObjects;

        _nameText.text = _name;
        _createdObjectsAmount.text = _createdObjectsHeader;
        _spawnedObjectsAmount.text = _spawnedObjectsHeader;
        _activeObjectsAmount.text = _activeObjectsHeader;
    }
}