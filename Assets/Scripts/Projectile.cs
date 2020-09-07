using UnityEngine;
using GameConstants;

public class Projectile : MonoBehaviour 
{
    [Header("Game Stats")]
    [SerializeField] int damage = 1;

    Collider2D projectileCollider;
    Health mainCharacterHealth;

    private void Start() {
        projectileCollider = GetComponent<Collider2D>();
        mainCharacterHealth = FindObjectOfType<MainCharacter>().GetComponent<Health>();
    }

    private void Update() {
        float damageRedShade = (float) damage / (float) mainCharacterHealth.GetHealth();
        Debug.Log(damageRedShade);
        GetComponent<SpriteRenderer>().color = new Color(damage / mainCharacterHealth.GetHealth(), 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (projectileCollider.IsTouchingLayers(LayerMask.GetMask(GameKeys.LAYER_HITBOX_KEY))) {
            Debug.Log("Player hit");
        }
    }
}
