using UnityEngine;
public enum EAttackType
{
    Line,
    Area
}
[CreateAssetMenu(fileName = "AttackData", menuName = "Scriptable Objects/Attack Data")]
public class AttackData : ScriptableObject
{
    [SerializeField] private string _name;
    public string NAME => _name;
    [SerializeField] private int _range;
    public int RANGE => _range;
    [SerializeField] private int _damage;
    public int DAMAGE => _damage;
    [SerializeField] private EAttackType _type;
    public EAttackType TYPE => _type;
}
