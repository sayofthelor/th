using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private GameObject _camera;
    public int hp = 5;
    [HideInInspector] public Rigidbody2D rb;

    void Start() {
        _camera = GameObject.Find("Main Camera");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        _camera.transform.position = new Vector3(transform.position.x, transform.position.y, _camera.transform.position.z);
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
