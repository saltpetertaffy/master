using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorAbsorber : MonoBehaviour
{
    [SerializeField] int onHitArmorRestoreAmount = 0;

    public int GetOnHitArmorRestoreAmount() {
        return onHitArmorRestoreAmount;
    }

    public void SetOnHitArmorRestoreAmount(int amountToSet) {
        onHitArmorRestoreAmount = amountToSet;
    }
}
