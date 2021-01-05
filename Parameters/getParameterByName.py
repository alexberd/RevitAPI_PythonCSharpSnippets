# Load the Python Standard and DesignScript Libraries
import sys
import clr
clr.AddReference('ProtoGeometry')
from Autodesk.DesignScript.Geometry import *

# Import RevitAPI
clr.AddReference("RevitAPI")
import Autodesk
from Autodesk.Revit.DB import *
  
#Create a Python Node with two Inputs
elements = UnwrapElement(IN[0])
parameterName = IN[1]

output=[]
for e in elements:
  paraExist=False
  for para in e.Parameters:
    p = para.Definition
    if p.Name == parameterName:
      paraExist=True   
      if para.StorageType == Autodesk.Revit.DB.StorageType.Integer:
      	output.append(para.AsInteger())
      	break
      elif para.StorageType == Autodesk.Revit.DB.StorageType.String:
      	output.append(para.AsString())
      	break
      elif para.StorageType == Autodesk.Revit.DB.StorageType.Double:
      	output.append(para.AsDouble())
      	break
      else:
      	output.append(para.AsValueString())
      	break
  if paraExist==False:
  	output.append("")

OUT = output
