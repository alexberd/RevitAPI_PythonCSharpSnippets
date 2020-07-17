#BY Martin.Servold_MEE
#https://forums.autodesk.com/t5/revit-api-forum/purge-unused-via-the-api/m-p/7526079

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

output=[]

purgeGuid = 'e8c63650-70b7-435a-9010-ec97660c1bda'
purgableElementIds = []
performanceAdviser = DB.PerformanceAdviser.GetPerformanceAdviser()
guid = System.Guid(purgeGuid)
ruleId = None
allRuleIds = performanceAdviser.GetAllRuleIds()
for rule in allRuleIds:
    # Finds the PerformanceAdviserRuleId for the purge command
    if str(rule.Guid) == purgeGuid:
        ruleId = rule
ruleIds = List[DB.PerformanceAdviserRuleId]([ruleId])
for i in range(4):
    # Executes the purge
    failureMessages = performanceAdviser.ExecuteRules(doc, ruleIds)
    if failureMessages.Count > 0:
        # Retreives the elements
        purgableElementIds = failureMessages[0].GetFailingElements()

#Stores the element to purge for output
for i in purgableElementIds:
  output.append(doc.GetElement(i)):
  
# Deletes the elements
try:
    elementTodelet=doc.GetElement
    doc.Delete(purgableElementIds)
    
except:
    for e in purgableElementIds:
        try:
            doc.Delete(e)
        except:
            pass

OUT=output
