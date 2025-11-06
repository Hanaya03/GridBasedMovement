using UnityEngine;

public class Waiting : BTurnItems
{
    public Waiting(ETurnItems stateKey, StateData Data) : base(stateKey, Data)
    {
    }
    public override void OnLeftClick(){}
    public override void EnterState()
    {
        Debug.Log("Now in waiting state");
    }
    public override void ExitState(){}
    public override void UpdateState()
    {
        Debug.Log("Waiting...");
    }
    public override ETurnItems GetNextState(){ return StateKey; }
}
