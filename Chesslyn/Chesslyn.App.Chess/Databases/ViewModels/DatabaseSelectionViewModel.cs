/**************************************\
 *                                     *
 *  Chesslyn © 2022, Xander van Doorn  *
 *                                     *
\**************************************/

// .NET
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

// Prism
using Prism.Commands;
using Prism.Services.Dialogs;

// Chesslyn
using Chesslyn.Application.ViewModels;
using Chesslyn.Application.Dialogs.Models;


namespace Chesslyn.App.Database.Databases.ViewModels
{
  public class DatabaseSelectionViewModel : ViewModelBase
  {
    #region Public

    public DatabaseSelectionViewModel(IDialogService i_dialogService)
    {
      m_dialogService = i_dialogService;

      AddDatabase = new DelegateCommand(OnAddDatabase);
      RemoveDatabase = new DelegateCommand(OnRemoveDatabase, () => SelectedDatabase != null);
    }


    public DatabaseItemViewModel SelectedDatabase
    {
      get => GetProperty<DatabaseItemViewModel>();
      set
      {
        if (SetProperty(value))
        {
          EvaluateCanExecute(RemoveDatabase);
        }
      }
    }


    public ObservableCollection<DatabaseItemViewModel> Databases { get; } = new ObservableCollection<DatabaseItemViewModel>();


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
      IEnumerable<FileInfo> selectedFiles = new List<FileInfo>();
      if (m_dialogService.ShowOpenFileDialog(out selectedFiles, i_filter: "Chess Database Source (*.pgn;*.cly) | *.pgn;*.cly | All Files (*.*) | *.*"))
      {
        foreach (FileInfo fileInfo in selectedFiles)
        {
          if (!Databases.Any(d => d.FileInfo.FullName.Equals(fileInfo.FullName)))
          {
            Databases.Add(new DatabaseItemViewModel(fileInfo));
          }
        }
      }
    }


    private void OnRemoveDatabase()
    {
      if (SelectedDatabase != null)
      {
        int activeDatabaseIndex = Databases.IndexOf(SelectedDatabase);
        Databases.Remove(SelectedDatabase);

        if (activeDatabaseIndex > 0)
        {
          SelectedDatabase = Databases.ElementAt(--activeDatabaseIndex);
        }
        else if (activeDatabaseIndex == 0 && Databases.Any())
        {
          SelectedDatabase = Databases.First();
        }
      }
    }


    private readonly IDialogService m_dialogService;

    #endregion
  }
}
