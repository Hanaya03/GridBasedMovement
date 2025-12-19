using UnityEngine;
using System.Collections.Generic;

public class UnitList : MonoBehaviour
{
    [SerializeField] private GameObject[] _unitGOArr;
    private Dictionary<string, UnitController> _units = new Dictionary<string, UnitController>();

    void Start()
    {
        foreach(GameObject g in _unitGOArr)
            _units.Add(g.name, g.GetComponent<UnitController>());
    }

}
