using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDeathBehavior : DeathBehavior
{
    [SerializeField] string deathAnimationName;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public override void OnDeath() {
        animator.SetTrigger(GameKeys.ANIMATION_DEAD_TRIGGER);
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

        float deathAnimationDuration = 0;
        foreach (AnimationClip clip in clips) {
            if (clip.name == deathAnimationName) {
                deathAnimationDuration = clip.length;
                break;
            }
        }

        if (deathAnimationDuration == 0) {
            Debug.LogWarning("Death animation with zero duration, \"" + deathAnimationName + "\" detected. Did you correctly spell the animation name?");
        }

        StartCoroutine(DelaySetIsCompleted(deathAnimationDuration));
    }

    private IEnumerator DelaySetIsCompleted(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        isCompleted = true;
    }
}
