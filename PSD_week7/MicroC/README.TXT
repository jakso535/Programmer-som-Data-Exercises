Compiling and loading the micro-C evaluator and parser (MicroC/README.TXT)
--------------------------------------------------------------------------

Archive microc.zip contains the files used in points A, B and C below.


A. Generating and compiling the lexer and parser for micro-C, and
   loading the interpreter for micro-C.  (Running fsyacc on CPar.fsy
   produces a bunch of shift/reduce conflict warnings, but as far as I
   can see this is due to a bug in fsyacc, which ignores the %nonassoc
   directives on GT LT GE LE).

   fslex --unicode CLex.fsl
   fsyacc --module CPar CPar.fsy
   fsharpi -r FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Interp.fs ParseAndRun.fs

   open ParseAndRun;;
   fromFile "ex1.c";;
   run (fromFile "ex1.c") [17];;
   run (fromFile "ex11.c") [8];;


B. To compile and use the micro-C compiler

   fslex --unicode CLex.fsl
   fsyacc --module CPar CPar.fsy
   dotnet fsi -r /Users/atm/Desktop/uni/itu/semester-5/programmer-som-data/assignments/Programmer-som-Data-Exercises/PSD_week2/libs/ProgramsAsDataCodeE2025-main/fsharp/FsLexYacc.Runtime.11.3.0/lib/netstandard2.0/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs   
   dotnet fsi -r /Users/Jake/Desktop/ITU/5-semester/Programmer-som-Data-Exercises/PSD_week2/libs/ProgramsAsDataCodeE2025-main/fsharp/FsLexYacc.Runtime.11.3.0/lib/netstandard2.0/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs   


   open ParseAndComp;;
   compileToFile (fromFile "Exercise-8.3.c") "Exercise-8.3.out";;

   #q;;
   java Machine Exercise-8.3.out 8
   
   java Machinetrace test6.out

   javac Machine.java
   java Machine Exercise-8.3.out 8


C. To compile and use the backwards (continuation-based) micro-C compiler:

   fslex --unicode CLex.fsl
   fsyacc --module CPar CPar.fsy
   dotnet fsi -r /Users/atm/Desktop/uni/itu/semester-5/programmer-som-data/assignments/Programmer-som-Data-Exercises/PSD_week2/libs/ProgramsAsDataCodeE2025-main/fsharp/FsLexYacc.Runtime.11.3.0/lib/netstandard2.0/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Contcomp.fs ParseAndContcomp.fs   

   open ParseAndContcomp;;
   contCompileToFile (fromFile "ex11.c") "ex11.out";;
   #q;;

   javac Machine.java
   java Machine ex11.out 8


D. Build the backwards micro-C compiler as a command-line program microcc

   fslex --unicode CLex.fsl
   fsyacc --module CPar CPar.fsy
   fsharpc -r FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Contcomp.fs MicroCC.fs -o microcc.exe

   microcc.exe ex11.c
or
   mono microcc.exe ex11.c

   javac Machine.java
   java Machine ex11.out 8
