using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour {
    [SerializeField]
    private float seconds = 10f;
    [SerializeField]
    private float noteSpeed = 10000f;

    private Rigidbody selfBody;

    private void OnEnable()
    {
        StartCoroutine(DisableAfterTime());
        selfBody = GetComponent<Rigidbody>();

        MapController.OnUpdateNoteState += HandleOnUpdateState;
    }

    private void OnDisable()
    {
        
    }

    IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(seconds);

        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update()
    {
		if (gameObject.activeInHierarchy == true)
        {
            //transform.Translate(new Vector3(0, 0, -(noteSpeed) * Time.deltaTime));
            selfBody.velocity = transform.forward * (float)(-noteSpeed * Time.deltaTime);
        }
	}

    void HandleOnUpdateState(bool state)
    {
        if (state)
        {
            SetAlpha(gameObject.GetComponent<Renderer>().material, 0.2F);
            Invoke("ResetAlphaChange", 10f);
        }
    }

    private void ResetAlphaChange()
    {
        SetAlpha(gameObject.GetComponent<Renderer>().material, 1F);
    }

    public static void SetAlpha(Material material, float value)
    {
        Color color = material.color;
        color.a = value;
        material.color = color;
    }
}
