; ModuleID = 'code.cpp'
source_filename = "code.cpp"
target datalayout = "e-m:x-p:32:32-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32-a:0:32-S32"
target triple = "i686-pc-windows-msvc19.34.31937"

%rtti.TypeDescriptor30 = type { ptr, ptr, [31 x i8] }
%rtti.TypeDescriptor19 = type { ptr, ptr, [20 x i8] }
%rtti.CompleteObjectLocator = type { i32, i32, i32, ptr, ptr }
%rtti.ClassHierarchyDescriptor = type { i32, i32, i32, ptr }
%rtti.BaseClassDescriptor = type { ptr, i32, i32, i32, i32, i32, ptr }
%"class.std::basic_string" = type { %"class.std::_Compressed_pair" }
%"class.std::_Compressed_pair" = type { %"class.std::_String_val" }
%"class.std::_String_val" = type { %"union.std::_String_val<std::_Simple_types<char>>::_Bxty", i32, i32 }
%"union.std::_String_val<std::_Simple_types<char>>::_Bxty" = type { ptr, [12 x i8] }
%"class.std::exception" = type { ptr, %struct.__std_exception_data }
%struct.__std_exception_data = type { ptr, i8 }

$printf = comdat any

$__local_stdio_printf_options = comdat any

$"??$_Integral_to_string@DH@std@@YA?AV?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@0@H@Z" = comdat any

$"?_Xlen_string@std@@YAXXZ" = comdat any

$"??_Gbad_array_new_length@std@@UAEPAXI@Z" = comdat any

$"?what@exception@std@@UBEPBDXZ" = comdat any

$"??_Gbad_alloc@std@@UAEPAXI@Z" = comdat any

$"??_Gexception@std@@UAEPAXI@Z" = comdat any

$"??_C@_0BD@NPMPEDPJ@Fibonacci?5Series?3?5?$AA@" = comdat any

$"??_C@_02KEGNLNML@?0?5?$AA@" = comdat any

$"?_OptionsStorage@?1??__local_stdio_printf_options@@9@4_KA" = comdat any

$"??_C@_0BA@JFNIOLAK@string?5too?5long?$AA@" = comdat any

$"??_R0?AVbad_array_new_length@std@@@8" = comdat any

$"??_R0?AVbad_alloc@std@@@8" = comdat any

$"??_R0?AVexception@std@@@8" = comdat any

$"??_7bad_array_new_length@std@@6B@" = comdat largest

$"??_R4bad_array_new_length@std@@6B@" = comdat any

$"??_R3bad_array_new_length@std@@8" = comdat any

$"??_R2bad_array_new_length@std@@8" = comdat any

$"??_R1A@?0A@EA@bad_array_new_length@std@@8" = comdat any

$"??_R1A@?0A@EA@bad_alloc@std@@8" = comdat any

$"??_R3bad_alloc@std@@8" = comdat any

$"??_R2bad_alloc@std@@8" = comdat any

$"??_R1A@?0A@EA@exception@std@@8" = comdat any

$"??_R3exception@std@@8" = comdat any

$"??_R2exception@std@@8" = comdat any

$"??_7bad_alloc@std@@6B@" = comdat largest

$"??_R4bad_alloc@std@@6B@" = comdat any

$"??_7exception@std@@6B@" = comdat largest

$"??_R4exception@std@@6B@" = comdat any

$"??_C@_0BC@EOODALEL@Unknown?5exception?$AA@" = comdat any

