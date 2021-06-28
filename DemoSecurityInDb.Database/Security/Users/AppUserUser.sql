CREATE USER [AppUserUser]
	FOR LOGIN [AppUserLogin]
	WITH DEFAULT_SCHEMA = [AppUserSchema];

GO

GRANT CONNECT TO [AppUserUser]
