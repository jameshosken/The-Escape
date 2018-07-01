using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;
    
    [SerializeField] float walkMovementStopRadius = 0.2f;

    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
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

        var playerToClickPoint = currentClickTarget - transform.position;
        if(playerToClickPoint.magnitude >= walkMovementStopRadius)
        {
            m_Character.Move(currentClickTarget - transform.position, false, false);
        }

        
    }
}

