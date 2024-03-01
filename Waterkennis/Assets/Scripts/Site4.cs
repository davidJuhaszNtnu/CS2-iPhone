using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mapbox.Examples;

public class Site4 : MonoBehaviour
{
    public GameObject wwtp_prefab, welcomePanel, welcomePanel2, statementsPanel, scoreUpdatePanel1, scoreUpdatePanel2, afterStatementsPanel,
    taskPanel, site4, site4UI, app, gameController;
    public Button true_button_L, false_button_L, next_button_L, true_button_P, false_button_P, next_button_P;
    public Camera arCamera, mapCamera;
    string[] statements, info_on_correct, info_on_false;
    string[] statements_dutch, info_on_correct_dutch, info_on_false_dutch;
    bool[] correct_answers;
    bool answered;
    int incorrentAnsweresCount;
    int statementCount;
    GameObject question_L, question_P, statementsPanel_L, statementsPanel_P, wwtp;
    TextMeshProUGUI answerText_L, answerText_P;

    bool animate;
    public GameObject tank_L, tank_P, droplet_L, droplet_P;
    float minLevel_P, minLevel_L, t, dt, oldLevel_P, newLevel_P, currentLevel_P, oldLevel_L, newLevel_L, currentLevel_L;
    public TextMeshProUGUI scoreText_L, scoreText_P, lostText_L, lostText_P;

