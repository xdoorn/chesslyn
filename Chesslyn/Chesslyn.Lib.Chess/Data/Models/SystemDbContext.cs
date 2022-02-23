/**************************************\
 *                                     *
 *  Chesslyn © 2022, Xander van Doorn  *
 *                                     *
\**************************************/

// .NET
using Chesslyn.Lib.Chess.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Chesslyn.Lib.Chess.Data.Models
{
  public class SystemDbContext : DbContext
  {
    public DbSet<ClyBase> ClyBases { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder i_optionsBuilder)
    {
      string filename = Path.Combine(PathUtilities.GetApplicationDataPath(true), "System.cly");
      i_optionsBuilder.UseSqlite($"FileName={filename}");
      
      base.OnConfiguring(i_optionsBuilder);
    }
  }
}
