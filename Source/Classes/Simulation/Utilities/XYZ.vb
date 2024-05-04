Imports System.Text
Imports SharpDX

Public Structure XYZ
    Public X As Double
    Public Y As Double
    Public Z As Double
    Public Shared Function NaXYZ() As XYZ
        Return New XYZ(Double.PositiveInfinity, Double.PositiveInfinity, Double.PositiveInfinity)
    End Function
    Public Function IsNaN() As Boolean
        Return X = Double.NaN And Y = Double.NaN And Z = Double.NaN
    End Function
    Public Function IsZero() As Boolean
        Return X = 0 And Y = 0 And Z = 0
    End Function
    Public Sub MakeZero()
        MakeValue(0)
    End Sub
    Public Sub MakeValue(ByVal Value As Double)
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
        MakeValue(Value)
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

    Public Shared Operator -(ByVal lhs As XYZ, ByVal rhs As XYZ) As XYZ
        Return New XYZ(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z)
    End Operator
    Public Shared Operator -(ByVal rhs As XYZ) As XYZ
        Return New XYZ(0 - rhs.X, 0 - rhs.Y, 0 - rhs.Z)
    End Operator
    Public Shared Operator -(ByVal lhs As XYZ, ByVal rhs As Double) As XYZ
        Return New XYZ(lhs.X - rhs, lhs.Y - rhs, lhs.Z - rhs)
    End Operator
    Public Shared Operator +(ByVal lhs As XYZ, ByVal rhs As Double) As XYZ
        Return New XYZ(lhs.X + rhs, lhs.Y + rhs, lhs.Z + rhs)
    End Operator

    Public Shared Operator +(ByVal lhs As XYZ, ByVal rhs As XYZ) As XYZ
        Return New XYZ(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z)
    End Operator

    Public Shared Operator =(ByVal lhs As XYZ, ByVal rhs As XYZ) As Boolean
        Return lhs.X = rhs.X AndAlso lhs.Y = rhs.Y AndAlso lhs.Z = rhs.Z
    End Operator

    Public Shared Operator <=(ByVal lhs As XYZ, ByVal rhs As XYZ) As Boolean
        Return lhs.X <= rhs.X AndAlso lhs.Y <= rhs.Y AndAlso lhs.Z <= rhs.Z
    End Operator

    Public Shared Operator >=(ByVal lhs As XYZ, ByVal rhs As XYZ) As Boolean
        Return lhs.X >= rhs.X AndAlso lhs.Y >= rhs.Y AndAlso lhs.Z >= rhs.Z
    End Operator

    Public Shared Operator *(ByVal lhs As XYZ, ByVal rhs As Double) As XYZ
        Return New XYZ(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs)
    End Operator
    Public Shared Operator *(ByVal lhs As Double, ByVal rhs As XYZ) As XYZ
        Return New XYZ(lhs * rhs.X, lhs * rhs.Y, lhs * rhs.Z)
    End Operator
    Public Shared Operator *(ByVal lhs As XYZ, ByVal rhs As XYZ) As XYZ
        Return New XYZ(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z)
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

    Public Sub Rotate(ByRef RotationMatrix As Matrix3x3)
        Dim newX As Double = X * RotationMatrix.M11 + Y * RotationMatrix.M21 + Z * RotationMatrix.M31
        Dim newY As Double = X * RotationMatrix.M12 + Y * RotationMatrix.M22 + Z * RotationMatrix.M32
        Dim newZ As Double = X * RotationMatrix.M13 + Y * RotationMatrix.M23 + Z * RotationMatrix.M33
        Z = newZ
        X = newX
        Y = newY
    End Sub

    Public Function NewRotated(ByRef RotationMatrix As Matrix3x3) As XYZ
        Dim newXYZ As New XYZ(Me)
        newXYZ.Rotate(RotationMatrix)
        Return newXYZ
    End Function

    Public Function MagnitudeSquared() As Double
        Return (X * X) + (Y * Y) + (Z * Z)
    End Function
    Public Function Magnitude() As Double
        Return Sqrt(MagnitudeSquared)
    End Function
    Public Function Abs() As XYZ
        Return New XYZ(Me).MakeMeAbs()
    End Function
    Public Sub MakeAbs()
        X = Math.Abs(X)
        Y = Math.Abs(Y)
        Z = Math.Abs(Z)
    End Sub
    Public Function MakeMeAbs() As XYZ
        MakeAbs()
        Return Me
    End Function
    Public Sub MakeUnit()
        Dim Mag As Double = Magnitude()
        X /= Mag
        Y /= Mag
        Z /= Mag
    End Sub
    Public Function MakeMeUnit() As XYZ
        MakeUnit()
        Return Me
    End Function
    Public Function GetNewUnit() As XYZ
        Return (New XYZ(X, Y, Z)).MakeMeUnit
    End Function
    Public Function ToVector3() As Vector3
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
    Public Function IsNaXYZ() As Boolean
        Return X = Double.PositiveInfinity And Y = Double.PositiveInfinity And Z = Double.PositiveInfinity
    End Function
    Public Overloads Sub ToString(stringBuilder As StringBuilder, tabs As String)

        stringBuilder.Append(tabs)
        stringBuilder.Append("<X>")
        stringBuilder.Append(X.ToString)
        stringBuilder.AppendLine("</X>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Y>")
        stringBuilder.Append(Y.ToString())
        stringBuilder.AppendLine("</Y>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Z>")
        stringBuilder.Append(Z.ToString())
        stringBuilder.AppendLine("</Z>")
    End Sub
    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder, "")
        Return stringBuilder.ToString
    End Function
    Public Sub Load(ByRef intext As String)
        Dim Result As String

        Result = GetXMLNodeValue(intext, "X")
        If Result <> "" And IsNumeric(Result) Then
            X = ToDouble(Result)
        Else
            X = 0
        End If

        Result = GetXMLNodeValue(intext, "Y")
        If Result <> "" And IsNumeric(Result) Then
            Y = ToDouble(Result)
        Else
            Y = 0
        End If

        Result = GetXMLNodeValue(intext, "Z")
        If Result <> "" And IsNumeric(Result) Then
            Z = ToDouble(Result)
        Else
            Z = 0
        End If
    End Sub
End Structure
