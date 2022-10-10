using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HeroScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool keyboard;
    float speed;

    float rotateSpeed = 45;
    float fireRate = 0.2f;
    float nextFire = 0.0f;
    float eggSpeed = 40f;
    public GameObject eggSample;

    public static string controlStatus;
    public static int eggCount = 1;
    public static int planeCount = 1;
    public static int eggKills = 0;
    public static int touchKills = 0;
    public GameObject planeSample;

    public static int health;
    public static bool takeDamage = false;
    public static string invincible;
    public Camera MainCamera;
    
    //public Egg eggPrefab;
    void Start()
    {
        //keep track of whether the keyboard keys will be used or not
        keyboard = true;
        speed = 5;
        MainCamera = Camera.main;
        health = 20;
        invincible = "true";
    }

    // Update is called once per frame
    void Update()
    {
        //check if take damage
        if(Input.GetKeyDown("i")){
            takeDamage = !takeDamage;
        }
        if(takeDamage){
            invincible = "false";
        }
        else if(!takeDamage){
            invincible = "true";
        }
        if(health <= 0){
            //End the game if your health goes less than 0
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }


        if(Input.GetKeyDown("m")){
            //switch state of keyboard
            keyboard = !keyboard;
        }

        if(keyboard == true){
            //keyboard
            //always go forward 
            controlStatus = "Keyboard";
            speed += Input.GetAxis("Vertical");
            transform.position += transform.up * Time.smoothDeltaTime * speed;
        }
        else{
            //mouse
            controlStatus = "Mouse";
            //Vector3 means you gather the x, y, and z components from mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //z is 0 for us
            mousePosition.z = 0;
            //Make assets's position always at the mouse
            transform.position = mousePosition;
        }

        //turning
        if(Input.GetKey("left") || Input.GetKey("a")){
            transform.Rotate(0,0,rotateSpeed * Time.smoothDeltaTime);
        }
        if(Input.GetKey("right") || Input.GetKey("d")){
            transform.Rotate(0,0, -1f * rotateSpeed * Time.smoothDeltaTime);
        }
        

        //Shoot egg
        shootEgg();
        
        //Spawn planes
        spawnPlanes();
    }
    private void shootEgg(){
        if(Input.GetKey(KeyCode.Space) && Time.time > nextFire){
            GameObject egg = Instantiate(eggSample, transform.position, transform.rotation);
            Rigidbody2D e = egg.GetComponent<Rigidbody2D>();
            e.velocity = transform.up * eggSpeed;
            nextFire = Time.time + fireRate;
            eggCount++;
        }
    }
    
    private void spawnPlanes(){
        if(planeCount < 10){
            float height = MainCamera.orthographicSize;
            float width = height / MainCamera.aspect;

            float randomWidth = Random.Range(-1 * 0.9f * width, 0.9f * width);
           
            float randomHeight = Random.Range(-1 * 0.9f * height, 0.9f * height);
            
            Vector3 randomSpawn = new Vector3(randomWidth, randomHeight, 0f);
            Instantiate(planeSample, randomSpawn, Quaternion.identity);
            planeCount++;
        }
    }
}

