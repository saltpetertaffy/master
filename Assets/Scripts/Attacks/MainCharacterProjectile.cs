using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterProjectile : Projectile
{
    protected float startingAngle = 0f;
    protected float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        targetLayer = GameKeys.LAYER_ENEMY_KEY;
    }

    public void SetStartingAngle(float angle) {
        startingAngle = angle >= 0 ? angle : 360 + angle;
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }
}
