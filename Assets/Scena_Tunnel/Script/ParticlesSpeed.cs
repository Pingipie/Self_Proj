using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSpeed: MonoBehaviour
{
    bool ok;

    void Awake()
    {
        ok = false;
        this.gameObject.GetComponent<ParticleSystem>().emissionRate = 248f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<ParticleSystem>().isPlaying && ok == false)
        {
            ok = true;
            StartCoroutine(speed(this.gameObject.GetComponent<ParticleSystem>()));
        }
        
    }

    IEnumerator speed(ParticleSystem ps)
    {
        yield return new WaitForSeconds(5);
        while (ps.startSpeed < 140f)
        {
            ps.startSpeed += 1f;
            if(ps.startLifetime > 2f)
            {
                ps.startLifetime -= .08f;
            }
            yield return new WaitForSeconds(.07f);
        }

        ps.emissionRate = 0;

    }
}