@"??_C@_0BD@NPMPEDPJ@Fibonacci?5Series?3?5?$AA@" = linkonce_odr dso_local unnamed_addr constant [19 x i8] c"Fibonacci Series: \00", comdat, align 1
@"??_C@_02KEGNLNML@?0?5?$AA@" = linkonce_odr dso_local unnamed_addr constant [3 x i8] c", \00", comdat, align 1
@"?_OptionsStorage@?1??__local_stdio_printf_options@@9@4_KA" = linkonce_odr dso_local global i64 0, comdat, align 8
@"??_C@_0BA@JFNIOLAK@string?5too?5long?$AA@" = linkonce_odr dso_local unnamed_addr constant [16 x i8] c"string too long\00", comdat, align 1
@"??_7type_info@@6B@" = external constant ptr
@"??_R0?AVbad_array_new_length@std@@@8" = linkonce_odr global %rtti.TypeDescriptor30 { ptr @"??_7type_info@@6B@", ptr null, [31 x i8] c".?AVbad_array_new_length@std@@\00" }, comdat
@"??_R0?AVbad_alloc@std@@@8" = linkonce_odr global %rtti.TypeDescriptor19 { ptr @"??_7type_info@@6B@", ptr null, [20 x i8] c".?AVbad_alloc@std@@\00" }, comdat
@"??_R0?AVexception@std@@@8" = linkonce_odr global %rtti.TypeDescriptor19 { ptr @"??_7type_info@@6B@", ptr null, [20 x i8] c".?AVexception@std@@\00" }, comdat
@0 = private unnamed_addr constant { [3 x ptr] } { [3 x ptr] [ptr @"??_R4bad_array_new_length@std@@6B@", ptr @"??_Gbad_array_new_length@std@@UAEPAXI@Z", ptr @"?what@exception@std@@UBEPBDXZ"] }, comdat($"??_7bad_array_new_length@std@@6B@")
@"??_R4bad_array_new_length@std@@6B@" = linkonce_odr constant %rtti.CompleteObjectLocator { i32 0, i32 0, i32 0, ptr @"??_R0?AVbad_array_new_length@std@@@8", ptr @"??_R3bad_array_new_length@std@@8" }, comdat
@"??_R3bad_array_new_length@std@@8" = linkonce_odr constant %rtti.ClassHierarchyDescriptor { i32 0, i32 0, i32 3, ptr @"??_R2bad_array_new_length@std@@8" }, comdat
@"??_R2bad_array_new_length@std@@8" = linkonce_odr constant [4 x ptr] [ptr @"??_R1A@?0A@EA@bad_array_new_length@std@@8", ptr @"??_R1A@?0A@EA@bad_alloc@std@@8", ptr @"??_R1A@?0A@EA@exception@std@@8", ptr null], comdat
@"??_R1A@?0A@EA@bad_array_new_length@std@@8" = linkonce_odr constant %rtti.BaseClassDescriptor { ptr @"??_R0?AVbad_array_new_length@std@@@8", i32 2, i32 0, i32 -1, i32 0, i32 64, ptr @"??_R3bad_array_new_length@std@@8" }, comdat
@"??_R1A@?0A@EA@bad_alloc@std@@8" = linkonce_odr constant %rtti.BaseClassDescriptor { ptr @"??_R0?AVbad_alloc@std@@@8", i32 1, i32 0, i32 -1, i32 0, i32 64, ptr @"??_R3bad_alloc@std@@8" }, comdat
@"??_R3bad_alloc@std@@8" = linkonce_odr constant %rtti.ClassHierarchyDescriptor { i32 0, i32 0, i32 2, ptr @"??_R2bad_alloc@std@@8" }, comdat
@"??_R2bad_alloc@std@@8" = linkonce_odr constant [3 x ptr] [ptr @"??_R1A@?0A@EA@bad_alloc@std@@8", ptr @"??_R1A@?0A@EA@exception@std@@8", ptr null], comdat
@"??_R1A@?0A@EA@exception@std@@8" = linkonce_odr constant %rtti.BaseClassDescriptor { ptr @"??_R0?AVexception@std@@@8", i32 0, i32 0, i32 -1, i32 0, i32 64, ptr @"??_R3exception@std@@8" }, comdat
@"??_R3exception@std@@8" = linkonce_odr constant %rtti.ClassHierarchyDescriptor { i32 0, i32 0, i32 1, ptr @"??_R2exception@std@@8" }, comdat
@"??_R2exception@std@@8" = linkonce_odr constant [2 x ptr] [ptr @"??_R1A@?0A@EA@exception@std@@8", ptr null], comdat
@1 = private unnamed_addr constant { [3 x ptr] } { [3 x ptr] [ptr @"??_R4bad_alloc@std@@6B@", ptr @"??_Gbad_alloc@std@@UAEPAXI@Z", ptr @"?what@exception@std@@UBEPBDXZ"] }, comdat($"??_7bad_alloc@std@@6B@")
@"??_R4bad_alloc@std@@6B@" = linkonce_odr constant %rtti.CompleteObjectLocator { i32 0, i32 0, i32 0, ptr @"??_R0?AVbad_alloc@std@@@8", ptr @"??_R3bad_alloc@std@@8" }, comdat
@2 = private unnamed_addr constant { [3 x ptr] } { [3 x ptr] [ptr @"??_R4exception@std@@6B@", ptr @"??_Gexception@std@@UAEPAXI@Z", ptr @"?what@exception@std@@UBEPBDXZ"] }, comdat($"??_7exception@std@@6B@")
@"??_R4exception@std@@6B@" = linkonce_odr constant %rtti.CompleteObjectLocator { i32 0, i32 0, i32 0, ptr @"??_R0?AVexception@std@@@8", ptr @"??_R3exception@std@@8" }, comdat
@"??_C@_0BC@EOODALEL@Unknown?5exception?$AA@" = linkonce_odr dso_local unnamed_addr constant [18 x i8] c"Unknown exception\00", comdat, align 1

