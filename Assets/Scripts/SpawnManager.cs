using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject ShieldPowerUp;
    [SerializeField] private GameObject LifePowerup;
    private int spawnRangeX = 9;
    private int spawnRangeY = 4;

    [SerializeField] private GameObject BarrierPrefab;
    //使用列表更新barrier数据，提高程序效率
    public List<GameObject> barriers = new List<GameObject>();
    private int barriersAmount;
    private int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnShieldPowerUp", 5f, 5f);
        InvokeRepeating("SpawnLifePowerUp", 3f, 5f);
        SpawnBarrier(waveNumber);

    }
    private void Update()
    {
        barriersAmount = barriers.Count;
        if (barriersAmount == 0)
        {
            Debug.Log("spawn");

            waveNumber++;
            SpawnBarrier(waveNumber);
        }
    }
    public void SpawnShieldPowerUp()
    {
        Instantiate(ShieldPowerUp, GeneratePosition(), ShieldPowerUp.transform.rotation);
    }
    public void SpawnLifePowerUp()
    {
        Instantiate(LifePowerup, GeneratePosition(), LifePowerup.transform.rotation);
    }
    //生成 barrier
    public void SpawnBarrier(int SpawnNumber)
    {
        for (int i = 0; i < SpawnNumber; i++)
        {
            GameObject newBarrier = Instantiate(BarrierPrefab, GeneratePosition(), BarrierPrefab.transform.rotation);
            barriers.Add(newBarrier);

        }

    }
    public Vector3 GeneratePosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        //递归查找合适的位置，用到 OverlapSphere
        Collider[] hitColliders = Physics.OverlapSphere(randomPos, 3.0f);
        if (hitColliders != null && hitColliders.Length > 0)
        {
            //GeneratePosition();/*这里我没有考虑到子弹的存在，我认为子弹不应该在影响范围内*/
            foreach (Collider collider in hitColliders)
            {
                if (collider.CompareTag("Player") || collider.CompareTag("Barrier"))
                {
                    GeneratePosition();
                }
            }

        }
        return randomPos;
    }
}
