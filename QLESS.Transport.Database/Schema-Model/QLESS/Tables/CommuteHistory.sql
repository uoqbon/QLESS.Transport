CREATE TABLE [QLESS].[CommuteHistory]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [CardId] BIGINT NOT NULL, 
    [StationId] INT NOT NULL, 
    [IsDeparture] BIT NOT NULL, 
    [CreatedDate] DATETIME2(0) NOT NULL
)
GO
ALTER TABLE [QLESS].[CommuteHistory] ADD CONSTRAINT [FK_CommuteHistory_CardId] FOREIGN KEY ([CardId]) REFERENCES [QLESS].[Card] ([Id])
GO
ALTER TABLE [QLESS].[CommuteHistory] ADD CONSTRAINT [FK_CommuteHistory_StationId] FOREIGN KEY ([StationId]) REFERENCES [QLESS].[Station] ([Id])
GO