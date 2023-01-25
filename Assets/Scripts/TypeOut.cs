using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
using TMPro;

public class TypeOut : MonoBehaviour {
    private TextMeshProUGUI txt;

    void Start() {
        txt = GetComponent<TextMeshProUGUI>();
    }

    public void PlayText(string description) {
        txt.text = "";
        StartCoroutine (Typing(description));
    }

    public void PlayText(string description, float secs) {
        txt.text = "";
        StartCoroutine (Typing(description));
        StartCoroutine (ResetAfter(secs));
    }

    IEnumerator Typing(string description) {
        foreach (char c in description) {
            txt.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator ResetAfter(float secs) {
        yield return new WaitForSeconds(secs);
        txt.text = "";
    }
}
