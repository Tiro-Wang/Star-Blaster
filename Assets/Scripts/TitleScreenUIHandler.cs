using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUIHandler : MonoBehaviour
{
    [SerializeField] private HowToPlayDialog howToPlayDialog;
    [SerializeField] private SettingsDialog settingsDialog;
    //开始游戏
    public void StartNew()
    {
        SceneManager.LoadScene(1);

    }
    //退出游戏
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    //打开HowToPlayDialog
    public void OpenHowToPlayDialog()
    {
        /*  这是一个错误，基础错误，理解错误，实例化后的对象和以前还一样嘛？！！当然不一样了
         *  HowToPlayDialog howToPlayDialog = new HowToPlayDialog();
                howToPlayDialog.Open();*/
        //howToPlayDialog.SetActive(true);
        howToPlayDialog.OpenDialog();
    }
    //打开SettingsDialog
    public void OpenSettingsDialog()
    {
        settingsDialog.OpenDialog();
    }
}