@"??_7bad_array_new_length@std@@6B@" = unnamed_addr alias ptr, getelementptr inbounds ({ [3 x ptr] }, ptr @0, i32 0, i32 0, i32 1)
@"??_7bad_alloc@std@@6B@" = unnamed_addr alias ptr, getelementptr inbounds ({ [3 x ptr] }, ptr @1, i32 0, i32 0, i32 1)
@"??_7exception@std@@6B@" = unnamed_addr alias ptr, getelementptr inbounds ({ [3 x ptr] }, ptr @2, i32 0, i32 0, i32 1)

; Function Attrs: norecurse nounwind
define dso_local noundef i32 @main(i32 noundef %0, ptr nocapture noundef readonly %1) local_unnamed_addr #0 {
  %3 = alloca %"class.std::basic_string", align 4
  %4 = alloca %"class.std::basic_string", align 4
  %5 = alloca %"class.std::basic_string", align 4
  %6 = load ptr, ptr %1, align 4, !tbaa !9
  %7 = tail call i32 @atoi(ptr nocapture noundef %6)
  %8 = tail call i32 (ptr, ...) @printf(ptr noundef nonnull @"??_C@_0BD@NPMPEDPJ@Fibonacci?5Series?3?5?$AA@")
  %9 = icmp slt i32 %7, 1
  br i1 %9, label %14, label %10

10:                                               ; preds = %2
  %11 = getelementptr inbounds %"class.std::_String_val", ptr %4, i32 0, i32 2
  %12 = getelementptr inbounds %"class.std::_String_val", ptr %3, i32 0, i32 2
  %13 = getelementptr inbounds %"class.std::_String_val", ptr %5, i32 0, i32 2
  br label %15

14:                                               ; preds = %101, %2
  ret i32 0

15:                                               ; preds = %10, %101
  %16 = phi i32 [ 1, %10 ], [ %105, %101 ]
  %17 = phi i32 [ 1, %10 ], [ %103, %101 ]
  %18 = phi i32 [ 0, %10 ], [ %102, %101 ]
  switch i32 %16, label %73 [
    i32 1, label %19
    i32 2, label %46
  ]

19:                                               ; preds = %15
  call void @llvm.lifetime.start.p0(i64 24, ptr nonnull %3) #18
  call void @"??$_Integral_to_string@DH@std@@YA?AV?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@0@H@Z"(ptr nonnull sret(%"class.std::basic_string") align 4 %3, i32 noundef %18)
  %20 = load i32, ptr %12, align 4, !tbaa !13
  %21 = icmp ugt i32 %20, 15
  %22 = load ptr, ptr %3, align 4
  %23 = select i1 %21, ptr %22, ptr %3
  %24 = call i32 (ptr, ...) @printf(ptr noundef nonnull dereferenceable(1) %23)
  %25 = load i32, ptr %12, align 4, !tbaa !13
  %26 = icmp ugt i32 %25, 15
  br i1 %26, label %27, label %45

27:                                               ; preds = %19
  %28 = load ptr, ptr %3, align 4, !tbaa !16
  %29 = add i32 %25, 1
  %30 = icmp ugt i32 %29, 4095
  br i1 %30, label %31, label %42

31:                                               ; preds = %27
  %32 = getelementptr inbounds i32, ptr %28, i32 -1
  %33 = load i32, ptr %32, align 4, !tbaa !17
  %34 = ptrtoint ptr %28 to i32
  %35 = add i32 %34, -4
  %36 = sub i32 %35, %33
  %37 = icmp ult i32 %36, 32
  br i1 %37, label %39, label %38

38:                                               ; preds = %31
  call void @_invalid_parameter_noinfo_noreturn() #19
  unreachable

39:                                               ; preds = %31
  %40 = add i32 %25, 36
  %41 = inttoptr i32 %33 to ptr
  br label %42

42:                                               ; preds = %39, %27
  %43 = phi i32 [ %40, %39 ], [ %29, %27 ]
  %44 = phi ptr [ %41, %39 ], [ %28, %27 ]
  call void @"??3@YAXPAXI@Z"(ptr noundef %44, i32 noundef %43) #18
  br label %45

