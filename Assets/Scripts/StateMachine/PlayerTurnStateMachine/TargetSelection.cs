using UnityEngine;
using System.Collections.Generic;

public class TargetSelection : BTurnItems
{
    private Dictionary<EAttackType, BAttackItems> _states = new Dictionary<EAttackType, BAttackItems>();
    private EAttackType nextStateKey;
    private BAttackItems _currentState;
    AttackStateData _data;
    private bool _inTransitioningState = false;
 
    public TargetSelection(ETurnItems stateKey, StateData Data) : base(stateKey, Data)
    {
    }

    public override void OnAwake()
    {
        _data = new AttackStateData(Data.UnitLayer, Data.Grid);
        _states.Add(EAttackType.Line, new Line(EAttackType.Line, _data));
        _states.Add(EAttackType.Area, new Area(EAttackType.Area, _data));



    }

    public override void OnLeftClick(){}
    public override void EnterState()
    {
        _data.CurrentAttack = Data.TargetUnit.CurrentAttack;
        _data.TargetUnit = Data.TargetUnit;
        Debug.Log($"Selecting attack range of {Data.TargetUnit.CurrentAttack.RANGE}");
        _currentState = _states[Data.TargetUnit.CurrentAttack.TYPE];

        _currentState.EnterState();
    }
    public override void ExitState()
    {
        _currentState.ExitState();
    }
    public override void UpdateState()
    {
        if (!_inTransitioningState && nextStateKey.Equals(_currentState.StateKey))
        {
            _currentState.UpdateState();
        }
        else
        {
            TransitionToState(nextStateKey);
        }
    }
    
    private void TransitionToState(EAttackType Statekey){
        _inTransitioningState = true;
        _currentState.ExitState();
        _currentState = _states[Statekey];
        _currentState.ResetStateKey();
        _currentState.EnterState();
        _inTransitioningState = false;
    }
    public override ETurnItems GetNextState(){ return _nextState; }
}
