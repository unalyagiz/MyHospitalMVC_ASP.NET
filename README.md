# MyHospitalMVC_ASP.NET

This project has done during my internship with in a time of 4 weeks.

## Purpose of the project
I wanted to learn web-development despite of having no prior experience. And I would be happy if I could use MVC design pattern. So the project idea was a hospital website which is performed
several operations like taking appointment,adding doctor to database, information about doctors etc.

## Steps by Weeks

## Week 1

So I have started to design the database and the relations between its properties.At the same time I was researching the MVC design pattern and ASP.NET frameworks.There are two common approach when creating a database for ASP.NET applications.One of them is CODE FIRST and the other one is DATABASE FIRST.I had tried to apply the code first approach but I failed when tried to bond the relations.So I have decided to apply the database first approach and I have succeeded.But after that I realize the mistake.And tried to give it a one more chance.It was succeeded as well.Which was happened that way,when creating a database there is one framework that can make that happen which is ENTITY FRAMEWORK.So I added to my project package and include its using into  DATABASE CONTEXT.cs.And created a class for each table and its properties.DATA ANOTATIONS library allow developers to set their table name,type of properties and lengths,key and relations.So I created classes for each table and  its properties and that way they were MODELS which keep the data in it.And I have started initiliazer method to create database.After the Database created I have tried to test it with filling  fake data in it and observed that the constraints that applied remains its existence.

## Week 2
At the second week of my internship,It was time to move on to the data-related operations and how to visualize them in the web-page.I used visual studio for my Project.So,in my reasearch i learned a syntax that allow to embed c# code into cshtml file which is called razor syntax.It is developed by Microsoft for ASP.NET projects.I created a CONTROLLER for making operations with data which is received from MODEL and view it into VIEW.
Back at the creation of database,i had not fill the tables just created it.So,I decided to fill them with fake data to see the results in VIEW.I edited my DatabaseContextController with that way,for each table I created list of objects and fill them with the framework that i found to provide dataset.And initialized the database again.At the end I have got a filled database to show the informations of doctors and patients into VIEW.For displaying the data into View,the data must be taken from database and pass it to the controller then controller can pass it to the VIEW.In my homepageController,I created an object of DatabaseContext and took those list of objects into a same kinds of objects.I created a function type of ActionResult ,took that data and pass its view-page.But for using the data ,view is needed to take a model.So i imported my model with razor syntax.View is a cshtml file that i mentioned above which allow you to take the data and manipulate like in .cs file except for displaying it in html-page.After a couple of lines of code,i have succeded to displaying.This was my first achievement in my tasks.

## Week 3
At the third week of my internship,I needed to create a web-page for inserting data to database just like any program that involved database.I have started to create my View for inserting Doctors to database.For using properties of the object,it is needed to import the MODEL to VIEW.Then I used html helper methods to create textbox for properties of the model.There is one framework for JavaScript which is called JQUERY.I used that framework for Client-Side validation.But it is not safe all the time if the user is somehow able to deactivate the JavaScript from browser then database might be filled with spam data.(For adding doctor you need to have a authorization of admin so that’s not the case for that situation but I also added the validation to adding patient VIEW which I will mention later.)So I needed to provide also Server-Side validation.I used a method called ModelState.IsValid which controls the model has any validation error and if it has not then it will return true so that way I am able to save the data into database.

<img src="https://github.com/unalyagiz/MyHospitalMVC_ASP.NET/blob/master/trunk/images/1.png" width="600" height="250"/>
I had created branches table for keep the branches in one table with their IDs and names so that information can not be lost.Profession property is a select list item and returns id of Branches,if the id matches with in the database then doctors branch is set it to that branch.Doctors have branches and I had created relations between Doctor and Branch that way.

<img src="https://github.com/unalyagiz/MyHospitalMVC_ASP.NET/blob/master/trunk/images/2.png" width="600" height="250"/>
<img src="https://github.com/unalyagiz/MyHospitalMVC_ASP.NET/blob/master/trunk/images/3.png" width="600" height="250"/>

I have successfully complete the add Doctor operation.So there has to be two other options which are deletion and editing.For that operations I needed to create a table of doctors to apply the operations and placed buttons.

<img src="https://github.com/unalyagiz/MyHospitalMVC_ASP.NET/blob/master/trunk/images/4.png" />
<img src="https://github.com/unalyagiz/MyHospitalMVC_ASP.NET/blob/master/trunk/images/5.png" />

When HttpPost method is triggered the page will reload and the ViewBag is no longer have any data so first I had the data in TempData and then passed it into ViewBag.

<img src="https://github.com/unalyagiz/MyHospitalMVC_ASP.NET/blob/master/trunk/images/6.png" />

At the deletion operation,I wanted to display a MODAL to ask user “are you sure ?”.And if delete is selected then it will return the doctors id to Delete method with AJAX call.

<img src="https://github.com/unalyagiz/MyHospitalMVC_ASP.NET/blob/master/trunk/images/7.png" />

## Week 4
At the fourth week of my internship,I needed to create a form for patients.So I imported patient MODEL into VIEW and created textboxes and dropdowns for patient properties.In the dropdown list when the patient selects the particular branch,second dropdown will automatically filled with its doctors.

<img src="https://github.com/unalyagiz/MyHospitalMVC_ASP.NET/blob/master/trunk/images/8.png" />

This interaction is possible with JavaScript. I wrote down the following code to return the selected branch id to controller and compared with doctors table to return the lists of doctors.

<img src="https://github.com/unalyagiz/MyHospitalMVC_ASP.NET/blob/master/trunk/images/9.png" />
<img src="https://github.com/unalyagiz/MyHospitalMVC_ASP.NET/blob/master/trunk/images/10.png" />

As I mentioned before I have applied Client-side and Server-Side validation to this form too.This is the result of Client-side validation by  JQUERY.It will detect the local language.(Turkish in this case)

<img src="https://github.com/unalyagiz/MyHospitalMVC_ASP.NET/blob/master/trunk/images/11.png" width="300" height="250" />

At the last days of my internship,I have created some buttons to represent the appointment hours.So in my PatientController I have created a method to pass the times of appointment to view.In patient view I have used partial view to show the appointment date and hours because I wanted date and time interactive with each other.
My purpose was when the user clicks the doctor it will search into appointments of the selected doctor and shown the available hours.
</br>
<img src="https://github.com/unalyagiz/MyHospitalMVC_ASP.NET/blob/master/trunk/images/12.png"   />



