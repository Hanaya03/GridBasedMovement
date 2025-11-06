using UnityEngine;
using System.Linq;

public class PathSelection : BTurnItems<ETurnItems>
{
    private Ray ray;
    private RaycastHit hit;
    public PathSelection(ETurnItems stateKey, StateData Data) : base(stateKey, Data){}

    public override void OnLeftClick()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Data.GroundLayer))
        {
            Vector2 tar = (Vector2)hit.transform.position;
            if (Data.TargetUnit.Path.Count > 0)
            {
                if (tar == Data.TargetUnit.Path.Last())
                {
                    Data.TargetUnit.FollowPath();
                }
                else
                {
                    Data.TargetUnit.Path.AddRange(PathUtility.Path);
                    PathUtility.Source = Data.TargetUnit.Path.Last();
                    PathUtility.Path.Clear();
                }
            }
            else
            {
                Data.TargetUnit.Path.AddRange(PathUtility.Path);
                PathUtility.Source = Data.TargetUnit.Path.Last();
                PathUtility.Path.Clear();
            }
        }
    }
    public override void EnterState(){}
    public override void ExitState(){}
    public override void UpdateState()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Data.GroundLayer))
        {
            Vector2 tar = (Vector2)hit.transform.position;
            if (tar == PathUtility.Source)
                return;

            if (tar.x + tar.y > Data.TargetUnit.MoveDistance)
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
    public override ETurnItems GetNextState(){ return StateKey; }
}
