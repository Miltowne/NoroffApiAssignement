CREATE TABLE Superhero (
    SuperheroId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name varchar(50),
    Alias varchar(50),
    Origin varchar(50)
);
CREATE TABLE Assistant (
    AssistantId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name varchar(50)
);
CREATE TABLE Powers (
    PowersId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name varchar(50),
    Description varchar(50)
);