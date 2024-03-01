using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCameraCollider : MonoBehaviour
{
    public GameObject site3;

    void OnCollisionEnter(Collision other){
        // Debug.Log("entered");
        if(site3.GetComponent<Site3>().mazeInteractionOn)
            if(other.gameObject.tag != "air" && other.gameObject.tag != "broken_pipe"){
                // other.gameObject.GetComponent<MeshRenderer>().material = invisibleMaterial;
                other.gameObject.layer = 7;
            }
        // site3.GetComponent<Site3>().collision_camera = true;
    }

    void OnCollisionStay(Collision other){
        // site3.GetComponent<Site3>().collision_camera = true;
        // site3.GetComponent<Site3>().normal_camera = other.contacts[0].normal;
    }

    void OnCollisionExit(Collision other){
        // Debug.Log("exited");
        if(site3.GetComponent<Site3>().mazeInteractionOn)
            if(other.gameObject.tag != "air" && other.gameObject.tag != "broken_pipe"){
                // other.gameObject.GetComponent<MeshRenderer>().material = brickWallMaterial;
                other.gameObject.layer = 6;
            }
        // site3.GetComponent<Site3>().collision_camera = false;
    }
}
