using UnityEngine;

public class Waiting : BTurnItems
{
    public Waiting(ETurnItems stateKey, StateData Data) : base(stateKey, Data)
    {
    }
    public override void OnLeftClick(){}
    public override void EnterState(){}
    public override void ExitState(){}
    public override void UpdateState(){}
    public override ETurnItems GetNextState(){ return StateKey; }
}
