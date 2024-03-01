using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Site1UI : MonoBehaviour
{
    public GameObject welcomePanel, welcomePanel2, multichoicePanel, scoreUpdatePanel, answerPanel, site1, gameController;
    public TMP_Dropdown dropdown;
    public bool[] answered;
    bool[] correct_answer;

    public GameObject[] toggles_L;
    public GameObject[] toggles_P;

    TextMeshProUGUI score_text_L, score_text_P, title_L, title_P, infoText_L, infoText_P;
    public GameObject tank_L, tank_P, droplet_L, droplet_P;

    bool animate;
    public bool correct;
    float minLevel_P, minLevel_L, t, dt, oldLevel_P, newLevel_P, currentLevel_P, oldLevel_L, newLevel_L, currentLevel_L;
    public int attempt;

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

        title_L = scoreUpdatePanel.transform.GetChild(0).GetChild(0).transform.GetComponent<TextMeshProUGUI>();
        infoText_L = scoreUpdatePanel.transform.GetChild(0).GetChild(1).transform.GetComponent<TextMeshProUGUI>();
        score_text_L = scoreUpdatePanel.transform.GetChild(0).GetChild(2).transform.GetComponent<TextMeshProUGUI>();
        title_P = scoreUpdatePanel.transform.GetChild(1).GetChild(0).transform.GetComponent<TextMeshProUGUI>();
        infoText_P = scoreUpdatePanel.transform.GetChild(1).GetChild(1).transform.GetComponent<TextMeshProUGUI>();
        score_text_P = scoreUpdatePanel.transform.GetChild(1).GetChild(2).transform.GetComponent<TextMeshProUGUI>();

        restart();
    }

    public void restart(){
        float aspectRatio = (float)Screen.width/(float)Screen.height;
        if(Screen.orientation == ScreenOrientation.Portrait){
            minLevel_P = tank_P.GetComponent<RectTransform>().rect.height * 0.95f;
            minLevel_L = tank_L.GetComponent<RectTransform>().rect.height * 0.95f * aspectRatio;
        }else{
            minLevel_L = tank_L.GetComponent<RectTransform>().rect.height * 0.95f;
            minLevel_P = tank_P.GetComponent<RectTransform>().rect.height * 0.95f * aspectRatio;
        }
        
        answered = new bool[5];
        correct_answer = new bool[5];
        
        attempt = 1;
        correct = true;
        for (int i = 0; i < answered.Length; i++)
            answered[i] = false;
        correct_answer[0] = false;
        correct_answer[1] = true;
        correct_answer[2] = false;
        correct_answer[3] = true;
        correct_answer[4] = false;

        for (int i = 0; i < answered.Length; i++){
            toggles_L[i].GetComponent<Toggle>().isOn = false;
            toggles_P[i].GetComponent<Toggle>().isOn = false;
        }

        animate = false;        
        droplet_L.SetActive(false);
        droplet_P.SetActive(false);
    }

    void Update(){
        if(animate)
            animateWaterLevel();
    }

    public void ok_welcomePanel_bttn(){
        welcomePanel.SetActive(false);
        welcomePanel2.SetActive(true);
    }

    public void ok_welcomePanel2_bttn(){
        welcomePanel2.SetActive(false);
        multichoicePanel.SetActive(true);
    }

    public void ok_multichoicePanel_bttn(){
        multichoicePanel.SetActive(false);
        correct = true;
        float oldScore = (float)gameController.GetComponent<gameController>().score;
        for (int i = 0; i < answered.Length; i++){
            if(answered[i] != correct_answer[i])
                correct = false;
        }
        if(!correct){
            gameController.GetComponent<gameController>().score -= 5;
            gameController.GetComponent<gameController>().updateStatus(5, false, false);

            if(dropdown.value == 0){
                //english
                title_L.text = "Incorrect!";
                title_P.text = title_L.text;
                infoText_L.text = "You lost 5 liters of water. You have one more attempt.";
                infoText_P.text = infoText_L.text;
                score_text_L.text = "Your current score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liters";
                score_text_P.text = score_text_L.text;
            }else{
                //dutch
                title_L.text = "Onjuist!";
                title_P.text = title_L.text;
                infoText_L.text = "Je hebt niet alle antwoorden goed en je verliest 5 liter water. Probeer het nog een keer.";
                infoText_P.text = infoText_L.text;
                score_text_L.text = "Je huidige score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liter.";
                score_text_P.text = score_text_L.text;
            }

            //update water level in the tank
            setupAnimationWaterLevel((float)gameController.GetComponent<gameController>().score, oldScore);

            if(attempt == 2){
                if(dropdown.value == 0){
                    //english
                    infoText_L.text = "In the Netherlands, the main sources of drinking water are surface water (water from rivers and lakes) and groundwater (water found underground).";
                    infoText_P.text = infoText_L.text;
                }else{
                    //dutch
                    infoText_L.text = "In Nederland zijn de belangrijkste bronnen voor drinkwater: oppervlaktewater (water uit rivieren en meren) en grondwater (water dat zich onder de grond bevindt).";
                    infoText_P.text = infoText_L.text;
                }
            }
        }else{
            if(dropdown.value == 0){
                //english
                title_L.text = "Correct!";
                title_P.text = title_L.text;
                infoText_L.text = "In the Netherlands, the main sources of drinking water are surface water (water from rivers and lakes) and groundwater (water found underground).";
                infoText_P.text = infoText_L.text;
                score_text_L.text = "Your current score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liters";
                score_text_P.text = score_text_L.text;
            }else{
                //dutch
                title_L.text = "Juist!";
                title_P.text = title_L.text;
                infoText_L.text = "In Nederland zijn de belangrijkste bronnen voor drinkwater: oppervlaktewater (water uit rivieren en meren) en grondwater (water dat zich onder de grond bevindt).";
                infoText_P.text = infoText_L.text;
                score_text_L.text = "Je huidige score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liter.";
                score_text_P.text = score_text_L.text;
            }
        }

        scoreUpdatePanel.SetActive(true);
    }

    private void setupAnimationWaterLevel(float newScore, float oldScore){
        oldLevel_P = -(minLevel_P-oldScore/(float)gameController.GetComponent<gameController>().maxScore*minLevel_P);
        newLevel_P = -(minLevel_P-newScore/(float)gameController.GetComponent<gameController>().maxScore*minLevel_P);
        oldLevel_L = -(minLevel_L-oldScore/(float)gameController.GetComponent<gameController>().maxScore*minLevel_L);
        newLevel_L = -(minLevel_L-newScore/(float)gameController.GetComponent<gameController>().maxScore*minLevel_L);
        t = 0f;
        dt = 0.01f;
        if(oldScore != newScore){
            animate = true;
            droplet_L.SetActive(true);
            droplet_P.SetActive(true);
        }else{
            tank_P.GetComponent<RectTransform>().offsetMax = new Vector2(0f, oldLevel_P);
            tank_P.GetComponent<RectTransform>().offsetMin = new Vector2(0f, oldLevel_P);
            tank_L.GetComponent<RectTransform>().offsetMax = new Vector2(0f, oldLevel_L);
            tank_L.GetComponent<RectTransform>().offsetMin = new Vector2(0f, oldLevel_L);
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
        }
    }

    public void ok_scoreUpdatePanel_bttn(){
        scoreUpdatePanel.SetActive(false);
        if(correct || attempt == 2)
            answerPanel.SetActive(true);
        else multichoicePanel.SetActive(true);
        attempt++;
    }

    public void ok_answerPanel_bttn(){
        site1.GetComponent<Site1>().nextSite();
    }

    public void toggle1(Toggle toggle){
        answered[0] = toggle.isOn;
        toggles_L[0].GetComponent<Toggle>().isOn = toggle.isOn;
        toggles_P[0].GetComponent<Toggle>().isOn = toggle.isOn;
    }

    public void toggle2(Toggle toggle){
        answered[1] = toggle.isOn;
        toggles_L[1].GetComponent<Toggle>().isOn = toggle.isOn;
        toggles_P[1].GetComponent<Toggle>().isOn = toggle.isOn;
    }

    public void toggle3(Toggle toggle){
        answered[2] = toggle.isOn;
        toggles_L[2].GetComponent<Toggle>().isOn = toggle.isOn;
        toggles_P[2].GetComponent<Toggle>().isOn = toggle.isOn;
    }

    public void toggle4(Toggle toggle){
        answered[3] = toggle.isOn;
        toggles_L[3].GetComponent<Toggle>().isOn = toggle.isOn;
        toggles_P[3].GetComponent<Toggle>().isOn = toggle.isOn;
    }

    public void toggle5(Toggle toggle){
        answered[4] = toggle.isOn;
        toggles_L[4].GetComponent<Toggle>().isOn = toggle.isOn;
        toggles_P[4].GetComponent<Toggle>().isOn = toggle.isOn;
    }
}
