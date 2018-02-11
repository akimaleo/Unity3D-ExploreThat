using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    Transform player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    float rotationX, rotationY = 0F;
    public float sensitivity = 2F;

    Ray ray;
    RaycastHit hit;
    Transform cathed;
    Rigidbody cathedRb;
    //bool isCathed = false;

    void Update()
    {
        rotationX = Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -60, 60);
        transform.localEulerAngles = new Vector3(-rotationY, 0, 0);

        player.Rotate(0, rotationX, 0);



    }
}
    
//притягування об'єктів 
/*using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    Transform player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    float rotationX, rotationY = 0F;
    [Range(0.0f, 500f)]
    public float magicPower = 1F;
    public float sensitivity = 2F;

    Ray ray;
    RaycastHit hit;
    Transform cathed;
    Rigidbody cathedRb;
    bool advancedView = false, isCathed = false;

    void Update()
    {

        //Поворот камери і тіла мишою
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.visible = false;
            advancedView = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Cursor.visible = true;
            advancedView = false;
        }

        if (advancedView)
        {
            rotationX = Input.GetAxis("Mouse X") * sensitivity;
            rotationY += Input.GetAxis("Mouse Y") * sensitivity;
            rotationY = Mathf.Clamp(rotationY, -60, 60);
            transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
            isCathed = false;
            //поворот тіла по y, замість камери
            player.Rotate(0, rotationX, 0);
        }
        else {
            if (Input.GetMouseButton(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100))
                    if ((cathed = hit.transform).tag == "isPicking")
                    {                       
                        cathedRb = cathed.GetComponent<Rigidbody>();
                        isCathed = true;
                    }
                    else isCathed = false;
            }else if(Input.GetMouseButtonUp(0)){
                isCathed = false;
            } 
            if (isCathed)
            {
                Vector3 pushVector = (Vector3.Normalize(ray.origin - hit.point)*magicPower + Vector3.Normalize(hit.point - ray.origin)*cathedRb.mass);


                cathedRb.AddForce(pushVector);
                
                Debug.Log(Vector3.Normalize(ray.origin - hit.point) * magicPower / cathedRb.mass);
                Debug.DrawLine(ray.origin, hit.point);
            }
        }
    }
}*/
