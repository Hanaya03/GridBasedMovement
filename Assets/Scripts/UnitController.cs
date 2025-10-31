using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitController : MonoBehaviour
{
    [SerializeField]private float _stepTime = .2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // _position = new Coords(0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void SetDestination(Coords destination)
    {
        // while (_projected.X != _target.X | _projected.Y != _target.Y)
        // {

        // }
    }

    public void Move(Vector3 targetPos)
    {
        targetPos.z = 1;
        transform.position = targetPos;
    }

    public void FollowPath(List<Vector2> steps)
    {
        StartCoroutine(TakeSteps(steps));
    }
    
    IEnumerator TakeSteps(List<Vector2> steps)
    {
        for(int i = 0; i < steps.Count; i++)
        {
            yield return new WaitForSeconds(_stepTime);
            transform.position = (Vector3)steps[i] + Vector3.forward;
        }
    }
}
