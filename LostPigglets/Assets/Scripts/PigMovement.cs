using UnityEngine;
using System.Collections;
public class PigMovement : MonoBehaviour
{
    public static PigMovement current;
    public Vector3 playerOffset = new Vector3(0, 0.5f, 0);
    public float rotSpeed = 3f; //Manager

    public Rigidbody pigRB;

	private bool moved = false;

    [HideInInspector]
    public NavMeshAgent nav;

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
            nav.SetDestination(position);
        }
    }

    void Rotate(Vector3 position)
    {
        Quaternion targetRotation = Quaternion.LookRotation((position + playerOffset) - transform.position);
        pigRB.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
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
