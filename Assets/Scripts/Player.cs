using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score;
    public float move_speed;  //이동 속도
    public float Durability;  //내구도(라이프 차감)
    public float attack_damage;  //공격력
    public float attack_speed;  //공격 속도
    public GameObject bullet_obj;
    float attack_timer = 10f;

    void PlayerMove(){
        int h= 0;
        int v = 0;
        Vector2 dir;

        if(Input.GetKey(KeyCode.A)){ 
            //Enter the LeftMoveCode here 
            h = -1;
            if(Input.GetKey(KeyCode.D)) h = 0;
        }
        if(Input.GetKey(KeyCode.D)){  
            //Enter the RightMoveCode here
            h = 1;
            if(Input.GetKey(KeyCode.A)) h = 0;
        }
        if(Input.GetKey(KeyCode.W)){  
            //Enter the UpMoveCode here 
            v = 1;
            if(Input.GetKey(KeyCode.S)) v = 0;
        }
        if(Input.GetKey(KeyCode.S)){  
            //Enter the DownMoveCode here
            v = -1;
            if(Input.GetKey(KeyCode.W)) v = 0;
        }
        dir = new Vector2(h,v).normalized;
        transform.Translate(dir * move_speed * Time.deltaTime);
    }
    void PlayerAttack(){
        if(Input.GetKey(KeyCode.Space)){
            float delay = 1.0f/attack_speed;
            attack_timer += Time.deltaTime;
            if(attack_timer >= delay){
                Instantiate(bullet_obj, transform.position, Quaternion.identity);
                bullet_obj.GetComponent<Bullet>().bullet_damage = attack_damage;
                bullet_obj.GetComponent<Bullet>().bullet_direction = Vector2.up;
                bullet_obj.GetComponent<Bullet>().bullet_speed = 10.0f;
                bullet_obj.GetComponent<Bullet>().is_enemy_bullet = false;

                attack_timer = 0;
            }
}
    }
    void PlayerUseSkill(int index){}

    void Start(){}
    void Update(){
        PlayerMove();
        PlayerAttack();
    }
}
