using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeathBehavior : DeathBehavior
{
    [SerializeField] ParticleSystem deathParticles;

    public override void OnDeath() {
        Instantiate(deathParticles, transform.localPosition, Quaternion.identity);
        StartCoroutine(DelayDestroy(deathParticles.main.duration));;
    }

    private IEnumerator DelayDestroy(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Destroy(deathParticles);
        isCompleted = true;
    }
}
