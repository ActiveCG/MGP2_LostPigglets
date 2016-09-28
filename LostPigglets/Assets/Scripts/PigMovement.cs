using UnityEngine;
using System.Collections;
public class PigMovement : MonoBehaviour
{
    public static PigMovement current;
    public float rotSpeed = 3f; //Manager
    public float movSpeed; //Manager

    private float test;
    private bool canMove;

    private Vector3 direction;
    private Vector3 targetDirection;
    private Vector3 targetPosition;
    float distance;

    private Quaternion lookRot;

    private Rigidbody pigRB;

    [HideInInspector]
    public NavMeshAgent nav;

    void Awake()
    {
        current = this;
    }

    void Start()
    {
        pigRB = gameObject.GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
    }

    void OnEnable()
    {
        //MouseInput.move += Movement;
        TouchInput.move += Movement;
        TouchInput.rotate += Rotate;
    }

    void OnDisable()
    {
        //MouseInput.move -= Movement;
        TouchInput.move -= Movement;
        TouchInput.rotate -= Rotate;
    }

    //void FixedUpdate()
    //{
    //    if (canMove == true)
    //    {
    //        //Quaternion targetRotation = Quaternion.LookRotation((targetPosition - transform.position).normalized);
    //        //pigRB.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);

    //        //targetDirection = (targetPosition - transform.position + new Vector3(0, 0.5f, 0)).normalized;

    //        //Debug.Log(targetDirection);
    //        distance = Vector3.Distance(targetPosition, transform.position);

    //        //Debug.Log(transform.position);
    //        pigRB.AddForce(transform.forward * movSpeed);

    //        if (distance < 0.1f)
    //        {
    //            canMove = false;
    //            Debug.Log("I am in");
    //        }
    //    }
    //}

    void Movement(Vector3 position)
    {
        //Debug.Log(position);
        //targetPosition = position + new Vector3(0, 0.5f, 0);
        //Debug.Log(targetPosition);
        //canMove = true;
        nav.SetDestination(position);
    }

    void Rotate(Vector3 position)
    {
        Quaternion targetRotation = Quaternion.LookRotation((position + new Vector3(0,0.5f,0)) - transform.position);
        pigRB.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
    }
}
