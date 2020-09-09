using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStat : MonoBehaviour {
    private int baseStatId;

    public int GetBaseStatId() {
        return baseStatId;
    }

    public void SetBaseStatId(int baseStatId) {
        this.baseStatId = baseStatId;
    }
}
