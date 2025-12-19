using UnityEngine;
using UnityEngine.UI;

public class PathSelectionE : BTurnItemsE 
{
    public PathSelectionE(ETurnItems stateKey, StateDataE Data) : base(stateKey, Data)
    {
    }
    public override void EnterState()
    {
    }

    public void TransitionToMove()
    {
    }

    public void TransitionToAtk()
    {
    }
    
    public override void ExitState()
    {
    }
    public override void UpdateState() {
        Debug.Log("in enemy path selection state");
    }
    
    public override ETurnItems GetNextState(){ return _nextState; }
}
