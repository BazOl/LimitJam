using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject loseScreen;
    [SerializeField] BaseScript baseScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (baseScript.hitBase)
        {
            loseScreen.SetActive(true);
        }
    }
}
