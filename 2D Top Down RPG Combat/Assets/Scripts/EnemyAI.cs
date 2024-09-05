using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Vector2 roamPos;
    private enum State
    {
        Roam
    }

    private State state;
    EnemyPathfinding pathFinding;

    private void Awake()
    {
        pathFinding = GetComponent<EnemyPathfinding>();
        state = State.Roam; 
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    private void FixedUpdate()
    {
        
    }

    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roam)
        {
            Vector2 roamPos = GetNewRoamPosition();
            
            pathFinding.GetMoveDirection(ref roamPos);

            yield return new WaitForSeconds(2);
        }
    }

    private Vector2 GetNewRoamPosition()
    {
        return new Vector2(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f)).normalized;
    }
}
