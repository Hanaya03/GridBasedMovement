using UnityEngine;
using System.Collections.Generic;

public class TargetSelection : BTurnItems
{
    private bool _selecting = true;
    private Dictionary<EAttackType?, BAttackItems> _states = new Dictionary<EAttackType?, BAttackItems>();
    private EAttackType? nextStateKey;
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

    public override void OnLeftClick()
    {
        if (_data.CurrentAttack == null)
        {
            return;
        }
        _currentState.OnLeftClick();
    }
    public override void EnterState()
    {
        _data.CurrentAttack = null;
        for(int i = 0; i < Data.TargetUnit.Attacks.Length; i++)
        {
            Data.AttackButtonGOArr[i].SetActive(true);
        }
    
        Data.AttackButtonArr[0].onClick.AddListener(SelectAttackA);
        Data.AttackButtonArr[1].onClick.AddListener(SelectAttackB);
        Data.AttackButtonArr[2].onClick.AddListener(SelectAttackC);
        Data.AttackButtonArr[3].onClick.AddListener(SelectAttackD);

    // _data.CurrentAttack = Data.TargetUnit.CurrentAttack;
        _data.TargetUnit = Data.TargetUnit;
        // Debug.Log($"Selecting attack range of {Data.TargetUnit.CurrentAttack.RANGE}");
        // _currentState = _states[Data.TargetUnit.CurrentAttack.TYPE];

        // _currentState.EnterState();
    }
        
    public void SelectAttackA(){_data.CurrentAttack = Data.TargetUnit.Attacks[0]; SelectAttack();}
    public void SelectAttackB(){_data.CurrentAttack = Data.TargetUnit.Attacks[1]; SelectAttack();}
    public void SelectAttackC(){_data.CurrentAttack = Data.TargetUnit.Attacks[2]; SelectAttack();}
    public void SelectAttackD(){_data.CurrentAttack = Data.TargetUnit.Attacks[3]; SelectAttack();}


    public void SelectAttack()
    {
        _currentState = _states[_data.CurrentAttack.TYPE];
        _currentState.ResetStateKey();
        _currentState.EnterState();

        for(int i = 0; i < Data.TargetUnit.Attacks.Length; i++)
        {
            Data.AttackButtonGOArr[i].SetActive(false);
        }
    }

    public override void ExitState()
    {
        _currentState.ExitState();
        _data.CurrentAttack = null;
    }
    public override void UpdateState()
    {
        if (_data.CurrentAttack == null)
        {
            Debug.Log("Null state");
            return;
        }

        nextStateKey = _currentState.GetNextState();

        if (!_inTransitioningState && nextStateKey.Equals(_currentState.StateKey))
        {
            _currentState.UpdateState();
        }
        else
        {
            if(nextStateKey == null){
                _nextState = ETurnItems.Waiting;
            }else{
                TransitionToState(nextStateKey);
            }
        }
    }
    
    private void TransitionToState(EAttackType? Statekey){
        _inTransitioningState = true;
        _currentState.ExitState();
        _currentState = _states[Statekey];
        _currentState.ResetStateKey();
        _currentState.EnterState();
        _inTransitioningState = false;
    }
    public override ETurnItems GetNextState(){ return _nextState; }
}
