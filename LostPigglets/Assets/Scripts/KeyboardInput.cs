using UnityEngine;
using System.Collections;
public class KeyboardInput : MonoBehaviour
{
    //public delegate void MovementInput(Vector3 position);

    //public static event MovementInput move;
    //public static event MovementInput rotate;

    private float timer;
    private float distance;
    private Plane groundPlane;
    private Ray ray;

    RaycastHit hit;

    public float tapTime = 0.2f;
    public Collider plane;

    /*void Start()
    {
        plane = GameObject.FindGameObjectWithTag("Plane").GetComponent<Collider>();
        groundPlane = new Plane(Vector3.up, Vector3.zero);
    }*/

    void Update()
    {
       //GetInput();

		if (GameManager.instance.cinematicCut == false) {
			
			if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
				GameManager.instance.player.transform.Translate (-10f * Input.GetAxis ("Horizontal") * Time.deltaTime, 0f, -10f * Input.GetAxis ("Vertical") * Time.deltaTime);
				GameManager.instance.move (GameManager.instance.player.transform.position);
			} else {
				GameManager.instance.notMoving (new Vector3 (0, 0, 0));
			}
		}

    }

    /*void Moving()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out hit, Mathf.Infinity))
        {
            //move(hit.point);
			GameManager.instance.move(hit.point);
        }
    }

    void Rotating()
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (groundPlane.Raycast(ray, out distance))
        {
            //rotate(ray.GetPoint(distance));
			GameManager.instance.rotate(ray.GetPoint(distance));
        }
    }
    void GetInput()
    {


        //if (Input.GetTouch(0).phase == TouchPhase.Moved)
        //{
        //    PigMovement.current.nav.enabled = false;
        //    Rotating();
        //    timer += Time.deltaTime;
        //}

        if (Input.GetMouseButtonDown(0))
        {
            //PigMovement.current.nav.enabled = true;
            Moving();
        }

        //if (Input.GetTouch(0).phase == TouchPhase.Ended)
        //{
        //    timer = 0;
        //}
    }*/
}
