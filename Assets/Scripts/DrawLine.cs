using UnityEngine;
using static MainObject;

public class DrawLine : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Rigidbody2D _playerRb;
    public Color color;
    public void Start()
    {
        Invoke("GetPlayerRb", 0.1f);
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
        _lineRenderer.startWidth = 0.2f;
        _lineRenderer.endWidth = 0.2f;
        _lineRenderer.enabled = false;
    }

   private void GetPlayerRb()
   {
       _playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
   }

    private Vector2 _initialPosition;
    private Vector2 _currentPosition;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MainObject.timeScale = 0.5f;
            MainObject.hudSize = 10;
            _initialPosition = transform.position;
            _lineRenderer.SetPosition(0, _initialPosition);
            _lineRenderer.positionCount = 1;
            _lineRenderer.enabled = true;
        } 
        else if (Input.GetMouseButton(0))
        {
            _initialPosition = transform.position;
            _lineRenderer.SetPosition(0, _initialPosition);
            _currentPosition = GetCurrentMousePosition().GetValueOrDefault();
            _lineRenderer.positionCount = 2;
            MainObject.hudSize = 10 + (Vector2.Distance(_initialPosition, _currentPosition) / 2.5f < 3 ? Vector2.Distance(_initialPosition, _currentPosition) / 2.5f : 3);
            _lineRenderer.SetPosition(1, _currentPosition);

        } 
        else if (Input.GetMouseButtonUp(0))
        {
            MainObject.timeScale = 1f;
            MainObject.hudSize = 8;
            _lineRenderer.enabled = false;
            var releasePosition = GetCurrentMousePosition().GetValueOrDefault();
            var direction = releasePosition - _initialPosition;
           // add force to rb in direction of mouse release
           if (Vector2.Distance(_initialPosition, direction) > 0.75f) {
                _playerRb.velocity = Vector2.zero;
                _playerRb.AddForce(direction, ForceMode2D.Impulse);
           }
        }
    }

    private Vector2? GetCurrentMousePosition()
    {
        var ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        var plane = new Plane(Vector3.forward, Vector2.zero);

        float rayDistance;
        if (plane.Raycast(ray, out rayDistance))
        {
            return ray.GetPoint(rayDistance);
             
        }

        return null;
    }
     
}