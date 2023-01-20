using System;
using System.Net.Http;
using System.Web.Mvc;
using LocaWebAPI.Models;
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core;
using Task = System.Threading.Tasks.Task;
using System.Windows.Forms;

namespace WebApplication2.Controllers
{
    public class InfluxController : Controller
    {


        public ActionResult Index()
        {
            InfluxModel.DataHistoryEntry obj = new InfluxModel.DataHistoryEntry();
            HttpResponseMessage httpResponseMe = new HttpResponseMessage();
            Main();
            //ChamadaPost(obj);
            return View();
        }

        private static readonly char[] Token = "-4pzow_giNIIMOuGN3wKfD7KnTdLACIR6pxw1a23T7lxcBDcjcUacm_oyVEKcygZLCFBnHsvLvlvqooUGXqkRg==".ToCharArray();

        public static async Task Main()
        {
            Random rand = new Random();
            double min = 1;
            double max = 100;
            double range = max - min;
            double sample = rand.NextDouble();
            double scaled = (sample * range) + min;
            float f = (float)scaled;



            double sample2 = rand.NextDouble();
            double scaled2 = (sample2 * range) + min;
            float f2 = (float)scaled2;

            var client = new InfluxDBClient("http://192.168.15.115:8086","adminIg","dm123456");

            //
            // Write Data
            //
            for (int i = 0; i < 1000000; i++)
            {
                int a = 3800;
                wait(a);
                using (var writeApi = client.GetWriteApi())
                {
                    //
                    // Write by Point
                    //
                    var point = InfluxDB.Client.Writes.PointData.Measurement("Machine")
                        .Tag("Machine_id", "EPREG0242")
                        .Field("temperature", f)
                        .Field("usage", f2)
                        .Field("fanspeed", f)
                        .Field("gauge", f2)
                        .Field("test1", f)
                        .Field("test2", f2)
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



                    //writeApi.Dispose();
                }

                //
                // Query data
                //
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

        [Measurement("Machine")]
        private class Machine
        {
            [@Column("machine_id")] public int machine_id { get; set; }

            [@Column("usage")] public double Usage { get; set; }

            [@Column(IsTimestamp = true)] public DateTime Time { get; set; }
        }

    }
}

