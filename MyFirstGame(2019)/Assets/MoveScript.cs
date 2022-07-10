using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class MoveScript : MonoBehaviour
{
    public GameObject player;
    public GameObject selectedUnit;
    public int heroHealth;
    public int maxHealth;
    public int speed = 15;
    public int RunSpeed = 15;
    public int repulsion = 15;
    public int WalkSpeed = 7;
    public int speedRotate = 2;
    public int speedJump = 325;
    public int monsterDmg;
    public GameObject RangedSpellPrefab;

    public Vector3 moveDirection;
    public Rigidbody playerRigidbody;

    public float gravityForce;
    public Vector3 moveVector;

    public EnemyStats enemyStatsScript;

    public Transform Teleport1;

    public Vector3 respa;

    public ParamsSave HeroHp;

    public HealthBar healthBar;



    public float autoAttackCurTime;
    public float autoAttackCooldown;
    public bool canAutoAttack;

    public bool behindEnemy;
    public bool canAttack;

    public float doubleClickTimer;
    public bool didDoubleClick;

    public LayerMask RaycastLayers;
    public bool inLineOfSight;

    public bool isGrounded;
    public float TickTime;

    public bool hoverOverActive;
    public string hoverName;

    public CharacterController ch_controller;
    // Start is called before the first frame update
    public void Start()
    {
        HeroHp = GameObject.Find("ParamsSave").GetComponent<ParamsSave>();
        player = (GameObject)this.gameObject;
        maxHealth = HeroHp.heroHealthic;
        heroHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        monsterDmg = HeroHp.monsterdamage;
        isGrounded = true;
    }

    public void Spawn(){
        Vector3 pos = respa;
        Instantiate(player, respa, Quaternion.identity);
    }

    // private void CharacterMove()
    // {
    //     moveVector = Vector3.zero;
    //     moveVector.x = Input.GetAxis("Horizontal") * speed;
    //     moveVector.z = Input.GetAxis("Vertical") * speed;

    //     moveVector.y = gravityForce;
    //     ch_controller.Move(moveVector * Time.deltaTime);
    // }

    // private void GamingGravity()
    // {
    //     if (!ch_controller.isGrounded) gravityForce -= 20f * Time.deltaTime;
    //     else gravityForce = -1f;
    // }

    public void OnCollisionEnter(Collision collision)
    {
        
        //print("Collision");
        if (collision.gameObject.tag.Equals("ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag.Equals("coin"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("FireBall"))
        {
            if(heroHealth < maxHealth)
            {
                heroHealth = heroHealth + 10;
                healthBar.SetHealth(heroHealth);
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("KillArea") && Input.GetKey(KeyCode.E))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("monster"))
        {

            player.GetComponent<Animator>().Play("die");
            heroHealth = heroHealth - monsterDmg;

            healthBar.SetHealth(heroHealth);

            // moveDirection = playerRigidbody.transform.position - collision.transform.position;
            // playerRigidbody.AddForce(moveDirection.normalized * 5000f);
        }
        if (collision.gameObject.tag.Equals("KillArea"))
        {
            Spawn();
            Destroy(this.gameObject);
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        
        print(heroHealth);
        if(heroHealth >= 1)
        {
            // CharacterMove();
            // GamingGravity();
            if(Input.GetMouseButton(0)){
            SelectTarget(0);
            }
            if(Input.GetMouseButton(1)){
                SelectTarget(1);
            }

            if(selectedUnit != null){

                Vector3 toTarget = (selectedUnit.transform.position - transform.position).normalized;

                if(Vector3.Dot(toTarget, selectedUnit.transform.forward) < 0){
                    behindEnemy = false;
                }else{
                    behindEnemy = true;
                }

                float distance = Vector3.Distance(this.transform.position, selectedUnit.transform.position);
                Vector3 targetDir = selectedUnit.transform.position - transform.position;
                Vector3 forward = transform.forward;
                float angle = Vector3.Angle(targetDir, forward);

                if (angle > 60.0){
                    canAttack = false;
                    autoAttackCurTime = 0;
                }
                else {
                    if(distance < 60){
                        canAttack = true;
                    }
                    else{
                        canAttack = false;
                        autoAttackCurTime = 0;
                    }
                }

                RaycastHit hit;
                if(Physics.Linecast(selectedUnit.transform.position, transform.position, out hit, RaycastLayers))
                {
                    Debug.Log("BLOCKED");
                    inLineOfSight = false;
                }
                else
                {
                    Debug.Log("NOT BLOCKED");
                    inLineOfSight = true;
                }

                if(doubleClickTimer > 0){
                    doubleClickTimer -= Time.deltaTime;
                }
                else{
                    didDoubleClick = false;
                }
            }

            if(selectedUnit != null && canAttack && canAutoAttack){
                if(autoAttackCurTime < autoAttackCooldown){
                    autoAttackCurTime += Time.deltaTime;
                }
                else{

                    BasicAttack();
                    autoAttackCurTime = 0;
                }
            }

            if(Input.GetKeyDown("1")){
                if(selectedUnit != null && canAttack && inLineOfSight){
                    BasicAttack();
                    canAutoAttack = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                RangedAttack();
            }

            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit2;

            if(Physics.Raycast(ray2, out hit2, 10000)){
                if(hit2.transform.tag == "monster") {
                    hoverOverActive = true;
                    hoverName = hit2.transform.GetComponent<EnemyStats>().enemyName;
                }
                else{
                    hoverOverActive = false;
                }
            }


            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
            {
                player.transform.position += player.transform.forward * WalkSpeed * Time.deltaTime;
            }
            else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                player.transform.position += player.transform.forward * RunSpeed * Time.deltaTime;
            }else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                player.transform.position += player.transform.forward * RunSpeed * Time.deltaTime * 2;
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                player.transform.position -= player.transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                player.transform.Rotate(Vector3.up * speedRotate);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                player.transform.Rotate(Vector3.down * speedRotate);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Spawn();
                Destroy(this.gameObject);
            }

            
            //if (Input.GetKey(KeyCode.Space))
            //{
            //    player.transform.position += player.transform.up * speedJump * Time.deltaTime;
            //}

            if (isGrounded && Input.GetKey(KeyCode.Space))
            {
                isGrounded = false;
                player.transform.position += player.transform.up * speedJump * Time.deltaTime;
            }

        }else
        {
            SceneManager.LoadScene("Loser");
        }
        
    }

    void SelectTarget(int selectedNum){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 10000)){
            if(hit.transform.tag == "monster")
            {
                selectedUnit = hit.transform.gameObject;
                enemyStatsScript = selectedUnit.transform.gameObject.transform.GetComponent<EnemyStats>();

                if(selectedNum == 0 && selectedUnit == null)
                {
                    canAutoAttack = false;
                }
                else if(selectedNum == 1)
                {
                    canAutoAttack = true;
                }
            }
            else {
                if(selectedUnit != null){
                    if(didDoubleClick == false){
                        didDoubleClick = true;
                        doubleClickTimer = 0.3f;
                    }
                    else{

                        print("DESELECT");
                        selectedUnit = null;
                        didDoubleClick = false;
                        doubleClickTimer = 0;
                        autoAttackCurTime = 0;
                    }
                }
            }
        }
    }

    void BasicAttack(){
        enemyStatsScript.RecieveDamage(10);
    }

    void RangedAttack(){
        Vector3 SpawnSpellLoc = new Vector3 (this.transform.position.x, this.transform.position.y + 11, this.transform.position.z);

        GameObject clone;
        clone = Instantiate (RangedSpellPrefab, SpawnSpellLoc, Quaternion.identity);
        clone.transform.GetComponent<RangedSpell>().Target = selectedUnit;
    }


}
