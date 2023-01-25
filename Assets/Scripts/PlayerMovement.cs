using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    [SerializeField] float speed;
    private Vector3 targetPosition;
    private Vector3 facing;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position;
        facing = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 1);
    }
    public void MoveToObject(int distanceFromObject, Vector3 objectPosition) {
        targetPosition = new Vector3(objectPosition.x, 0f, objectPosition.z - distanceFromObject);
        facing = objectPosition;
    }

    void Update() {
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        transform.LookAt(facing);
        //Vector3 forward = transform.forward;
        //transform.position += forward * speed * Time.deltaTime;

        transform.localEulerAngles = new Vector3(Mathf.Clamp(transform.localEulerAngles.x, 0, 0),transform.localEulerAngles.y,transform.localEulerAngles.z);
    }

    public Vector3 GetTargetPosition() {
        return targetPosition;
    }
}
