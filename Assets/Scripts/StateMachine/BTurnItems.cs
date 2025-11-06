using UnityEngine;
using System;

public abstract class BTurnItems<EState> where EState : Enum
{
    protected StateData Data{ get; set; }
    public EState StateKey{get; private set;}

    public BTurnItems(EState key, StateData data)
    {
        StateKey = key;
        Data = data;
    }

    public abstract void OnLeftClick();
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract EState GetNextState();
}
