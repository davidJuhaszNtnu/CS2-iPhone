using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Site3UI : MonoBehaviour
{
    public GameObject pipe_image_L, tap_image_L, pump_image_L, pipe_image_P, tap_image_P, pump_image_P;
    GameObject pipe_image, tap_image, pump_image;
    public GameObject anchors_portrait, anchors_landscape, taskPanel, taskPanel_L, taskPanel_P, taskCompletedPanel, site3;
    public Camera arCamera;

    int[] order;
    int[] correct_order;
    string orientation;
    GameObject parent;
    float swap_distance;

    bool animate;
    public GameObject tank_L, tank_P, droplet_L, droplet_P, gameController;
    float minLevel_P, minLevel_L, t, dt, oldLevel_P, newLevel_P, currentLevel_P, oldLevel_L, newLevel_L, currentLevel_L;
    public TextMeshProUGUI scoreText_L, scoreText_P, lostText_L, lostText_P, titleText_L, titleText_P;

    public TMP_Dropdown dropdown;
    public bool failed;

    void Start()
    {
        // pipe 0, tap 1, pump 2
        order = new int[3];
        correct_order = new int[3];
        swap_distance = 100f;
        // setImages(1, 2, "portrait");

        animate = false;
        // incorrect order
        float aspectRatio = (float)Screen.width/(float)Screen.height;
        if(Screen.orientation == ScreenOrientation.Portrait){
            minLevel_P = tank_P.GetComponent<RectTransform>().rect.height * 0.95f;
            minLevel_L = tank_L.GetComponent<RectTransform>().rect.height * 0.95f * aspectRatio;
        }else{
            minLevel_L = tank_L.GetComponent<RectTransform>().rect.height * 0.95f;
            minLevel_P = tank_P.GetComponent<RectTransform>().rect.height * 0.95f * aspectRatio;
        }

        droplet_L.SetActive(false);
        droplet_P.SetActive(false);
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

    public void restart(){
        animate = false;
        droplet_L.SetActive(false);
        droplet_P.SetActive(false);
    }

    void Update(){
        if(animate)
            animateWaterLevel();
    }

    public void setImages(int pipe, int tap, int pump, string screen){
        // pipe 0, tap 1, pump 2
        order[0] = pipe;
        order[1] = tap;
        order[2] = pump;

        correct_order[0] = 2;
        correct_order[1] = 3;
        correct_order[2] = 1;

        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = false;

        orientation = screen;
        if(orientation == "portrait"){
            parent = anchors_portrait;
            taskPanel_P.SetActive(true);
            taskPanel_L.SetActive(false);
            pipe_image = pipe_image_P;
            tap_image = tap_image_P;
            pump_image = pump_image_P;
        }else{
            parent = anchors_landscape;
            taskPanel_P.SetActive(false);
            taskPanel_L.SetActive(true);
            pipe_image = pipe_image_L;
            tap_image = tap_image_L;
            pump_image = pump_image_L;
        }

        pipe_image.transform.SetParent(parent.transform.GetChild(order[0] - 1).transform, true);
        tap_image.transform.SetParent(parent.transform.GetChild(order[1] - 1).transform, true);
        pump_image.transform.SetParent(parent.transform.GetChild(order[2] - 1).transform, true);

        pipe_image.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        pipe_image.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        tap_image.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        tap_image.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        pump_image.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        pump_image.GetComponent<RectTransform>().offsetMax = Vector2.zero;
    }

    public void ok_taskPanel_bttn(){
        taskPanel.SetActive(false);
        taskCompletedPanel.SetActive(true);
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = true;
        float oldScore = (float)gameController.GetComponent<gameController>().score;

        if(order[0] == correct_order[0] && order[1] == correct_order[1] && order[2] == correct_order[2]){
            failed = false;
            lostText_L.gameObject.SetActive(false);
            lostText_P.gameObject.SetActive(false);
            if(dropdown.value  == 0){
                titleText_L.text = "Correct!";
                titleText_P.text = titleText_L.text;
                scoreText_L.text = "Your current score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liters.";
                scoreText_P.text = scoreText_L.text;
            }else{
                titleText_L.text = "Juist!";
                titleText_P.text = titleText_L.text;
                scoreText_L.text = "Je huidige score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liter.";
                scoreText_P.text = scoreText_L.text;
            }
        }else{
            failed = true;
            //update water level in the tank
            gameController.GetComponent<gameController>().score -= 10;
            gameController.GetComponent<gameController>().updateStatus(10, false, false);
            lostText_L.gameObject.SetActive(true);
            lostText_P.gameObject.SetActive(true);
            if(dropdown.value == 0){
                titleText_L.text = "Incorrect!";
                titleText_P.text = titleText_L.text;
                scoreText_L.text = "Your current score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liters.";
                scoreText_P.text = scoreText_L.text;
            }else{
                titleText_L.text = "Onjuist!";
                titleText_P.text = titleText_L.text;
                scoreText_L.text = "Je huidige score is:\n" + gameController.GetComponent<gameController>().score.ToString() + " liter.";
                scoreText_P.text = scoreText_L.text;
            }
        }

        setupAnimationWaterLevel((float)gameController.GetComponent<gameController>().score, oldScore);
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

    public void ok_taskCompletedPanel_bttn(){
        taskCompletedPanel.SetActive(false);
        site3.GetComponent<Site3>().taskCompleted();
    }

    void relocate_picture(GameObject picture, Transform parent){
        picture.transform.SetParent(parent.transform, true);
        picture.transform.SetAsLastSibling();
        
        picture.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        picture.GetComponent<RectTransform>().offsetMax = Vector2.zero;
    }

    public void drag_pipe(){
        pipe_image.transform.position = Input.mousePosition;
        float distance;
        int this_index = 0;

        for (int i = 0; i < order.Length; i++){
            if(i != this_index){
                distance = Vector2.Distance(Input.mousePosition, parent.transform.GetChild(order[i] - 1).transform.position);
                if(distance < swap_distance){
                    if(parent.transform.GetChild(order[i] - 1).transform.childCount > 0)
                        relocate_picture(parent.transform.GetChild(order[i] - 1).transform.GetChild(0).gameObject, parent.transform.GetChild(order[this_index] - 1));
                }else if(parent.transform.GetChild(order[i] - 1).transform.childCount == 0)
                    relocate_picture(parent.transform.GetChild(order[this_index] - 1).transform.GetChild(1).gameObject, parent.transform.GetChild(order[i] - 1));
            }
        }
    }

    public void endDrag_pipe(){
        int this_index = 0;
        bool swaped = false;
        for (int i = 0; i < order.Length; i++)
            if(parent.transform.GetChild(order[i] - 1).transform.childCount == 0){
                swaped = true;
                relocate_picture(pipe_image, parent.transform.GetChild(order[i] - 1));
                int temp = order[i];
                order[i] = order[this_index];
                order[this_index] = temp;
            }
        if(!swaped){
            pipe_image.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            pipe_image.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        }
    }

    public void drag_tap(){
        tap_image.transform.position = Input.mousePosition;
        float distance;
        int this_index = 1;

        for (int i = 0; i < order.Length; i++){
            if(i != this_index){
                distance = Vector2.Distance(Input.mousePosition, parent.transform.GetChild(order[i] - 1).transform.position);
                if(distance < swap_distance){
                    if(parent.transform.GetChild(order[i] - 1).transform.childCount > 0)
                        relocate_picture(parent.transform.GetChild(order[i] - 1).transform.GetChild(0).gameObject, parent.transform.GetChild(order[this_index] - 1));
                }else if(parent.transform.GetChild(order[i] - 1).transform.childCount == 0)
                    relocate_picture(parent.transform.GetChild(order[this_index] - 1).transform.GetChild(1).gameObject, parent.transform.GetChild(order[i] - 1));
            }
        }
    }

    public void endDrag_tap(){
        bool swaped = false;
        int this_index = 1;

        for (int i = 0; i < order.Length; i++)
            if(parent.transform.GetChild(order[i] - 1).transform.childCount == 0){
                swaped = true;
                relocate_picture(tap_image, parent.transform.GetChild(order[i] - 1));
                int temp = order[i];
                order[i] = order[this_index];
                order[this_index] = temp;
            }
        if(!swaped){
            tap_image.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            tap_image.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        }
    }

    public void drag_pump(){
        pump_image.transform.position = Input.mousePosition;
        float distance;
        int this_index = 2;

        for (int i = 0; i < order.Length; i++){
            if(i != this_index){
                distance = Vector2.Distance(Input.mousePosition, parent.transform.GetChild(order[i] - 1).transform.position);
                if(distance < swap_distance){
                    if(parent.transform.GetChild(order[i] - 1).transform.childCount > 0)
                        relocate_picture(parent.transform.GetChild(order[i] - 1).transform.GetChild(0).gameObject, parent.transform.GetChild(order[this_index] - 1));
                }else if(parent.transform.GetChild(order[i] - 1).transform.childCount == 0)
                    relocate_picture(parent.transform.GetChild(order[this_index] - 1).transform.GetChild(1).gameObject, parent.transform.GetChild(order[i] - 1));
            }
        }
    }

    public void endDrag_pump(){
        bool swaped = false;
        int this_index = 2;

        for (int i = 0; i < order.Length; i++)
            if(parent.transform.GetChild(order[i] - 1).transform.childCount == 0){
                swaped = true;
                relocate_picture(pump_image, parent.transform.GetChild(order[i] - 1));
                int temp = order[i];
                order[i] = order[this_index];
                order[this_index] = temp;
            }
        if(!swaped){
            pump_image.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            pump_image.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        }
    }
}
