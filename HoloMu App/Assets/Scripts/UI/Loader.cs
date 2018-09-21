using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject Orbs;
    public TextMesh StatusText;

	void Start ()
    {
        Orbs.SetActive(false);
        StatusText.text = "";
	}

    public void SetLoading(bool isLoading, string text = "")
    {
        Orbs.SetActive(isLoading);
        StatusText.text = text;
    }
}
