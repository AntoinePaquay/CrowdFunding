--CREATE TRIGGER [TR_Project_ParameterHistory]
--	ON [Project]
--	FOR UPDATE
--	AS
--	BEGIN
--		DECLARE @Goal DECIMAL, @Closing DATETIME2
--		DECLARE modified_rows CURSOR
--		FOR (SELECT [Id], [Goal], [Closing] FROM deleted);

--		OPEN modified_rows;

--		FETCH NEXT FROM modified_ROWS INTO @Id, @Goal, @Closing;

--		WHILE @@FETCH_STATUS = 0
--			BEGIN
--				IF ((@Goal <> (SELECT [Goal] FROM inserted WHERE [Id] = @Id) 
--				OR (@Closing  <> (SELECT [Closing] FROM inserted WHERE [Id] = @Id))
--				BEGIN
--					INSERT INTO ParameterHistory([Goal], [Closing])
--					VALUES (@Goal, @Closing)
--				END
--			END;
--	END


-- Workaround for this bug: Not supporting multiple row updates.


-- This trigger creates a new ParameterHistory entry whenever the Goal or Closing columns of a Project are modified

CREATE TRIGGER [TR_Project_ParameterHistory]
	ON [Project]
	FOR UPDATE
	AS 
	BEGIN
		DECLARE @Goal DECIMAL = (SELECT ([Goal]) FROM deleted), @Closing DATETIME2 = (SELECT ([Closing]) FROM deleted)
		IF (@Goal <> (SELECT ([Goal]) FROM inserted) OR @Closing <> (SELECT ([Closing]) FROM inserted))
		BEGIN
			INSERT INTO ParameterHistory([Goal], [Closing])
			VALUES (@Goal, @Closing);
		END
	END