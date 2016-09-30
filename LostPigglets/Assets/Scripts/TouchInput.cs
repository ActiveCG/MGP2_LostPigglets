using UnityEngine;
using System.Collections;
public class TouchInput : MonoBehaviour
{

    [HideInInspector]
    public Collider plane;
    private float timer;
    private float distance;
    private Plane groundPlane;
    private Ray ray;
    RaycastHit hit;

    public float tapTimeForMoving = 0.2f;


    void Start()
    {
        plane = GameObject.FindGameObjectWithTag("Plane").GetComponent<Collider>();
        groundPlane = new Plane(Vector3.up, Vector3.zero);
    }

    void Update()
    {
        GetInput();
    }

    void Moving()
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

        //Physics.Raycast(ray, out collided, Mathf.Infinity);
        //Debug.Log(collided.collider);

        //if (!(collided.collider.gameObject.tag == "Terain"))
        //{
            if (plane.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameManager.instance.move(hit.point);
            }
        //}
    }

    void Rotating()
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (groundPlane.Raycast(ray, out distance))
        {
            GameManager.instance.rotate(ray.GetPoint(distance));
        }
    }

    void GetInput()
    {
        if (Input.touchCount > 0)
        {
            //Debug.Log(Input.GetTouch(0).tapCount);

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                PigMovement.current.nav.enabled = false;
                Rotating();
                timer += Time.deltaTime;
                //Debug.Log(timer);
                if(timer < 0.2f)
                {
                    //Debug.Log("Reseting the NavMesh");
                    PigMovement.current.nav.enabled = true;
                }
                
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended && timer < tapTimeForMoving)
            {
                PigMovement.current.nav.enabled = true;
                Moving();
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                PigMovement.current.nav.enabled = true;
                timer = 0;
            }
        }

    }
}
