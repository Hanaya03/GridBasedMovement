using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Scriptable Objects/Unit Data")]
public class UnitData : ScriptableObject
{
    [SerializeField] private int _maxMoveSpeed;
    public int MOVE => _maxMoveSpeed;
    [SerializeField] private int _maxHealth;
    public int HEALTH => _maxHealth;

    [SerializeField] private AttackData[] _attackList;
    public AttackData[] ATTACKS => _attackList;

}
