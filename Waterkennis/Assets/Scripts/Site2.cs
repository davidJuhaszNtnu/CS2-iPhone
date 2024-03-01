using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random=UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using Mapbox.Examples;

public class Site2 : MonoBehaviour
{
    public GameObject well_prefab, pipe_prefab, membrane_prefab, tank_prefab;
    public GameObject site2, site2UI, welcomePanel, findPanel, itemsFoundPanel, taskCompletedPanel, taskPanel, app, 
    distanceWarningPanel, gameController, languagePanel, tapOnObjectPanel;
    public GameObject pipe_image_findPanel_L, membrane_image_findPanel_L, tank_image_findPanel_L;
    public GameObject[] image_anchors_findPanel_L;
    public GameObject pipe_image_findPanel_P, membrane_image_findPanel_P, tank_image_findPanel_P;
    public GameObject[] image_anchors_findPanel_P;
    public Camera arCamera, mapCamera;
    int order, pipe_order, membrane_order, tank_order;
    bool pipeCollected, membraneCollected, tankCollected, allCollected;
    bool start_search;
    private float d_membrane, d_pipe, d_tank, d_well;
    public float showDistance, maxDistance;
    private bool objectShown;
    public TMP_Dropdown dropdown;
    public GameObject LanguageChanger;

    public Sprite markerSprite;