45:                                               ; preds = %19, %42
  call void @llvm.lifetime.end.p0(i64 24, ptr nonnull %3) #18
  br label %101

46:                                               ; preds = %15
  call void @llvm.lifetime.start.p0(i64 24, ptr nonnull %4) #18
  call void @"??$_Integral_to_string@DH@std@@YA?AV?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@0@H@Z"(ptr nonnull sret(%"class.std::basic_string") align 4 %4, i32 noundef %17)
  %47 = load i32, ptr %11, align 4, !tbaa !13
  %48 = icmp ugt i32 %47, 15
  %49 = load ptr, ptr %4, align 4
  %50 = select i1 %48, ptr %49, ptr %4
  %51 = call i32 (ptr, ...) @printf(ptr noundef nonnull dereferenceable(1) %50)
  %52 = load i32, ptr %11, align 4, !tbaa !13
  %53 = icmp ugt i32 %52, 15
  br i1 %53, label %54, label %72

54:                                               ; preds = %46
  %55 = load ptr, ptr %4, align 4, !tbaa !16
  %56 = add i32 %52, 1
  %57 = icmp ugt i32 %56, 4095
  br i1 %57, label %58, label %69

58:                                               ; preds = %54
  %59 = getelementptr inbounds i32, ptr %55, i32 -1
  %60 = load i32, ptr %59, align 4, !tbaa !17
  %61 = ptrtoint ptr %55 to i32
  %62 = add i32 %61, -4
  %63 = sub i32 %62, %60
  %64 = icmp ult i32 %63, 32
  br i1 %64, label %66, label %65

65:                                               ; preds = %58
  call void @_invalid_parameter_noinfo_noreturn() #19
  unreachable

66:                                               ; preds = %58
  %67 = add i32 %52, 36
  %68 = inttoptr i32 %60 to ptr
  br label %69

69:                                               ; preds = %66, %54
  %70 = phi i32 [ %67, %66 ], [ %56, %54 ]
  %71 = phi ptr [ %68, %66 ], [ %55, %54 ]
  call void @"??3@YAXPAXI@Z"(ptr noundef %71, i32 noundef %70) #18
  br label %72

72:                                               ; preds = %46, %69
  call void @llvm.lifetime.end.p0(i64 24, ptr nonnull %4) #18
  br label %101

73:                                               ; preds = %15
  %74 = add nsw i32 %17, %18
  call void @llvm.lifetime.start.p0(i64 24, ptr nonnull %5) #18
  call void @"??$_Integral_to_string@DH@std@@YA?AV?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@0@H@Z"(ptr nonnull sret(%"class.std::basic_string") align 4 %5, i32 noundef %74)
  %75 = load i32, ptr %13, align 4, !tbaa !13
  %76 = icmp ugt i32 %75, 15
  %77 = load ptr, ptr %5, align 4
  %78 = select i1 %76, ptr %77, ptr %5
  %79 = call i32 (ptr, ...) @printf(ptr noundef nonnull dereferenceable(1) %78)
  %80 = load i32, ptr %13, align 4, !tbaa !13
  %81 = icmp ugt i32 %80, 15
  br i1 %81, label %82, label %100

82:                                               ; preds = %73
  %83 = load ptr, ptr %5, align 4, !tbaa !16
  %84 = add i32 %80, 1
  %85 = icmp ugt i32 %84, 4095
  br i1 %85, label %86, label %97

86:                                               ; preds = %82
  %87 = getelementptr inbounds i32, ptr %83, i32 -1
  %88 = load i32, ptr %87, align 4, !tbaa !17
  %89 = ptrtoint ptr %83 to i32
  %90 = add i32 %89, -4
  %91 = sub i32 %90, %88
  %92 = icmp ult i32 %91, 32
  br i1 %92, label %94, label %93

93:                                               ; preds = %86
  call void @_invalid_parameter_noinfo_noreturn() #19
  unreachable

94:                                               ; preds = %86
  %95 = add i32 %80, 36
  %96 = inttoptr i32 %88 to ptr
  br label %97

97:                                               ; preds = %94, %82
  %98 = phi i32 [ %95, %94 ], [ %84, %82 ]
  %99 = phi ptr [ %96, %94 ], [ %83, %82 ]
  call void @"??3@YAXPAXI@Z"(ptr noundef %99, i32 noundef %98) #18
  br label %100

100:                                              ; preds = %73, %97
  call void @llvm.lifetime.end.p0(i64 24, ptr nonnull %5) #18
  br label %101

