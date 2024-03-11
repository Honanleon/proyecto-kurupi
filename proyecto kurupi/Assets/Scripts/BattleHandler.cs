using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleHandler : MonoBehaviour
{
    public State state;
    private characterCombat character_Combat;
    private bool startAttack;
    //private attackButton attack_Button;
    private Canvas canvas;
    public enum State {
        WaitingForPlayer,
        Busy,
    }

    public void attackInput(){
        startAttack = true;
    }
    public void endAttack(){
        startAttack = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        state = State.WaitingForPlayer;

        GameObject characterCombat = GameObject.Find("player");
        character_Combat = characterCombat.GetComponent<characterCombat>();         

        GameObject attackButton = GameObject.Find("Canvas/attackButton");
        //attack_Button = attackButton.GetComponent<attackButton>();
                
        GameObject canvas = GameObject.Find("Canvas");

    }


    // Update is called once per frame
    void Update()
    {
        if (state == State.WaitingForPlayer) {
            if (startAttack == true) {
                character_Combat.attackCircuit();
                if (startAttack == false){
                    state = State.Busy;
                }

            }
        }
    }
}
