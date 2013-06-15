//-----------------------------------------------------------------------
// <copyright file="BitNumber.cs" company="none">
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
using System.Text;

namespace logictable
{
	public enum BitValue {
		One,
		Zero,
		DontCare
	};

	public struct BitNumber
	{
		private BitValue[] bits;

		public BitNumber(BitValue[] bits)
		{
			this.bits = bits;
		}

		public BitValue this[int i] {
			get { return this.bits[i]; }
		}

		public int NumBits {
			get { return this.bits.Length; }
		}

		public static BitNumber FromString(string val)
		{
			BitValue[] bits = new BitValue[val.Length];

			for (int i = 0; i < val.Length; i++) {
				if (val[i] == '1')
					bits[i] = BitValue.One;
				else if (val[i] == '0')
					bits[i] = BitValue.Zero;
				else if (val[i] == '-')
					bits[i] = BitValue.DontCare;
				else
					throw new ArgumentException();
			}

			return new BitNumber(bits);
		}

		public override string ToString()
		{
			StringBuilder t = new StringBuilder(this.bits.Length);
			for (int i = 0; i < this.bits.Length; i++) {
				if (this.bits[i] == BitValue.One)
					t.Append('1');
				else if (this.bits[i] == BitValue.Zero)
					t.Append('0');
				else if (this.bits[i] == BitValue.DontCare)
					t.Append('-');
			}

			return t.ToString();
		}
	}
}

