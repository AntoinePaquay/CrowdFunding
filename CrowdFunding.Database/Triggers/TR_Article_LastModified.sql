-- This trigger update the LastModified time of Articles upon modification

CREATE TRIGGER [TR_Article_LastModified]
	ON [Article]
	FOR  UPDATE
	AS
		UPDATE [Article]
		SET [LastModified] = SYSDATETIME()
		WHERE [Id] IN (SELECT DISTINCT [Id] FROM inserted)
