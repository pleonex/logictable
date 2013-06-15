//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="none">
// Copyright (C) 2013
//
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by 
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//
//   This program is distributed in the hope that it will be useful, 
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details. 
//
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see "http://www.gnu.org/licenses/". 
// </copyright>
// <author>pleoNeX</author>
// <email>benito356@gmail.com</email>
// <date>15/06/2013</date>
//-----------------------------------------------------------------------
using System;

namespace logictable
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string table = @"0000
0010
----
0100
0000
0001
0001
0001
0111
0011
0001
----
0000
0011
----
----
0010
0110
0110
0110
0111
1111
----
0110
0101
0001
----
1101
0101
----
0110
0100
1100
1000
1000
1100
1100
----
1001
1101
1110
1111
1011
----
1110
1110
1010
1010
0010
1011
1010
1010
----
1001
1001
----
----
0001
0001
0001
0000
1000
1000
1001
";
			LogicTable lt = LogicTable.FromText(table, 2, 4);
			if (lt[14, 2][2] != BitValue.Zero)
				throw new Exception();

			int[] ones     = lt.GetMintermsOf(0, BitValue.One);
			int[] dontcare = lt.GetMintermsOf(0, BitValue.DontCare);

			Console.WriteLine("Done!");
		}
	}
}
