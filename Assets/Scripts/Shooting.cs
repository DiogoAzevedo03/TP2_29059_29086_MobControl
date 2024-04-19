using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shooting : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float fireCd;
    private float fireTimer;

    [SerializeField] float chargeAmount;
    private float currentCharge = 0;

    void Start()
    {
        fireTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (fireTimer <= 0)
            {
                if (currentCharge < chargeAmount) { currentCharge++; }
                Shoot();
                fireTimer = fireCd;
            }
        }
        if (Input.GetMouseButtonUp(0) && (currentCharge >= chargeAmount))
        {
            currentCharge = 0;
        }
    }
  
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        //bullet.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,15),ForceMode.Impulse);
    }
 
}
