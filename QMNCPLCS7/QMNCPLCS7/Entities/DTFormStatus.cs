using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QMNetCoreFrame.MSSql;
using QMNetCoreFrame.Tools;
using Microsoft.EntityFrameworkCore.SqlServer;
using QMNetCoreFrame.Log;
using System.Data;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using QMNetCorePLCS7.Types;
using QMNetCorePLCS7;

namespace QMNCPLCS7.Entities
{
  public  class DTFormStatus
    {
        public string cmd { get; set; }
        public string bgntime { get; set; }
        public string endtime { get; set; }
        public UInt64 refid { get; set; }
       
        public string FormID { get; set; }
        public string TagID { get; set; }
        public string LineID { get; set; }
        public string DeviceID { get; set; }
        public string IsDown { get; set; }
        public string Status { get; set; }
        public string create_by { get; set; }
       
        public DateTime? create_time { get; set; }








        //string column = "refid,FormID,TagID,LineID,DeviceID,IsDown,Status,create_by,create_time";



        //@refid,@FormID,@TagID,@LineID,@DeviceID,@IsDown,@Status,@create_by,@create_time


        public static string CreateNew(DTFormStatus data)
        {
            string sql = " insert into DTFormStatus(FormID,TagID,LineID,DeviceID,IsDown,Status,create_by,create_time)values(@FormID,@TagID,@LineID,@DeviceID,@IsDown,@Status,@create_by,@create_time)";
            SqlParameter[] paras = new SqlParameter[]
            {
  
  new SqlParameter("@FormID", data.FormID),
  new SqlParameter("@TagID", data.TagID),
  new SqlParameter("@LineID", data.LineID),
  new SqlParameter("@DeviceID", data.DeviceID),
  new SqlParameter("@IsDown", data.IsDown),
  new SqlParameter("@Status", data.Status),
  new SqlParameter("@create_by", data.create_by),
  new SqlParameter("@create_time", DateTime.Now)
             };
            foreach (SqlParameter parm in paras)
            {
                if (parm.Value == null)
                    parm.Value = DBNull.Value;
            }
            return MSSql.ExecInsertParaTransStr(sql, paras);
        }



        public static string UpdateDataByRefID(DTFormStatus data)
        {
            const string sql = "update DTFormStatus set  ";
            StringBuilder sb = new StringBuilder();
            sb.Append(sql);
             
            if (!string.IsNullOrEmpty(data.FormID))
            {
                sb.AppendFormat("   FormID='{0}' ", data.FormID);
            }
            if (!string.IsNullOrEmpty(data.TagID))
            {
                sb.AppendFormat(" , TagID='{0}' ", data.TagID);
            }
            if (!string.IsNullOrEmpty(data.LineID))
            {
                sb.AppendFormat(" , LineID='{0}' ", data.LineID);
            }
            if (!string.IsNullOrEmpty(data.DeviceID))
            {
                sb.AppendFormat(" , DeviceID='{0}' ", data.DeviceID);
            }
            if (!string.IsNullOrEmpty(data.IsDown))
            {
                sb.AppendFormat(" , IsDown='{0}' ", data.IsDown);
            }
            if (!string.IsNullOrEmpty(data.Status))
            {
                sb.AppendFormat(" , Status='{0}' ", data.Status);
            }
            if (!string.IsNullOrEmpty(data.create_by))
            {
                sb.AppendFormat(" , create_by='{0}' ", data.create_by);
            }
           
            sb.AppendFormat("  where refid={0} ", data.refid);
            return MSSql.ExcuteNOQueryStrEx(sb.ToString());
        }




        public static string DelByRefID(UInt64 refid)
        {
            string sql = string.Format("delete from DTFormStatus where refid={0} ", refid);
            return MSSql.ExcuteNOQueryStrEx(sql);
        }





        public static DataTable QueryDataByRefID(UInt64 refid)
        {
            string sql = string.Format(" select  refid,FormID,TagID,LineID,DeviceID,IsDown,Status,create_by,create_time from DTFormStatus where refid={0} ", refid);
            return MSSql.ExecuteQueryDataTable(sql);
        }





