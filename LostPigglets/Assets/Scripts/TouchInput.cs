using UnityEngine;
using System.Collections;
public class TouchInput : MonoBehaviour
{
    public static TouchInput instance;

    [HideInInspector]
    public Collider plane;
    private Transform player;
    private float timer;
    private float distance;
    private int touches;
    private Plane groundPlane;
    private Ray ray;
    private RaycastHit hit;

    [HideInInspector]
    public RaycastHit hitInfo;
    public float tapTimeForMoving = 0.2f;


    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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

    //void ContinuouslyMoving()
    //{
    //    ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
    //    Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity);
    //    PigMovement.current.nav.SetDestination(hit.point);
    //}


    void GetInput()
    {
        touches = Input.touchCount;

        // Limit the touches to only register 1 finger
        if (touches > 1)
        {
            touches = 1;
        }

        for(int i=0; i<touches; i++)
        {
            //Debug.Log(Input.GetTouch(0).tapCount);
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Physics.Raycast(ray.origin, ray.direction, out hitInfo, Mathf.Infinity);
            //Debug.Log(hitInfo.collider);
            Debug.Log(Vector3.Distance(player.position, hitInfo.point));

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (Vector3.Distance(player.position, hitInfo.point) < PlayerStats.instance.radiusForRotation)
                {
                    PigMovement.current.nav.enabled = false;
                    Rotating();
                    timer += Time.deltaTime;
                    //Debug.Log(timer);
                    if (timer < 0.2f)
                    {
                        //Debug.Log("Reseting the NavMesh");
                        PigMovement.current.nav.enabled = true;
                    }
                }
                else
                {
                    PigMovement.current.nav.enabled = true;
                    PigMovement.current.nav.SetDestination(hitInfo.point);
                }
                
            }

            //if(Input.GetTouch(0).phase == TouchPhase.Stationary)
            //{
            //    PigMovement.current.nav.enabled = true;
            //    ContinuouslyMoving();
            //}

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
