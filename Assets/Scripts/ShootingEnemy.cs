using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    [SerializeField] Vector2 projectileVelocity;
    [SerializeField] bool aiming = false;

    Rigidbody2D attackRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        attackRigidbody = attack.GetComponent<Rigidbody2D>();
        if (!attackRigidbody) {
            Debug.LogError("No rigidbody found on attack, did you forget to give the enemy an attack?");
        }
    }

    public override void Attack() {
        MainCharacter mainCharacter = FindObjectOfType<MainCharacter>();
        if (!mainCharacter) { return; }

        Vector2 attackVelocity;

        if (aiming) {
            Vector2 mainCharacterPosition = FindObjectOfType<MainCharacter>().transform.position;
            Vector2 aimedDirection = mainCharacterPosition + (Vector2) attackPoint.transform.position;
            aimedDirection.Normalize();
            attackVelocity = -aimedDirection * projectileVelocity.magnitude;
        } else {
            attackVelocity = projectileVelocity;
        }

        GameObject newShot = Instantiate(attack, attackPoint.transform.position, Quaternion.identity);
        newShot.GetComponent<Rigidbody2D>().velocity = attackVelocity;
    }
}
