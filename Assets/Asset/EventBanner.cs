using UnityEngine;
using TMPro;

public class EventBanner : MonoBehaviour
{
    [SerializeField] private GameObject banner;
    [SerializeField] private TextMeshProUGUI eventText;
    public void ShowBannerText(string text)
    {
        banner.SetActive(true);
        eventText.text = text;
    }
    public void HideBannerText()
    {
        banner.SetActive(false);
    }
}
