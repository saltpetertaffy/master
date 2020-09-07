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
        float damageRedShade = damage / (float) mainCharacterHealth.GetHealth();
        GetComponent<SpriteRenderer>().color = new Color(damageRedShade, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (projectileCollider.IsTouchingLayers(LayerMask.GetMask(GameKeys.LAYER_HITBOX_KEY))) {
            Debug.Log("Player hit");
        }
    }
}
