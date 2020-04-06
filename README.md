Run DB script file ContactInfoDBScript.sql
Change Connection String accordingly.
Open Solution file.
Use POSTMAN/FIDDLER to test api


URL 
1. GetAllContactDetails- /api/ContactInfo/GetAllContactInfo
2. SaveContactDetails - /api/ContactInfo/SaveContactInfo
   JSON : 
   {
        "FirstName": "a",
        "LastName": "a",
        "Email": "asd@11.com",
        "PhoneNumber": "1231231231",
        "IsActive": true
    }
    
 3. EditContactDetails- /api/ContactInfo/EditContactInfo
    JSON :  (Provide ID of record which we want to edit)
     {
        "Id": 2, 
        "FirstName": "nikhil",
        "LastName": "asd1",
        "Email": "asd1@asd.com",
        "PhoneNumber": "123123",
        "IsActive": true
    }
    
  4.DeleteContactDetails - /api/ContactInfo/DeleteContactInfo?id=1 (Provide ID of record which we want to delete)
