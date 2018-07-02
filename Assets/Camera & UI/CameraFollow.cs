using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] float bounciness = 0.5f;

    [SerializeField] Transform player;
    [SerializeField] Transform camera;
    [SerializeField] [Range(1, 100)] float verticalOffset;

    Transform playerTransform;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = Vector3.Lerp(transform.position, player.position, 0.2f);

        float horz = Input.GetAxis("Horizontal");
        
            transform.Rotate(new Vector3(0, -horz, 0));
        

        float vert = Input.GetAxis("Vertical") * 0.1f;

        camera.transform.Translate(new Vector3( 0, vert, 0), Space.World);
        

        camera.transform.LookAt(transform, Vector3.up);
        
    }
}
