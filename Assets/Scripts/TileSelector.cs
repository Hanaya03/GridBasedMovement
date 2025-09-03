using UnityEngine;
using UnityEngine.InputSystem;

public class TileSelector : MonoBehaviour
{
    [SerializeField] private GridPhysics targetUnit;
    [SerializeField] private LayerMask groundLayer;
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
        Debug.Log("input");
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit)){
            Debug.Log("hit, layer: " + hit.transform.gameObject.layer);
            Debug.Log("target layer: " + groundLayer);
            if(hit.transform.gameObject.layer != groundLayer)
                targetUnit.Move(hit.transform.position.x, hit.transform.position.z);
        }
        // targetUnit.Move();
    }
}
