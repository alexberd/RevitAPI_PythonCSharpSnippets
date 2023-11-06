//From https://stackoverflow.com/questions/52119667/get-builtinparameterid-from-builtin-parameter-elementid-in-revit

Void getParameterFromBuiltInParameterId(Integer paramIntValue)
{
  BuiltInParameter parameter = (BuiltInParameter)Enum.ToObject(typeof(BuiltInParameter), paramIntValue);
}