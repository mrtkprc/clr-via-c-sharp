# CLR via C# (Fourth Edition) by Jeffrey Richter
## Notes from CLR via C# written by Jeffrey Richter



### This repository contains notes taken from book CLR via C#(Fourth Edition),written by Jeffrey Richter, with examples.

## Chapter 1

- CLR is just what its name says it is: a runtime that is usable by different and verified programming language.
- **CLR has no idea which programming language the developer used for the source code.**
- You can create source code files written in any programming language that supports the CLR.

**A managed module is a standard 32-bit Windows (P)ortable (E)xecutable (PE32) file or a standard 64bit Windows portable executable (PE32+) files** requires the CLR to execute.

**IL codeis sometimes referred to as managed code because CLR manages its execution**

### Metadata has many uses:
- Compiler can read metadata directly.
- Intellisense feature parses metadata to tell you.
- By specifiying the `CLR` command-line switch, the C++ compiler produces modules that contain managed code.

**C++ is unique in that it is the only compiler that allows the developer to write both managed and unmanaged code**

![Assembly](./images/assembly.jpeg)

- **You can tell if .NET Framework has been installed by looking for the `MsCorEE.dll` file in the `%SystemRoot%\System32` directory. The existence of this file tells you that .NET FW is installed.** 

- If you want to determine exactly which versions of the .NET FW are installed. Examine the subdirectories under the following directories.
    - `%SystemRoot%System32\Microsoft.NET\Framework`
    - `%SystemRoot%System32\Microsoft.NET\Framework64`


- .NET FW SDK includes a command-line utility called `CLRVer.exe` that shows all of the CLR versions installed on a machine.
- The utility can also show which version of CLR is being used by process

- Microsoft ships two SDK Command Line utilities `DumpBin.exe` and `CorFlags.exe`.

### `DumpBin.exe`
> The Microsoft COFF Binary File Dumper (DUMPBIN.EXE) displays information about Common Object File Format (COFF) binary files. You can use DUMPBIN to examine COFF object files, standard libraries of COFF objects, executable files, and dynamic-link libraries (DLLs).

e.g: `dumpbin.exe /all /out:dump-bin-out.txt DumpBinSample.exe`

gives dump output file.

### `CorFlag.exe`
> The CorFlags Conversion tool allows you to configure the CorFlags section of the header of a portable executable image.

### 64-bits versions of windows offer a terminology that allows 32-bit Windows application to run. This technology is called `WoW64 (Windows On Windows64)`

- ### After Windows has examined the EXE's file header to determine whether to create 32-bit or 64 bit process, Windows loads the `x86`, `x64` or `ARM` versions of `MsCorEE.dll` into process address space.

**You can think of IL as can object oriented machine language.**

- A performance hit is incurred only the first time a method is called. All subsequent calls to the method execute at the full speed of the native code, because verificatin and compilation to native code don't need to be performed again.

**Calling for first time.**
![Assembly](./images/calling-for-first-time.jpeg)

**Calling for second time.**

![Assembly](./images/calling-for-second-time.jpeg)

### ILAsm.exe

> The IL Assembler generates a portable executable (PE) file from intermediate language (IL) assembly. You can run the resulting executable, which contains IL and the required metadata, to determine whether the IL performs as expected.


`ilasm examples/ilasm/sample.il /output:hello_world.exe`

You can find sample IL code in `examples/ilasm/sample.il` file.

### ILDasm.exe

> The IL Disassembler is a companion tool to the IL Assembler (Ilasm.exe). Ildasm.exe takes a portable executable (PE) file that contains intermediate language (IL) code and creates a text file suitable as input to Ilasm.exe.

`ildasm examples/ildasm/hello_world.exe /output:examples/ildasm/hello.il`

Output of `hello.il`:

```
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.4084.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:0:0
}
.assembly sample
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module sample.exe
// MVID: {D2503C99-2A0C-474A-8F6B-7A6DFDF99208}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x06BF0000

// =============== CLASS MEMBERS DECLARATION ===================
.class public auto ansi beforefieldinit Hello
       extends [mscorlib]System.Object
{
  .method public hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "Hello World!"
    IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_000b:  nop
    IL_000c:  ret
  } // end of method Hello::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Hello::.ctor

} // end of class Hello

// =============================================================
// *********** DISASSEMBLY COMPLETE ***********************
```

- The JIT compiler stores the native code CPU instructions in dynamic memory. This means that the compiled code is discarded when the application terminates.

`Debug: /optimize- /debug:full`

`Release: /optimize+ /debug:pdbonly`

Continue from page 5