Friend Class Location
    Implements ILocation
    Private ReadOnly _id As Long
    Private ReadOnly _x As Integer
    Private ReadOnly _y As Integer
    Private ReadOnly _z As Integer
    Public Sub New(id As Long, x As Integer, y As Integer, z As Integer)
        _id = id
        _x = x
        _y = y
        _z = z
    End Sub

    Public ReadOnly Property Id As Long Implements ILocation.Id
        Get
            Return _id
        End Get
    End Property

    Public ReadOnly Property X As Integer Implements ILocation.X
        Get
            Return _x
        End Get
    End Property

    Public ReadOnly Property Y As Integer Implements ILocation.Y
        Get
            Return _y
        End Get
    End Property

    Public ReadOnly Property Z As Integer Implements ILocation.Z
        Get
            Return _z
        End Get
    End Property
End Class
