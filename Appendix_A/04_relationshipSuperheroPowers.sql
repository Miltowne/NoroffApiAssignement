ALTER TABLE SuperheroPowers
ADD PowersId int,
CONSTRAINT FK_SuperheroPowers FOREIGN KEY (PowersId) REFERENCES Powers(PowersId),
SuperheroId int,
CONSTRAINT FK_PowersSuperhero FOREIGN KEY (SuperheroId) REFERENCES Superhero(SuperheroId);