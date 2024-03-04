using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUIHandler : MonoBehaviour
{
    [SerializeField] private HowToPlayDialog howToPlayDialog;
    [SerializeField] private SettingsDialog settingsDialog;
    //��ʼ��Ϸ
    public void StartNew()
    {
        SceneManager.LoadScene(1);

    }
    //�˳���Ϸ
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    //��HowToPlayDialog
    public void OpenHowToPlayDialog()
    {
        /*  ����һ�����󣬻�������������ʵ������Ķ������ǰ��һ���������Ȼ��һ����
         *  HowToPlayDialog howToPlayDialog = new HowToPlayDialog();
                howToPlayDialog.Open();*/
        //howToPlayDialog.SetActive(true);
        howToPlayDialog.OpenDialog();
    }
    //��SettingsDialog
    public void OpenSettingsDialog()
    {
        settingsDialog.OpenDialog();
    }
}
