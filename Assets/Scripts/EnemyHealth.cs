using UnityEngine;

/*
 * Responsible for managing a enemy unit health.
 */

public class EnemyHealth : MonoBehaviour
{
    public FloatReference maxHp;

    private float currentHealth;

    private void OnEnable()
    {
        // Reset the current Hp on Spawn.
        currentHealth = maxHp.CurrentValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            TakeDamage(damageDealer.AttackDamage);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0f)
            Die();
    }

    private void Die()
    {
        //TODO: Let them lay on the ground.
        Destroy(transform.parent.gameObject);
    }
}
