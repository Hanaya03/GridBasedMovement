using UnityEngine;

public class CharacterSelection : BTurnItems
{
    private UnitController _unit;
    private GameObject _currentObject;
    public CharacterSelection(ETurnItems stateKey, StateData Data) : base(stateKey, Data){}
    public override void OnLeftClick()
    {
        if (Physics.Raycast(Data.ray, out Data.hit, Mathf.Infinity, Data.UnitLayer))
        {
            _unit = _currentObject.GetComponent<UnitController>();
            Data.TargetUnit = _unit;
            _nextState = ETurnItems.ActionSelection;
        }
    }
    public override void EnterState()
    {
    }
    public override void ExitState(){}
    public override void UpdateState()
    {
        Debug.Log("In Character selection state");
        Data.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(Data.ray, out Data.hit, Mathf.Infinity, Data.UnitLayer))
        {
            GameObject tmp = Data.hit.transform.gameObject;
            if(tmp != _currentObject && _currentObject != null)
            {
                Data.Grid.SMap[(int)_currentObject.transform.position.x, (int)_currentObject.transform.position.y].DeHighlightUnit();
            }
            _currentObject = tmp;
            Vector2 tar = (Vector2)Data.hit.transform.position;
            Data.Grid.SMap[(int)tar.x, (int)tar.y].HighlightUnit();
        }
    }
    public override ETurnItems GetNextState(){ return _nextState; }
}
