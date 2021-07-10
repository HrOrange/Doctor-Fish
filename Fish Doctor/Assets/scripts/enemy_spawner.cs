using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_spawner : MonoBehaviour
{
    public List<GameObject> enemy_types;
    public List<GameObject> boss_types;
    public List<int> remaining_normal_enemies;
    public List<int> remaining_bosses;

    public float spawm_delta_time = 3.0f;
    bool spawning_bosses;
    float clock;

    public float lowest_distace_to_player = 15.0f;
    public Transform spawn_points;

    public int level;
    public Text level_show;

    void Start()
    {
        for (int i = 0; i < enemy_types.Count; i++) remaining_normal_enemies.Add(3);
        for (int i = 0; i < boss_types.Count; i++) remaining_bosses.Add(1);
    }

    void Update()
    {
        if(!spawning_bosses) clock += Time.deltaTime;

        if (clock >= spawm_delta_time) {
            clock -= spawm_delta_time;

            bool spawn_boss = true;
            foreach(int i in remaining_normal_enemies)
                if(i != 0)
                {
                    spawn_boss = false;
                    break;
                }

            if (!spawn_boss)
            {
                for (int i = 0; i < remaining_normal_enemies.Count; i++)
                {
                    if(remaining_normal_enemies[i] > 0)
                    {
                        remaining_normal_enemies[i]--;

                        //Vector2 spawn_pos = new Vector2(Random.Range(-range.x / 2, range.x / 2), Random.Range(-range.y / 2, range.y / 2));
                        int r = Random.Range(0, spawn_points.childCount - 1);
                        Vector2 spawn_pos = new Vector2(spawn_points.GetChild(r).transform.position.x, spawn_points.GetChild(r).transform.position.y);
                        while (Vector2.Distance(spawn_pos, GameObject.FindWithTag("Player").transform.position) < lowest_distace_to_player)
                        {
                            r = Random.Range(0, spawn_points.childCount - 1);
                            spawn_pos = new Vector2(spawn_points.GetChild(r).transform.position.x, spawn_points.GetChild(r).transform.position.y);
                        }

                        GameObject spawned = Instantiate(enemy_types[i], spawn_pos, Quaternion.identity);
                        spawned.transform.SetParent(transform);

                        break;
                    }
                }

                bool no_more_normals = true;
                for (int i = 0; i < remaining_normal_enemies.Count; i++)
                {
                    if (remaining_normal_enemies[i] > 0)
                    {
                        no_more_normals = false;
                        break;
                    }
                }

                if (no_more_normals)
                {
                    spawning_bosses = true;
                    spawn_next_boss();
                    clock = 0;
                }
            }

        }
    }
    public void spawn_next_boss()
    {
        bool more_bosses = true;
        for (int i = 0; i < remaining_bosses.Count; i++)
        {
            if (remaining_bosses[i] > 0)
            {
                remaining_bosses[i]--;

                //Vector2 spawn_pos = new Vector2(Random.Range(-range.x / 2, range.x / 2), Random.Range(-range.y / 2, range.y / 2));
                int r = Random.Range(0, spawn_points.childCount - 1);
                Vector2 spawn_pos = new Vector2(spawn_points.GetChild(r).transform.position.x, spawn_points.GetChild(r).transform.position.y);
                while (Vector2.Distance(spawn_pos, GameObject.FindWithTag("Player").transform.position) < lowest_distace_to_player)
                {
                    r = Random.Range(0, spawn_points.childCount - 1);
                    spawn_pos = new Vector2(spawn_points.GetChild(r).transform.position.x, spawn_points.GetChild(r).transform.position.y);
                }

                GameObject spawned = Instantiate(boss_types[i], spawn_pos, Quaternion.identity);
                spawned.transform.SetParent(transform);

                more_bosses = false;
                break;
            }
        }
        if (more_bosses)
        {
            for (int i = 0; i < enemy_types.Count; i++) remaining_normal_enemies[i] = 3;
            for (int i = 0; i < boss_types.Count; i++) remaining_bosses[i] = 1;

            spawning_bosses = false;
        }
    }
}
