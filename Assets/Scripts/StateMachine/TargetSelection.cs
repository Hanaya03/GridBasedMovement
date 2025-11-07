using UnityEngine;

public class TargetSelection : BTurnItems
{
    public TargetSelection(ETurnItems stateKey, StateData Data) : base(stateKey, Data)
    {
    }
    public override void OnLeftClick(){}
    public override void EnterState()
    {
        Debug.Log("Now in target selection state!");
    }
    public override void ExitState()
    {
        Debug.Log("target selected!");
    }
    public override void UpdateState()
    {
        Debug.Log("Selecting target...");
    }
    public override ETurnItems GetNextState(){ return _nextState; }
}
