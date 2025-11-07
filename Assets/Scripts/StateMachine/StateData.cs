using UnityEngine;
using UnityEngine.UI;
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

    public GameObject ActionButtonGO;
    public GameObject MoveButtonGO;
    public Button ActionButton;
    public Button MoveButton;

    private Map _grid;
    public Map Grid => _grid;


    public StateData(LayerMask GroundLayer, LayerMask UnitLayer, Map Grid, GameObject AButton, GameObject MButton)
    {
        _groundLayer = GroundLayer;
        _grid = Grid;
        _unitLayer = UnitLayer;
        ActionButtonGO = AButton;
        MoveButtonGO = MButton;
        ActionButton = ActionButtonGO.GetComponent<Button>();
        MoveButton = MoveButtonGO.GetComponent<Button>();
    }
}