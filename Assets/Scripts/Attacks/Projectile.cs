using UnityEngine;
using GameConstants;

public abstract class Projectile : OneOffAttack
{
    [SerializeField] bool collidesWithGround = false;

    protected override void OnHit(Collider2D collision) {
        if (collidesWithGround && attackCollider.IsTouchingLayers(LayerMask.GetMask(GameKeys.LAYER_GROUND_KEY))) {
            Destroy(gameObject);
            return;
        }

        if (attackCollider.IsTouchingLayers(LayerMask.GetMask(targetLayer))) {
            Hitbox hitbox = collision.gameObject.GetComponent<Hitbox>();
            if (hitbox) {
                hitbox.HandleHit(this);
            }
            Destroy(gameObject);
        }
    }
}