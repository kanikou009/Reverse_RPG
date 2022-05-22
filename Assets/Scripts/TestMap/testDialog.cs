using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testDialog : MonoBehaviour
{
    public Canvas CanvasS;

    public GameObject dialogBox;
    public Text dialogText;

    private string[] dialogLines;

    private int currentLine;
    private bool justStarted;


    

    public static testDialog instance;

    private void Awake()
    {
        if(instance== null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetMouseButtonUp(1))
            {
                if (!justStarted)
                {
                    currentLine++;

                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);
                        CanvasS.enabled = true;
                    }
                    else
                    {
                        dialogText.text = dialogLines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;
                }
            }
        }
    }

  
    public void ShowDialog(string[]lines)
    {
        dialogLines = lines;

        currentLine = 0;

        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);

        justStarted = true;


    }

    public void ShowDialogChange(bool x)
    {
        dialogBox.SetActive(x);
        CanvasS.enabled = !x;
    }
}
