using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToRiver : MonoBehaviour {
    void OnMouseDown() {
        SceneManager.LoadScene(3);
    }
}
