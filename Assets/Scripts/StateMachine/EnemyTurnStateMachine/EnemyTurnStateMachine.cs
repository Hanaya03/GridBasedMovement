using UnityEngine;
using System.Collections.Generic;

public class EnemyTurnStateMachine : MonoBehaviour
{
    [SerializeField] private UnitList _unitCache;

    private Dictionary<ETurnItems, BTurnItemsE> _states = new Dictionary<ETurnItems, BTurnItemsE>();
    private ETurnItems nextStateKey;
    public ETurnItems NextStateKey => nextStateKey;
    private BTurnItemsE _currentState;
    private bool _inTransitioningState = false;

    public void OnUpdate()
    {
        nextStateKey = _currentState.GetNextState();

        if (!_inTransitioningState && nextStateKey.Equals(_currentState.StateKey))
        {
            _currentState.UpdateState();
        }
        else
        {
            TransitionToState(nextStateKey);
        }
    }
    
    private void TransitionToState(ETurnItems Statekey){
        _inTransitioningState = true;
        _currentState.ExitState();
        _currentState = _states[Statekey];
        _currentState.ResetStateKey();
        _currentState.EnterState();
        _inTransitioningState = false;
    }

    private void Awake()
    {
        StateDataE _data = new StateDataE(_unitCache);

        _states.Add(ETurnItems.CharacterSelection, new CharacterSelectionE(ETurnItems.CharacterSelection, _data));
        _states.Add(ETurnItems.ActionSelection, new ActionSelectionE(ETurnItems.ActionSelection, _data));
        _states.Add(ETurnItems.PathSelection, new PathSelectionE(ETurnItems.PathSelection, _data));
        _states.Add(ETurnItems.TargetSelection, new TargetSelectionE(ETurnItems.TargetSelection, _data));
        _states.Add(ETurnItems.Waiting, new WaitingE(ETurnItems.Waiting, _data));

        _states[ETurnItems.TargetSelection].OnAwake();

        _currentState = _states[ETurnItems.CharacterSelection];
    }
}
