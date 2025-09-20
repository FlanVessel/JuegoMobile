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

    public bool IsShowing { get; private set; } = false;

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

        //Si la ventana esta ahi, no haces nada
        if (IsShowing) return;

        //Activamos el objeto
        windowCanvas.gameObject.SetActive(true);

        if (instant)
        {

            //Mostrar la ventana inmediatamente
            windowCanvasGroup.transform.DOScale(Vector3.one, 0f);

        }
        else
        {

            //Mostrar la ventana con animation time
            windowCanvasGroup.transform.DOScale(Vector3.one, animationTime).SetEase(easeShow);
            IsShowing = true;

        }
    }

    [Button]
    public virtual void Hide(bool instant = false)
    {
        //windowCanvas.gameObject.SetActive(false);

        if (instant)
        {

            //Ocultar la ventana inmediatamente
            windowCanvasGroup.transform.DOScale(Vector3.zero, 0f);

        }
        else
        {

            //Ocultar la ventana con animation time
            windowCanvasGroup.transform.DOScale(Vector3.zero, animationTime).SetEase(easeHide).OnComplete(DisableCanvas);

        }
    }

    private void DisableCanvas()
    {
        windowCanvas.gameObject.SetActive(false);
        IsShowing = false;
    }
}
