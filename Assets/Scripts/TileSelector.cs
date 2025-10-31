using UnityEngine;
using UnityEngine.InputSystem;

public class TileSelector : MonoBehaviour
{
    [SerializeField] private UnitController targetUnit;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Map _grid;
    private bool _pathLocked = false;
    private PathUtility _pathTool;
    private Ray ray;
    private RaycastHit hit;
    private InputSystem_Actions controls;
    private InputAction _enter;

    // Update is called once per frame
    void Update()
    {
        if (_pathLocked)
            return;

        if (_pathTool.Source != (Vector2)targetUnit.transform.position)
            _pathTool.Source = (Vector2)targetUnit.transform.position;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit, layer: " + hit.transform.gameObject.layer);
            Debug.Log("target layer: " + groundLayer);


            if (_pathTool.Path.Count > 0)
            {
                if ((Vector2)hit.transform.position == _pathTool.Path[_pathTool.Path.Count - 1])
                {
                    Debug.Log("type shift");
                    return;
                }
            }

            _pathTool.ErasePathHighlights();

            if (hit.transform.gameObject.layer != groundLayer)
            {
                _pathTool.AddToPath((Vector2)hit.transform.position);
            }
        }
    }
    
    private void Awake()
    {
        _pathTool = new PathUtility();
        _pathTool.Source = targetUnit.transform.position;
        _pathTool._map = _grid.map;
        _pathTool._smap = _grid.SMap;
        controls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _enter = controls.UI.Click;
        _enter.Enable();
        _enter.canceled += ctx => HandleIn();
    }

    private void OnDisable()
    {
        _enter.Disable();
    }

    private void HandleIn()
    {
        _pathLocked = true;
    }
    
    public void SubmitPath()
    {
        targetUnit.FollowPath(_pathTool.Path);
        _pathTool.ErasePathHighlights();
        _pathLocked = false;
    }
}
