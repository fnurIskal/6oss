using UnityEngine;
using UnityEngine.UI;

public class MenuSesKontrol : MonoBehaviour
{
    public AudioClip ayarlarSesi;
    private Button ayarlarButonu;

    void Start()
    {
        // UI butonunu buluyoruz
        ayarlarButonu = GetComponent<Button>();

        // Butona týklandýðýnda çalýþacak fonksiyonu atýyoruz
        ayarlarButonu.onClick.AddListener(AyarlaraTiklandi);
    }

    void AyarlaraTiklandi()
    {
        // Sesi çal
        AudioSource audioKaynagi = GetComponent<AudioSource>();
        audioKaynagi.clip = ayarlarSesi;
        audioKaynagi.Play();

        // Burada baþka ayarlar yapabilirsiniz
    }
}