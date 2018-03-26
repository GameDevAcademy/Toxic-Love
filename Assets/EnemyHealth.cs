using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public FloatReference maxHp;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHp.CurrentValue;
    }
    
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0f)
            Die();
    }

    private void Die()
    {
        Destroy(transform.parent.gameObject);
    }




}
