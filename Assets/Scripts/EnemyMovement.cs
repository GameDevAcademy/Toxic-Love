using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for moving the enemy to the player.
 */

public class EnemyMovement : Movement
{
    public FloatReference distanceThreshold;
    private Transform target;

    protected override void Start()
    {
        base.Start();
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    protected override void ReadInput()
    {
        // Get the input based on the target location.
        float horizontalInput = 0f;

        Vector3 targetDirection = (target.position - transform.position);
        float distance = targetDirection.x;
        if(Mathf.Abs(distance) > distanceThreshold)
        {
            horizontalInput = (distance < 0f) ? (-1f) : (1f);
        }
        else
        {
            Attack();
        }

        HandleSpriteDirectionWithInput(horizontalInput);

        HandleMovement(horizontalInput);
    }

    public FloatReference playerHp;
    public FloatReference attackDamage;

    private float lastAttack = 0f;
    private float attackSpeed = 3f;

    private void Attack()
    {
        if (Time.time - lastAttack > attackSpeed)
        {
            playerHp.CurrentValue = playerHp - attackDamage;
            lastAttack = Time.time;
        }
    }
}
