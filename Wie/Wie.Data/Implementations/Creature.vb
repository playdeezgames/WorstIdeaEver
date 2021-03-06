Friend Class Creature
    Implements ICreature
    Private ReadOnly _id As Long
    Private ReadOnly _locationId As Long

    Public Sub New(id As Long, locationId As Long)
        _id = id
        _locationId = locationId
    End Sub

    Public ReadOnly Property Id As Long Implements ICreature.Id
        Get
            Return _id
        End Get
    End Property

    Public ReadOnly Property LocationId As Long Implements ICreature.LocationId
        Get
            Return _locationId
        End Get
    End Property
End Class
