using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Playerstatus : MonoBehaviour
{
    public int playerhp = 80;
    public int playervaluehp = 80;
    public int playerad;
    public int playermd;
    public int playermana;
    public int playerlevel = 1;
    public int playerxp;
    Slider playerhpslider;
    Slider playermanaslider;
    bool invincible = false;
    bool demon = false;
    bool holy = false;
    public bool magicdestroy = false;
    bool[] abnormal = new bool[20];
    public Transform swordposition1;
    public Transform swordposition2;
    public GameObject sword;
    public GameObject katana;
    public GameObject spear;
    public GameObject shield;
    private GameObject playersword;
    private GameObject playersword2;
    int attribute;
    // Start is called before the first frame update
    void Start()
    {
        //属性決定
        attribute = Random.Range(1, 6);
        //sword複製
        GameObject playersword = Instantiate(sword) as GameObject;
        playersword.transform.SetParent(swordposition1, false);
        playersword.transform.position = swordposition1.position;
        playersword.transform.rotation = swordposition1.rotation;
        //HPber作成
        playerhpslider = GameObject.Find("Playerhpber").GetComponent<Slider>();
        playerhpslider.maxValue = playerhp;
        playerhpslider.value = playerhp;
        //Manaber作成
        playermanaslider = GameObject.Find("Playermanaber").GetComponent<Slider>();
        playermanaslider.maxValue = playermana;
        playermanaslider.value = playermana;
        //ステータス変更値を初期化
        for(int i = 0;i < 20; i++)
        {
            abnormal[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //マップ外に出たとき
        if (transform.position.y <= -15) playerhpslider.value = 0;
        Magic playermagic = GetComponent<Magic>();
        //レベルアップ時の処理
        if (playerxp >= 95 * playerlevel)
        {
            playerlevel++;
            playerhp = playerhp + (playerhp / 2);
            if (demon == true)
            {
                playerhp = playerhp / 2;
            }
            playerxp = playerxp - 95 * playerlevel;
            playerad = playerad + playerlevel * 3;
            playermd = playermd + playerlevel * 6;
            playermana = playermana + playerlevel * 15;
            playerhpslider.maxValue = playerhp;
            playerhpslider.value = playerhp;
            playermanaslider.maxValue = playermana;
            playermanaslider.value = playermana;
        }
        //HPが0になったときの処理
        if (playerhpslider.value <= 0)
        {
            EditorApplication.isPlaying = false;
        }
        //魔法:Demonを使った時の武器変更とステータス変更
        if (demon == true)
        {
            playerhpslider.value += 0.07f;
            playermanaslider.value -= 0.05f;
            if (playermanaslider.value == 0.0f)
            {
                Destroy(GameObject.Find("Katana(Clone)"));
                Destroy(GameObject.Find("Katana(Clone)"));
                GameObject playersword = Instantiate(sword) as GameObject;
                playersword.transform.SetParent(swordposition1, false);
                playersword.transform.position = swordposition1.position;
                playersword.transform.rotation = swordposition1.rotation;
                demon = false;
                playerhpslider.maxValue = playerhpslider.maxValue * 2;
                playerad = (int)(playerad / 1.5f);
                playermagic.Magiclifted();
            }
        }
        //魔法:Holyknightを使った時の武器変更とステータス変更
        else if (holy == true)
        {
            playerhpslider.value += 0.03f;
            playermanaslider.value -= 0.07f;
            if (playermanaslider.value == 0.0f)
            {
                Destroy(GameObject.Find("Spear(Clone)"));
                Destroy(GameObject.Find("Shield(Clone)"));
                GameObject playersword = Instantiate(sword) as GameObject;
                playersword.transform.SetParent(swordposition1, false);
                playersword.transform.position = swordposition1.position;
                playersword.transform.rotation = swordposition1.rotation;
                holy = false;
                playermanaslider.maxValue = playermanaslider.maxValue * 2;
                playermd = (int)(playermd / 1.5f);
                playermagic.Magiclifted();
            }
        }
        //通常時の回復量
        else
        {
            playerhpslider.value += 0.05f;
            playermanaslider.value += 0.07f;
        }
    }
    //プレイヤーに攻撃が当たった時
    void OnTriggerEnter(Collider other)
    {
        Magiccon magiccon = other.GetComponent<Magiccon>();
        if (other.gameObject.tag == "EnemyMagic1" || other.gameObject.tag == "EnemyMagic2" || other.gameObject.tag == "EnemyMagic3" || other.gameObject.tag == "EnemyMagic4" || other.gameObject.tag == "EnemyMagic5")
        {
            //無敵ではないとき
            if (invincible == false)
            {
                //不利属性
                if ((attribute == 1 && other.gameObject.tag == "EnemyMagic2") || (attribute == 2 && other.gameObject.tag == "EnemyMagic3") || (attribute == 3 && other.gameObject.tag == "EnemyMagic1") || (attribute == 4 && other.gameObject.tag == "EnemyMagic5") || (attribute == 5 && other.gameObject.tag == "EnemyMagic4"))
                {
                    playerhpslider.value -= magiccon.Enemymagicdamage(1) * 1.5f;
                }
                //有利属性
                else if((attribute == 1 && other.gameObject.tag == "EnemyMagic3") || (attribute == 2 && other.gameObject.tag == "EnemyMagic1") || (attribute == 3 && other.gameObject.tag == "EnemyMagic2"))
                {
                    playerhpslider.value -= magiccon.Enemymagicdamage(1) * 0.5f;
                }
                //通常時
                else
                {
                    playerhpslider.value -= magiccon.Enemymagicdamage(1);
                }
                Destroy(other.gameObject);
            }
        }
    }
    //他のスクリプトにステータスの値を渡す
    public float Getstats(float i)
    {
        switch (i)
        {
            //HP
            case 1:
                return playerhpslider.value;
            //Mana
            case 2:
                return playermanaslider.value;
            //Level
            case 3:
                return playerlevel;
            //物理攻撃力
            case 4:
                return playerad;
            //魔法攻撃力
            case 5:
                return playermd;
            //経験値
            default:
                playerxp += (int)i;
                return 0;
        }
    }
    //魔法使用時マナが足りているか
    public bool Setmana(float j)
    {
        //足りていないとき
        if (playermanaslider.value - j <= 0)
        {
            return false;
        }
        //足りている時
        else
        {
            playermanaslider.value -= j;
            return true;
        }
    }
    //魔法によるステータス変更
    public void Abnormalstates(int a)
    {
        OVRPlayerController con = GameObject.Find("OVRPlayerController").GetComponent<OVRPlayerController>();
        switch (a)
        {
            //Fireboost
            case 1:
                playerad = (int)(playerad * 1.2f);
                abnormal[a] = true;
                Invoke("Resetstatus", 7);
                break;
            //Waterboost
            case 2:
                playermd = (int)(playermd * 1.1f);
                abnormal[a] = true;
                Invoke("Resetstatus", 7);
                break;
            //Windboost
            case 3:
                con.Acceleration += 0.2f;
                abnormal[a] = true;
                Invoke("Resetstatus", 7);
                break;
            //Lightheal
            case 4:
                playerhpslider.value = (int)(playerhpslider.value * 1.2f);
                break;
            //Magicdestroy
            case 5:
                magicdestroy = true;
                Invoke("Resetstatus", 5);
                break;
            //Highboost:Fire
            case 11:
                playerad = (int)(playerad * 1.4f);
                playermd = (int)(playermd / 1.4f);
                abnormal[a] = true;
                Invoke("Resetstatus", 9);
                break;
            //Highboost:Water
            case 12:
                playerad = (int)(playerad / 1.4f);
                playermd = (int)(playermd * 1.4f);
                abnormal[a] = true;
                Invoke("Resetstatus", 9);
                break;
            //Highboost:Wind
            case 13:
                con.Acceleration += 0.4f;
                playerad = (int)(playerad / 1.2f);
                playermd = (int)(playermd / 1.2f);
                abnormal[a] = true;
                Invoke("Resetstatus", 10);
                break;
            //Highheal
            case 14:
                playerhpslider.value = (int)(playerhpslider.value * 1.5f);
                playerad = (int)(playerad / 1.2f);
                playermd = (int)(playermd / 1.2f);
                abnormal[a] = true;
                Invoke("Resetstatus", 10);
                break;
            //Highdestroy
            case 15:
                magicdestroy = true;
                playerhpslider.value = playerhpslider.value / 1.3f;
                playerad = (int)(playerad * 1.2f);
                abnormal[a] = true;
                Invoke("Resetstatus", 10);
                break;
            //Ultimateboost
            case 23:
                playerad = (int)(playerad * 1.5f);
                playermd = (int)(playermd * 1.5f);
                con.Acceleration += 0.2f;
                playermanaslider.value = playermanaslider.value / 1.2f;
                Invoke("Resetstatus", 10);
                break;
            //Perfectprotect
            case 24:
                invincible = true;
                playerhpslider.value = playerhpslider.maxValue;
                abnormal[a] = true;
                Invoke("Resetstatus", 3);
                break;
            //Holyknight
            case 34:
                playermanaslider.maxValue = playermanaslider.maxValue / 2;
                playermd = (int)(playermd * 1.5f);
                holy = true;
                Destroy(GameObject.Find("Sword(Clone)"));
                playersword = Instantiate(spear) as GameObject;
                playersword.transform.SetParent(swordposition1, false);
                playersword.transform.position = swordposition1.position;
                playersword.transform.rotation = swordposition1.rotation;
                playersword2 = Instantiate(shield) as GameObject;
                playersword2.transform.SetParent(swordposition2, false);
                playersword2.transform.position = swordposition2.position;
                playersword2.transform.rotation = swordposition2.rotation;
                break;
            //Demon
            case 35:
                playerhpslider.maxValue = playerhpslider.maxValue / 2;
                playerad = (int)(playerad * 1.5f);
                demon = true;
                Destroy(GameObject.Find("Sword(Clone)"));
                playersword = Instantiate(katana) as GameObject;
                playersword.transform.SetParent(swordposition1, false);
                playersword.transform.position = swordposition1.position;
                playersword.transform.rotation = swordposition1.rotation;
                playersword2 = Instantiate(katana) as GameObject;
                playersword2.transform.SetParent(swordposition2, false);
                playersword2.transform.position = swordposition2.position;
                playersword2.transform.rotation = swordposition2.rotation;
                break;
            
        }
    }
    //魔法で変更したステータスを戻す
    public void Resetstatus()
    {
        OVRPlayerController con = GameObject.Find("OVRPlayerController").GetComponent<OVRPlayerController>();
        int count = 1;
        while(abnormal[count] != true || count >= 25)
        {
            count++;
        }
        switch (count)
        {
            //Fireboost
            case 1:
                playerad = (int)(playerad / 1.2f);
                abnormal[count] = false;
                break;
            //Waterboost
            case 2:
                playermd = (int)(playermd / 1.1f);
                abnormal[count] = false;
                break;
            //Windboost
            case 3:
                con.Acceleration -= 0.2f;
                abnormal[count] = false;
                break;
            //Magicdestroy
            case 5:
                abnormal[count] = false;
                magicdestroy = false;
                break;
            //Highboost:Fire
            case 11:
                playerad = (int)(playerad / 1.4f);
                playermd = (int)(playermd * 1.4f);
                abnormal[count] = false;
                break;
            //Highboost:Water
            case 12:
                playerad = (int)(playerad * 1.4f);
                playermd = (int)(playermd / 1.4f);
                abnormal[count] = false;
                break;
            //Highboost:Wind
            case 13:
                con.Acceleration -= 0.4f;
                playerad = (int)(playerad * 1.2f);
                playermd = (int)(playermd * 1.2f);
                abnormal[count] = false;
                break;
            //Highheal
            case 14:
                playerad = (int)(playerad * 1.2f);
                playermd = (int)(playermd * 1.2f);
                abnormal[count] = false;
                break;
            //Highdestroy
            case 15:
                abnormal[count] = false;
                playerhpslider.value = playerhpslider.value * 1.3f;
                playerad = (int)(playerad / 1.2f);
                magicdestroy = false;
                break;
            //Ultimateboost
            case 23:
                abnormal[count] = false;
                playerad = (int)(playerad / 1.5f);
                playermd = (int)(playermd / 1.5f);
                con.Acceleration -= 0.2f;
                break;
            //Perfectprotect
            case 24:
                abnormal[count] = false;
                invincible = false;
                break;
            default:
                break;
        }
    }
}
