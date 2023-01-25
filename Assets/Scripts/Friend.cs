using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : Interactable {
    // [SerializeField] GameObject bear;
    [SerializeField] GameObject bro;
    [SerializeField] GameObject endingDisplay;
    // [SerializeField] GameObject friend;
    private Ending ending;
    private bool alive;
    private bool hovering;

    void Start() {
        ending = endingDisplay.GetComponent<Ending>();
        alive = true;
        hovering = false;
        bro.SetActive(false);
    }

    void OnMouseOver() {
        bro.SetActive(true);
        hovering = true;
    }

    void OnMouseExit() {
        bro.SetActive(false);
        hovering = false;
    }

    void OnMouseDown() {
        ending.KillFriend();
        alive = false;
    }

    void Update() {
        if (alive) {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + 2, 0f, player.transform.transform.position.z), 5 * Time.deltaTime);
            transform.localEulerAngles = new Vector3(Mathf.Clamp(transform.localEulerAngles.x, 0, 0),transform.localEulerAngles.y,transform.localEulerAngles.z);
        }
        if (hovering && Input.GetKeyDown(KeyCode.Mouse0)) {
            FriendDown();
        }
    }
}
