using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameController : MonoBehaviour
{
    public float score;
    public float maxScore = 120;
    
    public TextMeshProUGUI scoreText_L, scoreText_P;
    public int[] scoreLost;
    public GameObject[] sites_L, sites_P;
    public GameObject app;
    public TMP_Dropdown dropdown;
    public int currentSite_index;

    void Start()
    {
        scoreLost = new int[5];
        restart();
        if(app.GetComponent<App>().nextSite_index != 1 && app.GetComponent<App>().nextSite_index != 5){
            sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
            sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(2).gameObject.SetActive(false);

            sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
            sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(2).gameObject.SetActive(false);
        }else{
            sites_L[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);

            sites_P[app.GetComponent<App>().nextSite_index - 1].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
        }
    }

    public void restart(){
        score = maxScore;
        for (int i = 0; i < 5; i++){
            if(dropdown.value == 0){
                //english
                sites_L[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters lost: 0";
                sites_P[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters lost: 0";
                if(i == 4){
                    sites_L[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Not visited yet";
                    sites_P[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Not visited yet";
                }
            }else{
                //dutch
                sites_L[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters\nkwijtgeraakt: 0";
                sites_P[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters\nkwijtgeraakt: 0";
                if(i == 4){
                    sites_L[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Nog niet bezocht";
                    sites_P[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Nog niet bezocht";
                }
            }
            scoreLost[i] = 0;
            if(i != 0 && i != 4){
                sites_L[i].transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
                sites_L[i].transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
                sites_L[i].transform.GetChild(2).GetChild(2).gameObject.SetActive(true);
                sites_L[i].transform.GetChild(2).GetChild(3).gameObject.SetActive(false);

                sites_P[i].transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
                sites_P[i].transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
                sites_P[i].transform.GetChild(2).GetChild(2).gameObject.SetActive(true);
                sites_P[i].transform.GetChild(2).GetChild(3).gameObject.SetActive(false);
                
                if(dropdown.value ==0){
                    //english
                    sites_L[i].transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = "Not visited yet";
                    sites_P[i].transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = "Not visited yet";
                }else{
                    //dutch
                    sites_L[i].transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = "Nog niet bezocht";
                    sites_P[i].transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = "Nog niet bezocht";
                }
            }
        }
        sites_L[0].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
        sites_P[0].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
    }

    public void updateStatus(int lost, bool gotComponents, bool language){
        // int currentSite_index = app.GetComponent<App>().nextSite_index - 1;
        scoreLost[currentSite_index] += lost;
        if(dropdown.value == 0){
            //english
            scoreText_L.text = "Your current score: " + score.ToString() + " liters";
            scoreText_P.text = "Your current score:\n" + score.ToString() + " liters";
            sites_L[currentSite_index].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters lost: " + scoreLost[currentSite_index].ToString();
            sites_P[currentSite_index].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters lost: " + scoreLost[currentSite_index].ToString();
        }else{
            //dutch
            scoreText_L.text = "Je huidige score: " + score.ToString() + " liter";
            scoreText_P.text = "Je huidige score:\n" + score.ToString() + " liter";
            if(currentSite_index == 0 || currentSite_index == 4){
                sites_L[currentSite_index].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters\nkwijtgeraakt: " + scoreLost[currentSite_index].ToString();
                sites_P[currentSite_index].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters\nkwijtgeraakt: " + scoreLost[currentSite_index].ToString();
            }else{
                sites_L[currentSite_index].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters kwijtgeraakt: " + scoreLost[currentSite_index].ToString();
                sites_P[currentSite_index].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters kwijtgeraakt: " + scoreLost[currentSite_index].ToString();
            }
        }

        if(gotComponents && !language){
            sites_L[currentSite_index].transform.GetChild(2).GetChild(3).gameObject.SetActive(true);
            sites_P[currentSite_index].transform.GetChild(2).GetChild(3).gameObject.SetActive(true);
        }

        if(language){
            for (int i = 0; i < 5; i++){
                if(i > currentSite_index){
                    if(dropdown.value ==0){
                        //english
                        if(i !=4 ){
                        sites_L[i].transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = "Not visited yet";
                        sites_P[i].transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = "Not visited yet";
                        }else{
                            sites_L[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Not visited yet";
                            sites_P[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Not visited yet";
                        }
                    }else{
                        //dutch
                        if(i != 4){
                        sites_L[i].transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = "Nog niet bezocht";
                        sites_P[i].transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = "Nog niet bezocht";
                        }else{
                            sites_L[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Nog niet bezocht";
                            sites_P[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Nog niet bezocht";
                        }
                    }
                }
                if(i != 0 && i <= currentSite_index && i != 4){
                    if(dropdown.value == 0){
                        sites_L[i].transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = "Components gained";
                        sites_P[i].transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = "Components gained";
                    }else{
                        sites_L[i].transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = "Ontvangen onderdelen";
                        sites_P[i].transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = "Ontvangen onderdelen";
                    }
                }
                if(i <= currentSite_index){
                    if(dropdown.value == 0){
                        sites_L[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters lost: " + scoreLost[i].ToString();
                        sites_P[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters lost: " + scoreLost[i].ToString();
                    }else{
                        if(i == 0 || i == 4){
                            sites_L[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters\nkwijtgeraakt: " + scoreLost[i].ToString();
                            sites_P[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters\nkwijtgeraakt: " + scoreLost[i].ToString();
                        }else{
                            sites_L[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters kwijtgeraakt: " + scoreLost[i].ToString();
                            sites_P[i].transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Liters kwijtgeraakt: " + scoreLost[i].ToString();
                        }
                    }
                }
            }
        }
    }

}
