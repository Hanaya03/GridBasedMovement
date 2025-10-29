using UnityEngine;
using UnityEngine.InputSystem;

public class TileSelector : MonoBehaviour
{
    [SerializeField] private UnitController targetUnit;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Map _grid;
    private PathUtility _pathTool;
    private Ray ray;
    private RaycastHit hit;
    private InputSystem_Actions controls;
    private InputAction _enter;

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Awake()
    {
        _pathTool = new PathUtility();
        _pathTool.Source = targetUnit.transform.position;
        _pathTool._map = _grid.map;
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
        _pathTool.Source = targetUnit.transform.position;
        Debug.Log("input");
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit, layer: " + hit.transform.gameObject.layer);
            Debug.Log("target layer: " + groundLayer);
            if (hit.transform.gameObject.layer != groundLayer)
            {
                // targetUnit.Move(hit.transform.position);
                _pathTool.AddToPath((Vector2)hit.transform.position);
            }
            // targetUnit.SetDestination(new Coords((int)hit.transform.position.x, (int)hit.transform.position.z));
        }
        // targetUnit.Move();
    }
    
    public void SubmitPath()
    {
        targetUnit.FollowPath(_pathTool.Path);
        _pathTool.ClearPath();
    }
}
