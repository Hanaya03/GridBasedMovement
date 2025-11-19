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
    public override void ExitState()
    {
        Debug.Log("Done waiting!");
        Data.TargetUnit = null;
    }
    public override void UpdateState()
    {
        Debug.Log("Waiting...");
        if (Data.TargetUnit.DoneMoving)
            _nextState = ETurnItems.CharacterSelection;
    }
    public override ETurnItems GetNextState(){ return _nextState; }
}
