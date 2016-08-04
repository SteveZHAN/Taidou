using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour 
{
    public static MessageManager _instance;

    public UILabel messageLabel;
    public TweenAlpha tween;

    private bool isSetActive = true;

    void Awake()
    {
        _instance = this;

        messageLabel = transform.Find("Label").GetComponent<UILabel>();
        tween = this.GetComponent<TweenAlpha>();

        EventDelegate ed = new EventDelegate(this, "OnTweenFinished");
        tween.onFinished.Add(ed);

        gameObject.SetActive(false);
    }

    public void ShowMessage(string message,float time=1)            //供外部调用的消息展示方法
    {
        gameObject.SetActive(true);
        StartCoroutine(Show(message, time));
    }

    IEnumerator Show(string message,float time)
    {
        isSetActive = true;
        tween.PlayForward();
        messageLabel.text = message;

        yield return new WaitForSeconds(time);
        isSetActive = false;
        tween.PlayReverse();
    }

    public void OnTweenFinished()
    {
        if (isSetActive == false)
        {
            gameObject.SetActive(false);
        }
    }

}
