using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Map = ENV.Map;

public class UnitController : MonoBehaviour
{
    private List<Vector2> _path = new List<Vector2>();
    public List<Vector2> Path { get { return _path; } set { _path = value; } }
    public bool DoneMoving = true;
    [SerializeField] private UnitData _data;
    [SerializeField] private float _stepTime = .2f;
    [SerializeField] private ENV.Map _grid;

    private int _currentHealth;

    public Vector2 Position => gameObject.transform.position;

    public AttackData[] Attacks => _data.ATTACKS;

    public int MoveDistance => _data.MOVE;

    private AttackData _currentAttack;
    public AttackData CurrentAttack => _currentAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = _data.HEALTH;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void SelectAttack(int idx)
    {
        _currentAttack = _data.ATTACKS[idx];
    }

    public void TakeDamage(int dmg)
    {
        _currentHealth -= dmg;
        Debug.Log($"{gameObject.name} took {dmg} point(s) of damage. Now has {_currentHealth} health.");
    }

    public void FollowPath()
    {
        DoneMoving = false;
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
        _path.Clear();
        DoneMoving = true;
    }
}
