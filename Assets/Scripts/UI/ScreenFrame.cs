using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UI;
using UnityEngine;
using Screen = UI.Screen;

public class ScreenFrame : MonoBehaviour
{
    [SerializeField] private ScreenFrameSettings settings;

    private List<Screen> _screens = new List<Screen>();
    public Screen GetScreen(ScreenID screenID) => _screens.FirstOrDefault(screen => screen.ID == screenID);

    public void Request(ScreenRequest request)
    {
        switch (request.action)
        {
            case ScreenAction.Open:
                Open(request);
                break;
            
            case ScreenAction.Close:
                Close(request);
                break;
            
            case ScreenAction.New:
                New(request);
                break;
            
            case ScreenAction.Switch:
                Switch(request);
                break;
            
            case ScreenAction.Recall:
                Recall(request);
                break;
        }
    }

    private void Open(ScreenRequest request)
    {
        var screen = GetScreen(request.id);
        if (screen is null)
        {
            screen = New(request);
            if (screen is null) return;
        }
    
        screen.Open();
    }
    
    private void Close(ScreenRequest request)
    {
        var screen = GetScreen(request.id);
        if(screen is null) return;

        screen.Close();
    }
    
    private Screen New(ScreenRequest request)
    {
        var screen = settings.GetScreen(request.id);
        if (screen is null) return null; 
        
        var newScreen = GameObject.Instantiate(screen,this.transform);
        newScreen.gameObject.SetActive(false);
        
        _screens.Add(newScreen);

        return newScreen;
    }
    
    private void Switch(ScreenRequest request)
    {
        var switchedScreen = GetScreen(request.id);
        if (switchedScreen is null)
        {
            switchedScreen = New(request);
            if (switchedScreen is null) return;
        }

        var hidedScreens=  _screens.FindAll(screen => screen.Type is ScreenType.Window && screen.gameObject.activeInHierarchy);
        hidedScreens.ForEach(screen => screen.Hide());
        
        switchedScreen.Open();
    }
    
    private void Recall(ScreenRequest request)
    {
        var screen = GetScreen(request.id);
        if(screen is null) return;

        _screens.Remove(screen);
        GameObject.Destroy(screen.gameObject);
    }
    
}
