using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Site4UI : MonoBehaviour
{
    public GameObject wwtp_image_L, sewer_pipe_image_L, lake_image_L, wwtp_image_P, sewer_pipe_image_P, lake_image_P;
    public GameObject wwtp_image, sewer_pipe_image, lake_image, site4UI, site4, taskPanel, taskPanel_L, taskPanel_P, scoreUpdatePanel2;
    public GameObject anchors_portrait, anchors_landscape;
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
    public bool failed;

    public TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        order = new int[3];
        correct_order = new int[3];
        swap_distance = 100f;

        animate = false;
        //ordering
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

    public void setImages(int wwtp, int sewer_pipe, int lake, string screen){
        // wwtp 0, sewer pipe 1, lake 2
        order[0] = wwtp;
        order[1] = sewer_pipe;
        order[2] = lake;
        
        correct_order[0] = 2;
        correct_order[1] = 1;
        correct_order[2] = 3;

        if(screen == "portrait"){
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = false;
        }
        if(screen == "landscape"){
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
        }

        orientation = screen;
        if(orientation == "portrait"){
            taskPanel_P.SetActive(true);
            taskPanel_L.SetActive(false);
            parent = anchors_portrait;
            wwtp_image = wwtp_image_P;
            sewer_pipe_image = sewer_pipe_image_P;
            lake_image = lake_image_P;
        }else{
            taskPanel_P.SetActive(false);
            taskPanel_L.SetActive(true);
            parent = anchors_landscape;
            wwtp_image = wwtp_image_L;
            sewer_pipe_image = sewer_pipe_image_L;
            lake_image = lake_image_L;
        }

        wwtp_image.transform.SetParent(parent.transform.GetChild(order[0] - 1).transform, true);
        sewer_pipe_image.transform.SetParent(parent.transform.GetChild(order[1] - 1).transform, true);
        lake_image.transform.SetParent(parent.transform.GetChild(order[2] - 1).transform, true);

        wwtp_image.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        wwtp_image.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        sewer_pipe_image.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        sewer_pipe_image.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        lake_image.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        lake_image.GetComponent<RectTransform>().offsetMax = Vector2.zero;
    }

    public void ok_taskPanel_bttn(){
        taskPanel.SetActive(false);
        scoreUpdatePanel2.SetActive(true);
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        float oldScore = (float)gameController.GetComponent<gameController>().score;

        if(order[0] == correct_order[0] && order[1] == correct_order[1] && order[2] == correct_order[2]){
            failed = false;
            lostText_L.gameObject.SetActive(false);
            lostText_P.gameObject.SetActive(false);
            if(dropdown.value == 0){
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

    void relocate_picture(GameObject picture, Transform parent){
        picture.transform.SetParent(parent.transform, true);
        picture.transform.SetParent(parent.transform, true);
        picture.transform.SetAsLastSibling();
        
        picture.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        picture.GetComponent<RectTransform>().offsetMax = Vector2.zero;
    }

    public void drag_wwtp(){
        wwtp_image.transform.position = Input.mousePosition;
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

    public void endDrag_wwtp(){
        int this_index = 0;
        bool swaped = false;
        for (int i = 0; i < order.Length; i++)
            if(parent.transform.GetChild(order[i] - 1).transform.childCount == 0){
                swaped = true;
                relocate_picture(wwtp_image, parent.transform.GetChild(order[i] - 1));
                int temp = order[i];
                order[i] = order[this_index];
                order[this_index] = temp;
            }
        if(!swaped){
            wwtp_image.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            wwtp_image.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        }
    }

    public void drag_sewer_pipe(){
        sewer_pipe_image.transform.position = Input.mousePosition;
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

    public void endDrag_sewer_pipe(){
        int this_index = 1;
        bool swaped = false;

        for (int i = 0; i < order.Length; i++)
            if(parent.transform.GetChild(order[i] - 1).transform.childCount == 0){
                swaped = true;
                relocate_picture(sewer_pipe_image, parent.transform.GetChild(order[i] - 1));
                int temp = order[i];
                order[i] = order[this_index];
                order[this_index] = temp;
            }
        if(!swaped){
            sewer_pipe_image.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            sewer_pipe_image.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        }
    }

    public void drag_lake(){
        lake_image.transform.position = Input.mousePosition;
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

    public void endDrag_lake(){
        int this_index = 2;
        bool swaped = false;

        for (int i = 0; i < order.Length; i++)
            if(parent.transform.GetChild(order[i] - 1).transform.childCount == 0){
                swaped = true;
                relocate_picture(lake_image, parent.transform.GetChild(order[i] - 1));
                int temp = order[i];
                order[i] = order[this_index];
                order[this_index] = temp;
            }
        if(!swaped){
            lake_image.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            lake_image.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        }
    }
}
