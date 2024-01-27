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
    private bool hasArrived;
    private bool hasStarted;
    //private bool hasAttacked;
    private bool hasReturned;


    private float moveDir;
    public float speed = 1f;


    void moveToEnemy () { 
            transform.position = Vector3.MoveTowards(transform.position, en1_Platform_Position, speed * Time.deltaTime);
            character_Base.walkingAnimation(true, true);
    }
    // Start is called before the first frame update
    void Start()
    {
        character_Base = GetComponent<characterBase>();
        GameObject en1Platform = GameObject.Find("en1Platform");
        en1_Platform = en1Platform.GetComponent<Transform>();
        en1_Platform_Position = en1_Platform.position;
        GameObject playerPlatform = GameObject.Find("playerPlatform");
        player_Platform = playerPlatform.GetComponent<Transform>();
        player_Platform_Position = player_Platform.position;
        //hasArrived = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            hasArrived = false;
            hasStarted = true;
        }

            if (transform.position == en1_Platform_Position){
                hasArrived = true;
            }
            else if (hasStarted == true){
                moveToEnemy();
            }

            if (hasArrived == true){
                character_Base.walkingAnimation(false, true);
                character_Base.attackingAnimation(true, true);

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


    //public void attack () {
    //    character_Base.attackingAnimation(true);
    //    hasAttacked = true;
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