using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSpeed: MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<ParticleSystem>().isPlaying)
            this.gameObject.GetComponent<ParticleSystem>().startSpeed += 0.1f;
        
    }
}
