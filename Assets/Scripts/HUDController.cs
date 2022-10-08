using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _waveTimer;
    static public HUDController Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {

    }

    public void UpdateTimerText(int _time)
    {
        _waveTimer.text = _time.ToString() + "ñ";
    }
}
