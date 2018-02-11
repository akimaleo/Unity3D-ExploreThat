using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    CharacterController character;

    void Start()
    {
        character = GetComponent<CharacterController>();
        //Cursor.visible = false;
    }
    //movement speed
    public float speed = 5;

    Vector3 forwardDirection,
            moveDirection,
            sideDirection;

    private float yDegrees;

    public float jumpPower = 15,
                jumpDuration = 5,
                jumpCounter = 30;

    private bool ctrl = false,
                shift = false,
                lastGrounded = true,
                chGround;


    float gravityScale = 1;


    void Jump()
    {
       
        //GRAVITY
        character.Move(Physics.gravity * Time.deltaTime * gravityScale);
        chGround = character.isGrounded;


        if (!chGround) gravityScale += 0.15f;
        else gravityScale = 1;

        //JUMP INPUT
        if (Input.GetKeyDown(KeyCode.Space) && !ctrl && chGround)
            jumpCounter = 0;

        //JUMP ADDICTION
        if (jumpCounter < jumpDuration)//якщо персонажа підіймаємо
        {
            jumpDuration = 0.3f / Time.deltaTime;
            jumpCounter++;
            jumpPower = 10;
            
            character.Move(new Vector3(0, jumpPower * Time.deltaTime, 0));

            if (jumpCounter + 1 < jumpDuration)           
                gravityScale = 0.2f;
        }

    }

    void Update()
    {
        moveDirection = Vector3.zero;
        yDegrees = transform.rotation.eulerAngles.y * Mathf.PI / 180;
        forwardDirection = new Vector3(Mathf.Sin(yDegrees), 0, Mathf.Cos(yDegrees));

        yDegrees = (transform.rotation.eulerAngles.y + 90) * Mathf.PI / 180;
        sideDirection = new Vector3(Mathf.Sin(yDegrees), 0, Mathf.Cos(yDegrees));

        Jump();
        //destroy a terrain
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("Terrain").GetComponent<TerrainEditor>().DestroyTerrain(transform.position, 10);
        }*/

        //LEFT CTRL SIT
        if (Input.GetKeyDown(KeyCode.LeftControl) && !shift)
        {
            character.height = 270;
            character.center = new Vector3(0, 105, 0);
            speed = 2.5f;
            ctrl = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) && !shift)
        {
            character.height = 420;
            character.center = new Vector3(0, 34, 0);
            speed = 5;
            ctrl = false;
        }

        //WASD MOVEMENT
        if (Input.GetAxis("Vertical") != 0)
            moveDirection += Input.GetAxis("Vertical") * forwardDirection * speed;
        if (Input.GetAxis("Horizontal") != 0)
            moveDirection += Input.GetAxis("Horizontal") * sideDirection * speed;

        //LEFT SHIFT RUN
        if (Input.GetKeyDown(KeyCode.LeftShift) && !ctrl)
            speed = 10;
        else if (Input.GetKeyUp(KeyCode.LeftShift) && !ctrl)
            speed = 5f;

        character.Move(moveDirection * Time.deltaTime);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3F)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * 2 / body.mass;
    }
}
