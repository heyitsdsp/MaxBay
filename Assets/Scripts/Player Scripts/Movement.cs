using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public FileManager fileManager;
    // Start is called before the first frame update
    Vector3 mousePos;
    float nonMovementZoneX;
    float nonMovementZoneY;
    [SerializeField]
    float velocityX;
    [SerializeField]
    int divisions;
    float screenWidthCurrent;
    bool activateControls = true;
    PointerActivation pointer;
    [SerializeField]
    float rotY = 40f;
    float initialRot;
    float zPos;
    void Start()
    {
        screenWidthCurrent = Screen.width;
        nonMovementZoneX = screenWidthCurrent / divisions;
        nonMovementZoneY = Screen.height / divisions;
        pointer = GetComponent<PointerActivation>();
        zPos = transform.position.z;
        initialRot = transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePosition();
        if (activateControls)
        {
            MovePlayer();
        }
        else if (!activateControls)
        {
           // pointer.DeactivateAllPointers();
        }
        CheckControlValidity();
        if (transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
        }
    }
    void GetMousePosition()
    {
        Vector3 posM = Input.mousePosition;
        posM.z = Camera.main.nearClipPlane;
        mousePos = Camera.main.ScreenToWorldPoint(posM);
        //Debug.Log("mouse pos:"+ mousePos);
        //Debug.Log("Player pos:" + transform.position);
        //Debug.Log("screen width:" + Screen.width);
    }
    void MovePlayer()
    {
        float direction = mousePos.x * screenWidthCurrent / 2 - transform.position.x;
        if (fileManager.playerState == "R" || direction>nonMovementZoneX)
        {
            MoveRight();
        }
        else if (fileManager.playerState == "L" || -direction>nonMovementZoneX )
        {
            MoveLeft();
        }
        else
        {
            transform.Translate(Vector3.zero * Time.deltaTime);
           // pointer.DeactivateAllPointers();
            transform.localEulerAngles = new Vector3(initialRot, 0, 0);
        }
        //transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
    void MoveRight()
    {
        // transform.Translate(transform.TransformDirection(Vector3.right)*velocityX* Time.deltaTime);
        /* Vector3 direction = transform.TransformDirection(Vector3.right);
         transform.Translate(direction * velocityX * Time.deltaTime);
         pointer.ActiavtePointer(3);
         transform.localEulerAngles = new Vector3(0, -rotY, 0);*/
       // pointer.ActiavtePointer(3);
        transform.Translate(new Vector3(1 / Mathf.Sqrt(2), 0f, -1 / Mathf.Sqrt(2)) * (velocityX) * Time.deltaTime);
        transform.localEulerAngles = new Vector3(initialRot, -rotY, 0);

    }
    void MoveLeft()
    {
        /* transform.Translate(new Vector3(-velocityX, 0f, 0f) * Time.deltaTime);
         pointer.ActiavtePointer(2);
         transform.localEulerAngles = new Vector3(0, rotY, 0);*/
       // pointer.ActiavtePointer(2);
        transform.Translate(new Vector3(1 / Mathf.Sqrt(2), 0f, 1 / Mathf.Sqrt(2)) * (-velocityX) * Time.deltaTime);
        transform.localEulerAngles = new Vector3(initialRot, rotY, 0);
    }
    void CheckControlValidity()
    {
        if((mousePos.y-1)*Screen.height > 5*nonMovementZoneY)
        {
            activateControls = false;
        }
        else if((mousePos.y - 1) * Screen.height < -5 * nonMovementZoneY)
        {
            activateControls = false;
        }
        else
        {
            activateControls = true;
        }
    }
}
