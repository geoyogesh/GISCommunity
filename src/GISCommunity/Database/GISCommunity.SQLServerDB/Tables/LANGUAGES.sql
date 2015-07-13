﻿CREATE TABLE [GISC].[LANGUAGES](
	[LANGUAGE] [NVARCHAR](100) NOT NULL,
	[CULTURE] [NVARCHAR](10),
	[LOCALIZEDNAME] [NVARCHAR](100) NOT NULL,
	CONSTRAINT PK_LANGUAGES_CULTURE PRIMARY KEY CLUSTERED (CULTURE), 
    CONSTRAINT [FK_REGIONS_LANGUAGES] FOREIGN KEY ([CULTURE]) REFERENCES [GISC].[LANGUAGES]([CULTURE])
) ON [PRIMARY]