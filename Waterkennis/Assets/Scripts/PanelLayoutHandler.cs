using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLayoutHandler : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject map;

    void Start()
    {
        restart();
        // panels[15].SetActive(true);
    }

    public void restart(){
        foreach(GameObject panel in panels)
            panel.SetActive(false);
        //welcome panel
        panels[3].SetActive(true);
        // panels[8].SetActive(true);
        // panels[15].SetActive(true);
        // panels[33].SetActive(true);
        // panels[40].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject panel in panels){
            if(panel.activeSelf){
                if(Screen.orientation == ScreenOrientation.Portrait){
                    if(panel.transform.GetChild(0).gameObject.activeSelf)
                        panel.transform.GetChild(0).gameObject.SetActive(false);
                    if(!panel.transform.GetChild(1).gameObject.activeSelf)
                        panel.transform.GetChild(1).gameObject.SetActive(true);
                }else{
                    if(!panel.transform.GetChild(0).gameObject.activeSelf)
                        panel.transform.GetChild(0).gameObject.SetActive(true);
                    if(panel.transform.GetChild(1).gameObject.activeSelf)
                        panel.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        }
    }
}
