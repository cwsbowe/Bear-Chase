using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Description : MonoBehaviour {
    private TypeOut typeOut;
    [SerializeField] GameObject panel;

    void Start() {
        panel.SetActive(true);
        typeOut = GetComponent<TypeOut>();
        StartCoroutine (PlayAfter("Two men were travelling together,\nwhen a bear suddenly met them on their\npath\nThey both ran, but can they\nescape the bear together?", 0f, 10f));
        StartCoroutine (PlayAfter("How will you escape the bear?\nClick on objects to interact with them", 10.5f, 8f));
        StartCoroutine (RemovePanel(18.5f));
    }

    IEnumerator PlayAfter(string description, float playAfter, float playFor) {
        yield return new WaitForSeconds(playAfter);
        typeOut.PlayText(description, playFor);
    }

    IEnumerator RemovePanel(float afterSecs) {
        yield return new WaitForSeconds(afterSecs);
        panel.SetActive(false);
    }

    public void EndingText(string ending) {
        typeOut.PlayText(ending);
    }
}
