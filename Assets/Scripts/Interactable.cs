using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
    // [SerializeField] protected GameObject player;
    // [SerializeField] GameObject bear;
    protected GameObject player;
    private GameObject bear;
    [SerializeField] int distanceFromObject;
    [SerializeField] protected float delayBear;
    [SerializeField] protected int value;
    private PlayerMovement playerMovement;
    protected BearMovement bearMovement;

    protected AudioSource interactSound;


    // void Awake() {
    //     playerMovement = player.GetComponent<PlayerMovement>();
    //     bearMovement = bear.GetComponent<BearMovement>();
    //     interactSound = GetComponent<AudioSource>();

    //     delayBear = Random.Range(6,15);
    // }

    void OnEnable() {
        bear = GameObject.FindGameObjectWithTag("Bear");
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        bearMovement = bear.GetComponent<BearMovement>();
        interactSound = GetComponent<AudioSource>();
    }

    protected bool CheckInteract() {
        float distance = transform.position.z - player.transform.position.z;
        if (distance < 11f) {
            return true;
        }
        else {
            return false;
        }
    }

    protected void MoveCharacters() {
        playerMovement.MoveToObject(distanceFromObject, gameObject.transform.position);
        bearMovement.UpdatePlayerTarget(distanceFromObject, gameObject.transform.position);
        bearMovement.MoveForward();
    }

    protected void MoveCharacters(Vector3 bearTarget) {
        playerMovement.MoveToObject(distanceFromObject, gameObject.transform.position);
        bearMovement.AddTarget(bearTarget, gameObject, delayBear);
        bearMovement.UpdatePlayerTarget(distanceFromObject, gameObject.transform.position);
        bearMovement.MoveForward();
    }

    protected void FriendDown() {
        //different to other interactables as when friend is knocked over doesnt move player or bear
        gameObject.transform.eulerAngles = new Vector3 (0f, 0f, -90f);
        bearMovement.AttackFriend(delayBear);
        gameObject.GetComponent<Animator>().enabled = false;
        interactSound.Play();
        //Debug.Log(alive);
    }
}
