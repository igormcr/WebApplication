using System;
using System.Net.Http;
using System.Web.Mvc;
using LocaWebAPI.Models;
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core;
using Task = System.Threading.Tasks.Task;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WebApplication2.Controllers
{
    public class InfluxController : Controller
    {


        public ActionResult Index()
        {
            InfluxModel.DataHistoryEntry obj = new InfluxModel.DataHistoryEntry();
            HttpResponseMessage httpResponseMe = new HttpResponseMessage();
            WritePointsInflux();
            return View();
        }

        private static readonly char[] Token = "-4pzow_giNIIMOuGN3wKfD7KnTdLACIR6pxw1a23T7lxcBDcjcUacm_oyVEKcygZLCFBnHsvLvlvqooUGXqkRg==".ToCharArray();

        public static async Task Main()
        {
            var client = new InfluxDBClient("http://192.168.15.115:8086", "HlFomVb-ps9_xv7dLv0dPjQdOiJM_xd-MfyCqyeghsGnWT70NDQttq_BfN8ihftsyJUIn6XfylQcj9YjUBXgjA==");

            //
            // Write Data
            //
            for (int i = 0; i < 1000000; i++)
            {
                int a =0;
                wait(a);
                using (var writeApi = client.GetWriteApi())
                {
                    //
                    // Write by Point
                    //
                    float f = GenerateRandom();
                    wait(60);
                    float f2 = GenerateRandom();
                    wait(60);
                    float f3 =GenerateRandom();
                    wait(60);
                    float f4 = GenerateRandom();
                    wait(60);
                    float f5 = GenerateRandom();
                    wait(60);
                    float f6 = GenerateRandom();



                    var point = InfluxDB.Client.Writes.PointData.Measurement("Machine")
                        .Tag("Machine_id", "EPREG0242")
                        .Field("temperature", f)
                        .Field("usage", f2)
                        .Field("fanspeed", f3)
                        .Field("gauge", f4)
                        .Field("test1", f5)
                        .Field("test2", f6)
                        .Timestamp(DateTime.UtcNow.AddSeconds(-10), WritePrecision.Ns);
                    writeApi.WritePoint(point, "db_influx_test", "ec19deabee672945");
                    //
                    // Write by LineProtocol
                    //
                    //writeApi.WriteRecord("temperature,value=60.0", WritePrecision.Ns, "db_influx_test", "ec19deabee672945");

                    //
                    // Write by POCO
                    //
                    //var machine = new Machine { machine_id = 50, Usage = 70, Time = DateTime.UtcNow };
                    //writeApi.WriteMeasurement(machine, WritePrecision.Ns, "db_influx_test", "ec19deabee672945");

                    var clienttest2 = client.PingAsync();
                    //Console.WriteLine(clienttest2.Result);
                    //if (clienttest2.Result == true) {
                    //    Console.WriteLine("Response ok");
                    //}
                    //else { wait(600); }

                    writeApi.Dispose();
                }

                //if (clienttest.Result == true)
                //{
                //    Console.Write("Response ok");
                //}
                //else { wait(600); Main(); }
                //Query data;


                //var queryapi = client.GetQueryApi();
                //var flux = "from(bucket:\"db_influx_test\") |> range(start: 0)";

                //var fluxTables = await queryapi.QueryAsync(flux, "ec19deabee672945");
                //fluxTables.ForEach(fluxTable =>
                //{
                //    var fluxRecords = fluxTable.Records;
                //    fluxRecords.ForEach(fluxRecord =>
                //    {
                //        Console.WriteLine($"{fluxRecord.GetTime()}: {fluxRecord.GetValue()}");
                //    });

                //});
            }
        }

        public static async Task WritePointsInflux()
        {
            var client = new InfluxDBClient("http://192.168.15.115:8086", "HlFomVb-ps9_xv7dLv0dPjQdOiJM_xd-MfyCqyeghsGnWT70NDQttq_BfN8ihftsyJUIn6XfylQcj9YjUBXgjA==");

            //
            // Write Data
            //
            for (int i = 0; i < 1000000; i++)
            {
                int a = 0;
                wait(a);
                using (var writeApi = client.GetWriteApi())
                {
                    //
                    // Write by Point
                    //
                    List<InfluxDB.Client.Writes.PointData> points = new List<InfluxDB.Client.Writes.PointData>(0);

                    for (int i2 = 0; i2 < 50; i2++)
                    {
                        Random r = new Random();
                        int rInt = r.Next(0,20);

                        var point = InfluxDB.Client.Writes.PointData.Measurement("Machine")
                        .Tag("Machine_id", "EPREG0242")
                        .Field("temperature", GenerateRandom())
                        .Field("usage", GenerateRandom())
                        .Field("fanspeed", GenerateRandom())
                        .Field("gauge", GenerateRandom())
                        .Field("test1", GenerateRandom())
                        .Field("test2", GenerateRandom())
                        .Timestamp(DateTime.UtcNow.AddSeconds(rInt), WritePrecision.Ns);

                        points.Add(point);

                        var point2 = InfluxDB.Client.Writes.PointData.Measurement("Machine")
                        .Tag("Machine_id", "EPREG0202" + rInt.ToString())
                        .Field("temperature", GenerateRandom())
                        .Field("usage", GenerateRandom())
                        .Field("fanspeed", GenerateRandom())
                        .Field("gauge", GenerateRandom())
                        .Field("test1", GenerateRandom())
                        .Field("test2", GenerateRandom())
                        .Timestamp(DateTime.UtcNow.AddSeconds(0), WritePrecision.Ns);

                        points.Add(point2);

                        var point3 = InfluxDB.Client.Writes.PointData.Measurement("Machine")
                        .Tag("Machine_id", "EPREG0101" + rInt.ToString())
                        .Field("temperature", GenerateRandom())
                        .Field("usage", GenerateRandom())
                        .Field("fanspeed", GenerateRandom())
                        .Field("gauge", GenerateRandom())
                        .Field("test1", GenerateRandom())
                        .Field("test2", GenerateRandom())
                        .Timestamp(DateTime.UtcNow.AddSeconds(0), WritePrecision.Ns);

                        points.Add(point3);
                    }
                    writeApi.WritePoints(points, "db_influx_test", "ec19deabee672945");

                    var clienttest2 = client.PingAsync();
                    //Console.WriteLine(clienttest2.Result);
                    //if (clienttest2.Result == true) {
                    //    Console.WriteLine("Response ok");
                    //}
                    //else { wait(600); }

                    writeApi.Dispose();
                }

            }
        }

        private static void wait(int value)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (value == 0 || value < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = value;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

        private static float GenerateRandom()
        {
            Random r = new Random();
            int rInt = r.Next(0, 50);

            var rand = new Random();
            double min = 1;
            double max = 100;
            double range = max - min;

            double sample2 = rand.NextDouble();
            double scaled2 = (sample2 * range) + min;
            return (float)scaled2 + rInt;

        }

        [Measurement("Machine")]
        private class Machine
        {
            [@Column("machine_id")] public int machine_id { get; set; }

            [@Column("usage")] public double Usage { get; set; }

            [@Column(IsTimestamp = true)] public DateTime Time { get; set; }
        }

    }
}

