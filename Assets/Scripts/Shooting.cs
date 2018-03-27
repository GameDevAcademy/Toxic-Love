using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for handling the player's shooting.
 */

public class Shooting : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float fireRate;

    private float currentFire;
    private bool reloading;

    private Vector2 currentMouseDirection;

    private void Update()
    {
        // Points the gun towards the mouse.
        PointGun();

        // Shoot if the player clicks.
        if (Input.GetMouseButton(0))
            HandleFire();

        // Update the current fire time of the weapon.
        currentFire += Time.deltaTime;
    }

    private void PointGun()
    {
        // Get the direction the mouse is now pointing at.
        UpdateMouseDirection();

        // Transform the direction into an angle and update it.
        float angle = Mathf.Atan2(currentMouseDirection.y, currentMouseDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    private void HandleFire()
    {
        // Check if the player is allowed to fire.
        if (currentFire > fireRate && reloading == false)
            Fire();
        
    }

    private void Fire()
    {
        // Reset the currentFire time.
        currentFire = 0f;

        // Spawn the bullet and shoot towards the mouse.
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Fire(currentMouseDirection);
    }

    private void UpdateMouseDirection()
    {
        // Update the mouse direction based on the mouse and current point.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentMouseDirection = mousePosition - transform.position;
    }
}
