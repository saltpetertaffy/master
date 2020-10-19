using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextEmission : MonoBehaviour
{
    public void DestroyAfterTime(float duration) {
        StartCoroutine(DelayDestroy(duration));
    }

    private IEnumerator DelayDestroy(float duration) {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
