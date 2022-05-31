using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Enemystatus : MonoBehaviour
{
    public float maxhp;
    float hp;
    public float edamage;
    public float elevel;
    public float exp;
    float plevel;
    GameObject player;
    readonly string blade = "PlayerBlade";
    public Slider enemyslider;
    public bool boss;
    public String stairsname;
    public bool[] attribute = new bool[6];
    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーのステータスを取得
        player = GameObject.Find("Player");
        Playerstatus stats = player.GetComponent<Playerstatus>();
        plevel = stats.Getstats(3);
        //敵のステータスを決定
        maxhp = maxhp * (plevel * 2);
        edamage = edamage + (plevel * 3);
        elevel = elevel + plevel + 1;
        exp = exp * (plevel * 2);
        //HPber作成
        enemyslider = enemyslider.GetComponent<Slider>();
        enemyslider.maxValue = maxhp;
        enemyslider.value = maxhp;
        Enemymove enemyspos = gameObject.GetComponent<Enemymove>();
        Bossmove bossmove = gameObject.GetComponent<Bossmove>();
        if(boss == true)
        {
            bossmove.Setenemydamage((int)edamage);
        }
        else
        {
            enemyspos.Setenemydamage((int)edamage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //マップ外に出たとき
        if ((transform.position.y <= -1 || transform.position.y >= 25 || transform.position.x < 0 || transform.position.x > 500 || transform.position.z < 0 || transform.position.z > 500 ) && boss == false) Dead(false);
        hp = enemyslider.value;
        //HPが0以下の時死亡
        if (hp <= 0) Dead(true);
        enemyslider.value += 0.005f;
    }
    //敵に攻撃が当たったとき
    void OnTriggerEnter(Collider other)
    {
        player = GameObject.Find("Player");
        Playerstatus stats = player.GetComponent<Playerstatus>();
        //剣の時
        if (other.gameObject.tag == blade)
        {
            enemyslider.value = hp - stats.Getstats(4);
        }
        //魔法の時
        if (other.gameObject.tag == "PlayerMagic1" || other.gameObject.tag == "PlayerMagic2" || other.gameObject.tag == "PlayerMagic3" || other.gameObject.tag == "PlayerMagic4" || other.gameObject.tag == "PlayerMagic5")
        {
            Magiccon magiccon = other.GetComponent<Magiccon>();
            //弱点属性
            if ((attribute[1] == true && other.gameObject.tag == "PlayerMagic2") || (attribute[2] == true && other.gameObject.tag == "PlayerMagic3") || (attribute[3] == true && other.gameObject.tag == "PlayerMagic1") || (attribute[4] == true && other.gameObject.tag == "PlayerMagic5") || (attribute[5] == true && other.gameObject.tag == "PlayerMagic4"))
            {
                enemyslider.value = hp - magiccon.Playermagicdamage() * 1.5f;
            }
            //有利属性
            else if ((attribute[1] == true && other.gameObject.tag == "PlayerMagic3") || (attribute[2] == true && other.gameObject.tag == "PlayerMagic1") || (attribute[3] == true && other.gameObject.tag == "PlayerMagic2"))
            {
                enemyslider.value = hp - magiccon.Playermagicdamage() * 0.5f;
            }
            //通常時
            else
            {
                enemyslider.value = hp - magiccon.Playermagicdamage();
            }
        }
    }
    //死亡時の処理
    void Dead(bool i)
    {
        Spawncontroll terrain = GameObject.Find("Terrain").GetComponent<Spawncontroll>();
        player = GameObject.Find("Player");
        Playerstatus stats = player.GetComponent<Playerstatus>();
        Magic magic = player.GetComponent<Magic>();
        string enemyname = gameObject.name;
        //敵の出現数を減らす
        switch (enemyname)
        {
            case "Prototype01(Clone)":
                terrain.Setnumber(0);
                magic.Setenemycount(0);
                break;
            case "Prototype02(Clone)":
                terrain.Setnumber(1);
                magic.Setenemycount(1);
                break;
            case "Prototype03(Clone)":
                terrain.Setnumber(2);
                magic.Setenemycount(2);
                break;
            case "Prototype04(Clone)":
                terrain.Setnumber(3);
                magic.Setenemycount(3);
                break;
            case "Prototype05(Clone)":
                terrain.Setnumber(4);
                magic.Setenemycount(4);
                break;
            case "Prototype06(Clone)":
                terrain.Setnumber(5);
                magic.Setenemycount(5);
                break;
            case "Prototype07(Clone)":
                terrain.Setnumber(6);
                magic.Setenemycount(6);
                break;
            case "Fireboss(Clone)":
                magic.tp[0] = true;
                GameObject.Find(stairsname).SetActive(true);
                magic.Setenemycount(7);
                break;
            case "Waterboss(Clone)":
                Debug.Log(5);
                magic.tp[1] = true;
                GameObject.Find(stairsname).SetActive(true);
                magic.Setenemycount(8);
                break;
            case "Windboss(Clone)":
                magic.tp[2] = true;
                GameObject.Find(stairsname).SetActive(true);
                magic.Setenemycount(9);
                break;
            case "DEboss(Clone)":
                Invoke("Gameend", 2);
                break;
        }
        if(i == true) stats.Getstats(exp);
        Destroy(gameObject);
    //ゲーム終了
    }
    public void Gameend()
    {
        EditorApplication.isPlaying = false;
    }


}
