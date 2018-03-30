using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for handling the player's shooting.
 */

public class Shooting : MouseMono
{
    public Bullet bulletPrefab;
    public float fireRate;

    private float currentFire;
    private bool reloading;

    protected override void Update()
    {
        base.Update();

        // Shoot if the player clicks.
        if (Input.GetMouseButton(0))
            HandleFire();

        // Update the current fire time of the weapon.
        currentFire += Time.deltaTime;
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
        bullet.Fire(mouseDirection);
    }
}
