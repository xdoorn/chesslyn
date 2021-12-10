/**************************************\
 *                                     *
 *  Chesslyn © 2021, Xander van Doorn  *
 *                                     *
\**************************************/

// Using .NET
using System;

// Prism
using Prism;
using Prism.Regions;

// Chesslyn
using Chesslyn.Application.Models;


namespace Chesslyn.Application.ViewModels
{
  public abstract class AppViewModelBase : ModelBase, IActiveAware
  {
    #region Public
    public AppViewModelBase(IRegionManager? i_regionManager)
    {
      m_regionManager = i_regionManager;
    }


    public string AppName
    {
      get { return GetType().Name.Replace("ViewModel", ""); }
    }


    public bool IsActive
    {
      get { return GetProperty<bool>(); }
      set
      {
        if (SetProperty(value))
        {
          IsActiveChanged?.Invoke(this, new EventArgs());
        }
      }
    }

    public event EventHandler? IsActiveChanged;

    #endregion

    #region Private

    private readonly IRegionManager? m_regionManager;

    #endregion
  }
}
