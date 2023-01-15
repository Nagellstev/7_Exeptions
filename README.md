# CarPark
Using the object model from the Collections tasks, extend the functionality by adding the following event handlings:

 - InitializationException - an exception if it is impossible to initialize a car model.
 - AddException - an exception if it is impossible to add a car model;
 - GetAutoByParameterException - for the GetAutoByParameter (string parameter, string value) 
 method - an exception if it is impossible to find the model by the specified parameter. 
 E.g. an attempt to find a car by a nonexistent parameter.
 - UpdateAutoException - an exception if it is impossible to replace a car. 
 E.g. an attempt to replace the car with a non-existent identifier (ID).
 - RemoveAutoException - an exception if it is impossible to remove a car. 
 E.g. an attempt to delete the car with a non-existent identifier (ID).