    public Sprite markerSprite;
    public TMP_Dropdown dropdown;

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
    }

    void Update(){
        if(animate)
            animateWaterLevel();
    }

    public void startSite(){
        site4UI.GetComponent<Site4UI>().set_tank_level();
        wwtp = Instantiate(wwtp_prefab);
        wwtp.transform.SetParent(transform, true);
        wwtp.SetActive(true);
        Vector3 dir = arCamera.transform.forward;
        wwtp.transform.position = transform.position + Vector3.Normalize(new Vector3(dir.x,0f,dir.z))*0.5f + new Vector3(0f, 0f, 0f);

        welcomePanel.SetActive(true);
        welcomePanel2.SetActive(false);
        statementsPanel.SetActive(false);
        scoreUpdatePanel1.SetActive(false);
        statementsPanel_L = statementsPanel.transform.GetChild(0).gameObject;
        statementsPanel_P = statementsPanel.transform.GetChild(1).gameObject;
        afterStatementsPanel.SetActive(false);
        scoreUpdatePanel2.SetActive(false);
        taskPanel.SetActive(false);
        question_L = statementsPanel_L.transform.GetChild(0).gameObject;
        question_P = statementsPanel_P.transform.GetChild(0).gameObject;
        answerText_L = statementsPanel_L.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        answerText_P = statementsPanel_P.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        statementCount = 0;
        incorrentAnsweresCount = 0;

        statements = new string[6];
        statements[0]="Treated wastewater can be reused to make drinking water.";
        statements[1]="Treated wastewater can be reused for irrigation.";
        statements[2]="Wastewater contains energy that can be reclaimed.";
        statements[3]="Wastewater contains heat that can be recovered.";
        statements[4]="Wastewater contains high levels of precious metals (gold, lithium) that can be recovered.";
        statements[5]="Making drinking water produces waste, this waste has no value.";

        info_on_correct = new string[6];
        info_on_correct[0]="Correct, in the Netherlands, the law does not allow the reuse of treated wastewater to make drinking water.";
        info_on_correct[1]="Correct, treated wastewater can be used to water parks and for farming.";
        info_on_correct[2]="Correct, waste captured from the treatment of wastewater can be used to generate energy (production of biogas).";
        info_on_correct[3]="Correct, it is possible to recover heat from wastewater using specific technologies. The heat recovered can be used for heating your home.";
        info_on_correct[4]="Correct, wastewater contains low levels of precious metals.";
        info_on_correct[5]="Correct, some waste streams from the production of drinking water can be re-used (e.g., lime pellets removed during the treatment process are sold to fertiliser, steel and construction industries).";

        info_on_false = new string[6];
        info_on_false[0]="Incorrect, in the Netherlands, the law does not allow the reuse of treated wastewater to make drinking water.";
        info_on_false[1]="Incorrect, treated wastewater can be used to water parks and for farming.";
        info_on_false[2]="Incorrect, waste captured from the treatment of wastewater can be used to generate energy (production of biogas).";
        info_on_false[3]="Incorrect, it is possible to recover heat from wastewater using specific technologies. The heat recovered can be used for heating your home.";
        info_on_false[4]="Incorrect, wastewater contains low levels of precious materials.";
        info_on_false[5]="Incorrect, some waste streams from the production of drinking water can be re-used (e.g., lime pellets removed during the treatment process are sold to fertiliser, steel and construction industries).";

        statements_dutch = new string[6];
        statements_dutch[0]="Gezuiverd afvalwater kan worden hergebruikt om er drinkwater van te maken.";
        statements_dutch[1]="Gezuiverd afvalwater kan worden hergebruikt om planten mee te irrigeren.";
        statements_dutch[2]="In afvalwater zit energie die teruggewonnen kan worden.";
        statements_dutch[3]="In afvalwater zit warmte die teruggewonnen kan worden.";
        statements_dutch[4]="In afvalwater zit een hoog gehalte aan waardevolle metalen (bijvoorbeeld goud, lithium) die teruggewonnen kunnen worden.";
        statements_dutch[5]="Bij de productie van drinkwater ontstaat afval. Dit afval kan niet hergebruikt worden, en heeft dus geen waarde meer.";

        info_on_correct_dutch = new string[6];
        info_on_correct_dutch[0]="Juist, in Nederland is het volgens de wet verboden om gezuiverd afvalwater te gebruiken om drinkwater te maken.";
        info_on_correct_dutch[1]="Juist, gezuiverd afvalwater mag gebruikt worden om parken en landbouwgewassen te irrigeren.";
        info_on_correct_dutch[2]="Juist, afvalstoffen die ontstaan bij de zuivering van afvalwater kunnen worden gebruikt om energie te produceren (biogas). ";
        info_on_correct_dutch[3]="Juist, het is mogelijk om uit afvalwater warmte te winnen. Deze warmte kan bijvoorbeeld gebruikt worden om je huis te verwarmen.";
        info_on_correct_dutch[4]="Juist, afvalwater bevat maar lage gehaltes waardevolle metalen.";
        info_on_correct_dutch[5]="Juist, sommige afvalstoffen die ontstaan bij het maken van drinkwater kunnen hergebruikt worden (bijvoobeeld kalkkorrels die gevormd worden, kunnen als kunststof worden verkocht).";

        info_on_false_dutch = new string[6];
        info_on_false_dutch[0]="Onjuist, in Nederland is het volgens de wet verboden om gezuiverd afvalwater te gebruiken om drinkwater te maken.";
        info_on_false_dutch[1]="Onjuist, gezuiverd afvalwater mag gebruikt worden om parken en landbouwgewassen te irrigeren.";
        info_on_false_dutch[2]="Onjuist, afvalstoffen die ontstaan bij de zuivering van afvalwater kunnen worden gebruikt om energie te produceren (biogas). ";
        info_on_false_dutch[3]="Onjuist, het is mogelijk om uit afvalwater warmte te winnen. Deze warmte kan bijvoorbeeld gebruikt worden om je huis te verwarmen.";
        info_on_false_dutch[4]="Onjuist, afvalwater bevat maar lage gehaltes waardevolle metalen.";
        info_on_false_dutch[5]="Onjuist, sommige afvalstoffen die ontstaan bij het maken van drinkwater kunnen hergebruikt worden (bijvoobeeld kalkkorrels die gevormd worden, kunnen als kunststof worden verkocht).";

        correct_answers = new bool[6];
        correct_answers[0] = false;
        correct_answers[1] = true;
        correct_answers[2] = true;
        correct_answers[3] = true;
        correct_answers[4] = false;
        correct_answers[5] = false;

        question_L.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (statementCount + 1).ToString() + "/6";
        question_L.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = statements[statementCount];
        question_P.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (statementCount + 1).ToString() + "/6";
        question_P.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = statements[statementCount];
        next_button_L.gameObject.SetActive(false);
        true_button_L.gameObject.SetActive(true);
        false_button_L.gameObject.SetActive(true);
        answerText_L.gameObject.SetActive(false);
        next_button_P.gameObject.SetActive(false);
        true_button_P.gameObject.SetActive(true);
        false_button_P.gameObject.SetActive(true);
        answerText_P.gameObject.SetActive(false);

        animate = false;
        droplet_L.SetActive(false);
        droplet_P.SetActive(false);
    }

    public void ok_welcomePanel_bttn(){
        welcomePanel.SetActive(false);
        welcomePanel2.SetActive(true);
    }

    public void ok_welcomePanel2_bttn(){
        welcomePanel2.SetActive(false);
        statementsPanel.SetActive(true);
    }

    public void true_bttn(){
        answered = true;
        answerText_L.gameObject.SetActive(true);
        answerText_P.gameObject.SetActive(true);

        if(correct_answers[statementCount]){
            if(dropdown.value == 0){
                answerText_L.text = info_on_correct[statementCount];
                answerText_P.text = info_on_correct[statementCount];
            }else{
                answerText_L.text = info_on_correct_dutch[statementCount];
                answerText_P.text = info_on_correct_dutch[statementCount];
            }
        }else{
            incorrentAnsweresCount++;
            if(dropdown.value == 0){
                answerText_L.text = info_on_false[statementCount];
                answerText_P.text = info_on_false[statementCount];
            }else{
                answerText_L.text = info_on_false_dutch[statementCount];
                answerText_P.text = info_on_false_dutch[statementCount];
            }
        }

        true_button_L.gameObject.SetActive(false);
        false_button_L.gameObject.SetActive(false);
        next_button_L.gameObject.SetActive(true);

        true_button_P.gameObject.SetActive(false);
        false_button_P.gameObject.SetActive(false);
        next_button_P.gameObject.SetActive(true);
    }

    public void changeLanguage(){
        if(statementCount < 6){
            if(dropdown.value == 0){
                question_L.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = statements[statementCount];
                question_P.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = statements[statementCount];
                if(answered){
                    if(correct_answers[statementCount]){
                        answerText_L.text = info_on_correct[statementCount];
                        answerText_P.text = info_on_correct[statementCount];
                    }else{
                        answerText_L.text = info_on_false[statementCount];
                        answerText_P.text = info_on_false[statementCount];
                    }
                }else{
                    if(correct_answers[statementCount]){
                        answerText_L.text = info_on_false[statementCount];
                        answerText_P.text = info_on_false[statementCount];
                    }else{
                        answerText_L.text = info_on_correct[statementCount];
                        answerText_P.text = info_on_correct[statementCount];
                    }
                }
            }else{
                question_L.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = statements_dutch[statementCount];
                question_P.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = statements_dutch[statementCount];
                if(answered){
                    if(correct_answers[statementCount]){
                        answerText_L.text = info_on_correct_dutch[statementCount];
                        answerText_P.text = info_on_correct_dutch[statementCount];
                    }else{
                        answerText_L.text = info_on_false_dutch[statementCount];
                        answerText_P.text = info_on_false_dutch[statementCount];
                    }
                }else{
                    if(correct_answers[statementCount]){
                        answerText_L.text = info_on_false_dutch[statementCount];
                        answerText_P.text = info_on_false_dutch[statementCount];
                    }else{
                        answerText_L.text = info_on_correct_dutch[statementCount];
                        answerText_P.text = info_on_correct_dutch[statementCount];
                    }
                }
            }
        }else{
            if(incorrentAnsweresCount == 0){
                if(dropdown.value == 0){
                    lostText_L.text = "Congratulations! All your answers were correct.";
                    lostText_P.text = lostText_L.text;
                }else{
                    lostText_L.text = "Gefeliciteerd! Al je antwoorden waren juist.";
                    lostText_P.text = lostText_L.text;
                }
            }else{
                if(dropdown.value == 0){
                    lostText_L.text = "You lost " + (incorrentAnsweresCount * 5).ToString() + " litres of water.";
                    lostText_P.text = lostText_L.text;
                }else{
                    lostText_L.text = "Je verliest " + (incorrentAnsweresCount * 5).ToString() + " liter water.";
                    lostText_P.text = lostText_L.text;
                }
            }
            if(dropdown.value == 0){
                scoreText_L.text = "Your current score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liters.";
                scoreText_P.text = scoreText_L.text;
            }else{
                scoreText_L.text = "Je huidige score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liter.";
                scoreText_P.text = scoreText_L.text;
            }
        }
    }

    public void false_bttn(){
        answered = false;
        answerText_L.gameObject.SetActive(true);
        answerText_P.gameObject.SetActive(true);

        if(!correct_answers[statementCount]){
            if(dropdown.value == 0){
                answerText_L.text = info_on_correct[statementCount];
                answerText_P.text = info_on_correct[statementCount];
            }else{
                answerText_L.text = info_on_correct_dutch[statementCount];
                answerText_P.text = info_on_correct_dutch[statementCount];
            }
        }else{
            incorrentAnsweresCount++;
            if(dropdown.value == 0){
                answerText_L.text = info_on_false[statementCount];
                answerText_P.text = info_on_false[statementCount];
            }else{
                answerText_L.text = info_on_false_dutch[statementCount];
                answerText_P.text = info_on_false_dutch[statementCount];
            }
        }

        true_button_L.gameObject.SetActive(false);
        false_button_L.gameObject.SetActive(false);
        next_button_L.gameObject.SetActive(true);

        true_button_P.gameObject.SetActive(false);
        false_button_P.gameObject.SetActive(false);
        next_button_P.gameObject.SetActive(true);
    }

    public void next_bttn(){
        statementCount++;
        answerText_L.gameObject.SetActive(false);
        true_button_L.gameObject.SetActive(true);
        false_button_L.gameObject.SetActive(true);
        next_button_L.gameObject.SetActive(false);

        answerText_P.gameObject.SetActive(false);
        true_button_P.gameObject.SetActive(true);
        false_button_P.gameObject.SetActive(true);
        next_button_P.gameObject.SetActive(false);
        if(statementCount < 6){
            question_L.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (statementCount + 1).ToString() + "/6";
            if(dropdown.value == 0)
                question_L.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = statements[statementCount];
            else question_L.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = statements_dutch[statementCount];

            question_P.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (statementCount + 1).ToString() + "/6";
            if(dropdown.value == 0)
                question_P.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = statements[statementCount];
            else question_P.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = statements_dutch[statementCount];
        }else{
            // it was the last statement
            statementsPanel.SetActive(false);
            scoreUpdatePanel1.SetActive(true);
            if(incorrentAnsweresCount == 0){
                if(dropdown.value == 0){
                    lostText_L.text = "Congratulations! All your answers were correct.";
                    lostText_P.text = lostText_L.text;
                }else{
                    lostText_L.text = "Gefeliciteerd! Al je antwoorden waren juist.";
                    lostText_P.text = lostText_L.text;
                }
            }else{
                if(dropdown.value == 0){
                    lostText_L.text = "You lost " + (incorrentAnsweresCount * 5).ToString() + " litres of water.";
                    lostText_P.text = lostText_L.text;
                }else{
                    lostText_L.text = "Je verliest " + (incorrentAnsweresCount * 5).ToString() + " liter water.";
                    lostText_P.text = lostText_L.text;
                }
            }
            float oldScore = (float)gameController.GetComponent<gameController>().score;
            gameController.GetComponent<gameController>().score -= incorrentAnsweresCount * 5;
            gameController.GetComponent<gameController>().updateStatus(incorrentAnsweresCount * 5, false, false);
            setupAnimationWaterLevel((float)gameController.GetComponent<gameController>().score, oldScore);

            if(dropdown.value == 0){
                scoreText_L.text = "Your current score is\n" + gameController.GetComponent<gameController>().score.ToString() + " liters.";
                scoreText_P.text = scoreText_L.text;
            }else{
                scoreText_L.text = "Je huidige score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liter.";
                scoreText_P.text = scoreText_L.text;
            }
        }
    }

    private void setupAnimationWaterLevel(float newScore, float oldScore){
        oldLevel_P = -(minLevel_P-oldScore/(float)gameController.GetComponent<gameController>().maxScore*minLevel_P);
        newLevel_P = -(minLevel_P-newScore/(float)gameController.GetComponent<gameController>().maxScore*minLevel_P);
        oldLevel_L = -(minLevel_L-oldScore/(float)gameController.GetComponent<gameController>().maxScore*minLevel_L);
        newLevel_L = -(minLevel_L-newScore/(float)gameController.GetComponent<gameController>().maxScore*minLevel_L);
        t = 0f;
        dt = 0.01f;
        animate = true;
        droplet_L.SetActive(true);
        droplet_P.SetActive(true);
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

    public void ok_scoreUpdatePanel1_bttn(){
        scoreUpdatePanel1.SetActive(false);
        afterStatementsPanel.SetActive(true);
        //components gained
        gameController.GetComponent<gameController>().updateStatus(0, true, false);
    }

    public void ok_afterStatementsPanel_bttn(){
        afterStatementsPanel.SetActive(false);
        taskPanel.SetActive(true);
        string orientation;
        if(Screen.orientation == ScreenOrientation.Portrait)
            orientation = "portrait";
        else orientation = "landscape";
        site4UI.GetComponent<Site4UI>().setImages(1, 2, 3, orientation);
    }

    public void ok_scoreUpdatePanel2_bttn(){
        site4.SetActive(false);
        site4UI.SetActive(false);
        arCamera.enabled = false;
        mapCamera.enabled = true;
        app.GetComponent<App>().map.SetActive(true);
        app.GetComponent<App>().mapInstructionPanel.SetActive(true);
        app.GetComponent<App>().mapInstructionTitle_L.gameObject.SetActive(true);
        app.GetComponent<App>().mapInstructionTitle_P.gameObject.SetActive(true);
        if(dropdown.value == 0){
            //english
            app.GetComponent<App>().mapInstructionTitle_L.text = "Congratulations on completing the wastewater treatment plant challenges!";
            app.GetComponent<App>().mapInstructionTitle_P.text = app.GetComponent<App>().mapInstructionTitle_L.text;
            app.GetComponent<App>().mapInstructionText_L.text = "Use the map view to navigate your way to the to the environment (site 4).\nAt the site, find the sign with the following image:";
            app.GetComponent<App>().mapInstructionText_P.text = app.GetComponent<App>().mapInstructionText_L.text;
        }else{
            //dutch
            app.GetComponent<App>().mapInstructionTitle_L.text = "Gefeliciteerd met het voltooien van de opgaven bij de afvalwaterzuiveringsinstallatie!";
            app.GetComponent<App>().mapInstructionTitle_P.text = app.GetComponent<App>().mapInstructionTitle_L.text;
            app.GetComponent<App>().mapInstructionText_L.text = "Gebruik de kaart om je weg naar het milieu (locatie 4) te vinden.\nOp de locatie vind je een bord met de volgende afbeelding:";
            app.GetComponent<App>().mapInstructionText_P.text = app.GetComponent<App>().mapInstructionText_L.text;
        }
        app.GetComponent<App>().markerImage_L.sprite = markerSprite;
        app.GetComponent<App>().markerImage_P.sprite = markerSprite;

        app.GetComponent<App>().help_button.gameObject.SetActive(true);
        app.GetComponent<App>().player.SetActive(true);
        app.GetComponent<App>().sitePathSpawner.GetComponent<SpawnOnMap>().currentSite = 3;
        app.GetComponent<App>().nextSite_index = 5;
        app.GetComponent<App>().siteOn = false;
        app.GetComponent<App>().sitePathSpawner.GetComponent<SpawnOnMap>().showSitePath();
        app.GetComponent<App>().back_button.gameObject.SetActive(true);
        app.GetComponent<App>().showMap_button.gameObject.SetActive(false);
    }
}
