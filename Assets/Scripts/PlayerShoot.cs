using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bulletPrefab;
    public Transform shootPosition;
    public float shootForce;

    private float rubberbandChargeTime = 0f;
    private const float maxRubberbandChargeTime = 2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Shoot();
       }

        //rubber band - adrian
        if (Input.GetKey(KeyCode.T))
        {
            rubberbandChargeTime += Time.deltaTime;
            //Debug.Log(rubberbandChargeTime);
            rubberbandChargeTime = Mathf.Clamp(rubberbandChargeTime, 0, maxRubberbandChargeTime);
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            ShootRubberband();
            rubberbandChargeTime = 0f;
        }
    }

    void Shoot() {
        GameObject newBullet = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddForce(shootPosition.up * shootForce, ForceMode2D.Impulse);
    }

    void ShootRubberband()
    {
        GameObject newBullet = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddForce(shootPosition.up * shootForce * rubberbandChargeTime, ForceMode2D.Impulse);
        //Debug.Log(shootPosition.up * shootForce * rubberbandChargeTime);
        //Debug.Log(rubberbandChargeTime);
    }
}
