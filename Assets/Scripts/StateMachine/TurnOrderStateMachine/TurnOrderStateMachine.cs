using UnityEngine;

public enum EOrderItems
{
    PlayerTurn,
    EnemyTurn
}
public class TurnOrderStateMachine : MonoBehaviour
{
    [SerializeField] PlayerTurnStateMachine _playerController;
    [SerializeField] EnemyTurnStateMachine _enemyController;
    private EOrderItems _currentTurn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentTurn = EOrderItems.PlayerTurn;
    }

    // Update is called once per frame
    void Update()
    {

        if(_currentTurn == EOrderItems.PlayerTurn)
        {
            if(_playerController.NextStateKey == ETurnItems.Waiting)
            {
                _currentTurn = EOrderItems.EnemyTurn;
                return;
            }
            _playerController.OnUpdate();
        }
        else
        {
            if(_enemyController.NextStateKey == ETurnItems.Waiting)
            {
                _currentTurn = EOrderItems.PlayerTurn;
                return;
            }
            _enemyController.OnUpdate();
        }
    }
}
