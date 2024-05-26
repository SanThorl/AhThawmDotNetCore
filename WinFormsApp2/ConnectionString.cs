using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace WinFormsApp2
{
    internal static class ConnectionString
    {
        public static SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "TestDb",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
    }
}
