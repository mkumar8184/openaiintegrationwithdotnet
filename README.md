
## Open AI/ chat gpt api integration with .net /.core & database
## create account in open ai and get api key to authenticate httpclient request
1.  Login : https://platform.openai.com/docs/overview
2. create project. 
3. generate api keys and copy to use in application
![image](https://github.com/user-attachments/assets/05767094-fe69-486f-a856-b4ff0f5b2d15)

### Important : you must pay atleast 5 $ ,else it wont work , charges are very less so you can use for more activities  .
![image](https://github.com/user-attachments/assets/5e728077-d6d6-4818-a8a7-8447343aeb56)

## in attached code 
you will get employee details from db/json and send  get employee details based on your given prompt.
This code will help you for followings:
1. how to implement open ai api
2. created seperate service for open ai 
3. db example use in json file
4. save user search history in json file
5. return response in needed object
6. User search result will be saved in json file/db
7. To analyse any data based on given prompt 

## Examples: let say we have employeedb.json file with below record

{
 "Employees": [
    {
      "EmployeeId": "00001",
      "EmployeeName": "John Doe",
      "DateOfBirth": "1985-05-05",
      "Nationality": "American",
      "Position": "Software Engineer",
      "Department": "Development",
      "Manager": "Jane Smith"
    },
  {
    "EmployeeId": "00002",
    "EmployeeName": "Alice Johnson",
    "DateOfBirth": "1990-08-12",
    "Nationality": "Canadian",
    "Position": "Project Manager",
    "Department": "Project Management",
    "Manager": "Jane Smith"
  },
    {
      "EmployeeId": "00003",
      "EmployeeName": "Bob Brown",
      "DateOfBirth": "1982-03-23",
      "Nationality": "British",
      "Position": "UX Designer",
      "Department": "Design",
      "Manager": "Alice Johnson"
    },
    {
      "EmployeeId": "00004",
      "EmployeeName": "Emily Davis",
      "DateOfBirth": "1995-11-30",
      "Nationality": "Australian",
      "Position": "Data Analyst",
      "Department": "Analytics",
      "Manager": "Jane Smith"
    },
    {
      "EmployeeId": "00005",
      "EmployeeName": "Jane Smith",
      "DateOfBirth": "1980-02-15",
      "Nationality": "American",
      "Position": "Senior Manager",
      "Department": "Development",
      "Manager": null
    }
  ]
}

## get list of employee who has position title "Project Manager"
![image](https://github.com/user-attachments/assets/89e05ed7-e5b2-4b2a-be3d-b61a0b361c20)

## Response
![image](https://github.com/user-attachments/assets/a9091776-446b-4756-911c-f8c30133be07)

## get list of employee who reports to  "Jane Smith"
![image](https://github.com/user-attachments/assets/6cc0c401-42c7-4747-9209-0282b6688685)
## Response
![image](https://github.com/user-attachments/assets/646d8759-ec8f-436c-bc63-c46306d24174)


connect if you need to know more ....
Thanks 

