using System;

public struct Array_i8_12
{
	public byte element_0;

	public byte element_1;

	public byte element_2;

	public byte element_3;

	public byte element_4;

	public byte element_5;

	public byte element_6;

	public byte element_7;

	public byte element_8;

	public byte element_9;

	public byte element_10;

	public byte element_11;
}

using System;

public struct Array_i8_16
{
	public byte element_0;

	public byte element_1;

	public byte element_2;

	public byte element_3;

	public byte element_4;

	public byte element_5;

	public byte element_6;

	public byte element_7;

	public byte element_8;

	public byte element_9;

	public byte element_10;

	public byte element_11;

	public byte element_12;

	public byte element_13;

	public byte element_14;

	public byte element_15;
}

using System;

public struct Array_i8_18
{
	public byte element_0;

	public byte element_1;

	public byte element_2;

	public byte element_3;

	public byte element_4;

	public byte element_5;

	public byte element_6;

	public byte element_7;

	public byte element_8;

	public byte element_9;

	public byte element_10;

	public byte element_11;

	public byte element_12;

	public byte element_13;

	public byte element_14;

	public byte element_15;

	public byte element_16;

	public byte element_17;
}

using System;

public struct Array_i8_19
{
	public byte element_0;

	public byte element_1;

	public byte element_2;

	public byte element_3;

	public byte element_4;

	public byte element_5;

	public byte element_6;

	public byte element_7;

	public byte element_8;

	public byte element_9;

	public byte element_10;

	public byte element_11;

	public byte element_12;

	public byte element_13;

	public byte element_14;

	public byte element_15;

	public byte element_16;

	public byte element_17;

	public byte element_18;
}

using System;

public struct Array_i8_20
{
	public byte element_0;

	public byte element_1;

	public byte element_2;

	public byte element_3;

	public byte element_4;

	public byte element_5;

	public byte element_6;

	public byte element_7;

	public byte element_8;

	public byte element_9;

	public byte element_10;

	public byte element_11;

	public byte element_12;

	public byte element_13;

	public byte element_14;

	public byte element_15;

	public byte element_16;

	public byte element_17;

	public byte element_18;

	public byte element_19;
}

using System;

public struct Array_i8_21
{
	public byte element_0;

	public byte element_1;

	public byte element_2;

	public byte element_3;

	public byte element_4;

	public byte element_5;

	public byte element_6;

	public byte element_7;

	public byte element_8;

	public byte element_9;

	public byte element_10;

	public byte element_11;

	public byte element_12;

	public byte element_13;

	public byte element_14;

	public byte element_15;

	public byte element_16;

	public byte element_17;

	public byte element_18;

	public byte element_19;

	public byte element_20;
}

using System;

public struct Array_i8_3
{
	public byte element_0;

	public byte element_1;

	public byte element_2;
}

using System;

public struct Array_i8_31
{
	public byte element_0;

	public byte element_1;

	public byte element_2;

	public byte element_3;

	public byte element_4;

	public byte element_5;

	public byte element_6;

	public byte element_7;

	public byte element_8;

	public byte element_9;

	public byte element_10;

	public byte element_11;

	public byte element_12;

	public byte element_13;

	public byte element_14;

	public byte element_15;

	public byte element_16;

	public byte element_17;

	public byte element_18;

	public byte element_19;

	public byte element_20;

	public byte element_21;

	public byte element_22;

	public byte element_23;

	public byte element_24;

	public byte element_25;

	public byte element_26;

	public byte element_27;

	public byte element_28;

	public byte element_29;

	public byte element_30;
}

using System;

public struct Array_ptr_2
{
	public IntPtr element_0;

	public IntPtr element_1;
}

using System;

public struct Array_ptr_3
{
	public IntPtr element_0;

	public IntPtr element_1;

	public IntPtr element_2;
}

using System;

public struct Array_ptr_4
{
	public IntPtr element_0;

	public IntPtr element_1;

	public IntPtr element_2;

	public IntPtr element_3;
}

using System;
using System.Runtime.InteropServices;
using System.Text;

