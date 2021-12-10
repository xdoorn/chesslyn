/**************************************\
 *                                     *
 *  Chesslyn © 2021, Xander van Doorn  *
 *                                     *
\**************************************/

// .NET
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

// Prism
using Prism.Commands;

// Chesslyn
using Chesslyn.Application.Models;


namespace Chesslyn.App.Chess.ViewModels
{
  public class WorkspaceViewModel : ModelBase
  {
    public WorkspaceViewModel()
    {
      NewGame = new DelegateCommand(OnNewGame);
      SaveGame = new DelegateCommand(OnSaveGame);
      CloseGame = new DelegateCommand(OnCloseGame);
    }


    private void OnNewGame()
    {
      Games.Add(new GameViewModel() { Header = "New Game 1" });

      if (ActiveGame == null)
      {
        ActiveGame = Games.First();
      }
    }

    private void OnSaveGame()
    {
      MessageBox.Show("Save Game");
    }

    private void OnCloseGame()
    {
      if (ActiveGame != null)
      {
        MessageBoxResult result = MessageBox.Show("Are you sure to close the game?", "Chesslyn", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
          Games.Remove(ActiveGame);
        }
      }
    }


    public GameViewModel ActiveGame
    {
      get => GetProperty<GameViewModel>();
      set => SetProperty(value);
    }


    public ObservableCollection<GameViewModel> Games { get; set; } = new ObservableCollection<GameViewModel>();


    public ICommand NewGame
    {
      get => GetProperty<ICommand>();
      set => SetProperty(value);
    }


    public ICommand SaveGame
    {
      get => GetProperty<ICommand>();
      set => SetProperty(value);
    }


    public ICommand CloseGame
    {
      get => GetProperty<ICommand>();
      set => SetProperty(value);
    }
  }
}
