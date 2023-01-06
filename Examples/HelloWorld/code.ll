; ModuleID = 'code.cpp'
source_filename = "code.cpp"
target datalayout = "e-m:x-p:32:32-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32-a:0:32-S32"
target triple = "i686-pc-windows-msvc19.34.31937"

$"??_C@_0N@GCDOMLDM@Hello?5World?$CB?$AA@" = comdat any

@"??_C@_0N@GCDOMLDM@Hello?5World?$CB?$AA@" = linkonce_odr dso_local unnamed_addr constant [13 x i8] c"Hello World!\00", comdat, align 1

; Function Attrs: mustprogress nofree norecurse nounwind
define dso_local noundef i32 @main() local_unnamed_addr #0 {
  %1 = tail call i32 @puts(ptr noundef nonnull @"??_C@_0N@GCDOMLDM@Hello?5World?$CB?$AA@")
  ret i32 0
}

; Function Attrs: nofree nounwind
declare dso_local noundef i32 @puts(ptr nocapture noundef readonly) local_unnamed_addr #1

attributes #0 = { mustprogress nofree norecurse nounwind "frame-pointer"="none" "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="pentium4" "target-features"="+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #1 = { nofree nounwind "frame-pointer"="none" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="pentium4" "target-features"="+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }

!llvm.linker.options = !{!0, !1, !2, !3, !4, !5}
!llvm.module.flags = !{!6, !7}
!llvm.ident = !{!8}

!0 = !{!"/FAILIFMISMATCH:\22_MSC_VER=1900\22"}
!1 = !{!"/FAILIFMISMATCH:\22_ITERATOR_DEBUG_LEVEL=0\22"}
!2 = !{!"/FAILIFMISMATCH:\22RuntimeLibrary=MT_StaticRelease\22"}
!3 = !{!"/DEFAULTLIB:libcpmt.lib"}
!4 = !{!"/FAILIFMISMATCH:\22_CRT_STDIO_ISO_WIDE_SPECIFIERS=0\22"}
!5 = !{!"/FAILIFMISMATCH:\22annotate_string=0\22"}
!6 = !{i32 1, !"NumRegisterParameters", i32 0}
!7 = !{i32 1, !"wchar_size", i32 2}
!8 = !{!"clang version 15.0.1"}
