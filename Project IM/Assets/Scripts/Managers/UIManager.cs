using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;


public class UIManager : IManager
{
    public const string PAGE_ROOT_PATH = "Prefabs/UI/Page/";

    [SerializeField]
    private CanvasGroup _pageGroup = null;
    private List<BaseViewModel> _uiPageList = new ();
        
    public CanvasGroup PageGroup => _pageGroup;
    public int PageCount => _uiPageList.Count;
        
    public BaseViewModel GetCurrentPage()
    {
        if (_uiPageList.Count == 0)
        {
            return null;
        }

        return _uiPageList[_uiPageList.Count - 1];
    }
        
    public List<T> GetPages<T>() where T : BaseViewModel
    {
        List<T> pages = new List<T>();
        foreach (var page in _uiPageList)
        {
            if (page is T)
            {
                pages.Add(page as T);
            }
        }
        return pages;
    }
        
    public T OpenPage<T>() where T : BaseViewModel
    {
        T page = FindPage<T>();
        page = GameObject.Instantiate(page);
        _uiPageList.Add(page);
        return page;
    }
    private T FindPage<T>() where T : BaseViewModel
    {
        T page = Resources.Load<T>($"{PAGE_ROOT_PATH}{typeof(T).Name}");
        if (page == null)
        {
            Debug.LogError($"[UIManager] Page not found: {typeof(T).Name}");
            return null;
        }
        return page;
    }

    public void ClosePage()
    {
        BaseViewModel page = _uiPageList[_uiPageList.Count - 1];
        _uiPageList.Remove(page);
        Object.Destroy(page.gameObject);
    }
        
    public void CloseAllPages()
    {
        while(_uiPageList.Count > 0)
        {
            ClosePage();
        }
    }
    
    
    
    public void Init()
    { }
}

    
