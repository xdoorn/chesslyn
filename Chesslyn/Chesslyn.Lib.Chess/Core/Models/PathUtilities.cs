/**************************************\
 *                                     *
 *  Chesslyn © 2022, Xander van Doorn  *
 *                                     *
\**************************************/

using System;
using System.IO;


namespace Chesslyn.Lib.Chess.Core.Models
{
  public static class PathUtilities
  {
    public static string GetApplicationDataPath(bool i_createIfNotExist = false)
    {
      string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Chesslyn");
      
      if (i_createIfNotExist && !Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }

      return path;
    }
  }
}
