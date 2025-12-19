using UnityEngine;
using UnityEngine.UI;

public class ActionSelectionE : BTurnItemsE 
{
    public ActionSelectionE(ETurnItems stateKey, StateDataE Data) : base(stateKey, Data)
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
    public override void UpdateState() { }
    
    public override ETurnItems GetNextState(){ return _nextState; }
}
