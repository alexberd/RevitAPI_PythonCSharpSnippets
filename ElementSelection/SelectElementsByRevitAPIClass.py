# Enable Python support and load DesignScript library
import clr
clr.AddReference('ProtoGeometry')
from Autodesk.DesignScript.Geometry import *

# Import DocumentManager and TransactionManager
clr.AddReference("RevitServices")
import RevitServices
from RevitServices.Persistence import DocumentManager

# Import RevitAPI
clr.AddReference("RevitAPI")
import Autodesk
from Autodesk.Revit.DB import *

#Select Current Document
doc = DocumentManager.Instance.CurrentDBDocument

#Create ElementCollector
selection = FilteredElementCollector(doc);

#Select Element Class from REVIT-API
#https://www.revitapidocs.com/2019
selection.OfClass(LinePatternElement)

#EQUIVALENT TO THE ABOVE
#selection.WherePasses(ElementClassFilter(LinePatternElement))

#Define if element is a type element or not
#selection.WhereElementIsNotElementType();

#Append the elements to output
output=[]
for i in selection:
	output.append(i)

OUT = output
