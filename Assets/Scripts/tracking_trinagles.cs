using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracking_trinagles : MonoBehaviour
{

    public GameObject target;

    public float speed = 0.5f;


    // Update is called once per frame
    void Update()
    {
        if ((target.transform.position.y > 5f) && (transform.position.y - target.transform.position.y < 5f)){
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }

    }
}
