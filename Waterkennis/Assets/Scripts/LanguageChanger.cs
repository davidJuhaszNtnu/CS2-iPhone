using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageChanger : MonoBehaviour
{
    public GameObject gameController, app, site1, site1UI, site2, site2UI, site3UI, site3, site4, site4UI, site5;
    int currentSite_index;
    //wrong site panel
    public TextMeshProUGUI _L_wrongSitePanel;
    public TextMeshProUGUI _P_wrongSitePanel;
    //map instruction panel
    public TextMeshProUGUI _L_mapInstructionPanel1, _L_mapInstructionPanel2, _L_mapInstructionPanel3;
    public TextMeshProUGUI _P_mapInstructionPanel1, _P_mapInstructionPanel2, _P_mapInstructionPanel3;

    //--------------site1---------------------------------
    //welcome panel 1
    public TextMeshProUGUI _L_site1_welcomePanel11, _L_site1_welcomePanel12, _L_site1_welcomePanel13;
    public TextMeshProUGUI _P_site1_welcomePanel11, _P_site1_welcomePanel12, _P_site1_welcomePanel13;
    //welcome panel 2
    public TextMeshProUGUI _L_site1_welcomePanel21, _L_site1_welcomePanel22, _L_site1_welcomePanel23;
    public TextMeshProUGUI _P_site1_welcomePanel21, _P_site1_welcomePanel22, _P_site1_welcomePanel23;
    // multichoice panel
    public TextMeshProUGUI _L_site1_multichoicePanel1, _L_site1_multichoicePanel2, _L_site1_multichoicePanel3, _L_site1_multichoicePanel4, _L_site1_multichoicePanel5, _L_site1_multichoicePanel6;
    public TextMeshProUGUI _P_site1_multichoicePanel1, _P_site1_multichoicePanel2, _P_site1_multichoicePanel3, _P_site1_multichoicePanel4, _P_site1_multichoicePanel5, _P_site1_multichoicePanel6;
    //score update panel
    public TextMeshProUGUI _L_site1_statusUpdatePanel1, _L_site1_statusUpdatePanel2, _L_site1_statusUpdatePanel3;
    public TextMeshProUGUI _P_site1_statusUpdatePanel1, _P_site1_statusUpdatePanel2, _P_site1_statusUpdatePanel3;
    //answer panel
    public TextMeshProUGUI _L_site1_answerPanel1, _L_site1_answerPanel2, _L_site1_answerPanel3, _L_site1_answerPanel4;
    public TextMeshProUGUI _P_site1_answerPanel1, _P_site1_answerPanel2, _P_site1_answerPanel3, _P_site1_answerPanel4;

    //------------------------site2------------------------------
    //welcome panel
    public TextMeshProUGUI _L_site2_welcomePanel1, _L_site2_welcomePanel2;
    public TextMeshProUGUI _P_site2_welcomePanel1, _P_site2_welcomePanel2;
    //find panel
    public TextMeshProUGUI _L_site2_findPanel1, _L_site2_findPanel2, _L_site2_findPanel3, _L_site2_findPanel4;
    public TextMeshProUGUI _P_site2_findPanel1, _P_site2_findPanel2, _P_site2_findPanel3, _P_site2_findPanel4;
    //object labels
    public TextMeshProUGUI pipe_text, memmbrane_text, tank_text;
    //distance warning panel
    public TextMeshProUGUI _L_site2_distanceWarningPanel;
    public TextMeshProUGUI _P_site2_distanceWarningPanel;
    //tap on object panel
    public TextMeshProUGUI _L_site2_tapOnObjectPanel;
    public TextMeshProUGUI _P_site2_tapOnObjectPanel;
    //items found panel
    public TextMeshProUGUI _L_site2_itemsFoundPanel1, _L_site2_itemsFoundPanel2;
    public TextMeshProUGUI _P_site2_itemsFoundPanel1, _P_site2_itemsFoundPanel2;
    //task panel
    public TextMeshProUGUI _L_site2_taskPanel1, _L_site2_taskPanel2, _L_site2_taskPanel3, _L_site2_taskPanel4;
    public TextMeshProUGUI _P_site2_taskPanel1, _P_site2_taskPanel2, _P_site2_taskPanel3, _P_site2_taskPanel4;
    //task completed panel
    public TextMeshProUGUI _L_site2_taskCompletedPanel1, _L_site2_taskCompletedPanel2, _L_site2_taskCompletedPanel3, _L_site2_taskCompletedPanel4;
    public TextMeshProUGUI _P_site2_taskCompletedPanel1, _P_site2_taskCompletedPanel2, _P_site2_taskCompletedPanel3, _P_site2_taskCompletedPanel4;

    //---------------------------site3-----------------------------------
    //welcome panel
    public TextMeshProUGUI _L_site3_welcomePanel1, _L_site3_welcomePanel2;
    public TextMeshProUGUI _P_site3_welcomePanel1, _P_site3_welcomePanel2;
    //distance warning panel
    public TextMeshProUGUI _L_site3_distanceWarningPanel;
    public TextMeshProUGUI _P_site3_distanceWarningPanel;
    //tap on object panel
    public TextMeshProUGUI _L_site3_tapOnObjectPanel;
    public TextMeshProUGUI _P_site3_tapOnObjectPanel;
    //info bubble panel
    public TextMeshProUGUI _L_site3_infoBubblePanel1, _L_site3_infoBubblePanel2, _L_site3_infoBubblePanel3;
    public TextMeshProUGUI _P_site3_infoBubblePanel1, _P_site3_infoBubblePanel2, _P_site3_infoBubblePanel3;
    //info bubble world
    public TextMeshProUGUI _site3_infoBubbleWorldPanel1, _site3_infoBubbleWorldPanel2, _site3_infoBubbleWorldPanel3, _site3_infoBubbleWorldPanel4;
    //task panel
    public TextMeshProUGUI _L_site3_taskPanel1, _L_site3_taskPanel2, _L_site3_taskPanel3, _L_site3_taskPanel4;
    public TextMeshProUGUI _P_site3_taskPanel1, _P_site3_taskPanel2, _P_site3_taskPanel3, _P_site3_taskPanel4;
    //task completed panel
    public TextMeshProUGUI _L_site3_taskCompletedPanel1, _L_site3_taskCompletedPanel2, _L_site3_taskCompletedPanel3, _L_site3_taskCompletedPanel4;
    public TextMeshProUGUI _P_site3_taskCompletedPanel1, _P_site3_taskCompletedPanel2, _P_site3_taskCompletedPanel3, _P_site3_taskCompletedPanel4;
    //warning panel
    public TextMeshProUGUI _L_site3_warningPanel1, _L_site3_warningPanel2;
    public TextMeshProUGUI _P_site3_warningPanel1, _P_site3_warningPanel2;
    //maze panel
    public TextMeshProUGUI _L_site3_mazePanel;
    public TextMeshProUGUI _P_site3_mazePanel;
    //found broken pipe panel
    public TextMeshProUGUI _L_site3_foundBrokenPipePanel1, _L_site3_foundBrokenPipePanel2;
    public TextMeshProUGUI _P_site3_foundBrokenPipePanel1, _P_site3_foundBrokenPipePanel2;
    //pipe opened panel
    public TextMeshProUGUI _L_site3_pipeOpenedPanel1, _L_site3_pipeOpenedPanel2;
    public TextMeshProUGUI _P_site3_pipeOpenedPanel1, _P_site3_pipeOpenedPanel2;
    //info to multichoice panel 1
    public TextMeshProUGUI _L_site3_infoToMultichoicePanel11, _L_site3_infoToMultichoicePanel12, _L_site3_infoToMultichoicePanel13, _L_site3_infoToMultichoicePanel14,
    _L_site3_infoToMultichoicePanel15, _L_site3_infoToMultichoicePanel16, _L_site3_infoToMultichoicePanel17, _L_site3_infoToMultichoicePanel18, _L_site3_infoToMultichoicePanel19;
    public TextMeshProUGUI _P_site3_infoToMultichoicePanel11, _P_site3_infoToMultichoicePanel12, _P_site3_infoToMultichoicePanel13, _P_site3_infoToMultichoicePanel14,
    _P_site3_infoToMultichoicePanel15, _P_site3_infoToMultichoicePanel16, _P_site3_infoToMultichoicePanel17, _P_site3_infoToMultichoicePanel18, _P_site3_infoToMultichoicePanel19;
    //info between panel
    public TextMeshProUGUI _L_site3_infoBetweenPanel;
    public TextMeshProUGUI _P_site3_infoBetweenPanel;
    //info to multichoice panel 2
    public TextMeshProUGUI _L_site3_infoToMultichoicePanel21, _L_site3_infoToMultichoicePanel22, _L_site3_infoToMultichoicePanel23, _L_site3_infoToMultichoicePanel24,
    _L_site3_infoToMultichoicePanel25, _L_site3_infoToMultichoicePanel26, _L_site3_infoToMultichoicePanel27;
    public TextMeshProUGUI _P_site3_infoToMultichoicePanel21, _P_site3_infoToMultichoicePanel22, _P_site3_infoToMultichoicePanel23, _P_site3_infoToMultichoicePanel24,
    _P_site3_infoToMultichoicePanel25, _P_site3_infoToMultichoicePanel26, _P_site3_infoToMultichoicePanel27;
    //multichoice panel 1
    public TextMeshProUGUI _L_site3_multichoicePanel11, _L_site3_multichoicePanel12, _L_site3_multichoicePanel13, _L_site3_multichoicePanel14, _L_site3_multichoicePanel15,
    _L_site3_multichoicePanel16;
    public TextMeshProUGUI _P_site3_multichoicePanel11, _P_site3_multichoicePanel12, _P_site3_multichoicePanel13, _P_site3_multichoicePanel14, _P_site3_multichoicePanel15,
    _P_site3_multichoicePanel16;
    //score update panel 1
    public TextMeshProUGUI _L_site3_scoreUpdatePanel11, _L_site3_scoreUpdatePanel12, _L_site3_scoreUpdatePanel13;
    public TextMeshProUGUI _P_site3_scoreUpdatePanel11, _P_site3_scoreUpdatePanel12, _P_site3_scoreUpdatePanel13;
    //multichoice panel 2
    public TextMeshProUGUI _L_site3_multichoicePanel21, _L_site3_multichoicePanel22, _L_site3_multichoicePanel23, _L_site3_multichoicePanel24, _L_site3_multichoicePanel25;
    public TextMeshProUGUI _P_site3_multichoicePanel21, _P_site3_multichoicePanel22, _P_site3_multichoicePanel23, _P_site3_multichoicePanel24, _P_site3_multichoicePanel25;
    //score update panel 2
    public TextMeshProUGUI _L_site3_scoreUpdatePanel21, _L_site3_scoreUpdatePanel22, _L_site3_scoreUpdatePanel23;
    public TextMeshProUGUI _P_site3_scoreUpdatePanel21, _P_site3_scoreUpdatePanel22, _P_site3_scoreUpdatePanel23;

    //---------------------------site4-----------------------------------
    //welcome panel 1
    public TextMeshProUGUI _L_site4_welcomePanel11, _L_site4_welcomePanel12;
    public TextMeshProUGUI _P_site4_welcomePanel11, _P_site4_welcomePanel12;
    //welcome panel 2
    public TextMeshProUGUI _L_site4_welcomePanel21, _L_site4_welcomePanel22;
    public TextMeshProUGUI _P_site4_welcomePanel21, _P_site4_welcomePanel22;
    //after statements panel
    public TextMeshProUGUI _L_site4_afterStatementsPanel1, _L_site4_afterStatementsPanel2, _L_site4_afterStatementsPanel3, _L_site4_afterStatementsPanel4;
    public TextMeshProUGUI _P_site4_afterStatementsPanel1, _P_site4_afterStatementsPanel2, _P_site4_afterStatementsPanel3, _P_site4_afterStatementsPanel4;
    //task panel
    public TextMeshProUGUI _L_site4_taskPanel1, _L_site4_taskPanel2, _L_site4_taskPanel3, _L_site4_taskPanel4;
    public TextMeshProUGUI _P_site4_taskPanel1, _P_site4_taskPanel2, _P_site4_taskPanel3, _P_site4_taskPanel4;
    //score update panel
    public TextMeshProUGUI _L_site4_scoreUpdatePanel1, _L_site4_scoreUpdatePanel2, _L_site4_scoreUpdatePanel3, _L_site4_scoreUpdatePanel4;
    public TextMeshProUGUI _P_site4_scoreUpdatePanel1, _P_site4_scoreUpdatePanel2, _P_site4_scoreUpdatePanel3, _P_site4_scoreUpdatePanel4;

    //------------------------site5------------------------------
    //welcome panel
    public TextMeshProUGUI _L_site5_welcomePanel1, _L_site5_welcomePanel2;
    public TextMeshProUGUI _P_site5_welcomePanel1, _P_site5_welcomePanel2;
    // multichoice panel
    public TextMeshProUGUI _L_site5_multichoicePanel1, _L_site5_multichoicePanel2, _L_site5_multichoicePanel3, _L_site5_multichoicePanel4, _L_site5_multichoicePanel5;
    public TextMeshProUGUI _P_site5_multichoicePanel1, _P_site5_multichoicePanel2, _P_site5_multichoicePanel3, _P_site5_multichoicePanel4, _P_site5_multichoicePanel5;
    //score update panel
    public TextMeshProUGUI _L_site5_scoreUpdatePanel1, _L_site5_scoreUpdatePanel2, _L_site5_scoreUpdatePanel3;
    public TextMeshProUGUI _P_site5_scoreUpdatePanel1, _P_site5_scoreUpdatePanel2, _P_site5_scoreUpdatePanel3;
    //info panel 1
    public TextMeshProUGUI _L_site5_infoPanel1;
    public TextMeshProUGUI _P_site5_infoPanel1;
    //thank you panel
    public TextMeshProUGUI _L_site5_thankYouPanel1, _L_site5_thankYouPanel2;
    public TextMeshProUGUI _P_site5_thankYouPanel1, _P_site5_thankYouPanel2;
    //info panel 2
    public TextMeshProUGUI _L_site5_infoPanel21, _L_site5_infoPanel22;
    public TextMeshProUGUI _P_site5_infoPanel21, _P_site5_infoPanel22;
    //spend water panel
    public TextMeshProUGUI _L_site5_spendWaterPanel1, _L_site5_spendWaterPanel2, _L_site5_spendWaterPanel3, _L_site5_spendWaterPanel4, _L_site5_spendWaterPanel5,
    _L_site5_spendWaterPanel6, _L_site5_spendWaterPanel7, _L_site5_spendWaterPanel8, _L_site5_spendWaterPanel9, _L_site5_spendWaterPanel10;
    public TextMeshProUGUI _P_site5_spendWaterPanel1, _P_site5_spendWaterPanel2, _P_site5_spendWaterPanel3, _P_site5_spendWaterPanel4, _P_site5_spendWaterPanel5,
    _P_site5_spendWaterPanel6, _P_site5_spendWaterPanel7, _P_site5_spendWaterPanel8, _P_site5_spendWaterPanel9, _P_site5_spendWaterPanel10;
    //end panel
    public TextMeshProUGUI _L_site5_endPanel1, _L_site5_endPanel2, _L_site5_endPanel3;
    public TextMeshProUGUI _P_site5_endPanel1, _P_site5_endPanel2, _P_site5_endPanel3;

    public void changeLanguage(int index){
        if(index == 0){
            changetoEnglish();
        }else{
            changetoDutch();
        }
    }

    public void changetoDutch(){
        currentSite_index = app.GetComponent<App>().nextSite_index - 1;
        //status panel
        gameController.GetComponent<gameController>().updateStatus(0, false, true);
        //wrong site panel
        _L_wrongSitePanel.text = "Je hebt geen toegang tot deze locatie!";
        _P_wrongSitePanel.text = _L_wrongSitePanel.text;
        //map instruction panel
        switch(currentSite_index){
            case 1:
                _L_mapInstructionPanel1.text = "Ga naar de eerste locatie.";
                _P_mapInstructionPanel1.text = _L_mapInstructionPanel1.text;
                _L_mapInstructionPanel2.text = "Gebruik de kaart om je weg naar de waterbron (locatie 1) te vinden.\nOp de locatie vind je een bord met de volgende afbeelding:";
                _P_mapInstructionPanel2.text = "Gebruik de kaart om je weg naar de waterbron (locatie 1) te vinden.\nOp de locatie vind je een bord met de volgende afbeelding:";
                break;
            case 2:
                _L_mapInstructionPanel1.text = "Gefeliciteerd met het voltooien van de opgave bij de waterbron!";
                _P_mapInstructionPanel1.text = _L_mapInstructionPanel1.text;
                _L_mapInstructionPanel2.text = "Gebruik de kaart om je weg naar het leidingnetwerk (locatie 2) te vinden.\nOp de locatie vind je een bord met de volgende afbeelding:";
                _P_mapInstructionPanel2.text = "Gebruik de kaart om je weg naar het leidingnetwerk (locatie 2) te vinden.\nOp de locatie vind je een bord met de volgende afbeelding:";
                break;
            case 3:
                _L_mapInstructionPanel1.text = "Gefeliciteerd met het voltooien van de opgaven bij het leidingnetwerk!";
                _P_mapInstructionPanel1.text = _L_mapInstructionPanel1.text;
                _L_mapInstructionPanel2.text = "Gebruik de kaart om je weg naar de afvalwaterzuiveringsinstallatie (locatie 3) te vinden.\nOp de locatie vind je een bord met de volgende afbeelding:";
                _P_mapInstructionPanel2.text = "Gebruik de kaart om je weg naar de afvalwaterzuiveringsinstallatie (locatie 3) te vinden.\nOp de locatie vind je een bord met de volgende afbeelding:";
                break;
            case 4:
                _L_mapInstructionPanel1.text = "Gefeliciteerd met het voltooien van de opgaven bij de afvalwaterzuiveringsinstallatie!";
                _P_mapInstructionPanel1.text = _L_mapInstructionPanel1.text;
                _L_mapInstructionPanel2.text = "Gebruik de kaart om je weg naar het milieu (locatie 4) te vinden.\nOp de locatie vind je een bord met de volgende afbeelding:";
                _P_mapInstructionPanel2.text = "Gebruik de kaart om je weg naar het milieu (locatie 4) te vinden.\nOp de locatie vind je een bord met de volgende afbeelding:";
                break;
        }
        _L_mapInstructionPanel3.text = "Scan de afbeelding met de camera van je device (telefoon, tablet) door in het camerabeeld op de 3D-afbeelding van de waterbron te klikken. Druk op het camera-icoon hieronder om de camera te activeren.";
        _P_mapInstructionPanel3.text = _L_mapInstructionPanel3.text;
        
        //---------------------site1--------------------------------------
        if(site1.activeSelf){
            //welcome panel 1
            _L_site1_welcomePanel11.text = "Welkom bij Water-kennis, een immersive media-ervaring!";
            _P_site1_welcomePanel11.text = _L_site1_welcomePanel11.text;
            _L_site1_welcomePanel12.text = "Je draait je kraan open, je doucht of spoelt je toilet door en er stroomt schoon water.\n\nMaar waar komt dit water vandaan? Het hebben van genoeg schoon water is een wereldwijd een probleem geworden. Bij KWR werken we aan het vinden van de oplossingen die er voor zorgen dat we nu en in de toekomst voldoende schoon water hebben.\n\nIn deze immersive media ervaring kom je, via een aantal challenges, meer te weten over het watersysteem dat zorgt voor het schone water bij jou thuis.";
            _P_site1_welcomePanel12.text = _L_site1_welcomePanel12.text;
            _L_site1_welcomePanel13.text = "Deze app is ontwikkeld in het ULTIMATE project, dat financiële ondersteuning ontvangt uit de European Unie’s Horizon 2020 research and innovation programma onder contract no. 869318. Meer op ultimatewater.eu";
            _P_site1_welcomePanel13.text = _L_site1_welcomePanel13.text;
            //welcome panel 2
            _L_site1_welcomePanel21.text = "Welkom bij Water-kennis, een immersive media-ervaring!";
            _P_site1_welcomePanel21.text = _L_site1_welcomePanel21.text;
            _L_site1_welcomePanel22.text = "De regels zijn eenvoudig. Je begint met een drinkwaterbudget van 120 liter (het gemiddelde dagelijkse waterverbruik van Nederlanders). In het spel krijg je een paar challenges. Als je deze goed doorstaat houdt je je waterbudget. Maak je een fout – dan verlies je een deel ervan.\n\nAan het einde van het spel moet je, met het drinkwaterbudget dat je over hebt, kiezen welke activiteiten je kunt doen.";
            _P_site1_welcomePanel22.text = _L_site1_welcomePanel22.text;
            _L_site1_welcomePanel23.text = "Deze app is ontwikkeld in het ULTIMATE project, dat financiële ondersteuning ontvangt uit de European Unie’s Horizon 2020 research and innovation programma onder contract no. 869318. Meer op ultimatewater.eu";
            _P_site1_welcomePanel23.text = _L_site1_welcomePanel23.text;
            //multichoice panel
            _L_site1_multichoicePanel1.text = "Waar komt drinkwater in Nederland vandaan? (kies 1 of meerdere antwoorden)";
            _P_site1_multichoicePanel1.text = _L_site1_multichoicePanel1.text;
            _L_site1_multichoicePanel2.text = "Regenwater";
            _P_site1_multichoicePanel2.text = _L_site1_multichoicePanel2.text;
            _L_site1_multichoicePanel3.text = "Rivierwater";
            _P_site1_multichoicePanel3.text = _L_site1_multichoicePanel3.text;
            _L_site1_multichoicePanel4.text = "Zeewater";
            _P_site1_multichoicePanel4.text = _L_site1_multichoicePanel4.text;
            _L_site1_multichoicePanel5.text = "Grondwater";
            _P_site1_multichoicePanel5.text = _L_site1_multichoicePanel5.text;
            _L_site1_multichoicePanel6.text = "Afvalwater";
            _P_site1_multichoicePanel6.text = _L_site1_multichoicePanel6.text;
            //score update panel
            if(site1UI.GetComponent<Site1UI>().attempt < 2){
                _L_site1_statusUpdatePanel2.text = "Je hebt niet alle antwoorden goed en je verliest 5 liter water. Probeer het nog een keer.";
                _P_site1_statusUpdatePanel2.text = _L_site1_statusUpdatePanel2.text;
            }else if(site1UI.GetComponent<Site1UI>().attempt == 2){
                _L_site1_statusUpdatePanel2.text = "In Nederland zijn de belangrijkste bronnen voor drinkwater: oppervlaktewater (water uit rivieren en meren) en grondwater (water dat zich onder de grond bevindt).";
                _P_site1_statusUpdatePanel2.text = _L_site1_statusUpdatePanel2.text;
            }
            if(!site1UI.GetComponent<Site1UI>().correct){
                _L_site1_statusUpdatePanel1.text = "Onjuist!";
                _P_site1_statusUpdatePanel1.text = _L_site1_statusUpdatePanel1.text;
            }else{
                _L_site1_statusUpdatePanel1.text = "Juist!";
                _P_site1_statusUpdatePanel1.text = _L_site1_statusUpdatePanel1.text;
            }
            _L_site1_statusUpdatePanel3.text = "Je huidige score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liter.";
            _P_site1_statusUpdatePanel3.text = _L_site1_statusUpdatePanel3.text;
            //answer panel
            _L_site1_answerPanel1.text = "In Nederland wordt het meeste drinkwater geproduceerd uit ondergrondse bronnen. Om te zorgen voor een betrouwbare en duurzame drinkwatervoorziening voor iedereen en om tegelijker het milieu te kunnen beschermen, is het belangrijk om te begrijpen hoe de verschillende waterbronnen met elkaar verbonden zijn, hoe we het gebruik ervan kunnen beheren en de kwaliteit kunnen bewaken.";
            _P_site1_answerPanel1.text = _L_site1_answerPanel1.text;
            _L_site1_answerPanel2.text = "Waar komt drinkwater in Nederland vandaan?";
            _P_site1_answerPanel2.text = _L_site1_answerPanel2.text;
            _L_site1_answerPanel3.text = "Grondwater  63%";
            _P_site1_answerPanel3.text = _L_site1_answerPanel3.text;
            _L_site1_answerPanel4.text = "Oppervlaktewater  37%";
            _P_site1_answerPanel4.text = _L_site1_answerPanel4.text;
        }

        //---------------------site2--------------------------------------
        if(site2.activeSelf){
            //welcome panel
            _L_site2_welcomePanel1.text = "Welkom bij de waterbron!";
            _P_site2_welcomePanel1.text = _L_site2_welcomePanel1.text;
            _L_site2_welcomePanel2.text = "De eerste stap in het maken van drinkwater is het oppompen van water uit een bron en het te zuiveren.\n\nRondom de bron op deze locatie hebben we 3 onderdelen verstopt die nodig zijn om drinkwater te maken. De onderdelen bevinden zich binnen 2,5 meter van je huidige positie. Verzamel alle 3 de onderdelen. Om een onderdeel te verzamelen: activeer de camera via het camera icoon, zoek het voorwerp, en tik op de 3D-afbeelding als je het onderdeel gevonden hebt.\n\nVeel succes!\n\n";
            _P_site2_welcomePanel2.text = _L_site2_welcomePanel2.text;
            //find panel
            _L_site2_findPanel1.text = "Verzameld:";
            _P_site2_findPanel1.text = _L_site2_findPanel1.text;
            _L_site2_findPanel2.text = "Leiding";
            _P_site2_findPanel2.text = _L_site2_findPanel2.text;
            _L_site2_findPanel3.text = "Membraanfilter";
            _P_site2_findPanel3.text = _L_site2_findPanel3.text;
            _L_site2_findPanel4.text = "Tank";
            _P_site2_findPanel4.text = _L_site2_findPanel4.text;
            //object labels
            pipe_text.text = "Leiding\n(transport)";
            memmbrane_text.text = "Membraanfilter\n(waterbehandeling)";
            tank_text.text = "Tank\n(opslag)";
            //distance warning panel
            _L_site2_distanceWarningPanel.text = "Je bent te ver weg!";
            _P_site2_distanceWarningPanel.text = _L_site2_distanceWarningPanel.text;
            //tap on object panel
            _L_site2_tapOnObjectPanel.text = "Tik op het 3D-object";
            _P_site2_tapOnObjectPanel.text = _L_site2_tapOnObjectPanel.text;
            //items found panel
            _L_site2_itemsFoundPanel1.text = "Gefeliciteerd!";
            _P_site2_itemsFoundPanel1.text = _L_site2_itemsFoundPanel1.text;
            _L_site2_itemsFoundPanel2.text = "Je hebt alle 3 de onderdelen gevonden die nodig zijn om het water op te vangen, te zuiveren en op te slaan. Zet de onderdelen nu in de juiste volgorde.\n\nVeel succes!";
            _P_site2_itemsFoundPanel2.text = _L_site2_itemsFoundPanel2.text;
            //task panel
            _L_site2_taskPanel1.text = "Zet de onderdelen in de juiste volgorde voor verzamelen, zuiveren en opslaan. Je kunt de onderdelen verplaatsen door ze te slepen. Je hebt maar één poging om de onderdelen in de juiste volgorde te zetten.";
            _P_site2_taskPanel1.text = _L_site2_taskPanel1.text;
            _L_site2_taskPanel2.text = "Leiding";
            _P_site2_taskPanel2.text = _L_site2_taskPanel2.text;
            _L_site2_taskPanel3.text = "Membraanfilter";
            _P_site2_taskPanel3.text = _L_site2_taskPanel3.text;
            _L_site2_taskPanel4.text = "Tank";
            _P_site2_taskPanel4.text = _L_site2_taskPanel4.text;
            //task completed panel
            _L_site2_taskCompletedPanel2.text = "De juiste volgorde is: Leiding (om het water op te pompen), Membraan (om het water te zuiveren) en Tank (om het water op te slaan).";
            _P_site2_taskCompletedPanel2.text = _L_site2_taskCompletedPanel2.text;
            _L_site2_taskCompletedPanel3.text = "Je verliest 10 liter water.";
            _P_site2_taskCompletedPanel3.text = _L_site2_taskCompletedPanel3.text;
            if(site2UI.GetComponent<Site2UI>().failed){
                _L_site2_taskCompletedPanel1.text = "Onjuist!";
                _P_site2_taskCompletedPanel1.text = _L_site2_taskCompletedPanel1.text;
            }else{
                _L_site2_taskCompletedPanel1.text = "Juist!";
                _P_site2_taskCompletedPanel1.text = _L_site2_taskCompletedPanel1.text;
            }
            _L_site2_taskCompletedPanel4.text = "Je huidige score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liter.";
            _P_site2_taskCompletedPanel4.text = _L_site2_taskCompletedPanel4.text;
        }

        //---------------------site3--------------------------------------
        if(site3.activeSelf){
            //welcome panel
            _L_site3_welcomePanel1.text = "Welkom bij het leidingnetwerk!";
            _P_site3_welcomePanel1.text = _L_site3_welcomePanel1.text;
            _L_site3_welcomePanel2.text = "Wist je dat Nederland een leidingnetwerk voor drinkwater heeft van 120.000 km? Dit is lang genoeg om 3 keer rond de aarde te gaan! Deze leidingen zijn nodig om het drinkwater naar de klanten te brengen (bijvoorbeeld naar jouw huis).\n\nJe volgende challenge is het vinden van AIR (de Autonomous Inspection Robot). AIR is een robot die in de distributieleidingen leeft en is uitgerust met sensoren om de toestand van het leidingnetwerk te analyseren.\n\nAIR bevindt binnen 2,5 meter van je huidige positie. Als je AIR hebt gevonden, tik je op de robot.\n\nVeel succes!";
            _P_site3_welcomePanel2.text = _L_site3_welcomePanel2.text;
            //distance warning panel
            _L_site3_distanceWarningPanel.text = "Je bent te ver weg!";
            _P_site3_distanceWarningPanel.text = _L_site3_distanceWarningPanel.text;
            //tap on object panel
            _L_site3_tapOnObjectPanel.text = "Tik op de robot.";
            _P_site3_tapOnObjectPanel.text = _L_site3_tapOnObjectPanel.text;
            //info bubble panel
            _L_site3_infoBubblePanel1.text = "Hallo, mijn naam is AIR. Ik ben verantwoordelijk voor de gezondheid van het leidingnetwerk.\nOmdat je mij gevonden hebt, beloon ik je met 3 onderdelen voor dit deel van het watersysteem";
            _L_site3_infoBubblePanel2.text = "•\tPomp\n•\tLeiding\n•\tKraan";
            _L_site3_infoBubblePanel3.text = "In je volgende opdracht moet je deze onderdelen in de juiste volgorde zetten om gezuiverd drinkwater van de opslagtank op locatie 1 (waterbron) naar je huis te brengen.\nVeel succes!";
            _P_site3_infoBubblePanel1.text = _L_site3_infoBubblePanel1.text;
            _P_site3_infoBubblePanel2.text = _L_site3_infoBubblePanel2.text;
            _P_site3_infoBubblePanel3.text = "In je volgende opdracht moet je deze onderdelen in de juiste volgorde zetten om gezuiverd drinkwater van de opslagtank op locatie 1 (waterbron) naar je huis te brengen.\n\nVeel succes!";
            //task panel
            _L_site3_taskPanel1.text = "Zet de onderdelen voor dit deel van het watersysteem in de juiste volgorde om drinkwater naar je huis te brengen. Je kunt de onderdelen verplaatsen door ze te verslepen.";
            _P_site3_taskPanel1.text = _L_site3_taskPanel1.text;
            _L_site3_taskPanel2.text = "Leiding";
            _P_site3_taskPanel2.text = _L_site3_taskPanel2.text;
            _L_site3_taskPanel3.text = "Kraan";
            _P_site3_taskPanel3.text = _L_site3_taskPanel3.text;
            _L_site3_taskPanel4.text = "Pomp";
            _P_site3_taskPanel4.text = _L_site3_taskPanel4.text;
            //task completed panel
            _L_site3_taskCompletedPanel2.text = "De juiste volgorde is: Pomp (om het water te verplaatsen), Leiding (om het water te transporteren) en Kraan (om bij het water te komen).";
            _P_site3_taskCompletedPanel2.text = _L_site3_taskCompletedPanel2.text;
            _L_site3_taskCompletedPanel3.text = "Je verliest 10 liter water.";
            _P_site3_taskCompletedPanel3.text = _L_site3_taskCompletedPanel3.text;
            if(site3UI.GetComponent<Site3UI>().failed){
                _L_site3_taskCompletedPanel1.text = "Onjuist!";
                _P_site3_taskCompletedPanel1.text = _L_site3_taskCompletedPanel1.text;
            }else{
                _L_site3_taskCompletedPanel1.text = "Juist!";
                _P_site3_taskCompletedPanel1.text = _L_site3_taskCompletedPanel1.text;
            }
            _L_site3_taskCompletedPanel4.text = "Je huidige score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liter.";
            _P_site3_taskCompletedPanel4.text = _L_site3_taskCompletedPanel4.text;
            //click to open
            var pipe = site3.transform.Find("pipe");
            if(pipe != null){
                pipe.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Klik op de kraan om deze te openen!";
            }
            //warning panel
            _L_site3_warningPanel1.text = "Waarschuwing!";
            _P_site3_warningPanel1.text = _L_site3_warningPanel1.text;
            _L_site3_warningPanel2.text = "Geen water.\n\n\nEr zit een lek in het leidingnetwerk. Dit moet gerepareerd worden.\n\n\nDe volgende challenge is om AIR door een doolhof te leiden om het lek te vinden.";
            _P_site3_warningPanel2.text = _L_site3_warningPanel2.text;
            //maze panel
            _L_site3_mazePanel.text = "Leid AIR door het doolhof om de kapotte leiding te vinden.\n\nAIR gaat vooruit door de pijltjestoets vooruit ingedrukt te houden. Je draait de AIR door de telefoon voor je te houden en naar links of rechts te draaien. Als je de kapotte leiding hebt gevonden, loop er dan naartoe.\n\nVeel succes!";
            _P_site3_mazePanel.text = _L_site3_mazePanel.text;
            //broken pipe canvas
            pipe = site3.transform.Find("brokenPipe");
            if(pipe != null){
                pipe.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Loop naar deze kapotte leiding.";
            }
            //found broken pipe panel
            _L_site3_foundBrokenPipePanel1.text = "Gefeliciteerd!";
            _P_site3_foundBrokenPipePanel1.text = _L_site3_foundBrokenPipePanel1.text;
            _L_site3_foundBrokenPipePanel2.text = "Je hebt AIR geholpen het lek te vinden. Het lek is nu gerepareerd.\n\nProbeer de kraan weer open te draaien.";
            _P_site3_foundBrokenPipePanel2.text = _L_site3_foundBrokenPipePanel2.text;
            //pipe opened panel
            _L_site3_pipeOpenedPanel1.text = "Gefeliciteerd!";
            _P_site3_pipeOpenedPanel1.text = _L_site3_pipeOpenedPanel1.text;
            _L_site3_pipeOpenedPanel2.text = "Je hebt met succes het leidingnetwerk ingericht om drinkwater naar je huis te brengen.\n\nWist je dat Nederlanders het drinkwater in huis  voor veel verschillende activiteiten gebruiken?. Het meeste water wordt bijvoorbeeld gebruikt om te douchen.";
            _P_site3_pipeOpenedPanel2.text = _L_site3_pipeOpenedPanel2.text;
            //info to multichoice panel 1
            _L_site3_infoToMultichoicePanel11.text = "Nederlandse drinkwaterverbruik in huis per activiteit";
            _P_site3_infoToMultichoicePanel11.text = _L_site3_infoToMultichoicePanel11.text;
            _L_site3_infoToMultichoicePanel12.text = "Douchen 41%";
            _P_site3_infoToMultichoicePanel12.text = _L_site3_infoToMultichoicePanel12.text;
            _L_site3_infoToMultichoicePanel13.text = "Toilet doorspoelen 29%";
            _P_site3_infoToMultichoicePanel13.text = _L_site3_infoToMultichoicePanel13.text;
            _L_site3_infoToMultichoicePanel14.text = "Kleding wassen 13%";
            _P_site3_infoToMultichoicePanel14.text = _L_site3_infoToMultichoicePanel14.text;
            _L_site3_infoToMultichoicePanel15.text = "Afwassen 13%";
            _P_site3_infoToMultichoicePanel15.text = _L_site3_infoToMultichoicePanel15.text;
            _L_site3_infoToMultichoicePanel16.text = "Handen wassen 3%";
            _P_site3_infoToMultichoicePanel16.text = _L_site3_infoToMultichoicePanel16.text;
            _L_site3_infoToMultichoicePanel17.text = "Koffie, thee en water drinken 1%";
            _P_site3_infoToMultichoicePanel17.text = _L_site3_infoToMultichoicePanel17.text;
            _L_site3_infoToMultichoicePanel18.text = "Eten bereiden 1%";
            _P_site3_infoToMultichoicePanel18.text = _L_site3_infoToMultichoicePanel18.text;
            _L_site3_infoToMultichoicePanel19.text = "Overige 6%";
            _P_site3_infoToMultichoicePanel19.text = _L_site3_infoToMultichoicePanel19.text;
            //info between panel
            _L_site3_infoBetweenPanel.text = "Wist je dat het gebruik van drinkwater ook verantwoordelijk is voor een groot deel van het energieverbruik in je huis.\n\nGemiddeld 20% van de energie die in thuis gebruikt, is voor het verwarmen van drinkwater (koken, douchen). Van dit warme water wordt 80% gebruikt om te douchen.";
            _P_site3_infoBetweenPanel.text = "Wist je dat het gebruik van drinkwater ook verantwoordelijk is voor een groot deel van het energieverbruik in je huis.\n\nGemiddeld 20% van de energie die in thuis gebruikt, is voor het verwarmen van drinkwater (koken, douchen). Van dit warme water wordt 80% gebruikt om te douchen.";
            //info to multichoice panel 2
            _L_site3_infoToMultichoicePanel21.text = "Gemiddeld huishoudelijk energieverbruik in Nederland";
            _P_site3_infoToMultichoicePanel21.text = _L_site3_infoToMultichoicePanel21.text;
            _L_site3_infoToMultichoicePanel22.text = "Verwarming 75%";
            _P_site3_infoToMultichoicePanel22.text = _L_site3_infoToMultichoicePanel22.text;
            _L_site3_infoToMultichoicePanel23.text = "Warm water 20%";
            _P_site3_infoToMultichoicePanel23.text = _L_site3_infoToMultichoicePanel23.text;
            _L_site3_infoToMultichoicePanel24.text = "Koken 5%";
            _P_site3_infoToMultichoicePanel24.text = _L_site3_infoToMultichoicePanel24.text;
            _L_site3_infoToMultichoicePanel25.text = "Douchen 80%";
            _P_site3_infoToMultichoicePanel25.text = _L_site3_infoToMultichoicePanel25.text;
            _L_site3_infoToMultichoicePanel26.text = "Ander gebruik 20%";
            _P_site3_infoToMultichoicePanel26.text = _L_site3_infoToMultichoicePanel26.text;
            _L_site3_infoToMultichoicePanel27.text = "Wist je dat je thuis water kunt besparen met een paar eenvoudige waterbesparende maatregelen? Dit kan helpen om te besparen op het gebruik en de kosten van water EN energie.";
            _P_site3_infoToMultichoicePanel27.text = _L_site3_infoToMultichoicePanel27.text;
            //multichoice panel 1
            _L_site3_multichoicePanel11.text = "Selecteer welke waterbesparende maatregelen bij jou thuis kunnen worden gebruikt om het gebruik van drinkwater te verminderen. (kies 1 of meerdere antwoorden)";
            _P_site3_multichoicePanel11.text = _L_site3_multichoicePanel11.text;
            _L_site3_multichoicePanel12.text = "Regenwater opvangen en gebruiken om planten in de tuin water te geven";
            _P_site3_multichoicePanel12.text = _L_site3_multichoicePanel12.text;
            _L_site3_multichoicePanel13.text = "Minder lang onder de douche staan";
            _P_site3_multichoicePanel13.text = _L_site3_multichoicePanel13.text;
            _L_site3_multichoicePanel14.text = "De kraan open laten staan als je je tanden poetst";
            _P_site3_multichoicePanel14.text = _L_site3_multichoicePanel14.text;
            _L_site3_multichoicePanel15.text = "Je wasmachine gebruiken met weinig kledingstukken";
            _P_site3_multichoicePanel15.text = _L_site3_multichoicePanel15.text;
            _L_site3_multichoicePanel16.text = "Lekkages repareren (bijv. lekkende kraan, doorlopend toilet)";
            _P_site3_multichoicePanel16.text = _L_site3_multichoicePanel16.text;
            //score update panel 1
            if(site3.GetComponent<Site3>().attempt < 2){
                _L_site3_scoreUpdatePanel12.text = "Je hebt niet alle antwoorden goed en je verliest 5 liter water. Probeer het nog een keer.";
                _P_site3_scoreUpdatePanel12.text = _L_site3_scoreUpdatePanel12.text;
            }else if(site3.GetComponent<Site3>().attempt == 2){
                _L_site3_scoreUpdatePanel12.text = "Je kunt water besparen door regenwater op te vangen en dit te gebruiken voor tuinieren, minder lang onder de douche te staan of lekken te repareren. Er zijn nog veel meer manieren om water te besparen.";
                _P_site3_scoreUpdatePanel12.text = _L_site3_scoreUpdatePanel12.text;
            }
            if(!site3.GetComponent<Site3>().correct){
                _L_site3_scoreUpdatePanel11.text = "Onjuist!";
                _P_site3_scoreUpdatePanel11.text = _L_site3_scoreUpdatePanel11.text;
            }else{
                _L_site3_scoreUpdatePanel11.text = "Juist!";
                _P_site3_scoreUpdatePanel11.text = _L_site3_scoreUpdatePanel11.text;
            }
            _L_site3_scoreUpdatePanel13.text = "Je huidige score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liter.";
            _P_site3_scoreUpdatePanel13.text = _L_site3_scoreUpdatePanel13.text;
            //multichoice panel 2
            _L_site3_multichoicePanel21.text = "Het gebruikte drinkwater (bijv. om te douchen, toiletten door te spoelen) verdwijnt het in het riool. Vanaf dat moment is het afvalwater. Wat gebeurt er met dit afvalwater? (kies 1 of meerdere antwoorden)";
            _P_site3_multichoicePanel21.text = _L_site3_multichoicePanel21.text;
            _L_site3_multichoicePanel22.text = "Wordt rechtstreeks in het milieu geloosd";
            _P_site3_multichoicePanel22.text = _L_site3_multichoicePanel22.text;
            _L_site3_multichoicePanel23.text = "Wordt eerst gezuiverd en dan weer in het milieu geloosd";
            _P_site3_multichoicePanel23.text = _L_site3_multichoicePanel23.text;
            _L_site3_multichoicePanel24.text = "Wordt gezuiverd en dan hergebruikt";
            _P_site3_multichoicePanel24.text = _L_site3_multichoicePanel24.text;
            _L_site3_multichoicePanel25.text = "Er gebeurt niets met het water nadat het gebruikt is";
            _P_site3_multichoicePanel25.text = _L_site3_multichoicePanel25.text;
            //score update panel 2
            if(site3.GetComponent<Site3>().attempt < 2){
                _L_site3_scoreUpdatePanel22.text = "Je hebt niet alle antwoorden goed en je verliest 5 liter water. Probeer het nog een keer.";
                _P_site3_scoreUpdatePanel22.text = _L_site3_scoreUpdatePanel22.text;
            }else if(site3.GetComponent<Site3>().attempt == 2){
                _L_site3_scoreUpdatePanel22.text = "Nadat het water is gebruikt, wordt het eerst gezuiverd voordat het weer in het milieu wordt geloosd of voordat het wordt hergebruikt.";
                _P_site3_scoreUpdatePanel22.text = _L_site3_scoreUpdatePanel22.text;
            }
            if(!site3.GetComponent<Site3>().correct){
                _L_site3_scoreUpdatePanel21.text = "Onjuist!";
                _P_site3_scoreUpdatePanel21.text = _L_site3_scoreUpdatePanel21.text;
            }else{
                _L_site3_scoreUpdatePanel21.text = "Juist!";
                _P_site3_scoreUpdatePanel21.text = _L_site3_scoreUpdatePanel21.text;
            }
            _L_site3_scoreUpdatePanel23.text = "Je huidige score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liter";
            _P_site3_scoreUpdatePanel23.text = _L_site3_scoreUpdatePanel23.text;
        }

        //---------------------site4--------------------------------------
        if(site4.activeSelf){
            //welcome panel 1
            _L_site4_welcomePanel11.text = "Welkom bij de afvalwaterzuiveringsinstallatie!";
            _P_site4_welcomePanel11.text = _L_site4_welcomePanel11.text;
            _L_site4_welcomePanel12.text = "Nadat je het drinkwater in je huis hebt gebruikt, brengen rioolbuizen het afvalwater (gebruikt water) naar een zuiveringsinstallatie.\n\nIn Nederland zijn de gemeente en het waterschap samen verantwoordelijk voor het opvangen en zuiveren van het afvalwater. De gemeente zorgt voor het riool (inzameling en transport), de waterschappen zorgen voor het zuiveren.";
            _P_site4_welcomePanel12.text = _L_site4_welcomePanel12.text;
            //welcome panel 2
            _L_site4_welcomePanel21.text = "Welkom bij de afvalwaterzuiveringsinstallatie!";
            _P_site4_welcomePanel21.text = _L_site4_welcomePanel21.text;
            _L_site4_welcomePanel22.text = "Het zuiveren van afvalwater heeft verschillende voordelen.\n\nIn de volgende opdracht moet je aangeven welke uitspraken waar of niet waar zijn. Bij elk fout antwoord verlies je 5 liter van je waterbudget.\n\nVeel succes!";
            _P_site4_welcomePanel22.text = "Het zuiveren van afvalwater heeft verschillende voordelen.\n\nIn de volgende opdracht moet je aangeven welke uitspraken waar of niet waar zijn. Bij elk fout antwoord verlies je 5 liter van je waterbudget.\n\nVeel succes!";
            //statement panel
            site4.GetComponent<Site4>().changeLanguage();
            //after statements panel
            _L_site4_afterStatementsPanel1.text = "Gefeliciteerd!";
            _P_site4_afterStatementsPanel1.text = _L_site4_afterStatementsPanel1.text;
            _L_site4_afterStatementsPanel2.text = "Je hebt de laatste 3 onderdelen van het watersysteem gekregen.";
            _P_site4_afterStatementsPanel2.text = _L_site4_afterStatementsPanel2.text;
            _L_site4_afterStatementsPanel3.text = "• Afvalwaterzuiveringsinstallatie\n• Rioolbuis\n• Waterbron (bijv. meer, rivier)";
            _P_site4_afterStatementsPanel3.text = _L_site4_afterStatementsPanel3.text;
            _L_site4_afterStatementsPanel4.text = "In de volgende challenge moet je de onderdelen in de juiste volgorde zetten om te helpen bij het zuiveren van afvalwater en het terugbrengen van het schoon gemaakte afvalwater naar het watersysteem.\nVeel succes!";
            _P_site4_afterStatementsPanel4.text = "In de volgende challenge moet je de onderdelen in de juiste volgorde zetten om te helpen bij het zuiveren van afvalwater en het terugbrengen van het schoon gemaakte afvalwater naar het watersysteem.\n\nVeel succes!";
            //task panel
            _L_site4_taskPanel1.text = "Zet de onderdelen voor dit deel van het systeem in de juiste volgorde om afvalwater te zuiveren en het gezuiverde water terug te voeren in het watersysteem (zoals een meer of rivier). Je kunt onderdelen verplaatsen door te slepen.";
            _P_site4_taskPanel1.text = _L_site4_taskPanel1.text;
            _L_site4_taskPanel2.text = "Afvalwaterzuiveringsinstallatie";
            _P_site4_taskPanel2.text = _L_site4_taskPanel2.text;
            _L_site4_taskPanel3.text = "Rioolbuis";
            _P_site4_taskPanel3.text = _L_site4_taskPanel3.text;
            _L_site4_taskPanel4.text = "Waterbron (meer, rivier) ";
            _P_site4_taskPanel4.text = _L_site4_taskPanel4.text;
            //score update panel
            _L_site4_scoreUpdatePanel2.text = "De juiste volgorde is: Rioolbuis (om het vuile water te transporteren), Afvalwaterzuiveringsinstallatie (om het gebruikte water schoon te maken) en Waterbron (meer, rivier) (om het schone water te ontvangen).";
            _P_site4_scoreUpdatePanel2.text = _L_site4_scoreUpdatePanel2.text;
            _L_site4_scoreUpdatePanel3.text = "Je verliest 10 liter water.";
            _P_site4_scoreUpdatePanel3.text = _L_site4_scoreUpdatePanel3.text;
            if(site4UI.GetComponent<Site4UI>().failed){
                _L_site4_scoreUpdatePanel1.text = "Onjuist!";
                _P_site4_scoreUpdatePanel1.text = _L_site4_scoreUpdatePanel1.text;
            }else{
                _L_site4_scoreUpdatePanel1.text = "Juist!";
                _P_site4_scoreUpdatePanel1.text = _L_site4_scoreUpdatePanel1.text;
            }
            _L_site4_scoreUpdatePanel4.text = "Je huidige score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liter.";
            _P_site4_scoreUpdatePanel4.text = _L_site4_scoreUpdatePanel4.text;
        }

        //---------------------site5--------------------------------------
        if(site5.activeSelf){
            //welcome panel
            _L_site5_welcomePanel1.text = "Welkom in het milieu!";
            _P_site5_welcomePanel1.text = _L_site5_welcomePanel1.text;
            _L_site5_welcomePanel2.text = "In de vorige challenge heb je geleerd hoe afvalwater, nadat het gezuiverd is, weer terug in het milieu kan worden gebracht. Het is belangrijk dat het afvalwater wordt gezuiverd voordat het weer in het milieu terechtkomt. Dit wordt gedaan om te voorkomen dat verontreinigende stoffen in het milieu terechtkomen. ";
            _P_site5_welcomePanel2.text = _L_site5_welcomePanel2.text;
            //multichoice panel
            _L_site5_multichoicePanel1.text = "Welke watergerelateerde verontreinigende stoffen kunnen in het milieu terechtkomen? (kies 1 of meerdere antwoorden)";
            _P_site5_multichoicePanel1.text = _L_site5_multichoicePanel1.text;
            _L_site5_multichoicePanel2.text = "Plastic";
            _P_site5_multichoicePanel2.text = _L_site5_multichoicePanel2.text;
            _L_site5_multichoicePanel3.text = "Pesticiden";
            _P_site5_multichoicePanel3.text = _L_site5_multichoicePanel3.text;
            _L_site5_multichoicePanel4.text = "Geneesmiddelen en hormonen";
            _P_site5_multichoicePanel4.text = _L_site5_multichoicePanel4.text;
            _L_site5_multichoicePanel5.text = "Bacteriën";
            _P_site5_multichoicePanel5.text = _L_site5_multichoicePanel5.text;
            //score update panel
            if(site5.GetComponent<Site5>().attempt < 2){
                _L_site5_scoreUpdatePanel2.text = "Je hebt niet alle antwoorden goed en je verliest 5 liter water. Probeer het nog een keer.";
                _P_site5_scoreUpdatePanel2.text = _L_site5_scoreUpdatePanel2.text;
            }else if(site5.GetComponent<Site5>().attempt == 2){
                _L_site5_scoreUpdatePanel2.text = "De juiste verontreinigende stoffen zijn: Plastics, Pesticiden, Geneesmiddelen en hormonen, Bacteriën.";
                _P_site5_scoreUpdatePanel2.text = _L_site5_scoreUpdatePanel2.text;
            }
            if(!site5.GetComponent<Site5>().correct){
                _L_site5_scoreUpdatePanel1.text = "Onjuist!";
                _P_site5_scoreUpdatePanel1.text = _L_site5_scoreUpdatePanel1.text;
            }else{
                _L_site5_scoreUpdatePanel1.text = "Juist!";
                _P_site5_scoreUpdatePanel1.text = _L_site5_scoreUpdatePanel1.text;
            }
            _L_site5_scoreUpdatePanel3.text = "Je huidige score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liter.";
            _P_site5_scoreUpdatePanel3.text = _L_site5_scoreUpdatePanel3.text;
            //info panel 1
            _L_site5_infoPanel1.text = "Door vervuiling door menselijke activiteiten lopen drinkwaterbronnen in Nederland ernstig gevaar. En ook klimaatverandering is een bedrijging voor de kwaliteit van waterbronnen.\n\nIn Nederland zijn er  wetten om de kwaliteit van grond- en oppervlaktewaterbronnen te beschermen.";
            _P_site5_infoPanel1.text = _L_site5_infoPanel1.text;
            //thank you panel
            _L_site5_thankYouPanel1.text = "Bedankt voor het spelen van\nWater-kennis!";
            _P_site5_thankYouPanel1.text = _L_site5_thankYouPanel1.text;
            _L_site5_thankYouPanel2.text = "Je bent met succes door het watersysteem gekomen, van de bron, via de distributie, de zuivering van afvalwater en als laatste het terugbrengen van het gezuiverde water in het milieu.\n\nWe hopen dat de ervaring zowel leerzaam als leuk was.";
            _P_site5_thankYouPanel2.text = _L_site5_thankYouPanel2.text;
            //info panel 2
            _L_site5_infoPanel21.text = "Na het beantwoorden van alle vragen heb je nog " + gameController.GetComponent<gameController>().score.ToString() + " liter van je totale drinkwaterbudget over.";
            _P_site5_infoPanel21.text = _L_site5_infoPanel21.text;
            _L_site5_infoPanel22.text = "De gemiddelde Nederlander gebruikt thuis 120 liter drinkwater per dag (bijv. douchen, doorspoelen, wassen, voedsel bereiden).";
            _P_site5_infoPanel22.text = _L_site5_infoPanel22.text;
            //spend water panel
            _L_site5_spendWaterPanel1.text = "Hoe zou je het dagelijkse drinkwaterbudget van " + gameController.GetComponent<gameController>().score.ToString() + " liter dat je over hebt gehouden verdelen over dagelijkse activiteiten?";
            _P_site5_spendWaterPanel1.text = _L_site5_spendWaterPanel1.text;
            _L_site5_spendWaterPanel2.text = "Een douche nemen (50 L)";
            _P_site5_spendWaterPanel2.text = _L_site5_spendWaterPanel2.text;
            _L_site5_spendWaterPanel3.text = "Je toilet doorspoelen (35 L)";
            _P_site5_spendWaterPanel3.text = _L_site5_spendWaterPanel3.text;
            _L_site5_spendWaterPanel4.text = "De was doen (15 L)";
            _P_site5_spendWaterPanel4.text = _L_site5_spendWaterPanel4.text;
            _L_site5_spendWaterPanel5.text = "Je handen wassen (5 L)";
            _P_site5_spendWaterPanel5.text = _L_site5_spendWaterPanel5.text;
            _L_site5_spendWaterPanel6.text = "Afwassen (5 L)";
            _P_site5_spendWaterPanel6.text = _L_site5_spendWaterPanel6.text;
            _L_site5_spendWaterPanel7.text = "Eten bereiden (2 liter)";
            _P_site5_spendWaterPanel7.text = _L_site5_spendWaterPanel7.text;
            _L_site5_spendWaterPanel8.text = "Kraanwater drinken (1 liter)";
            _P_site5_spendWaterPanel8.text = _L_site5_spendWaterPanel8.text;
            _L_site5_spendWaterPanel9.text = "Koffie en thee zetten (1 liter)";
            _P_site5_spendWaterPanel9.text = _L_site5_spendWaterPanel9.text;
            _L_site5_spendWaterPanel10.text = "Andere activiteiten doen (bijv. planten water geven, ramen zemen) (6 L)";
            _P_site5_spendWaterPanel10.text = _L_site5_spendWaterPanel10.text;
            site5.GetComponent<Site5>().updateTankText();
            //end panel
            _L_site5_endPanel1.text = "•\tSpel afsluiten";
            _P_site5_endPanel1.text = "• Spel afsluiten";
            _L_site5_endPanel2.text = "•\tOpnieuw spelen";
            _P_site5_endPanel2.text = "• Opnieuw spelen";
            _L_site5_endPanel3.text = "•\tLink naar KWR pagina: \n\n<link=\"ID\">https://www.kwrwater.nl/projecten/water-kennis-een-meeslepende-media-ervaring/</link>";
            _P_site5_endPanel3.text = "• Link naar KWR pagina: \n\n<link=\"ID\">https://www.kwrwater.nl/projecten/water-kennis-een-meeslepende-media-ervaring/</link>";
        }
    }











    public void changetoEnglish(){
        currentSite_index = app.GetComponent<App>().nextSite_index - 1;
        //status panel
        gameController.GetComponent<gameController>().updateStatus(0, false, true);
        //wrong site panel
        _L_wrongSitePanel.text = "You are not allowed to this site!";
        _P_wrongSitePanel.text = _L_wrongSitePanel.text;
        //map instruction panel
        switch(currentSite_index){
            case 1:
                _L_mapInstructionPanel1.text = "Navigate to the first site!";
                _P_mapInstructionPanel1.text = _L_mapInstructionPanel1.text;
                _L_mapInstructionPanel2.text = "Use the map view to navigate your way to the to the source of the water (site 1).\nAt the site, find the sign with the following image:";
                _P_mapInstructionPanel2.text = "Use the map view to navigate your way to the to the source of the water\n(site 1).\nAt the site, find the sign with the following image:";
                break;
            case 2:
                _L_mapInstructionPanel1.text = "Congratulations on completing the water source challenge!";
                _P_mapInstructionPanel1.text = _L_mapInstructionPanel1.text;
                _L_mapInstructionPanel2.text = "Use the map view to navigate your way to the to the pipe network (site 2).\nAt the site, find the sign with the following image:";
                _P_mapInstructionPanel2.text = "Use the map view to navigate your way to the to the pipe network (site 2).\nAt the site, find the sign with the following image:";
                break;
            case 3:
                _L_mapInstructionPanel1.text = "Congratulations on completing the pipe network challenges!";
                _P_mapInstructionPanel1.text = _L_mapInstructionPanel1.text;
                _L_mapInstructionPanel2.text = "Use the map view to navigate your way to the to the wastewater treatment plant\n(site 3).\nAt the site, find the sign with the following image:";
                _P_mapInstructionPanel2.text = "Use the map view to navigate your way to the to the wastewater treatment plant (site 3).\nAt the site, find the sign with the following image:";
                break;
            case 4:
                _L_mapInstructionPanel1.text = "Congratulations on completing the wastewater treatment plant challenges!";
                _P_mapInstructionPanel1.text = _L_mapInstructionPanel1.text;
                _L_mapInstructionPanel2.text = "Use the map view to navigate your way to the to the environment (site 4).\nAt the site, find the sign with the following image:";
                _P_mapInstructionPanel2.text = "Use the map view to navigate your way to the to the environment (site 4).\nAt the site, find the sign with the following image:";
                break;
        }
        _L_mapInstructionPanel3.text = "Scan the image with your device using the camera view (activate by pressing the camera icon below) and click on the 3D image of the water source.";
        _P_mapInstructionPanel3.text = _L_mapInstructionPanel3.text;

        //---------------------site1--------------------------------------
        if(site1.activeSelf){
            //welcome panel 1
            _L_site1_welcomePanel11.text = "Welcome to Water-kennis, an immersive media experience!";
            _P_site1_welcomePanel11.text = _L_site1_welcomePanel11.text;
            _L_site1_welcomePanel12.text = "Turn on your tap, shower or flush your toilet and clean water flows out. But where does this water come from?\n\nThe availability of enough clean water has become a societal issue all over the world. At KWR, we work on finding the best way to manage the water system, with sustainability and circularity as a priority.\n\nThrough a number of challenges, you will learn about the different stages of the water system that brings water to your home.";
            _P_site1_welcomePanel12.text = _L_site1_welcomePanel12.text;
            _L_site1_welcomePanel13.text = "This app was developed was part of ULTIMATE. This project has received funding from the European Union’s Horizon 2020 research and innovation programme under grant agreement N° 869318. More on ultimatewater.eu";
            _P_site1_welcomePanel13.text = _L_site1_welcomePanel13.text;
            //welcome panel 2
            _L_site1_welcomePanel21.text = "Welcome to Water-kennis, an immersive media experience!";
            _P_site1_welcomePanel21.text = _L_site1_welcomePanel21.text;
            _L_site1_welcomePanel22.text = "The rules are simple. You will start with a drinking water budget of 120 litres (the average daily water consumption of a person in the Netherlands). If you complete a challenge with mistakes, you will lose a part of your drinking water budget.\n\nAfter completing the game, you will be asked to make choices in your water use based on your remaining drinking water budget.";
            _P_site1_welcomePanel22.text = _L_site1_welcomePanel22.text;
            _L_site1_welcomePanel23.text = "This app was developed was part of ULTIMATE. This project has received funding from the European Union’s Horizon 2020 research and innovation programme under grant agreement N° 869318. More on ultimatewater.eu";
            _P_site1_welcomePanel23.text = _L_site1_welcomePanel23.text;
            //multichoice panel
            _L_site1_multichoicePanel1.text = "Where is drinking water in the Netherlands coming from? (it is possible more than one answer is correct)";
            _P_site1_multichoicePanel1.text = _L_site1_multichoicePanel1.text;
            _L_site1_multichoicePanel2.text = "Rain water";
            _P_site1_multichoicePanel2.text = _L_site1_multichoicePanel2.text;
            _L_site1_multichoicePanel3.text = "River water";
            _P_site1_multichoicePanel3.text = _L_site1_multichoicePanel3.text;
            _L_site1_multichoicePanel4.text = "Seawater";
            _P_site1_multichoicePanel4.text = _L_site1_multichoicePanel4.text;
            _L_site1_multichoicePanel5.text = "Groundwater";
            _P_site1_multichoicePanel5.text = _L_site1_multichoicePanel5.text;
            _L_site1_multichoicePanel6.text = "Wastewater";
            _P_site1_multichoicePanel6.text = _L_site1_multichoicePanel6.text;
            //score update panel
            if(site1UI.GetComponent<Site1UI>().attempt < 2){
                _L_site1_statusUpdatePanel2.text = "You lost 5 liters of water. You have one more attempt.";
                _P_site1_statusUpdatePanel2.text = _L_site1_statusUpdatePanel2.text;
            }else if(site1UI.GetComponent<Site1UI>().attempt == 2){
                _L_site1_statusUpdatePanel2.text = "In the Netherlands, the main sources of drinking water are surface water (water from rivers and lakes) and groundwater (water found underground).";
                _P_site1_statusUpdatePanel2.text = _L_site1_statusUpdatePanel2.text;
            }
            if(!site1UI.GetComponent<Site1UI>().correct){
                _L_site1_statusUpdatePanel1.text = "Incorrect!";
                _P_site1_statusUpdatePanel1.text = _L_site1_statusUpdatePanel1.text;
            }else{
                _L_site1_statusUpdatePanel1.text = "Correct!";
                _P_site1_statusUpdatePanel1.text = _L_site1_statusUpdatePanel1.text;
            }
            _L_site1_statusUpdatePanel3.text = "Your current score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liters";
            _P_site1_statusUpdatePanel3.text = _L_site1_statusUpdatePanel3.text;
            //answer panel
            _L_site1_answerPanel1.text = "In the Netherlands, most of the drinking water is produced from underground sources. To ensure a reliable and sustainable supply of drinking water to meet the needs for all citizens while also safeguarding the environment, it is important to understanding how different water sources are linked, how to manage their exploitation and to secure their quality.";
            _P_site1_answerPanel1.text = _L_site1_answerPanel1.text;
            _L_site1_answerPanel2.text = "Where is drinking water from in the Netherlands?";
            _P_site1_answerPanel2.text = _L_site1_answerPanel2.text;
            _L_site1_answerPanel3.text = "Groundwater 63%";
            _P_site1_answerPanel3.text = _L_site1_answerPanel3.text;
            _L_site1_answerPanel4.text = "Surface water 37%";
            _P_site1_answerPanel4.text = _L_site1_answerPanel4.text;
        }

        //---------------------site2--------------------------------------
        if(site2.activeSelf){
            //welcome panel
            _L_site2_welcomePanel1.text = "Welcome to the water source!";
            _P_site2_welcomePanel1.text = _L_site2_welcomePanel1.text;
            _L_site2_welcomePanel2.text = "The first step in making drinking water is the water source.\n\nWe have hidden 3 components needed to make drinking water around the water source. The components are located in a 2.5 meter  radius. Collect all 3 components. In order to collect a component, you need to tap on the 3D image. \n\nGood luck!\n\n";
            _P_site2_welcomePanel2.text = _L_site2_welcomePanel2.text;
            //find panel
            _L_site2_findPanel1.text = "Collected:";
            _P_site2_findPanel1.text = _L_site2_findPanel1.text;
            _L_site2_findPanel2.text = "Pipe";
            _P_site2_findPanel2.text = _L_site2_findPanel2.text;
            _L_site2_findPanel3.text = "Membrane";
            _P_site2_findPanel3.text = _L_site2_findPanel3.text;
            _L_site2_findPanel4.text = "Tank";
            _P_site2_findPanel4.text = _L_site2_findPanel4.text;
            //object labels
            pipe_text.text = "Pipe\n(transportation)";
            memmbrane_text.text = "Membrane\n(treatment)";
            tank_text.text = "Tank\n(storage)";
            //distance warning panel
            _L_site2_distanceWarningPanel.text = "You are too far away!";
            _P_site2_distanceWarningPanel.text = _L_site2_distanceWarningPanel.text;
            //tap on object panel
            _L_site2_tapOnObjectPanel.text = "Tap on the 3D object";
            _P_site2_tapOnObjectPanel.text = _L_site2_tapOnObjectPanel.text;
            //items found panel
            _L_site2_itemsFoundPanel1.text = "Congratulations!";
            _P_site2_itemsFoundPanel1.text = _L_site2_itemsFoundPanel1.text;
            _L_site2_itemsFoundPanel2.text = "You have found all 3 components needed to collect, purify and store the water. Now, place the components in the correct order.\n\nGood luck!";
            _P_site2_itemsFoundPanel2.text = _L_site2_itemsFoundPanel2.text;
            //task panel
            _L_site2_taskPanel1.text = "Put the components in the correct order for collection, purification and storage. You can move components by dragging. You have only one attempt.";
            _P_site2_taskPanel1.text = _L_site2_taskPanel1.text;
            _L_site2_taskPanel2.text = "Pipe";
            _P_site2_taskPanel2.text = _L_site2_taskPanel2.text;
            _L_site2_taskPanel3.text = "Membrane";
            _P_site2_taskPanel3.text = _L_site2_taskPanel3.text;
            _L_site2_taskPanel4.text = "Tank";
            _P_site2_taskPanel4.text = _L_site2_taskPanel4.text;
            //task completed panel
            _L_site2_taskCompletedPanel2.text = "The correct order is: Pipe (to collect the water), Membrane (to treat the water) and Tank (to store the water).";
            _P_site2_taskCompletedPanel2.text = _L_site2_taskCompletedPanel2.text;
            _L_site2_taskCompletedPanel3.text = "You lost 10 litres of water.";
            _P_site2_taskCompletedPanel3.text = _L_site2_taskCompletedPanel3.text;
            if(site2UI.GetComponent<Site2UI>().failed){
                _L_site2_taskCompletedPanel1.text = "Incorrect!";
                _P_site2_taskCompletedPanel1.text = _L_site2_taskCompletedPanel1.text;
            }else{
                _L_site2_taskCompletedPanel1.text = "Correct!";
                _P_site2_taskCompletedPanel1.text = _L_site2_taskCompletedPanel1.text;
            }
            _L_site2_taskCompletedPanel4.text = "Your current score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liters.";
            _P_site2_taskCompletedPanel4.text = _L_site2_taskCompletedPanel4.text;
        }

        //---------------------site3--------------------------------------
        if(site3.activeSelf){
            //welcome panel
            _L_site3_welcomePanel1.text = "Welcome to the pipe network!";
            _P_site3_welcomePanel1.text = _L_site3_welcomePanel1.text;
            _L_site3_welcomePanel2.text = "Did you know that the Netherlands has a drinking water supply pipe network of 120,000 km? This is long enough to go around the earth 3 times! These pipes are necessary to bring the drinking water to the clients (for example to your home).\n\nYour next challenge is to find AIR (the Autonomous Inspection Robot). AIR is a robot that lives in the distribution pipes and is equipped with sensors to measure the condition of the pipe network.\n\nAIR is located somewhere in a 2.5  meter radius. When you find AIR, tap on the robot.\n\nGood luck!";
            _P_site3_welcomePanel2.text = _L_site3_welcomePanel2.text;
            //distance warning panel
            _L_site3_distanceWarningPanel.text = "You are too far away!";
            _P_site3_distanceWarningPanel.text = _L_site3_distanceWarningPanel.text;
            //tap on object panel
            _L_site3_tapOnObjectPanel.text = "Tap on the robot.";
            _P_site3_tapOnObjectPanel.text = _L_site3_tapOnObjectPanel.text;
            //info bubble panel
            _L_site3_infoBubblePanel1.text = "Hi, my name is AIR. I am responsible for the well-being of the pipe network.\nFor finding me, I would like to reward you with the following 3 components for this part of the water system";
            _L_site3_infoBubblePanel2.text = "•\tPump\n•\tPipe\n•\tTap";
            _L_site3_infoBubblePanel3.text = "In your next challenge, you will need to put these components in the correct order to help get the drinking water to your home.\nGood luck!";
            _P_site3_infoBubblePanel1.text = _L_site3_infoBubblePanel1.text;
            _P_site3_infoBubblePanel2.text = _L_site3_infoBubblePanel2.text;
            _P_site3_infoBubblePanel3.text = "In your next challenge, you will need to put these components in the correct order to help get the drinking water to your home.\n\nGood luck!";
            //task panel
            _L_site3_taskPanel1.text = "Put the components for this part of the water system in the correct order to bring drinking water to your home. You can move components by dragging.";
            _P_site3_taskPanel1.text = _L_site3_taskPanel1.text;
            _L_site3_taskPanel2.text = "Pipe";
            _P_site3_taskPanel2.text = _L_site3_taskPanel2.text;
            _L_site3_taskPanel3.text = "Tap";
            _P_site3_taskPanel3.text = _L_site3_taskPanel3.text;
            _L_site3_taskPanel4.text = "Pump";
            _P_site3_taskPanel4.text = _L_site3_taskPanel4.text;
            //task completed panel
            _L_site3_taskCompletedPanel2.text = "The correct order is: Pump (to move the water), Pipe (to transport the water) and Tap (to access the water).";
            _P_site3_taskCompletedPanel2.text = _L_site3_taskCompletedPanel2.text;
            _L_site3_taskCompletedPanel3.text = "You lost 10 litres of water.";
            _P_site3_taskCompletedPanel3.text = _L_site3_taskCompletedPanel3.text;
            if(site3UI.GetComponent<Site3UI>().failed){
                _L_site3_taskCompletedPanel1.text = "Incorrect!";
                _P_site3_taskCompletedPanel1.text = _L_site3_taskCompletedPanel1.text;
            }else{
                _L_site3_taskCompletedPanel1.text = "Correct!";
                _P_site3_taskCompletedPanel1.text = _L_site3_taskCompletedPanel1.text;
            }
            _L_site3_taskCompletedPanel4.text = "Your current score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liters.";
            _P_site3_taskCompletedPanel4.text = _L_site3_taskCompletedPanel4.text;
            //click to open
            var pipe = site3.transform.Find("pipe");
            if(pipe != null){
                pipe.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Click the valve to open!";
            }
            //warning panel
            _L_site3_warningPanel1.text = "Warning!";
            _P_site3_warningPanel1.text = _L_site3_warningPanel1.text;
            _L_site3_warningPanel2.text = "No water.\n\n\nThere is a leak in the pipe network that needs to be fixed.\n\n\nYour next challenge is to guide AIR through a maze to find the broken pipe.";
            _P_site3_warningPanel2.text = _L_site3_warningPanel2.text;
            //maze panel
            _L_site3_mazePanel.text = "Guide AIR through the maze to find the broken pipe.\n\nAIR is moved forward by pressing and holding down the forward arrow button . AIR is turned by holding the phone in front of you and rotating to the left or right. \n\nOnce you find the broken pipe, walk up to it.\n\nGood luck!";
            _P_site3_mazePanel.text = _L_site3_mazePanel.text;
            //broken pipe canvas
            pipe = site3.transform.Find("brokenPipe");
            if(pipe != null){
                pipe.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Walk into this broken pipe";
            }
            //found broken pipe panel
            _L_site3_foundBrokenPipePanel1.text = "Congratulations!";
            _P_site3_foundBrokenPipePanel1.text = _L_site3_foundBrokenPipePanel1.text;
            _L_site3_foundBrokenPipePanel2.text = "You have helped AIR find the leak. The leak has now been fixed.\n\nYou can try to open the tap again.";
            _P_site3_foundBrokenPipePanel2.text = _L_site3_foundBrokenPipePanel2.text;
            //pipe opened panel
            _L_site3_pipeOpenedPanel1.text = "Congratulations!";
            _P_site3_pipeOpenedPanel1.text = _L_site3_pipeOpenedPanel1.text;
            _L_site3_pipeOpenedPanel2.text = "You have successfully configured the pipe network to bring drinking water to your home.\n\nIn Dutch homes, drinking water is used for many different activities. Showering, for example, is the biggest water user.";
            _P_site3_pipeOpenedPanel2.text = _L_site3_pipeOpenedPanel2.text;
            //info to multichoice panel 1
            _L_site3_infoToMultichoicePanel11.text = "Household drinking water consumption by application in the Netherlands";
            _P_site3_infoToMultichoicePanel11.text = _L_site3_infoToMultichoicePanel11.text;
            _L_site3_infoToMultichoicePanel12.text = "Showering 41%";
            _P_site3_infoToMultichoicePanel12.text = _L_site3_infoToMultichoicePanel12.text;
            _L_site3_infoToMultichoicePanel13.text = "Toilet flushing 29%";
            _P_site3_infoToMultichoicePanel13.text = _L_site3_infoToMultichoicePanel13.text;
            _L_site3_infoToMultichoicePanel14.text = "Washing laundry 13%";
            _P_site3_infoToMultichoicePanel14.text = _L_site3_infoToMultichoicePanel14.text;
            _L_site3_infoToMultichoicePanel15.text = "Washing dishes 13%";
            _P_site3_infoToMultichoicePanel15.text = _L_site3_infoToMultichoicePanel15.text;
            _L_site3_infoToMultichoicePanel16.text = "Hand washing 3%";
            _P_site3_infoToMultichoicePanel16.text = _L_site3_infoToMultichoicePanel16.text;
            _L_site3_infoToMultichoicePanel17.text = "Drinking coffee, tea and water 1%";
            _P_site3_infoToMultichoicePanel17.text = _L_site3_infoToMultichoicePanel17.text;
            _L_site3_infoToMultichoicePanel18.text = "Preparing food 1%";
            _P_site3_infoToMultichoicePanel18.text = _L_site3_infoToMultichoicePanel18.text;
            _L_site3_infoToMultichoicePanel19.text = "Other 6%";
            _P_site3_infoToMultichoicePanel19.text = _L_site3_infoToMultichoicePanel19.text;
            //info between panel
            _L_site3_infoBetweenPanel.text = "Did you know that using drinking water is also connected to a large part of energy consumption in your home. \n\nOn average, 20% of the energy used in your home is to heat drinking water (cooking, showering). Of this hot water, 80% of this is used for showering.";
            _P_site3_infoBetweenPanel.text = "Did you know that using drinking water is also connected to a large part of energy consumption in your home. \n\n\nOn average, 20% of the energy used in your home is to heat drinking water (cooking, showering). Of this hot water, 80% of this is used for showering.";
            //info to multichoice panel 2
            _L_site3_infoToMultichoicePanel21.text = "Average household energy use in the Netherlands";
            _P_site3_infoToMultichoicePanel21.text = _L_site3_infoToMultichoicePanel21.text;
            _L_site3_infoToMultichoicePanel22.text = "Heating 75%";
            _P_site3_infoToMultichoicePanel22.text = _L_site3_infoToMultichoicePanel22.text;
            _L_site3_infoToMultichoicePanel23.text = "Hot water 20%";
            _P_site3_infoToMultichoicePanel23.text = _L_site3_infoToMultichoicePanel23.text;
            _L_site3_infoToMultichoicePanel24.text = "Cooking 5%";
            _P_site3_infoToMultichoicePanel24.text = _L_site3_infoToMultichoicePanel24.text;
            _L_site3_infoToMultichoicePanel25.text = "Showering 80%";
            _P_site3_infoToMultichoicePanel25.text = _L_site3_infoToMultichoicePanel25.text;
            _L_site3_infoToMultichoicePanel26.text = "Other uses 20%";
            _P_site3_infoToMultichoicePanel26.text = _L_site3_infoToMultichoicePanel26.text;
            _L_site3_infoToMultichoicePanel27.text = "Did you know that you can save water with a few simple water saving practices at home? This can help save on the use and cost of water and energy.";
            _P_site3_infoToMultichoicePanel27.text = _L_site3_infoToMultichoicePanel27.text;
            //multichoice panel 1
            _L_site3_multichoicePanel11.text = "Select what water saving practices can be used at your home to reduce the use of drinking water. (it is possible more than one answer is correct)";
            _P_site3_multichoicePanel11.text = _L_site3_multichoicePanel11.text;
            _L_site3_multichoicePanel12.text = "Collecting rain water for gardening";
            _P_site3_multichoicePanel12.text = _L_site3_multichoicePanel12.text;
            _L_site3_multichoicePanel13.text = "Spending less time in the shower";
            _P_site3_multichoicePanel13.text = _L_site3_multichoicePanel13.text;
            _L_site3_multichoicePanel14.text = "Keeping the tap on when brushing your teeth";
            _P_site3_multichoicePanel14.text = _L_site3_multichoicePanel14.text;
            _L_site3_multichoicePanel15.text = "Using your washing machine with few clothing items";
            _P_site3_multichoicePanel15.text = _L_site3_multichoicePanel15.text;
            _L_site3_multichoicePanel16.text = "Repair leaks  (e.g., leaking tap, running toilet)";
            _P_site3_multichoicePanel16.text = _L_site3_multichoicePanel16.text;
            //score update panel 1
            if(site3.GetComponent<Site3>().attempt < 2){
                _L_site3_scoreUpdatePanel12.text = "You lost 5 liters of water. You have one more attempt.";
                _P_site3_scoreUpdatePanel12.text = _L_site3_scoreUpdatePanel12.text;
            }else if(site3.GetComponent<Site3>().attempt == 2){
                _L_site3_scoreUpdatePanel12.text = "You can save water by collecting rainwater and using this for gardening, spending less time in the shower or repairing leaks. There are many other water saving practices that you can use.";
                _P_site3_scoreUpdatePanel12.text = _L_site3_scoreUpdatePanel12.text;
            }
            if(!site3.GetComponent<Site3>().correct){
                _L_site3_scoreUpdatePanel11.text = "Incorrect!";
                _P_site3_scoreUpdatePanel11.text = _L_site3_scoreUpdatePanel11.text;
            }else{
                _L_site3_scoreUpdatePanel11.text = "Correct!";
                _P_site3_scoreUpdatePanel11.text = _L_site3_scoreUpdatePanel11.text;
            }
            _L_site3_scoreUpdatePanel13.text = "Your current score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liters.";
            _P_site3_scoreUpdatePanel13.text = _L_site3_scoreUpdatePanel13.text;
            //multichoice panel 2
            _L_site3_multichoicePanel21.text = "After drinking water is used (e.g., for showering, flushing toilets) it disappears into the sewer. From that moment it is wastewater. What happens with this wastewater? (it is possible more than one answer is correct)";
            _P_site3_multichoicePanel21.text = _L_site3_multichoicePanel21.text;
            _L_site3_multichoicePanel22.text = "Directly disposed in the environment";
            _P_site3_multichoicePanel22.text = _L_site3_multichoicePanel22.text;
            _L_site3_multichoicePanel23.text = "First treated and then disposed back in the environment";
            _P_site3_multichoicePanel23.text = _L_site3_multichoicePanel23.text;
            _L_site3_multichoicePanel24.text = "Treated and then re-used";
            _P_site3_multichoicePanel24.text = _L_site3_multichoicePanel24.text;
            _L_site3_multichoicePanel25.text = "Nothing happens to the water after it is used";
            _P_site3_multichoicePanel25.text = _L_site3_multichoicePanel25.text;
            //score update panel 2
            if(site3.GetComponent<Site3>().attempt < 2){
                _L_site3_scoreUpdatePanel22.text = "You lost 5 liters of water. You have one more attempt.";
                _P_site3_scoreUpdatePanel22.text = _L_site3_scoreUpdatePanel22.text;
            }else if(site3.GetComponent<Site3>().attempt == 2){
                _L_site3_scoreUpdatePanel22.text = "After water is used, it is first treated before it is either put back in the environment or reused.";
                _P_site3_scoreUpdatePanel22.text = _L_site3_scoreUpdatePanel22.text;
            }
            if(!site3.GetComponent<Site3>().correct){
                _L_site3_scoreUpdatePanel21.text = "Incorrect!";
                _P_site3_scoreUpdatePanel21.text = _L_site3_scoreUpdatePanel21.text;
            }else{
                _L_site3_scoreUpdatePanel21.text = "Correct!";
                _P_site3_scoreUpdatePanel21.text = _L_site3_scoreUpdatePanel21.text;
            }
            _L_site3_scoreUpdatePanel23.text = "Your current score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liters.";
            _P_site3_scoreUpdatePanel23.text = _L_site3_scoreUpdatePanel23.text;
        }


        //---------------------site4--------------------------------------
        if(site4.activeSelf){
            //welcome panel 1
            _L_site4_welcomePanel11.text = "Welcome to the wastewater treatment plant!";
            _P_site4_welcomePanel11.text = _L_site4_welcomePanel11.text;
            _L_site4_welcomePanel12.text = "After you have used the drinking water in your home, sewer pipes bring the wastewater (used water) to a treatment plant.\n\nIn the Netherlands the municipality and the water boards share the responsibility of managing the wastewater. The municipality takes care of collection and transportation, while the water boards take care of the purification (treatment).";
            _P_site4_welcomePanel12.text = _L_site4_welcomePanel12.text;
            //welcome panel 2
            _L_site4_welcomePanel21.text = "Welcome to the wastewater treatment plant!";
            _P_site4_welcomePanel21.text = _L_site4_welcomePanel21.text;
            _L_site4_welcomePanel22.text = "Wastewater can be treated with multiple benefits.\n\nIn the next challenge, you will be presented with a number of statements on the benefits of treated wastewater. Identify which statements are true or false. For each incorrect answer you lose 5 litres of water.\n\nGood luck!";
            _P_site4_welcomePanel22.text = "Wastewater can be treated with multiple benefits.\n\n\nIn the next challenge, you will be presented with a number of statements on the benefits of treated wastewater. Identify which statements are true or false. For each incorrect answer you lose 5 litres of water.\n\n\nGood luck!";
            //statement panel
            site4.GetComponent<Site4>().changeLanguage();
            //after statements panel
            _L_site4_afterStatementsPanel1.text = "Congratulations!";
            _P_site4_afterStatementsPanel1.text = _L_site4_afterStatementsPanel1.text;
            _L_site4_afterStatementsPanel2.text = "You have been awarded with the final 3 components of the water system.";
            _P_site4_afterStatementsPanel2.text = _L_site4_afterStatementsPanel2.text;
            _L_site4_afterStatementsPanel3.text = "• Wastewater treatment plant\n• Sewer pipe\n• Water source (e.g., laker, river)";
            _P_site4_afterStatementsPanel3.text = _L_site4_afterStatementsPanel3.text;
            _L_site4_afterStatementsPanel4.text = "In your next challenge, you will need to put the components in the correct order to help with treating the wastewater and returning the treated water back in the water system.\nGood luck!";
            _P_site4_afterStatementsPanel4.text = "In your next challenge, you will need to put the components in the correct order to help with treating the wastewater and returning the treated water back in the water system.\n\nGood luck!";
            //task panel
            _L_site4_taskPanel1.text = "Put the components for this part of the system in the correct order for treating wastewater and retuning the treated water back into the water system (such as a lake or river). You can move components by dragging.";
            _P_site4_taskPanel1.text = _L_site4_taskPanel1.text;
            _L_site4_taskPanel2.text = "Wastewater treatment plant";
            _P_site4_taskPanel2.text = _L_site4_taskPanel2.text;
            _L_site4_taskPanel3.text = "Sewer pipe";
            _P_site4_taskPanel3.text = _L_site4_taskPanel3.text;
            _L_site4_taskPanel4.text = "Lake";
            _P_site4_taskPanel4.text = _L_site4_taskPanel4.text;
            //score update panel
            _L_site4_scoreUpdatePanel2.text = "The correct order is: Sewer pipe (to transport the dirty water), Wastewater treatment plant (to treat the used water) and Water source (laker, river) (to receive the clean water).";
            _P_site4_scoreUpdatePanel2.text = _L_site4_scoreUpdatePanel2.text;
            _L_site4_scoreUpdatePanel3.text = "You lost 10 litres of water.";
            _P_site4_scoreUpdatePanel3.text = _L_site4_scoreUpdatePanel3.text;
            if(site4UI.GetComponent<Site4UI>().failed){
                _L_site4_scoreUpdatePanel1.text = "Incorrect!";
                _P_site4_scoreUpdatePanel1.text = _L_site4_scoreUpdatePanel1.text;
            }else{
                _L_site4_scoreUpdatePanel1.text = "Correct!";
                _P_site4_scoreUpdatePanel1.text = _L_site4_scoreUpdatePanel1.text;
            }
            _L_site4_scoreUpdatePanel4.text = "Your current score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liters.";
            _P_site4_scoreUpdatePanel4.text = _L_site4_scoreUpdatePanel4.text;
        }


        //---------------------site5--------------------------------------
        if(site5.activeSelf){
            //welcome panel
            _L_site5_welcomePanel1.text = "Welcome to the environment!";
            _P_site5_welcomePanel1.text = _L_site5_welcomePanel1.text;
            _L_site5_welcomePanel2.text = "In the previous challenge, you were told how wastewater can be put back in the environment.  It is important that the wastewater is treated before it is put back in the environment. \n\nThis is done to limit the possibility of water related pollutants entering the environment.";
            _P_site5_welcomePanel2.text = _L_site5_welcomePanel2.text;
            //multichoice panel
            _L_site5_multichoicePanel1.text = "Select water related pollutants that can enter the environment? (it is possible more than one answer is correct)";
            _P_site5_multichoicePanel1.text = _L_site5_multichoicePanel1.text;
            _L_site5_multichoicePanel2.text = "Plastic materials";
            _P_site5_multichoicePanel2.text = _L_site5_multichoicePanel2.text;
            _L_site5_multichoicePanel3.text = "Pesticides";
            _P_site5_multichoicePanel3.text = _L_site5_multichoicePanel3.text;
            _L_site5_multichoicePanel4.text = "Pharmaceutical and hormones";
            _P_site5_multichoicePanel4.text = _L_site5_multichoicePanel4.text;
            _L_site5_multichoicePanel5.text = "Bacteria";
            _P_site5_multichoicePanel5.text = _L_site5_multichoicePanel5.text;
            //score update panel
            if(site5.GetComponent<Site5>().attempt < 2){
                _L_site5_scoreUpdatePanel2.text = "You lost 5 liters of water. You have one more attempt.";
                _P_site5_scoreUpdatePanel2.text = _L_site5_scoreUpdatePanel2.text;
            }else if(site5.GetComponent<Site5>().attempt == 2){
                _L_site5_scoreUpdatePanel2.text = "The correct pollutants are: Plastic materials, Pesticides, Pharmaceutical and hormones, Bacteria.";
                _P_site5_scoreUpdatePanel2.text = _L_site5_scoreUpdatePanel2.text;
            }
            if(!site5.GetComponent<Site5>().correct){
                _L_site5_scoreUpdatePanel1.text = "Incorrect!";
                _P_site5_scoreUpdatePanel1.text = _L_site5_scoreUpdatePanel1.text;
            }else{
                _L_site5_scoreUpdatePanel1.text = "Correct!";
                _P_site5_scoreUpdatePanel1.text = _L_site5_scoreUpdatePanel1.text;
            }
            _L_site5_scoreUpdatePanel3.text = "Your current score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liters";
            _P_site5_scoreUpdatePanel3.text = _L_site5_scoreUpdatePanel3.text;
            //info panel 1
            _L_site5_infoPanel1.text = "Due to pollution from human activities, drinking water sources in the Netherlands are at serious risk.\n\nClimate change is also introducing new threats to the quality of water sources, which has an impact on producing drinking water.\n\nIn the Netherlands, laws are in place to protect the quality of groundwater and surface water sources.";
            _P_site5_infoPanel1.text = _L_site5_infoPanel1.text;
            //thank you panel
            _L_site5_thankYouPanel1.text = "Thank you for playing\nWater-kennis!";
            _P_site5_thankYouPanel1.text = _L_site5_thankYouPanel1.text;
            _L_site5_thankYouPanel2.text = "You have successfully navigated through the water system from the source, to distribution, to treatment of used water and finally putting the treated water back into the environment.\n\nWe hope the experience was both educational and fun.";
            _P_site5_thankYouPanel2.text = _L_site5_thankYouPanel2.text;
            //info panel 2
            _L_site5_infoPanel21.text = "Having gone through the various challenges, you were able to keep " + gameController.GetComponent<gameController>().score.ToString() + " litres of your total drinking water budget.";
            _P_site5_infoPanel21.text = _L_site5_infoPanel21.text;
            _L_site5_infoPanel22.text = "In the Netherlands, the average person uses 120 litres of water per day for different activities (e.g.,  showering, flushing, washing, food preparation)";
            _P_site5_infoPanel22.text = _L_site5_infoPanel22.text;
            //spend water panel
            _L_site5_spendWaterPanel1.text = "How would you spend your remaining daily drinking water budget of " + gameController.GetComponent<gameController>().score.ToString() +" litres?";
            _P_site5_spendWaterPanel1.text = _L_site5_spendWaterPanel1.text;
            _L_site5_spendWaterPanel2.text = "Taking a shower (50 L)";
            _P_site5_spendWaterPanel2.text = _L_site5_spendWaterPanel2.text;
            _L_site5_spendWaterPanel3.text = "Flushing your toilet (35 L)";
            _P_site5_spendWaterPanel3.text = _L_site5_spendWaterPanel3.text;
            _L_site5_spendWaterPanel4.text = "Washing your laundry (15 L)";
            _P_site5_spendWaterPanel4.text = _L_site5_spendWaterPanel4.text;
            _L_site5_spendWaterPanel5.text = "Washing your hands (5 L)";
            _P_site5_spendWaterPanel5.text = _L_site5_spendWaterPanel5.text;
            _L_site5_spendWaterPanel6.text = "Washing your dishes (5 L)";
            _P_site5_spendWaterPanel6.text = _L_site5_spendWaterPanel6.text;
            _L_site5_spendWaterPanel7.text = "Preparing food (2 L)";
            _P_site5_spendWaterPanel7.text = _L_site5_spendWaterPanel7.text;
            _L_site5_spendWaterPanel8.text = "Drinking tap water (1 L)";
            _P_site5_spendWaterPanel8.text = _L_site5_spendWaterPanel8.text;
            _L_site5_spendWaterPanel9.text = "Preparing coffee and tea (1 L)";
            _P_site5_spendWaterPanel9.text = _L_site5_spendWaterPanel9.text;
            _L_site5_spendWaterPanel10.text = "Doing other activities (e.g., watering your plants, cleaning your windows) (6 L)";
            _P_site5_spendWaterPanel10.text = _L_site5_spendWaterPanel10.text;
            site5.GetComponent<Site5>().updateTankText();
            //end panel
            _L_site5_endPanel1.text = "•\tExit the app";
            _P_site5_endPanel1.text = "• Exit the app";
            _L_site5_endPanel2.text = "•\tReplay the game";
            _P_site5_endPanel2.text = "• Replay the game";
            _L_site5_endPanel3.text = "•\tLink to KWR page: \n\n<link=\"ID\">https://www.kwrwater.nl/en/projecten/water-kennis-an-immersive-media-experience/</link>";
            _P_site5_endPanel3.text = "• Link to KWR page: \n\n<link=\"ID\">https://www.kwrwater.nl/en/projecten/water-kennis-an-immersive-media-experience/</link>";
        }
    }
}
