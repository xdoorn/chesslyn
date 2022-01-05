/**************************************\
 *                                     *
 *  Chesslyn © 2021, Xander van Doorn  *
 *                                     *
\**************************************/

// .NET
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

// Prism
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;

// Chesslyn
using Chesslyn.Application.ViewModels;
using Chesslyn.Application.Dialogs.Models;


namespace Chesslyn.App.Database.ViewModels
{
  public class DatabaseAppViewModel : AppViewModelBase
  {
    #region Public

    public DatabaseAppViewModel(IRegionManager i_regionManager, IDialogService i_dialogService) : base(i_regionManager)
    {
      m_dialogService = i_dialogService;

      Databases.Add("Championship 2021");
      Databases.Add("My Games");

      AddDatabase = new DelegateCommand(OnAddDatabase);
      RemoveDatabase = new DelegateCommand(OnRemoveDatabase, () => ActiveDatabase != null);
    }

    public string ActiveDatabase
    {
      get => GetProperty<string>();
      set
      {
        if (SetProperty(value))
        {
          EvaluateCanExecute(RemoveDatabase);
        }
      }
    }


    public ObservableCollection<string> Databases { get; } = new ObservableCollection<string>();


    public ICommand AddDatabase
    {
      get => GetProperty<ICommand>();
      set => SetProperty(value);
    }


    public ICommand RemoveDatabase
    {
      get => GetProperty<ICommand>();
      set => SetProperty(value);
    }

    #endregion

    #region Private

    private void OnAddDatabase()
    {
      string? fileName = null;
      if (m_dialogService.ShowOpenFileDialog(out fileName, i_filter: "Chess Database Source (*.pgn;*.cly) | *.pgn;*.cly | All Files (*.*) | *.*"))
      {
        if (fileName != null)
        {
          Databases.Add(fileName);
        }
      }
    }


    private void OnRemoveDatabase()
    {
      if (ActiveDatabase != null)
      {
        Databases.Remove(ActiveDatabase);
      }
    }


    private readonly IDialogService m_dialogService;

    #endregion
  }
}
