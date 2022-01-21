using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI upText;
    [SerializeField] TextMeshProUGUI downText;
    [SerializeField] TextMeshProUGUI leftText;
    [SerializeField] TextMeshProUGUI rightText;

    [SerializeField] GameObject nomorearrows;
    [SerializeField] TextMeshProUGUI noarrowAmountText;



    [SerializeField] TextMeshProUGUI scoreText;


    public AudioClip shotSound;
    public AudioSource audio;


    int upAmount = 3;
    int downAmount = 3;
    int leftAmount = 3;
    int rightAmount = 3;

    public int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        DestroyCorrectEnemy();
        upText.text = "x"+upAmount;
        downText.text = "x"+downAmount;
        leftText.text = "x"+leftAmount;
        rightText.text = "x"+rightAmount;
    }

    void DestroyCorrectEnemy()
    {
        int up = GameObject.FindGameObjectsWithTag("UpE").Length;
        int down = GameObject.FindGameObjectsWithTag("DownE").Length;
        int right = GameObject.FindGameObjectsWithTag("RightE").Length;
        int left = GameObject.FindGameObjectsWithTag("LeftE").Length;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (up > 0 && upAmount > 0)
            {
                Destroy(GameObject.FindWithTag("UpE"));
                upAmount++;
                UpdatePoints();
            }
            else if (upAmount == 0)
            {
                noarrowAmountText.text = "You have no more UP arrows";
                StartCoroutine(NoMore());
                //Debug.Log("Uh oh");
            }
            else 
            {
                Debug.Log("No enemies on screen");
                upAmount--;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (down > 0 && downAmount > 0)
            {
                Destroy(GameObject.FindWithTag("DownE"));
                downAmount++;
                UpdatePoints();
            }
            else if (downAmount == 0)
            {
                noarrowAmountText.text = "You have no more DOWN arrows";
                StartCoroutine(NoMore());
                // Debug.Log("Uh oh");
            }
            else 
            {
                Debug.Log("No enemies on screen");
                downAmount--;
            }
        }   
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (right > 0 && rightAmount > 0)
            {
                Destroy(GameObject.FindWithTag("RightE"));
                rightAmount++;
                UpdatePoints();
            }
            else if (rightAmount == 0)
            {
                noarrowAmountText.text = "You have no more RIGHT arrows";
                StartCoroutine(NoMore());
                Debug.Log("Uh oh");
            }
            else 
            {
                Debug.Log("No enemies on screen");
                rightAmount--;
            }
        }        
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (left > 0 && leftAmount > 0)
            {
                Destroy(GameObject.FindWithTag("LeftE"));
                leftAmount++;
                UpdatePoints();
            }
            else if(leftAmount == 0) 
            {
                Debug.Log("Uh oh");
                noarrowAmountText.text = "You have no more LEFT arrows";
                StartCoroutine(NoMore());
            }
            else 
            {
                Debug.Log("No enemies on screen");
                leftAmount--;
            }
        }
        
    }

    IEnumerator NoMore() 
    {
        nomorearrows.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        nomorearrows.gameObject.SetActive(false);
    }

    void UpdatePoints() 
    {
        audio.clip = shotSound;
        audio.Play();
        score++;
        scoreText.text = "Score: " + score;
    }
}
