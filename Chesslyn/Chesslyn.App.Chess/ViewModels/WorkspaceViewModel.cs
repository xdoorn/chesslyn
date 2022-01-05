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
using Prism.Services.Dialogs;

// Chesslyn
using Chesslyn.Application.ViewModels;
using Chesslyn.Application.Dialogs.Models;


namespace Chesslyn.App.Chess.ViewModels
{
  public class WorkspaceViewModel : ViewModelBase
  {
    public WorkspaceViewModel(IDialogService i_dialogService)
    {
      m_dialogService = i_dialogService;

      NewGame = new DelegateCommand(OnNewGame);
      SaveGame = new DelegateCommand(OnSaveGame, CanSaveGame);
      CloseGame = new DelegateCommand(OnCloseGame, CanCloseGame);
    }


    private void OnNewGame()
    {
      Games.Add(new GameViewModel() { Header = "New Game 1" });

      if (ActiveGame == null)
      {
        ActiveGame = Games.First();
      }
    }


    private bool CanSaveGame()
    {
      return ActiveGame != null;
    }


    private void OnSaveGame()
    {
      if (m_dialogService.ShowYesNoQuestionDialog("Would you like to save this game?"))
      {
        m_dialogService.ShowOkInformationDialog("Game has been saved");
      }
    }


    private void OnCloseGame()
    {
      if (m_dialogService.ShowYesNoQuestionDialog("Are you sure to close the game?"))
      {
        Games.Remove(ActiveGame);
      }
    }


    private bool CanCloseGame()
    {
      return ActiveGame != null;
    }


    public GameViewModel ActiveGame
    {
      get => GetProperty<GameViewModel>();
      set
      {
        if (SetProperty(value))
        {
          EvaluateCanExecute(SaveGame);
          EvaluateCanExecute(CloseGame);
        }
      }
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


    private readonly IDialogService m_dialogService = null;
  }
}
