Imports System.Text

Public Class XYZ
    Public X As Double
    Public Y As Double
    Public Z As Double
    Private Mag As Double
    Public Shared Function NaXYZ() As XYZ
        Return New XYZ(Double.PositiveInfinity, Double.PositiveInfinity, Double.PositiveInfinity)
    End Function
    Public Function isNaN() As Boolean
        Return X = Double.NaN And Y = Double.NaN And Z = Double.NaN
    End Function
    Public Function isZero() As Boolean
        Return X = 0 And Y = 0 And Z = 0
    End Function
    Public Sub makeZero()
        makeValue(0)
    End Sub
    Public Sub makeValue(ByRef Value As Double)
        X = Value
        Y = Value
        Z = Value
    End Sub
    Public Function Dot(ByRef Other As XYZ) As Double
        Return (X * Other.X) + (Y * Other.Y) + (Z * Other.Z)
    End Function
    Public Function Cross(ByRef Other As XYZ) As XYZ
        Return New XYZ((Y * Other.Z) - (Z * Other.Y), (Z * Other.X) - (X * Other.Z), (X * Other.Y) - (Y * Other.X))
    End Function
    Public Sub New(ByRef Value As Double)
        makeValue(Value)
    End Sub
    Public Sub New(ByRef Other As XYZ)
        Copy(Other)
    End Sub
    Public Sub Copy(ByRef Other As XYZ)
        X = Other.X
        Y = Other.Y
        Z = Other.Z
    End Sub
    Public Sub New(ByVal X As Double, ByVal Y As Double, ByVal Z As Double)
        Me.X = X
        Me.Y = Y
        Me.Z = Z
    End Sub
    Public Sub New()
     makeZero()
    End Sub
    Public Shared Operator -(ByVal lhs As XYZ, ByVal rhs As XYZ) As XYZ
        Return New XYZ(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z)
    End Operator
    Public Shared Operator -(ByVal rhs As XYZ) As XYZ
        Return New XYZ(0 - rhs.X, 0 - rhs.Y, 0 - rhs.Z)
    End Operator
    Public Shared Operator +(ByVal lhs As XYZ, ByVal rhs As XYZ) As XYZ
        Return New XYZ(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z)
    End Operator
    Public Shared Operator =(ByVal lhs As XYZ, ByVal rhs As XYZ) As Boolean
        Return lhs.X = rhs.X And lhs.Y = rhs.Y And lhs.Z = rhs.Z
    End Operator
    Public Shared Operator *(ByVal lhs As XYZ, ByVal rhs As Double) As XYZ
        Return New XYZ(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs)
    End Operator
    Public Shared Operator *(ByVal lhs As Double, ByVal rhs As XYZ) As XYZ
        Return New XYZ(lhs * rhs.X, lhs * rhs.Y, lhs * rhs.Z)
    End Operator
    Public Shared Operator *(ByVal lhs As XYZ, ByVal rhs As XYZ) As XYZ
        Return New XYZ(lhs.X * rhs.X, lhs.X * rhs.Y, lhs.X * rhs.Z)
    End Operator
    Public Shared Operator /(ByVal lhs As XYZ, ByVal rhs As Double) As XYZ
        Return New XYZ(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs)
    End Operator
    Public Shared Operator /(ByVal lhs As XYZ, ByVal rhs As XYZ) As XYZ
        Return New XYZ(lhs.X / rhs.X, lhs.Y / rhs.Y, lhs.Z / rhs.Z)
    End Operator
    Public Shared Operator /(ByVal lhs As Double, ByVal rhs As XYZ) As XYZ
        Return New XYZ(lhs / rhs.X, lhs / rhs.Y, lhs / rhs.Z)
    End Operator
    Public Shared Operator <>(ByVal lhs As XYZ, ByVal rhs As XYZ) As Boolean
        Return Not lhs = rhs
    End Operator
    Public Function MagnitudeSquared() As Double
        Return (X * X) + (Y * Y) + (Z * Z)
    End Function
    Public Function Magnitude() As Double
        Return Sqrt(MagnitudeSquared)
    End Function
    Public Function Abs() As XYZ
        Return New XYZ(Math.Abs(X), Math.Abs(Y), Math.Abs(Z))
    End Function
    Public Sub makeUnit()
        Mag = Magnitude()
        X /= Mag
        Y /= Mag
        Z /= Mag
    End Sub
    Public Function getUnit() As XYZ
        Mag = Magnitude()
        Return New XYZ(X / Mag, Y / Mag, Z / Mag)
    End Function
    Public Function toVector3() As Vector3
        Return New Vector3(ToSingle(X), ToSingle(Y), ToSingle(Z))
    End Function
    Public Function Perpendicular() As XYZ
        Return New XYZ(-Y, X, Z)
    End Function
    Public Function Perpendicular2() As XYZ
        Return New XYZ(X, -Z, Y)
    End Function
    Public Function Flip() As XYZ
        Return New XYZ(-X, -Z, -Y)
    End Function
    Public Function isNaXYZ() As Boolean
        Return X = Double.PositiveInfinity And Y = Double.PositiveInfinity And Z = Double.PositiveInfinity
    End Function
    Public Overloads Sub ToString(stringBuilder As StringBuilder)

        stringBuilder.AppendLine("<X>")
        stringBuilder.Append(X.ToString)
        stringBuilder.Append("</X>")

        stringBuilder.AppendLine("<Y>")
        stringBuilder.Append(Y.ToString())
        stringBuilder.Append("</Y>")

        stringBuilder.AppendLine("<Z>")
        stringBuilder.Append(Z.ToString())
        stringBuilder.Append("</Z>")
    End Sub
    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder)
        Return stringBuilder.ToString
    End Function
    Public Sub Load(ByRef intext As String)
        Dim Result As String

        Result = GetValue(intext, "X")
        If Result <> "" And IsNumeric(Result) Then
            X = ToDouble(Result)
        Else
            X = 0
        End If

        Result = GetValue(intext, "Y")
        If Result <> "" And IsNumeric(Result) Then
            Y = ToDouble(Result)
        Else
            Y = 0
        End If

        Result = GetValue(intext, "Z")
        If Result <> "" And IsNumeric(Result) Then
            Z = ToDouble(Result)
        Else
            Z = 0
        End If
    End Sub
End Class
