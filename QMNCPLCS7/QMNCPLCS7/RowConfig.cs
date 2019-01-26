using System;
using System.Collections.Generic;
using System.Text;
using QMNetCorePLCS7;
using System.Collections;
using QMNCPLCS7.Entities;
using System.Data;
using QMNetCoreFrame.Log;

namespace QMNCPLCS7
{
   public class RowConfig
    {
        public static Dictionary<string, ArrayList> EqpPoint = new Dictionary<string, ArrayList>();

        public static Dictionary<string, TagData> TagDic = new Dictionary<string, TagData>();


        public static void InitData()
        {
            EqpPoint.Clear();
            
          
          DataTable device= DevicePoint.GetDistinctDevice();
            if (device == null || device.Rows.Count == 0)
            {

            }
            else
            {
                string deviceid = "";
                for(int i = 0; i < device.Rows.Count; i++)
                {
                    deviceid = device.Rows[i]["deviceid"].ToString().Trim();
                    if (!string.IsNullOrEmpty(deviceid))
                    {
                        DataTable dt = DevicePoint.GetDataPointByDeviceID(deviceid);
                        if (dt == null || dt.Rows.Count == 0)
                        {

                        }
                        else
                        {
                            ArrayList list = new ArrayList();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                RowDataPoint point = new RowDataPoint();
                                point.IP = dt.Rows[j]["IP"].ToString().Trim();
                                point.TagID = dt.Rows[j]["TagID"].ToString().Trim();
                                point.TagName = dt.Rows[j]["TagName"].ToString().Trim();
                                point.type = dt.Rows[j]["type"].ToString().Trim();
                                point.datatype = Convert.ToInt32(dt.Rows[j]["dataType"].ToString().Trim());
                                point.dbNumber = Convert.ToInt32(dt.Rows[j]["dbNumber"].ToString().Trim());
                                point.startByte = Convert.ToInt32(dt.Rows[j]["startByte"].ToString().Trim());
                                point.bitNumber = Convert.ToInt32(dt.Rows[j]["bitNumber"].ToString().Trim());
                                point.vartype = Convert.ToInt32(dt.Rows[j]["varType"].ToString().Trim());
                                list.Add(point);
                            }
                            EqpPoint.Add(deviceid, list);
                        }
                    }
                  

                  
                }
            }

        }

        
        public static void InitDic()
        {
            RealData.Clear();
            FrontData.Clear();

            DataTable dt = DevicePoint.GetTagName();
            if (dt != null && dt.Rows.Count > 0)
            {
                string tagid = "";
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    tagid = dt.Rows[i]["TagID"].ToString().Trim();

                    Log.Info("[ReadData Dic Add TagID:] " + tagid);
                    RealData.dic.Add(tagid, uint.MaxValue);

                    PLCHisData data = new PLCHisData();
                    data.Value = uint.MaxValue;
                    data.refid = 0;
                    data.TagID = tagid;
                    data.Time = DateTime.Now;
                    data.type = "";

                    FrontData.dic.Add(tagid, data);
                    Log.Info("[FrontData Dic Add TagID:] " + tagid);
                }
            }
        }


        public static void InitTagDic()
        {
            TagDic.Clear();
            
            DataTable dt = DevicePoint.GetTagData();
            if (dt != null && dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    TagData data = new TagData();
                    data.LineID= dt.Rows[i]["LineID"].ToString().Trim();
                    data.DeviceID = dt.Rows[i]["DeviceID"].ToString().Trim();
                    data.TagID= dt.Rows[i]["TagID"].ToString().Trim();
                    data.TagName= dt.Rows[i]["TagName"].ToString().Trim();
                    data.type= dt.Rows[i]["type"].ToString().Trim();
                    TagDic.Add(data.TagID, data);
                    
                }
            }
        }
    }

   public class RowDataPoint
    {
        public string type { set; get; }
        public string Line { set; get; }
        public string EQP { set; get; }
        public string IP { set; get; }
        public string TagID { set; get; }
        public string TagName { set; get; }
        public string TagValue { set; get; }
        public QMNetCorePLCS7.DataType Area { set; get; }
        public int datatype { set; get; }
        public int vartype { set; get; }
        public int dbNumber { set; get; }
        public int startByte { set; get; }
        public int bitNumber { set; get; }

    }


    public class TagData
    {
        public string TagID { set; get; }
        public string TagName { set; get; }
        public string LineID { set; get; }
        public string DeviceID { set; get; }
        public string type { set; get; }
    }

   public class RealData
    {
        public static Dictionary<string,uint> dic = new Dictionary<string, uint>();

        public static void Clear()
        {
            dic.Clear();
        }

    }

    public class FrontData
    {
        public static Dictionary<string, PLCHisData> dic = new Dictionary<string, PLCHisData>();

        public static void Clear()
        {
            dic.Clear();
        }
    }

    public class PLCHisData
    {
        public string formid { set; get; }
        public UInt64 refid { set; get; }
        public string TagID { set; get; }
        public DateTime Time { set; get; }
        public uint Value { set; get; }
        public string type { set; get; }
    }

}
