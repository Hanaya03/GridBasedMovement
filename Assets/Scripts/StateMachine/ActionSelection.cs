using UnityEngine;

public class ActionSelection : BTurnItems
{
    public ActionSelection(ETurnItems stateKey, StateData Data) : base(stateKey, Data)
    {
        // _data = Data;
    }
    public override void OnLeftClick(){}
    public override void EnterState(){}
    public override void ExitState(){}
    public override void UpdateState(){}
    public override ETurnItems GetNextState(){ return StateKey; }
}
