using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
public string enemy_id;
public float move_speed; 
public float Durability;
public float attack_damage; 
public float attack_speed; 
float attack_timer;
public GameObject bullet_obj;

Vector2 dir;

void Start(){
    dir = (GameObject.Find("Player").transform.position-this.transform.position).normalized;
}
void Update(){
    EnemyMove();
    EnemyAttack();
}
void EnemyMove(){
    switch(enemy_id){
        case "A" :
            transform.Translate(Vector2.down * move_speed * Time.deltaTime);
        break;
        case "B" :
            transform.Translate(Vector2.down * move_speed * Time.deltaTime);
        break;
        case "C" :
            transform.Translate(dir * move_speed * Time.deltaTime);
        break;
    }
    
}
void EnemyAttack(){
    //an automatic attack
    float delay = 1.0f/attack_speed;
    attack_timer += Time.deltaTime;
    if(attack_timer >= delay){
        BulletSetup(enemy_id);
        Instantiate(bullet_obj, transform.position, Quaternion.identity);
        attack_timer = 0;
    }
}
void BulletSetup(string type){
    switch(type){
        case "A" :
            bullet_obj.GetComponent<SpriteRenderer>().sprite = bullet_obj.GetComponent<Bullet>().bullet_Image[4];
            bullet_obj.GetComponent<Bullet>().bullet_damage = attack_damage;
            bullet_obj.GetComponent<Bullet>().bullet_direction = Vector2.down;
            bullet_obj.GetComponent<Bullet>().bullet_speed = 5.0f;
            bullet_obj.GetComponent<Bullet>().is_enemy_bullet = true;
            bullet_obj.GetComponent<Bullet>().bullet_type = "A";
        break;
        case "B" :
            //Null
        break;
        case "C" :
            bullet_obj.GetComponent<SpriteRenderer>().sprite = bullet_obj.GetComponent<Bullet>().bullet_Image[6];
            bullet_obj.GetComponent<Bullet>().bullet_damage = attack_damage;
            bullet_obj.GetComponent<Bullet>().bullet_direction = (GameObject.Find("Player").transform.position-this.transform.position).normalized;
            bullet_obj.GetComponent<Bullet>().bullet_speed = 1.5f;
            bullet_obj.GetComponent<Bullet>().is_enemy_bullet = true;
            bullet_obj.GetComponent<Bullet>().bullet_type = "B";
            
        break;
    }
    
}
void OnTriggerEnter2D(Collider2D other){
    if(other.gameObject.tag == "Border") Destroy(this.gameObject);
    else if(other.gameObject.tag == "Player"){
        Destroy(this.gameObject);
        other.gameObject.GetComponent<Player>().Durability -= attack_damage;
        if(other.gameObject.GetComponent<Player>().Durability <= 0){
            Destroy(other.gameObject);
        }
    }
}

}
