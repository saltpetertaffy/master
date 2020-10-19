using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    Collider2D shredderCollider;

    private void Start() {
        shredderCollider = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision) {
        Destroy(collision.gameObject);
    }
}
