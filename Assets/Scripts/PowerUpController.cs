using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private float timeToDie = 5f;

    //获取Player下的PlayerController脚本
    private PlayerController playerController;
    private GameManager gameManager;
    private SFXManager sfxManager;
    //private GameObject player;
    // Start is called before the first frame update
    //使用枚举给两个物体添加特定标签
    public enum PowerupType
    {
        AddShield,
        AddLife
    }
    public  PowerupType powerupType;
    void Start()
    {
        //powerUp存在时间
        StartCoroutine(WaitToDie());

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        sfxManager=GameObject.FindGameObjectWithTag("SFXManager").GetComponent<SFXManager>();   
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);

        //Player撞到显示护盾
        if (other.CompareTag( "Player"))
        {
            sfxManager.PlayGetPowerUPSFX();
            if (powerupType == PowerupType.AddShield)
            {
                //other.gameObject.transform.Find("Shield").gameObject.SetActive(true);
                playerController.ActiveShield();
                //player.gameObject.transform.Find("Shield").gameObject.SetActive(true);

            }
            if(powerupType == PowerupType.AddLife)
            {
                gameManager.AddLife(1);
            }

        }
    }
    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(timeToDie);
        Destroy(gameObject);
    }
}
