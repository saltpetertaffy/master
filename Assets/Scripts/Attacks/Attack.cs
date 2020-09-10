using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    protected Collider2D projectileCollider;
    protected GameStatEffect[] projectileEffects;
    protected string targetLayer;

    private void Awake() {
        projectileCollider = GetComponent<Collider2D>();
        projectileEffects = GetComponents<GameStatEffect>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        OnHit(collision);
    }

    protected abstract void OnHit(Collider2D collision);
}
