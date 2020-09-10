using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected GameObject attack;
    [SerializeField] protected GameObject attackPoint;

    public GameObject GetAttack() {
        return attack;
    }

    public void SetAttack(GameObject attack) {
        this.attack = attack;
    }

    public abstract void Attack();
}
