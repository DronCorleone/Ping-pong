using System;
using UnityEngine;


public class DDebug
{
    private readonly DDebug _parent;
    private readonly string _name;
    private readonly string _fullName;

    public DDebug(string name, DDebug parent = null)
    {
        _name = name;
        _parent = parent;
        _fullName = $"{FullName}: ";
    }
    
    public bool Mute { get; set; }
    
    private bool IsMute => (Mute || _parent != null && _parent.IsMute);
    
    private string FullName => _parent == null ? _name : $"{_parent.FullName}{'.'}{_name}";
    
    
    public void Info(string msg)
    {
        if (!IsMute)
            Debug.Log(_fullName + msg);
    }
    
    public void Warn(string msg)
    {
        if (!IsMute)
            Debug.LogWarning(_fullName + msg);
    }
    
    public void Err(string msg)
    {
        Debug.LogError($"LogError of {_fullName}{msg}");
    }
    
    public void Ex(Exception ex)
    {
        Debug.LogError(_fullName + ex);
    }
}