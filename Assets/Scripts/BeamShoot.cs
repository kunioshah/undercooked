using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class BeamShoot : MonoBehaviour
{
    public GameObject aim;
    public GameObject beam;
    public Rigidbody2D rb;
    public Rigidbody2D rbBeam;

    public Transform shootPosition;
    Vector2 direction;
    float angle;

    private Animation animAim;

    void Start()
    {
        animAim["BeamAimPhase"].wrapMode = WrapMode.Once;
        animAim["BeamShoot"].wrapMode = WrapMode.Once;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            aim.SetActive(true);
            rb.position = shootPosition.position;
            //animAim.Play("BeamAimPhase");
        }
        if (Input.GetKey(KeyCode.B))
        {
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 angleDirection = direction - rb.position;
            angle = Mathf.Atan2(angleDirection.y, angleDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            rb.position = shootPosition.position;
        }
        if (Input.GetKeyUp(KeyCode.B)) //&& !animAim.IsPlaying("BeamAimPhase") 
        {
            aim.SetActive(false);
            beam.SetActive(true);
            rbBeam.position = rb.position;
            rbBeam.rotation = rb.rotation;
        }
    }
}