101:                                              ; preds = %100, %72, %45
  %102 = phi i32 [ %18, %45 ], [ %18, %72 ], [ %17, %100 ]
  %103 = phi i32 [ %17, %45 ], [ %17, %72 ], [ %74, %100 ]
  %104 = call i32 (ptr, ...) @printf(ptr noundef nonnull @"??_C@_02KEGNLNML@?0?5?$AA@")
  %105 = add nuw i32 %16, 1
  %106 = icmp eq i32 %16, %7
  br i1 %106, label %14, label %15, !llvm.loop !18
}

; Function Attrs: argmemonly mustprogress nocallback nofree nosync nounwind willreturn
declare void @llvm.lifetime.start.p0(i64 immarg, ptr nocapture) #1

; Function Attrs: mustprogress nofree nounwind readonly willreturn
declare dso_local i32 @atoi(ptr nocapture noundef) local_unnamed_addr #2

; Function Attrs: inlinehint mustprogress nounwind
define linkonce_odr dso_local i32 @printf(ptr noundef %0, ...) local_unnamed_addr #3 comdat {
  %2 = alloca ptr, align 4
  call void @llvm.lifetime.start.p0(i64 4, ptr nonnull %2) #18
  call void @llvm.va_start(ptr nonnull %2)
  %3 = load ptr, ptr %2, align 4, !tbaa !9
  %4 = call ptr @__acrt_iob_func(i32 noundef 1) #18
  %5 = call ptr @__local_stdio_printf_options()
  %6 = load i64, ptr %5, align 8, !tbaa !20
  %7 = call i32 @__stdio_common_vfprintf(i64 noundef %6, ptr noundef %4, ptr noundef %0, ptr noundef null, ptr noundef %3) #18
  call void @llvm.va_end(ptr nonnull %2)
  call void @llvm.lifetime.end.p0(i64 4, ptr nonnull %2) #18
  ret i32 %7
}

; Function Attrs: argmemonly mustprogress nocallback nofree nosync nounwind willreturn
declare void @llvm.lifetime.end.p0(i64 immarg, ptr nocapture) #1

; Function Attrs: mustprogress nocallback nofree nosync nounwind willreturn
declare void @llvm.va_start(ptr) #4

declare dso_local ptr @__acrt_iob_func(i32 noundef) local_unnamed_addr #5

; Function Attrs: mustprogress nocallback nofree nosync nounwind willreturn
declare void @llvm.va_end(ptr) #4

declare dso_local i32 @__stdio_common_vfprintf(i64 noundef, ptr noundef, ptr noundef, ptr noundef, ptr noundef) local_unnamed_addr #5

; Function Attrs: mustprogress noinline nounwind
define linkonce_odr dso_local ptr @__local_stdio_printf_options() local_unnamed_addr #6 comdat {
  ret ptr @"?_OptionsStorage@?1??__local_stdio_printf_options@@9@4_KA"
}

; Function Attrs: nounwind
define linkonce_odr dso_local void @"??$_Integral_to_string@DH@std@@YA?AV?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@0@H@Z"(ptr noalias sret(%"class.std::basic_string") align 4 %0, i32 noundef %1) local_unnamed_addr #7 comdat {
  %3 = alloca [21 x i8], align 1
  call void @llvm.lifetime.start.p0(i64 21, ptr nonnull %3) #18
  %4 = icmp slt i32 %1, 0
  br i1 %4, label %5, label %20

5:                                                ; preds = %2
  %6 = sub i32 0, %1
  br label %7

7:                                                ; preds = %7, %5
  %8 = phi i32 [ 21, %5 ], [ %13, %7 ]
  %9 = phi i32 [ %6, %5 ], [ %15, %7 ]
  %10 = urem i32 %9, 10
  %11 = trunc i32 %10 to i8
  %12 = or i8 %11, 48
  %13 = add nsw i32 %8, -1
  %14 = getelementptr inbounds i8, ptr %3, i32 %13
  store i8 %12, ptr %14, align 1, !tbaa !16
  %15 = udiv i32 %9, 10
  %16 = icmp ult i32 %9, 10
  br i1 %16, label %17, label %7, !llvm.loop !22

17:                                               ; preds = %7
  %18 = add nsw i32 %8, -2
  %19 = getelementptr inbounds i8, ptr %3, i32 %18
  store i8 45, ptr %19, align 1, !tbaa !16
  br label %30

