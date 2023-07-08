BEGIN
	INSERT INTO com_Roles (Uuid, RoleName, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt) VALUES
	('urn:roles:ddcf7e0b-7e0c-42cd-82e4-8268bc1ac9f2', 'Guest', 'System', GETUTCDATE(), 'System', GETUTCDATE()),
	('urn:roles:6fbc9b7d-e714-44c8-a1c5-e247a0bab966', 'Driver', 'System', GETUTCDATE(), 'System', GETUTCDATE()),
	('urn:roles:cf30b68d-7f99-4fdc-a7aa-997142a7271d', 'TravelAgent', 'System', GETUTCDATE(), 'System', GETUTCDATE())
END
GO