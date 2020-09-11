using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextEmitter : MonoBehaviour {
    [SerializeField] TextEmission textEmissionPrefab;
    [SerializeField] [Tooltip("Point relative to the Emitter where text emissions will appear")] Vector2 emissionPoint;
    [SerializeField] [Range(0, 2)] float emissionPointXRandomness = 0f;
    [SerializeField] [Range(0, 2)] float emissionPointYRandomness = 0f;
    [SerializeField] Vector2 velocity;
    [SerializeField] float emissionDuration = 1.5f;

    TextMeshProUGUI text;

    private void Start() {
        text = textEmissionPrefab.GetComponent<TextMeshProUGUI>();
    }

    public void EmitText(string text, Transform emissionTransform) {
        this.text.text = text;
        CreateTextEmission(emissionTransform);
    }

    public void EmitText(string text, Transform emissionTransform, Color color) {
        this.text.color = color;
        this.text.text = text;
        CreateTextEmission(emissionTransform);
    }

    private void CreateTextEmission(Transform emissionTransform) {
        float emissionX = emissionTransform.position.x + emissionPoint.x + Random.Range(-emissionPointXRandomness, emissionPointXRandomness);
        float emissionY = emissionTransform.position.y + emissionPoint.y + Random.Range(-emissionPointYRandomness, emissionPointYRandomness);
        TextEmission newEmission = Instantiate(textEmissionPrefab, new Vector2(emissionX, emissionY), Quaternion.identity, this.transform);
        newEmission.GetComponent<Rigidbody2D>().velocity = velocity;
        newEmission.DestroyAfterTime(emissionDuration);
    }
}
