-- Kiểm tra và xóa bảng RoomsStatus nếu tồn tại
IF OBJECT_ID('dbo.RoomsStatus', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.RoomsStatus;
END
GO

-- Tạo bảng RoomsStatus mới
CREATE TABLE dbo.RoomsStatus (
    [RoomsStatusId] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[RoomsStatusCode] [nvarchar](100) NOT NULL,
	[RoomsStatusName] [nvarchar](100) NOT NULL,
	[RoomsStatusColor] [nvarchar](200) NOT NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
);
GO