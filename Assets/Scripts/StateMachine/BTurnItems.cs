using UnityEngine;
using System;

public abstract class BTurnItems
{
    protected StateData Data{ get; set; }
    public ETurnItems StateKey{get; private set;}

    public BTurnItems(ETurnItems key, StateData data)
    {
        StateKey = key;
        Data = data;
    }

    public abstract void OnLeftClick();
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract ETurnItems GetNextState();
}
