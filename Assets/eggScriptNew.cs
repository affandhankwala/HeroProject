using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class eggScriptNew : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.smoothDeltaTime * 40f;
    }
    void OnBecameInvisible() {
        Destroy (gameObject);
        HeroScript.eggCount--;
    }
}
 