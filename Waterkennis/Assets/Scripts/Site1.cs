using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using Mapbox.Examples;
using TMPro;

public class Site1 : MonoBehaviour
{
    public GameObject site1, site1UI, welcomePanel, welcomePanel2, multichoicePanel, scoreUpdatePanel, answerPanel, site2, site2UI, app, gameController;
    public Camera arCamera, mapCamera;
    public TMP_Dropdown dropdown;

    public Sprite markerSprite;

    // private GameObject aRSessionOrigin;

    void Start()
    {
        restart();

        // welcomePanel.SetActive(false);
        // scoreUpdatePanel.SetActive(true);
        // multichoiceCanvas.gameObject.transform.position = new Vector3(0f,0f,1f);
    }

    public void restart(){
        welcomePanel.SetActive(true);
        welcomePanel2.SetActive(false);
        multichoicePanel.SetActive(false);
        scoreUpdatePanel.SetActive(false);
        answerPanel.SetActive(false);

        for (int i = 0; i < site1UI.GetComponent<Site1UI>().answered.Length; i++)
            site1UI.GetComponent<Site1UI>().answered[i] = false;
    }

    public void nextSite(){
        site1.SetActive(false);
        site1UI.SetActive(false);
        arCamera.enabled = false;
        mapCamera.enabled = true;
        app.GetComponent<App>().map.SetActive(true);
        app.GetComponent<App>().mapInstructionPanel.SetActive(true);
        app.GetComponent<App>().mapInstructionIsOn = true;
        // app.GetComponent<App>().mapInstructionTitle_L.gameObject.SetActive(false);
        // app.GetComponent<App>().mapInstructionTitle_P.gameObject.SetActive(false);
        if(dropdown.value == 0){
            //english
            app.GetComponent<App>().mapInstructionTitle_L.text = "Navigate to the first site!";
            app.GetComponent<App>().mapInstructionTitle_P.text = app.GetComponent<App>().mapInstructionTitle_L.text;
            app.GetComponent<App>().mapInstructionText_L.text = "Use the map view to navigate your way to the to the source of the water (site 1).\nAt the site, find the sign with the following image:";
            app.GetComponent<App>().mapInstructionText_P.text = "Use the map view to navigate your way to the to the source of the water\n(site 1).\nAt the site, find the sign with the following image:";
        }else{
            //dutch
            app.GetComponent<App>().mapInstructionTitle_L.text = "Ga naar de eerste locatie.";
            app.GetComponent<App>().mapInstructionTitle_P.text = app.GetComponent<App>().mapInstructionTitle_L.text;
            app.GetComponent<App>().mapInstructionText_L.text = "Gebruik de kaart om je weg naar de waterbron (locatie 1) te vinden.\nOp de locatie vind je een bord met de volgende afbeelding:";
            app.GetComponent<App>().mapInstructionText_P.text = "Gebruik de kaart om je weg naar de waterbron (locatie 1) te vinden.\nOp de locatie vind je een bord met de volgende afbeelding:";
        }
        app.GetComponent<App>().markerImage_L.sprite = markerSprite;
        app.GetComponent<App>().markerImage_P.sprite = markerSprite;

        app.GetComponent<App>().help_button.gameObject.SetActive(true);
        app.GetComponent<App>().player.SetActive(true);
        if(gameController.GetComponent<gameController>().replaying)
            app.GetComponent<App>().sitePathSpawner.GetComponent<SpawnOnMap>().currentSite = 4;
        else app.GetComponent<App>().sitePathSpawner.GetComponent<SpawnOnMap>().currentSite = 0;
        app.GetComponent<App>().nextSite_index = 2;
        app.GetComponent<App>().siteOn = false;
        app.GetComponent<App>().sitePathSpawner.GetComponent<SpawnOnMap>().showSitePath();
        app.GetComponent<App>().back_button.gameObject.SetActive(true);
        app.GetComponent<App>().showMap_button.gameObject.SetActive(false);
    }
}