20:                                               ; preds = %2, %20
  %21 = phi i32 [ %26, %20 ], [ 21, %2 ]
  %22 = phi i32 [ %28, %20 ], [ %1, %2 ]
  %23 = urem i32 %22, 10
  %24 = trunc i32 %23 to i8
  %25 = or i8 %24, 48
  %26 = add nsw i32 %21, -1
  %27 = getelementptr inbounds i8, ptr %3, i32 %26
  store i8 %25, ptr %27, align 1, !tbaa !16
  %28 = udiv i32 %22, 10
  %29 = icmp ult i32 %22, 10
  br i1 %29, label %30, label %20, !llvm.loop !22

30:                                               ; preds = %20, %17
  %31 = phi i32 [ %18, %17 ], [ %26, %20 ]
  %32 = getelementptr inbounds i8, ptr %3, i32 %31
  tail call void @llvm.memset.p0.i64(ptr noundef nonnull align 4 dereferenceable(24) %0, i8 0, i64 24, i1 false)
  %33 = icmp eq i32 %31, 21
  br i1 %33, label %34, label %36

34:                                               ; preds = %30
  %35 = getelementptr inbounds %"class.std::_String_val", ptr %0, i32 0, i32 2
  store i32 15, ptr %35, align 4, !tbaa !13
  br label %65

36:                                               ; preds = %30
  %37 = sub nsw i32 21, %31
  %38 = icmp sgt i32 %31, 21
  br i1 %38, label %39, label %40

39:                                               ; preds = %36
  tail call void @"?_Xlen_string@std@@YAXXZ"() #20
  unreachable

40:                                               ; preds = %36
  %41 = icmp ult i32 %37, 16
  br i1 %41, label %42, label %45

42:                                               ; preds = %40
  %43 = getelementptr inbounds %"class.std::_String_val", ptr %0, i32 0, i32 1
  store i32 %37, ptr %43, align 4, !tbaa !23
  %44 = getelementptr inbounds %"class.std::_String_val", ptr %0, i32 0, i32 2
  store i32 15, ptr %44, align 4, !tbaa !13
  call void @llvm.memcpy.p0.p0.i32(ptr nonnull align 4 %0, ptr nonnull align 1 %32, i32 %37, i1 false)
  br label %65

45:                                               ; preds = %40
  %46 = getelementptr inbounds %"class.std::_String_val", ptr %0, i32 0, i32 2
  %47 = or i32 %37, 15
  %48 = tail call i32 @llvm.umax.i32(i32 %47, i32 22)
  %49 = icmp ugt i32 %48, 4094
  br i1 %49, label %50, label %58

50:                                               ; preds = %45
  %51 = add nuw i32 %48, 36
  %52 = tail call noalias noundef nonnull ptr @"??2@YAPAXI@Z"(i32 noundef %51) #21
  %53 = ptrtoint ptr %52 to i32
  %54 = add i32 %53, 35
  %55 = and i32 %54, -32
  %56 = inttoptr i32 %55 to ptr
  %57 = getelementptr inbounds i32, ptr %56, i32 -1
  store i32 %53, ptr %57, align 4, !tbaa !17
  br label %61

58:                                               ; preds = %45
  %59 = add nuw nsw i32 %48, 1
  %60 = tail call noalias noundef nonnull ptr @"??2@YAPAXI@Z"(i32 noundef %59) #21
  br label %61

61:                                               ; preds = %58, %50
  %62 = phi ptr [ %56, %50 ], [ %60, %58 ]
  store ptr %62, ptr %0, align 4, !tbaa !9
  %63 = getelementptr inbounds %"class.std::_String_val", ptr %0, i32 0, i32 1
  store i32 %37, ptr %63, align 4, !tbaa !23
  store i32 %48, ptr %46, align 4, !tbaa !13
  call void @llvm.memcpy.p0.p0.i32(ptr nonnull align 1 %62, ptr nonnull align 1 %32, i32 %37, i1 false)
  %64 = getelementptr inbounds i8, ptr %62, i32 %37
  store i8 0, ptr %64, align 1, !tbaa !16
  br label %65

65:                                               ; preds = %34, %42, %61
  call void @llvm.lifetime.end.p0(i64 21, ptr nonnull %3) #18
  ret void
}

; Function Attrs: inlinehint mustprogress noreturn nounwind
define linkonce_odr dso_local void @"?_Xlen_string@std@@YAXXZ"() local_unnamed_addr #8 comdat {
  tail call void @"?_Xlength_error@std@@YAXPBD@Z"(ptr noundef nonnull @"??_C@_0BA@JFNIOLAK@string?5too?5long?$AA@") #19
  unreachable
}

