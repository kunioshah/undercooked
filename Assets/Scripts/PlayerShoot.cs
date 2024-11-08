using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bulletPrefab;
    public Transform shootPosition;
    public float shootForce;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Shoot();
       }
    }

    void Shoot() {
        GameObject newBullet = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddForce(shootPosition.up * shootForce, ForceMode2D.Impulse);
    }
}
