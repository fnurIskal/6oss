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

        // Butona t�kland���nda �al��acak fonksiyonu at�yoruz
        ayarlarButonu.onClick.AddListener(AyarlaraTiklandi);
    }

    void AyarlaraTiklandi()
    {
        // Sesi �al
        AudioSource audioKaynagi = GetComponent<AudioSource>();
        audioKaynagi.clip = ayarlarSesi;
        audioKaynagi.Play();

        // Burada ba�ka ayarlar yapabilirsiniz
    }
}