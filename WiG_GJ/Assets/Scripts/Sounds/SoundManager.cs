using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager m_instance;

    private static AudioSource m_audioSource;

    public GameObject menuAudio;
    public static AudioSource menuBackground;

    public GameObject gameAudio;
    public static AudioSource gameBackground;

    public static AudioClip pickUpAmmo;
    public static AudioClip fullLayerWin; 
    public static AudioClip jump;
    public static AudioClip bubbleHit;
    public static AudioClip bubbleFire;
    public static AudioClip die;
    public static AudioClip bumpInObstacle;

    // =================================

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (m_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();

        gameBackground = gameAudio.GetComponent<AudioSource>();
        menuBackground = menuAudio.GetComponent<AudioSource>();

        PlayBackground("menu");

        pickUpAmmo = Resources.Load<AudioClip>("Sounds/pickUpAmmo");
        fullLayerWin = Resources.Load<AudioClip>("Sounds/fullLayerWin");
        jump = Resources.Load<AudioClip>("Sounds/jump");
        bubbleHit = Resources.Load<AudioClip>("Sounds/bubbleHit");
        bubbleFire = Resources.Load<AudioClip>("Sounds/bubbleFire");
        die = Resources.Load<AudioClip>("Sounds/die");
        bumpInObstacle = Resources.Load<AudioClip>("Sounds/bumpInObstacle");
    }

    public static void PlayBackground(string name)
    {
        switch (name)
        {
            case "game":
                menuBackground.Stop();
                gameBackground.Play();
                break;

            case "menu":
                gameBackground.Stop();
                menuBackground.Play();
                break;
        }
    }

    public static void PlaySound(string name)
    {
        switch (name)
        {
            case "pickUpAmmo":
                m_audioSource.PlayOneShot(pickUpAmmo);
                break;

            case "fullLayerWin":
                m_audioSource.PlayOneShot(fullLayerWin);
                break;

            case "jump":
                m_audioSource.PlayOneShot(jump);
                break;

            case "bubbleHit":
                m_audioSource.PlayOneShot(bubbleHit);
                break;

            case "bubbleFire":
                m_audioSource.PlayOneShot(bubbleFire);
                break;

            case "die":
                m_audioSource.PlayOneShot(die);
                break;

            case "bumpInObstacle":
                m_audioSource.PlayOneShot(bumpInObstacle);
                break;
        }
    }
}
