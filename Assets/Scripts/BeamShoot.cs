using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class BeamShoot : MonoBehaviour
{
    public GameObject aimPrefab;
    public Transform shootPosition;
    private Animation animAim;
    private Animation animShoot;

    public Rigidbody2D rb;
    Vector2 direction;
    float angle;

    public GameObject beam;

    // Start is called before the first frame update
    void Start()
    {
        animAim["BeamAimPhase"].wrapMode = WrapMode.Once;
        animAim["BeamShoot"].wrapMode = WrapMode.Once;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameObject newBeamAim = Instantiate(aimPrefab, shootPosition.position, shootPosition.rotation);
            rb.position = shootPosition.position;
            animAim.Play("BeamAimPhase");
        }
        if (Input.GetKey(KeyCode.B))
        {
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 angleDirection = direction - rb.position;
            angle = Mathf.Atan2(angleDirection.y, angleDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            rb.position = shootPosition.position;
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            Destroy(aimPrefab);
            GameObject newBeam = Instantiate(beam, rb.position, shootPosition.rotation);
            //animShoot.Play("BeamShoot");
        }
    }
}
