using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OneOffAttack : Attack
{
    private void OnTriggerEnter2D(Collider2D collision) {
        OnHit(collision);
    }
}
