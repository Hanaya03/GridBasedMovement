using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Scriptable Objects/Unit Data")]
public class UnitData : ScriptableObject
{
    [SerializeField] private int _maxMoveSpeed;
    public int MOVE => _maxMoveSpeed;
    [SerializeField] private int _maxHealth;

}
