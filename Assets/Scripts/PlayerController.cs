using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 mousePos;

    [SerializeField] private Rigidbody playerRb;

    private float forwardInput;
    private float sideInput;

    private float thrust = 200.0f;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletAnchor;

    [SerializeField] private GameObject shield;
    private float TimeForShieldActive = 3f;

    private GameManager gameManager;

    private SFXManager sfxManager;
    //粒子
    [SerializeField]private ParticleSystem engineTail;
    private float boostSpeed = 300f;
    public bool isShield { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        sfxManager = GameObject.FindGameObjectWithTag("SFXManager").GetComponent<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isPause)
        {
            forwardInput = Input.GetAxis("Vertical");
            sideInput = Input.GetAxis("Horizontal");
            //rotate to look at mouse
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            transform.LookAt(mousePos, Vector3.back);
            //move
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * thrust);
            playerRb.AddRelativeForce(Vector3.right * sideInput * thrust, ForceMode.Force);

            //发射子弹
            if (Input.GetMouseButtonDown(0))
            {
                FireShot();
            }
            //粒子&&加速
            if (Input.GetKeyDown(KeyCode.W))
                engineTail.Play();
            else if (Input.GetKeyUp(KeyCode.W))
                engineTail.Stop();

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerRb.AddRelativeForce(Vector3.forward * boostSpeed, ForceMode.Impulse);
                engineTail.Play();
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
                engineTail.Stop();

        }

    }

    public void ActiveShield()
    {
        isShield = true;
        //TODO:实现护盾防护功能
        shield.SetActive(true);
        //护盾存在时间
        StartCoroutine(ShieldTimer());
    }
    IEnumerator ShieldTimer()
    {
        yield return new WaitForSeconds(TimeForShieldActive);
        shield.SetActive(false);
        isShield = false;
    }
    public void FireShot()
    {
        //bullet发射的声音
        sfxManager.PlayPlayerShotSFX();
        Vector3 lookPos = mousePos - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(lookPos, Vector3.forward);
        Instantiate(bulletPrefab, bulletAnchor.transform.position, lookRotation);
    }
    public void PlayerHitSound()
    {
        if (gameManager.lives == 0)
        {
            sfxManager.PlayPlayerDestroySFX();
        }
        else if (gameManager.lives > 0)
        {
            sfxManager.PlayPlayerHitSFX();
        }
    }

}
