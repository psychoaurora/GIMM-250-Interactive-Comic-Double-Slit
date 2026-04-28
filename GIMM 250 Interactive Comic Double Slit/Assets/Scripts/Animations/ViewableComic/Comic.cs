using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Comic : MonoBehaviour
{
    [SerializeField] private ComicPanel[] panelOrder;

    [SerializeField] private GameObject exitButt;
    [SerializeField] private GameObject arrowButts;
    [SerializeField] private GameObject arrowBack;
    [SerializeField] private GameObject bgTop;

    public int CurrentPanel
    {
        get
        {
            return currentPanel;
        }
        set
        {
           //Debug.Log($"Panel Updated to {value}");
            if (currentPanel >= 0 && currentPanel < panelOrder.Length)
            {
                panelOrder[currentPanel].isOpen = false;
            }
            currentPanel = value;
            if (value >= 0 && value < panelOrder.Length)
            {
                panelOrder[value].isOpen = true;
            }

            arrowBack.SetActive(currentPanel > 0);
            arrowButts.SetActive(currentPanel < panelOrder.Length);
            exitButt.SetActive(currentPanel >= panelOrder.Length);
            bgTop.SetActive(currentPanel < panelOrder.Length);
        }
    }

    public int currentPanel = -1;
    public void NextPanel() => CurrentPanel++;
    public void PreviousPanel() => CurrentPanel--;

    public void SetPanel(int panel) => CurrentPanel = panel;
    private void Start()
    {
        //INTIALIZE BUTTONS IN PANELS

        for (int i = 0; i < panelOrder.Length; i++)
        {
            ComicPanel panel = panelOrder[i];
            Button butt = panel.gameObject.GetComponent<Button>();
            int curr = i;
            butt.onClick.AddListener(() => SetPanel(curr));
           // Debug.Log("ListenersAdded");
        }
    }
    private void Awake()
    {
        CurrentPanel = 0;

        arrowBack.SetActive(currentPanel > 0);
        arrowButts.SetActive(currentPanel < panelOrder.Length);
        exitButt.SetActive(currentPanel >= panelOrder.Length);
        bgTop.SetActive(currentPanel < panelOrder.Length);
    }
}
