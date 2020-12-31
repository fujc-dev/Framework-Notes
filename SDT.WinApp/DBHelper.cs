using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace SDT.WinApp
{

    /// <summary>
    /// 数据库操作帮助类
    /// </summary>
    public class DBHelper
    {

        //连接字符串,从web.config中获取
        public static string conStr = ConfigurationManager.ConnectionStrings["DBConnectionString1"].ConnectionString;

        /// <summary>
        /// 获取SqlCommand对象
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="pars">参数集</param>
        /// <returns>SqlCommand对象</returns>
        private static SqlCommand GetSqlCommand(string sql, SqlConnection conn, params SqlParameter[] pars)

        {
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.Parameters.AddRange(pars);
            return comm;
        }





        /// <summary>
        /// 设置SqlCommand对象的值
        /// </summary>
        /// <param name="comm">SqlCommand对象</param>
        /// <param name="commandText">需要执行的sql语句或存储过程名称</param>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="type">执行的类型(sql语句类型或存储过程类型)</param>
        private static void SetSqlCommand(SqlCommand comm, string commandText, SqlConnection conn, CommandType type)
        {
            comm.CommandText = commandText;
            comm.Connection = conn;
            comm.CommandType = type;
        }


        /// 查询返回SqlDataReader,读取数据完毕后必须关闭SqlDataReader，会自动释放数据库连接
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pars">参数集</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pars)
        {
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand comm = GetSqlCommand(sql, conn, pars);
            return comm.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 执行查询，返回结果集的第一行第一列数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pars">参数集</param>
        /// <returns>单个数据</returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlCommand comm = GetSqlCommand(sql, conn, pars);
                return comm.ExecuteScalar();
            }
        }



        /// <summary>
        /// 执行增删改操作
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pars">参数集</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlCommand comm = GetSqlCommand(sql, conn, pars);
                return comm.ExecuteNonQuery();
            }
        }



        /// <summary>
        /// 执行查询语句,返回DataTable
        /// </summary>
        /// <param name="sql">sql语句</param>        
        /// <param name="pars">参数集</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteAdapter(string sql, params SqlParameter[] pars)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.SelectCommand.Parameters.AddRange(pars);
                adapter.Fill(dt);
            }
            return dt;
        }



        /// 调用存储过程返回SqlDataReader,读取数据完毕后必须关闭SqlDataReader，会自动释放数据库连接
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="comm">Sqlcommand对象</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string procedureName, SqlCommand comm)
        {
            SqlConnection conn = new SqlConnection(conStr);
            SetSqlCommand(comm, procedureName, conn, CommandType.StoredProcedure);
            return comm.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 调用存储过程，返回结果集的第一行第一列数据
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="comm">Sqlcommand对象</param>
        /// <returns>单个数据</returns>
        public static object ExecuteScalar(string procedureName, SqlCommand comm)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SetSqlCommand(comm, procedureName, conn, CommandType.StoredProcedure);
                return comm.ExecuteScalar();
            }
        }



        /// <summary>
        /// 调用存储过程，执行非查询操作(增删改)
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="comm">Sqlcommand对象</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string procedureName, SqlCommand comm)

        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SetSqlCommand(comm, procedureName, conn, CommandType.StoredProcedure);
                return comm.ExecuteNonQuery();
            }
        }



        /// <summary>
        /// 执行存储过程,返回DataTable
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="comm">Sqlcommand对象</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteAdapter(string procedureName, SqlCommand comm)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SetSqlCommand(comm, procedureName, conn, CommandType.StoredProcedure);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(dt);
            }
            return dt;
        }



        /// <summary>
        /// 使用事务执行多个非查询操作，sql语句不能相同
        /// </summary>
        /// <param name="sqlList">键：sql语句  值：参数集</param>
        /// <returns>是否全都成功执行</returns>
        public static bool ExecuteWithTransaction(Dictionary<string, List<SqlParameter>> sqlList)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.Transaction = tran;
                try
                {
                    foreach (var v in sqlList)
                    {
                        comm.Parameters.Clear();
                        comm.CommandText = v.Key;
                        if (v.Value != null && v.Value.Count > 0)
                        {
                            comm.Parameters.AddRange(v.Value.ToArray());
                        }
                        comm.ExecuteNonQuery();
                    }
                    tran.Commit();
                    return true;
                }
                catch (Exception)
                {
                    tran.Rollback();
                    return false;
                }
            }
        }


        /// <summary>
        /// 使用事务执行多个非查询操作，通用
        /// </summary>
        /// <param name="sqlList">SQL对象</param>
        /// <returns>是否全都成功执行</returns>
        public static bool ExecuteWithTransaction(List<SQL> sqlList)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.Transaction = tran;
                try
                {
                    foreach (var v in sqlList)
                    {
                        comm.Parameters.Clear();
                        comm.CommandText = v.Sql;
                        if (v.ParameterList != null && v.ParameterList.Count > 0)
                        {
                            comm.Parameters.AddRange(v.ParameterList.ToArray());
                        }
                        comm.ExecuteNonQuery();
                    }
                    tran.Commit(); return true;
                }
                catch (Exception)
                {
                    tran.Rollback(); return false;
                }
            }
        }
    }

    /// <summary>
    /// SQL类,包含sql语句和参数集
    /// </summary>
    public class SQL
    {
        public string Sql { get; set; }
        public List<SqlParameter> ParameterList { get; set; }
        public SQL(string sql, List<SqlParameter> pars)
        {
            this.Sql = sql; this.ParameterList = pars;
        }
        public SQL(string sql)
        {
            this.Sql = sql;
        }
        public SQL() { }
    }

}