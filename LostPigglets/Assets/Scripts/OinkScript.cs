using UnityEngine;
using System.Collections;

public class OinkScript : MonoBehaviour {

    public int id;

    public float timeActive;

    float counter;

    GameObject playerPos;

    GameObject canvas;

    [HideInInspector]
    public GameObject pigletPos;

    float angle;
    Vector3 sign;
    float tempAngle;
    float canvasPosScaler = 0.8f;
    Vector2 canvasCenter;
    RectTransform rect;

    Vector2 spherePos;
    float sphereRadius;
    Vector2 canvasPos;
    float canvasWidthR;
    float canvasHeightR;


    //New try
    Vector3 vPos;

    // Use this for initialization
    void Start() {
        counter = 0f;
        rect = gameObject.GetComponent<RectTransform>();
        playerPos = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.FindGameObjectWithTag("GUI");
        canvasCenter = new Vector2(canvas.GetComponent<RectTransform>().rect.width/2.0f, canvas.GetComponent<RectTransform>().rect.height / 2.0f);
        canvasPos = new Vector2(canvas.GetComponent<RectTransform>().rect.width - canvas.GetComponent<RectTransform>().rect.width, canvas.GetComponent<RectTransform>().rect.height - canvas.GetComponent<RectTransform>().rect.height);
        rect.position = canvasPos;
        canvasWidthR = canvas.GetComponent<RectTransform>().rect.width/2.0f;
        canvasHeightR = canvas.GetComponent<RectTransform>().rect.height/2.0f;
        

        sphereRadius = (canvas.GetComponent<RectTransform>().rect.height / 2.0f) * 0.9f;

    }

    void Update() {

        if (OinkPool.current.isCreated) {

            counter += Time.deltaTime;

            //Debug.Log(AngleBetweenVector(playerPos.transform.position, pigletPos.transform.position) + " " + pigletPos);
            if (counter > timeActive) {
                DestroyOink();
            }
            angle = AngleBetweenVector(playerPos.transform.position, pigletPos.transform.position);
            spherePos = CalculateSpawnpoint(angle);
            rect.position = spherePos;

        }

    }
	
    void DestroyOink()
    {
        gameObject.SetActive(false);
        PigletManager.current.pigletActiveOink[id] = false;
        counter = 0f;
    
    }


    //Forward vector is the vector you want to measure the angle from
    private float AngleBetweenVector(Vector3 vec1, Vector3 vec2) {
        Vector3 refVector = (vec2 - vec1).normalized; // Find the vector from pig to piglet
        tempAngle = Vector3.Angle(playerPos.transform.forward.normalized, refVector);

       sign = Vector3.Cross(playerPos.transform.forward, refVector);
        if(sign.y < 0) {
            tempAngle = -tempAngle;
            tempAngle = 180f + tempAngle;
            tempAngle += 180f;
        }

        return tempAngle;
    }

    // Calculate the circular placement of the oink bubble
    Vector2 CalculateSpawnpoint(float angle) {       
        float radAngle = angle * Mathf.Deg2Rad;

        float newX = (Mathf.Sin(radAngle) * canvasWidthR * 0.8f);
        float newY = (Mathf.Cos(radAngle) * canvasHeightR * 0.8f);

        return new Vector2(canvasCenter.x - newX, canvasCenter.y - newY);
    }

}
