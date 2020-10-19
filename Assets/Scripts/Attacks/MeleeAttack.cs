using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeAttack : OneOffAttack
{
    protected override void OnHit(Collider2D collision) {
        if (attackCollider.IsTouchingLayers(LayerMask.GetMask(targetLayer))) {
            Hitbox hitbox = collision.gameObject.GetComponent<Hitbox>();
            if (hitbox) {
                hitbox.HandleHit(attackEffects);
            }
        }
    }
}
