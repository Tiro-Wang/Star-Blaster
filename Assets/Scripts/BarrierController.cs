using UnityEngine;
using UnityEngine.UI;

public class BarrierController : MonoBehaviour
{
    private Vector3 randomDirection;
    private Vector3 randomAngle;
    private float moveSpeed = 1f;
    private float rotateSpeed = 2f;

    [SerializeField] private GameObject littleBarrier;
    private SpawnManager spawnManager;
    private GameManager gameManager;
    private PlayerController playerController;
    private int removeLife;

    private SFXManager sfxManager;

    void Start()
    {
        //��ȡ���ֵ
        randomDirection = RandomDirection();
        randomAngle = RandomAngle();

        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").gameObject.GetComponent<PlayerController>();
        sfxManager = GameObject.FindGameObjectWithTag("SFXManager").GetComponent<SFXManager>();
        spawnManager=GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //barrierƽ���ƶ��������� update�е���RandomDirection����������ֻ��ȡһ��ֵ�ᴩʼĩ
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime, Space.World);
        transform.Rotate(randomAngle * rotateSpeed * Time.deltaTime);
    }

    private Vector3 RandomDirection()
    {
        //�൱�ڷ�������
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        return new Vector3(x, y, 0);
    }
    private Vector3 RandomAngle()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        return new Vector3(x, y, z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!playerController.isShield)
            {
                //TODO:������
                removeLife = 1;

                gameManager.RemoveLife(removeLife);
                playerController.PlayerHitSound();
            }

            DestroySelf();
        }
        else if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            DestroySelf();
            gameManager.AddScore(10);
        }
    }
    private void DestroySelf()
    {
        spawnManager.barriers.Remove(gameObject);
        sfxManager.PlayBarrierDestroySFX();
        Destroy(gameObject);
        if (this.gameObject.name == "Barrier(Clone)")
        {
            CreateLittleBarrier();

        }
    }
    private void CreateLittleBarrier()
    {
        int random = Random.Range(1, 5);
        for (int i = 0; i < random; i++)
        {
           GameObject newLittleBarrier= Instantiate(littleBarrier, transform.position, littleBarrier.transform.rotation);
            spawnManager.barriers.Add(newLittleBarrier);
        }
    }
}
