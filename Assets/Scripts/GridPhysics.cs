using UnityEngine;
public class GridPhysics : MonoBehaviour
{
    [SerializeField] private Transform unitTransform;
    
    private Coords coords; 
    private Vector2 targetPositionVector;


    public void Start()
    {

        coords = new Coords(0,0);
        targetPositionVector = Vector3.zero;
    }

    public void Move(Vector2 targetPos)
    {
        // targetPositionVector.x += x;
        // targetPositionVector.z += y;
        unitTransform.position = targetPos;
    }
}
