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
        //调用触发器
        animator.SetTrigger(name: "Close_Trigger");
        //保证动画不是立即结束（以为动画执行过程比代码执行过程慢的多），所以添加协程
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
