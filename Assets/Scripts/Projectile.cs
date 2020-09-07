using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;

public class Projectile : MonoBehaviour 
{
    [Header("Game Stats")]
    [SerializeField] int damage;

    Collider2D projectileCollider;

    private void Start() {
        projectileCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (projectileCollider.IsTouchingLayers(LayerMask.GetMask(GameKeys.LAYER_HITBOX_KEY))) {
            Debug.Log("Player hit");
        }
    }
}
