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
using System.IO;
using System.Text;

namespace logictable
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (args.Length != 5 || args[0] != "-eam")
				return;

			string tablePath  = args[1];
			int numVarsColumn = Convert.ToInt32(args[2]);
			int numVarsRow    = Convert.ToInt32(args[3]);
			string outputPath = args[4];

			// Export All Minterms
			LogicTable lt = LogicTable.FromText(File.ReadAllText(tablePath), numVarsColumn, numVarsRow);

			StringBuilder output = new StringBuilder();
			int[] min;
			for (int i = 0; i < lt.NumBits; i++) {
				output.AppendFormat("Y{0}\n", i);

				min = lt.GetMintermsOf(i, BitValue.One);
				output.Append("1: ");
				for (int k = 0; k < min.Length; k++)
					output.AppendFormat("{0},", min[k]);
				output.AppendLine();

				min = lt.GetMintermsOf(i, BitValue.DontCare);
				output.Append("-: ");
				for (int k = 0; k < min.Length; k++)
					output.AppendFormat("{0},", min[k]);
				output.AppendLine();
			}

			File.WriteAllText(outputPath, output.ToString());

		}
	}
}
