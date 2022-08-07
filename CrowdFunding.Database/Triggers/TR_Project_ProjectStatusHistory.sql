-- This trigger creates a new ProjectStatusHistory entry whenever the ProjectStatusId foreign key of a Project is modified

CREATE TRIGGER [TR_Project_ProjectStatusHistory]
	ON [Project]
	FOR UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		DECLARE @StatusId INT  = (SELECT ([ProjectStatusId]) FROM deleted), @ProjectId INT = (SELECT ([Id]) FROM deleted)
		IF (@StatusId <> (SELECT ([ProjectStatusId]) FROM inserted))
		BEGIN
			INSERT INTO ProjectStatusHistory([ProjectId], [ProjectStatusId])
			VALUES (@ProjectId, @StatusId)
		END
	END

--