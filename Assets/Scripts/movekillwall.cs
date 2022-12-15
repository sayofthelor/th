using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movekillwall : MonoBehaviour
{

    private float bosspoint = 110f;
    public float speed;
    public GameObject go;

    void Update(){

        float ypos = transform.position.y;

        if (ypos <= bosspoint && go.transform.position.y >= 5){
            transform.Translate(Vector2.up*speed*Time.deltaTime);
        }
    }

    
}