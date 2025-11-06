using UnityEngine;
using Map = ENV.Map;


public class StateData
{
    public UnitController TargetUnit;
    public Ray ray;
    public RaycastHit hit;

    private LayerMask _groundLayer;
    private LayerMask _unitLayer;
    public LayerMask GroundLayer => _groundLayer;
    public LayerMask UnitLayer => _unitLayer;

    private Map _grid;
    public Map Grid => _grid;


    public StateData(LayerMask GroundLayer, LayerMask UnitLayer, Map Grid)
    {
        _groundLayer = GroundLayer;
        _grid = Grid;
        _unitLayer = UnitLayer;
    }
}