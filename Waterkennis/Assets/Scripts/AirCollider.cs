using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCollider : MonoBehaviour
{
    public GameObject site3;

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "broken_pipe"){
            site3.GetComponent<Site3>().foundLeak = true;
        }
        if(other.gameObject.tag == "mazeWall")
            site3.GetComponent<Site3>().collision = true;
    }
    void OnCollisionStay(Collision other){
        if(other.gameObject.tag == "mazeWall"){
            site3.GetComponent<Site3>().collision = true;
            site3.GetComponent<Site3>().normal = other.contacts[0].normal;
        }
    }

    void OnCollisionExit(Collision other){
        if(other.gameObject.tag == "mazeWall")
            site3.GetComponent<Site3>().collision = false;
    }
}