; Function Attrs: noreturn
declare dso_local void @"?_Xlength_error@std@@YAXPBD@Z"(ptr noundef) local_unnamed_addr #9

; Function Attrs: noreturn
declare dso_local void @_invalid_parameter_noinfo_noreturn() local_unnamed_addr #9

; Function Attrs: inlinehint nounwind
define linkonce_odr dso_local x86_thiscallcc noundef ptr @"??_Gbad_array_new_length@std@@UAEPAXI@Z"(ptr noundef nonnull align 4 dereferenceable(12) %0, i32 noundef %1) unnamed_addr #10 comdat align 2 {
  store ptr @"??_7exception@std@@6B@", ptr %0, align 4, !tbaa !24
  %3 = getelementptr inbounds %"class.std::exception", ptr %0, i32 0, i32 1
  tail call void @__std_exception_destroy(ptr noundef nonnull %3) #18
  %4 = icmp eq i32 %1, 0
  br i1 %4, label %6, label %5

5:                                                ; preds = %2
  tail call void @"??3@YAXPAX@Z"(ptr noundef nonnull %0) #22
  br label %6

6:                                                ; preds = %5, %2
  ret ptr %0
}

; Function Attrs: mustprogress nounwind
define linkonce_odr dso_local x86_thiscallcc noundef ptr @"?what@exception@std@@UBEPBDXZ"(ptr noundef nonnull align 4 dereferenceable(12) %0) unnamed_addr #11 comdat align 2 {
  %2 = getelementptr inbounds %"class.std::exception", ptr %0, i32 0, i32 1
  %3 = load ptr, ptr %2, align 4, !tbaa !26
  %4 = icmp eq ptr %3, null
  %5 = select i1 %4, ptr @"??_C@_0BC@EOODALEL@Unknown?5exception?$AA@", ptr %3
  ret ptr %5
}

; Function Attrs: inlinehint nounwind
define linkonce_odr dso_local x86_thiscallcc noundef ptr @"??_Gbad_alloc@std@@UAEPAXI@Z"(ptr noundef nonnull align 4 dereferenceable(12) %0, i32 noundef %1) unnamed_addr #10 comdat align 2 {
  store ptr @"??_7exception@std@@6B@", ptr %0, align 4, !tbaa !24
  %3 = getelementptr inbounds %"class.std::exception", ptr %0, i32 0, i32 1
  tail call void @__std_exception_destroy(ptr noundef nonnull %3) #18
  %4 = icmp eq i32 %1, 0
  br i1 %4, label %6, label %5

5:                                                ; preds = %2
  tail call void @"??3@YAXPAX@Z"(ptr noundef nonnull %0) #22
  br label %6

6:                                                ; preds = %5, %2
  ret ptr %0
}

; Function Attrs: nounwind
define linkonce_odr dso_local x86_thiscallcc noundef ptr @"??_Gexception@std@@UAEPAXI@Z"(ptr noundef nonnull align 4 dereferenceable(12) %0, i32 noundef %1) unnamed_addr #7 comdat align 2 {
  store ptr @"??_7exception@std@@6B@", ptr %0, align 4, !tbaa !24
  %3 = getelementptr inbounds %"class.std::exception", ptr %0, i32 0, i32 1
  tail call void @__std_exception_destroy(ptr noundef nonnull %3) #18
  %4 = icmp eq i32 %1, 0
  br i1 %4, label %6, label %5

5:                                                ; preds = %2
  tail call void @"??3@YAXPAX@Z"(ptr noundef nonnull %0) #22
  br label %6

6:                                                ; preds = %5, %2
  ret ptr %0
}

; Function Attrs: nobuiltin nounwind
declare dso_local void @"??3@YAXPAX@Z"(ptr noundef) local_unnamed_addr #12

declare dso_local void @__std_exception_destroy(ptr noundef) local_unnamed_addr #5

; Function Attrs: nobuiltin allocsize(0)
declare dso_local noundef nonnull ptr @"??2@YAPAXI@Z"(i32 noundef) local_unnamed_addr #13

; Function Attrs: argmemonly mustprogress nocallback nofree nounwind willreturn
declare void @llvm.memcpy.p0.p0.i32(ptr noalias nocapture writeonly, ptr noalias nocapture readonly, i32, i1 immarg) #14

; Function Attrs: nounwind
declare dso_local void @"??3@YAXPAXI@Z"(ptr noundef, i32 noundef) local_unnamed_addr #15

