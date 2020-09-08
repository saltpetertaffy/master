using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeathBehavior : DeathBehavior
{
    [SerializeField] ParticleSystem deathParticles;

    public override void OnDeath() {
        Instantiate(deathParticles, gameObject.transform.position, Quaternion.identity);
        isCompleted = true;
    }
}
