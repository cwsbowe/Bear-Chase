using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMovement : MonoBehaviour {

    [SerializeField] GameObject player;

    [SerializeField] float speed;
    [SerializeField] float chaseDistance;
    [SerializeField] GameObject endingDisplay;
    [SerializeField] GameObject friend;
    // [SerializeField] float followDistance = 5.0f;
    private Rigidbody rb;
    private Vector3 targetPosition;
    private List<Vector3> targetVectors;
    private List<GameObject> targetObjects;
    private List<float> targetDelays;
    private Ending ending;
    private bool delayNext;
    private AudioSource bearSound;

    void Start() {
        rb = GetComponent<Rigidbody>();
        ending = endingDisplay.GetComponent<Ending>();
        bearSound = GetComponent<AudioSource>();
        targetPosition = transform.position;
        targetVectors = new List<Vector3>();
        targetObjects = new List<GameObject>();
        targetDelays = new List<float>();
        targetVectors.Add(player.transform.position);
        targetObjects.Add(player);
        targetDelays.Add(6);
        targetDelays.Add(0);
        delayNext = true;
    }

    //Moves the bear forwards by chaseDistance and moves the bear horizontally by the appropriate amount in direction of the players distance from the bear
    public void MoveForward() {
        float changeX;
        // Debug.Log(targetVectors[0]);
        // Debug.Log(targetVectors[1]);
        // CheckAtObject();
        List<int> toRemove = new List<int>();
        for (int i = 0; i < targetVectors.Count; i++) {
            if (targetVectors.Count > 1) {
                if (targetVectors[i].z < transform.position.z + chaseDistance - targetDelays[0]) {
                    toRemove.Add(i);
                } else {
                    break;
                }
            }
        }
        foreach (int i in toRemove) {
            targetDelays[i+1] += targetDelays[i];
            targetDelays.RemoveAt(i);
            targetVectors.RemoveAt(i);
            targetObjects.RemoveAt(i);
        }
        if (delayNext) {
            delayNext = false;
            
            if (targetVectors[0].z < transform.position.z + chaseDistance - targetDelays[0]) {
                targetDelays[1] -= targetVectors[0].z - transform.position.z - chaseDistance + targetDelays[0];
                // targetDelays[0] =  targets[0].z - transform.position.z + chaseDistance;
                targetPosition = targetVectors[0];
                delayNext = true;
                CheckAtObject();
                // targetVectors.RemoveAt(0);
                // targetDelays.RemoveAt(0);
                // Debug.Log("0");
            } else {
                Debug.Log(transform.position.z + chaseDistance - targetDelays[0]);
                changeX = (targetVectors[0].x - transform.position.x) / (targetVectors[0].z - transform.position.z) * (chaseDistance - targetDelays[0]);
                targetPosition = new Vector3(transform.position.x + changeX, transform.position.y, transform.position.z + chaseDistance - targetDelays[0]);
                targetDelays.RemoveAt(0);
                // Debug.Log("1");
            }
        } else if (targetVectors[0].z < transform.position.z + chaseDistance) {
            if (targetDelays.Count > 2) {
                targetDelays[1] -= targetVectors[0].z - transform.position.z - chaseDistance + targetDelays[0];
                // targetDelays.RemoveAt(0);
            } else {
                targetDelays.Insert(0, transform.position.z + chaseDistance - targetVectors[0].z - targetDelays[0]);
                // targetDelays.RemoveAt(1);
            }
            // targetDelays[0] = targets[0].z - transform.position.z + chaseDistance;
            targetPosition = targetVectors[0];
            delayNext = true;
            // targetVectors.RemoveAt(0);
            // targetDelays.RemoveAt(0);
            CheckAtObject();
            // Debug.Log("2");
        } else {
            changeX = (targetVectors[0].x - transform.position.x) / (targetVectors[0].z - transform.position.z) * chaseDistance;
            targetPosition = new Vector3(transform.position.x + changeX, transform.position.y, transform.position.z + chaseDistance);
        }
        foreach (float i in targetDelays) {
            Debug.Log(i);
        }
    }

    void Update() {
        // Vector3 targetPosition = player.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // transform.LookAt(player.transform);
        transform.LookAt(targetVectors[0]);

        transform.localEulerAngles = new Vector3(Mathf.Clamp(transform.localEulerAngles.x, 0, 0),transform.localEulerAngles.y,transform.localEulerAngles.z);
    }

    public void AddTarget(Vector3 newTarget, GameObject obj, float newTargetDelay) {
        targetVectors.Insert(targetVectors.Count - 1, newTarget);
        targetObjects.Insert(targetObjects.Count - 1, obj);
        targetDelays.Insert(targetDelays.Count - 1, newTargetDelay);
    }

    public void UpdatePlayerTarget(int distanceFromObject, Vector3 objectPosition) {
        targetVectors.RemoveAt(targetVectors.Count - 1);
        //This accounts for where the players new position will be
        targetVectors.Add(new Vector3(objectPosition.x, 0f, objectPosition.z - distanceFromObject));
        //doesnt need to add to targetDelays as the last position is always 0
    }

    public void ChangePath() {
        int totalDelay = 0;
        foreach (int targetDelay in targetDelays) {
            totalDelay += targetDelay;
        }
        targetDelays = new List<float>();
        targetDelays.Add(totalDelay);
        targetDelays.Add(0);
        targetVectors = new List<Vector3>();
        targetVectors.Add(new Vector3 (0f, 0f, 0f));
        delayNext = true;
        MoveForward();
    }

    private void CheckAtObject() {
        // if (transform.position.z > targetVectors[0].z - 0.5f) {
            if (transform.position.z > player.transform.position.z - 0.5f) {
                ending.BearEats();
                ending.EndOfStory();
            } else {
                targetVectors.RemoveAt(0);
                targetDelays.RemoveAt(0);
                targetObjects[0].SetActive(false);
                targetObjects.RemoveAt(0);
            }
            bearSound.Play();
        // }
    }

    public void AttackFriend(float delayBear) {
        AddTarget(friend.transform.position, friend, delayBear);
    }
}