; Function Attrs: argmemonly nocallback nofree nounwind willreturn writeonly
declare void @llvm.memset.p0.i64(ptr nocapture writeonly, i8, i64, i1 immarg) #16

; Function Attrs: nocallback nofree nosync nounwind readnone speculatable willreturn
declare i32 @llvm.umax.i32(i32, i32) #17

attributes #0 = { norecurse nounwind "frame-pointer"="none" "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="pentium4" "target-features"="+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #1 = { argmemonly mustprogress nocallback nofree nosync nounwind willreturn }
attributes #2 = { mustprogress nofree nounwind readonly willreturn "frame-pointer"="none" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="pentium4" "target-features"="+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #3 = { inlinehint mustprogress nounwind "frame-pointer"="none" "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="pentium4" "target-features"="+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #4 = { mustprogress nocallback nofree nosync nounwind willreturn }
attributes #5 = { "frame-pointer"="none" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="pentium4" "target-features"="+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #6 = { mustprogress noinline nounwind "frame-pointer"="none" "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="pentium4" "target-features"="+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #7 = { nounwind "frame-pointer"="none" "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="pentium4" "target-features"="+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #8 = { inlinehint mustprogress noreturn nounwind "frame-pointer"="none" "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="pentium4" "target-features"="+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #9 = { noreturn "frame-pointer"="none" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="pentium4" "target-features"="+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #10 = { inlinehint nounwind "frame-pointer"="none" "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="pentium4" "target-features"="+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #11 = { mustprogress nounwind "frame-pointer"="none" "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="pentium4" "target-features"="+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #12 = { nobuiltin nounwind "frame-pointer"="none" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="pentium4" "target-features"="+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #13 = { nobuiltin allocsize(0) "frame-pointer"="none" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="pentium4" "target-features"="+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #14 = { argmemonly mustprogress nocallback nofree nounwind willreturn }
attributes #15 = { nounwind "frame-pointer"="none" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="pentium4" "target-features"="+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #16 = { argmemonly nocallback nofree nounwind willreturn writeonly }
attributes #17 = { nocallback nofree nosync nounwind readnone speculatable willreturn }
attributes #18 = { nounwind }
attributes #19 = { noreturn nounwind }
attributes #20 = { noreturn }
attributes #21 = { nounwind allocsize(0) }
attributes #22 = { builtin nounwind }

!llvm.linker.options = !{!0, !1, !2, !3, !4, !5}
!llvm.module.flags = !{!6, !7}
!llvm.ident = !{!8}

!0 = !{!"/FAILIFMISMATCH:\22_CRT_STDIO_ISO_WIDE_SPECIFIERS=0\22"}
!1 = !{!"/FAILIFMISMATCH:\22_MSC_VER=1900\22"}
!2 = !{!"/FAILIFMISMATCH:\22_ITERATOR_DEBUG_LEVEL=0\22"}
!3 = !{!"/FAILIFMISMATCH:\22RuntimeLibrary=MT_StaticRelease\22"}
!4 = !{!"/DEFAULTLIB:libcpmt.lib"}
!5 = !{!"/FAILIFMISMATCH:\22annotate_string=0\22"}
!6 = !{i32 1, !"NumRegisterParameters", i32 0}
!7 = !{i32 1, !"wchar_size", i32 2}
!8 = !{!"clang version 15.0.1"}
!9 = !{!10, !10, i64 0}
!10 = !{!"any pointer", !11, i64 0}
!11 = !{!"omnipotent char", !12, i64 0}
!12 = !{!"Simple C++ TBAA"}
!13 = !{!14, !15, i64 20}
!14 = !{!"?AV?$_String_val@U?$_Simple_types@D@std@@@std@@", !11, i64 0, !15, i64 16, !15, i64 20}
!15 = !{!"int", !11, i64 0}
!16 = !{!11, !11, i64 0}
!17 = !{!15, !15, i64 0}
!18 = distinct !{!18, !19}
!19 = !{!"llvm.loop.mustprogress"}
!20 = !{!21, !21, i64 0}
!21 = !{!"long long", !11, i64 0}
!22 = distinct !{!22, !19}
!23 = !{!14, !15, i64 16}
!24 = !{!25, !25, i64 0}
!25 = !{!"vtable pointer", !12, i64 0}
!26 = !{!27, !10, i64 4}
!27 = !{!"?AVexception@std@@", !28, i64 4}
!28 = !{!"?AU__std_exception_data@@", !10, i64 0, !29, i64 4}
!29 = !{!"bool", !11, i64 0}
