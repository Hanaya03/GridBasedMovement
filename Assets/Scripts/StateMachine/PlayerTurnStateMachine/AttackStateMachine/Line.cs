using UnityEngine;
using System;

public class Line : BAttackItems
{
    private GameObject _currentObject;
    public Line(EAttackType key, AttackStateData data) : base(key, data){}
    
    public override void OnLeftClick()
    {
    }
    public override void EnterState()
    {
        Debug.Log("Entering Line state");
        (int, int) tmp;
        for(int i = 0; i < Data.Identities.Length; i++)
        {
            tmp = Data.Identities[i];
            Debug.Log($"Trying to iterate through identities, current identity {i} with tmp {tmp}");
            Debug.Log($"Current attack range: {Data.CurrentAttack.RANGE}");

            for (int x = 1; x <= Data.CurrentAttack.RANGE; x++)
            {
                Debug.Log($"Trying to draw tile");
                try
                {
                    Data.Grid.SMap[tmp.Item1 * x + (int)Data.TargetUnit.Position.x, tmp.Item2 * x + (int)Data.TargetUnit.Position.y].HighlightPathTile();
                }
                catch(IndexOutOfRangeException e)
                {
                    Debug.Log("invalid position");
                }
            }
        }
        
    }
    public override void ExitState()
    {
        Debug.Log("Exiting the sub-state Line.");
    }
    public override void UpdateState()
    {
        Debug.Log("Updating the sub-state Line.");
        Data.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(Data.ray, out Data.hit, Mathf.Infinity, Data.UnitLayer))
        {
            GameObject tmp = Data.hit.transform.gameObject;
            if(tmp != _currentObject && _currentObject != null)
            {
                Data.Grid.SMap[(int)_currentObject.transform.position.x, (int)_currentObject.transform.position.y].DeTargetTile();
            }
            _currentObject = tmp;
            Vector2 tar = (Vector2)Data.hit.transform.position;
            Data.Grid.SMap[(int)tar.x, (int)tar.y].TargetTile();
        }
    }
    public override EAttackType GetNextState(){ return _nextState; }
}
