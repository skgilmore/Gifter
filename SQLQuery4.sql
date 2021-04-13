SELECT p.Title, p.Caption, p.DateCreated, p.ImageUrl, p.id,
                                     p.UserProfileId,

                       up.Name, up.Bio, up.Email, up.DateCreated AS UserProfileDateCreated,
                       up.ImageUrl AS UserProfileImageUrl, up.Id AS PostUserProfileId,
                       c.PostId, c.Message, c.Id as CommentId

                            FROM Post p
                             LEFT JOIN UserProfile  up ON p.UserProfileId= up.id
                             LEFT JOIN Comment c ON p.Id = c.PostId
                          WHERE p.id = 1