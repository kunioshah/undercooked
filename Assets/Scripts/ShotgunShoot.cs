using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShotgunShoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform shotgunPos0;
    public Transform shotgunPos1;
    public Transform shotgunPos2;
    public Transform shotgunPos3;
    public Transform shotgunPos4;
    public float shootForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shotgun();
        }
    }

    void Shotgun()
    {
        GameObject newBullet0 = Instantiate(bulletPrefab, shotgunPos0.position, shotgunPos0.rotation);
        GameObject newBullet1 = Instantiate(bulletPrefab, shotgunPos1.position, shotgunPos1.rotation);
        GameObject newBullet2 = Instantiate(bulletPrefab, shotgunPos2.position, shotgunPos2.rotation);
        GameObject newBullet3 = Instantiate(bulletPrefab, shotgunPos3.position, shotgunPos3.rotation);
        GameObject newBullet4 = Instantiate(bulletPrefab, shotgunPos4.position, shotgunPos4.rotation);

        newBullet0.GetComponent<Rigidbody2D>().AddForce(shotgunPos0.up * shootForce, ForceMode2D.Impulse);
        newBullet1.GetComponent<Rigidbody2D>().AddForce(shotgunPos1.up * shootForce, ForceMode2D.Impulse);
        newBullet2.GetComponent<Rigidbody2D>().AddForce(shotgunPos2.up * shootForce, ForceMode2D.Impulse);
        newBullet3.GetComponent<Rigidbody2D>().AddForce(shotgunPos3.up * shootForce, ForceMode2D.Impulse);
        newBullet4.GetComponent<Rigidbody2D>().AddForce(shotgunPos4.up * shootForce, ForceMode2D.Impulse);
    }

}