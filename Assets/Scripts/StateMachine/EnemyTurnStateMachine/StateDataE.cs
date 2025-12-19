using UnityEngine;
using UnityEngine.UI;
using Map = ENV.Map;

public class StateDataE
{
    private UnitController _targetUnit;
    public UnitController TargetUnit {get{return _targetUnit;} set{_targetUnit = value;}}
    private UnitList _unitCache;
    public UnitList UnitCache => _unitCache;
    public int UnitArrLength => _unitCache.UnitGOArr.Length;

    public StateDataE(UnitList UC)
    {
        _unitCache = UC;
    }

    public void SelectUnit(int idx){
        _targetUnit = _unitCache.GetUnit(idx);
    }
}