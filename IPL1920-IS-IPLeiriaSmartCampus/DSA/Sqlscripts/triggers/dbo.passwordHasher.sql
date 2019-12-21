CREATE TRIGGER [passwordHasher]
	ON [dbo].[t_users]
	INSTEAD OF INSERT
	AS
	BEGIN
		SET NOCOUNT ON
		INSERT t_users
		select HASHBYTES('MD5','@!98ABc'+password)
		from inserted
	END
	GO