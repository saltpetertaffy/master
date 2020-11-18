using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Upgrade : MonoBehaviour {
    public string Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Duration { get; set; }
    public List<GameStatEffect> Effects { get; set; }
}
