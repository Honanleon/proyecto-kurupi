using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class characterCombat : MonoBehaviour
{
    private characterBase character_Base;
    private BattleHandler battle_Handler;
    private Transform en1_Platform;
    private Vector3 en1_Platform_Position;
    private Transform player_Platform;
    private Vector3 player_Platform_Position;
    private Vector3 targetEnemy;

    private bool hasArrived;
    private bool hasStarted;

    private float healthPoints = 100;
    private float attackPoints = 55;
    public float defensePoints = 30;
    private float energyPoints = 30;

    private float enemy_healthPoints;
    private float enemy_attackPoints;
    private float enemy_defensePoints;

    private float attackCost = 10;
    private float defenseCost = 5;
    private float energyAddition = 15;

    public bool hasAttacked;
    public bool hasReturned;
    private bool hasFinishedAnimation;
    public bool isDefending;
    
    private enemyController enemy_Controller;


    private float moveDir;
    public float speed = 1f;

    void moveToEnemy () { 
            transform.position = Vector3.MoveTowards(transform.position, targetEnemy, speed * Time.deltaTime);
            character_Base.walkingAnimation(true, true);
            if (transform.position == targetEnemy){
                hasArrived = true;
            }
    }

    void attack () {
        if (this.hasAttacked == false){
            character_Base.walkingAnimation(false, true);
            character_Base.attackingAnimation(true, true);
            if (isDefending == true){
                if (enemy_defensePoints < attackPoints){
                    if (hasFinishedAnimation == true){
                        character_Base.attackingAnimation(false, true);
                        enemy_Controller.receiveDamage(attackPoints - enemy_defensePoints);
                        this.hasAttacked = true;
                    }
                }
                else {
                    if (hasFinishedAnimation == true){
                    this.hasAttacked = true;
                    }
                }
            }
            else {
                if (hasFinishedAnimation == true){
                enemy_Controller.receiveDamage(attackPoints);
                this.hasAttacked = true;
                }
            }
        }

    }

    void returnToPlatform () {
        transform.position = Vector3.MoveTowards(transform.position, player_Platform_Position, speed * Time.deltaTime);
        character_Base.attackingAnimation(false, true);
        character_Base.walkingAnimation(true, false);
        if (transform.position == player_Platform_Position){
            hasReturned = true;
        }
    }
    void FinishedAnimation (){
        hasFinishedAnimation = true;
    }

    public void receiveDamage (float damageReceived){
        healthPoints = healthPoints - damageReceived;
        damageReceived = 0;
    }

    public void attackCircuit (){
         if (hasStarted == true && hasArrived == false){
                moveToEnemy();
            }
            if (hasArrived == true && hasAttacked == false){
                attack();
            }
            if (hasAttacked == true && hasReturned == false && hasFinishedAnimation == true){
                returnToPlatform();
            }
            if (hasReturned == true){
                hasReturned = false;
                hasArrived = false;
                hasAttacked = false;
                hasFinishedAnimation = false;
                battle_Handler.endAttack();
                character_Base.walkingAnimation(false, true);
                character_Base.idleAnimation(true, true);
            }
    }
    // Start is called before the first frame update
    void Start()
    {
        character_Base = GetComponent<characterBase>();

        hasArrived = false;
        hasStarted = true;
        hasAttacked = false;
        hasReturned = false;
       
        GameObject enemy1 = GameObject.Find("enemy");
        enemy_Controller = enemy1.GetComponent<enemyController>();
        enemy_defensePoints = enemy_Controller.defensePoints;


        GameObject en1Platform = GameObject.Find("en1Platform");
        en1_Platform = en1Platform.GetComponent<Transform>();
        en1_Platform_Position = en1_Platform.position;

        GameObject playerPlatform = GameObject.Find("playerPlatform");
        player_Platform = playerPlatform.GetComponent<Transform>();
        player_Platform_Position = player_Platform.position;

        Vector3 targetEnemy = en1_Platform_Position;

        GameObject battleHandler = GameObject.Find("BattleHandler");
        battle_Handler = battleHandler.GetComponent<BattleHandler>();
    }

    // Update is called once per frame
    void Update()
    {

    }
        
} 