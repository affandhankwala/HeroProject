using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class countScript : MonoBehaviour
{
    public int eggCount;
    public int planeCount;
    public int eggKills;
    public int touchKills;

    public string controls = "Keyboard";
    
    public TMP_Text myText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get all data from scripts
        controls = HeroScript.controlStatus;
        eggCount = HeroScript.eggCount;
        planeCount = HeroScript.planeCount;
        eggKills = HeroScript.eggKills;
        touchKills = HeroScript.touchKills;
       //myText.text = "Control Mode: "+controls;
        myText.text = "Use the eggs to destroy the planes. Or just hit them"+"\n"+
        "Press 'q' to quit the game and 'i' to toggle invincibility"+"\n"+
        "Control Mode: "+controls+"\n"+
        "Eggs on screen: "+eggCount+"\n"+
        "Enemies touched: "+touchKills+"\n"+
        "Enemies on screen: "+planeCount+"\n"+
        "Total Kills: "+(eggKills + touchKills)+"\n"+
        "Invincible: "+HeroScript.invincible+"\n"+
        "Hero Health: "+HeroScript.health+"\n";


        //Quit the game:
        if(Input.GetKeyDown("q")){
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
