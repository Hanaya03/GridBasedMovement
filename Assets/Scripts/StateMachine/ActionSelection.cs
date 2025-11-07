using UnityEngine;
using UnityEngine.UI;

public class ActionSelection : BTurnItems 
{
    public ActionSelection(ETurnItems stateKey, StateData Data) : base(stateKey, Data)
    {
        // _data = Data;
    }
    public override void OnLeftClick(){}
    public override void EnterState()
    {
        Data.ActionButtonGO.SetActive(true);
        Data.MoveButtonGO.SetActive(true);

        Data.ActionButton.onClick.AddListener(TransitionToAtk);
        Data.MoveButton.onClick.AddListener(TransitionToMove);
    }

    public void TransitionToMove()
    {
        _nextState = ETurnItems.PathSelection;
    }

    public void TransitionToAtk()
    {
        _nextState = ETurnItems.TargetSelection;
    }
    
    public override void ExitState()
    {
        Data.ActionButtonGO.SetActive(false);
        Data.MoveButtonGO.SetActive(false);
    }
    public override void UpdateState() { }
    
    public override ETurnItems GetNextState(){ return _nextState; }
}