public class Main
{
	public unsafe static int main(int %0, IntPtr %1)
	{
		Struct_class_std__basic_string* ptr = stackalloc Struct_class_std__basic_string[sizeof(Struct_class_std__basic_string) * 1];
		Struct_class_std__basic_string* ptr2 = stackalloc Struct_class_std__basic_string[sizeof(Struct_class_std__basic_string) * 1];
		Struct_class_std__basic_string* ptr3 = stackalloc Struct_class_std__basic_string[sizeof(Struct_class_std__basic_string) * 1];
		IntPtr intPtr = *%1;
		int num = global::Main.atoi(intPtr);
		int num2 = global::Main.printf(global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_, __arglist());
		if (num >= 1)
		{
			Struct_class_std__basic_string* ptr4 = ptr2;
			Struct_class_std__basic_string* ptr5 = ptr;
			Struct_class_std__basic_string* ptr6 = ptr3;
			byte b = 1;
			for (;;)
			{
				int num3 = 1;
				int num4;
				if (b != 1)
				{
					num3 = num4;
					if (b != 25)
					{
						break;
					}
				}
				int num5 = num3;
				int num6 = 1;
				int num7;
				if (b != 1)
				{
					num6 = num7;
					if (b != 25)
					{
						goto Block_5;
					}
				}
				int num8 = num6;
				int num9 = 0;
				int num10;
				if (b != 1)
				{
					num9 = num10;
					if (b != 25)
					{
						goto Block_7;
					}
				}
				int num11 = num9;
				int num12;
				if (num5 != 1)
				{
					if (num5 != 2)
					{
						num12 = num8 + num11;
						global::Main.llvm_lifetime_start_p0(24L, ptr3);
						global::Main.??$_Integral_to_string@DH@std@@YA?AV?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@0@H@Z(ptr3, num12);
						int element_ = ((Struct_class_std___String_val*)ptr6)->element_2;
						bool flag = (UIntPtr)element_ > (UIntPtr)15;
						IntPtr intPtr2 = *(IntPtr*)ptr3;
						IntPtr intPtr3 = intPtr2;
						if (!flag)
						{
							intPtr3 = ptr3;
						}
						IntPtr intPtr4 = intPtr3;
						int num13 = global::Main.printf(intPtr4, __arglist());
						int element_2 = ((Struct_class_std___String_val*)ptr6)->element_2;
						if ((UIntPtr)element_2 > (UIntPtr)15)
						{
							IntPtr intPtr5 = *(IntPtr*)ptr3;
							int num14 = element_2 + 1;
							bool flag2 = (UIntPtr)num14 > (UIntPtr)4095;
							b = 19;
							int num19;
							IntPtr intPtr7;
							if (flag2)
							{
								IntPtr intPtr6 = intPtr5 + -1 * 4;
								int num15 = (int)(*intPtr6);
								int num16 = (int)intPtr5;
								int num17 = num16 + -4;
								int num18 = num17 - num15;
								if ((UIntPtr)num18 >= (UIntPtr)32)
								{
									goto Block_29;
								}
								num19 = element_2 + 36;
								intPtr7 = (IntPtr)num15;
								b = 22;
							}
							int num20 = num19;
							if (b != 22)
							{
								num20 = num14;
								if (b != 19)
								{
									goto Block_31;
								}
							}
							int num21 = num20;
							IntPtr intPtr8 = intPtr7;
							if (b != 22)
							{
								intPtr8 = intPtr5;
								if (b != 19)
								{
									goto Block_33;
								}
							}
							IntPtr intPtr9 = intPtr8;
							global::Main.DELETE(intPtr9, num21);
						}
						global::Main.llvm_lifetime_end_p0(24L, ptr3);
						b = 24;
					}
					else
					{
						global::Main.llvm_lifetime_start_p0(24L, ptr2);
						global::Main.??$_Integral_to_string@DH@std@@YA?AV?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@0@H@Z(ptr2, num8);
						int element_3 = ((Struct_class_std___String_val*)ptr4)->element_2;
						bool flag3 = (UIntPtr)element_3 > (UIntPtr)15;
						IntPtr intPtr10 = *(IntPtr*)ptr2;
						IntPtr intPtr11 = intPtr10;
						if (!flag3)
						{
							intPtr11 = ptr2;
						}
						IntPtr intPtr12 = intPtr11;
						int num22 = global::Main.printf(intPtr12, __arglist());
						int element_4 = ((Struct_class_std___String_val*)ptr4)->element_2;
						if ((UIntPtr)element_4 > (UIntPtr)15)
						{
							IntPtr intPtr13 = *(IntPtr*)ptr2;
							int num23 = element_4 + 1;
							bool flag4 = (UIntPtr)num23 > (UIntPtr)4095;
							b = 12;
							int num28;
							IntPtr intPtr15;
							if (flag4)
							{
								IntPtr intPtr14 = intPtr13 + -1 * 4;
								int num24 = (int)(*intPtr14);
								int num25 = (int)intPtr13;
								int num26 = num25 + -4;
								int num27 = num26 - num24;
								if ((UIntPtr)num27 >= (UIntPtr)32)
								{
									goto Block_21;
								}
								num28 = element_4 + 36;
								intPtr15 = (IntPtr)num24;
								b = 15;
							}
							int num29 = num28;
							if (b != 15)
							{
								num29 = num23;
								if (b != 12)
								{
									goto Block_23;
								}
							}
							int num30 = num29;
							IntPtr intPtr16 = intPtr15;
							if (b != 15)
							{
								intPtr16 = intPtr13;
								if (b != 12)
								{
									goto Block_25;
								}
							}
							IntPtr intPtr17 = intPtr16;
							global::Main.DELETE(intPtr17, num30);
						}
						global::Main.llvm_lifetime_end_p0(24L, ptr2);
						b = 17;
					}
				}
				else
				{
					global::Main.llvm_lifetime_start_p0(24L, ptr);
					global::Main.??$_Integral_to_string@DH@std@@YA?AV?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@0@H@Z(ptr, num11);
					int element_5 = ((Struct_class_std___String_val*)ptr5)->element_2;
					bool flag5 = (UIntPtr)element_5 > (UIntPtr)15;
					IntPtr intPtr18 = *(IntPtr*)ptr;
					IntPtr intPtr19 = intPtr18;
					if (!flag5)
					{
						intPtr19 = ptr;
					}
					IntPtr intPtr20 = intPtr19;
					int num31 = global::Main.printf(intPtr20, __arglist());
					int element_6 = ((Struct_class_std___String_val*)ptr5)->element_2;
					if ((UIntPtr)element_6 > (UIntPtr)15)
					{
						IntPtr intPtr21 = *(IntPtr*)ptr;
						int num32 = element_6 + 1;
						bool flag6 = (UIntPtr)num32 > (UIntPtr)4095;
						b = 5;
						int num37;
						IntPtr intPtr23;
						if (flag6)
						{
							IntPtr intPtr22 = intPtr21 + -1 * 4;
							int num33 = (int)(*intPtr22);
							int num34 = (int)intPtr21;
							int num35 = num34 + -4;
							int num36 = num35 - num33;
							if ((UIntPtr)num36 >= (UIntPtr)32)
							{
								goto Block_13;
							}
							num37 = element_6 + 36;
							intPtr23 = (IntPtr)num33;
							b = 8;
						}
						int num38 = num37;
						if (b != 8)
						{
							num38 = num32;
							if (b != 5)
							{
								goto Block_15;
							}
						}
						int num39 = num38;
						IntPtr intPtr24 = intPtr23;
						if (b != 8)
						{
							intPtr24 = intPtr21;
							if (b != 5)
							{
								goto Block_17;
							}
						}
						IntPtr intPtr25 = intPtr24;
						global::Main.DELETE(intPtr25, num39);
					}
					global::Main.llvm_lifetime_end_p0(24L, ptr);
					b = 10;
				}
				int num40 = num11;
				if (b != 10)
				{
					num40 = num11;
					if (b != 17)
					{
						num40 = num8;
						if (b != 24)
						{
							goto Block_36;
						}
					}
				}
				num10 = num40;
				int num41 = num8;
				if (b != 10)
				{
					num41 = num8;
					if (b != 17)
					{
						num41 = num12;
						if (b != 24)
						{
							goto Block_39;
						}
					}
				}
				num7 = num41;
				int num42 = global::Main.printf(global::Main.___C__02KEGNLNML__0_5__AA_, __arglist());
				num4 = num5 + 1;
				bool flag7 = num5 == num;
				b = 25;
				if (flag7)
				{
					return 0;
				}
			}
			throw new Exception("Bad Jump!");
			Block_5:
			throw new Exception("Bad Jump!");
			Block_7:
			throw new Exception("Bad Jump!");
			Block_13:
			global::Main._invalid_parameter_noinfo_noreturn();
			throw new Exception("unreachable!!!");
			Block_15:
			throw new Exception("Bad Jump!");
			Block_17:
			throw new Exception("Bad Jump!");
			Block_21:
			global::Main._invalid_parameter_noinfo_noreturn();
			throw new Exception("unreachable!!!");
			Block_23:
			throw new Exception("Bad Jump!");
			Block_25:
			throw new Exception("Bad Jump!");
			Block_29:
			global::Main._invalid_parameter_noinfo_noreturn();
			throw new Exception("unreachable!!!");
			Block_31:
			throw new Exception("Bad Jump!");
			Block_33:
			throw new Exception("Bad Jump!");
			Block_36:
			throw new Exception("Bad Jump!");
			Block_39:
			throw new Exception("Bad Jump!");
		}
		return 0;
	}

