using UnityEngine;
using GameConstants;

public abstract class Projectile : Attack
{
    protected override void OnHit(Collider2D collision) {
        if (projectileCollider.IsTouchingLayers(LayerMask.GetMask(targetLayer))) {
            Hitbox hitbox = collision.gameObject.GetComponent<Hitbox>();
            if (hitbox) {
                hitbox.HandleHit(projectileEffects);
            }
            Destroy(gameObject);
        }
    }
}