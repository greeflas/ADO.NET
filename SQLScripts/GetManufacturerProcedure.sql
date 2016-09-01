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