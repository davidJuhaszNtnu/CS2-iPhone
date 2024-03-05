using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mapbox.Examples;

public class Site5UI : MonoBehaviour
{
    public GameObject markerHandler, site1, site1UI, site2, site2UI, site3UI, site4UI, site3, site5,
    app, panelLayoutHandler, gameController, welcomePanel, multichoicePanel;
    public GameObject[] toggles;

    public GameObject[] toggles_L;
    public GameObject[] toggles_P;

    public GameObject tank_L, tank_P, droplet_L, droplet_P, dropletIn_L, dropletIn_P;
    bool animate;
    float minLevel_P, minLevel_L, t, dt, oldLevel_P, newLevel_P, currentLevel_P, oldLevel_L, newLevel_L, currentLevel_L;

    float[] actionCosts;

    public TMP_Dropdown dropdown;
    public GameObject languageChanger;

    void Start()
    {
        float aspectRatio = (float)Screen.width/(float)Screen.height;
        if(Screen.orientation == ScreenOrientation.Portrait){
            minLevel_P = tank_P.GetComponent<RectTransform>().rect.height * 0.95f;
            minLevel_L = tank_L.GetComponent<RectTransform>().rect.height * 0.95f * aspectRatio;
        }else{
            minLevel_L = tank_L.GetComponent<RectTransform>().rect.height * 0.95f;
            minLevel_P = tank_P.GetComponent<RectTransform>().rect.height * 0.95f * aspectRatio;
        }

        // Debug.Log(tank_P.GetComponent<RectTransform>().rect.height);

        actionCosts = new float[9];
        actionCosts[0] = 50f;
        actionCosts[1] = 35f;
        actionCosts[2] = 15f;
        actionCosts[3] = 5f;
        actionCosts[4] = 5f;
        actionCosts[5] = 2f;
        actionCosts[6] = 1f;
        actionCosts[7] = 1f;
        actionCosts[8] = 6f;
    }

    public void set_tank_level(){
        float aspectRatio = (float)Screen.width/(float)Screen.height;
        if(Screen.orientation == ScreenOrientation.Portrait){
            minLevel_P = tank_P.GetComponent<RectTransform>().rect.height * 0.95f;
            minLevel_L = tank_L.GetComponent<RectTransform>().rect.height * 0.95f * aspectRatio;
        }else{
            minLevel_L = tank_L.GetComponent<RectTransform>().rect.height * 0.95f;
            minLevel_P = tank_P.GetComponent<RectTransform>().rect.height * 0.95f * aspectRatio;
        }
    }

    void Update(){
        if(animate)
            animateWaterLevel();
    }

    public void updateActions(){
        for (int i = 0; i < 9; i++){
            if(gameController.GetComponent<gameController>().score < actionCosts[i] && !toggles_L[i].transform.GetChild(0).GetComponent<Toggle>().isOn){
                Color c = toggles_L[i].GetComponent<TextMeshProUGUI>().color;
                c.a = 0.5f;
                toggles_L[i].GetComponent<TextMeshProUGUI>().color = c;
                toggles_L[i].transform.GetChild(0).GetComponent<Toggle>().interactable = false;

                c = toggles_P[i].GetComponent<TextMeshProUGUI>().color;
                c.a = 0.5f;
                toggles_P[i].GetComponent<TextMeshProUGUI>().color = c;
                toggles_P[i].transform.GetChild(0).GetComponent<Toggle>().interactable = false;
            }else{
                Color c = toggles_L[i].GetComponent<TextMeshProUGUI>().color;
                c.a = 1f;
                toggles_L[i].GetComponent<TextMeshProUGUI>().color = c;
                toggles_L[i].transform.GetChild(0).GetComponent<Toggle>().interactable = true;

                c = toggles_P[i].GetComponent<TextMeshProUGUI>().color;
                c.a = 1f;
                toggles_P[i].GetComponent<TextMeshProUGUI>().color = c;
                toggles_P[i].transform.GetChild(0).GetComponent<Toggle>().interactable = true;
            }
        }
    }

    void resolveToggle(bool isOn, GameObject toggle_L, GameObject toggle_P, float cost){
        toggle_L.transform.GetChild(0).GetComponent<Toggle>().isOn = isOn;
        toggle_P.transform.GetChild(0).GetComponent<Toggle>().isOn = isOn;

        float oldScore = 0f;
        float change = (float)gameController.GetComponent<gameController>().score;
        if(isOn){
            change -= cost/2f;
            oldScore = (float)gameController.GetComponent<gameController>().score + cost/2f;
        }else{
            change += cost/2f;
            oldScore = (float)gameController.GetComponent<gameController>().score - cost/2f;
        }
        gameController.GetComponent<gameController>().score = change;
        
        // Debug.Log(gameController.GetComponent<gameController>().score);
        setupAnimationWaterLevel((float)gameController.GetComponent<gameController>().score, oldScore);

        site5.GetComponent<Site5>().updateTankText();
        updateActions();
    }

    public void toggle1(Toggle toggle){
        resolveToggle(toggle.isOn, toggles_L[0], toggles_P[0], actionCosts[0]);    
    }

    public void toggle2(Toggle toggle){
        resolveToggle(toggle.isOn, toggles_L[1], toggles_P[1], actionCosts[1]);
    }

