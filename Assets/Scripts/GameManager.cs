using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseScreen;

    public int lives { get; private set; }
    [SerializeField] private LifeUIController lifeUIController;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private TextMeshProUGUI scoreText;
    private int score=0;
    public bool isPause {  get; private set; }
    private void Start()
    {
        scoreText.text=score.ToString();
        lives = 3;
        lifeUIController.UpdateLives(lives);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        isPause = true;
        //��ʾ��ͣҳ��
        PauseScreen.SetActive(true);
        
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        isPause = false;
        PauseScreen.SetActive(false);
    }

    //��ʼ���ü���
/*    public void RestInfo()
    {
    }*/
    //ʵ�������Ӽ�����
    public void RemoveLife(int removeLife)
    {
        lives -= removeLife;
        lifeUIController.UpdateLives(lives);
        if(lives<=0)
        {

            GameOver();

        }
    }
    public void AddLife(int addLife)
    {
        lives += addLife;
        if (lives > 5)
        {
            lives = 5;
        }
        lifeUIController.UpdateLives(lives);
    }
    //�ӷֹ���
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }
    //ʵ�� gameOver ��ʾ gameOver sceneS
    public void GameOver()
    {
        player.SetActive(false);
        StartCoroutine(WaitToDie());
    }
    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(1f);//�ȴ����� gameOver
        gameOverScreen.SetActive(true);
    }
    //���¿�ʼ��Ϸ��Restart��ť��ӵ���¼�����������Ϸ����
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
