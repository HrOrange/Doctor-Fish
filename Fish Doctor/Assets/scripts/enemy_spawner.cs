using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    public List<GameObject> enemy_types;
    
    public float spawm_delta_time = 3.0f;
    float clock;

    public float lowest_distace_to_player = 15.0f;
    public Vector2 range = new Vector2(100, 100);

    void Update()
    {
        clock += Time.deltaTime;
        if (clock >= spawm_delta_time) {
            clock -= spawm_delta_time;

            Vector2 spawn_pos = new Vector2(Random.Range(-range.x / 2, range.x / 2), Random.Range(-range.y / 2, range.y / 2));
            while (Vector2.Distance(spawn_pos, GameObject.FindWithTag("Player").transform.position) < lowest_distace_to_player) spawn_pos = new Vector2(Random.Range(-range.x / 2, range.x / 2), Random.Range(-range.y / 2, range.y / 2));
            
            GameObject spawned = Instantiate(enemy_types[Random.Range(0, enemy_types.Count)], spawn_pos, Quaternion.identity);
            spawned.transform.SetParent(transform);
        }
    }
}
