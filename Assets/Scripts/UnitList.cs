using UnityEngine;
using System.Collections.Generic;

public class UnitList : MonoBehaviour
{
    [SerializeField] private GameObject[] _unitGOArr;
    public GameObject[] UnitGOArr => _unitGOArr;
    private Dictionary<string, UnitController> _units = new Dictionary<string, UnitController>();

    void Start()
    {
        foreach(GameObject g in _unitGOArr)
            _units.Add(g.name, g.GetComponent<UnitController>());
    }

    public UnitController GetUnit(int i){
        return _units[_unitGOArr[i].name];
    }
}
