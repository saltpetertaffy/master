using UnityEngine;
using GameConstants;

public abstract class Projectile : MonoBehaviour
{
    private Collider2D projectileCollider;
    protected GameStatEffect[] projectileEffects;
    
    private void Awake() {
        projectileCollider = GetComponent<Collider2D>();
        projectileEffects = GetComponents<GameStatEffect>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (projectileCollider.IsTouchingLayers(LayerMask.GetMask(GameKeys.LAYER_HITBOX_KEY))) {
            Hitbox hitbox = collision.gameObject.GetComponent<Hitbox>();
            if (hitbox) {
                hitbox.HandleHit(projectileEffects);
            }
            Destroy(gameObject);
        }
    }
}
