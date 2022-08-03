-- -- This trigger update the LastModified time of Comments upon modification

CREATE TRIGGER [TR_Comment_LastModified]
	ON [Comment]
	FOR  UPDATE
	AS
		UPDATE [Comment]
		SET [LastModified] = SYSDATETIME()
		WHERE [Id] IN (SELECT DISTINCT [Id] FROM inserted)
