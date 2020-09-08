using UnityEngine;
using GameConstants;

public class Projectile : MonoBehaviour 
{
    GameStatEffect[] projectileEffects;

    Collider2D projectileCollider;
    Health mainCharacterHealth;

    private void Start() {
        projectileCollider = GetComponent<Collider2D>();
        mainCharacterHealth = FindObjectOfType<MainCharacter>().GetComponentInChildren<Health>();
        projectileEffects = GetComponents<GameStatEffect>();
    }

    private void Update() {
        GetComponent<SpriteRenderer>().color = generateDamageColor();
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

    private Color generateDamageColor() {
        int totalDamage = 0;

        foreach (GameStatEffect projectileEffect in projectileEffects) {
            switch (projectileEffect.GetGameStatEffectId()) {
                case GameConfigConstants.EFFECT_ID_DAMAGE:
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue());
                    break;
                case GameConfigConstants.EFFECT_ID_DAMAGE_PERCENT_MAX:
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue() * mainCharacterHealth.GetMaximumHealth());
                    break;
                case GameConfigConstants.EFFECT_ID_DAMAGE_PERCENT_REMAINING:
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue() * mainCharacterHealth.GetHealth());
                    break;
            }
        }
        float damageRedShade = totalDamage / (float) mainCharacterHealth.GetHealth();
        Color damageColor = new Color(1, 1 - damageRedShade, 1 - damageRedShade);
        return damageColor;
    }
}
