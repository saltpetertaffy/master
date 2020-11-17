using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {
    private string name { get; set; }
    private string description { get; set; }
    private float duration { get; set; }
    private List<GameStatEffect> effects { get; set; }
}