    public void toggle3(Toggle toggle){
        resolveToggle(toggle.isOn, toggles_L[2], toggles_P[2], actionCosts[2]);
    }

    public void toggle4(Toggle toggle){
        resolveToggle(toggle.isOn, toggles_L[3], toggles_P[3], actionCosts[3]);
    }

    public void toggle5(Toggle toggle){
        resolveToggle(toggle.isOn, toggles_L[4], toggles_P[4], actionCosts[4]);
    }

    public void toggle6(Toggle toggle){
        resolveToggle(toggle.isOn, toggles_L[5], toggles_P[5], actionCosts[5]);
    }

    public void toggle7(Toggle toggle){
        resolveToggle(toggle.isOn, toggles_L[6], toggles_P[6], actionCosts[6]);
    }

    public void toggle8(Toggle toggle){
        resolveToggle(toggle.isOn, toggles_L[7], toggles_P[7], actionCosts[7]);
    }

    public void toggle9(Toggle toggle){
        resolveToggle(toggle.isOn, toggles_L[8], toggles_P[8], actionCosts[8]);
    }

    public void setupAnimationWaterLevel(float newScore, float oldScore){
        oldLevel_P = -(minLevel_P-oldScore/(float)gameController.GetComponent<gameController>().maxScore*minLevel_P);
        newLevel_P = -(minLevel_P-newScore/(float)gameController.GetComponent<gameController>().maxScore*minLevel_P);
        oldLevel_L = -(minLevel_L-oldScore/(float)gameController.GetComponent<gameController>().maxScore*minLevel_L);
        newLevel_L = -(minLevel_L-newScore/(float)gameController.GetComponent<gameController>().maxScore*minLevel_L);
        t = 0f;
        dt = 0.01f;
        if(oldScore != newScore){
            animate = true;
            if(newScore < oldScore){
                droplet_L.SetActive(true);
                droplet_P.SetActive(true);
                dropletIn_L.SetActive(false);
                dropletIn_P.SetActive(false);
            }else{
                droplet_L.SetActive(false);
                droplet_P.SetActive(false);
                dropletIn_L.SetActive(true);
                dropletIn_P.SetActive(true);
            }
        }else{
            tank_P.GetComponent<RectTransform>().offsetMax = new Vector2(0f, oldLevel_P);
            tank_P.GetComponent<RectTransform>().offsetMin = new Vector2(0f, oldLevel_P);
            tank_L.GetComponent<RectTransform>().offsetMax = new Vector2(0f, oldLevel_L);
            tank_L.GetComponent<RectTransform>().offsetMin = new Vector2(0f, oldLevel_L);
            animate = false;
            droplet_L.SetActive(false);
            droplet_P.SetActive(false);
            dropletIn_L.SetActive(false);
            dropletIn_P.SetActive(false);
        }
    }

    private void animateWaterLevel(){
        if(t<1f){
            currentLevel_P = oldLevel_P + (newLevel_P - oldLevel_P)*t;
            currentLevel_L = oldLevel_L + (newLevel_L - oldLevel_L)*t;
            tank_P.GetComponent<RectTransform>().offsetMax = new Vector2(0f, currentLevel_P);
            tank_P.GetComponent<RectTransform>().offsetMin = new Vector2(0f, currentLevel_P);
            tank_L.GetComponent<RectTransform>().offsetMax = new Vector2(0f, currentLevel_L);
            tank_L.GetComponent<RectTransform>().offsetMin = new Vector2(0f, currentLevel_L);
            t += dt;
        }else{
            animate = false;
            droplet_L.SetActive(false);
            droplet_P.SetActive(false);
            dropletIn_L.SetActive(false);
            dropletIn_P.SetActive(false);
        }
    }

    public void clickOnLink(){
        if(dropdown.value == 0){
            Application.OpenURL("https://www.kwrwater.nl/en/projecten/water-kennis-an-immersive-media-experience/");
        }else Application.OpenURL("https://www.kwrwater.nl/projecten/water-kennis-een-meeslepende-media-ervaring/");
    }

    public void replay_bttn(){
        gameController.GetComponent<gameController>().restart();
        gameController.GetComponent<gameController>().replaying = true;
        markerHandler.GetComponent<MarkerHandler>().restart();
        site1.GetComponent<Site1>().restart();
        site1UI.GetComponent<Site1UI>().restart();
        site2.GetComponent<Site2>().restart();
        site2UI.GetComponent<Site2UI>().restart();
        site3UI.GetComponent<Site3UI>().restart();
        site4UI.GetComponent<Site4UI>().restart();
        panelLayoutHandler.GetComponent<PanelLayoutHandler>().restart();
        app.GetComponent<App>().restart();
        if(dropdown.value == 0){
            languageChanger.GetComponent<LanguageChanger>().changetoEnglish();
        }else languageChanger.GetComponent<LanguageChanger>().changetoDutch();
        welcomePanel.SetActive(true);
        multichoicePanel.SetActive(false);
        // toggles
        foreach(GameObject toggle in toggles)
            toggle.GetComponent<Toggle>().isOn = false;
    }

    public void exit_bttn(){
        Application.Quit();
    }
}
