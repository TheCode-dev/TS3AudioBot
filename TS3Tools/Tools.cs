using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TS3Tools
{
	public static class Tools
	{
		public static bool IsLinux
		{
			get
			{
				int p = (int)Environment.OSVersion.Platform;
				return (p == 4) || (p == 6) || (p == 128);
			}
		}

		public static IEnumerable<Enum> GetFlags(this Enum input) => Enum.GetValues(input.GetType()).Cast<Enum>().Where(input.HasFlag);

		// Encoding

		public static Encoding Utf8Encoder { get; } = new UTF8Encoding(false, false);

		// Time

		public static readonly DateTime UnixTimeStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

		public static uint ToUnix(this DateTime dateTime) => (uint)(dateTime - UnixTimeStart).TotalSeconds;

		public static DateTime FromUnix(uint unixTimestamp) => UnixTimeStart.AddSeconds(unixTimestamp);

		public static uint UnixNow => (uint)(DateTime.UtcNow - UnixTimeStart).TotalSeconds;

		public static DateTime Now => DateTime.UtcNow;

		// Random

		public static Random Random { get; } = new Random();

		public static T PickRandom<T>(IReadOnlyList<T> collection)
		{
			int pick = Random.Next(0, collection.Count);
			return collection[pick];
		}

		// Math

		public static TimeSpan Min(TimeSpan a, TimeSpan b) => a < b ? a : b;
		public static TimeSpan Max(TimeSpan a, TimeSpan b) => a > b ? a : b;

		public static int MathMod(int x, int mod) => ((x % mod) + mod) % mod;

		public static float Clamp(float value, float min, float max) => Math.Min(Math.Max(value, min), max);
		public static int Clamp(int value, int min, int max) => Math.Min(Math.Max(value, min), max);

		// Generic

		public static void SetLogId(Id id) => SetLogId(id.ToString());
		public static void SetLogId(string id) => NLog.MappedDiagnosticsContext.Set("BotId", id);

		public static Exception UnhandledDefault<T>(T value) where T : struct { return new MissingEnumCaseException(typeof(T).Name, value.ToString()); }
	}
}
