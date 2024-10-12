using System;
using UnityEngine;

public class Stats
{
    private int _amountObjectsSpawnedForAllTime = 0;
    private int _createdObjectsAmount = 0;
    private int _activeObjectsAmount = 0;

    public event Action<int> AmountObjectsSpawnedChenged;
    public event Action<int> CreatedObjectsAmountChenged;
    public event Action<int> ActiveObjectsAmountChenged;

    public void Update(int spawnedObjectsCount, int createdObjectsCount, int activeObjectsCount)
    {
        if (_amountObjectsSpawnedForAllTime != spawnedObjectsCount)
        {
            _amountObjectsSpawnedForAllTime = spawnedObjectsCount;
            AmountObjectsSpawnedChenged?.Invoke(_amountObjectsSpawnedForAllTime);
        }

        if (_createdObjectsAmount != createdObjectsCount)
        {
            _createdObjectsAmount = createdObjectsCount;
            CreatedObjectsAmountChenged?.Invoke(_createdObjectsAmount);
        }

        if(_activeObjectsAmount != activeObjectsCount)
        {
            _activeObjectsAmount = activeObjectsCount;
            ActiveObjectsAmountChenged?.Invoke(_activeObjectsAmount);
        }
    }
}
