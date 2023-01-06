using System;
using System.Runtime.InteropServices;

public class Main
{
	public static int main()
	{
		Main.CreateVars();
		int num = Main.puts(Main.___C__0N_GCDOMLDM_Hello_5World__CB__AA_);
		return 0;
	}

	[DllImport("ucrtbase.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	public static extern int puts(IntPtr %0);

	public unsafe static void CreateVars()
	{
		Main.___C__0N_GCDOMLDM_Hello_5World__CB__AA_ = (Array_i8_13*)NativeMemory.Alloc((UIntPtr)sizeof(Array_i8_13));
		Main.___C__0N_GCDOMLDM_Hello_5World__CB__AA_->element_0 = 72;
		Main.___C__0N_GCDOMLDM_Hello_5World__CB__AA_->element_1 = 101;
		Main.___C__0N_GCDOMLDM_Hello_5World__CB__AA_->element_2 = 108;
		Main.___C__0N_GCDOMLDM_Hello_5World__CB__AA_->element_3 = 108;
		Main.___C__0N_GCDOMLDM_Hello_5World__CB__AA_->element_4 = 111;
		Main.___C__0N_GCDOMLDM_Hello_5World__CB__AA_->element_5 = 32;
		Main.___C__0N_GCDOMLDM_Hello_5World__CB__AA_->element_6 = 87;
		Main.___C__0N_GCDOMLDM_Hello_5World__CB__AA_->element_7 = 111;
		Main.___C__0N_GCDOMLDM_Hello_5World__CB__AA_->element_8 = 114;
		Main.___C__0N_GCDOMLDM_Hello_5World__CB__AA_->element_9 = 108;
		Main.___C__0N_GCDOMLDM_Hello_5World__CB__AA_->element_10 = 100;
		Main.___C__0N_GCDOMLDM_Hello_5World__CB__AA_->element_11 = 33;
		Main.___C__0N_GCDOMLDM_Hello_5World__CB__AA_->element_12 = 0;
	}

	public unsafe static Array_i8_13* ___C__0N_GCDOMLDM_Hello_5World__CB__AA_;
}

using System;

public struct Array_i8_13
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
}
