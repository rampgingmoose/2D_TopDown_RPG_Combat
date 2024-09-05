using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5f;
    private Rigidbody2D rb;
    private Vector2 moveVec;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        rb.MovePosition(rb.position + moveVec * (Time.fixedDeltaTime * speed));
    }

    public void GetMoveDirection(ref Vector2 moveDir)
    {
        moveVec = moveDir;
    }
}
