using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class characterCombat : MonoBehaviour
{
    private characterBase character_Base;
    private Transform en1_Platform;
    private Vector3 en1_Platform_Position;
    private Transform player_Platform;
    private Vector3 player_Platform_Position;
    private Vector3 targetEnemy;

    private bool hasArrived;
    private bool hasStarted;

    public float healthPoints = 100;
    public float attackPoints = 150;
    public float defensePoints = 30;
    private float energyPoints = 30;

    private float enemy_healthPoints;
    private float enemy_attackPoints;
    private float enemy_defensePoints;

    private float attackCost = 10;
    private float defenseCost = 5;
    private float energyAddition = 15;

    public bool hasAttacked = false;
    private bool hasReturned;
    public bool isDefending;
    
    private enemyController enemy_Controller;


    private float moveDir;
    public float speed = 1f;


    void moveToEnemy () { 
            transform.position = Vector3.MoveTowards(transform.position, targetEnemy, speed * Time.deltaTime);
            character_Base.walkingAnimation(true, true);
    }

    void attack () {
        if (this.hasAttacked == false){
            character_Base.walkingAnimation(false, true);
            character_Base.attackingAnimation(true, true);
            if (isDefending == true){
                if (enemy_defensePoints < attackPoints){
                    enemy_healthPoints = enemy_healthPoints - (attackPoints - enemy_defensePoints);
                }
                else {
                    enemy_healthPoints = enemy_healthPoints;
                }
            }
            else {
                //enemy_healthPoints = enemy_healthPoints - attackPoints;
                enemy_Controller.receiveDamage(attackPoints);
            }
        }

        bool hasAttacked = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        character_Base = GetComponent<characterBase>();

        GameObject enemy1 = GameObject.Find("enemy");
        enemy_Controller = enemy1.GetComponent<enemyController>();
        enemy_healthPoints = enemy_Controller.healthPoints;
        enemy_attackPoints = enemy_Controller.attackPoints;
        enemy_defensePoints = enemy_Controller.defensePoints;


        GameObject en1Platform = GameObject.Find("en1Platform");
        en1_Platform = en1Platform.GetComponent<Transform>();
        en1_Platform_Position = en1_Platform.position;

        GameObject playerPlatform = GameObject.Find("playerPlatform");
        player_Platform = playerPlatform.GetComponent<Transform>();
        player_Platform_Position = player_Platform.position;

        Vector3 targetEnemy = en1_Platform_Position;
    }

    // Update is called once per frame
    void Update()
    {
        //if

        if(Input.GetKey(KeyCode.W)){
            hasArrived = false;
            hasStarted = true;
        }

            if (transform.position == targetEnemy){
                hasArrived = true;
            }
            else if (hasStarted == true){
                moveToEnemy();
            }

            if (hasArrived == true){
                attack();
            }
        
         //while (hasArrived == false){
            //transform.position = Vector3.MoveTowards(transform.position, en1_Platform_Position, speed * Time.deltaTime);
            //character_Base.walkingAnimation(true);

    }
        //character_Base.walkingAnimation(true);
        //moveToEnemy();
        //if(Input.GetKey(KeyCode.W)){
            //moveToEnemy(false);
        //}
            //hasAttacked = false;
            //while (hasAttacked == false){
            //    attack();
            //}
            //hasReturned = false;
            //while (hasReturned == false){
               //moveBack();
        
} 
    //void moveTo (Vector3 position) {
    //    player_Platform_Position = position;
    //}

    //public void moveTo (Vector3 position){
    //    en1_Platform_Position = position;

    //}

   // void moveBack (){

    //    if (transform.position == player_Platform_Position){
    //        hasReturned = true;
    //    }
    //    else {
    //        transform.position = Vector3.MoveTowards(transform.position, player_Platform_Position, speed * Time.deltaTime);
    //        character_Base.walkingAnimation(false);
   //     }
    //}