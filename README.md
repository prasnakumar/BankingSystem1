# BankingSystem
1.first in the appsetting.json change the db name to the required type 
"DevConnection": "Server=(**Db name here** );Database=BankingDB;Trusted_Connection=True;MultipleActiveResultSets=True;"


2. make sure you microsoft sql server is on and connected 

3. install the following dependence 

a)microsoft.entityframeworkcore
b)microsoft.entityframeworkcore.Design
c)microsoft.entityframeworkcore.sqlserver
d)microsoft.entityframeworkcore.Tools
e)microsoft.entityframeworkcore.authentication

4. run the program 



5.open postman and use the following url 
a) To Add user use **https://localhost:44375/api/Person** method put
b)insert this JSON file 
{
        
        "name": "NewUser",
        "password": "1234"
    } ( id will be generated ) 
    
    
    
    
c) once the User is created to withdraw or deposit use 
  . to withdraw https://localhost:44375/api/Person/withdraw/(/* add money like here 12100*/)
  and click on **basic auth** and enter username and password that is created using in step a
  . to deposit https://localhost:44375/api/Person/deposit/(/* add money 12100 */)
   and click on basic auth and enter username and password that is created using in step a
  
  
 points : if the money cant be withdrawn  then it will be giving a response cant withdraw 
 
 6) to view all the data use https://localhost:44375/api/Person 
