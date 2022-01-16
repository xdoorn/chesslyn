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
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Chesslyn.App.Database.Games.ViewModels
{
  public class GameHeaderViewModel : ViewModelBase
  {
    #region Public

    public GameHeaderViewModel(IEventAggregator i_eventAggregator)
    {
      //i_eventAggregator.GetEvent<DatabaseSelectionChangedEvent>().Subscribe(OnDatabaseSelectionChanged);
      Properties.Add(new KeyValuePair<string, string>("White Player", "Carlsen, Magnus"));
      Properties.Add(new KeyValuePair<string, string>("White Elo", "2872"));
      Properties.Add(new KeyValuePair<string, string>("Black Player", "Giri, Anish"));
      Properties.Add(new KeyValuePair<string, string>("Black Elo", "2795"));
      Properties.Add(new KeyValuePair<string, string>("Result", "1/2-1/2"));
      Properties.Add(new KeyValuePair<string, string>("Date", "2022-20-01"));
      Properties.Add(new KeyValuePair<string, string>("Tournament", "Tata Steel Chess 2022"));
      Properties.Add(new KeyValuePair<string, string>("Site", "Wijk aan Zee, The Netherlands"));
      Properties.Add(new KeyValuePair<string, string>("Tempo", "Classical"));
      Properties.Add(new KeyValuePair<string, string>("ECO", "A65"));
    }


    public ObservableCollection<KeyValuePair<string, string>> Properties { get; } = new ObservableCollection<KeyValuePair<string, string>>();

    #endregion

    #region Private

    #endregion
  }
}
