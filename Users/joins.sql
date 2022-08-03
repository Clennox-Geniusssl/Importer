USE Users
GO

SELECT Info.UserInfo.UserInfoID,
Info.PayInfo.AdeptRef
FROM Info.UserInfo
INNER JOIN Info.PayInfo
ON AdeptRef = 'A117753'