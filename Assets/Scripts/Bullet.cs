using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for handling the bullet behavior.
 */

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    public void Fire(Vector2 direction)
    {
        // Update the rb according to the new direction.
        direction = direction.normalized;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;

        // Rotate the transform towards the direction.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO: Create splash first.
        Destroy(gameObject);
    }

}
