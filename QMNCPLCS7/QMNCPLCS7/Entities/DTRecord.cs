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

    public class DTRecord
    {
        public string cmd { get; set; }
        public string bgntime { get; set; }
        public string endtime { get; set; }
        public UInt64 refid { get; set; }

        public DateTime PDate { set; get; }
        public string TagID { get; set; }
        public double Value { set; get; }
        public string LineID { get; set; }
        public string DeviceID { get; set; }
        public string IsDown { get; set; }
        public string Shift { get; set; }
        public string Model { get; set; }
        public DateTime? Start_time { get; set; }
        public DateTime? End_time { get; set; }
        public double Duration { get; set; }
        public string Category { get; set; }
        public string Lev1 { get; set; }
        public string Lev2 { get; set; }
        public string Brand { get; set; }
        public string CBrand { get; set; }
        public string Ctype { get; set; }
        public string stand_time { get; set; }
        public string Reason { get; set; }
        public string Memo { get; set; }
        public string status { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }
        public DateTime? update_time { get; set; }
        public DateTime? create_time { get; set; }





        // string column = "refid,LineID,DeviceID,IsDown,Shift,Model,Start_time,End_time,Duration,Category,Lev1,Lev2,Brand,CBrand,Ctype,stand_time,Reason,Memo,status,create_by,create_time,update_by,update_time";

        //@refid,@LineID,@DeviceID,@IsDown,@Shift,@Model,@Start_time,@End_time,@Duration,@Category,@Lev1,@Lev2,@Brand,@CBrand,@Ctype,@stand_time,@Reason,@Memo,@status,@create_by,@create_time,@update_by,@update_time


        public static string CreateNew(DTRecord data)
        {
            string sql = " insert into DTRecord(TagID,Value,PDate,LineID,DeviceID,IsDown,Shift,Model,Start_time,End_time,Duration,Category,Lev1,Lev2,Brand,CBrand,Ctype,stand_time,Reason,Memo,status,create_by,create_time)values(@TagID,@Value,@PDate,@LineID,@DeviceID,@IsDown,@Shift,@Model,@Start_time,@End_time,@Duration,@Category,@Lev1,@Lev2,@Brand,@CBrand,@Ctype,@stand_time,@Reason,@Memo,@status,@create_by,@create_time)";
            SqlParameter[] paras = new SqlParameter[]
            {
   new SqlParameter("@TagID", data.TagID),

   new SqlParameter("@Value", data.Value),
   new SqlParameter("@PDate", data.PDate),
  new SqlParameter("@LineID", data.LineID),
  new SqlParameter("@DeviceID", data.DeviceID),
  new SqlParameter("@IsDown", data.IsDown),
  new SqlParameter("@Shift", data.Shift),
  new SqlParameter("@Model", data.Model),
  new SqlParameter("@Start_time", data.Start_time),
  new SqlParameter("@End_time", data.End_time),
  new SqlParameter("@Duration", data.Duration),
  new SqlParameter("@Category", data.Category),
  new SqlParameter("@Lev1", data.Lev1),
  new SqlParameter("@Lev2", data.Lev2),
  new SqlParameter("@Brand", data.Brand),
  new SqlParameter("@CBrand", data.CBrand),
  new SqlParameter("@Ctype", data.Ctype),
  new SqlParameter("@stand_time", data.stand_time),
  new SqlParameter("@Reason", data.Reason),
  new SqlParameter("@Memo", data.Memo),
  new SqlParameter("@status", data.status),
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



        public static string UpdateDataByRefID(DTRecord data)
        {
            const string sql = "update DTRecord set  ";
            StringBuilder sb = new StringBuilder();
            sb.Append(sql);


            if (!string.IsNullOrEmpty(data.DeviceID))
            {
                sb.AppendFormat("   DeviceID='{0}' ", data.DeviceID);
            }

            if (!string.IsNullOrEmpty(data.Shift))
            {
                sb.AppendFormat(" , Shift='{0}' ", data.Shift);
            }
            if (!string.IsNullOrEmpty(data.Model))
            {
                sb.AppendFormat(" , Model='{0}' ", data.Model);
            }


            if (!string.IsNullOrEmpty(data.Category))
            {
                sb.AppendFormat(" , Category='{0}' ", data.Category);
            }
            if (!string.IsNullOrEmpty(data.Lev1))
            {
                sb.AppendFormat(" , Lev1='{0}' ", data.Lev1);
            }
            if (!string.IsNullOrEmpty(data.Lev2))
            {
                sb.AppendFormat(" , Lev2='{0}' ", data.Lev2);
            }
            if (!string.IsNullOrEmpty(data.Brand))
            {
                sb.AppendFormat(" , Brand='{0}' ", data.Brand);
            }
            if (!string.IsNullOrEmpty(data.CBrand))
            {
                sb.AppendFormat(" , CBrand='{0}' ", data.CBrand);
            }
            if (!string.IsNullOrEmpty(data.Ctype))
            {
                sb.AppendFormat(" , Ctype='{0}' ", data.Ctype);
            }
            if (!string.IsNullOrEmpty(data.stand_time))
            {
                sb.AppendFormat(" , stand_time='{0}' ", data.stand_time);
            }
            if (!string.IsNullOrEmpty(data.Reason))
            {
                sb.AppendFormat(" , Reason='{0}' ", data.Reason);
            }
            if (!string.IsNullOrEmpty(data.Memo))
            {
                sb.AppendFormat(" , Memo='{0}' ", data.Memo);
            }
            if (!string.IsNullOrEmpty(data.status))
            {
                sb.AppendFormat(" , status='{0}' ", data.status);
            }


            if (!string.IsNullOrEmpty(data.update_by))
            {
                sb.AppendFormat(" , update_by='{0}' ", data.update_by);
            }

            sb.AppendFormat(" , update_time='{0}' ", DateTime.Now);

            sb.AppendFormat("  where refid={0} ", data.refid);
            return MSSql.ExcuteNOQueryStrEx(sb.ToString());
        }




        public static string DelByRefID(UInt64 refid)
        {
            string sql = string.Format("delete from DTRecord where refid={0} ", refid);
            return MSSql.ExcuteNOQueryStrEx(sql);
        }





        public static DataTable QueryDataByRefID(UInt64 refid)
        {
            string sql = string.Format(" select  refid,PDate,LineID,DeviceID,IsDown,Shift,Model,Start_time,End_time,Duration,Category,Lev1,Lev2,Brand,CBrand,Ctype,stand_time,Reason,Memo,status,create_by,create_time,update_by,update_time from DTRecord where refid={0} ", refid);
            return MSSql.ExecuteQueryDataTable(sql);
        }





        public static DTRecord GetObject(UInt64 refid)
        {
            DTRecord data = new DTRecord();
            DataTable dt = DTRecord.QueryDataByRefID(refid);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                data.refid = Convert.ToUInt64(dt.Rows[0]["refid"]);
                data.PDate = Convert.ToDateTime(dt.Rows[0]["PDate"].ToString());
                data.LineID = dt.Rows[0]["LineID"].ToString();
                data.DeviceID = dt.Rows[0]["DeviceID"].ToString();
                data.IsDown = dt.Rows[0]["IsDown"].ToString();
                data.Shift = dt.Rows[0]["Shift"].ToString();
                data.Model = dt.Rows[0]["Model"].ToString();

                if (dt.Rows[0]["Start_time"] != System.DBNull.Value)
                {
                    data.Start_time = Convert.ToDateTime(dt.Rows[0]["Start_time"].ToString());
                }

                if (dt.Rows[0]["End_time"] != System.DBNull.Value)
                {
                    data.End_time = Convert.ToDateTime(dt.Rows[0]["End_time"].ToString());
                }




                data.Duration = Convert.ToInt32(dt.Rows[0]["Duration"].ToString());
                data.Category = dt.Rows[0]["Category"].ToString();
                data.Lev1 = dt.Rows[0]["Lev1"].ToString();
                data.Lev2 = dt.Rows[0]["Lev2"].ToString();
                data.Brand = dt.Rows[0]["Brand"].ToString();
                data.CBrand = dt.Rows[0]["CBrand"].ToString();
                data.Ctype = dt.Rows[0]["Ctype"].ToString();
                data.stand_time = dt.Rows[0]["stand_time"].ToString();
                data.Reason = dt.Rows[0]["Reason"].ToString();
                data.Memo = dt.Rows[0]["Memo"].ToString();
                data.status = dt.Rows[0]["status"].ToString();
                data.create_by = dt.Rows[0]["create_by"].ToString();

                data.update_by = dt.Rows[0]["update_by"].ToString();

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
            string sql = " select  refid,PDate,LineID,DeviceID,IsDown,Shift,Model,Start_time,End_time,Duration,Category,Lev1,Lev2,Brand,CBrand,Ctype,stand_time,Reason,Memo,status,create_by,create_time,update_by,update_time from DTRecord    ";
            return MSSql.ExecuteQueryDataTable(sql);
        }





        public static DataTable QueryByCondition(DTRecord data)
        {
            StringBuilder sb = new StringBuilder();
            string sqlstr = "select refid,PDate,LineID,DeviceID,IsDown,Shift,Model,Start_time,End_time,Duration,Category,Lev1,Lev2,Brand,CBrand,Ctype,stand_time,Reason,Memo,status,create_by,create_time,update_by,update_time  from DTRecord where 1=1 ";
            sb.Append(sqlstr);

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
            if (!string.IsNullOrEmpty(data.Shift))
            {
                sb.AppendFormat(" and Shift like '%{0}%' ", data.Shift);
            }
            if (!string.IsNullOrEmpty(data.Model))
            {
                sb.AppendFormat(" and Model like '%{0}%' ", data.Model);
            }



            if (!string.IsNullOrEmpty(data.Category))
            {
                sb.AppendFormat(" and Category like '%{0}%' ", data.Category);
            }
            if (!string.IsNullOrEmpty(data.Lev1))
            {
                sb.AppendFormat(" and Lev1 like '%{0}%' ", data.Lev1);
            }
            if (!string.IsNullOrEmpty(data.Lev2))
            {
                sb.AppendFormat(" and Lev2 like '%{0}%' ", data.Lev2);
            }
            if (!string.IsNullOrEmpty(data.Brand))
            {
                sb.AppendFormat(" and Brand like '%{0}%' ", data.Brand);
            }
            if (!string.IsNullOrEmpty(data.CBrand))
            {
                sb.AppendFormat(" and CBrand like '%{0}%' ", data.CBrand);
            }
            if (!string.IsNullOrEmpty(data.Ctype))
            {
                sb.AppendFormat(" and Ctype like '%{0}%' ", data.Ctype);
            }
            if (!string.IsNullOrEmpty(data.stand_time))
            {
                sb.AppendFormat(" and stand_time like '%{0}%' ", data.stand_time);
            }
            if (!string.IsNullOrEmpty(data.Reason))
            {
                sb.AppendFormat(" and Reason like '%{0}%' ", data.Reason);
            }
            if (!string.IsNullOrEmpty(data.Memo))
            {
                sb.AppendFormat(" and Memo like '%{0}%' ", data.Memo);
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



        public static DataTable DTRecordBlurSearch(string column, string value)
        {
            string sql = string.Format("select refid,PDate,LineID,DeviceID,IsDown,Shift,Model,Start_time,End_time,Duration,Category,Lev1,Lev2,Brand,CBrand,Ctype,stand_time,Reason,Memo,status,create_by,create_time,update_by,update_time from DTRecord where {0} like '%{1}%' ", column, value);
            return MSSql.ExecuteQueryDataTable(sql);
        }



        public static void DTPlusDuration(UInt64 refid, double duration)
        {
            string sql = string.Format(" update DTRecord set duration=duration+{0} ,end_time='{1}' where refid={2} ", duration, DateTime.Now, refid);
            MSSql.ExcuteNOQueryStrEx(sql);
        }

        public static void DTPlusDurationFinish(UInt64 refid, double duration)
        {
            string sql = string.Format(" update DTRecord set duration=duration+{0},IsFinish='Y' ,end_time='{1}' where refid={2} ", duration, DateTime.Now, refid);
            MSSql.ExcuteNOQueryStrEx(sql);
        }


        public static UInt64 GetMaxRefid(string DeviceID)
        {
            string sql = string.Format(" select max(refid)refid from dtrecord where deviceid='{0}'", DeviceID);
            DataTable dt = MSSql.ExecuteQueryDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToUInt64(dt.Rows[0]["refid"]);
            }
        }




        public static double Get10MinuteDTTime(string tagid)
        {
            string sql = string.Format("select sum(Duration)Duration from DTRecord where tagid='{0}' and   create_time > dateadd(n,-60,getdate()) and status not in('Operating','Lack','Tailback') ", tagid);
            DataTable dt = MSSql.ExecuteQueryDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(dt.Rows[0]["Duration"]);
            }
        }


        public static double GetDownTime(string tagid,double minute)
        {
            DateTime time = DateTime.Now.AddMinutes(minute);
            string sql = string.Format("select Isnull(sum(Duration),0)Duration from DTRecord where tagid='{0}' and   create_time>'{1}' and status not in('Operating','Lack','Tailback') ", tagid,time);
            DataTable dt = MSSql.ExecuteQueryDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(dt.Rows[0]["Duration"]);
            }
        }

        public static SpanStatus GetSpanTimeStatus(string tagid,double minute)
        {
            SpanStatus data = new SpanStatus();
            DateTime time = DateTime.Now.AddMinutes(minute);
            string sql = string.Format(" select Start_time,End_time,Duration,Status,TagID from DTRecord where   tagid='{0}'  and end_time >='{1}' and start_time<='{1}' ",tagid, time);
            DataTable dt = MSSql.ExecuteQueryDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                data.Status = dt.Rows[0]["Status"].ToString().Trim();
                DateTime  endtime = Convert.ToDateTime(dt.Rows[0]["End_time"]);
                TimeSpan span = endtime - time;
                data.Duration = span.TotalMinutes;
                return data;
            }

        }




    }


}
