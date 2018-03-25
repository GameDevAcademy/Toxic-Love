using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for player shooting.
 */

public class Shooting : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float fireRate;

    private float currentFire;
    private bool reloading;

    private void Update()
    {
        PointGun();

        if (Input.GetMouseButton(0))
            HandleFire();

        currentFire += Time.deltaTime;
    }

    private void PointGun()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    private void HandleFire()
    {
        if (currentFire > fireRate && reloading == false)
            Fire();
        
    }

    private void Fire()
    {
        currentFire = 0f;
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        bullet.Fire(mousePosition - transform.position);
    }
}
