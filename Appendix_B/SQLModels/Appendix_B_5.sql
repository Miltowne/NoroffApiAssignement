INSERT INTO Customer (FirstName, LastName, Company, Address, City, State, Country, PostalCode, Phone, Fax, Email ) 
VALUES ('Sanjin', 'Andersson', 'Experis', 'Trädgårdsgatan', 'Linköping', 'Östergötland', 'Sweden', '60224', '0736547856', '01147895478', 'Sanjin.Andersson@gmail.com');

select * from Customer where FirstName = 'Sanjin';