/**************************************\
 *                                     *
 *  Chesslyn © 2021, Xander van Doorn  *
 *                                     *
\**************************************/

using Chesslyn.Application.ViewModels;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chesslyn.App.Chess.ViewModels
{
  public class ChessAppViewModel : AppViewModelBase
  {
    public ChessAppViewModel(IRegionManager i_regionManager) : base(i_regionManager)
    {
    }
  }
}
