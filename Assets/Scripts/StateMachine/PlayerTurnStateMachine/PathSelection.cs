using UnityEngine;
using System.Linq;

public class PathSelection : BTurnItems
{
    private int _stepsAvailable;
    public PathSelection(ETurnItems stateKey, StateData Data) : base(stateKey, Data){}

    public override void OnLeftClick()
    {
        if (Physics.Raycast(Data.ray, out Data.hit, Mathf.Infinity, Data.GroundLayer))
        {
            Vector2 tar = (Vector2)Data.hit.transform.position;
            if (Data.TargetUnit.Path.Count > 0)
            {
                if (tar == Data.TargetUnit.Path.Last())
                {
                    Data.TargetUnit.FollowPath();
                    _nextState = ETurnItems.Waiting;
                }
                else
                {
                    Data.TargetUnit.Path.AddRange(PathUtility.Path);
                    _stepsAvailable -= PathUtility.Path.Count;
                    PathUtility.Source = Data.TargetUnit.Path.Last();
                    PathUtility.Path.Clear();
                }
            }
            else
            {
                Data.TargetUnit.Path.AddRange(PathUtility.Path);
                _stepsAvailable -= PathUtility.Path.Count;
                PathUtility.Source = Data.TargetUnit.Path.Last();
                PathUtility.Path.Clear();
            }
        }
    }
    public override void EnterState()
    {
        PathUtility.Source = (Vector2)Data.TargetUnit.transform.position;
        _stepsAvailable = Data.TargetUnit.MoveDistance;
    }
    public override void ExitState()
    {
    }
    public override void UpdateState()
    {
        Data.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(Data.ray, out Data.hit, Mathf.Infinity, Data.GroundLayer))
        {
            Vector2 tar = (Vector2)Data.hit.transform.position;
            if (tar == PathUtility.Source)
                return;

            if (Mathf.Abs(tar.x - PathUtility.Source.x) + Mathf.Abs(tar.y - PathUtility.Source.y) > _stepsAvailable)
            {
                PathUtility.ErasePathHighlights();
                return;
            }


            if (PathUtility.Path.Count > 0)
            {
                if (tar == PathUtility.Path.Last())
                {
                    Debug.Log("Same Path");
                    return;
                }
            }

            PathUtility.ErasePathHighlights();

            PathUtility.CreatePath(tar);
        }
        else
        {
            PathUtility.ErasePathHighlights();

        }
    }
    public override ETurnItems GetNextState(){ return _nextState; }
}
