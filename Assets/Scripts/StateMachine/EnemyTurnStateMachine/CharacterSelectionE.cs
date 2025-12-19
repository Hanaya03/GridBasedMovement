using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionE : BTurnItemsE 
{
    public CharacterSelectionE(ETurnItems stateKey, StateDataE Data) : base(stateKey, Data)
    {
    }

    public override void EnterState()
    {
        _data.SelectUnit(Random.Range(0, _data.UnitArrLength));
    }

    public void TransitionToMove()
    {
        _nextState = ETurnItems.PathSelection;
    }

    public void TransitionToAtk()
    {
    }
    
    public override void ExitState()
    {
    }
    public override void UpdateState()
    {
        Debug.Log("in enemy character selection state");
        TransitionToMove();
    }
    
    public override ETurnItems GetNextState(){ return _nextState; }
}
