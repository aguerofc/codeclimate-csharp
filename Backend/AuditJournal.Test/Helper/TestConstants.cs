using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace BAS.AuditJournal.Test.Helper
{
    /// <summary>
    /// Generic unit test constants
    /// </summary>
    public static class TestConstants
    {

        public static SqlException GetSqlException()
        {
            var sqlException = FormatterServices.GetUninitializedObject(typeof(SqlException)) as SqlException;

            return sqlException;
        }

        public static Exception GetGeneralException()
        {
            return new Exception("Test Exception");
        }

        public static class AccountJournalParamTest
        {
            public static int SeatId = 1;
            public static DateTime FromDate = DateTime.Now;
            public static DateTime ToDate = DateTime.Now;
            
        }

        public static class AccountJournalTest
        {
           
            public static string AccountId = "";
            public static string AccountName = "Cuentas por cobrar Agentes y Afiliados";
            public static string AccountType ="DB";
            public static decimal Amount= 1234;
            public static string DocumentReference = "Pagos de Agentes y Afiliados";
            public static string SeatName = "Asi#09";
            public static string Nit = "01AL15";



        }
    }
}

