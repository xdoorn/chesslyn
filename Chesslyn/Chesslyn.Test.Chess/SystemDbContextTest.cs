/**************************************\
 *                                     *
 *  Chesslyn © 2022, Xander van Doorn  *
 *                                     *
\**************************************/

// Nunit
using NUnit.Framework;

// Chesslyn
using Chesslyn.Lib.Chess.Data.Models;


namespace Chesslyn.Test.Chess
{
  [TestFixture]
  public class SystemDbContextTest
  {
    [Test]
    public void AddSomething()
    {
      using (SystemDbContext db = new SystemDbContext())
      {
        db.Database.EnsureCreated();

        db.ClyBases.Add(new ClyBase() { Name = "Masters", Path = "Masters.cly" });
        db.SaveChanges();
      }
    }
  }
}
