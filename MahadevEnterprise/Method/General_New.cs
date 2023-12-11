using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;

namespace MahadevEnterprise.Method
{
    public class General_New
    {
        #region "Common functions"

        string CS = ConfigurationManager.ConnectionStrings["MahadevEnterpriseConnectionString"].ToString();



        public int GetDataInsertORUpdate(string storedProcedure, NameValueCollection nv)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, con);

                for (int i = 0; i < nv.Count; i++)
                {
                    SqlParameter Param;
                    if ((nv.Get(nv.AllKeys[i])) == null)
                        Param = new SqlParameter(nv.AllKeys[i], DBNull.Value);
                    else
                        Param = new SqlParameter(nv.AllKeys[i], nv.Get(nv.AllKeys[i]));
                    cmd.Parameters.Add(Param);
                    //ErrorMessage(nv.AllKeys[i] + ":" + nv.Get(nv.AllKeys[i]));
                }

                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ErrorMessage("Sql Error is=" + ex.Message.ToString());
                    cmd.Connection.Close();
                }
                finally
                {
                    con.Close();
                }
            }

            return result;
        }

        public void ErrorMessage(string msg)
        {
            string ACPPath = HostingEnvironment.MapPath("~/log.txt");
            StreamWriter swExtLogFile = new StreamWriter(ACPPath, true);
            swExtLogFile.Write(Environment.NewLine);
            swExtLogFile.Write("*****Error message=****" + msg + " at " + DateTime.Now.ToString());
            swExtLogFile.Flush();
            swExtLogFile.Close();
        }

        // insert Update Delete
        public int GetDataExecuteScaler(string storedProcedure, NameValueCollection nv)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, con);

                for (int i = 0; i < nv.Count; i++)
                {
                    SqlParameter Param;
                    if ((nv.Get(nv.AllKeys[i])) == null)
                        Param = new SqlParameter(nv.AllKeys[i], DBNull.Value);
                    else
                        Param = new SqlParameter(nv.AllKeys[i], nv.Get(nv.AllKeys[i]));
                    cmd.Parameters.Add(Param);

                }

                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();

                    var result1 = cmd.ExecuteScalar();
                    result = result1 == DBNull.Value ? 0 : Convert.ToInt32(result1);


                }
                catch (Exception ex)
                {
                    cmd.Connection.Close();
                }
                finally
                {
                    con.Close();
                }
            }

            return result;
        }

        public long GetDataExecuteScalerRetObj(string storedProcedure, NameValueCollection nv)
        {
            long result = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, con);

                for (int i = 0; i < nv.Count; i++)
                {
                    SqlParameter Param;
                    if ((nv.Get(nv.AllKeys[i])) == null)
                        Param = new SqlParameter(nv.AllKeys[i], DBNull.Value);
                    else
                        Param = new SqlParameter(nv.AllKeys[i], nv.Get(nv.AllKeys[i]));
                    cmd.Parameters.Add(Param);

                }
                cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = (long)cmd.Parameters["@ID"].Value;

                }
                catch (Exception ex)
                {
                    cmd.Connection.Close();
                }
                finally
                {
                    con.Close();
                }
            }

            return result;
        }

        public DataSet GetDataSet(string storedProcedure, NameValueCollection nv)
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, con);

                for (int i = 0; i < nv.Count; i++)
                {
                    SqlParameter Param;
                    if ((nv.Get(nv.AllKeys[i])) == null)
                        Param = new SqlParameter(nv.AllKeys[i], DBNull.Value);
                    else
                        Param = new SqlParameter(nv.AllKeys[i], nv.Get(nv.AllKeys[i]));
                    cmd.Parameters.Add(Param);

                }

                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    con.Open();
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    da.Dispose();
                    cmd.Connection.Close();
                }
                finally
                {
                    con.Close();
                }
            }

            return ds;
        }

        public DataTable GetDataTable(string storedProcedure, NameValueCollection nv)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, con);

                for (int i = 0; i < nv.Count; i++)
                {
                    SqlParameter Param;
                    if ((nv.Get(nv.AllKeys[i])) == null)
                        Param = new SqlParameter(nv.AllKeys[i], DBNull.Value);
                    else
                        Param = new SqlParameter(nv.AllKeys[i], nv.Get(nv.AllKeys[i]));
                    cmd.Parameters.Add(Param);

                }

                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    con.Open();
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    ErrorMessage(ex.StackTrace + ex.Message.ToString());
                    // ex.Message.ToString();
                    da.Dispose();
                    cmd.Connection.Close();
                }
                finally
                {
                    con.Close();
                }
            }

            return dt;
        }

        #endregion

        #region "*** Encrypt & Decrypt ***"
        public string EncryptFinal(string toEncrypt, bool useHashing)
        {
            string sEncrypt = Encrypt(toEncrypt, useHashing);
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(sEncrypt);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file
            string key = (string)settingsReader.GetValue("HealthcareSecurityKey", typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file
            string key = (string)settingsReader.GetValue("HealthcareSecurityKey", typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);


        }
        public string DecryptFinal(string cipherString, bool useHashing)
        {
            string sDecrypt = Decrypt(cipherString, useHashing);
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(sDecrypt);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("HealthcareSecurityKey", typeof(String));

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("HealthcareSecurityKey", typeof(String));

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion "*** Encrypt & Decrypt ***"

        #region "Push Notification"


        //public string SendNotification(string NotificationFormat)
        //{
        //    FCMResponse response;
        //    AppSettingsReader settingsReader = new AppSettingsReader();
        //    string SERVER_API_KEY = "AAAA2_eW4i8:APA91bGz_ofD4rKIs7l_cDmR3NJhVJ_1o9TKrUgpM2vn3UuVkiqeyWYRrWn7GjhvR1IKz8m3BaU2kLmlg7RWcfIVHwvIejsWteBOWRh2FF7pv0w8bpU3XVvEFofN8CkcGO0U9LdmNCeL";//(string)settingsReader.GetValue("ApplicationId", typeof(String));
        //    var SENDER_ID = "944751698479";// (string)settingsReader.GetValue("SenderId", typeof(String));

        //    WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        //    tRequest.Method = "post";
        //    tRequest.ContentType = "application/json";

        //    Byte[] byteArray = Encoding.UTF8.GetBytes(NotificationFormat);
        //    tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));
        //    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
        //    tRequest.ContentLength = byteArray.Length;
        //    tRequest.ContentType = "application/json";
        //    using (Stream dataStream = tRequest.GetRequestStream())
        //    {
        //        dataStream.Write(byteArray, 0, byteArray.Length);

        //        using (WebResponse tResponse = tRequest.GetResponse())
        //        {
        //            using (Stream dataStreamResponse = tResponse.GetResponseStream())
        //            {
        //                using (StreamReader tReader = new StreamReader(dataStreamResponse))
        //                {
        //                    String responseFromFirebaseServer = tReader.ReadToEnd();
        //                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<FCMResponse>(responseFromFirebaseServer);
        //                }
        //            }

        //        }
        //    }

        //    return response.ToString();
        //}

        //public string getExactPayload(string UserID, string Tokens, string Message, string Title, string typemsg)
        //{
        //    string postData = "";
        //    postData = "{\"collapse_key\":\"score_update\",\"time_to_live\":108,\"delay_while_idle\":true,\"priority\":\"high\",\"data\": { \"userid\": \"" + UserID + "\",\"Message\": \"" + Message + "\",\"Title\": \"" + Title + "\",\"Type\": \"" + typemsg + "\"}  ,\"registration_ids\":[\"" + Tokens + "\"] }";
        //    return postData;
        //}

        //public string SendMessage(string UserID, string Tokens, string Message, string Title, string TypeMsg)
        //{
        //    var objNotification = new
        //    {
        //        to = Tokens,
        //        data = new
        //        {
        //            postData = getExactPayload(UserID, Tokens, Message, Title, TypeMsg)
        //        }

        //    };
        //    return SendNotification(Newtonsoft.Json.JsonConvert.SerializeObject(objNotification));
        //}

        public class FCMResponse
        {
            public long multicast_id { get; set; }
            public int success { get; set; }
            public int failure { get; set; }
            public int canonical_ids { get; set; }
            public List<FCMResult> results { get; set; }
        }
        public class FCMResult
        {
            public string message_id { get; set; }
        }
        #endregion


        public void ShowMessageAndRedirect(Page page, string message, string url)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "redirect", "alert('" + message + "'); window.location='" + url + "';", true);
        }


        public void ShowMessage(Page page, string message)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + message + "');", true);
        }

    }
}