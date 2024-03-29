using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
public string bullet_type;
public Sprite[] bullet_Image;  //0~2:player, 3~6:enemy
public Vector3 bullet_direction;  //방향
public float bullet_speed;  //속도
public float bullet_damage;  //공격력
public bool is_enemy_bullet;


void Update(){
    BulletMove();
}

void BulletMove(){
    transform.Translate(bullet_direction * bullet_speed * Time.deltaTime);
}
void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.tag == "Border") Destroy(this.gameObject);

    if(!is_enemy_bullet){
        if(other.gameObject.tag == "Enemy"){
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Enemy>().Durability -= bullet_damage;
            if(other.gameObject.GetComponent<Enemy>().Durability <= 0){
                switch(other.gameObject.GetComponent<Enemy>().enemy_id){
                    case "A" :
                        GameObject.Find("Player").GetComponent<Player>().score += 50;
                    break;
                    case "B" :
                        GameObject.Find("Player").GetComponent<Player>().score += 100;
                    break;
                    case "C" :
                        GameObject.Find("Player").GetComponent<Player>().score += 200;
                    break;
                }
                Destroy(other.gameObject);
            }
        }
    }
    else if(is_enemy_bullet){
        if(other.gameObject.tag == "Player"){
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Player>().Durability -= bullet_damage;
            if(other.gameObject.GetComponent<Player>().Durability <= 0){
                Destroy(other.gameObject);
            }
        }
    }
    else{

    }
}
}
