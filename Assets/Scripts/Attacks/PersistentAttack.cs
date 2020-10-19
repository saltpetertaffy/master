using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PersistentAttack : Attack
{
    private void OnTriggerStay2D(Collider2D collision) {
        OnHit(collision);
    }
}
