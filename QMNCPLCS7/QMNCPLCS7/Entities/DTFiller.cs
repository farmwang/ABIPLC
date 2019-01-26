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
  public  class DTFiller
    {
        public string cmd { get; set; }
        public string bgntime { get; set; }
        public string endtime { get; set; }
        public UInt64 refid { get; set; }
       
        public string Shift { get; set; }
        public DateTime? PDate { get; set; }
        public string FormID { get; set; }
        public string TagID { get; set; }
        public string LineID { get; set; }
        public string DeviceID { get; set; }
        public string IsDown { get; set; }
        public string Status { get; set; }
        public string Code { get; set; }
        public string Msg { get; set; }

        public string RiseEqp { get; set; }
        public string Risecode { get; set; }
        public string Risemsg { get; set; }
        public string RiseTagID { get; set; }
        public string RiseStatus { get; set; }



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
        public string IsDiff { get; set; }
        public string IsPro { get; set; }
        public string IsShift { get; set; }
        public string IsFinish { get; set; }
        public string Create_by { get; set; }
         
        public string Update_by { get; set; }
        public DateTime? Update_time { get; set; }
        public DateTime? create_time { get; set; }





       // string column = "refid,Shift,PDate,FormID,TagID,LineID,DeviceID,IsDown,Status,Code,Msg,RiseEqp,Risecode,Risemsg,RiseTagID,RiseStatus,Model,Start_time,End_time,Duration,Category,Lev1,Lev2,Brand,CBrand,Ctype,stand_time,Reason,Memo,IsDiff,IsPro,IsShift,IsFinish,Create_by,Create_time,Update_by,Update_time";



        //@refid,@Shift,@PDate,@FormID,@TagID,@LineID,@DeviceID,@IsDown,@Status,@Code,@Msg,@RiseEqp,@Risecode,@Risemsg,@Model,@Start_time,@End_time,@Duration,@Category,@Lev1,@Lev2,@Brand,@CBrand,@Ctype,@stand_time,@Reason,@Memo,@IsDiff,@IsPro,@IsShift,@IsFinish,@Create_by,@Create_time,@Update_by,@Update_time


        public static string CreateNew(DTFiller data)
        {
            string sql = " insert into DTFiller( Shift,PDate,FormID,TagID,LineID,DeviceID,IsDown,Status,Code,Msg,RiseEqp,Risecode,Risemsg,RiseTagID,RiseStatus,Model,Start_time,End_time,Duration,Category,Lev1,Lev2,Brand,CBrand,Ctype,stand_time,Reason,Memo,IsDiff,IsPro,IsShift,IsFinish,Create_by,Create_time)values(@Shift,@PDate,@FormID,@TagID,@LineID,@DeviceID,@IsDown,@Status,@Code,@Msg,@RiseEqp,@Risecode,@Risemsg,@RiseTagID,@RiseStatus,@Model,@Start_time,@End_time,@Duration,@Category,@Lev1,@Lev2,@Brand,@CBrand,@Ctype,@stand_time,@Reason,@Memo,@IsDiff,@IsPro,@IsShift,@IsFinish,@Create_by,@Create_time)";
            SqlParameter[] paras = new SqlParameter[]
            {
   
  new SqlParameter("@Shift", data.Shift),
  new SqlParameter("@PDate", data.PDate),
  new SqlParameter("@FormID", data.FormID),
  new SqlParameter("@TagID", data.TagID),
  new SqlParameter("@LineID", data.LineID),
  new SqlParameter("@DeviceID", data.DeviceID),
  new SqlParameter("@IsDown", data.IsDown),
  new SqlParameter("@Status", data.Status),
  new SqlParameter("@Code", data.Code),
  new SqlParameter("@Msg", data.Msg),
  new SqlParameter("@RiseEqp", data.RiseEqp),
  new SqlParameter("@Risecode", data.Risecode),
  new SqlParameter("@Risemsg", data.Risemsg),
  new SqlParameter("@RiseTagID", data.RiseTagID),
  new SqlParameter("@RiseStatus", data.RiseStatus),
 
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
  new SqlParameter("@IsDiff", data.IsDiff),
  new SqlParameter("@IsPro", data.IsPro),
  new SqlParameter("@IsShift", data.IsShift),
  new SqlParameter("@IsFinish", data.IsFinish),
  new SqlParameter("@Create_by", data.Create_by),
  new SqlParameter("@Create_time", DateTime.Now)
  
             };
            foreach (SqlParameter parm in paras)
            {
                if (parm.Value == null)
                    parm.Value = DBNull.Value;
            }
            return MSSql.ExecInsertParaTransStr(sql, paras);
        }



        public static string UpdateDataByRefID(DTFiller data)
        {
            const string sql = "update DTFiller set  ";
            StringBuilder sb = new StringBuilder();
            sb.Append(sql);
             
            if (!string.IsNullOrEmpty(data.Shift))
            {
                sb.AppendFormat("   Shift='{0}' ", data.Shift);
            }
             
            if (!string.IsNullOrEmpty(data.FormID))
            {
                sb.AppendFormat(" , FormID='{0}' ", data.FormID);
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
            if (!string.IsNullOrEmpty(data.Code))
            {
                sb.AppendFormat(" , Code='{0}' ", data.Code);
            }
            if (!string.IsNullOrEmpty(data.Msg))
            {
                sb.AppendFormat(" , Msg='{0}' ", data.Msg);
            }
            if (!string.IsNullOrEmpty(data.RiseEqp))
            {
                sb.AppendFormat(" , RiseEqp='{0}' ", data.RiseEqp);
            }
            if (!string.IsNullOrEmpty(data.Risecode))
            {
                sb.AppendFormat(" , Risecode='{0}' ", data.Risecode);
            }
            if (!string.IsNullOrEmpty(data.Risemsg))
            {
                sb.AppendFormat(" , Risemsg='{0}' ", data.Risemsg);
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
            if (!string.IsNullOrEmpty(data.IsDiff))
            {
                sb.AppendFormat(" , IsDiff='{0}' ", data.IsDiff);
            }
            if (!string.IsNullOrEmpty(data.IsPro))
            {
                sb.AppendFormat(" , IsPro='{0}' ", data.IsPro);
            }
            if (!string.IsNullOrEmpty(data.IsShift))
            {
                sb.AppendFormat(" , IsShift='{0}' ", data.IsShift);
            }
            if (!string.IsNullOrEmpty(data.IsFinish))
            {
                sb.AppendFormat(" , IsFinish='{0}' ", data.IsFinish);
            }
           
            
            if (!string.IsNullOrEmpty(data.Update_by))
            {
                sb.AppendFormat(" , Update_by='{0}' ", data.Update_by);
            }
            
                sb.AppendFormat(" , Update_time='{0}' ", DateTime.Now);
             
            sb.AppendFormat("  where refid={0} ", data.refid);
            return MSSql.ExcuteNOQueryStrEx(sb.ToString());
        }




        public static string DelByRefID(UInt64 refid)
        {
            string sql = string.Format("delete from DTFiller where refid={0} ", refid);
            return MSSql.ExcuteNOQueryStrEx(sql);
        }





        public static DataTable QueryDataByRefID(UInt64 refid)
        {
            string sql = string.Format(" select  refid,Shift,PDate,FormID,TagID,LineID,DeviceID,IsDown,Status,Code,Msg,RiseEqp,Risecode,Risemsg,Model,Start_time,End_time,Duration,Category,Lev1,Lev2,Brand,CBrand,Ctype,stand_time,Reason,Memo,IsDiff,IsPro,IsShift,IsFinish,Create_by,Create_time,Update_by,Update_time from DTFiller where refid={0} ", refid);
            return MSSql.ExecuteQueryDataTable(sql);
        }





        public static DTFiller GetObject(UInt64 refid)
        {
            DTFiller data = new DTFiller();
            DataTable dt = DTFiller.QueryDataByRefID(refid);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
               data.refid =Convert.ToUInt64( dt.Rows[0]["refid"]); 
                
                data.Shift = dt.Rows[0]["Shift"].ToString();
                data.PDate =Convert.ToDateTime( dt.Rows[0]["PDate"].ToString());
                data.FormID = dt.Rows[0]["FormID"].ToString();
                data.TagID = dt.Rows[0]["TagID"].ToString();
                data.LineID = dt.Rows[0]["LineID"].ToString();
                data.DeviceID = dt.Rows[0]["DeviceID"].ToString();
                data.IsDown = dt.Rows[0]["IsDown"].ToString();
                data.Status = dt.Rows[0]["Status"].ToString();
                data.Code = dt.Rows[0]["Code"].ToString();
                data.Msg = dt.Rows[0]["Msg"].ToString();
                data.RiseEqp = dt.Rows[0]["RiseEqp"].ToString();
                data.Risecode = dt.Rows[0]["Risecode"].ToString();
                data.Risemsg = dt.Rows[0]["Risemsg"].ToString();
                data.Model = dt.Rows[0]["Model"].ToString();
                data.Start_time =Convert.ToDateTime( dt.Rows[0]["Start_time"].ToString());
                data.End_time = Convert.ToDateTime(dt.Rows[0]["End_time"].ToString());
                data.Duration =Convert.ToDouble( dt.Rows[0]["Duration"].ToString());
                data.Category = dt.Rows[0]["Category"].ToString();
                data.Lev1 = dt.Rows[0]["Lev1"].ToString();
                data.Lev2 = dt.Rows[0]["Lev2"].ToString();
                data.Brand = dt.Rows[0]["Brand"].ToString();
                data.CBrand = dt.Rows[0]["CBrand"].ToString();
                data.Ctype = dt.Rows[0]["Ctype"].ToString();
                data.stand_time = dt.Rows[0]["stand_time"].ToString();
                data.Reason = dt.Rows[0]["Reason"].ToString();
                data.Memo = dt.Rows[0]["Memo"].ToString();
                data.IsDiff = dt.Rows[0]["IsDiff"].ToString();
                data.IsPro = dt.Rows[0]["IsPro"].ToString();
                data.IsShift = dt.Rows[0]["IsShift"].ToString();
                data.IsFinish = dt.Rows[0]["IsFinish"].ToString();
                data.Create_by = dt.Rows[0]["Create_by"].ToString();
                
                data.Update_by = dt.Rows[0]["Update_by"].ToString();
                 
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
            string sql = " select refid,refid,Shift,PDate,FormID,TagID,LineID,DeviceID,IsDown,Status,Code,Msg,RiseEqp,Risecode,Risemsg,Model,Start_time,End_time,Duration,Category,Lev1,Lev2,Brand,CBrand,Ctype,stand_time,Reason,Memo,IsDiff,IsPro,IsShift,IsFinish,Create_by,Create_time,Update_by,Update_time from DTFiller    ";
            return MSSql.ExecuteQueryDataTable(sql);
        }





        public static DataTable QueryByCondition(DTFiller data)
        {
            StringBuilder sb = new StringBuilder();
            string sqlstr = "select refid,Shift,PDate,FormID,TagID,LineID,DeviceID,IsDown,Status,Code,Msg,RiseEqp,Risecode,Risemsg,Model,Start_time,End_time,Duration,Category,Lev1,Lev2,Brand,CBrand,Ctype,stand_time,Reason,Memo,IsDiff,IsPro,IsShift,IsFinish,Create_by,Create_time,Update_by,Update_time  from DTFiller where 1=1 ";
            sb.Append(sqlstr);
           
            if (!string.IsNullOrEmpty(data.Shift))
            {
                sb.AppendFormat(" and Shift like '%{0}%' ", data.Shift);
            }
            
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
            if (!string.IsNullOrEmpty(data.Code))
            {
                sb.AppendFormat(" and Code like '%{0}%' ", data.Code);
            }
            if (!string.IsNullOrEmpty(data.Msg))
            {
                sb.AppendFormat(" and Msg like '%{0}%' ", data.Msg);
            }
            if (!string.IsNullOrEmpty(data.RiseEqp))
            {
                sb.AppendFormat(" and RiseEqp like '%{0}%' ", data.RiseEqp);
            }
            if (!string.IsNullOrEmpty(data.Risecode))
            {
                sb.AppendFormat(" and Risecode like '%{0}%' ", data.Risecode);
            }
            if (!string.IsNullOrEmpty(data.Risemsg))
            {
                sb.AppendFormat(" and Risemsg like '%{0}%' ", data.Risemsg);
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
            if (!string.IsNullOrEmpty(data.IsDiff))
            {
                sb.AppendFormat(" and IsDiff like '%{0}%' ", data.IsDiff);
            }
            if (!string.IsNullOrEmpty(data.IsPro))
            {
                sb.AppendFormat(" and IsPro like '%{0}%' ", data.IsPro);
            }
            if (!string.IsNullOrEmpty(data.IsShift))
            {
                sb.AppendFormat(" and IsShift like '%{0}%' ", data.IsShift);
            }
            if (!string.IsNullOrEmpty(data.IsFinish))
            {
                sb.AppendFormat(" and IsFinish like '%{0}%' ", data.IsFinish);
            }
            if (!string.IsNullOrEmpty(data.Create_by))
            {
                sb.AppendFormat(" and Create_by like '%{0}%' ", data.Create_by);
            }
           
            if (!string.IsNullOrEmpty(data.Update_by))
            {
                sb.AppendFormat(" and Update_by like '%{0}%' ", data.Update_by);
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



        public static DataTable DTFillerBlurSearch(string column, string value)
        {
            string sql = string.Format("select refid,Shift,PDate,FormID,TagID,LineID,DeviceID,IsDown,Status,Code,Msg,RiseEqp,Risecode,Risemsg,Model,Start_time,End_time,Duration,Category,Lev1,Lev2,Brand,CBrand,Ctype,stand_time,Reason,Memo,IsDiff,IsPro,IsShift,IsFinish,Create_by,Create_time,Update_by,Update_time from DTFiller where {0} like '%{1}%' ", column, value);
            return MSSql.ExecuteQueryDataTable(sql);
        }



        public static UInt64 GetMaxRefid(string FormID)
        {
            string sql = string.Format(" select max(refid)refid from DTFiller where FormID='{0}'", FormID);
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


        public static void DTPlusDuration(string formid, double duration)
        {
            string sql = string.Format(" update DTFiller set duration=duration+{0} ,end_time='{1}' where FormID='{2}' ", duration, DateTime.Now, formid);
            MSSql.ExcuteNOQueryStrEx(sql);
        }


        public static void DTPlusDurationFinish(string formid, double duration)
        {
            string sql = string.Format(" update DTFiller set duration=duration+{0},IsFinish='Y' ,end_time='{1}' where FormID='{2}' ", duration, DateTime.Now, formid);
            MSSql.ExcuteNOQueryStrEx(sql);
        }



        public static void UpdateRiseEqp(string formid, string tagid,string eqpname)
        {
            string sql = string.Format(" update DTFiller set RiseTagID='{0}' ,RiseEqp='{1}' where FormID='{2}' ", tagid, eqpname, formid);
            MSSql.ExcuteNOQueryStrEx(sql);
        }


    }
}
