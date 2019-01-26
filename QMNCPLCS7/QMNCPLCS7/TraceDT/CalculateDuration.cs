using System;
using System.Collections.Generic;
using System.Text;
using QMNetCorePLCS7;
using System.Collections;
using QMNCPLCS7.Entities;
using System.Data;
using QMNetCoreFrame.Log;
using System.Threading;

namespace QMNCPLCS7.TraceDT
{
  public  class CalculateDuration
    {

        public static EqpSpanDuration Get60MKPI(string tagid)
        {
            EqpSpanDuration data = new EqpSpanDuration();
            try
            {
                data.TagID = tagid;
                SpanStatus span = DTRecord.GetSpanTimeStatus(tagid, -60);
                bool ISDown = true;
                if (span != null)
                {
                    if (span.Status == "Operating" || span.Status == "Lack" || span.Status == "Tailback")
                    {
                        data.Run = span.Duration;
                        ISDown = false;
                    }
                    else
                    {
                        data.Down = span.Duration;
                    }

                }

                if (ISDown)
                {
                    data.Down = data.Down + DTRecord.GetDownTime(tagid, -60);
                    data.Run = 60 - data.Down;
                }
                else
                {
                    data.Down = DTRecord.GetDownTime(tagid, -60);
                    data.Run = 60 - data.Down;
                }

                data.KPI = data.Run / 60;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                data = null;
            }
            
            return data;
        }



        public static EqpSpanDuration Get30MKPI(string tagid)
        {
            EqpSpanDuration data = new EqpSpanDuration();
            try
            {
                data.TagID = tagid;
                SpanStatus span = DTRecord.GetSpanTimeStatus(tagid, -30);
                bool ISDown = true;
                if (span != null)
                {
                    if (span.Status == "Operating" || span.Status == "Lack" || span.Status == "Tailback")
                    {
                        data.Run = span.Duration;
                        ISDown = false;
                    }
                    else
                    {
                        data.Down = span.Duration;
                    }

                }

                if (ISDown)
                {
                    data.Down = data.Down + DTRecord.GetDownTime(tagid, -30);
                    data.Run = 30 - data.Down;
                }
                else
                {
                    data.Down = DTRecord.GetDownTime(tagid, -30);
                    data.Run = 30 - data.Down;
                }

                data.KPI = data.Run / 30;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                data = null;
            }
            
            return data;
        }



        public static EqpSpanDuration Get15MKPI(string tagid)
        {
            EqpSpanDuration data = new EqpSpanDuration();
            try
            {
                data.TagID = tagid;
                SpanStatus span = DTRecord.GetSpanTimeStatus(tagid, -15);
                bool ISDown = true;
                if (span != null)
                {
                    if (span.Status == "Operating" || span.Status == "Lack" || span.Status == "Tailback")
                    {
                        data.Run = span.Duration;
                        ISDown = false;
                    }
                    else
                    {
                        data.Down = span.Duration;
                    }

                }

                if (ISDown)
                {
                    data.Down = data.Down + DTRecord.GetDownTime(tagid, -15);
                    data.Run = 15 - data.Down;
                }
                else
                {
                    data.Down = DTRecord.GetDownTime(tagid, -15);
                    data.Run = 15 - data.Down;
                }

                data.KPI = data.Run / 15;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                data = null;
            }
            
            return data;
        }


        public static EqpSpanDuration Get10MKPI(string tagid)
        {
            EqpSpanDuration data = new EqpSpanDuration();
            try
            {
                data.TagID = tagid;
                SpanStatus span = DTRecord.GetSpanTimeStatus(tagid, -10);
                bool ISDown = true;
                if (span != null)
                {
                    if (span.Status == "Operating" || span.Status == "Lack" || span.Status == "Tailback")
                    {
                        data.Run = span.Duration;
                        ISDown = false;
                    }
                    else
                    {
                        data.Down = span.Duration;
                    }

                }

                if (ISDown)
                {
                    data.Down = data.Down + DTRecord.GetDownTime(tagid, -10);
                    data.Run = 10 - data.Down;
                }
                else
                {
                    data.Down = DTRecord.GetDownTime(tagid, -10);
                    data.Run = 10 - data.Down;
                }

                data.KPI = data.Run / 10;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                data = null;
            }

            return data;
        }



        public static EqpSpanDuration Get5MKPI(string tagid)
        {
            EqpSpanDuration data = new EqpSpanDuration();
            try
            {
                data.TagID = tagid;
                SpanStatus span = DTRecord.GetSpanTimeStatus(tagid, -5);
                bool ISDown = true;
                if (span != null)
                {
                    if (span.Status == "Operating" || span.Status == "Lack" || span.Status == "Tailback")
                    {
                        data.Run = span.Duration;
                        ISDown = false;
                    }
                    else
                    {
                        data.Down = span.Duration;
                    }

                }

                if (ISDown)
                {
                    data.Down = data.Down + DTRecord.GetDownTime(tagid, -5);
                    data.Run = 5 - data.Down;
                }
                else
                {
                    data.Down = DTRecord.GetDownTime(tagid, -5);
                    data.Run = 5 - data.Down;
                }

                data.KPI = data.Run / 5;
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
                data = null;
            }
            
            return data;
        }


        public static EqpSpanDuration Get2MKPI(string tagid)
        {
            EqpSpanDuration data = new EqpSpanDuration();
            try
            {
                data.TagID = tagid;
                SpanStatus span = DTRecord.GetSpanTimeStatus(tagid, -2);
                bool ISDown = true;
                if (span != null)
                {
                    if (span.Status == "Operating" || span.Status == "Lack" || span.Status == "Tailback")
                    {
                        data.Run = span.Duration;
                        ISDown = false;
                    }
                    else
                    {
                        data.Down = span.Duration;
                    }

                }

                if (ISDown)
                {
                    data.Down = data.Down + DTRecord.GetDownTime(tagid, -2);
                    data.Run = 2 - data.Down;
                }
                else
                {
                    data.Down = DTRecord.GetDownTime(tagid, -2);
                    data.Run = 2 - data.Down;
                }

                data.KPI = data.Run / 2;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                data = null;
            }

            return data;
        }


    }
}
