/*

SELECT *
FROM Info.UserInfo U
left OUTER JOIN Info.PayInfo P
ON U.UserInfoID = P.AdeptRef;

*/

/*
SELECT * 
FROM Info.UserInfo U
FULL OUTER JOIN Info.PayInfo p 
ON U.UserInfoID = p.AdeptRef;
*/

SELECT CAST
(UserInfoID AS NVARCHAR(10) ) from Info.UserInfo;