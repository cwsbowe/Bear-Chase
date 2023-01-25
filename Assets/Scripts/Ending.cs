using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] GameObject bear;
    [SerializeField] GameObject descriptionBox;
    [SerializeField] GameObject ending0;
    [SerializeField] GameObject ending1;
    [SerializeField] GameObject ending2;

    private Description description;
    private bool village;
    private bool bearKill;
    private bool friendDead;

    void Start() {
        description = descriptionBox.GetComponent<Description>();
    }

    //End of game function
    public void EndOfStory() {
        if (bearKill) {
            ending0.SetActive(true);
            description.EndingText("You and your friend both get mauled\nby the bear.\nMaybe trying to the right thing was\nthe wrong decision.");
        } else {
            if (village) {
            ending1.SetActive(true);
            if (friendDead) {
                description.EndingText("You betray the trust of both your\n friend and the villagers.\nA number of children are mauled to\n death but you're alive\nCongratulations?");
            } else {
                description.EndingText("You and your friend both make it\n back to the relative safety of\n the village.\nMany other people die but at least you\n and your friend can ease each\n others consciences.\nCongratulations.");
            }
            } else {
                ending2.SetActive(true);
                if (friendDead) {
                    description.EndingText("Your friend is dead but you are\n safe.\nOther than the mental trauma of sentencing\n your closest friend to a brutal death you are unharmed.\nCongratulations.");
                } else {
                    description.EndingText("You cross the river and escape\nwith your friend and conscience intact.\nCongratulations!");
                }
            }
        }
        bear.SetActive(false);
        player.SetActive(false);
    }

    public void GoToVillage() {
        village = true;
    }

    public void BearEats() {
        bearKill = true;
    }

    public void KillFriend() {
        friendDead = true;
    }
}
