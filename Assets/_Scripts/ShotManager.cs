using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
    public GameObject projectile;
    public float projectileForce = 5f;
    public Transform startShotPoint;
   
    
    // Update is called once per frame
    void Update()
    {
        Vector2 projectilePos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimerDirection = mousePos - projectilePos;
        transform.right = aimerDirection;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void Shoot()
    {
        GameObject newProjectile = Instantiate(projectile, startShotPoint.position, startShotPoint.rotation);
        newProjectile.GetComponent<Rigidbody2D>().velocity = transform.right * projectileForce;
    }
}
