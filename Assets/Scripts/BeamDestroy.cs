using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamDestroy : MonoBehaviour
{
    public Animation anim;
    public GameObject beam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beam.activeSelf && !anim.IsPlaying("BeamShoot"))
        {
            beam.SetActive(false);
        }
    }
}
