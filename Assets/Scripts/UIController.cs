using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  //추가하세요

public class UIController : MonoBehaviour
{
    Player player;
    public Text score_text;
    //public Text durability_text;
    public GameObject[] durability_image;

    public GameObject gameover_ui_group;

    

    void Start(){
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update(){
        //Player
        score_text.text = player.score.ToString();
        switch(player.Durability){
            case 6:
                for(int i = 0; i < 3; i++) durability_image[i].SetActive(true);
            break;
            case 5:
                for(int i = 0; i < 3; i++) durability_image[i].SetActive(true);
                durability_image[2].GetComponent<Image>().fillAmount = 0.5f;
            break;
            case 4:
                for(int i = 0; i < 2; i++) durability_image[i].SetActive(true);
                durability_image[2].SetActive(false);
            break;
            case 3:
                for(int i = 0; i < 2; i++) durability_image[i].SetActive(true);
                durability_image[1].GetComponent<Image>().fillAmount = 0.5f;
                durability_image[2].SetActive(false);
            break;
            case 2:
                durability_image[0].SetActive(true);
                durability_image[1].SetActive(false);
                durability_image[2].SetActive(false);
            break;
            case 1:
                durability_image[0].SetActive(true);
                durability_image[0].GetComponent<Image>().fillAmount = 0.5f;
                durability_image[1].SetActive(false);
                durability_image[2].SetActive(false);
            break;
            default:
                durability_image[0].SetActive(false);
                durability_image[1].SetActive(false);
                durability_image[2].SetActive(false);
            break;
        }
        //GameOver
        if(player.Durability <= 0 && !gameover_ui_group.activeInHierarchy){
            gameover_ui_group.SetActive(true);
        }

        //GameClear

        
            
        //Boss
    }
}
