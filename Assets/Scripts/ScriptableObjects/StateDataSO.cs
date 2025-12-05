using UnityEngine;
using UnityEngine.UI;
using Map = ENV.Map;

[CreateAssetMenu(fileName = "StateDataSO", menuName = "Scriptable Objects/StateDataSO")]
public class StateDataSO : ScriptableObject
{
    public UnitController TargetUnit;
    public Ray ray;
    public RaycastHit hit;

    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _unitLayer;
    public LayerMask GroundLayer => _groundLayer;
    public LayerMask UnitLayer => _unitLayer;

    public GameObject ActionButtonGO;
    public GameObject MoveButtonGO;
    public Button ActionButton;
    public Button MoveButton;

    [SerializeField] private Map _grid;
    public Map Grid => _grid;
}