	public static void llvm_lifetime_start_p0(long %0, IntPtr %1)
	{
	}

	[DllImport("ucrtbase.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	public static extern int atoi(IntPtr %0);

	public unsafe static int printf(IntPtr %0, __arglist)
	{
		IntPtr* ptr = stackalloc IntPtr[8];
		global::Main.llvm_lifetime_start_p0(4L, ptr);
		IntPtr intPtr = __arglist;
		IntPtr intPtr2 = intPtr;
		IntPtr intPtr3 = global::Main.__acrt_iob_func(1);
		IntPtr intPtr4 = global::Main.__local_stdio_printf_options();
		long num = (long)(*intPtr4);
		int num2 = global::Main.__stdio_common_vfprintf(num, intPtr3, %0, 0, intPtr2);
		global::Main.llvm_va_end(ref intPtr);
		global::Main.llvm_lifetime_end_p0(4L, ref intPtr);
		return num2;
	}

	public static void llvm_lifetime_end_p0(long %0, IntPtr %1)
	{
	}

	public static void llvm_va_start(IntPtr %0)
	{
	}

	[DllImport("ucrtbase.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	public static extern IntPtr __acrt_iob_func(int %0);

	public static void llvm_va_end(IntPtr %0)
	{
	}

	[DllImport("ucrtbase.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	public static extern int __stdio_common_vfprintf(long %0, IntPtr %1, IntPtr %2, IntPtr %3, IntPtr %4);

	public static IntPtr __local_stdio_printf_options()
	{
		return global::Main.__OptionsStorage__1____local_stdio_printf_options__9_4_KA;
	}

	public unsafe static void ??$_Integral_to_string@DH@std@@YA?AV?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@0@H@Z(IntPtr %0, int %1)
	{
		Array_i8_21* ptr = stackalloc Array_i8_21[sizeof(Array_i8_21) * 1];
		global::Main.llvm_lifetime_start_p0(21L, ptr);
		bool flag = %1 < 0;
		byte b = 0;
		int num2;
		if (!flag)
		{
			for (;;)
			{
				int num = num2;
				if (b != 4)
				{
					num = 21;
					if (b != 0)
					{
						break;
					}
				}
				int num3 = num;
				int num5;
				int num4 = num5;
				if (b != 4)
				{
					num4 = %1;
					if (b != 0)
					{
						goto Block_10;
					}
				}
				int num6 = num4;
				int num7 = (int)((ulong)num6 % (ulong)10);
				byte b2 = (byte)((sbyte)num7);
				byte b3 = b2 | 48;
				num2 = num3 + -1;
				byte* ptr2 = (byte*)(ptr + num2 * 1 / sizeof(Array_i8_21));
				*ptr2 = b3;
				num5 = (int)((IntPtr)((UIntPtr)num6 / (UIntPtr)10));
				bool flag2 = (UIntPtr)num6 < (UIntPtr)10;
				b = 4;
				if (flag2)
				{
					goto IL_164;
				}
			}
			throw new Exception("Bad Jump!");
			Block_10:
			throw new Exception("Bad Jump!");
		}
		int num8 = 0 - %1;
		b = 1;
		int num11;
		for (;;)
		{
			int num9 = 21;
			int num10;
			if (b != 1)
			{
				num9 = num10;
				if (b != 2)
				{
					break;
				}
			}
			num11 = num9;
			int num12 = num8;
			int num13;
			if (b != 1)
			{
				num12 = num13;
				if (b != 2)
				{
					goto Block_5;
				}
			}
			int num14 = num12;
			int num15 = (int)((ulong)num14 % (ulong)10);
			byte b4 = (byte)((sbyte)num15);
			byte b5 = b4 | 48;
			num10 = num11 + -1;
			byte* ptr3 = (byte*)(ptr + num10 * 1 / sizeof(Array_i8_21));
			*ptr3 = b5;
			num13 = (int)((IntPtr)((UIntPtr)num14 / (UIntPtr)10));
			bool flag3 = (UIntPtr)num14 < (UIntPtr)10;
			b = 2;
			if (flag3)
			{
				goto IL_BE;
			}
		}
		throw new Exception("Bad Jump!");
		Block_5:
		throw new Exception("Bad Jump!");
		IL_BE:
		int num16 = num11 + -2;
		byte* ptr4 = (byte*)(ptr + num16 * 1 / sizeof(Array_i8_21));
		*ptr4 = 45;
		b = 3;
		IL_164:
		int num17 = num16;
		if (b != 3)
		{
			num17 = num2;
			if (b != 4)
			{
				throw new Exception("Bad Jump!");
			}
		}
		int num18 = num17;
		IntPtr intPtr = ptr + num18 * 1 / sizeof(Array_i8_21);
		global::Main.llvm_memset_p0_i64(%0, 0, 24L, false);
		if (num18 != 21)
		{
			int num19 = 21 - num18;
			if (num18 > 21)
			{
				global::Main.?_Xlen_string@std@@YAXXZ();
				throw new Exception("unreachable!!!");
			}
			if ((UIntPtr)num19 >= (UIntPtr)16)
			{
				int* ptr5 = (ref %0.element_0) + 2 * 20;
				int num20 = num19 | 15;
				int num21 = global::Main.llvm_umax_i32(num20, 22);
				IntPtr intPtr2;
				IntPtr intPtr4;
				if ((UIntPtr)num21 <= (UIntPtr)4094)
				{
					int num22 = num21 + 1;
					intPtr2 = global::Main.NEW(num22);
					b = 13;
				}
				else
				{
					int num23 = num21 + 36;
					IntPtr intPtr3 = global::Main.NEW(num23);
					int num24 = (int)intPtr3;
					int num25 = num24 + 35;
					int num26 = num25 | -32;
					intPtr4 = (IntPtr)num26;
					int* ptr6 = intPtr4 + -1 * 4;
					*ptr6 = num24;
					b = 12;
				}
				IntPtr intPtr5 = intPtr4;
				if (b != 12)
				{
					intPtr5 = intPtr2;
					if (b != 13)
					{
						throw new Exception("Bad Jump!");
					}
				}
				IntPtr intPtr6 = intPtr5;
				*%0 = intPtr6;
				%0.element_0.element_1 = num19;
				*ptr5 = num21;
				global::Main.llvm_memcpy_p0_p0_i32(intPtr6, intPtr, num19, false);
				byte* ptr7 = intPtr6 + (IntPtr)(num19 * 1);
				*ptr7 = 0;
			}
			else
			{
				%0.element_0.element_1 = num19;
				int* ptr8 = (ref %0.element_0) + 2 * 20;
				*ptr8 = 15;
				global::Main.llvm_memcpy_p0_p0_i32(%0, intPtr, num19, false);
			}
		}
		else
		{
			int* ptr9 = (ref %0.element_0) + 2 * 20;
			*ptr9 = 15;
		}
		global::Main.llvm_lifetime_end_p0(21L, ptr);
	}

	public static void ?_Xlen_string@std@@YAXXZ()
	{
		global::Main.?_Xlength_error@std@@YAXPBD@Z(global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_);
		throw new Exception("unreachable!!!");
	}

	public static void ?_Xlength_error@std@@YAXPBD@Z(IntPtr %0)
	{
	}

	[DllImport("ucrtbase.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	public static extern void _invalid_parameter_noinfo_noreturn();

	public unsafe static IntPtr ??_Gbad_array_new_length@std@@UAEPAXI@Z(IntPtr %0, int %1)
	{
		*%0 = global::Main.___7exception_std__6B_;
		IntPtr intPtr = (ref %0.element_0) + 1 * 8;
		global::Main.__std_exception_destroy(intPtr);
		if (%1 != 0)
		{
			global::Main.DELETE(%0);
		}
		return %0;
	}

	public unsafe static IntPtr ?what@exception@std@@UBEPBDXZ(IntPtr %0)
	{
		IntPtr intPtr = (ref %0.element_0) + 1 * 8;
		IntPtr intPtr2 = *intPtr;
		bool flag = intPtr2 == 0;
		IntPtr intPtr3 = global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_;
		if (!flag)
		{
			intPtr3 = intPtr2;
		}
		return intPtr3;
	}

	public unsafe static IntPtr ??_Gbad_alloc@std@@UAEPAXI@Z(IntPtr %0, int %1)
	{
		*%0 = global::Main.___7exception_std__6B_;
		IntPtr intPtr = (ref %0.element_0) + 1 * 8;
		global::Main.__std_exception_destroy(intPtr);
		if (%1 != 0)
		{
			global::Main.DELETE(%0);
		}
		return %0;
	}

	public unsafe static IntPtr ??_Gexception@std@@UAEPAXI@Z(IntPtr %0, int %1)
	{
		*%0 = global::Main.___7exception_std__6B_;
		IntPtr intPtr = (ref %0.element_0) + 1 * 8;
		global::Main.__std_exception_destroy(intPtr);
		if (%1 != 0)
		{
			global::Main.DELETE(%0);
		}
		return %0;
	}

	public static void DELETE(IntPtr %0)
	{
		NativeMemory.Free(%0);
	}

	[DllImport("ucrtbase.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	public static extern void __std_exception_destroy(IntPtr %0);

	public static IntPtr NEW(int %0)
	{
		return NativeMemory.Alloc((UIntPtr)((IntPtr)%0));
	}

	public unsafe static void llvm_memcpy_p0_p0_i32(IntPtr %0, IntPtr %1, int %2, bool %3)
	{
		byte* ptr = (byte*)%1.ToPointer();
		byte* ptr2 = (byte*)%0.ToPointer();
		while (%2 > 0)
		{
			*ptr2 = *ptr;
			ptr++;
			ptr2++;
			%2--;
		}
	}

	public static void DELETE(IntPtr %0, int %1)
	{
		NativeMemory.Free(%0);
	}

	public unsafe static void llvm_memset_p0_i64(IntPtr %0, byte %1, long %2, bool %3)
	{
		byte* ptr = (byte*)%0.ToPointer();
		while (%2 > 0L)
		{
			*ptr = %1;
			ptr++;
			%2 -= 1L;
		}
	}

	public static int llvm_umax_i32(int %0, int %1)
	{
		if (%0 <= %1)
		{
			return %1;
		}
		return %0;
	}

	public unsafe static void CreateVars()
	{
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_ = (Array_i8_19*)NativeMemory.Alloc((UIntPtr)sizeof(Array_i8_19));
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_0 = 70;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_1 = 105;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_2 = 98;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_3 = 111;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_4 = 110;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_5 = 97;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_6 = 99;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_7 = 99;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_8 = 105;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_9 = 32;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_10 = 83;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_11 = 101;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_12 = 114;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_13 = 105;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_14 = 101;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_15 = 115;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_16 = 58;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_17 = 32;
		global::Main.___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_->element_18 = 0;
		global::Main.___C__02KEGNLNML__0_5__AA_ = (Array_i8_3*)NativeMemory.Alloc((UIntPtr)sizeof(Array_i8_3));
		global::Main.___C__02KEGNLNML__0_5__AA_->element_0 = 44;
		global::Main.___C__02KEGNLNML__0_5__AA_->element_1 = 32;
		global::Main.___C__02KEGNLNML__0_5__AA_->element_2 = 0;
		global::Main.__OptionsStorage__1____local_stdio_printf_options__9_4_KA = (long*)NativeMemory.Alloc((UIntPtr)sizeof(long));
		*global::Main.__OptionsStorage__1____local_stdio_printf_options__9_4_KA = 0L;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_ = (Array_i8_16*)NativeMemory.Alloc((UIntPtr)sizeof(Array_i8_16));
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_0 = 115;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_1 = 116;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_2 = 114;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_3 = 105;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_4 = 110;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_5 = 103;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_6 = 32;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_7 = 116;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_8 = 111;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_9 = 111;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_10 = 32;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_11 = 108;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_12 = 111;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_13 = 110;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_14 = 103;
		global::Main.___C__0BA_JFNIOLAK_string_5too_5long__AA_->element_15 = 0;
		global::Main.___R0_AVbad_array_new_length_std___8 = (Struct_rtti_TypeDescriptor30*)NativeMemory.Alloc((UIntPtr)sizeof(Struct_rtti_TypeDescriptor30));
		global::Main.___R0_AVbad_array_new_length_std___8->element_0 = ref global::Main.??_7type_info@@6B@;
		global::Main.___R0_AVbad_array_new_length_std___8->element_1 = 0;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_0 = 46;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_1 = 63;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_2 = 65;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_3 = 86;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_4 = 98;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_5 = 97;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_6 = 100;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_7 = 95;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_8 = 97;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_9 = 114;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_10 = 114;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_11 = 97;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_12 = 121;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_13 = 95;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_14 = 110;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_15 = 101;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_16 = 119;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_17 = 95;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_18 = 108;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_19 = 101;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_20 = 110;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_21 = 103;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_22 = 116;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_23 = 104;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_24 = 64;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_25 = 115;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_26 = 116;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_27 = 100;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_28 = 64;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_29 = 64;
		((Array_i8_31*)global::Main.___R0_AVbad_array_new_length_std___8)->element_30 = 0;
		global::Main.___R0_AVbad_alloc_std___8 = (Struct_rtti_TypeDescriptor19*)NativeMemory.Alloc((UIntPtr)sizeof(Struct_rtti_TypeDescriptor19));
		global::Main.___R0_AVbad_alloc_std___8->element_0 = ref global::Main.??_7type_info@@6B@;
		global::Main.___R0_AVbad_alloc_std___8->element_1 = 0;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_0 = 46;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_1 = 63;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_2 = 65;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_3 = 86;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_4 = 98;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_5 = 97;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_6 = 100;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_7 = 95;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_8 = 97;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_9 = 108;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_10 = 108;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_11 = 111;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_12 = 99;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_13 = 64;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_14 = 115;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_15 = 116;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_16 = 100;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_17 = 64;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_18 = 64;
		((Array_i8_20*)global::Main.___R0_AVbad_alloc_std___8)->element_19 = 0;
		global::Main.___R0_AVexception_std___8 = (Struct_rtti_TypeDescriptor19*)NativeMemory.Alloc((UIntPtr)sizeof(Struct_rtti_TypeDescriptor19));
		global::Main.___R0_AVexception_std___8->element_0 = ref global::Main.??_7type_info@@6B@;
		global::Main.___R0_AVexception_std___8->element_1 = 0;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_0 = 46;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_1 = 63;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_2 = 65;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_3 = 86;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_4 = 101;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_5 = 120;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_6 = 99;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_7 = 101;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_8 = 112;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_9 = 116;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_10 = 105;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_11 = 111;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_12 = 110;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_13 = 64;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_14 = 115;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_15 = 116;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_16 = 100;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_17 = 64;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_18 = 64;
		((Array_i8_20*)global::Main.___R0_AVexception_std___8)->element_19 = 0;
		global::Main.___R4bad_array_new_length_std__6B_ = (Struct_rtti_CompleteObjectLocator*)NativeMemory.Alloc((UIntPtr)sizeof(Struct_rtti_CompleteObjectLocator));
		global::Main.___R4bad_array_new_length_std__6B_->element_0 = 0;
		global::Main.___R4bad_array_new_length_std__6B_->element_1 = 0;
		global::Main.___R4bad_array_new_length_std__6B_->element_2 = 0;
		global::Main.___R4bad_array_new_length_std__6B_->element_3 = ref global::Main.___R0_AVbad_array_new_length_std___8;
		global::Main.___R4bad_array_new_length_std__6B_->element_4 = ref global::Main.___R3bad_array_new_length_std__8;
		global::Main.___R3bad_array_new_length_std__8 = (Struct_rtti_ClassHierarchyDescriptor*)NativeMemory.Alloc((UIntPtr)sizeof(Struct_rtti_ClassHierarchyDescriptor));
		global::Main.___R3bad_array_new_length_std__8->element_0 = 0;
		global::Main.___R3bad_array_new_length_std__8->element_1 = 0;
		global::Main.___R3bad_array_new_length_std__8->element_2 = 3;
		global::Main.___R3bad_array_new_length_std__8->element_3 = ref global::Main.___R2bad_array_new_length_std__8;
		global::Main.___R2bad_array_new_length_std__8 = (Array_ptr_4*)NativeMemory.Alloc((UIntPtr)sizeof(Array_ptr_4));
		global::Main.___R2bad_array_new_length_std__8->element_0 = ref global::Main.___R1A__0A_EA_bad_array_new_length_std__8;
		global::Main.___R2bad_array_new_length_std__8->element_1 = ref global::Main.___R1A__0A_EA_bad_alloc_std__8;
		global::Main.___R2bad_array_new_length_std__8->element_2 = ref global::Main.___R1A__0A_EA_exception_std__8;
		global::Main.___R2bad_array_new_length_std__8->element_3 = 0;
		global::Main.___R1A__0A_EA_bad_array_new_length_std__8 = (Struct_rtti_BaseClassDescriptor*)NativeMemory.Alloc((UIntPtr)sizeof(Struct_rtti_BaseClassDescriptor));
		global::Main.___R1A__0A_EA_bad_array_new_length_std__8->element_0 = ref global::Main.___R0_AVbad_array_new_length_std___8;
		global::Main.___R1A__0A_EA_bad_array_new_length_std__8->element_1 = 2;
		global::Main.___R1A__0A_EA_bad_array_new_length_std__8->element_2 = 0;
		global::Main.___R1A__0A_EA_bad_array_new_length_std__8->element_3 = -1;
		global::Main.___R1A__0A_EA_bad_array_new_length_std__8->element_4 = 0;
		global::Main.___R1A__0A_EA_bad_array_new_length_std__8->element_5 = 64;
		global::Main.___R1A__0A_EA_bad_array_new_length_std__8->element_6 = ref global::Main.___R3bad_array_new_length_std__8;
		global::Main.___R1A__0A_EA_bad_alloc_std__8 = (Struct_rtti_BaseClassDescriptor*)NativeMemory.Alloc((UIntPtr)sizeof(Struct_rtti_BaseClassDescriptor));
		global::Main.___R1A__0A_EA_bad_alloc_std__8->element_0 = ref global::Main.___R0_AVbad_alloc_std___8;
		global::Main.___R1A__0A_EA_bad_alloc_std__8->element_1 = 1;
		global::Main.___R1A__0A_EA_bad_alloc_std__8->element_2 = 0;
		global::Main.___R1A__0A_EA_bad_alloc_std__8->element_3 = -1;
		global::Main.___R1A__0A_EA_bad_alloc_std__8->element_4 = 0;
		global::Main.___R1A__0A_EA_bad_alloc_std__8->element_5 = 64;
		global::Main.___R1A__0A_EA_bad_alloc_std__8->element_6 = ref global::Main.___R3bad_alloc_std__8;
		global::Main.___R3bad_alloc_std__8 = (Struct_rtti_ClassHierarchyDescriptor*)NativeMemory.Alloc((UIntPtr)sizeof(Struct_rtti_ClassHierarchyDescriptor));
		global::Main.___R3bad_alloc_std__8->element_0 = 0;
		global::Main.___R3bad_alloc_std__8->element_1 = 0;
		global::Main.___R3bad_alloc_std__8->element_2 = 2;
		global::Main.___R3bad_alloc_std__8->element_3 = ref global::Main.___R2bad_alloc_std__8;
		global::Main.___R2bad_alloc_std__8 = (Array_ptr_3*)NativeMemory.Alloc((UIntPtr)sizeof(Array_ptr_3));
		global::Main.___R2bad_alloc_std__8->element_0 = ref global::Main.___R1A__0A_EA_bad_alloc_std__8;
		global::Main.___R2bad_alloc_std__8->element_1 = ref global::Main.___R1A__0A_EA_exception_std__8;
		global::Main.___R2bad_alloc_std__8->element_2 = 0;
		global::Main.___R1A__0A_EA_exception_std__8 = (Struct_rtti_BaseClassDescriptor*)NativeMemory.Alloc((UIntPtr)sizeof(Struct_rtti_BaseClassDescriptor));
		global::Main.___R1A__0A_EA_exception_std__8->element_0 = ref global::Main.___R0_AVexception_std___8;
		global::Main.___R1A__0A_EA_exception_std__8->element_1 = 0;
		global::Main.___R1A__0A_EA_exception_std__8->element_2 = 0;
		global::Main.___R1A__0A_EA_exception_std__8->element_3 = -1;
		global::Main.___R1A__0A_EA_exception_std__8->element_4 = 0;
		global::Main.___R1A__0A_EA_exception_std__8->element_5 = 64;
		global::Main.___R1A__0A_EA_exception_std__8->element_6 = ref global::Main.___R3exception_std__8;
		global::Main.___R3exception_std__8 = (Struct_rtti_ClassHierarchyDescriptor*)NativeMemory.Alloc((UIntPtr)sizeof(Struct_rtti_ClassHierarchyDescriptor));
		global::Main.___R3exception_std__8->element_0 = 0;
		global::Main.___R3exception_std__8->element_1 = 0;
		global::Main.___R3exception_std__8->element_2 = 1;
		global::Main.___R3exception_std__8->element_3 = ref global::Main.___R2exception_std__8;
		global::Main.___R2exception_std__8 = (Array_ptr_2*)NativeMemory.Alloc((UIntPtr)sizeof(Array_ptr_2));
		global::Main.___R2exception_std__8->element_0 = ref global::Main.___R1A__0A_EA_exception_std__8;
		global::Main.___R2exception_std__8->element_1 = 0;
		global::Main.___R4bad_alloc_std__6B_ = (Struct_rtti_CompleteObjectLocator*)NativeMemory.Alloc((UIntPtr)sizeof(Struct_rtti_CompleteObjectLocator));
		global::Main.___R4bad_alloc_std__6B_->element_0 = 0;
		global::Main.___R4bad_alloc_std__6B_->element_1 = 0;
		global::Main.___R4bad_alloc_std__6B_->element_2 = 0;
		global::Main.___R4bad_alloc_std__6B_->element_3 = ref global::Main.___R0_AVbad_alloc_std___8;
		global::Main.___R4bad_alloc_std__6B_->element_4 = ref global::Main.___R3bad_alloc_std__8;
		global::Main.___R4exception_std__6B_ = (Struct_rtti_CompleteObjectLocator*)NativeMemory.Alloc((UIntPtr)sizeof(Struct_rtti_CompleteObjectLocator));
		global::Main.___R4exception_std__6B_->element_0 = 0;
		global::Main.___R4exception_std__6B_->element_1 = 0;
		global::Main.___R4exception_std__6B_->element_2 = 0;
		global::Main.___R4exception_std__6B_->element_3 = ref global::Main.___R0_AVexception_std___8;
		global::Main.___R4exception_std__6B_->element_4 = ref global::Main.___R3exception_std__8;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_ = (Array_i8_18*)NativeMemory.Alloc((UIntPtr)sizeof(Array_i8_18));
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_0 = 85;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_1 = 110;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_2 = 107;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_3 = 110;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_4 = 111;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_5 = 119;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_6 = 110;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_7 = 32;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_8 = 101;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_9 = 120;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_10 = 99;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_11 = 101;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_12 = 112;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_13 = 116;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_14 = 105;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_15 = 111;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_16 = 110;
		global::Main.___C__0BC_EOODALEL_Unknown_5exception__AA_->element_17 = 0;
	}

	public unsafe static int Main(string[] A_0)
	{
		global::Main.CreateVars();
		if (A_0.Length == 0)
		{
			return global::Main.main(0, (IntPtr)0);
		}
		byte** ptr;
		checked
		{
			ptr = stackalloc byte*[unchecked((UIntPtr)A_0.Length) * (UIntPtr)sizeof(byte*)];
		}
		for (int i = 0; i < A_0.Length; i++)
		{
			byte[] array;
			byte* ptr2;
			if ((array = Encoding.ASCII.GetBytes(A_0[i])) == null || array.Length == 0)
			{
				ptr2 = null;
			}
			else
			{
				ptr2 = &array[0];
			}
			*(IntPtr*)(ptr + (IntPtr)i * (IntPtr)sizeof(byte*) / (IntPtr)sizeof(byte*)) = ptr2;
			array = null;
		}
		return global::Main.main(A_0.Length, ptr);
	}

	public unsafe static Array_i8_19* ___C__0BD_NPMPEDPJ_Fibonacci_5Series_3_5__AA_;

	public unsafe static Array_i8_3* ___C__02KEGNLNML__0_5__AA_;

	public unsafe static long* __OptionsStorage__1____local_stdio_printf_options__9_4_KA;

	public unsafe static Array_i8_16* ___C__0BA_JFNIOLAK_string_5too_5long__AA_;

	[NonSerialized]
	public static IntPtr ??_7type_info@@6B@;

	public unsafe static Struct_rtti_TypeDescriptor30* ___R0_AVbad_array_new_length_std___8;

	public unsafe static Struct_rtti_TypeDescriptor19* ___R0_AVbad_alloc_std___8;

	public unsafe static Struct_rtti_TypeDescriptor19* ___R0_AVexception_std___8;

	public static UnknownStruct_0 unknown;

	public unsafe static Struct_rtti_CompleteObjectLocator* ___R4bad_array_new_length_std__6B_;

	public unsafe static Struct_rtti_ClassHierarchyDescriptor* ___R3bad_array_new_length_std__8;

	public unsafe static Array_ptr_4* ___R2bad_array_new_length_std__8;

	public unsafe static Struct_rtti_BaseClassDescriptor* ___R1A__0A_EA_bad_array_new_length_std__8;

	public unsafe static Struct_rtti_BaseClassDescriptor* ___R1A__0A_EA_bad_alloc_std__8;

	public unsafe static Struct_rtti_ClassHierarchyDescriptor* ___R3bad_alloc_std__8;

	public unsafe static Array_ptr_3* ___R2bad_alloc_std__8;

	public unsafe static Struct_rtti_BaseClassDescriptor* ___R1A__0A_EA_exception_std__8;

	public unsafe static Struct_rtti_ClassHierarchyDescriptor* ___R3exception_std__8;

	public unsafe static Array_ptr_2* ___R2exception_std__8;

	public static UnknownStruct_0 unknown;

	public unsafe static Struct_rtti_CompleteObjectLocator* ___R4bad_alloc_std__6B_;

	public static UnknownStruct_0 unknown;

	public unsafe static Struct_rtti_CompleteObjectLocator* ___R4exception_std__6B_;

	public unsafe static Array_i8_18* ___C__0BC_EOODALEL_Unknown_5exception__AA_;

	public static IntPtr ___7exception_std__6B_;
}

using System;

public struct Struct_class_std__basic_string
{
	public Struct_class_std___Compressed_pair element_0;
}

using System;

public struct Struct_class_std__exception
{
	public IntPtr element_0;

	public Struct_struct___std_exception_data element_1;
}

using System;

public struct Struct_class_std___Compressed_pair
{
	public Struct_class_std___String_val element_0;
}

using System;

public struct Struct_class_std___String_val
{
	public Struct_union_std___String_val<std___Simple_types<char>>___Bxty element_0;

	public int element_1;

	public int element_2;
}

using System;

public struct Struct_rtti_BaseClassDescriptor
{
	public IntPtr element_0;

	public int element_1;

	public int element_2;

	public int element_3;

	public int element_4;

	public int element_5;

	public IntPtr element_6;
}

using System;

public struct Struct_rtti_ClassHierarchyDescriptor
{
	public int element_0;

	public int element_1;

	public int element_2;

	public IntPtr element_3;
}

using System;

public struct Struct_rtti_CompleteObjectLocator
{
	public int element_0;

	public int element_1;

	public int element_2;

	public IntPtr element_3;

	public IntPtr element_4;
}

using System;

public struct Struct_rtti_TypeDescriptor19
{
	public IntPtr element_0;

	public IntPtr element_1;

	public Array_i8_20 element_2;
}

using System;

public struct Struct_rtti_TypeDescriptor30
{
	public IntPtr element_0;

	public IntPtr element_1;

	public Array_i8_31 element_2;
}

using System;

public struct Struct_struct___std_exception_data
{
	public IntPtr element_0;

	public byte element_1;
}

using System;

public struct Struct_union_std___String_val<std___Simple_types<char>>___Bxty
{
	public IntPtr element_0;

	public Array_i8_12 element_1;
}

using System;

public struct UnknownStruct_0
{
	public Array_ptr_3 element_0;
}
