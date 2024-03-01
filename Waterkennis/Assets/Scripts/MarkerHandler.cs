using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MarkerHandler : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;
    private Vector2 touchPosition = default;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private ARRaycastManager arRaycastManager;

    public GameObject site1, site1UI, site2, site2UI, site3, site3UI, site4, site4UI, site5, site5UI, back_button, showMap_button,
    help_button, app, wrongSitePanel, gameController, LanguageChanger;
    private bool site2clicked, site3clicked, site4clicked, site5clicked;

    public TMP_Dropdown dropdown;

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        restart();
    }

    public void restart(){
        site2clicked = false;
        site3clicked = false;
        site4clicked = false;
        site5clicked = false;
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touchPosition);
                RaycastHit hitObject;

                if (Physics.Raycast(ray, out hitObject))
                {
                    if(hitObject.collider.tag=="site2"){
                        if(app.GetComponent<App>().nextSite_index == 2){
                            if(!site2clicked){
                                app.GetComponent<App>().siteOn = true;
                                site2clicked = true;
                                site2.SetActive(true);
                                site2UI.SetActive(true);
                                back_button.gameObject.SetActive(false);
                                showMap_button.gameObject.SetActive(false);
                                help_button.gameObject.SetActive(false);
                                site2.transform.position = hitObject.point;
                                site2.GetComponent<Site2>().startSite();
                                gameController.GetComponent<gameController>().currentSite_index = 1;
                                if(dropdown.value == 0){
                                    //english
                                    LanguageChanger.GetComponent<LanguageChanger>().changetoEnglish();
                                }else{
                                    //dutch
                                    LanguageChanger.GetComponent<LanguageChanger>().changetoDutch();
                                }
                                //status panel
                                gameController.GetComponent<gameController>().sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(2).gameObject.SetActive(false);

                                gameController.GetComponent<gameController>().sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(2).gameObject.SetActive(false);
                            }
                        }else if(!app.GetComponent<App>().siteOn){
                            wrongSitePanel.SetActive(true);
                        }
                    }
                    if(hitObject.collider.tag=="site3"){
                        if(app.GetComponent<App>().nextSite_index == 3){
                            if(!site3clicked){
                                app.GetComponent<App>().siteOn = true;
                                site3clicked = true;
                                site3.SetActive(true);
                                site3UI.SetActive(true);
                                back_button.gameObject.SetActive(false);
                                showMap_button.gameObject.SetActive(false);
                                help_button.gameObject.SetActive(false);
                                site3.transform.position = hitObject.point;
                                site3.GetComponent<Site3>().startSite();
                                gameController.GetComponent<gameController>().currentSite_index = 2;
                                if(dropdown.value == 0){
                                    //english
                                    LanguageChanger.GetComponent<LanguageChanger>().changetoEnglish();
                                }else{
                                    //dutch
                                    LanguageChanger.GetComponent<LanguageChanger>().changetoDutch();
                                }
                                //status panel
                                gameController.GetComponent<gameController>().sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(2).gameObject.SetActive(false);

                                gameController.GetComponent<gameController>().sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(2).gameObject.SetActive(false);
                            }
                        }else if(!app.GetComponent<App>().siteOn){
                            wrongSitePanel.SetActive(true);
                        }
                    }
                    if(hitObject.collider.tag=="site4"){
                        if(app.GetComponent<App>().nextSite_index == 4){
                            if(!site4clicked){
                                app.GetComponent<App>().siteOn = true;
                                site4clicked = true;
                                site4.SetActive(true);
                                site4UI.SetActive(true);
                                back_button.gameObject.SetActive(false);
                                showMap_button.gameObject.SetActive(false);
                                help_button.gameObject.SetActive(false);
                                site4.transform.position = hitObject.point;
                                site4.GetComponent<Site4>().startSite();
                                gameController.GetComponent<gameController>().currentSite_index = 3;
                                if(dropdown.value == 0){
                                    //english
                                    LanguageChanger.GetComponent<LanguageChanger>().changetoEnglish();
                                }else{
                                    //dutch
                                    LanguageChanger.GetComponent<LanguageChanger>().changetoDutch();
                                }
                                //status panel
                                gameController.GetComponent<gameController>().sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(2).gameObject.SetActive(false);

                                gameController.GetComponent<gameController>().sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(2).gameObject.SetActive(false);
                            }
                        }else if(!app.GetComponent<App>().siteOn){
                            wrongSitePanel.SetActive(true);
                        }
                    }
                    if(hitObject.collider.tag=="site5"){
                        if(app.GetComponent<App>().nextSite_index == 5){
                            if(!site5clicked){
                                app.GetComponent<App>().siteOn = true;
                                site5clicked = true;
                                site5.SetActive(true);
                                site5UI.SetActive(true);
                                back_button.gameObject.SetActive(false);
                                showMap_button.gameObject.SetActive(false);
                                help_button.gameObject.SetActive(false);
                                site5.transform.position = hitObject.point;
                                site5.GetComponent<Site5>().startSite();
                                gameController.GetComponent<gameController>().currentSite_index = 4;
                                if(dropdown.value == 0){
                                    //english
                                    LanguageChanger.GetComponent<LanguageChanger>().changetoEnglish();
                                }else{
                                    //dutch
                                    LanguageChanger.GetComponent<LanguageChanger>().changetoDutch();
                                }
                                //status panel
                                gameController.GetComponent<gameController>().sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(2).gameObject.SetActive(false);

                                gameController.GetComponent<gameController>().sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
                                gameController.GetComponent<gameController>().sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(2).gameObject.SetActive(false);
                            }
                        }else if(!app.GetComponent<App>().siteOn){
                            wrongSitePanel.SetActive(true);
                        }
                    }
                }
            } 
        }
    }
}