    GameObject well, pipe, membrane, tank;

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        restart();
    }

    public void restart(){
        pipeCollected = false;
        membraneCollected = false;
        tankCollected = false;
        allCollected = false;

        start_search = false;
        order = 0;
        welcomePanel.SetActive(true);
        findPanel.SetActive(false);
        itemsFoundPanel.SetActive(false);
        taskPanel.SetActive(false);
        taskCompletedPanel.SetActive(false);

        pipe_image_findPanel_L.SetActive(false);
        membrane_image_findPanel_L.SetActive(false);
        tank_image_findPanel_L.SetActive(false);
        pipe_image_findPanel_P.SetActive(false);
        membrane_image_findPanel_P.SetActive(false);
        tank_image_findPanel_P.SetActive(false);

        d_pipe = 0.1f;
        d_membrane = 0.1f;
        d_tank = 0.1f;
    }

    public void ok_welcomePanel_bbtn(){
        welcomePanel.SetActive(false);
        languagePanel.SetActive(false);
        findPanel.SetActive(true);
        start_search = true;
    }

    public void ok_itemsFoundPanel_bttn(){
        itemsFoundPanel.SetActive(false);
        // findPanel.SetActive(false);
        taskPanel.SetActive(true);

        string orientation;
        if(Screen.orientation == ScreenOrientation.Portrait)
            orientation = "portrait";
        else orientation = "landscape";
        site2UI.GetComponent<Site2UI>().setImages(pipe_order, membrane_order, tank_order, orientation);
    }
    
    public void startSite(){
        site2UI.GetComponent<Site2UI>().set_tank_level();
        welcomePanel.SetActive(true);
        findPanel.SetActive(false);
        itemsFoundPanel.SetActive(false);
        taskPanel.SetActive(false);
        taskCompletedPanel.SetActive(false);

        pipe_image_findPanel_L.SetActive(false);
        membrane_image_findPanel_L.SetActive(false);
        tank_image_findPanel_L.SetActive(false);
        pipe_image_findPanel_P.SetActive(false);
        membrane_image_findPanel_P.SetActive(false);
        tank_image_findPanel_P.SetActive(false);

        well = Instantiate(well_prefab);
        pipe = Instantiate(pipe_prefab);
        membrane = Instantiate(membrane_prefab);
        tank = Instantiate(tank_prefab);
        well.transform.SetParent(transform, true);
        pipe.transform.SetParent(transform, true);
        membrane.transform.SetParent(transform, true);
        tank.transform.SetParent(transform, true);

        LanguageChanger.GetComponent<LanguageChanger>().pipe_text = pipe.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        LanguageChanger.GetComponent<LanguageChanger>().memmbrane_text = membrane.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        LanguageChanger.GetComponent<LanguageChanger>().tank_text = tank.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        Vector3 dir = arCamera.transform.forward;
        well.transform.position = transform.position + Vector3.Normalize(new Vector3(dir.x, 0f, dir.z)) * 1f + new Vector3(0f, -0.3f, 0f);
        well.AddComponent<ARAnchor>();
        // well.transform.rotation = Quaternion.LookRotation(new Vector3(dir.x,0f,dir.z), Vector3.up)*Quaternion.Euler(-90,0,0);

        float angle;
        float dist;
        Vector3 position_vec = new Vector3(arCamera.transform.position.x - transform.position.x, 0f, arCamera.transform.position.z - transform.position.z);
        // position_vec = new Vector3(0f, 0f, 1f);
        position_vec.Normalize();
        
        angle = Random.Range(-60, 60);
        dist = Random.Range(1.5f, maxDistance);

        // pipe.transform.position = arCamera.transform.position + (new Vector3(dist*(float)Math.Cos(angle), 0.5f, dist*(float)Math.Sin(angle))) + new Vector3(0f, -0f, 0f);
        Vector3 component_pos = Quaternion.Euler(0, angle, 0) * position_vec * dist;
        pipe.transform.position = arCamera.transform.position + new Vector3(component_pos.x, -0.3f, component_pos.z);
        pipe.name = "pipe";
        pipe.AddComponent<ARAnchor>();

        angle = Random.Range(-60, 60);
        dist = Random.Range(1.5f, maxDistance);
        component_pos = Quaternion.Euler(0, angle, 0) * position_vec * dist;
        membrane.transform.position = arCamera.transform.position + new Vector3(component_pos.x, -0.3f, component_pos.z);
        membrane.name = "membrane";
        membrane.AddComponent<ARAnchor>();

        angle = Random.Range(-60, 60);
        dist = Random.Range(1.5f, maxDistance);
        component_pos = Quaternion.Euler(0, angle, 0) * position_vec * dist;
        tank.transform.position = arCamera.transform.position + new Vector3(component_pos.x, -0.3f, component_pos.z);
        tank.name = "tank";
        tank.AddComponent<ARAnchor>();

        well.SetActive(true);
        pipe.SetActive(false);
        membrane.SetActive(false);
        tank.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(start_search && !allCollected){
            // allCollected=true;
            if(!pipeCollected)
                d_pipe=Vector2.Distance(new Vector2(arCamera.transform.position.x,arCamera.transform.position.z),new Vector2(pipe.transform.position.x,pipe.transform.position.z));
            if(!membraneCollected)
                d_membrane=Vector2.Distance(new Vector2(arCamera.transform.position.x,arCamera.transform.position.z),new Vector2(membrane.transform.position.x,membrane.transform.position.z));
            if(!tankCollected)
                d_tank=Vector2.Distance(new Vector2(arCamera.transform.position.x,arCamera.transform.position.z),new Vector2(tank.transform.position.x,tank.transform.position.z));
            d_well=Vector2.Distance(new Vector2(arCamera.transform.position.x,arCamera.transform.position.z),new Vector2(transform.position.x, transform.position.z));

            if(d_well>maxDistance)
                distanceWarningPanel.SetActive(true);
            else distanceWarningPanel.SetActive(false);
            
            objectShown = false;
            if(d_pipe < showDistance && !pipeCollected){
                pipe.SetActive(true);
                // rotate signs above 3d object
                pipe.transform.GetChild(0).gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(arCamera.transform.forward.x, 0f, arCamera.transform.forward.z), Vector3.up);
                objectShown = true;
                ray = arCamera.ScreenPointToRay(Input.mousePosition);
                if(Input.GetMouseButtonDown(0)){
                    if(Physics.Raycast(ray, out hit)){
                        if(hit.collider.name == "pipe"){
                            pipeCollected=true;
                            pipe.SetActive(false);
                            pipe_image_findPanel_L.SetActive(true);
                            pipe_image_findPanel_P.SetActive(true);
                            order++;
                            pipe_order = order;
                            pipe_image_findPanel_L.transform.SetParent(image_anchors_findPanel_L[order - 1].transform, true);
                            pipe_image_findPanel_L.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                            pipe_image_findPanel_L.GetComponent<RectTransform>().offsetMax = Vector2.zero;

                            pipe_image_findPanel_P.transform.SetParent(image_anchors_findPanel_P[order - 1].transform, true);
                            pipe_image_findPanel_P.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                            pipe_image_findPanel_P.GetComponent<RectTransform>().offsetMax = Vector2.zero;
                        }
                    }
                }
            }else{
                pipe.SetActive(false);
            }

            if(d_membrane<showDistance && !membraneCollected){
                membrane.SetActive(true);
                membrane.transform.GetChild(0).gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(arCamera.transform.forward.x, 0f, arCamera.transform.forward.z), Vector3.up);
                objectShown = true;
                ray = arCamera.ScreenPointToRay(Input.mousePosition);
                if(Input.GetMouseButtonDown(0)){
                    if(Physics.Raycast(ray, out hit)){
                        if(hit.collider.name == "membrane"){
                            membraneCollected=true;
                            membrane.SetActive(false);
                            membrane_image_findPanel_L.SetActive(true);
                            membrane_image_findPanel_P.SetActive(true);
                            order++;
                            membrane_order = order;
                            membrane_image_findPanel_L.transform.SetParent(image_anchors_findPanel_L[order - 1].transform, true);
                            membrane_image_findPanel_L.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                            membrane_image_findPanel_L.GetComponent<RectTransform>().offsetMax = Vector2.zero;

                            membrane_image_findPanel_P.transform.SetParent(image_anchors_findPanel_P[order - 1].transform, true);
                            membrane_image_findPanel_P.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                            membrane_image_findPanel_P.GetComponent<RectTransform>().offsetMax = Vector2.zero;
                        }
                    }
                }
            }else{
                membrane.SetActive(false);
            }

            if(d_tank<showDistance && !tankCollected){
                tank.SetActive(true);
                tank.transform.GetChild(0).gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(arCamera.transform.forward.x, 0f, arCamera.transform.forward.z), Vector3.up);
                objectShown = true;
                ray = arCamera.ScreenPointToRay(Input.mousePosition);
                if(Input.GetMouseButtonDown(0)){
                    if(Physics.Raycast(ray, out hit)){
                        if(hit.collider.name == "tank"){
                            tankCollected=true;
                            tank.SetActive(false);
                            tank_image_findPanel_L.SetActive(true);
                            tank_image_findPanel_P.SetActive(true);
                            order++;
                            tank_order = order;
                            tank_image_findPanel_L.transform.SetParent(image_anchors_findPanel_L[order - 1].transform, true);
                            tank_image_findPanel_L.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                            tank_image_findPanel_L.GetComponent<RectTransform>().offsetMax = Vector2.zero;

                            tank_image_findPanel_P.transform.SetParent(image_anchors_findPanel_P[order - 1].transform, true);
                            tank_image_findPanel_P.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                            tank_image_findPanel_P.GetComponent<RectTransform>().offsetMax = Vector2.zero;
                        }
                    }
                }
            }else{
                tank.SetActive(false);
            }

            if(objectShown)
                tapOnObjectPanel.SetActive(true);
            else tapOnObjectPanel.SetActive(false);

            if(pipeCollected && membraneCollected && tankCollected){
                allCollected=true;
                gameController.GetComponent<gameController>().updateStatus(0, true, false);
                distanceWarningPanel.SetActive(false);
                findPanel.SetActive(false);
                tapOnObjectPanel.SetActive(false);
                languagePanel.SetActive(true);
                itemsFoundPanel.SetActive(true);
            }
        }
    }

    public void nextSite(){
        Destroy(well);
        Destroy(pipe);
        Destroy(membrane);
        Destroy(tank);
        arCamera.enabled=false;
        mapCamera.enabled=true;
        app.GetComponent<App>().map.SetActive(true);
        app.GetComponent<App>().mapInstructionPanel.SetActive(true);
        app.GetComponent<App>().mapInstructionTitle_L.gameObject.SetActive(true);
        app.GetComponent<App>().mapInstructionTitle_P.gameObject.SetActive(true);
        if(dropdown.value == 0){
            //english
            app.GetComponent<App>().mapInstructionTitle_L.text = "Congratulations on completing the water source challenge!";
            app.GetComponent<App>().mapInstructionTitle_P.text = app.GetComponent<App>().mapInstructionTitle_L.text;
            app.GetComponent<App>().mapInstructionText_L.text = "Use the map view to navigate your way to the to the pipe network (site 2).\nAt the site, find the sign with the following image:";
            app.GetComponent<App>().mapInstructionText_P.text = app.GetComponent<App>().mapInstructionText_L.text;
        }else{
            //dutch
            app.GetComponent<App>().mapInstructionTitle_L.text = "Gefeliciteerd met het voltooien van de opgave bij de waterbron!";
            app.GetComponent<App>().mapInstructionTitle_P.text = app.GetComponent<App>().mapInstructionTitle_L.text;
            app.GetComponent<App>().mapInstructionText_L.text = "Gebruik de kaart om je weg naar het leidingnetwerk (locatie 2) te vinden.\nOp de locatie vind je een bord met de volgende afbeelding:";
            app.GetComponent<App>().mapInstructionText_P.text = app.GetComponent<App>().mapInstructionText_L.text;
        }
        app.GetComponent<App>().markerImage_L.sprite = markerSprite;
        app.GetComponent<App>().markerImage_P.sprite = markerSprite;

        app.GetComponent<App>().help_button.gameObject.SetActive(true);
        app.GetComponent<App>().player.SetActive(true);
        app.GetComponent<App>().sitePathSpawner.GetComponent<SpawnOnMap>().currentSite = 1;
        app.GetComponent<App>().nextSite_index = 3;
        app.GetComponent<App>().siteOn = false;
        app.GetComponent<App>().sitePathSpawner.GetComponent<SpawnOnMap>().showSitePath();
        app.GetComponent<App>().back_button.gameObject.SetActive(true);
        app.GetComponent<App>().showMap_button.gameObject.SetActive(false);
        site2.SetActive(false);
        site2UI.SetActive(false);
    }
}
