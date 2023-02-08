using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core.Flux.Domain;
using InfluxDB.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfluxDB.Client.Writes;
using LocaWebAPI.Models;

namespace WebApplication2.InfluxMap
{
    //private class EntityConverterMachine : IDomainObjectMapper
    //{
    //    //
    //    // Parse incoming FluxRecord to DomainObject
    //    //
    //    public T ConvertToEntity<T>(FluxRecord fluxRecord)
    //    {
    //        if (typeof(T) != typeof(InfluxModel))
    //        {
    //            throw new NotSupportedException($"This converter doesn't supports: {typeof(InfluxModel)}");
    //        }

    //        //
    //        // Create SensorCustom entity and parse `SeriesId`, `Value` and `Time`
    //        //
    //        var customEntity = new InfluxModel
    //        {
    //            Id= Guid.Parse(Convert.ToString(fluxRecord.GetValueByKey("series_id"))!),
    //            Data = Convert.ToDouble(fluxRecord.GetValueByKey("data")),
    //            Time = fluxRecord.GetTime().GetValueOrDefault().ToDateTimeUtc(),
    //            //Attributes = new List<SensorAttribute>()
    //        };

    //        foreach (var (key, value) in fluxRecord.Values)
    //        {
    //            //
    //            // Parse SubCollection values
    //            //
    //            if (key.StartsWith("property_"))
    //            {
    //                var attribute = new SensorAttribute
    //                {
    //                    Name = key.Replace("property_", string.Empty),
    //                    Value = Convert.ToString(value)
    //                };

    //                customEntity.Attributes.Add(attribute);
    //            }
    //        }

    //        return (T)Convert.ChangeType(customEntity, typeof(T));
    //    }

    //    //
    //    // Convert DomainObject into PointData
    //    //
    //    public PointData ConvertToPointData<T>(T entity, WritePrecision precision)
    //    {
    //        if (!(entity is InfluxModel ce))
    //        {
    //            throw new NotSupportedException($"This converter doesn't supports: {typeof(SensorCustom)}");
    //        }

    //        //
    //        // Map `SeriesId`, `Value` and `Time` to Tag, Field and Timestamp
    //        //
    //        var point = PointData
    //            .Measurement("custom_measurement")
    //            .Tag("series_id", ce.Id.ToString())
    //            .Field("data", ce.Data)
    //            .Timestamp(ce.Time, precision);

    //        //
    //        // Map subattributes to Fields
    //        //
    //        foreach (var attribute in ce.Attributes ?? new List<SensorAttribute>())
    //        {
    //            point = point.Field($"property_{attribute.Name}", attribute.Value);
    //        }

    //        return point;
    //    }
    //}
}