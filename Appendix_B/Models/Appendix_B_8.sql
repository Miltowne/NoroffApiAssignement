SELECT *
FROM Customer
INNER JOIN Invoice
ON Customer.CustomerId = Invoice.CustomerId
ORDER BY Invoice.Total DESC