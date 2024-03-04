using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBase : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    /*    void Awake()
        {
            animator = GetComponent<Animator>();
        }*/
    /*    void Start()
        {
            animator = GetComponent<Animator>();
        }*/
    public virtual void OpenDialog()
    {
        animator = GetComponent<Animator>();

        this.gameObject.SetActive(true);
    }
    public void CloseDialog()
    {
        //���ô�����
        animator.SetTrigger(name: "Close_Trigger");
        //��֤��������������������Ϊ����ִ�й��̱ȴ���ִ�й������Ķࣩ���������Э��
        StartCoroutine(Close());
        /*        gameObject.SetActive(false);
                Debug.Log("close");*/

    }
    public IEnumerator Close()
    {
        Debug.Log("close");

        yield return new WaitForSecondsRealtime(0.3f);
        gameObject.SetActive(false);
    }

}
