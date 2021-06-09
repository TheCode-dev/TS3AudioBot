// TS3AudioBot - An advanced Musicbot for Teamspeak 3
// Copyright (C) 2017  TS3AudioBot contributors
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the Open Software License v. 3.0
//
// You should have received a copy of the Open Software License along with this
// program. If not, see <https://opensource.org/licenses/OSL-3.0>.

using System;
using System.Linq;
using TS3AudioBot.CommandSystem;

namespace TS3AudioBot.Config
{
	public static class ConfigHelper
	{
		public static ConfigPart[] ByPathAsArray(this ConfigPart config, string path)
		{
			try
			{
				return config.ByPath(path).ToArray();
			}
			catch (Exception ex)
			{
				throw new CommandException("Invalid TomlPath expression", ex, CommandExceptionReason.CommandError);
			}
		}
	}
}
