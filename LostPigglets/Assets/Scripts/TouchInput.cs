using UnityEngine;
using System.Collections;
public class TouchInput : MonoBehaviour
{
    public delegate void MovementInput(Vector3 position);
    public static event MovementInput move;
    public delegate void RotateInput(Vector3 rotationTarget);
    public static event MovementInput rotate;

    private float timer;
    private float distance;
    private Plane groundPlane;
    private Ray ray;

    RaycastHit hit;

    public Collider plane;

    void Start()
    {
        plane = GameObject.FindGameObjectWithTag("Plane").GetComponent<Collider>();
        groundPlane = new Plane(Vector3.up, Vector3.zero);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {

            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //Debug.Log("Rotate");
                PigMovement.current.nav.enabled = false;
                Rotating();
                timer += Time.deltaTime;
            }

            if(Input.GetTouch(0).phase == TouchPhase.Ended && timer < 0.2f)
            {
                //Debug.Log("Move");
                PigMovement.current.nav.enabled = true;
                Moving();
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                timer = 0;
            }
        }
            
    }

    void Moving()
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (plane.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Debug.DrawRay(ray.origin, ray.direction * 100f, Color.blue, 3f);
            move(hit.point);
        }
    }

    void Rotating()
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (groundPlane.Raycast(ray, out distance))
        {
            //Debug.DrawRay(ray.origin, ray.direction * 100f, Color.blue, 3f);
            rotate(ray.GetPoint(distance));
            //Debug.Log(ray.GetPoint(distance));
        }
    }
}
