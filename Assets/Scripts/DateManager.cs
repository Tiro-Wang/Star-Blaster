using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;

public class DateManager : MonoBehaviour
{
    public static DateManager instance { get; private set; }//��̬Instance�������ݳ־û�
    public float musicSettingValue;//�洢�û���SettingDialog���޸� music��ֵ
    public float SFXSettingValue;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);//���ٵ�ǰ�¼��ص���Ϸ����
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);//����һ�����ݻ���
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
