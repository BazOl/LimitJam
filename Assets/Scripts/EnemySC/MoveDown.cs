using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] float speed = 5;

    void Update()
    {
        transform.position -= transform.up * speed * Time.deltaTime;
    }



    

    

}
