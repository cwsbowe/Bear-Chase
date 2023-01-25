using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {
    private GameObject endingDisplay;
    private Ending ending;

    void Start() {
        endingDisplay = GameObject.Find("Ending Display");
        ending = endingDisplay.GetComponent<Ending>();
    }

    void OnMouseDown() {
        ending.EndOfStory();
    }
}
