using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class UI_Window : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string windowID;
    [SerializeField] private Canvas windowCanvas;
    [SerializeField] private CanvasGroup windowCanvasGroup;

    [Header("Options")]
    [SerializeField] private bool hideOnStart = true;
    [SerializeField] public float animationTime = 0.5f;
    [SerializeField] public Ease easeHide = Ease.Flash;
    [SerializeField] public Ease easeShow = Ease.InBack;

    public string WindowID => windowID;

    public void Start()
    {
        Initialize();
    }

    public virtual void Initialize()
    {
        if (hideOnStart) Hide(true);
    }

    [Button]
    public virtual void Show(bool instant = false)
    {
        //windowCanvas.gameObject.SetActive(true);

        if (instant)
        {

            windowCanvasGroup.transform.DOScale(Vector3.one, 0f);

        }
        else
        {

            windowCanvasGroup.transform.DOScale(Vector3.one, animationTime).SetEase(easeShow);

        }
    }

    [Button]
    public virtual void Hide(bool instant = false)
    {
        //windowCanvas.gameObject.SetActive(false);

        if (instant)
        {

            windowCanvasGroup.transform.DOScale(Vector3.zero, 0f);

        }
        else
        {

            windowCanvasGroup.transform.DOScale(Vector3.zero, animationTime).SetEase(easeHide);

        }
    }
}
