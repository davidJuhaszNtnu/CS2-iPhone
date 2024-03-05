using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Examples;
using TMPro;

public class App : MonoBehaviour
{
    public GameObject site1, site1UI, site2, site2UI, site3,
    site3UI, site4, site4UI, site5, site5UI, map, player, mainPanel, statusPanel, sitePathSpawner, 
    PanelLayoutHandler, miniMapPanel, wrongSitePanel, mapInstructionPanel, gameController, languagePanel;
    public Camera arCamera, mapCamera;
    public GameObject[] taskPanels;
    public Button back_button, showMap_button, forwardButton, help_button;
    public bool mapInstructionIsOn;

    public TextMeshProUGUI mapInstructionText_L, mapInstructionText_P, mapInstructionTitle_L, mapInstructionTitle_P;
    public Image markerImage_L, markerImage_P;

    int currentPanel_index;
    public int nextSite_index;
    public bool siteOn;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        restart();

        // site1.SetActive(false);
        // site1UI.SetActive(false);
        // back_button.gameObject.SetActive(true);
        // showMap_button.gameObject.SetActive(false);
        // mapCamera.enabled=true;
        // arCamera.enabled=false;
        // map.SetActive(true);
        // player.SetActive(true);
        // back_button.gameObject.SetActive(true);
        // showMap_button.gameObject.SetActive(false);
        // sitePathSpawner.GetComponent<SpawnOnMap>().showSitePath();

        // site1.SetActive(false);
        // site1UI.SetActive(false);
        // site2.SetActive(true);
        // site2UI.SetActive(true);
        // nextSite_index = 2;
        // site2.GetComponent<Site2>().startSite();
        // gameController.GetComponent<gameController>().currentSite_index = 1;

        // site1.SetActive(false);
        // site1UI.SetActive(false);
        // site3.SetActive(true);
        // site3UI.SetActive(true);
        // site3.GetComponent<Site3>().startSite();
        // nextSite_index = 3;
        // gameController.GetComponent<gameController>().currentSite_index = 2;

        // site1.SetActive(false);
        // site1UI.SetActive(false);
        // site4.SetActive(true);
        // site4UI.SetActive(true);
        // site4.GetComponent<Site4>().startSite();
        // nextSite_index = 4;
        // gameController.GetComponent<gameController>().currentSite_index = 3;

        // site1.SetActive(false);
        // site1UI.SetActive(false);
        // site5.SetActive(true);
        // site5UI.SetActive(true);
        // site5.GetComponent<Site5>().startSite();
        // nextSite_index = 5;
        // gameController.GetComponent<gameController>().currentSite_index = 4;
        // sitePathSpawner.GetComponent<SpawnOnMap>().currentSite = 3;
    }



    public void restart(){
        siteOn = true;
        nextSite_index = 1;
        gameController.GetComponent<gameController>().currentSite_index = 0;
        arCamera.enabled = true;
        mapCamera.enabled = false;
        map.SetActive(false);
        player.SetActive(false);
        back_button.gameObject.SetActive(false);
        showMap_button.gameObject.SetActive(false);
        forwardButton.gameObject.SetActive(false);
        help_button.gameObject.SetActive(false);
        mainPanel.SetActive(true);
        languagePanel.SetActive(true);
        statusPanel.SetActive(false);
        mapInstructionPanel.SetActive(false);
        site1.SetActive(true);
        site1UI.SetActive(true);
        site2.SetActive(false);
        site2UI.SetActive(false);
        site3.SetActive(false);
        site3UI.SetActive(false);
        site4.SetActive(false);
        site4UI.SetActive(false);
        site5.SetActive(false);
        site5UI.SetActive(false);
    }

    public void back_bttn(){
        arCamera.enabled=true;
        mapCamera.enabled=false;
        map.SetActive(false);
        player.SetActive(false);
        sitePathSpawner.GetComponent<SpawnOnMap>().hideSitePath();
        back_button.gameObject.SetActive(false);
        showMap_button.gameObject.SetActive(true);
    }

    public void showMap_bttn(){
        arCamera.enabled=false;
        mapCamera.enabled=true;
        map.SetActive(true);
        player.SetActive(true);
        sitePathSpawner.GetComponent<SpawnOnMap>().showSitePath();
        back_button.gameObject.SetActive(true);
        showMap_button.gameObject.SetActive(false);
    }

    public void status_bttn(){
        if(!statusPanel.activeSelf){
            currentPanel_index = -1;
            for (int i = 1; i < PanelLayoutHandler.GetComponent<PanelLayoutHandler>().panels.Length; i++){
                // i=16 is the distance warning panel at site 2
                // i=23 is the minimap panel at site 3
                if(i != 16 && i != 23 && PanelLayoutHandler.GetComponent<PanelLayoutHandler>().panels[i].activeSelf){
                    currentPanel_index = i;
                    PanelLayoutHandler.GetComponent<PanelLayoutHandler>().panels[i].SetActive(false);
                    // break;
                }
            }
            if(site3.GetComponent<Site3>().mazeInteractionOn)
                miniMapPanel.SetActive(false);
            if(mapInstructionIsOn)
                currentPanel_index = 2;
            Debug.Log(currentPanel_index);
            statusPanel.SetActive(true);
        }else{
            if(mapInstructionIsOn)
                currentPanel_index = 2;
            ok_statusPanel_bbtn();
        }
    }

    public void help_bttn(){
        if(mapInstructionPanel.activeSelf){
            mapInstructionPanel.SetActive(false);
            mapInstructionIsOn = false;
        }else{
            mapInstructionPanel.SetActive(true);
            mapInstructionIsOn = true;
        }
    }

    public void ok_statusPanel_bbtn(){
        if(site3.GetComponent<Site3>().mazeInteractionOn)
            miniMapPanel.SetActive(true);
        statusPanel.SetActive(false);
        if(currentPanel_index > 0)
            PanelLayoutHandler.GetComponent<PanelLayoutHandler>().panels[currentPanel_index].SetActive(true);
        // if(currentPanel_index == 2 && )
    }

    public void ok_mapInstructionPanel_bttn(){
        mapInstructionPanel.SetActive(false);
        mapInstructionIsOn = false;
    }

    public void ok_wrongSitePanel_bttn(){
        wrongSitePanel.SetActive(false);
    }

    public void exit_bttn(){
        Application.Quit();
    }

     public void privacy_policy_bttn(){
        Application.OpenURL("https://i.ntnu.no/wiki/-/wiki/English/NTNU+-+privacy+policy#:~:text=All%20processing%20at%20NTNU%20must,%2C%20innovation%2C%20dissemination%20and%20administration.");
    }
}
