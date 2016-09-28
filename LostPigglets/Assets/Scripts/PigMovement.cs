using UnityEngine;
using System.Collections;
public class PigMovement : MonoBehaviour
{
    public static PigMovement current;
    public Vector3 playerOffset = new Vector3(0, 0.5f, 0);
    public float rotSpeed = 3f; //Manager

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
        KeyboardInput.move += Movement;
        TouchInput.move += Movement;
        TouchInput.rotate += Rotate;
    }

    void OnDisable()
    {
        KeyboardInput.move -= Movement;
        TouchInput.move -= Movement;
        TouchInput.rotate -= Rotate;
    }

    void Movement(Vector3 position)
    {
        nav.SetDestination(position);
    }

    void Rotate(Vector3 position)
    {
        Quaternion targetRotation = Quaternion.LookRotation((position + playerOffset) - transform.position);
        pigRB.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
    }
}
