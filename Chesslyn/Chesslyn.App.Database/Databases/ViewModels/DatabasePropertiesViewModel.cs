/**************************************\
 *                                     *
 *  Chesslyn © 2022, Xander van Doorn  *
 *                                     *
\**************************************/

// .NET
using System;
using System.IO;

// Prism
using Prism.Events;

// Chesslyn
using Chesslyn.Application.ViewModels;
using Chesslyn.App.Database.Databases.Events;

namespace Chesslyn.App.Database.Databases.ViewModels
{
  public class DatabasePropertiesViewModel : ViewModelBase
  {
    #region Public

    public DatabasePropertiesViewModel(IEventAggregator i_eventAggregator)
    {
      i_eventAggregator.GetEvent<DatabaseSelectionChangedEvent>().Subscribe(OnDatabaseSelectionChanged);
    }


    public DatabaseItemViewModel DatabaseItem 
    {
      get => GetProperty<DatabaseItemViewModel>();
      set => SetProperty(value);
    }

    #endregion

    #region Private

    private void OnDatabaseSelectionChanged(DatabaseItemViewModel i_selectedDatabase)
    {
      DatabaseItem = i_selectedDatabase;
    }

    #endregion
  }
}
