/**************************************\
 *                                     *
 *  Chesslyn © 2021, Xander van Doorn  *
 *                                     *
\**************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chesslyn.Application.Dialogs.Interfaces
{
  public interface IDialogHosting
  {
    bool IsHosting { get; } 
  }
}
