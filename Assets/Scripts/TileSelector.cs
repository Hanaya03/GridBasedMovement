using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Linq;
using System.Collections.Generic;
using Map = ENV.Map;

public enum ETurn
{
    PlayerTurn,
    EnemyTurn
}

public enum ETurnItems
{
    CharacterSelection,
    ActionSelection,
    PathSelection,
    TargetSelection,
    Waiting
}

public class TileSelector : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _unitLayer;
    [SerializeField] private Map _grid;
    private Dictionary<ETurnItems, BTurnItems> _states = new Dictionary<ETurnItems, BTurnItems>();
    private BTurnItems _currentState;
    private bool _inTransitioningState = false;
    private InputSystem_Actions controls;
    private InputAction _enter;

    void Update()
    {
        ETurnItems nextStateKey = _currentState.GetNextState();

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
        _currentState.EnterState();
        _inTransitioningState = false;
    }

    private void Awake()
    {
        StateData _data = new StateData(_groundLayer, _unitLayer, _grid);

        _states.Add(ETurnItems.CharacterSelection, new CharacterSelection(ETurnItems.CharacterSelection, _data));
        _states.Add(ETurnItems.ActionSelection, new ActionSelection(ETurnItems.ActionSelection, _data));
        _states.Add(ETurnItems.PathSelection, new PathSelection(ETurnItems.PathSelection, _data));
        _states.Add(ETurnItems.Waiting, new Waiting(ETurnItems.Waiting, _data));

        _currentState = _states[ETurnItems.CharacterSelection];
        
        PathUtility.Map = _grid.map;
        PathUtility.SMap = _grid.SMap;
        controls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _enter = controls.UI.Click;
        _enter.Enable();
        _enter.canceled += ctx => _currentState.OnLeftClick();
    }

    private void OnDisable()
    {
        _enter.Disable();
    }
}
