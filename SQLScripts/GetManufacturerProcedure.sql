USE ShopAdo;
GO

CREATE PROCEDURE dbo.GetManufacturer
	@ManufacturerId INT = NULL
AS
	BEGIN
		IF(@ManufacturerId IS NULL)
			SELECT *
			FROM dbo.Manufacturer
		ELSE
			SELECT *
			FROM dbo.Manufacturer
			WHERE ManufacturerId = @ManufacturerId
	END

EXEC dbo.GetManufacturer 4

CREATE PROCEDURE dbo.InsertCategory
	@CategoryName NVARCHAR(100),
	@CategoryId INT OUTPUT
AS
	BEGIN
		INSERT INTO dbo.Category (CategoryName)
		VALUES (@CategoryName);
		
		SET @CategoryId = SCOPE_IDENTITY();
	END
	
DECLARE @CategoryId INT = 0;
EXEC dbo.InsertCategory "Test", @CategoryId OUTPUT
SELECT @CategoryId