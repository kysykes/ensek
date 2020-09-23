CREATE TABLE [EnSek].[MeterReading]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[MeterReadingValue] INT NOT NULL,
	[MeterReadingDateTime] DATETIME NOT NULL,
	[AccountId] INT NOT NULL
	CONSTRAINT FK_AccountId FOREIGN KEY (AccountId) 
	REFERENCES EnSek.Account (AccountId)
	ON DELETE CASCADE
)
