using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityWeld.Binding;


[Binding]
public class BaseViewModel : MonoBehaviour, INotifyPropertyChanged
{
    private string ttext;
    [Binding]
    public string Text
    {
        get
        { return ttext; }
        set
        {
            if (ttext == value)
            {
                return;
            }
            
            ttext = value;
            OnPropertyChanged("Text");
        }
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        Text = Managers.StatManager.Pd.Health.ToString();
    }
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
