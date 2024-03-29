using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
public GameObject[] objects;
public Transform[] position;

float[] random_time = {-1,-1,-1,-1,-1};
float[] spawn_timer = {0, 0, 0, 0, 0};

void SpawnEnemy(){
    for(int i = 0; i<5; i++){
        if(random_time[i] == -1){
            random_time[i] = Random.Range(5.0f, 7.0f);  //1~3
            spawn_timer[i] = 0;
        }else spawn_timer[i] += Time.deltaTime;


        if(random_time[i] <= spawn_timer[i]){
            int obj_index = Random.Range(1, 101);
            if(obj_index > 50 ) obj_index = 0;
            else if(obj_index > 15 && obj_index <= 50) obj_index = 1;
            else obj_index = 2;
            Instantiate(objects[obj_index], position[i].position, Quaternion.identity);
            random_time[i] = -1;
            spawn_timer[i] = 0;
        }
    }
}
void Update(){
    SpawnEnemy();
}
}
