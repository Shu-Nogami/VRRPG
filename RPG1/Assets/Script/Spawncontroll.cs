using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawncontroll : MonoBehaviour
{
    public int[] enemynumber = new int[100];
    public GameObject prototype1;
    public GameObject prototype2;
    public GameObject prototype3;
    public GameObject prototype4;
    public GameObject prototype5;
    public GameObject prototype6;
    public GameObject prototype7;
    public GameObject fireboss;
    public GameObject waterboss;
    public GameObject windboss;
    public GameObject darklightboss;
    public bool[] bossspawn = new bool[4];
    public GameObject player;
    public GameObject DEtower;
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            enemynumber[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Prototype01
        if (enemynumber[0] < 2)
        {
            GameObject proto1 = Instantiate(prototype1) as GameObject;
            proto1.transform.position = new Vector3(Random.Range(60,121),10,Random.Range(30,121));
            enemynumber[0]++;
        }
        //Prototype02
        if (enemynumber[1] < 2)
        {
            GameObject proto2 = Instantiate(prototype2) as GameObject;
            proto2.transform.position = new Vector3(Random.Range(40, 171), 10, Random.Range(320, 391));
            enemynumber[1]++;
        }
        //Prototype03
        if (enemynumber[2] < 2)
        {
            GameObject proto3 = Instantiate(prototype3) as GameObject;
            proto3.transform.position = new Vector3(Random.Range(275, 381), 10, Random.Range(320, 396));
            enemynumber[2]++;
        }
        //Prototype04
        if (enemynumber[3] < 1)
        {
            GameObject proto4 = Instantiate(prototype4) as GameObject;
            proto4.transform.position = new Vector3(Random.Range(345, 426), 10, Random.Range(140, 121));
            enemynumber[3]++;
        }
        //Prototype05
        if (enemynumber[4] < 2)
        {
            GameObject proto5 = Instantiate(prototype5) as GameObject;
            proto5.transform.position = new Vector3(Random.Range(240, 316), 10, Random.Range(80, 176));
            enemynumber[4]++;
        }
        //Prototype06
        if (enemynumber[5] < 1)
        {
            GameObject proto6 = Instantiate(prototype6) as GameObject;
            proto6.transform.position = new Vector3(Random.Range(40, 116), 10, Random.Range(380, 451));
            enemynumber[5]++;
        }
        //Prototype07
        if (enemynumber[6] < 1)
        {
            GameObject proto7 = Instantiate(prototype7) as GameObject;
            proto7.transform.position = new Vector3(Random.Range(380, 456), 10, Random.Range(370, 436));
            enemynumber[6]++;
        }
        //Fireboss
        if (player.transform.position.x >= 470 && player.transform.position.y < 0 && player.transform.position.z <= 30 && bossspawn[0] == true)
        {
            GameObject boss1 = Instantiate(fireboss) as GameObject;
            boss1.transform.position = new Vector3(490,-9,10);
            bossspawn[0] = false;
        }
        //Waterboss
        if (player.transform.position.x >= 472 && player.transform.position.y < 0 && player.transform.position.z >= 470 && bossspawn[1] == true)
        {
            GameObject boss2 = Instantiate(waterboss) as GameObject;
            boss2.transform.position = new Vector3(490, -9, 490);
            bossspawn[1] = false;
        }
        //Windboss
        if (player.transform.position.x <= 30 && player.transform.position.y < 0 && player.transform.position.z >= 470 && bossspawn[2] == true)
        {
            GameObject boss3 = Instantiate(windboss) as GameObject;
            boss3.transform.position = new Vector3(24, -9, 476);
            bossspawn[2] = false;
            Debug.Log(boss3.transform.position);
        }
        //DEboss
        if (bossspawn[0] == false && bossspawn[1] == false && bossspawn[2] == false && bossspawn[3] == true && player.transform.position.x >= 245 && player.transform.position.x <= 252 && player.transform.position.z >= 223 && player.transform.position.z <= 230)
        {
            Destroy(DEtower);
            wall.SetActive(true);
            GameObject boss4 = Instantiate(darklightboss) as GameObject;
            boss4.transform.position = new Vector3(262,8,246);
            bossspawn[3] = false;
        }
    }
    //敵の湧き数を変更
    public int Setnumber(int i)
    {
        enemynumber[i]--;
        return 0;
    }
}
