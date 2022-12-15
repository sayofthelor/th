using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObject : MonoBehaviour {
    [HideInInspector] public static float timeScale = 1f;
    [HideInInspector] public static float hudSize = 8;
    private float modifier;
    private Camera _camera;

    void Start() {
        _camera = GetComponent<Camera>();
        _camera.orthographicSize = hudSize;
    }

    void Update() {
        Time.timeScale = Mathf.Lerp(Time.timeScale, timeScale, BoundTo(1 - (Time.deltaTime * 9f), 0, 1));
        _camera.orthographicSize = Mathf.Lerp(hudSize, _camera.orthographicSize, BoundTo(1 - (Time.deltaTime * 9f), 0, 1));
    }
    
    private static float BoundTo(float value, float min, float max) {
        return Mathf.Max(min, Mathf.Min(max, value));
    }
}
