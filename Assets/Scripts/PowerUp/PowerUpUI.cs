using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    [SerializeField] private Image icon, background;
    [SerializeField] private Text text;
    private float _timeLeft;
    private const float Height = 45;
    private int index = 100;
    private bool _hasSet;
    private PowerUpUIController _powerUpUIController;
    
    public void SetIcon(Sprite sprite, string name)
    {
        icon.sprite = sprite;
        text.text = name;
        _timeLeft = 6f;
        
        SetPosition();
        _hasSet = true;
    }

    private void Update()
    {
        if(!_hasSet) return;;
        
        _timeLeft -= Time.deltaTime;
        background.fillAmount = _timeLeft / 6f;
        if (_timeLeft < 0)
        {
            _powerUpUIController.slots[index] = false;
            Destroy(gameObject);
        }
    }

    private void SetPosition()
    {
        index = 0;
        _powerUpUIController = GameObject.FindWithTag("PowerUpUIController").GetComponent<PowerUpUIController>();
        for (int i = 0; i < _powerUpUIController.slots.Length; i++)
        {
            if (_powerUpUIController.slots[i]) continue;
            index = i;
            _powerUpUIController.slots[i] = true;
            break;
        }
        var rectTransform = GetComponent<RectTransform>();
        var pos = rectTransform.position;
        pos.y -= (Height + 10) * index;
        rectTransform.position = pos;
    }
}
