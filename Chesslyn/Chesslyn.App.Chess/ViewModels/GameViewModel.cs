/**************************************\
 *                                     *
 *  Chesslyn © 2021, Xander van Doorn  *
 *                                     *
\**************************************/

using Chesslyn.Application.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chesslyn.App.Chess.ViewModels
{
  public class GameViewModel : ModelBase
  {
    public GameViewModel()
    {
    }

    public string Header
    {
      get => GetProperty<string>();
      set => SetProperty(value);
    }
  }
}
