using UnityEngine;

public class OddParticlesAttraction : MonoBehaviour
{
    // The particle system to operate on
    public ParticleSystem AffectedParticles;

    // Normalized treshold on the particle lifetime
    // 0: affect particles right after they are born
    // 1: never affect particles
    [Range(0.0f, 1.0f)]
    public float ActivationTreshold = 0.5f;

    // Transform cache
    private Transform m_rTransform = null;
    // Array to store particles info
    private ParticleSystem.Particle[] m_rParticlesArray = null;
    // Is this particle system simulating in world space?
    private bool m_bWorldPosition = true;
    // Multiplier to normalize movement cursor after treshold is crossed
    private float m_fCursorMultiplier = 1.0f;

    public bool creation;
    private bool setup;

    void Awake()
    {
        creation = false;
        setup = false;
        // Let's cache the transform
        m_rTransform = this.transform;
        // Setup particle system info
    }

    // To store how many particles are active on each frame
    private int m_iNumActiveParticles = 0;
    // The attractor target
    private Vector3 m_vParticlesTarget;
    // A cursor for the movement interpolation
    public float m_fCursor = 0.05f;
    void LateUpdate()
    {
        if(setup == false && AffectedParticles.particleCount == 1000)
        {
            AffectedParticles.Stop();
            Setup();
            setup = true;
        }
        // Work only if we have something to work on :)
        if (AffectedParticles != null && setup == true)
        {
            print(AffectedParticles.particleCount);
            //m_fCursor -= ActivationTreshold;
            //m_fCursor *= m_fCursorMultiplier;
            // Let's fetch active particles info
            m_iNumActiveParticles = AffectedParticles.GetParticles(m_rParticlesArray);
            // The attractor's target is it's world space position
            m_vParticlesTarget = m_rTransform.position;
            // If the system is not simulating in world space, let's project the attractor's target in the system's local space
            //if (!m_bWorldPosition)
              //  m_vParticlesTarget -= AffectedParticles.transform.position;

            //print(m_vParticlesTarget.x * 2);
            // For each active particle...
            for (int iParticle = 1; iParticle < m_iNumActiveParticles; iParticle = iParticle + 2)
            { // The movement cursor is the opposite of the normalized particle's lifetime m_fCursor = 1.0f - (m_rParticlesArray[iParticle].lifetime / m_rParticlesArray[iParticle].startLifetime); // Are we over the activation treshold? if (m_fCursor >= ActivationTreshold)
                {
                    // Take over the particle system imposed velocity
                    m_rParticlesArray[iParticle].velocity = Vector3.zero;

                    m_rParticlesArray[iParticle].position = Vector3.MoveTowards(m_rParticlesArray[iParticle].position, m_vParticlesTarget, m_fCursor);
                    // Interpolate the movement towards the target with a nice quadratic easing					
                    //m_rParticlesArray[iParticle].position = 
                    //  new Vector3(Mathf.Lerp(m_rParticlesArray[iParticle].position.x, m_vParticlesTarget.x, m_fCursor * m_fCursor),
                    //Mathf.Lerp(m_rParticlesArray[iParticle].position.y, m_vParticlesTarget.y, m_fCursor * m_fCursor), 
                    //Mathf.Lerp(m_rParticlesArray[iParticle].position.z, m_vParticlesTarget.z, m_fCursor * m_fCursor));
                    //print(Mathf.Lerp(m_rParticlesArray[m_iNumActiveParticles - 1].position.x, m_vParticlesTarget.x * 2, m_fCursor * m_fCursor));
                    /*if (Mathf.Lerp(m_rParticlesArray[iParticle].position.x, m_vParticlesTarget.x * 2, m_fCursor * m_fCursor) > (m_vParticlesTarget.x * 2 - 1))
                    {
                        if (creation == false)
                            creation = true;

                        m_rParticlesArray[iParticle].remainingLifetime = 0;
                    }*/
                    //if (Mathf.Lerp(m_rParticlesArray[m_iNumActiveParticles - 1].position.x, m_vParticlesTarget.x * 2, m_fCursor * m_fCursor) > 5.8f)
                    //  Destroy(AffectedParticles);

                }
            }

            // Let's update the active particles
            AffectedParticles.SetParticles(m_rParticlesArray, m_iNumActiveParticles);
        }
    }

    public void Setup()
    {
        // If we have a system to setup...
        if (AffectedParticles != null)
        {
            // Prepare enough space to store particles info
            m_rParticlesArray = new ParticleSystem.Particle[AffectedParticles.maxParticles];
            // Is the particle system working in world space? Let's store this info
            m_bWorldPosition = AffectedParticles.simulationSpace == ParticleSystemSimulationSpace.World;
            // This the ratio of the total lifetime cursor to the "over treshold" section
            m_fCursorMultiplier = 1.0f / (1.0f - ActivationTreshold);
        }
    }
}