using UnityEngine;
using System;

public class Area : BAttackItems
{
    public Area(EAttackType key, AttackStateData data) : base(key, data){}
    
    public override void OnLeftClick(){}
    public override void EnterState(){}
    public override void ExitState(){}
    public override void UpdateState(){}
    public override EAttackType GetNextState(){return _nextState;}
}
