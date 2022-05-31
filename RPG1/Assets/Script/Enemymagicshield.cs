using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemymagicshield : MonoBehaviour
{
    int shieldtype = 0;
    private MeshRenderer emisiion;
    private readonly string fire = "PlayerMagic1";
    private readonly string water = "PlayerMagic2";
    private readonly string wind = "PlayerMagic3";
    private readonly string light = "PlayerMagic4";
    private readonly string darkness = "PlayerMagic5";
    // Start is called before the first frame update
    void Start()
    {
        //1から5までランダムで選択
        shieldtype = Random.Range(1,6);
        emisiion = GetComponent<MeshRenderer>();
        emisiion.material.EnableKeyword("_EMISSION");
        switch (shieldtype)
        {
            //火
            case 1:
                emisiion.material.SetColor("_EmissionColor", new Color(1, 0, 0));
                break;
            //水
            case 2:
                emisiion.material.SetColor("_EmissionColor", new Color(0, 0.5f, 0));
                break;
            //風
            case 3:
                emisiion.material.SetColor("_EmissionColor", new Color(0.02f, 1, 0));
                break;
            //光
            case 4:
                emisiion.material.SetColor("_EmissionColor", new Color(1, 1, 0));
                break;
            //闇
            case 5:
                emisiion.material.SetColor("_EmissionColor", new Color(0.2f, 0, 1));
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //プレイヤーの魔法が当たったとき
    void OnTriggerEnter(Collider other)
    {
        switch (shieldtype)
        {
            //火
            case 1:
                if (other.gameObject.tag == fire)
                {
                    Destroy(other.gameObject);
                }
                break;
            //水
            case 2:
                if (other.gameObject.tag == water)
                {
                    Destroy(other.gameObject);
                }
                break;
            //風
            case 3:
                if (other.gameObject.tag == wind)
                {
                    Destroy(other.gameObject);
                }
                break;
            //光
            case 4:
                if (other.gameObject.tag == light)
                {
                    Destroy(other.gameObject);
                }
                break;
            //闇
            case 5:
                if (other.gameObject.tag == darkness)
                {
                    Destroy(other.gameObject);
                }
                break;
            default:
                break;
        }
    }
}
