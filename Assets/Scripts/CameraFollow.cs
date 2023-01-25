using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] Transform player;
    // private float speed = 1f;
    // private Vector3 offset = new Vector3(0f, 20f, 0f);
    private Vector3 offset = new Vector3(0f, 40f, -40f);

    private Vector3 smoothVelocity = Vector3.zero;

    void Update() {
        // Vector3 targetPosition = player.transform.position + offset;
        Vector3 targetPosition = new Vector3 (0f, (player.transform.position + offset).y, (player.transform.position + offset).z);

        // transform.position = Vector3.Lerp(player.transform.position - player.forward * 10f, targetPosition, 0.3f);
        transform.position = Vector3.Lerp(new Vector3 (0f, player.transform.position.y, player.transform.position.z), targetPosition, 0.3f);

        // transform.LookAt(player);
    }
}
