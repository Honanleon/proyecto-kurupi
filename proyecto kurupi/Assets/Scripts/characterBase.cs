using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;



public class characterBase : MonoBehaviour
{


    [SerializeField] private Animator anim;

    SpriteRenderer m_SpriteRenderer;

    public bool isMoving;


    //private characterCombat character_Combat;

    void Awake (){
    //character_Combat = gameObject.GetComponent<characterCombat>();

    }
    // Start is called before the first frame update
    void Start()
    {
         m_SpriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void walkingAnimation (bool isMoving, bool walkingRight) {
        if (isMoving == true){
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
        }
        else {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
        }
        if (walkingRight == false) {
            m_SpriteRenderer.flipX = true;
        }
        if (walkingRight == true) {
            m_SpriteRenderer.flipX = false;
        }
    }
    public void deathAnimation (bool isDying, bool dyingRight) {
        if (isDying == true){
            anim.SetBool ("isDead", true);
        }        
        if (dyingRight == false) {
            m_SpriteRenderer.flipX = true;
        }
        if (dyingRight == true) {
            m_SpriteRenderer.flipX = false;
        }
    }

    public void runningAnimation (bool isSprinting, bool runningRight){
        if (isSprinting == true){
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isIdle", true);
            anim.SetBool("isRunning", false);
        }
        if (runningRight == false) {
            m_SpriteRenderer.flipX = true;
        }
        if (runningRight == true) {
            m_SpriteRenderer.flipX = false;
        }
    }
    public void idleAnimation (bool isInactive, bool idleRight){
        if (isInactive == true){
            anim.SetBool("isIdle", true);
        }
        else {
            anim.SetBool("isIdle", false);
        }
        if (idleRight == false) {
            m_SpriteRenderer.flipX = true;
        }
        if (idleRight == true) {
            m_SpriteRenderer.flipX = false;
        }
    }
    public void attackingAnimation (bool isPunching, bool attackingRight) {

        if (isPunching == true){
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", true);
        }
        else {
            anim.SetBool("isIdle", true);
            anim.SetBool("isAttacking", false);
        }
        if (attackingRight == false) {
            m_SpriteRenderer.flipX = true;
        }
        if (attackingRight == true) {
            m_SpriteRenderer.flipX = false;
        }
    }

}
