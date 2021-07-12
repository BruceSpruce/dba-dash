﻿CREATE TABLE dbo.AvailabilityReplicas(
	   InstanceID INT NOT NULL,
	   replica_id UNIQUEIDENTIFIER NOT NULL,
       group_id UNIQUEIDENTIFIER NOT NULL,
       replica_metadata_id INT NULL,
       replica_server_name NVARCHAR(256) NOT NULL,
       endpoint_url NVARCHAR(128) NOT NULL,
       availability_mode TINYINT NOT NULL,
       failover_mode TINYINT NOT NULL,
       session_timeout INT NOT NULL,
       primary_role_allow_connections TINYINT NOT NULL,
       secondary_role_allow_connections TINYINT NOT NULL,
       create_date DATETIME NULL,
       modify_date DATETIME NULL,
       backup_priority INT NOT NULL,
       read_only_routing_url NVARCHAR(256) NULL,
       seeding_mode TINYINT NOT NULL,
       read_write_routing_url NVARCHAR(256) NULL,
       availability_mode_desc AS (CASE availability_mode WHEN 0 THEN N'ASYNCHRONOUS_COMMIT' WHEN 1 THEN N'SYNCHRONOUS_COMMIT' WHEN 4 THEN N'CONFIGURATION_ONLY' ELSE CONVERT(NVARCHAR(60),availability_mode) END),
       failover_mode_desc AS (CASE failover_mode WHEN 0 THEN N'AUTOMATIC' WHEN 1 THEN N'MANUAL' ELSE CONVERT(NVARCHAR(60),failover_mode) END),
       primary_role_allow_connections_desc AS (CASE primary_role_allow_connections WHEN 2 THEN N'ALL' WHEN 3 THEN N'READ_WRITE' ELSE CONVERT(NVARCHAR(60),primary_role_allow_connections) END),
       secondary_role_allow_connections_desc AS (CASE secondary_role_allow_connections WHEN 0 THEN N'NO' WHEN 1 THEN N'READ_ONLY' WHEN 2 THEN N'ALL' ELSE CONVERT(NVARCHAR(60),secondary_role_allow_connections) END),
       seeding_mode_desc AS (CASE seeding_mode WHEN 0 THEN N'AUTOMATIC' WHEN 1 THEN N'MANUAL' ELSE CONVERT(NVARCHAR(60),seeding_mode) END),
	   CONSTRAINT FK_AvailabilityReplicas_Instances FOREIGN KEY(InstanceID) REFERENCES dbo.Instances(InstanceID),
	   CONSTRAINT PK_AvailabilityReplicas PRIMARY KEY(InstanceID,replica_id)
)