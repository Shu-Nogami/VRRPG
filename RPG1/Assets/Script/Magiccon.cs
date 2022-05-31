using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magiccon : MonoBehaviour
{
    public float destroytime;
    public int movetype;
    int enemymagicdamage;
    public float magicspeed;
    string Blade = "PlayerBlade";
    public bool playermagic;
    public float playerbasisdamage;
    public GameObject destroyObject;
    // Start is called before the first frame update
    void Start()
    {
        //魔法の発動時間の設定
        Destroy(destroyObject, destroytime);
    }

    // Update is called once per frame
    void Update()
    {
        switch(movetype)
        {
            //まっすぐに飛ぶ
            case 1:
                transform.position += transform.forward * magicspeed;
                break;
            //右に飛ぶ
            case 2:
                transform.position += transform.right * magicspeed;
                break;
            default:
                break;
        }
    }
    //魔法が当たったとき
    void OnTriggerEnter(Collider other)
    {
        Playerstatus status = GameObject.Find("Player").GetComponent<Playerstatus>();
        //Magicdestroyが発動中に剣に当たったときもしくはShieldに当たったとき
        if ((other.gameObject.tag == Blade && status.magicdestroy == true) || (other.gameObject.tag == "Playershield" && playermagic == false))
        {
            Destroy(destroyObject);
        }
    }
    //敵の魔法ダメージを設定もしくは値を渡す
    public int Enemymagicdamage(int i)
    {
        switch (i)
        {
            case 1:
                return enemymagicdamage;
            default:
                enemymagicdamage = i;
                return 0;
        }
    }
    //プレイヤーの魔法の攻撃力設定
    public int Playermagicdamage()
    {
        Playerstatus status = GameObject.Find("Player").GetComponent<Playerstatus>();
        return (int)(status.Getstats(5) * playerbasisdamage);
    }
}
