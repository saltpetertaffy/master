using UnityEngine;
using GameConstants;

public class Projectile : MonoBehaviour 
{
    GameStatEffect[] projectileEffects;

    Collider2D projectileCollider;
    Health mainCharacterHealth;
    Armor mainCharacterArmor;

    private void Start() {
        projectileCollider = GetComponent<Collider2D>();
        mainCharacterHealth = FindObjectOfType<MainCharacter>().GetComponentInChildren<Health>();
        mainCharacterArmor = FindObjectOfType<MainCharacter>().GetComponentInChildren<Armor>();
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
                case (int) GameStatEffects.DAMAGE:
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue());
                    break;
                case (int) GameStatEffects.DAMAGE_PERCENT_MAX:
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue() * mainCharacterHealth.GetMaximumHealth());
                    break;
                case (int) GameStatEffects.DAMAGE_PERCENT_REMAINING:
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue() * mainCharacterHealth.GetHealth());
                    break;
            }
        }
        totalDamage = (int) (totalDamage * (1 - mainCharacterArmor.GetArmor() / 100));

        float damageRedShade = totalDamage / (float) mainCharacterHealth.GetHealth();
        Color damageColor = new Color(1, 1 - damageRedShade, 1 - damageRedShade);
        return damageColor;
    }
}
