using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO - Make arc variable, set in SplitterShooter
public class SplitterProjectile : MainCharacterProjectile
{    
    Rigidbody2D splitterRigidbody;

    float rotationSpeed = 360f;
    float angularRotation = 0f;
    public bool isReversed = false;
    
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
        float angle = Mathf.Atan2(splitterRigidbody.velocity.y, splitterRigidbody.velocity.x) * Mathf.Rad2Deg;
        angle = angle >= 0 ? angle : 360 + angle;

        if (isReversed ? angularRotation > -180 : angularRotation < 180) {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            rotationAmount = isReversed ? -rotationAmount : rotationAmount;
            transform.Rotate(0, 0, rotationAmount);
            Vector2 newDirection = Quaternion.AngleAxis(angle + rotationAmount, Vector3.forward) * Vector3.right;
            newDirection.Normalize();
            splitterRigidbody.velocity = newDirection * speed;
            angularRotation += rotationAmount;
        }
    }

    public void IsReversed(bool isReversed) {
        this.isReversed = isReversed;
    }
}
