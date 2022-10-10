using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class planeScript : MonoBehaviour
{
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        health = 4;
    }
    void Update(){
        if(health <= 0){
            //If health goes below zero then we assume it was destroyed by egg
            Destroy(gameObject);
            HeroScript.planeCount--;
            HeroScript.eggKills++;
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "Egg(Clone)"){
            Color c = this.GetComponent<SpriteRenderer>().color;
            //c = new Color(c.r, c.g, c.b, c.a * 0.8f);
            c.a *= 0.8f;
            this.GetComponent<SpriteRenderer>().color = c;
            health--;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.name == "Hero"){
            Destroy(gameObject);
            HeroScript.touchKills++;
            HeroScript.planeCount--;
            if(HeroScript.takeDamage == true){
                HeroScript.health--;
            }
        }
    }
}
