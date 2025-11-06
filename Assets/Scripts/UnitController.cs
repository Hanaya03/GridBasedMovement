using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Map = ENV.Map;

public class UnitController : MonoBehaviour
{
    private List<Vector2> _path = new List<Vector2>();
    public List<Vector2> Path{get{ return _path; } set{ _path = value; }}
    [SerializeField] private UnitData _data;
    [SerializeField] private float _stepTime = .2f;
    [SerializeField] private ENV.Map _grid;

    public int MoveDistance => _data.MOVE;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void FollowPath()
    {
        StartCoroutine(TakeSteps(_path));
    }
    
    IEnumerator TakeSteps(List<Vector2> steps)
    {
        _grid.SMap[(int)transform.position.x, (int)transform.position.y].DeHighlightUnit();
        for (int i = 0; i < steps.Count; i++)
        {
            yield return new WaitForSeconds(_stepTime);
            Debug.Log("taking step");
            transform.position = (Vector3)steps[i] + Vector3.forward;
            _grid.SMap[(int)transform.position.x, (int)transform.position.y].DehighlightPathTile();
        }
        PathUtility.ClearPath();
    }
}
