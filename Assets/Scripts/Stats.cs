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

    public int AmountObjectsSpawnedForAllTime
    {
        get
        {
            return _amountObjectsSpawnedForAllTime;
        }
        set
        {
            _amountObjectsSpawnedForAllTime = value;
            AmountObjectsSpawnedChenged?.Invoke(_amountObjectsSpawnedForAllTime);
        }
    }

    public int CreatedObjectsAmount
    {
        get
        {
            return _createdObjectsAmount;
        }
        set
        {
            _createdObjectsAmount = value;
            CreatedObjectsAmountChenged?.Invoke(_createdObjectsAmount);
        }
    }

    public int ActiveObjectAmount
    {
        get
        {
            return _activeObjectsAmount;
        }
        set
        {
            _activeObjectsAmount = value;
            ActiveObjectsAmountChenged?.Invoke(_activeObjectsAmount);
        }
    }
}
