using UnityEngine;
using UnityEngine.UI;
using Map = ENV.Map;

public class StateDataE
{
    public UnitController TargetUnit;
    public UnitList UnitCache;

    public StateDataE(UnitList UC)
    {
        UnitCache = UC;
    }
}