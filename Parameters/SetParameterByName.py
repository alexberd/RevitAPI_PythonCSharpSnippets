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

from Autodesk.Revit.DB import Transaction
t = Transaction(doc, 'Name')


#First define your Elements 
elements = IN[0]

#Second define your Parameter Name
ParName = IN[1]

#Third define your Parameter Value
ParValue = IN[2]

output=[]
for i in elements:
	try:
		t.Start()
		for Param in i.Parameters:
			if Param.Definition.Name == ParName:
				output.append(Param.Definition.Name)
				Param.Set(ParValue)
				output.append("Parameter changed at element: "+str(i.Id))
		
		t.Commit() 
	except Exception, e:
    t.Commit() 
		output.append("Problem at element: "+str(i.Id) +str(e))

OUT = output
