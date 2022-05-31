using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bossmove : MonoBehaviour
{
    public GameObject[] enemycanon = new GameObject[8];
    private int canoncount = -1;
    Transform playerpos;
    public string bosstype;
    private Vector3[] rocation = new Vector3[9];
    public float movespeed;
    int enemydamage;
    GameObject enemymagic;
    public GameObject magic1;
    public GameObject magic2;
    public GameObject magic3;
    public GameObject magic4;
    public Slider enemyslider;
    public float time;
    public float shottime;
    public bool Fullrecovery;
    // Start is called before the first frame update
    void Start()
    {
        playerpos = GameObject.Find("OVRPlayerController").transform;
        //Windboss座標設定
        rocation[0] = new Vector3(10, -9, 476);
        rocation[1] = new Vector3(24, -9, 476);
        rocation[2] = new Vector3(24, -9, 490);
        rocation[3] = new Vector3(24, -9, 503);
        rocation[4] = new Vector3(10, -9, 503);
        rocation[5] = new Vector3(-2.5f, -9, 503);
        rocation[6] = new Vector3(-2.5f, -9, 490);
        rocation[7] = new Vector3(-2.5f, -9, 476);
        rocation[8] = new Vector3(10, -9, 476);
        //キャノンの数を設定
        for (int i = 0; i < 12; i++)
        {
            if (enemycanon[i] != null)
            {
                canoncount++;
            }
        }
        enemyslider = enemyslider.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Enemystatus enemystatus = gameObject.GetComponent<Enemystatus>();
        time += Time.deltaTime;
        switch (bosstype)
        {
            //Fireboss
            case "fireboss":
                transform.LookAt(playerpos);
                transform.position += transform.forward * movespeed;
                //2秒たったら
                if(time >= shottime)
                {
                    shot();
                    time = 0;
                }
                //HPが30%を切ったら
                if (enemyslider.value == enemyslider.maxValue * 0.3f && Fullrecovery == true)
                {
                    enemyslider.value = enemyslider.maxValue;
                    Fullrecovery = false;
                }
                break;
                //Waterboss
            case "waterboss":
                transform.LookAt(playerpos);
                //HPが60%を切ったら
                if (enemyslider.value == enemyslider.maxValue * 0.6f)
                {
                    shottime = 1.8f;
                }
                //HPが30%を切ったら
                else if (enemyslider.value == enemyslider.maxValue * 0.3f)
                {
                    shottime = 1.5f;
                }
                //通常時
                if (time >= shottime)
                {
                    shot();
                    time = 0;
                }
                break;
                //Windboss
            case "windboss":
                //HPが60%を切ったら
                if (enemyslider.value == enemyslider.maxValue * 0.6f)
                {
                    movespeed = 1.3f;
                }
                //HPが30%を切ったら
                else if (enemyslider.value == enemyslider.maxValue * 0.3f)
                {
                    movespeed = 1.5f;
                }
                //通常時
                if (time >= shottime)
                {
                    rocation[0] = rocation[Random.Range(1,9)];
                    time = 0;
                    shot();
                }
                transform.LookAt(rocation[0]);
                transform.position += transform.forward * movespeed;
                break;
                //DEboss
            case "light&darkboss":
                transform.LookAt(playerpos);
                //通常時
                if(time >= shottime)
                {
                    shot();
                    time = 0;
                }
                //HPが50%を切ったら
                if (enemyslider.value == enemyslider.maxValue * 0.5f)
                {
                    //属性を光から闇に
                    enemystatus.attribute[4] = false;
                    enemystatus.attribute[5] = true;
                    transform.position += transform.forward * movespeed;
                }
                else
                {
                    //属性を闇から光に
                    enemystatus.attribute[5] = false;
                    enemystatus.attribute[4] = true;
                }
                //HPが10%を切ったら
                if (enemyslider.value == enemyslider.maxValue * 0.1f && Fullrecovery == true)
                {
                    enemyslider.value = enemyslider.maxValue;
                    Fullrecovery = false;
                }
                break;
        }
    }
    //魔法を打つ
    private void shot()
    {
        for (int j = 0; j <= canoncount; j++)
        {
            enemycanon[j].transform.LookAt(playerpos);
        }
        for (int j = 0; j <= canoncount; j++)
        {
            //DEbossの場合
            if(gameObject.name == "DEboss")
            {
                //1から4までランダムで選択
                int shottype = Random.Range(1, 5);
                switch (shottype)
                {
                    case 1:
                        enemymagic = Instantiate(magic1) as GameObject;
                        break;
                    case 2:
                        enemymagic = Instantiate(magic2) as GameObject;
                        break;
                    case 3:
                        enemymagic = Instantiate(magic3) as GameObject;
                        break;
                    case 4:
                        enemymagic = Instantiate(magic4) as GameObject;
                        break;
                }
            }
            //DEboss以外の場合
            else
            {
                //1か2までランダムで選択
                int shottype = Random.Range(1, 3);
                switch (shottype)
                {
                    case 1:
                        enemymagic = Instantiate(magic1) as GameObject;
                        break;
                    case 2:
                        enemymagic = Instantiate(magic2) as GameObject;
                        break;
                }
            }
            //beam系の魔法の場合キャノンの子に設定
            if (enemymagic.name == "EnemyFireBeam(Clone)" || enemymagic.name == "EnemyDarkBeam(Clone)") enemymagic.transform.SetParent(enemycanon[j].transform, false);
            enemymagic.transform.rotation = enemycanon[j].transform.rotation;
            enemymagic.transform.position = enemycanon[j].transform.position;
            Magiccon magiccon = enemymagic.GetComponent<Magiccon>();
            magiccon.Enemymagicdamage(enemydamage);
        }

    }
    //Enemystatusからのenemydamageを保存
    public void Setenemydamage(int j)
    {
        enemydamage = j;
    }
}
