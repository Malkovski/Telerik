namespace NorthwindTwin
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;
    using NorthwindDbContext;

    public class Startup
    {
        private static void Main()
        {
            IObjectContextAdapter context = new NorthEntities();

            string cloneNorth = context.ObjectContext.CreateDatabaseScript();

            var db = new NorthEntities();

            string[] splitter = new string[] { "\r\nGO\r\n" };
            string[] commandText = CreateDb.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

            foreach (string commandLine in commandText)
            {
                db.Database.ExecuteSqlCommand(commandLine);
            }

            var dbConForCreatingDB = new SqlConnection("Server=.\\SQL;Database=NorthwindTwin;Integrated Security=true");

            dbConForCreatingDB.Open();

            using (dbConForCreatingDB)
            {
                var cloneDB = new SqlCommand(cloneNorth, dbConForCreatingDB);
                cloneDB.ExecuteNonQuery();
            }
        }

        static string CreateDb = @"USE [master]
GO
CREATE DATABASE [NorthwindTwin]
CONTAINMENT = NONE
ON  PRIMARY
( NAME = N'NorthwindTwinwind', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL\MSSQL\DATA\NorthwindTwinWND.MDF' , SIZE = 4672KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
LOG ON
( NAME = N'NorthwindTwinwind_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL\MSSQL\DATA\NorthwindTwinWND_log.ldf' , SIZE = 3840KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
GO
ALTER DATABASE [NorthwindTwin] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NorthwindTwin].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [NorthwindTwin] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [NorthwindTwin] SET ANSI_NULLS OFF
GO
ALTER DATABASE [NorthwindTwin] SET ANSI_PADDING OFF
GO
ALTER DATABASE [NorthwindTwin] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NorthwindTwin] SET ARITHABORT OFF
GO
ALTER DATABASE [NorthwindTwin] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NorthwindTwin] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NorthwindTwin] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NorthwindTwin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NorthwindTwin] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [NorthwindTwin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NorthwindTwin] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [NorthwindTwin] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [NorthwindTwin] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NorthwindTwin] SET  DISABLE_BROKER
GO
ALTER DATABASE [NorthwindTwin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NorthwindTwin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NorthwindTwin] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [NorthwindTwin] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NorthwindTwin] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [NorthwindTwin] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NorthwindTwin] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [NorthwindTwin] SET RECOVERY SIMPLE
GO
ALTER DATABASE [NorthwindTwin] SET  MULTI_USER
GO
ALTER DATABASE [NorthwindTwin] SET PAGE_VERIFY TORN_PAGE_DETECTION  
GO
ALTER DATABASE [NorthwindTwin] SET DB_CHAINING OFF
GO
ALTER DATABASE [NorthwindTwin] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NorthwindTwin] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [NorthwindTwin] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NorthwindTwin] SET  READ_WRITE 
GO
";
    }
}