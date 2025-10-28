using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField] private GridPhysics phys;
    [SerializeField] private Map map;
    private int[] steps;
    private Coords _target;
    private Coords _projected;
    private Coords _position = new Coords(0, 0);
    public Coords Position => _position;
    public Coords Target { set { _target = value; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // _position = new Coords(0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void SetPath()
    {
        
    }

    public void SetDestination(Coords destination)
    {
        _target = destination;

        _projected = _position;
        // while (_projected.X != _target.X | _projected.Y != _target.Y)
        // {

        // }
    }
    
    public void Move(Vector2 targetPos)
    {
        transform.position = targetPos;
    }
}
