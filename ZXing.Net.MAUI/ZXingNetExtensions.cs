using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Graphics;

namespace ZXing.Net.Maui
{
	public static class ZXingNetExtensions
	{
		public static BarcodeResult ToBarcodeResult(this ZXing.Result result)
			=> new()
			{
				Raw = result.RawBytes,
				Value = result.Text,
				Format = (BarcodeFormat)(int)result.BarcodeFormat,
				Metadata = new Dictionary<MetadataType, object>(result?.ResultMetadata?.Select(md => new KeyValuePair<MetadataType, object> ((MetadataType)md.Key, md.Value))),
				PointsOfInterest = result?.ResultPoints?.Select(p => new PointF(p?.X ?? 0f, p?.Y ?? 0f))?.ToArray()
			};

		public static BarcodeResult[] ToBarcodeResults(this ZXing.Result[] results)
			=> results?.Select(result => new BarcodeResult()
			{
				Raw = result.RawBytes,
				Value = result.Text,
				Format = (BarcodeFormat)(int)result.BarcodeFormat,
				Metadata = new Dictionary<MetadataType, object>(result?.ResultMetadata?.Select(md => new KeyValuePair<MetadataType, object>((MetadataType)md.Key, md.Value))),
				PointsOfInterest = result?.ResultPoints?.Select(p => new PointF(p?.X ?? 0f, p?.Y ?? 0f))?.ToArray()
			})?.ToArray();
	}
}
