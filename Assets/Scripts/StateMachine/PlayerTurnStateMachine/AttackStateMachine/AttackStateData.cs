using UnityEngine;
using UnityEngine.UI;
using Map = ENV.Map;

public class AttackStateData
{
    public (int, int)[] Identities = { (0, 1), (1, 0), (0, -1), (-1, 0) };
    public UnitController TargetUnit;
    public Ray ray;
    public RaycastHit hit;

    private LayerMask _unitLayer;
    public LayerMask UnitLayer => _unitLayer;

    private AttackData _currentAttack;
    public AttackData CurrentAttack { get { return _currentAttack; } set { _currentAttack = value; } }

    private Map _grid;
    public Map Grid => _grid;


    public AttackStateData(LayerMask UnitLayer, Map Grid)
    {
        _grid = Grid;
        _unitLayer = UnitLayer;
    }
}