using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitterProjectile : MainCharacterProjectile
{    
    Rigidbody2D splitterRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        splitterRigidbody = GetComponent<Rigidbody2D>();
        SetProjectileForce();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DoReverseTurn();
    }

    private void SetProjectileForce() {
        Vector2 direction = Quaternion.AngleAxis(startingAngle, Vector3.forward) * Vector3.right;
        direction.Normalize();
        splitterRigidbody.velocity = direction * speed;
    }

    private void DoReverseTurn() {
        if (Mathf.Abs(Mathf.Atan2(splitterRigidbody.velocity.y, splitterRigidbody.velocity.x) * Mathf.Rad2Deg - startingAngle) < 180) {
            
        }
    }
}
