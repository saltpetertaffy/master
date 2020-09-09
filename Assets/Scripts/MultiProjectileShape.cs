using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiProjectileShape : MonoBehaviour
{
    [Header("Game Stats")]
    [SerializeField] Vector2 projectileShapeVelocity;

    Rigidbody2D projectileShapeRigidbody;

    private void Start() {
        projectileShapeRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        int projectileCount = GetComponentsInChildren<Projectile>().Length;
        if (projectileCount == 0) {
            Destroy(gameObject);
        }
    }

    private void LaunchProjectileShape() {
        projectileShapeRigidbody.velocity = projectileShapeVelocity;
    }
}
