using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IUManagerScript : MonoBehaviour
{
    [Header("UIPages")]
    public GameObject StartGamePopup;
    public GameObject MainUI; 
    public GameObject ColorPick; 
    public InputField ColumnSize;
    public InputField RowSize;


    public bool loadFromScene = true;
    public ColorPicker[] colorPicker;

    private List<ColorPicker> mColorPickerList;
    public void Start()
    {
        if (loadFromScene)
        {
            colorPicker = GameObject.FindObjectsOfType<ColorPicker>();
        }
        mColorPickerList = new List<ColorPicker>();
        mColorPickerList.AddRange(colorPicker);

        mColorPickerList = mColorPickerList.OrderBy(item => item.drawOrder).ToList();
        mColorPickerList.Reverse();
        mColorPickerList.CopyTo(colorPicker);

        foreach (var elem in mColorPickerList)
        {
            elem.useExternalDrawer = true;
        }
    }
    public void AddButtonCommand()
    {
        AddNewColor(ColorPick.GetComponent<ColorPicker>().GetColor());
    }
    private void AddNewColor(Color SelectedColor)
    {
        SharedPropertiesHelper.SharedProperties.GridColors.Add(SelectedColor);
    }
    public void SetSizeButtonCommand()
    {
        int cSize = 8;
        int rSize = 9;
        if (Int32.TryParse(ColumnSize.text, out cSize) && Int32.TryParse(RowSize.text,out rSize))
        {
            SetSize(cSize,rSize);
        }
    }
    private void SetSize(int column,int row)
    {
        SharedPropertiesHelper.SharedProperties.BoardSize = new Tuple<int, int>(column, row);
    }
    private void OnGUI()
    {

        foreach (var elem in mColorPickerList)
        {
            elem._DrawGUI();
        }
    }
    public void StartGamePopupButtonCommand()
    {
        StartGamePopup.SetActive(true);
        MainUI.SetActive(false);
    }
    private void Awake()
    { 
    }
    public void StartGamePopupOKButtonCommand()
    {
        StartGamePopup.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void StartGamePopupBackButtonCommand()
    {
        SharedPropertiesHelper.SharedProperties.GridColors = new List<Color>() { Color.red, Color.blue, Color.green };
        StartGamePopup.SetActive(false);
        MainUI.SetActive(true);
    }
    public void ExitButtonCommand()
    {
        Application.Quit();
    }
}
