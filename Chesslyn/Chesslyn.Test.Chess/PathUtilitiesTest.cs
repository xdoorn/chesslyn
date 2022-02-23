/**************************************\
 *                                     *
 *  Chesslyn © 2022, Xander van Doorn  *
 *                                     *
\**************************************/

using NUnit.Framework;

// Chesslyn
using Chesslyn.Lib.Chess.Core.Models;


namespace Chesslyn.Test.Chess
{
  public class PathUtilitiesTest
  {
    [Test]
    public void GetApplicationDataPath()
    {
      // Act
      string path = PathUtilities.GetApplicationDataPath();

      // Assert
      Assert.That(path, Does.EndWith(@"\AppData\Roaming\Chesslyn"));
    }
  }
}