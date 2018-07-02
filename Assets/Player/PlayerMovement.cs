using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float walkMovementRadius;
    [SerializeField] float walkStopRadius;

    ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;

    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_Move;


    

    bool isInDirectMode = false;    //todo consider making static 

    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }


    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {

        if(Input.GetKeyDown(KeyCode.G))         //Todo allow player to map later or add to menu. (G for Gamepad). 
        {
            isInDirectMode = !isInDirectMode;
        }


        if (isInDirectMode)
        {
            ProcessDirectMovement();
        }
        else
        {
            ProcessMouseMovement();
        }





    }

    private void ProcessDirectMovement()
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        // calculate camera relative direction to move:
        Vector3 m_CamForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 m_Move = v * m_CamForward + h * Camera.main.transform.right;


        m_Character.Move(m_Move, false, false);  
    }

    private void ProcessMouseMovement()  //Mouse movement
    {
        if (Input.GetMouseButton(0))            // WALK
        {

            switch (cameraRaycaster.layerHit)
            {
                case Layer.Walkable:
                    print("Cursor raycast hit" + cameraRaycaster.hit.collider.gameObject.name.ToString());
                    currentClickTarget = cameraRaycaster.hit.point;  // So not set in default case
                    break;

                default:
                    break;
            }
        }

        Vector3 playerToClickPoint = currentClickTarget - transform.position;
        if (playerToClickPoint.magnitude >= walkMovementRadius)
        {
            m_Character.Move(playerToClickPoint, false, false);
        }
        else if (playerToClickPoint.magnitude >= walkStopRadius)
        {
            m_Character.Move(playerToClickPoint * 0.2f, false, false);
        }
        else
        {
            m_Character.Move(Vector3.zero, false, false);
        }
    }
}

