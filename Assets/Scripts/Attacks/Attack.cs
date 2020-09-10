using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    protected Collider2D attackCollider;
    protected GameStatEffect[] attackEffects;
    protected string targetLayer;

    private void Awake() {
        attackCollider = GetComponent<Collider2D>();
        attackEffects = GetComponents<GameStatEffect>();
    }

    protected abstract void OnHit(Collider2D collision);
}
