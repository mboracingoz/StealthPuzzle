using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [field: SerializeField] public EnemyState CurrentState { get; private set; } = EnemyState.Patrol;

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case EnemyState.Patrol:
                HandlePatrol();
                break;
            case EnemyState.Alert:
                HandleAlert();
                break;
            case EnemyState.Chase:
                HandleChase();
                break;
            default:
                break;
        }
    }

    public void ChangeState(EnemyState newState)
    {
        if (CurrentState == newState) return;
        CurrentState = newState;
        Debug.Log($"Enemy state changed to {newState}");
    }


    private void HandlePatrol()
    {
        // Patrol logic here
    }

    private void HandleAlert()
    {
        // Alert logic here
    }

    private void HandleChase()
    {
        // Chase logic here
    }
}
