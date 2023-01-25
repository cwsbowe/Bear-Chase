using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berries : Interactable {
    [SerializeField] float rotationSpeed;

    void Start() {

    }
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotationSpeed);
    }

    void OnMouseDown() {
        if (CheckInteract()) {
            //gameObject.transform.eulerAngles = new Vector3 (0f, 0f, 0f);
            //gameObject.transform.position = new Vector3 (gameObject.transform.position.x, 0.5f, gameObject.transform.position.z);
            MoveCharacters(gameObject.transform.position);
        }
    }
}
