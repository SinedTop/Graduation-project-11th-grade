using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventoryCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    [SerializeField] private TextMeshProUGUI _stackText, _descriptionText;
    [SerializeField] private GameObject _descriptionObj;
    [SerializeField] private Image _icon;
    public int _currentStack;

    public void AddItemToCell(Item _currentItem)
    {
        if (_currentStack > _currentItem._maxStack) return;

        _currentStack++;
        _stackText.text = _currentStack.ToString() + "/" + _currentItem._maxStack.ToString();
        _descriptionText.text = _currentItem._descriptionRU;
        _icon.sprite = _currentItem._image;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _descriptionObj.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _descriptionObj.SetActive(false);
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        _descriptionObj.transform.position = eventData.position;
    }
}
