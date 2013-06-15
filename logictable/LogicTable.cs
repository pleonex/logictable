//-----------------------------------------------------------------------
// <copyright file="LogicTable.cs" company="none">
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
using System.Collections.Generic;

namespace logictable
{
	public class LogicTable
	{
		private BitNumber[,] table;

		private LogicTable(BitNumber[,] table)
		{
			this.table = table;
		}

		public static LogicTable FromText(string txtTable, int numVarsX, int numVarsY)
		{
			string[] entries = txtTable.Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
			int numEntries = entries.Length;
			int numBits = entries[0].Length;

			int numRows = 1 << numVarsY;
			int numColumns = 1 << numVarsX;
			if (numEntries != numRows * numColumns)
				throw new ArgumentException();

			BitNumber[,] table = new BitNumber[numRows, numColumns];
			for (int r = 0; r < numRows; r++) {
				for (int c = 0; c < numColumns; c++) {
					table[r, c] = BitNumber.FromString(entries[r * numColumns + c]);
					if (table[r, c].NumBits != numBits)
						throw new ArgumentException();
				}
			}

			return new LogicTable(table);
		}

		public BitNumber this[int row, int column] {
			get { return this.table[row, column]; }
		}

		public int NumBits {
			get { return this.table[0, 0].NumBits; }
		}
	}
}

