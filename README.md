# LLToIL

Converts LLVM IR to MSIL and compiles it to dll.

# Usage

LLToIL.exe "path/to/llvm/ir/code.ll"

# It can rn:
 - emit most opcodes
 - emit static fields values (particularly, not all cases tested)
 - link extern methods to ucrtbase.dll
 - crash by looking at what's under the hood of std::cout +____+

# Unsupported/Unimplemented features:
 - try carch opcodes
 - vectors
 - some LLVM intrinsics
 - some libstd methods (rn aviable all methods from kernel32 and ucrtbase.dll)
 - function names decorating
 - classes (not tested)
 - asm inlines 
 - threads
 - Vargs (or im stupid or .Net 6 uses wrong __arglist structure)
 - and etc...
