#Import Revit.Geometry
import clr
clr.AddReference('RevitNodes')
import Revit
clr.ImportExtensions(Revit.GeometryConversion)

#Get Input
data = UnwrapElement(IN[0])

#Convert To Point
OUT = data.Location.Point.ToPoint()
