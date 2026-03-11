using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [field: SerializeField] public EnemyState CurrentState { get; private set; } = EnemyState.Patrol;

    [SerializeField] private float _alertDuration = 1.5f;


    private EnemySearch _enemySearch;
    private float _alertTimer = 0f;

    void Awake()
    {
        _enemySearch = GetComponent<EnemySearch>();
    }

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
            case EnemyState.Search:
                HandleSearch();
                break;
            default:
                break;
        }
    }


    public void ChangeState(EnemyState newState, Vector2 lastKnownPosition = default)
    {
        if (CurrentState == newState) return;
        CurrentState = newState;
        _alertTimer = 0f;

        if (newState == EnemyState.Search)
        {
            _enemySearch.StartSearch(lastKnownPosition);
        }

        Debug.Log($"Enemy state changed to {newState}");
    }


    private void HandlePatrol()
    {
        // Patrol logic here
    }

    private void HandleAlert()
    {
        _alertTimer += Time.deltaTime;
        if (_alertTimer >= _alertDuration)
        {
            ChangeState(EnemyState.Chase);
        }

    }

    private void HandleChase()
    {
        // Chase logic here
    }
    private void HandleSearch()
    {
        _enemySearch.UpdateSearch();
    }
}
