using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE_circles : MonoBehaviour
{
    public int hp = 2;

    public GameObject OriginalSurrounderObject;
    public int Surrounder_object_count;

    private readonly float Appearduration = 0.3f;
    private Transform Surrounder_parent_transform;

    // Start is called before the first frame update
    void Start()
    {
        Surrounder_parent_transform = new GameObject( gameObject.name + "Surrounder Parent transform").transform;
        StartCoroutine("SPAWN_GO");
    }

    // Update is called once per frame
    void Update()
    {
        if (hp == 0){
            Destroy(this.gameObject);
        }
    }

    IEnumerator SPAWN_GO (){
        float angle_step = 360.0f/Surrounder_object_count;

        // OriginalSurrounderObject.transform.SetParent(Surrounder_parent_transform);

        for (int i = 0; i < Surrounder_object_count; i++){
            GameObject newobject = Instantiate(OriginalSurrounderObject);
            newobject.transform.RotateAround(transform.position, Vector2.down, angle_step * i);
            newobject.transform.SetParent(Surrounder_parent_transform);
            yield return new WaitForSeconds(Appearduration);
        }
    }
}
