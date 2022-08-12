	DECLARE @CustomerId int=1;

	with allCustomerGenres as (
    SELECT genre.name, COUNT(Genre.GenreId) AS genre_count
        FROM genre
            JOIN track
            ON Genre.GenreId = Track.GenreId
                JOIN InvoiceLine
                ON InvoiceLine.TrackId = Track.TrackId
                    JOIN Invoice
                    ON Invoice.InvoiceId= InvoiceLine.InvoiceId
                        JOIN Customer
                        ON Invoice.CustomerId = Customer.CustomerId
        WHERE Customer.CustomerId = @CustomerId
        GROUP BY genre.name
)
(SELECT * FROM allCustomerGenres 
    JOIN (SELECT MAX(genre_count) as max_count FROM allCustomerGenres) tbl
    ON allCustomerGenres.genre_count = tbl.max_count)