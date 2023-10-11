/****** Creates a prepared statement that logs in to the password manager and returns the user id which will be used later on ******/

CREATE OR ALTER PROCEDURE USER_MASTER_LOGIN 
	-- Add the parameters for the stored procedure here
	@Username nvarchar(255)= null,
	@Password varbinary = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	SELECT Guid FROM [User] WHERE Username = @Username AND Password = @Password

END
GO


CREATE OR ALTER PROCEDURE USER_MASTER_CREATE 
	-- Add the parameters for the stored procedure here
	@Guid uniqueidentifier = null,
	@Username nvarchar(255) = null,
	@Password varbinary = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @Guid IS NOT NULL
		IF EXISTS (SELECT 1 FROM [User] WHERE Guid = @Guid)
			UPDATE [User] SET Guid = @Guid, Username = @Username, Password = @Password
		ELSE 
			INSERT INTO [User] (Guid, Username, Password)
				VALUES (@Guid, @Username, @Password)
		ELSE 
			THROW 50001, 'ERROR UPDATING VAULT: SLIPSPACE RUPTURE DETECTED',1
END
GO


/****** Creates a prepared statement that fetches passwords from the password manager ******/

CREATE OR ALTER PROCEDURE GET_VAULT 
	-- Add the parameters for the stored procedure here
	@ownerGuid uniqueidentifier = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @ownerGuid IS NOT NULL
		SELECT U.Guid, E.Sitename, E.Username, E.Password
		FROM EncryptedVault E 
			JOIN [User] U ON U.Guid = E.Userguid
		WHERE E.Userguid = @ownerGuid
	ELSE 
		THROW 50001, 'Error fetching vault',1
END
GO


/****** Creates a prepared statement that adds news passwords to the password manager ******/

CREATE OR ALTER PROCEDURE CREATE_VAULT 
	-- Add the parameters for the stored procedure here
	@Userguid uniqueidentifier = null,
	@Sitename varbinary = null,
	@Username varbinary = null,
	@Password varbinary = null

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @Userguid IS NOT NULL
		IF EXISTS (SELECT 1 FROM EncryptedVault WHERE Userguid = @Userguid AND Sitename = @Sitename)
			UPDATE EncryptedVault SET Sitename = @Sitename, Username = @Username, Password = @Password
		ELSE 
			INSERT INTO EncryptedVault (Userguid, Sitename, Username, Password)
				VALUES (@Userguid, @Sitename, @Username, @Password)
		ELSE 
			THROW 50001, 'ERROR UPDATING VAULT: SLIPSPACE RUPTURE DETECTED',1
		
END
GO
