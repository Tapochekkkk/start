using UnityEngine;
using UnityEngine.UI;

public class TripleCharacterDoorSystem : MonoBehaviour
{
    [Header("UI Settings")]
    public GameObject selectionPanel;
    public Button redDoorButton;
    public Button blueDoorButton;
    public Button defaultDoorButton;
    public Text statusText;

    [Header("Door Colliders")]
    public Collider2D redDoorCollider;
    public Collider2D blueDoorCollider;
    public Collider2D defaultDoorCollider;

    [Header("Character Models")]
    public GameObject defaultModel;
    public GameObject redModel;
    public GameObject blueModel;

    [Header("Effects")]
    public float switchDelay = 0.3f;
    public ParticleSystem transformEffect;
    public AudioClip transformSound;

    private enum CharacterForm { Default, Red, Blue }
    private CharacterForm currentForm = CharacterForm.Default;
    private bool isPanelActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleSelectionPanel();
        }
    }

    void Start()
    {
        InitializeSystem();
    }

    void InitializeSystem()
    {
        selectionPanel.SetActive(false);
        redModel.SetActive(false);
        blueModel.SetActive(false);
        defaultModel.SetActive(true);

        redDoorButton.onClick.AddListener(() => SelectForm(CharacterForm.Red));
        blueDoorButton.onClick.AddListener(() => SelectForm(CharacterForm.Blue));
        defaultDoorButton.onClick.AddListener(() => SelectForm(CharacterForm.Default));
    }

    void ToggleSelectionPanel()
    {
        isPanelActive = !isPanelActive;
        selectionPanel.SetActive(isPanelActive);
        Time.timeScale = isPanelActive ? 0f : 1f;
        UpdateStatusText();
    }

    void SelectForm(CharacterForm newForm)
    {
        if (newForm != currentForm)
        {
            currentForm = newForm;
            Invoke("SwitchCharacterModel", switchDelay);
            UpdateDoors();
            PlayEffects();
        }
        ClosePanel();
    }

    void SwitchCharacterModel()
    {
        defaultModel.SetActive(false);
        redModel.SetActive(false);
        blueModel.SetActive(false);

        switch (currentForm)
        {
            case CharacterForm.Red:
                redModel.SetActive(true);
                break;
            case CharacterForm.Blue:
                blueModel.SetActive(true);
                break;
            default:
                defaultModel.SetActive(true);
                break;
        }
    }

    void UpdateDoors()
    {
        redDoorCollider.enabled = false;
        blueDoorCollider.enabled = false;
        defaultDoorCollider.enabled = false;

        switch (currentForm)
        {
            case CharacterForm.Red:
                redDoorCollider.enabled = true;
                break;
            case CharacterForm.Blue:
                blueDoorCollider.enabled = true;
                break;
            default:
                defaultDoorCollider.enabled = true;
                break;
        }
    }

    void PlayEffects()
    {
        if (transformEffect != null)
        {
            transformEffect.Play();
        }

        if (transformSound != null)
        {
            AudioSource.PlayClipAtPoint(transformSound, transform.position);
        }
    }

    void UpdateStatusText()
    {
        string formName = "";
        switch (currentForm)
        {
            case CharacterForm.Red:
                formName = "Красная форма";
                break;
            case CharacterForm.Blue:
                formName = "Синяя форма";
                break;
            default:
                formName = "Обычная форма";
                break;
        }
        statusText.text = $"Текущая форма: {formName}\nВыберите новую форму:";
    }

    void ClosePanel()
    {
        isPanelActive = false;
        selectionPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}