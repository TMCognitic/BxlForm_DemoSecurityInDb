GRANT EXECUTE, SELECT ON SCHEMA::[AppUserSchema] TO [AppUserRole];
GO

ALTER ROLE [AppUserRole]
ADD MEMBER [AppUserUser];