        public static DTFormStatus GetObject(UInt64 refid)
        {
            DTFormStatus data = new DTFormStatus();
            DataTable dt = DTFormStatus.QueryDataByRefID(refid);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                data.refid =Convert.ToUInt64( dt.Rows[0]["refid"]); 
                
                data.FormID = dt.Rows[0]["FormID"].ToString();
                data.TagID = dt.Rows[0]["TagID"].ToString();
                data.LineID = dt.Rows[0]["LineID"].ToString();
                data.DeviceID = dt.Rows[0]["DeviceID"].ToString();
                data.IsDown = dt.Rows[0]["IsDown"].ToString();
                data.Status = dt.Rows[0]["Status"].ToString();
                data.create_by = dt.Rows[0]["create_by"].ToString();
 
                DateTime time;
                if (dt.Rows[0]["create_time"] != System.DBNull.Value)
                {
                    if (DateTime.TryParse(dt.Rows[0]["create_time"].ToString(), out time))
                    {
                        data.create_time = time;
                    }
                }
                else
                {
                    data.create_time = null;
                }
                return data;
            }
        }





        public static DataTable QueryAll()
        {
            string sql = " select refid,refid,FormID,TagID,LineID,DeviceID,IsDown,Status,create_by,create_time from DTFormStatus    ";
            return MSSql.ExecuteQueryDataTable(sql);
        }





        public static DataTable QueryByCondition(DTFormStatus data)
        {
            StringBuilder sb = new StringBuilder();
            string sqlstr = "select refid,FormID,TagID,LineID,DeviceID,IsDown,Status,create_by,create_time  from DTFormStatus where 1=1 ";
            sb.Append(sqlstr);
          
            if (!string.IsNullOrEmpty(data.FormID))
            {
                sb.AppendFormat(" and FormID like '%{0}%' ", data.FormID);
            }
            if (!string.IsNullOrEmpty(data.TagID))
            {
                sb.AppendFormat(" and TagID like '%{0}%' ", data.TagID);
            }
            if (!string.IsNullOrEmpty(data.LineID))
            {
                sb.AppendFormat(" and LineID like '%{0}%' ", data.LineID);
            }
            if (!string.IsNullOrEmpty(data.DeviceID))
            {
                sb.AppendFormat(" and DeviceID like '%{0}%' ", data.DeviceID);
            }
            if (!string.IsNullOrEmpty(data.IsDown))
            {
                sb.AppendFormat(" and IsDown like '%{0}%' ", data.IsDown);
            }
            if (!string.IsNullOrEmpty(data.Status))
            {
                sb.AppendFormat(" and Status like '%{0}%' ", data.Status);
            }
            
            if (string.IsNullOrEmpty(data.bgntime) || string.IsNullOrEmpty(data.endtime))
            {
                if (string.IsNullOrEmpty(data.bgntime) && string.IsNullOrEmpty(data.endtime))
                {
                }
                else
                {
                    if (string.IsNullOrEmpty(data.bgntime))
                    {
                        sb.AppendFormat(" and create_time between '2000-01-11 00:00:00' and '{0}'", data.endtime);
                    }
                    else
                    {
                        sb.AppendFormat(" and create_time between '{0}' and  GETDATE()+1  ", data.bgntime);
                    }
                }
            }
            else
            {
                sb.AppendFormat(" and create_time between '{0}' and '{1}'", data.bgntime, data.endtime);
            }
            return MSSql.ExecuteQueryDataTable(sb.ToString());
        }



        public static DataTable DTFormStatusBlurSearch(string column, string value)
        {
            string sql = string.Format("select refid,FormID,TagID,LineID,DeviceID,IsDown,Status,create_by,create_time from DTFormStatus where {0} like '%{1}%' ", column, value);
            return MSSql.ExecuteQueryDataTable(sql);
        }

    }
}
