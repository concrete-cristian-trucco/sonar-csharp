﻿Imports System.Diagnostics
Imports System.Runtime.InteropServices

Module Foo
' The tests do not track location because it would introduce a comment inside the body (and the issue would not be raised)

' Noncompliant@+1 {{Add a nested comment explaining why this method is empty, throw a 'NotSupportedException' or complete the implementation.}}
  Function EmptyFunc()
  End Function

  Sub Exception1()
    Throw New NotImplementedException
  End Sub

' Noncompliant@+1 {{Add a nested comment explaining why this method is empty, throw a 'NotSupportedException' or complete the implementation.}}
  Sub EmptySub()
  End Sub

  Function Exception2()
    Throw New NotSupportedException
  End Function

  Function Exception3()
    Throw
  End Function

  Sub Comment1()
    ' foo
  End Sub

  Function Comment2()
    ' foo
  End Function

  Sub Ok1()
    Console.ReadKey()
  End Sub

  Function Ok2()
    Return "bar"
  End Function

' Noncompliant@+1
  Function Incomplete1()

  Function Incomplete2()
    Return "bar"

' Noncompliant@+1
  Sub Incomplete3()

  Function Incomplete4()
    Thr
  End Function

End Module

Module Bar
  MustInherit Class FooBar
    MustOverride Sub Foo1()
    Overridable Sub Foo2()
    End Sub
 ' Noncompliant@+1
    Function Foo3()
    End Function
  End Class

  Class BarQix
    Inherits FooBar
    Public Overrides Sub Foo1()
    End Sub
 ' Noncompliant@+1
    Public Overrides Sub Foo2()
    End Sub
 ' Noncompliant@+1
    Public Shadows Function Foo3()
    End Function
  End Class

  Public Class FooQix
    Inherits FooBar
    Public Overrides Sub Foo1()
      Throw New NotImplementedException()
    End Sub
    Public Overrides Sub Foo2()
      MyBase.Foo2()
    End Sub
    Public Shadows Function Foo3()
      ' x
    End Function
  End Class

  <DllImport("FOO.DLL")> _
  Private Shared Function External1(ByVal Handle As IntPtr) As IntPtr
  End Function

  <DllImport("FOO.DLL")> _
  Private Shared Sub External2(ByVal Handle As IntPtr)
  End Sub

  Declare Function External3 Lib "foo.dll" Alias "FooBar" (ByVal lpBuffer As String) As Integer

' Noncompliant@+2
  <Conditional("DEBUG"), Conditional("TEST1")>
  Sub OtherAttribute1()
  End Sub

' Noncompliant@+2
  <DllI
  Private Shared Sub OtherAttribute2(ByVal Handle As IntPtr)
  End Sub

End Module
