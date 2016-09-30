using UnityEngine;
using System.Collections;
public class PigMovement : MonoBehaviour
{
    public static PigMovement current;


    [HideInInspector]
    public Rigidbody pigRB;
    [HideInInspector]
    public NavMeshAgent nav;
	private bool moved = false;


    void Awake()
    {
        current = this;
		moved = false;
        nav = GetComponent<NavMeshAgent>();
    }


    void Start()
    {
        pigRB = gameObject.GetComponent<Rigidbody>();
    }


    void OnEnable()
    {
		GameManager.instance.OnPlayerMove += Movement; //KeyboardInput.move += Movement;
        //TouchInput.move += Movement;
		GameManager.instance.OnPlayerRotate += Rotate; //TouchInput.rotate += Rotate;
    }


    void OnDisable()
    {
		GameManager.instance.OnPlayerMove -= Movement; //KeyboardInput.move -= Movement;
        //TouchInput.move -= Movement;
		GameManager.instance.OnPlayerRotate -= Rotate; //TouchInput.rotate -= Rotate;
    }


    void Movement(Vector3 position)
    {
        if (nav.enabled)
        {
            //Debug.Log("Please Move");
            nav.SetDestination(position);
        }
    }


    void Rotate(Vector3 position)
    {
        //Debug.Log("Please Rotate");
        Quaternion targetRotation = Quaternion.LookRotation((position + PlayerStats.instance.rotationOffset) - transform.position);
        pigRB.rotation = Quaternion.Slerp(transform.rotation, targetRotation, PlayerStats.instance.rotSpeedFinger * Time.deltaTime);
    }


	//check whether player is not moving *****SHOULD BE IMPROVED, NO SOUND ON ROTATION!!!!!!!!!!!!
	void Update(){
		if ((moved == true && nav.enabled == true && nav.remainingDistance < 0.06f)
			|| nav.enabled == false) {
			GameManager.instance.notMoving (transform.position);
			moved = false;
		} else {
			moved = true;
		}
	}
}
