using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Bullet bullet;

    [SerializeField] int currentAmmo = 3;
    [SerializeField] int maxAmmo = 5;
    [SerializeField] float reloadTime = 5;
    float reloadElapsed = 0;
    void Update()
    {
        Reload();
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            currentAmmo--;
        }
    }
    private void Reload()
    {
        if (currentAmmo < maxAmmo)
        {
            reloadElapsed += Time.deltaTime;
        }
        if (reloadElapsed >= reloadTime)
        {
            currentAmmo++;
            reloadElapsed = 0;
        }
    }
}
