using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI upText;
    [SerializeField] TextMeshProUGUI downText;

    int upAmount = 3;
    int downAmount = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyCorrectEnemy();
        upText.text = "x"+upAmount;
        downText.text = "x"+downAmount;
    }

    void DestroyCorrectEnemy()
    {
        int up = GameObject.FindGameObjectsWithTag("UpE").Length;
        int down = GameObject.FindGameObjectsWithTag("DownE").Length;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (up > 0 || upAmount > 0)
            {
                Destroy(GameObject.FindWithTag("UpE"));
                upAmount++;
            }
            else 
            {
                Debug.Log("No enemies on screen");
                upAmount--;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (down > 0 || downAmount > 0)
            {
                Destroy(GameObject.FindWithTag("DownE"));
                downAmount++;
            }
            else 
            {
                Debug.Log("No enemies on screen");
                downAmount--;
            }
        }
    }
}
