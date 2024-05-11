using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestBase : MonoBehaviour
{
    public KeyCode keyCode = KeyCode.LeftControl;
    public Animator animator;
    public string triggerOpen = "Open";

    [Header("Notification")]
    public GameObject notification;
    public float tweenDuration = .2f;
    public Ease tweenBase = Ease.OutBack;

    [Space]
    public ChestItemBase chestItem;

    private float startScale;

    private bool _chestOpenned = false;

    private void Start()
    {
        startScale = notification.transform.localScale.x;
        HideNotification();
    }

    [NaughtyAttributes.Button]
    public void OpenChest()
    {
        if (_chestOpenned) return;
        animator.SetTrigger(triggerOpen);
        _chestOpenned = true;
        HideNotification();
        Invoke(nameof(ShowItem), 1f);
    }

    private void ShowItem()
    {
        chestItem.ShowItem();
        Invoke(nameof(CollectItem), 1f);
    }

    private void CollectItem()
    {
        chestItem.Collect();

    }

    private void OnTriggerEnter(Collider other)
    {
        Player p = other.GetComponent<Player>();
        if(p != null)
        {
            ShowNotification();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player p = other.GetComponent<Player>();
        if (p != null)
        {
            HideNotification();
        }
    }

    [NaughtyAttributes.Button]
    private void ShowNotification()
    {
        notification.SetActive(true);
        notification.transform.localScale = Vector3.zero;
        notification.transform.DOScale(startScale, tweenDuration);
    }

    [NaughtyAttributes.Button]
    private void HideNotification()
    {
        notification.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(keyCode) && notification.activeSelf)
        {
            OpenChest();
        }
    }
}
