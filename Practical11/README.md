README 
======
The solution contains 

Data project that 
1. defines the entity models with associated relationships  
2. defines a Repository Layer (EntityFramwork Context)
3. a Service Layer (application business logic)

XUnit Test project that
1. Defines a set of unit tests to validate the operation of the service layer 
2. Requires a reference to the SMS.Data project (dependency) - in particular the Service class and 
   models

MVC Web project that
1. Defines the user interface of our application - containing the ability to
    a. view students
    b. create a student
    c. edit a student
    d. includes validation when creating/editing a student
	e. adds UX improvements inclusing breadcrumbs and alerts
	e. includes authentication, authorisation and web security features
