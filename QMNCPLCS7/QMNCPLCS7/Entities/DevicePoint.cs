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

    public class DevicePoint
    {
        public string cmd { get; set; }
        public string bgntime { get; set; }
        public string endtime { get; set; }
        public UInt64 refid { get; set; }

        public string LineID{ get; set; }
        public string DeviceID { get; set; }
        public string IP { get; set; }
        public string Model { get; set; }
        public string TagID { get; set; }
        public string TagName { get; set; }
        public string Tagvalue { get; set; }
        public string Address { get; set; }
        public string type { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
        public string memo { get; set; }
        public string status { get; set; }
        public int dataType { get; set; }
        public int dbNumber { get; set; }
        public int startByte { get; set; }
        public int bitNumber { get; set; }
        public int varType { get; set; }
        public string create_by { get; set; }

        public string update_by { get; set; }
        public DateTime? update_time { get; set; }
        public DateTime? create_time { get; set; }






        //string column = "refid,DeviceID,IP,Model,TagID,TagName,Tagvalue,Address,type,code,msg,memo,status,dataType,dbNumber,startByte,bitNumber,varType,create_by,create_time,update_by,update_time";



        //@refid,@DeviceID,@IP,@Model,@TagID,@TagName,@Tagvalue,@Address,@type,@code,@msg,@memo,@status,@dataType,@dbNumber,@startByte,@bitNumber,@varType,@create_by,@create_time,@update_by,@update_time


        public static string CreateNew(DevicePoint data)
        {
            string sql = " insert into DevicePoint(LineID,DeviceID,IP,Model,TagID,TagName,Tagvalue,Address,type,code,msg,memo,status,dataType,dbNumber,startByte,bitNumber,varType,create_by,create_time)values(@LineID,@DeviceID,@IP,@Model,@TagID,@TagName,@Tagvalue,@Address,@type,@code,@msg,@memo,@status,@dataType,@dbNumber,@startByte,@bitNumber,@varType,@create_by,@create_time)";
            SqlParameter[] paras = new SqlParameter[]
            {
  new SqlParameter("@LineID", data.LineID),
  new SqlParameter("@DeviceID", data.DeviceID),
  new SqlParameter("@IP", data.IP),
  new SqlParameter("@Model", data.Model),
  new SqlParameter("@TagID", data.TagID),
  new SqlParameter("@TagName", data.TagName),
  new SqlParameter("@Tagvalue", data.Tagvalue),
  new SqlParameter("@Address", data.Address),
  new SqlParameter("@type", data.type),
  new SqlParameter("@code", data.code),
  new SqlParameter("@msg", data.msg),
  new SqlParameter("@memo", data.memo),
  new SqlParameter("@status", data.status),
  new SqlParameter("@dataType", data.dataType),
  new SqlParameter("@dbNumber", data.dbNumber),
  new SqlParameter("@startByte", data.startByte),
  new SqlParameter("@bitNumber", data.bitNumber),
  new SqlParameter("@varType", data.varType),
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



        public static string UpdateDataByRefID(DevicePoint data)
        {
            const string sql = "update DevicePoint set  ";
            StringBuilder sb = new StringBuilder();
            sb.Append(sql);

            if (!string.IsNullOrEmpty(data.DeviceID))
            {
                sb.AppendFormat("  DeviceID='{0}' ", data.DeviceID);
            }
            if (!string.IsNullOrEmpty(data.IP))
            {
                sb.AppendFormat(" , IP='{0}' ", data.IP);
            }
            if (!string.IsNullOrEmpty(data.Model))
            {
                sb.AppendFormat(" , Model='{0}' ", data.Model);
            }
            if (!string.IsNullOrEmpty(data.TagID))
            {
                sb.AppendFormat(" , TagID='{0}' ", data.TagID);
            }
            if (!string.IsNullOrEmpty(data.TagName))
            {
                sb.AppendFormat(" , TagName='{0}' ", data.TagName);
            }
            if (!string.IsNullOrEmpty(data.Tagvalue))
            {
                sb.AppendFormat(" , Tagvalue='{0}' ", data.Tagvalue);
            }
            if (!string.IsNullOrEmpty(data.Address))
            {
                sb.AppendFormat(" , Address='{0}' ", data.Address);
            }
            if (!string.IsNullOrEmpty(data.type))
            {
                sb.AppendFormat(" , type='{0}' ", data.type);
            }
            if (!string.IsNullOrEmpty(data.code))
            {
                sb.AppendFormat(" , code='{0}' ", data.code);
            }
            if (!string.IsNullOrEmpty(data.msg))
            {
                sb.AppendFormat(" , msg='{0}' ", data.msg);
            }
            if (!string.IsNullOrEmpty(data.memo))
            {
                sb.AppendFormat(" , memo='{0}' ", data.memo);
            }
            if (!string.IsNullOrEmpty(data.status))
            {
                sb.AppendFormat(" , status='{0}' ", data.status);
            }

            if (!string.IsNullOrEmpty(data.create_by))
            {
                sb.AppendFormat(" , create_by='{0}' ", data.create_by);
            }

            if (!string.IsNullOrEmpty(data.update_by))
            {
                sb.AppendFormat(" , update_by='{0}' ", data.update_by);
            }

            sb.AppendFormat("  where refid={0} ", data.refid);
            return MSSql.ExcuteNOQueryStrEx(sb.ToString());
        }




        public static string DelByRefID(UInt64 refid)
        {
            string sql = string.Format("delete from DevicePoint where refid={0} ", refid);
            return MSSql.ExcuteNOQueryStrEx(sql);
        }





        public static DataTable QueryDataByRefID(UInt64 refid)
        {
            string sql = string.Format(" select  refid,LineID,DeviceID,IP,Model,TagID,TagName,Tagvalue,Address,type,code,msg,memo,status,dataType,dbNumber,startByte,bitNumber,varType,create_by,create_time,update_by,update_time from DevicePoint where refid={0} ", refid);
            return MSSql.ExecuteQueryDataTable(sql);
        }





        public static DevicePoint GetObject(UInt64 refid)
        {
            DevicePoint data = new DevicePoint();
            DataTable dt = DevicePoint.QueryDataByRefID(refid);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                data.refid = Convert.ToUInt64(dt.Rows[0]["refid"]);
                data.LineID= dt.Rows[0]["LineID"].ToString();
                data.DeviceID = dt.Rows[0]["DeviceID"].ToString();
                data.IP = dt.Rows[0]["IP"].ToString();
                data.Model = dt.Rows[0]["Model"].ToString();
                data.TagID = dt.Rows[0]["TagID"].ToString();
                data.TagName = dt.Rows[0]["TagName"].ToString();
                data.Tagvalue = dt.Rows[0]["Tagvalue"].ToString();
                data.Address = dt.Rows[0]["Address"].ToString();
                data.type = dt.Rows[0]["type"].ToString();
                data.code = dt.Rows[0]["code"].ToString();
                data.msg = dt.Rows[0]["msg"].ToString();
                data.memo = dt.Rows[0]["memo"].ToString();
                data.status = dt.Rows[0]["status"].ToString();
                //  data.dataType =Convert.to( dt.Rows[0]["dataType"].ToString());
                data.dbNumber = Convert.ToInt32(dt.Rows[0]["dbNumber"].ToString());
                data.startByte = Convert.ToInt32(dt.Rows[0]["startByte"].ToString());
                data.bitNumber = Convert.ToInt32(dt.Rows[0]["bitNumber"].ToString());
                // data.varType = Convert.ToInt32(dt.Rows[0]["varType"].ToString());
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
            string sql = " select  refid,LineID,DeviceID,IP,Model,TagID,TagName,Tagvalue,Address,type,code,msg,memo,status,dataType,dbNumber,startByte,bitNumber,varType,create_by,create_time,update_by,update_time from DevicePoint    ";
            return MSSql.ExecuteQueryDataTable(sql);
        }





        public static DataTable QueryByCondition(DevicePoint data)
        {
            StringBuilder sb = new StringBuilder();
            string sqlstr = "select refid,LineID,DeviceID,IP,Model,TagID,TagName,Tagvalue,Address,type,code,msg,memo,status,dataType,dbNumber,startByte,bitNumber,varType,create_by,create_time,update_by,update_time  from DevicePoint where 1=1 ";
            sb.Append(sqlstr);

            if (!string.IsNullOrEmpty(data.DeviceID))
            {
                sb.AppendFormat(" and DeviceID like '%{0}%' ", data.DeviceID);
            }
            if (!string.IsNullOrEmpty(data.IP))
            {
                sb.AppendFormat(" and IP like '%{0}%' ", data.IP);
            }
            if (!string.IsNullOrEmpty(data.Model))
            {
                sb.AppendFormat(" and Model like '%{0}%' ", data.Model);
            }
            if (!string.IsNullOrEmpty(data.TagID))
            {
                sb.AppendFormat(" and TagID like '%{0}%' ", data.TagID);
            }
            if (!string.IsNullOrEmpty(data.TagName))
            {
                sb.AppendFormat(" and TagName like '%{0}%' ", data.TagName);
            }
            if (!string.IsNullOrEmpty(data.Tagvalue))
            {
                sb.AppendFormat(" and Tagvalue like '%{0}%' ", data.Tagvalue);
            }
            if (!string.IsNullOrEmpty(data.Address))
            {
                sb.AppendFormat(" and Address like '%{0}%' ", data.Address);
            }
            if (!string.IsNullOrEmpty(data.type))
            {
                sb.AppendFormat(" and type like '%{0}%' ", data.type);
            }
            if (!string.IsNullOrEmpty(data.code))
            {
                sb.AppendFormat(" and code like '%{0}%' ", data.code);
            }
            if (!string.IsNullOrEmpty(data.msg))
            {
                sb.AppendFormat(" and msg like '%{0}%' ", data.msg);
            }
            if (!string.IsNullOrEmpty(data.memo))
            {
                sb.AppendFormat(" and memo like '%{0}%' ", data.memo);
            }
            if (!string.IsNullOrEmpty(data.status))
            {
                sb.AppendFormat(" and status like '%{0}%' ", data.status);
            }


            if (!string.IsNullOrEmpty(data.create_by))
            {
                sb.AppendFormat(" and create_by like '%{0}%' ", data.create_by);
            }

            if (!string.IsNullOrEmpty(data.update_by))
            {
                sb.AppendFormat(" and update_by like '%{0}%' ", data.update_by);
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



        public static DataTable DevicePointBlurSearch(string column, string value)
        {
            string sql = string.Format("select refid,LineID,DeviceID,IP,Model,TagID,TagName,Tagvalue,Address,type,code,msg,memo,status,dataType,dbNumber,startByte,bitNumber,varType,create_by,create_time,update_by,update_time from DevicePoint where {0} like '%{1}%' ", column, value);
            return MSSql.ExecuteQueryDataTable(sql);
        }

        public static DataTable GetDistinctDevice()
        {
            string sql = string.Format(" select distinct deviceid from DevicePoint ");
            return MSSql.ExecuteQueryDataTable(sql);
        }

        public static DataTable GetDataPointByDeviceID(string deviceid)
        {
            string sql = string.Format(" select  IP,Model,TagID,TagName,Tagvalue,Address,type,code,msg,memo,status,dataType,dbNumber,startByte,bitNumber,varType from DevicePoint where deviceid='{0}' ", deviceid);
            return MSSql.ExecuteQueryDataTable(sql);
        }

        public static DataTable GetTagName()
        {
            string sql = "select TagID from DevicePoint ";
            return MSSql.ExecuteQueryDataTable(sql);
        }

        public static DataTable GetTagIDByEqp(string eqpid)
        {
            string sql =string.Format( "select TagID from DevicePoint where DeviceID='{0}' ",eqpid);
            return MSSql.ExecuteQueryDataTable(sql);
        }

        public static DataTable  GetTagData( )
        {
            string sql = string.Format(" select LineID,TagID,TagName,DeviceID,type from DevicePoint ");
            return MSSql.ExecuteQueryDataTable(sql);
        }

    }


}
