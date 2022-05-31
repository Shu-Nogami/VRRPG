using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    int[] magictype = new int[7];
    bool shortcut = false;
    public Transform magiccircle;
    public GameObject fireball;
    public GameObject waterball;
    public GameObject windball;
    public GameObject lightball;
    public GameObject darkball;
    public GameObject firebeam;
    public GameObject waterblade;
    public GameObject windblade;
    public GameObject lightblade;
    public GameObject darkbeam;
    public GameObject firepillar;
    public GameObject waterground;
    public GameObject basicball;
    public GameObject darkness;
    public GameObject player;
    public Transform playerpos;
    public GameObject playersword;
    public ParticleSystem fire;
    public ParticleSystem water;
    public ParticleSystem wind;
    public ParticleSystem light;
    public ParticleSystem dark;
    public ParticleSystem destroy;
    private MeshRenderer emisiion;
    GameObject playerswordblade;
    GameObject playerelementrocation;
    bool magicresponse = true;
    bool mana = true;
    public bool[] tp = new bool[3];
    bool timecount = false;
    GameObject tprocation;
    public float magicscale1;
    public int BeginnerMagic;
    public int MiddleMagic;
    public int BeginnerAuxiliaryMagic;
    public int MiddleAuxiliaryMagic;
    public int EnchantmentMagic;
    public int UltimateMagic;
    public int Tp;
    public float time = 0;
    public int enchantmentnumber;
    bool[] magic = new bool[1000];
    int[] enemycount = new int[10];
    int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0;i < 1000;i++)
        {
            magic[i] = true;
        }
        for (int i = 0;i < 10;i++)
        {
            enemycount[i] = 0;
        }
        for(int i = 0;i < 7; i++)
        {
            magictype[0] = 0;
        }
        playerswordblade = GameObject.Find("swordbread2");
        playerelementrocation = GameObject.Find("Elementrocation");
    }

    // Update is called once per frame
    void Update()
    {
        if (timecount == true)
        {
            time += Time.deltaTime;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstick))
        {
            shortcut = true;
        }
        if (time >= 7)
        {
            switch (enchantmentnumber)
            {
                case 1:
                    Destroy(fire);
                    break;
                case 2:
                    Destroy(water);
                    break;
                case 3:
                    Destroy(wind);
                    break;
                case 4:
                    Destroy(light);
                    break;
                case 5:
                    Destroy(dark);
                    break;
            }
            timecount = false;
            time = 0;
            playerswordblade.tag = "PlayerBlade";
        }
        Playerstatus status = player.GetComponent<Playerstatus>();
        emisiion = playerswordblade.GetComponent<MeshRenderer>();
        emisiion.material.EnableKeyword("_EMISSION");
        //魔法コマンドを入力
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            magictype[0] += 1;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            magictype[0] += 10;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            magictype[0] += 100;
        }
        //ショートカットの魔法を出力
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstick))
        {
            if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                magictype[0] = magictype[1];
            }
            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                magictype[0] = magictype[2];
            }
            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                magictype[0] = magictype[3];
            }
            if (OVRInput.GetDown(OVRInput.RawButton.X))
            {
                magictype[0] = magictype[4];
            }
            if (OVRInput.GetDown(OVRInput.RawButton.Y))
            {
                magictype[0] = magictype[5];
            }
            if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                magictype[0] = magictype[6];
            }
        }
        //魔法発動
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            if (magicresponse == true && shortcut == false)
            {
                switch (magictype[0])
                {
                    //Fireball
                    case 111:
                        mana = status.Setmana(BeginnerMagic);
                        if (mana == true)
                        {
                            GameObject playermagic = Instantiate(fireball) as GameObject;
                            playermagic.transform.position = magiccircle.position;
                            playermagic.transform.rotation = magiccircle.rotation;
                            magicresponse = false;
                            Invoke("Magiclifted", magicscale1);
                        }
                        break;
                    //Waterball
                    case 112:
                        mana = status.Setmana(BeginnerMagic);
                        if (mana == true)
                        {
                            GameObject playermagic = Instantiate(waterball) as GameObject;
                            playermagic.transform.position = magiccircle.position;
                            playermagic.transform.rotation = magiccircle.rotation;
                            magicresponse = false;
                            Invoke("Magiclifted", magicscale1);
                        }
                        break;
                    //Windball
                    case 113:
                        mana = status.Setmana(BeginnerMagic);
                        if (mana == true)
                        {
                            GameObject playermagic = Instantiate(windball) as GameObject;
                            playermagic.transform.position = magiccircle.position;
                            playermagic.transform.rotation = magiccircle.rotation;
                            magicresponse = false;
                            Invoke("Magiclifted", magicscale1);
                        }
                        break;
                    //Lightball
                    case 114:
                        if(magic[114] == true)
                        {
                            mana = status.Setmana(BeginnerMagic);
                            if (mana == true)
                            {
                                GameObject playermagic = Instantiate(lightball) as GameObject;
                                playermagic.transform.position = magiccircle.position;
                                playermagic.transform.rotation = magiccircle.rotation;
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Darkball
                    case 115:
                        if(magic[115] == true)
                        {
                            mana = status.Setmana(BeginnerMagic);
                            if (mana == true)
                            {
                                GameObject playermagic = Instantiate(darkball) as GameObject;
                                playermagic.transform.position = magiccircle.position;
                                playermagic.transform.rotation = magiccircle.rotation;
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Fireboost
                    case 131:
                        if (magic[131] == true)
                        {
                            mana = status.Setmana(BeginnerAuxiliaryMagic);
                            if (mana == true)
                            {
                                status.Abnormalstates(1);
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Waterboost
                    case 132:
                        if (magic[132] == true)
                        {
                            mana = status.Setmana(BeginnerAuxiliaryMagic);
                            if (mana == true)
                            {
                                status.Abnormalstates(2);
                            }
                        }
                        break;
                    //Windboost
                    case 133:
                        if (magic[133] == true)
                        {
                            mana = status.Setmana(BeginnerAuxiliaryMagic);
                            if (mana == true)
                            {
                                status.Abnormalstates(3);
                            }
                        }
                        break;
                    //Lightheal
                    case 134:
                        if (magic[134] == true)
                        {
                            mana = status.Setmana(BeginnerAuxiliaryMagic);
                            if (mana == true)
                            {
                                status.Abnormalstates(4);
                            }
                        }
                        break;
                    //Magicdestroy
                    case 135:
                        if (magic[135] == true)
                        {
                            mana = status.Setmana(BeginnerAuxiliaryMagic);
                            if (mana == true)
                            {
                                status.Abnormalstates(5);
                            }
                        }
                        break;
                    //Firebeam
                    case 221:
                        if (magic[221] == true)
                        {
                            mana = status.Setmana(MiddleMagic);
                            if (mana == true)
                            {
                                GameObject playermagic = Instantiate(firebeam) as GameObject;
                                playermagic.transform.SetParent(magiccircle.transform, false);
                                playermagic.transform.position = magiccircle.position;
                                playermagic.transform.rotation = magiccircle.rotation;
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Waterblade
                    case 242:
                        if (magic[242] == true)
                        {
                            mana = status.Setmana(MiddleMagic);
                            if (mana == true)
                            {
                                for (int i = 1; i <= 2; i++)
                                {
                                    GameObject playermagic = Instantiate(waterblade) as GameObject;
                                    playermagic.transform.rotation = Quaternion.Euler(magiccircle.rotation.x, magiccircle.rotation.y - 90, magiccircle.rotation.z);
                                    if (i == 1)
                                    {
                                        playermagic.transform.position = new Vector3(magiccircle.position.x + 0.5f, magiccircle.position.y, magiccircle.position.z);
                                    }
                                    else
                                    {
                                        playermagic.transform.position = new Vector3(magiccircle.position.x - 0.5f, magiccircle.position.y, magiccircle.position.z);
                                    }
                                }
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Windblade
                    case 243:
                        if (magic[243] == true)
                        {
                            mana = status.Setmana(MiddleMagic);
                            if (mana == true)
                            {
                                GameObject playermagic1 = Instantiate(windblade) as GameObject;
                                playermagic1.transform.position = magiccircle.position;
                                playermagic1.transform.rotation = magiccircle.rotation;
                                GameObject playermagic2 = Instantiate(windblade) as GameObject;
                                playermagic2.transform.position = magiccircle.position;
                                playermagic2.transform.rotation = magiccircle.rotation;
                                GameObject playermagic3 = Instantiate(windblade) as GameObject;
                                playermagic3.transform.position = magiccircle.position;
                                playermagic3.transform.rotation = magiccircle.rotation;
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Lightblade
                    case 244:
                        if (magic[244] == true)
                        {
                            mana = status.Setmana(MiddleMagic);
                            if (mana == true)
                            {
                                GameObject playermagic = Instantiate(lightblade) as GameObject;
                                playermagic.transform.position = magiccircle.position;
                                playermagic.transform.rotation = magiccircle.rotation;
                                for (int i = 1; i <= 2; i++)
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Darkbeam
                    case 225:
                        if (magic[225] == true)
                        {
                            mana = status.Setmana(MiddleMagic);
                            if (mana == true)
                            {
                                GameObject playermagic = Instantiate(darkbeam) as GameObject;
                                playermagic.transform.SetParent(magiccircle.transform, false);
                                playermagic.transform.position = magiccircle.position;
                                playermagic.transform.rotation = magiccircle.rotation;
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Highboost:Fire
                    case 231:
                        if (magic[231] == true)
                        {
                            mana = status.Setmana(MiddleAuxiliaryMagic);
                            if (mana == true)
                            {
                                status.Abnormalstates(11);
                            }
                        }
                        break;
                    //Highboost:Water
                    case 232:
                        if (magic[232] == true)
                        {
                            mana = status.Setmana(MiddleAuxiliaryMagic);
                            if (mana == true)
                            {
                                status.Abnormalstates(12);
                            }
                        }
                        break;
                    //Highboost:Wind
                    case 233:
                        if (magic[233] == true)
                        {
                            mana = status.Setmana(MiddleAuxiliaryMagic);
                            if (mana == true)
                            {
                                status.Abnormalstates(13);
                            }
                        }
                        break;
                    //Highheal
                    case 234:
                        if (magic[234] == true)
                        {
                            mana = status.Setmana(MiddleAuxiliaryMagic);
                            if (mana == true)
                            {
                                status.Abnormalstates(14);
                            }
                        }
                        break;
                    //Highdestroy
                    case 265:
                        if (magic[265] == true)
                        {
                            mana = status.Setmana(MiddleAuxiliaryMagic);
                            if (mana == true)
                            {
                                status.Abnormalstates(15);
                            }
                        }
                        break;
                    //Enchant:Fire
                    case 361:
                        if (magic[361] == true)
                        {
                            mana = status.Setmana(EnchantmentMagic);
                            if (mana == true)
                            {
                                emisiion.material.SetColor("_EmissionColor", new Color(1, 0, 0));
                                fire.transform.SetParent(playersword.transform, false);
                                fire.transform.position = playerelementrocation.transform.position;
                                fire.Play();
                                playerswordblade.tag = "PlayerMagic1";
                                timecount = true;
                                enchantmentnumber = 1;
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Enchant:Water
                    case 362:
                        if (magic[362] == true)
                        {
                            mana = status.Setmana(EnchantmentMagic);
                            if (mana == true)
                            {
                                emisiion.material.SetColor("_EmissionColor", new Color(0, 0.5f, 0));
                                water.transform.SetParent(playersword.transform, false);
                                water.transform.position = playerelementrocation.transform.position;
                                water.Play();
                                playerswordblade.tag = "PlayerMagic2";
                                timecount = true;
                                enchantmentnumber = 2;
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Enchant:Wind
                    case 363:
                        if (magic[363] == true)
                        {
                            mana = status.Setmana(EnchantmentMagic);
                            if (mana == true)
                            {
                                emisiion.material.SetColor("_EmissionColor", new Color(0.02f, 1, 0));
                                wind.transform.SetParent(playersword.transform, false);
                                wind.transform.position = playerelementrocation.transform.position;
                                wind.Play();
                                playerswordblade.tag = "PlayerMagic3";
                                timecount = true;
                                enchantmentnumber = 3;
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Enchant:Light
                    case 364:
                        if (magic[364] == true)
                        {
                            mana = status.Setmana(EnchantmentMagic);
                            if (mana == true)
                            {
                                emisiion.material.SetColor("_EmissionColor", new Color(1, 1, 0));
                                light.transform.SetParent(playersword.transform, false);
                                light.transform.position = playerelementrocation.transform.position;
                                light.Play();
                                playerswordblade.tag = "PlayerMagic4";
                                timecount = true;
                                enchantmentnumber = 4;
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Enchant:Dark
                    case 365:
                        if (magic[365] == true)
                        {
                            mana = status.Setmana(EnchantmentMagic);
                            if (mana == true)
                            {
                                emisiion.material.SetColor("_EmissionColor", new Color(0.2f, 0, 1));
                                dark.transform.SetParent(playersword.transform, false);
                                dark.transform.position = playerelementrocation.transform.position;
                                dark.Play();
                                playerswordblade.tag = "PlayerMagic5";
                                timecount = true;
                                enchantmentnumber = 5;
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Firepillar
                    case 551:
                        if (magic[551] == true)
                        {
                            mana = status.Setmana(UltimateMagic);
                            if (mana == true)
                            {
                                for (int i = 0; i <= 3; i++)
                                {
                                    GameObject playermagic = Instantiate(firepillar) as GameObject;
                                    float terrainhight;
                                    switch (i)
                                    {
                                        case 0:
                                            terrainhight = Terrain.activeTerrain.SampleHeight(new Vector3(playerpos.position.x + 10, playerpos.position.y, playerpos.position.z));
                                            playermagic.transform.position = new Vector3(playerpos.position.x + 10, terrainhight, playerpos.position.z);
                                            break;
                                        case 1:
                                            terrainhight = Terrain.activeTerrain.SampleHeight(new Vector3(playerpos.position.x - 10, playerpos.position.y, playerpos.position.z));
                                            playermagic.transform.position = new Vector3(playerpos.position.x - 10, terrainhight, playerpos.position.z);
                                            break;
                                        case 2:
                                            terrainhight = Terrain.activeTerrain.SampleHeight(new Vector3(playerpos.position.x, playerpos.position.y, playerpos.position.z + 10));
                                            playermagic.transform.position = new Vector3(playerpos.position.x, terrainhight, playerpos.position.z + 10);
                                            break;
                                        case 3:
                                            terrainhight = Terrain.activeTerrain.SampleHeight(new Vector3(playerpos.position.x, playerpos.position.y, playerpos.position.z - 10));
                                            playermagic.transform.position = new Vector3(playerpos.position.x, terrainhight, playerpos.position.z - 10);
                                            break;
                                    }
                                }
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Waterground
                    case 552:
                        if (magic[552] == true)
                        {
                            mana = status.Setmana(UltimateMagic);
                            if (mana == true)
                            {
                                GameObject playermagic = Instantiate(waterground) as GameObject;
                                playermagic.transform.position = playerpos.position;
                                playermagic.transform.SetParent(playerpos, false);
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Ultimateboost
                    case 533:
                        if (magic[533] == true)
                        {
                            mana = status.Setmana(UltimateMagic);
                            if (mana == true)
                            {
                                status.Abnormalstates(23);
                            }
                        }
                        break;
                    //Perfectprotect
                    case 534:
                        if (magic[534] == true)
                        {
                            mana = status.Setmana(UltimateMagic);
                            if (mana == true)
                            {
                                status.Abnormalstates(24);
                            }

                        }
                        break;
                    //Darknessburst
                    case 575:
                        if (magic[575] == true)
                        {
                            mana = status.Setmana(UltimateMagic);
                            if (mana == true)
                            {
                                GameObject playermagic1 = Instantiate(basicball) as GameObject;
                                playermagic1.transform.position = magiccircle.position;
                                playermagic1.transform.rotation = magiccircle.rotation;
                                InvokeRepeating("Ultdark", 1, 0.5f);
                                magicresponse = false;
                                Invoke("Magiclifted", magicscale1);
                            }
                        }
                        break;
                    //Fireteleport
                    case 831:
                        if (magic[831] == true)
                        {
                            mana = status.Setmana(Tp);
                            if (mana == true)
                            {
                                tprocation = GameObject.Find("Firetprocation");
                                if (tp[0] == true)
                                {
                                    GameObject.Find("OVRPlayerController").transform.position = tprocation.transform.position;
                                    GameObject.Find("OVRPlayerController").transform.rotation = tprocation.transform.rotation;
                                }
                            }
                        }
                        break;
                    //Waterteleport
                    case 832:
                        if (magic[832] == true)
                        {
                            mana = status.Setmana(Tp);
                            if (mana == true)
                            {
                                tprocation = GameObject.Find("Watertprocation");
                                if (tp[1] == true)
                                {
                                    GameObject.Find("OVRPlayerController").transform.position = tprocation.transform.position;
                                    GameObject.Find("OVRPlayerController").transform.rotation = tprocation.transform.rotation;
                                }
                            }

                        }
                        break;
                    //Windteleport
                    case 833:
                        if (magic[833] == true)
                        {
                            mana = status.Setmana(Tp);
                            if (mana == true)
                            {
                                tprocation = GameObject.Find("Windtprocation");
                                if (tp[2] == true)
                                {
                                    GameObject.Find("OVRPlayerController").transform.position = tprocation.transform.position;
                                    GameObject.Find("OVRPlayerController").transform.rotation = tprocation.transform.rotation;
                                }
                            }
                        }
                        break;
                    //DEteleport
                    case 834:
                        mana = status.Setmana(Tp);
                        if (mana == true)
                        {
                            tprocation = GameObject.Find("dark&lighttprocation");
                            GameObject.Find("OVRPlayerController").transform.position = tprocation.transform.position;
                            GameObject.Find("OVRPlayerController").transform.rotation = tprocation.transform.rotation;
                        }
                        break;
                    //Holyknight
                    case 934:
                        if (magic[934] == true)
                        {
                            status.Abnormalstates(34);
                            magicresponse = false;
                        }
                        break;
                    //Demon
                    case 935:
                        if (magic[935] == true)
                        {
                            status.Abnormalstates(35);
                            magicresponse = false;
                        }
                        break;
                    default:
                        break;
                }
            }
            //ショートカット作成
            else if (shortcut == true)
            {
                if (OVRInput.GetDown(OVRInput.RawButton.A))
                {
                    magictype[1] = magictype[0];
                }
                if (OVRInput.GetDown(OVRInput.RawButton.B))
                {
                    magictype[2] = magictype[0];
                }
                if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
                {
                    magictype[3] = magictype[0];
                }
                if (OVRInput.GetDown(OVRInput.RawButton.X))
                {
                    magictype[4] = magictype[0];
                }
                if (OVRInput.GetDown(OVRInput.RawButton.Y))
                {
                    magictype[5] = magictype[0];
                }
                if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
                {
                    magictype[6] = magictype[0];
                }
            }
            magictype[0] = 0;
            shortcut = false;
        }
    }
    //魔法使用可
    public void Magiclifted()
    {
        magicresponse = true;
    }
    //敵の討伐数を保存
    public void Setenemycount(int count)
    {
        enemycount[count]++;
        Magicuse();
    }
    //Darknessburst作成
    public void Ultdark()
    {
        Transform playermagic1 = GameObject.Find("basicball(Clone)").transform;
        float terrainhight = Terrain.activeTerrain.SampleHeight(playermagic1.position);
        switch (count)
        {
            case 1:
                GameObject playermagic2 = Instantiate(darkness) as GameObject;
                playermagic2.transform.position = new Vector3(playermagic1.position.x, terrainhight, playermagic1.position.z);
                count++;
                break;
            case 2:
                GameObject playermagic3 = Instantiate(darkness) as GameObject;
                playermagic3.transform.position = new Vector3(playermagic1.position.x, terrainhight, playermagic1.position.z);
                count++;
                break;
            case 3:
                GameObject playermagic4 = Instantiate(darkness) as GameObject;
                playermagic4.transform.position = new Vector3(playermagic1.position.x, terrainhight, playermagic1.position.z);
                count++;
                break;
            case 4:
                GameObject playermagic5 = Instantiate(darkness) as GameObject;
                playermagic5.transform.position = new Vector3(playermagic1.position.x, terrainhight, playermagic1.position.z);
                count++;
                Debug.Log(count);
                break;
            case 5:
                GameObject playermagic6 = Instantiate(darkness) as GameObject;
                playermagic6.transform.position = new Vector3(playermagic1.position.x, terrainhight, playermagic1.position.z);
                count = 1;
                CancelInvoke();
                break;
        }
    }
    //魔法取得
    public void Magicuse()
    {
        /* trueで取得済み
         * enemycount[0] →　Prototype01
         * enemycount[1] →　Prototype02
         * enemycount[2] →　Prototype03
         * enemycount[3] →　Prototype04
         * enemycount[4] →　Prototype05
         * enemycount[5] →　Prototype06
         * enemycount[6] →　Prototype07
         * enemycount[7] →　Fireboss
         * enemycount[8] →　Waterboss
         * enemycount[9] →　Windboss
         * */
        if (enemycount[0] >= 5)
        {
            magic[114] = true;
            magic[115] = true;
        }
        if (enemycount[0] >= 3 && enemycount[3] >= 5) magic[131] = true;
        if (enemycount[0] >= 3 && enemycount[2] >= 5) magic[132] = true;
        if (enemycount[0] >= 3 && enemycount[1] >= 5) magic[133] = true;
        if (enemycount[0] >= 3 && enemycount[1] >= 2 && enemycount[3] >= 2) magic[134] = true;
        if (enemycount[0] >= 3 && enemycount[2] >= 2 && enemycount[3] >= 2) magic[135] = true;
        if (enemycount[3] >= 10 && enemycount[4] >= 3) magic[221] = true;
        if (enemycount[2] >= 10 && enemycount[6] >= 3) magic[242] = true;
        if (enemycount[1] >= 10 && enemycount[5] >= 3) magic[243] = true;
        if (magic[114] == true && enemycount[0] >= 10 && enemycount[5] >= 2 && enemycount[6] >= 2) magic[244] = true;
        if (magic[115] == true && enemycount[0] >= 10 && enemycount[4] >= 2 && enemycount[6] >= 2) magic[225] = true;
        if (magic[131] == true && enemycount[4] >= 10) magic[231] = true;
        if (magic[132] == true && enemycount[6] >= 10) magic[232] = true;
        if (magic[133] == true && enemycount[5] >= 10) magic[233] = true;
        if (magic[134] == true && enemycount[5] >= 8 && enemycount[6] >= 8) magic[234] = true;
        if (magic[135] == true && enemycount[4] >= 8 && enemycount[6] >= 8) magic[265] = true;
        if (enemycount[3] >= 20 && enemycount[4] >= 15) magic[361] = true;
        if (enemycount[2] >= 20 && enemycount[7] >= 15) magic[362] = true;
        if (enemycount[1] >= 20 && enemycount[5] >= 15) magic[363] = true;
        if (enemycount[1] >= 20 && enemycount[6] >= 15) magic[364] = true;
        if (enemycount[2] >= 20 && enemycount[6] >= 15) magic[365] = true;
        if (enemycount[7] == 1) magic[551] = true;
        if (enemycount[8] == 1) magic[552] = true;
        if (enemycount[9] == 1) magic[533] = true;
        if (enemycount[5] >= 25 && enemycount[6] >= 25) magic[534] = true;
        if (enemycount[7] == 1 && enemycount[8] == 1 && enemycount[9] == 1 &&enemycount[4] >= 25 && enemycount[6] >= 25) magic[575] = true;
        if (enemycount[7] == 1) magic[831] = true;
        if (enemycount[8] == 1) magic[832] = true;
        if (enemycount[9] == 1) magic[833] = true;
        if (enemycount[2] >= 15 && enemycount[5] >= 15) magic[934] = true;
        if (enemycount[1] >= 15 && enemycount[4] >= 15) magic[935] = true;
    }
}
