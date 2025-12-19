using UnityEngine;
using System;

public abstract class BTurnItemsE
{
    protected StateDataE Data{ get; set; }
    public ETurnItems StateKey { get; private set; }
    protected ETurnItems _nextState;


    public BTurnItemsE(ETurnItems key, StateDataE data)
    {
        StateKey = key;
        _nextState = key;
        Data = data;
    }
    public virtual void OnAwake(){}
    public void ResetStateKey(){_nextState = StateKey;}
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract ETurnItems GetNextState();
}
