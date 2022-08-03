SELECT Info.PayInfo.AdeptRef, Info.UserInfo.UserInfoID
FROM Info.UserInfo RIGHT OUTER JOIN
Info.PayInfo ON Info.UserInfo.UserInfoID = Info.PayInfo.UserInfoID