using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyPot : Interactable {

    void OnMouseDown() {
        if (CheckInteract()) {
            // gameObject.transform.eulerAngles = new Vector3 (0f, 0f, 0f);
            // gameObject.transform.position = new Vector3 (gameObject.transform.position.x, 0.5f, gameObject.transform.position.z);
            // MoveCharacters(gameObject.transform.position);
            interactSound.Play();
            MoveCharacters(gameObject.transform.position);
        }
    }
}
