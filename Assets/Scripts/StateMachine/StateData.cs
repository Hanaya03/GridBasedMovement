using UnityEngine;

public class StateData
{
    public UnitController TargetUnit;

    private LayerMask _groundLayer;
    public LayerMask GroundLayer => _groundLayer;
    private Map _grid;
    public Map Grid => _grid;
    public StateData(LayerMask GroundLayer, Map Grid)
    {
        _groundLayer = GroundLayer;
        _grid = Grid;
    }
}