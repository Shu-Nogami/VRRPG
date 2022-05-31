using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove : MonoBehaviour
{
    public GameObject[] enemycanon = new GameObject[4];
    public int canoncount = -1;
    public float move;
    Transform playerpos;
    float Xaxis;
    float Zaxis;
    GameObject enemymagic;
    int shottype;
    public GameObject magic1;
    public GameObject magic2;
    int shotcontroll;
    float time = 3.0f;
    int enemydamage;
    public AudioClip sound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        playerpos = GameObject.Find("OVRPlayerController").transform;
        //キャノンの数を保存
        for(int i = 0;i < 4; i++)
        {
            if(enemycanon[i] != null)
            {
                canoncount++;
            }
        }
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        float terrainhight = Terrain.activeTerrain.SampleHeight(transform.position);
        transform.position = new Vector3(transform.position.x, terrainhight + 1.7f, transform.position.z);
        //プレイヤーと敵の座標の差を代入
        Xaxis = transform.position.x - playerpos.position.x;
        Zaxis = transform.position.z - playerpos.position.z;
        //プレイヤーが特定の範囲内にいる場合
        if (Xaxis <= 12 && Xaxis >= -8 && Zaxis <= 10 && Zaxis >= -12)
        {
            transform.position = Vector3.MoveTowards(transform.position,playerpos.position,0.01f);
            transform.LookAt(playerpos);
            for (int j = 0;j <= canoncount;j++)
            {
                enemycanon[j].transform.LookAt(playerpos);
            }
            if (time <= 0.0)
            {
                time = 1.5f;
                Magicshot();
            }
        }
        else
        {
            transform.position += transform.forward * move;
            if (time <= 0.0)
            {
                time = 3.0f;
                transform.rotation = new Quaternion(Random.Range(0,361),transform.rotation.y,Random.Range(0, 361), transform.rotation.w);
            }
        }
    }
    //Enemystatusからのenemydamageを保存
    public void Setenemydamage(int j)
    {
        enemydamage = j;
    }
    //攻撃
    public void Magicshot()
    {
        for(int j = 0;j <= canoncount;j++)
        {
            //1か2どちらかをランダムで選択
            shottype = Random.Range(1, 3);
            switch (shottype)
            {
                case 1:
                    enemymagic = Instantiate(magic1) as GameObject;
                    break;
                case 2:
                    enemymagic = Instantiate(magic2) as GameObject;
                    break;
            }
            //beam系の魔法の場合キャノンの子に設定
            if(enemymagic.name == "EnemyFireBeam(Clone)" || enemymagic.name == "EnemyDarkBeam(Clone)") enemymagic.transform.SetParent(enemycanon[j].transform, false);
            enemymagic.transform.rotation = enemycanon[j].transform.rotation;
            enemymagic.transform.position = enemycanon[j].transform.position;
            Magiccon magiccon = enemymagic.GetComponent<Magiccon>();
            magiccon.Enemymagicdamage(enemydamage);
        }
    }
}
