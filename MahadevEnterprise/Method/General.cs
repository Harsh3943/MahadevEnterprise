using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace MahadevEnterprise.Method
{
    public class General
    {
        private string mstr_ConnectionString;
        private SqlConnection mobj_SqlConnection;
        private SqlCommand mobj_SqlCommand;
        private int mint_CommandTimeout = 2000;

        //public enum ExpectedType
        //{

        //    StringType = 0,
        //    NumberType = 1,
        //    DateType = 2,
        //    BooleanType = 3,
        //    ImageType = 4
        //}


        public General()
        {
            try
            {
                mstr_ConnectionString = ConfigurationManager.ConnectionStrings["MahadevEnterpriseConnectionString"].ToString();

                mobj_SqlConnection = new SqlConnection(mstr_ConnectionString);
                mobj_SqlCommand = new SqlCommand();
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.Connection = mobj_SqlConnection;
                //ParseConnectionString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error initializing data class." + Environment.NewLine + ex.Message);
            }
        }




        public void CloseConnection()
        {
            if (mobj_SqlConnection.State != ConnectionState.Closed) mobj_SqlConnection.Close();
        }




        public string GetExecuteScalarByCommand(string Command)
        {
            object identity = 0;
            try
            {

                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.CommandType = CommandType.Text;


                mobj_SqlConnection.Open();

                mobj_SqlCommand.Connection = mobj_SqlConnection;
                identity = mobj_SqlCommand.ExecuteScalar();
                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
            return identity.ToString();
        }

        public int GetExecuteNonQueryByCommand(string Command)
        {
            int Result = 0;
            try
            {

                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.CommandType = CommandType.Text;

                mobj_SqlConnection.Open();

                mobj_SqlCommand.Connection = mobj_SqlConnection;
                Result = mobj_SqlCommand.ExecuteNonQuery();

                CloseConnection();
            }
            catch (Exception ex)
            {
                Result = 0;
                CloseConnection();
                throw ex;
            }

            return Result;

        }

        public DataTable GetDatasetByCommand(string Command)
        {
            try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.CommandType = CommandType.Text;

                mobj_SqlConnection.Open();

                SqlDataAdapter adpt = new SqlDataAdapter(mobj_SqlCommand);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0];
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

        }

        public SqlDataReader GetReaderBySQL(string strSQL)
        {
            mobj_SqlConnection.Open();
            try
            {
                SqlCommand myCommand = new SqlCommand(strSQL, mobj_SqlConnection);
                return myCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }

        public SqlDataReader GetReaderByCmd(string Command)
        {
            SqlDataReader objSqlDataReader = null;
            try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandType = CommandType.Text;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;

                mobj_SqlConnection.Open();
                mobj_SqlCommand.Connection = mobj_SqlConnection;

                objSqlDataReader = mobj_SqlCommand.ExecuteReader();
                return objSqlDataReader;
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }




        public void AddParameterWithValueToSQLCommand(string ParameterName, object Value)
        {
            try
            {
                mobj_SqlCommand.Parameters.AddWithValue(ParameterName, Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddParameterToSQLCommand(string ParameterName, SqlDbType ParameterType)
        {
            try
            {
                mobj_SqlCommand.Parameters.Add(new SqlParameter(ParameterName, ParameterType));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddParameterToSQLCommand(string ParameterName, SqlDbType ParameterType, int ParameterSize)
        {
            try
            {
                mobj_SqlCommand.Parameters.Add(new SqlParameter(ParameterName, ParameterType, ParameterSize));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetSQLCommandParameterValue(string ParameterName, object Value)
        {
            try
            {
                mobj_SqlCommand.Parameters[ParameterName].Value = Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void AddParameterToSQLCommand(string v, string username)
        {
            throw new NotImplementedException();
        }
    }
}