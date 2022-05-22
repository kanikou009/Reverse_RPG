using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivater : MonoBehaviour
{
    AudioSource audioSource1;
  

    //public Canvas CanvasS;
    [SerializeField, Header("会話文章"), Multiline(3)]
    private string[] lines;

    private bool canActivater;
    // Start is called before the first frame update
    void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canActivater && !testDialog.instance.dialogBox.activeInHierarchy)
        {
            testDialog.instance.ShowDialog(lines);
            //CanvasS.enabled = false;
           

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canActivater = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            
        {
            canActivater = false;


            testDialog.instance.ShowDialogChange(canActivater);
        }
    }
}
