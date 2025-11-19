using UnityEngine;
using System;

public abstract class BAttackItems
{
    protected AttackStateData Data{ get; set; }
    public EAttackType StateKey { get; private set; }
    protected EAttackType _nextState;


    public BAttackItems(EAttackType key, AttackStateData data)
    {
        StateKey = key;
        _nextState = key;
        Data = data;
    }
    
    public void ResetStateKey(){_nextState = StateKey;}

    public abstract void OnLeftClick();
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract EAttackType GetNextState();
}
