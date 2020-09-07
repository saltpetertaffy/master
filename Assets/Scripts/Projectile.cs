using UnityEngine;
using GameConstants;

public class Projectile : MonoBehaviour 
{
    [Header("Game Stats")]
    [SerializeField] int healthDamageFlat = 1;
    [SerializeField] [Range(0, 1)] float healthDamagePercentMax = 0f;
    [SerializeField] [Range(0, 1)] float healthDamagePercentRemaining = 0f;
    [SerializeField] int armorDamageFlat = 0;
    [SerializeField] [Range(0, 1)] float armorDamagePercentMax = 0f;
    [SerializeField] [Range(0, 1)] float armorDamagePercentRemaining = 0f;

    Collider2D projectileCollider;
    Health mainCharacterHealth;

    private void Start() {
        projectileCollider = GetComponent<Collider2D>();
        mainCharacterHealth = FindObjectOfType<MainCharacter>().GetComponent<Health>();
    }

    private void Update() {
        int totalDamage = Mathf.RoundToInt(healthDamageFlat
            + healthDamagePercentMax * mainCharacterHealth.GetMaximumHealth()
            + healthDamagePercentRemaining * mainCharacterHealth.GetHealth());
        float damageRedShade = totalDamage / (float) mainCharacterHealth.GetHealth();
        GetComponent<SpriteRenderer>().color = new Color(damageRedShade, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (projectileCollider.IsTouchingLayers(LayerMask.GetMask(GameKeys.LAYER_HITBOX_KEY))) {
            Debug.Log("Player hit");
        }
    }
}
