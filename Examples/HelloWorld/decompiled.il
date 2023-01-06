.class public auto ansi Main
	extends [System.Private.CoreLib]System.Object
{
	// Fields
	.field public static valuetype Array_i8_13* ___C__0N_GCDOMLDM_Hello_5World__CB__AA_

	// Methods
	.method public hidebysig static 
		int32 main () cil managed 
	{
		.maxstack 1
		.entrypoint
		.locals init (
			[0] uint8,
			[1] int32
		)

		IL_0000: call      void Main::CreateVars()
		IL_0005: nop
		IL_0006: ldsfld    valuetype Array_i8_13* Main::___C__0N_GCDOMLDM_Hello_5World__CB__AA_
		IL_000B: call      int32 Main::puts(native int)
		IL_0010: stloc.1
		IL_0011: ldc.i4.0
		IL_0012: nop
		IL_0013: ret
	} // end of method Main::main

	.method public hidebysig static pinvokeimpl("ucrtbase.dll" lasterr cdecl) 
		int32 puts (
			native int '%0'
		) cil managed preservesig 
	{
	} // end of method Main::puts

	.method public hidebysig static 
		void CreateVars () cil managed 
	{
		.maxstack 2

		IL_0000: sizeof    Array_i8_13
		IL_0006: call      void* [System.Private.CoreLib]System.Runtime.InteropServices.NativeMemory::Alloc(native unsigned int)
		IL_000B: stsfld    valuetype Array_i8_13* Main::___C__0N_GCDOMLDM_Hello_5World__CB__AA_
		IL_0010: ldsfld    valuetype Array_i8_13* Main::___C__0N_GCDOMLDM_Hello_5World__CB__AA_
		IL_0015: ldc.i4    72
		IL_001A: stfld     uint8 Array_i8_13::element_0
		IL_001F: ldsfld    valuetype Array_i8_13* Main::___C__0N_GCDOMLDM_Hello_5World__CB__AA_
		IL_0024: ldc.i4    101
		IL_0029: stfld     uint8 Array_i8_13::element_1
		IL_002E: ldsfld    valuetype Array_i8_13* Main::___C__0N_GCDOMLDM_Hello_5World__CB__AA_
		IL_0033: ldc.i4    108
		IL_0038: stfld     uint8 Array_i8_13::element_2
		IL_003D: ldsfld    valuetype Array_i8_13* Main::___C__0N_GCDOMLDM_Hello_5World__CB__AA_
		IL_0042: ldc.i4    108
		IL_0047: stfld     uint8 Array_i8_13::element_3
		IL_004C: ldsfld    valuetype Array_i8_13* Main::___C__0N_GCDOMLDM_Hello_5World__CB__AA_
		IL_0051: ldc.i4    111
		IL_0056: stfld     uint8 Array_i8_13::element_4
		IL_005B: ldsfld    valuetype Array_i8_13* Main::___C__0N_GCDOMLDM_Hello_5World__CB__AA_
		IL_0060: ldc.i4    32
		IL_0065: stfld     uint8 Array_i8_13::element_5
		IL_006A: ldsfld    valuetype Array_i8_13* Main::___C__0N_GCDOMLDM_Hello_5World__CB__AA_
		IL_006F: ldc.i4    87
		IL_0074: stfld     uint8 Array_i8_13::element_6
		IL_0079: ldsfld    valuetype Array_i8_13* Main::___C__0N_GCDOMLDM_Hello_5World__CB__AA_
		IL_007E: ldc.i4    111
		IL_0083: stfld     uint8 Array_i8_13::element_7
		IL_0088: ldsfld    valuetype Array_i8_13* Main::___C__0N_GCDOMLDM_Hello_5World__CB__AA_
		IL_008D: ldc.i4    114
		IL_0092: stfld     uint8 Array_i8_13::element_8
		IL_0097: ldsfld    valuetype Array_i8_13* Main::___C__0N_GCDOMLDM_Hello_5World__CB__AA_
		IL_009C: ldc.i4    108
		IL_00A1: stfld     uint8 Array_i8_13::element_9
		IL_00A6: ldsfld    valuetype Array_i8_13* Main::___C__0N_GCDOMLDM_Hello_5World__CB__AA_
		IL_00AB: ldc.i4    100
		IL_00B0: stfld     uint8 Array_i8_13::element_10
		IL_00B5: ldsfld    valuetype Array_i8_13* Main::___C__0N_GCDOMLDM_Hello_5World__CB__AA_
		IL_00BA: ldc.i4    33
		IL_00BF: stfld     uint8 Array_i8_13::element_11
		IL_00C4: ldsfld    valuetype Array_i8_13* Main::___C__0N_GCDOMLDM_Hello_5World__CB__AA_
		IL_00C9: ldc.i4    0
		IL_00CE: stfld     uint8 Array_i8_13::element_12
		IL_00D3: ret
	} // end of method Main::CreateVars

} // end of class Main

.class public sequential ansi Array_i8_13
	extends [System.Private.CoreLib]System.ValueType
{
	// Fields
	.field public uint8 element_0
	.field public uint8 element_1
	.field public uint8 element_2
	.field public uint8 element_3
	.field public uint8 element_4
	.field public uint8 element_5
	.field public uint8 element_6
	.field public uint8 element_7
	.field public uint8 element_8
	.field public uint8 element_9
	.field public uint8 element_10
	.field public uint8 element_11
	.field public uint8 element_12

} // end of class Array_i8_13
