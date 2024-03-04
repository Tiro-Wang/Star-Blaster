using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;

public class DateManager : MonoBehaviour
{
    public static DateManager instance { get; private set; }//静态Instance用来数据持久化
    public float musicSettingValue;//存储用户在SettingDialog中修改 music的值
    public float SFXSettingValue;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);//销毁当前新加载的游戏对象
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);//将第一次数据缓存
    }
    [Serializable]
    class SavaDate
    {
        public float musicSetting;
        public float SFXSetting;
    }
    public void SaveMusicSetting()
    {
        SavaDate date = new SavaDate();
        date.musicSetting = musicSettingValue;

        var json = JsonConvert.SerializeObject(date);
        File.WriteAllText(Application.persistentDataPath + "/saveDate.json",json);
    }
}
