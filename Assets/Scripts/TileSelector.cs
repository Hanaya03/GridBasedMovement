using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Linq;
using System.Collections.Generic;

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
    Waiting
}

public class TileSelector : MonoBehaviour
{
    private Dictionary<ETurnItems, BTurnItems<ETurnItems>> _states = new Dictionary<ETurnItems, BTurnItems<ETurnItems>>();
    private ETurnItems _currentState;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Map _grid;
    private bool _pathLocked = false;
    // private PathUtility _pathTool;
    
    private InputSystem_Actions controls;
    private InputAction _enter;

    void Update()
    {
        _states[_currentState].UpdateState();
    }

    private void Awake()
    {
        StateData _data = new StateData(groundLayer, _grid);

        _states.Add(ETurnItems.CharacterSelection, new CharacterSelection(ETurnItems.CharacterSelection, _data));
        _states.Add(ETurnItems.ActionSelection, new ActionSelection(ETurnItems.ActionSelection, _data));
        _states.Add(ETurnItems.PathSelection, new PathSelection(ETurnItems.CharacterSelection, _data));
        _states.Add(ETurnItems.Waiting, new Waiting(ETurnItems.Waiting, _data));

        _currentState = ETurnItems.CharacterSelection;
        
        PathUtility.Map = _grid.map;
        PathUtility.SMap = _grid.SMap;
        controls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _enter = controls.UI.Click;
        _enter.Enable();
        _enter.canceled += ctx => _states[_currentState].OnLeftClick();
    }

    private void OnDisable()
    {
        _enter.Disable();
    }
}
