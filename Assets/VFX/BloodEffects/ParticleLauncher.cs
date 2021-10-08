using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{

    public ParticleSystem particleLauncher;
    public ParticleSystem splatterParticles;
    public Gradient particleColorGradient;
    public ParticleDecalPool splatDecalPool;

    //private bool isBleeding = false;

    List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, collisionEvents);

        for (int i = 0; i < collisionEvents.Count; i++)
        {
            splatDecalPool.ParticleHit(collisionEvents[i], particleColorGradient);
            //EmitAtLocation(collisionEvents[i]);
        }

    }

    void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
    {
        splatterParticles.transform.position = particleCollisionEvent.intersection;
        splatterParticles.transform.rotation = Quaternion.LookRotation(particleCollisionEvent.normal);
        ParticleSystem.MainModule psMain = splatterParticles.main;
        psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));

        splatterParticles.Emit(1);
    }

    void Update()
    {
        //if (Input.GetButton("Fire1"))
        //{
        //    ParticleSystem.MainModule psMain = particleLauncher.main;
        //    psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));
        //    particleLauncher.Emit(1);
        //}

    }

    public void LaunchGore()
    {
        ParticleSystem.MainModule psMain = particleLauncher.main;
        psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));
        particleLauncher.Emit(75);
        StartCoroutine(SprayBlood());
    }

    IEnumerator SprayBlood()
    {
        //isBleeding = true;
        particleLauncher.Emit(75);
        yield return new WaitForSeconds(0.1f);
        particleLauncher.Emit(50);
        yield return new WaitForSeconds(0.1f);
        particleLauncher.Emit(50);
        //isBleeding = false;
    }
}