using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDT.WinApp
{
    public class UcBase : UserControl
    {
        public UcBase()
        {

        }
        /// <summary>
        /// 连接字符串 
        /// </summary>
        public static string conStr1 = "Data Source=49.233.163.243;Initial Catalog=Salary;persist security info=True;user id=sa;password=tonn*dane*1;MultipleActiveResultSets=True;Connect Timeout=1000;";
        public static string conStr2 = "Data Source=49.233.163.243;Initial Catalog=Salary;persist security info=True;user id=sa;password=tonn*dane*1;MultipleActiveResultSets=True;Connect Timeout=1000;";
        public static string conStr3 = "Data Source=49.233.163.243;Initial Catalog=Salary;persist security info=True;user id=sa;password=tonn*dane*1;MultipleActiveResultSets=True;Connect Timeout=1000;";

        #region 成员变量

        protected SqlTransaction tran1;
        protected SqlCommand command1;
        protected SqlConnection connection1;

        protected SqlTransaction tran2;
        protected SqlCommand command2;
        protected SqlConnection connection2;
        #endregion



        #region 事务1方法区

        /// <summary>
        /// 开启事务1
        /// </summary>
        protected void StartTran1(String currentIsolationLevel)
        {
            var isolation = Enum.Parse<IsolationLevel>(currentIsolationLevel);
            this.connection1 = new SqlConnection(conStr1);
            this.connection1.Open();
            this.tran1 = this.connection1.BeginTransaction(isolation);
            this.command1 = new SqlCommand();
            this.command1.Connection = this.connection1;
            this.command1.Transaction = this.tran1;

        }
        /// <summary>
        /// 提交事务1
        /// </summary>
        protected void CommitTran1()
        {
            if (tran1 != null)
                this.tran1.Commit();
        }

        protected void Rollback1()
        {
            try
            {
                if (tran1 != null)
                {
                    this.tran1.Rollback();
                }
            }
            catch (Exception)
            {
                
            }
        }
        #endregion



        #region 事务2方法区
        /// <summary>
        /// 开启事务2
        /// </summary>
        protected void StartTran2(String currentIsolationLevel)
        {
            var isolation = Enum.Parse<IsolationLevel>(currentIsolationLevel);
            this.connection2 = new SqlConnection(conStr2);
            this.connection2.Open();
            this.tran2 = this.connection2.BeginTransaction(isolation);
            this.command2 = new SqlCommand();
            this.command2.Connection = this.connection2;
            this.command2.Transaction = this.tran2;

        }

        /// <summary>
        /// 提交事务2
        /// </summary>
        protected void CommitTran2()
        {
            if (tran2 != null)
                this.tran2.Commit();
        }

        protected void Rollback2()
        {
            try
            {
                if (tran2 != null)
                {
                    this.tran2.Rollback();
                }
            }
            catch (Exception)
            {

            }
        }

        #endregion


        #region 公共方法区

        protected void ExecuteNonQuery(SqlCommand command, String sqlStr)
        {
            command.Parameters.Clear();
            command.CommandText = sqlStr;
            command.CommandTimeout = 1000;
            command.ExecuteNonQuery();
        }

        protected DataTable ExecuteAdapter(SqlCommand command)
        {
            String sqlStr = " SELECT money FROM Salary"; // WITH(NOLOCK)
            DataTable dt = new DataTable();
            command.Parameters.Clear();
            command.CommandText = sqlStr;
            command.CommandTimeout = 1000;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            return dt;
        }
        #endregion



    }
}
