using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Site5 : MonoBehaviour
{
    public GameObject pond_prefab, welcomePanel, multichoicePanel, scoreUpdatePanel, infoPanel, thankYouPanel, infoPanel2, spendWaterPanel, 
    endPanel, gameController, site5UI;
    public Camera arCamera;

    public bool[] answered;
    bool[] correct_answer;

    public GameObject[] toggles_L;
    public GameObject[] toggles_P;

    TextMeshProUGUI score_text_L, score_text_P, title_L, title_P, infoText_L, infoText_P;
    public GameObject tank_L, tank_P, droplet_L, droplet_P;
    public TextMeshProUGUI waterAvailable_text_P, waterAvailable_text_L;

    bool animate;
    public bool correct;
    float minLevel_P, minLevel_L, t, dt, oldLevel_P, newLevel_P, currentLevel_P, oldLevel_L, newLevel_L, currentLevel_L;
    public int attempt;

    public TMP_Dropdown dropdown;

    GameObject pond;

    // Start is called before the first frame update
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
    }

    void Update(){
        if(animate)
            animateWaterLevel();
    }

    public void startSite(){
        site5UI.GetComponent<Site5UI>().set_tank_level();
        answered = new bool[4];
        correct_answer = new bool[4];

        attempt = 1;
        correct = true;
        for (int i = 0; i < answered.Length; i++)
            answered[i] = false;
        correct_answer[0] = true;
        correct_answer[1] = true;
        correct_answer[2] = true;
        correct_answer[3] = true;

        animate = false;        
        droplet_L.SetActive(false);
        droplet_P.SetActive(false);

        for (int i = 0; i < answered.Length; i++){
            toggles_L[i].GetComponent<Toggle>().isOn = false;
            toggles_P[i].GetComponent<Toggle>().isOn = false;
        }

        welcomePanel.SetActive(true);
        multichoicePanel.SetActive(false);
        scoreUpdatePanel.SetActive(false);
        infoPanel.SetActive(false);
        thankYouPanel.SetActive(false);
        infoPanel2.SetActive(false);
        spendWaterPanel.SetActive(false);
        endPanel.SetActive(false);
        pond = Instantiate(pond_prefab);
        pond.transform.SetParent(transform, true);
        pond.SetActive(true);
        Vector3 dir = arCamera.transform.forward;
        pond.transform.position = transform.position + Vector3.Normalize(new Vector3(dir.x,0f,dir.z))*0.5f + new Vector3(0f, 0f, 0f);
    }

    public void ok_welcomePanel_bttn(){
        welcomePanel.SetActive(false);
        multichoicePanel.SetActive(true);
    }

    public void ok_scoreUpdatePanel_bttn(){
        scoreUpdatePanel.SetActive(false);
        if(correct || attempt == 2)
            infoPanel.SetActive(true);
        else multichoicePanel.SetActive(true);
        attempt++;
    }

    public void ok_infoPanel_bttn(){
        infoPanel.SetActive(false);
        thankYouPanel.SetActive(true);
    }

    public void ok_thankYouPanel_bttn(){
        thankYouPanel.SetActive(false);
        if(dropdown.value == 0){
            infoPanel2.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Having gone through the various challenges, you were able to keep " +
            gameController.GetComponent<gameController>().score.ToString() + " litres of your total drinking water budget.";
            infoPanel2.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = infoPanel2.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        }else{
            infoPanel2.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Na het beantwoorden van alle vragen heb je nog " +
            gameController.GetComponent<gameController>().score.ToString() + " liter van je totale drinkwaterbudget over.";
            infoPanel2.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = infoPanel2.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        }
        infoPanel2.SetActive(true);
    }

    public void ok_infoPanel2_bttn(){
        infoPanel2.SetActive(false);
        if(dropdown.value == 0){
            spendWaterPanel.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "How would you spend your remaining daily drinking water budget of " +
            gameController.GetComponent<gameController>().score.ToString() + " litres?";
        }else{
            spendWaterPanel.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Hoe zou je het dagelijkse drinkwaterbudget van " +
            gameController.GetComponent<gameController>().score.ToString() + " liter dat je over hebt gehouden verdelen over dagelijkse activiteiten?";
        }
        spendWaterPanel.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = spendWaterPanel.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        updateTankText();
        site5UI.GetComponent<Site5UI>().setupAnimationWaterLevel((float)gameController.GetComponent<gameController>().score, (float)gameController.GetComponent<gameController>().score);
        site5UI.GetComponent<Site5UI>().updateActions();
        spendWaterPanel.SetActive(true);
    }

    public void updateTankText(){
        if(dropdown.value == 0){
            waterAvailable_text_L.text = "Water available: " + gameController.GetComponent<gameController>().score.ToString() +" litres";
            waterAvailable_text_P.text = waterAvailable_text_L.text;
        }else{
            waterAvailable_text_L.text = "Beschikbaar water: " + gameController.GetComponent<gameController>().score.ToString() +" liter.";
            waterAvailable_text_P.text = waterAvailable_text_L.text;
        }
    }

    public void ok_spendWaterPanel_bttn(){
        spendWaterPanel.SetActive(false);
        endPanel.SetActive(true);
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
                title_L.text = "Incorrect!";
                title_P.text = title_L.text;
                infoText_L.text = "You lost 5 liters of water. You have one more attempt.";
                infoText_P.text = infoText_L.text;
                score_text_L.text = "Your current score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liters";
                score_text_P.text = score_text_L.text;
            }else{
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
                    infoText_L.text = "The correct pollutants are: Plastic materials, Pesticides, Pharmaceutical and hormones, Bacteria.";
                    infoText_P.text = infoText_L.text;
                }else{
                    infoText_L.text = "De juiste verontreinigende stoffen zijn: Plastics, Pesticiden, Geneesmiddelen en hormonen, Bacteriën.";
                    infoText_P.text = infoText_L.text;
                }
            }
        }else{
            if(dropdown.value == 0){
                title_L.text = "Correct!";
                title_P.text = title_L.text;
                infoText_L.text = "The correct pollutants are: Plastic materials, Pesticides, Pharmaceutical and hormones, Bacteria.";
                infoText_P.text = infoText_L.text;
                score_text_L.text = "Your current score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liters";
                score_text_P.text = score_text_L.text;
            }else{
                title_L.text ="Juist!";
                title_P.text = title_L.text;
                infoText_L.text = "De juiste verontreinigende stoffen zijn: Plastics, Pesticiden, Geneesmiddelen en hormonen, Bacteriën.";
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
}
