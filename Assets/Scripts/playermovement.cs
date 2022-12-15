using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    
    public float speed;

    public int hp = 5;

    private Rigidbody2D rb;

    void Start(){

        rb = this.GetComponent<Rigidbody2D>();

    }

    void Update(){

        Vector2 direction = new Vector2(0f, 1f);

        float verticalinput = Input.GetAxis("Vertical");

        rb.AddForce(direction*speed*Time.deltaTime*verticalinput, ForceMode2D.Impulse);
        
    }

    void OnTriggerEnter(Collider other){

        if (other.CompareTag("Killpoint")){
            Destroy(this.gameObject);
        }

        if (other.CompareTag("triangle_tracer") || other.CompareTag("projectile") || other.CompareTag("hands")){
            hp -= 1; 
        }

        if (other.CompareTag("AOE Spawner")){
            //other.GetComponent<Script>();
            //AOE_circles AOEC = new AOE_circles();
            //AOEC.hp -= 1;
        } 
    }
}
