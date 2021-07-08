using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    public List<GameObject> enemy_types;
    
    public float spawm_delta_time = 3.0f;
    float clock;

    public float lowest_distace_to_player = 15.0f;
    public Transform spawn_points;

    void Update()
    {
        clock += Time.deltaTime;
        if (clock >= spawm_delta_time) {
            clock -= spawm_delta_time;

            //Vector2 spawn_pos = new Vector2(Random.Range(-range.x / 2, range.x / 2), Random.Range(-range.y / 2, range.y / 2));
            int r = Random.Range(0, spawn_points.childCount - 1);
            Vector2 spawn_pos = new Vector2(spawn_points.GetChild(r).transform.position.x, spawn_points.GetChild(r).transform.position.y);
            while (Vector2.Distance(spawn_pos, GameObject.FindWithTag("Player").transform.position) < lowest_distace_to_player)
            {
                r = Random.Range(0, spawn_points.childCount - 1);
                spawn_pos = new Vector2(spawn_points.GetChild(r).transform.position.x, spawn_points.GetChild(r).transform.position.y);
            }
            
            GameObject spawned = Instantiate(enemy_types[Random.Range(0, enemy_types.Count)], spawn_pos, Quaternion.identity);
            spawned.transform.SetParent(transform);
        }
    }
}
