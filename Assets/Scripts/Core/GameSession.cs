using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] StatBar lifeBar;
    [SerializeField] StatBar armorBar;
    MainCharacter mainCharacter;
    
    private void Awake() {
        if (FindObjectsOfType<GameSession>().Length > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = FindObjectOfType<MainCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessPlayerDeath() {
        if (mainCharacter) {
            FindObjectOfType<CinemachineStateDrivenCamera>().enabled = false;
        }
    }
}
