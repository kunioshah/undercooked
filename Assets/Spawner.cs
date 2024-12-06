using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject SmolGameObject;
    //public GameObject MedGameObject;
    //public GameObject BeegGameObject;

    public float itemSpawnTimeNow;
    public float itemSpawnTime;
    public float numberOfItems;

    public float xSpawnLength;
    public float ySpawnLength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Item").Length < numberOfItems)
        {
            if (itemSpawnTimeNow <= 0)
            {
                spawnDem();
                //when fish spawn, reset timer to spawn again
                itemSpawnTimeNow = itemSpawnTime;
            }
            else
            {
                //count down time by 1 sec
                itemSpawnTimeNow -= Time.deltaTime;
            }
        }
    }

    public void spawnDem()
    {
        //GameObject[] fishSize = new GameObject[]{ SmolGameObject, SmolGameObject, SmolGameObject, SmolGameObject,
        //    SmolGameObject, MedGameObject, MedGameObject, MedGameObject, BeegGameObject, BeegGameObject};
        //Now we choose random feesh
        GameObject[] itemSize = new GameObject[] { SmolGameObject };
        int chosenOne = Random.Range(0, itemSize.Length);

        //We choose random spawn
        Vector2 randoSpawn = new Vector2(Random.Range(-xSpawnLength, xSpawnLength), Random.Range(-ySpawnLength, ySpawnLength));
        //public bool OverlapPoint(randoSpawn);
        //do
        {
            //randoSpawn = new (Random.Range(-103, 106), Random.Range(49, -49));
        } //while (OverlapPoint(randoSpawn));

        //Spawn the feesh
        Instantiate(itemSize[chosenOne], randoSpawn, Quaternion.identity);

        //Oh yeah also talk about which one it chose
        Debug.Log(chosenOne);
        //Maybe where it is, too
        Debug.Log(randoSpawn);
    }
}
