using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public bool selectedEnemy = false;
    public Transform thisTransform;

    private float healthPoints;
    private float attackPoints = 25;
    public float defensePoints = 25;
    private float energyPoints = 10;

    private float attackCost = 10;
    private float defenseCost = 5;
    private float energyAddition = 15;
        
    public bool isDefending;

    private characterCombat enemy_Controller;
    private float enemy_healthPoints;
    private float enemy_attackPoints;
    private float enemy_defensePoints;
    private bool enemy_hasAttacked;

    private enemyBase enemy_Base;

    

    // Start is called before the first frame update
    public void receiveDamage (float damageReceived){
        healthPoints = healthPoints - damageReceived;
    }
    void Start()
    {

        enemy_Base = GetComponent<enemyBase>();
        healthPoints = 100;
        //Transform thisTransform =  GetComponent<Transform>();
        GameObject enemy1 = GameObject.Find("player");
        enemy_Controller = enemy1.GetComponent<characterCombat>();
        enemy_defensePoints = enemy_Controller.defensePoints;

        enemy_hasAttacked = enemy_Controller.hasAttacked;


    }

    // Update is called once per frame
    void Update()
    {



        if (healthPoints < 0) {
            enemy_Base.deathAnimation(true, false);
        }
    }
}
