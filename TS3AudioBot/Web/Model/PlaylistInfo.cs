// TS3AudioBot - An advanced Musicbot for Teamspeak 3
// Copyright (C) 2017  TS3AudioBot contributors
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the Open Software License v. 3.0
//
// You should have received a copy of the Open Software License along with this
// program. If not, see <https://opensource.org/licenses/OSL-3.0>.

using System.Text.Json.Serialization;

namespace TS3AudioBot.Web.Model
{
	public class PlaylistInfo
	{
		// TODO better names
		[JsonPropertyName("Id")]
		public string Id { get; set; }
		[JsonPropertyName("Title")]
		public string Title { get; set; }

		/// <summary>How many songs are in the entire playlist</summary>
		[JsonPropertyName("SongCount")]
		public int SongCount { get; set; }
		/// <summary>From which index the itemization begins.</summary>
		[JsonPropertyName("DisplayOffset")]
		public int DisplayOffset { get; set; }
		/// <summary>The playlist items for the request.
		/// This might only be a part of the entire playlist.
		/// Check <see cref="SongCount"> for the entire count.</summary>
		[JsonPropertyName("Items")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public PlaylistItemGetData[]? Items { get; set; }

		public PlaylistInfo(string id, string title)
		{
			Id = id;
			Title = title;
		}
	}
}
