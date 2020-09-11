using UnityEngine;
using GameConstants;

public abstract class Projectile : OneOffAttack
{
    protected override void OnHit(Collider2D collision) {
        if (attackCollider.IsTouchingLayers(LayerMask.GetMask(targetLayer))) {
            Hitbox hitbox = collision.gameObject.GetComponent<Hitbox>();
            if (hitbox) {
                hitbox.HandleHit(attackEffects);
            }
            Destroy(gameObject);
        }
    }
}