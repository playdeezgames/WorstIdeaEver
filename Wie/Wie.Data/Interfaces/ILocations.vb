Public Interface ILocations
    Function Find(locationId As Int64) As ILocation
    Function Create(x As Integer, y As Integer, z As Integer) As Int64
End Interface
