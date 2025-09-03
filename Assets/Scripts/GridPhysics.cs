using UnityEngine;

public class GridPhysics : MonoBehaviour
{
    [SerializeField] private Transform unitTransform;
    private Vector3 targetPositionVector;


    public void Start(){
        targetPositionVector = Vector3.zero;
    }

    public void Move(float x, float y){
        targetPositionVector.x = x;
        targetPositionVector.z = y;
        unitTransform.position = targetPositionVector;
    }
}
