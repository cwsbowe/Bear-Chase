using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangePath : MonoBehaviour {
    // [SerializeField] GameObject path;
    [SerializeField] GameObject player;
    [SerializeField] GameObject bear;
    [SerializeField] int sceneNumber;
    [SerializeField] Vector3 triggerLocation;
    [SerializeField] GameObject otherPathChoice;
    [SerializeField] GameObject pathInfo;
    [SerializeField] GameObject endingDisplay;

    private PlayerMovement playerMovement;
    private BearMovement bearMovement;
    private Ending ending;

    void Start() {
        playerMovement = player.GetComponent<PlayerMovement>();
        bearMovement = bear.GetComponent<BearMovement>();
        ending = endingDisplay.GetComponent<Ending>();
        pathInfo.SetActive(false);
    }

    void OnMouseDown() {
        playerMovement.MoveToObject(0, triggerLocation);
        otherPathChoice.SetActive(false);
    }

    void OnMouseOver() {
        pathInfo.SetActive(true);
    }

    void OnMouseExit() {
        pathInfo.SetActive(false);
    }

    void Update() {
        if (player.transform.position.z > triggerLocation.z - 0.5f) {
            bear.transform.position = new Vector3 (0f, 0f, bear.transform.position.z - player.transform.position.z);
            player.transform.position = new Vector3 (0f, 0f, -0.1f);
            playerMovement.MoveToObject(0, new Vector3 (0f, 0f, 0f));
            bearMovement.ChangePath();
            if (sceneNumber == 2) {
                ending.GoToVillage();
            }
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
