using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private float timeToDie = 5f;

    //��ȡPlayer�µ�PlayerController�ű�
    private PlayerController playerController;
    private GameManager gameManager;
    private SFXManager sfxManager;
    //private GameObject player;
    // Start is called before the first frame update
    //ʹ��ö�ٸ�������������ض���ǩ
    public enum PowerupType
    {
        AddShield,
        AddLife
    }
    public  PowerupType powerupType;
    void Start()
    {
        //powerUp����ʱ��
        StartCoroutine(WaitToDie());

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        sfxManager=GameObject.FindGameObjectWithTag("SFXManager").GetComponent<SFXManager>();   
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);

        //Playerײ����ʾ����
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
