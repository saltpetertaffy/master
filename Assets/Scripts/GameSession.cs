using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] StatBar lifeBar;
    [SerializeField] StatBar armorBar;
    Health mainCharacterHealth;
    
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
        mainCharacterHealth = FindObjectOfType<MainCharacter>().GetComponentInChildren<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessPlayerDeath() {
        FindObjectOfType<CinemachineStateDrivenCamera>().enabled = false;
    }
}
