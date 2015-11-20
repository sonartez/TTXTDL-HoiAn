using Sonartez.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class UpdateController : ApiController
    {
        // GET api/update

        public string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>
        /// Get SERVER TABLE LASTUPDATE TIME
        /// </summary>
        /// <returns></returns>
        public TblUpdate GetUpdateStatus()
        {
            TblUpdate u = new TblUpdate();
            using (Sonartez_server db = new Sonartez_server(connectionString))
            {
                var q =
                from a in db.TblUpdate
                select a;
                u = q.FirstOrDefault<TblUpdate>();
            }
            return u;
        }

        public DateTime GetServerTime()
        {
            
            return DateTime.UtcNow;
        }

        public string  GetPostServerTime(DateTime time)
        {

            return time.ToString();
        }

        public string GetPostUTCServerTime(DateTime time)
        {

            return time.ToUniversalTime().ToString();
        }

        [HttpGet]
        public IEnumerable<TblClient> GetClient(DateTime lastUpdateDate)
        {
            lastUpdateDate = lastUpdateDate.AddSeconds(1);
            List<TblClient> u = new List<TblClient>();
            using (Sonartez_server db = new Sonartez_server(connectionString))
            {
                var q =
                from a in db.TblClient
                where a.ServerUpdate > lastUpdateDate
                select a;
                u = q.ToList();
            }
            return u;
        }

        [HttpGet]
        public IEnumerable<TblActivityLog> GetActivityLog(DateTime lastUpdateDate)
        {
            lastUpdateDate = lastUpdateDate.AddSeconds(1);
            List<TblActivityLog> u = new List<TblActivityLog>();
            using (Sonartez_server db = new Sonartez_server(connectionString))
            {
                var q =
                from a in db.TblActivityLog
                where a.ServerUpdate > lastUpdateDate
                select a;
                u = q.ToList();
            }
            return u;
        }

        [HttpGet]
        public IEnumerable<TblConsultantLog> GetConsultantLog(DateTime lastUpdateDate)
        {
            lastUpdateDate = lastUpdateDate.AddSeconds(1);
            List<TblConsultantLog> u = new List<TblConsultantLog>();
            using (Sonartez_server db = new Sonartez_server(connectionString))
            {
                var q =
                from a in db.TblConsultantLog
                where a.ServerUpdate > lastUpdateDate
                select a;
                u = q.ToList();
            }
            return u;
        }

        [HttpGet]
        public IEnumerable<TblInfor> GetInfor(DateTime lastUpdateDate)
        {
            lastUpdateDate = lastUpdateDate.AddSeconds(1);
            List<TblInfor> u = new List<TblInfor>();
            using (Sonartez_server db = new Sonartez_server(connectionString))
            {
                var q =
                from a in db.TblInfor
                where a.ServerUpdate > lastUpdateDate
                select a;
                u = q.ToList();
            }
            return u;
        }

        [HttpGet]
        public IEnumerable<TblUser> GetUser(DateTime lastUpdateDate)
        {
            lastUpdateDate = lastUpdateDate.AddSeconds(1);
            List<TblUser> u = new List<TblUser>();
            using (Sonartez_server db = new Sonartez_server(connectionString))
            {
                var q =
                from a in db.TblUser
                where a.ServerUpdate > lastUpdateDate
                select a;
                u = q.ToList();
            }
            return u;
        }

        [HttpGet]
        public IEnumerable<TblUser> GetAllUser()
        {
            List<TblUser> u = new List<TblUser>();
            using (Sonartez_server db = new Sonartez_server(connectionString))
            {
                var q =
                from a in db.TblUser
                select a;
                u = q.ToList();
            }
            return u;
        }

        [HttpGet]
        public IEnumerable<TblUserPermission> GetUserPermission(DateTime lastUpdateDate)
        {
            lastUpdateDate = lastUpdateDate.AddSeconds(1); //lastUpdateDate.ToUniversalTime();
            List<TblUserPermission> u = new List<TblUserPermission>();
            using (Sonartez_server db = new Sonartez_server(connectionString))
            {
                var q =
                from a in db.TblUserPermission
                where a.ServerUpdate > lastUpdateDate
                select a;
                u = q.ToList();
            }
            return u;
        }

        [HttpPost]
        public APIResult UpdateClient(TblClient data)
        {
            APIResult res = new APIResult();
            using (Sonartez_server db = new Sonartez_server(connectionString))
            {
                var matchedObj = (from c in db.TblClient
                                  where c.ClientID == data.ClientID
                                  select c).SingleOrDefault();

                if (matchedObj == null)
                {
                    try
                    {
                        // does not exist
                        Table<TblClient> TblObj = db.TblClient;
                        data.ServerUpdate  = DateTime.UtcNow;
                        TblObj.InsertOnSubmit(data);
                        TblObj.Context.SubmitChanges();

                        res.UpdateDate = DateTime.UtcNow;
                        res.Success = true;

                    }
                    catch (Exception ex)
                    {
                        res.Message = ex.Message;
                        res.Success = false;
                    }
                }
                else
                {
                    try
                    {
                        matchedObj.ClientCode = data.ClientCode;
                        matchedObj.ClientName = data.ClientName;
                        matchedObj.Descriptions = data.Descriptions;
                        matchedObj.LocationCode = data.LocationCode;
                        matchedObj.LocationName = data.LocationName;
                        matchedObj.ServerUpdate  = DateTime.UtcNow;
                        matchedObj.UpdateDate = data.UpdateDate.Value;
                        db.SubmitChanges();

                        res.UpdateDate = DateTime.UtcNow;
                        res.Success = true;
                    }
                    catch (Exception ex)
                    {
                        res.Message = ex.Message;
                        res.Success = false;
                    }
                }

            }
            return res;
        }

        [HttpPost]
        public APIResult UpdateClients(IEnumerable<TblClient> dataList)
        {
            APIResult res = new APIResult();
            using (Sonartez_server db = new Sonartez_server(connectionString))
            {
                foreach (var data in dataList)
                {
                    var matchedObj = (from c in db.TblClient
                                      where c.ClientID == data.ClientID
                                      select c).SingleOrDefault();

                    if (matchedObj == null)
                    {
                        try
                        {
                            // does not exist
                            Table<TblClient> TblObj = db.TblClient;
                            data.ServerUpdate  = DateTime.UtcNow;
                            TblObj.InsertOnSubmit(data);
                            TblObj.Context.SubmitChanges();

                            res.UpdateDate = DateTime.UtcNow;
                            res.Success = true;
                        }
                        catch (Exception ex)
                        {
                            res.Message = ex.Message;
                            res.Success = false;
                            break;
                        }
                    }
                    else
                    {
                        try
                        {
                            matchedObj.ClientCode = data.ClientCode;
                            matchedObj.ClientName = data.ClientName;
                            matchedObj.Descriptions = data.Descriptions;
                            matchedObj.LocationCode = data.LocationCode;
                            matchedObj.LocationName = data.LocationName;
                            matchedObj.ServerUpdate  = DateTime.UtcNow;
                            matchedObj.UpdateDate = data.UpdateDate.Value;
                            db.SubmitChanges();

                            res.UpdateDate = DateTime.UtcNow;
                            res.Success = true;
                        }
                        catch (Exception ex)
                        {
                            res.Message = ex.Message;
                            res.Success = false;
                            break;
                        }
                    }
                }
            }
            return res;
        }

        [HttpPost]
        public APIResult UpdateActivityLog(TblActivityLog data)
        {
            APIResult res = new APIResult();
            using (Sonartez_server db = new Sonartez_server(connectionString))
            {
                var matchedObj = (from c in db.TblActivityLog
                                  where c.ID == data.ID
                                  select c).SingleOrDefault();

                if (matchedObj == null)
                {
                    try
                    {
                        // does not exist
                        Table<TblActivityLog> TblObj = db.TblActivityLog;
                        data.ServerUpdate  = DateTime.UtcNow;                       
                        TblObj.InsertOnSubmit(data);
                        TblObj.Context.SubmitChanges();

                        res.UpdateDate = DateTime.UtcNow;
                        res.Success = true;

                    }
                    catch (Exception ex)
                    {
                        res.Message = ex.Message;
                        res.Success = false;
                    }
                }
                else
                {
                    try
                    {
                        matchedObj.ActivityType = data.ActivityType;
                        matchedObj.ClientName = data.ClientName;
                        matchedObj.Descriptions = data.Descriptions;
                        matchedObj.ClientID = data.ClientID;
                        matchedObj.UserID = data.UserID;
                        matchedObj.UserName = data.UserName;
                        matchedObj.CreateDate = data.CreateDate;
                        matchedObj.ServerUpdate  = DateTime.UtcNow;
                        db.SubmitChanges();

                        res.UpdateDate = DateTime.UtcNow;
                        res.Success = true;
                    }
                    catch (Exception ex)
                    {
                        res.Message = ex.Message;
                        res.Success = false;
                    }
                }

            }
            return res;
        }

        [HttpPost]
        public APIResult UpdateActivityLogs(IEnumerable<TblActivityLog> dataList)
        {
            APIResult res = new APIResult();
            using (Sonartez_server db = new Sonartez_server(connectionString))
            {
                foreach (var data in dataList)
                {


                    var matchedObj = (from c in db.TblActivityLog
                                      where c.ID == data.ID
                                      select c).SingleOrDefault();

                    if (matchedObj == null)
                    {
                        try
                        {
                            // does not exist
                            Table<TblActivityLog> TblObj = db.TblActivityLog;
                            data.ServerUpdate  = DateTime.UtcNow;
                            TblObj.InsertOnSubmit(data);
                            TblObj.Context.SubmitChanges();
                            res.UpdateDate = DateTime.UtcNow;
                            res.Success = true;

                        }
                        catch (Exception ex)
                        {
                            res.Message = ex.Message;
                            res.Success = false;
                        }
                    }
                    else
                    {
                        try
                        {
                            matchedObj.ActivityType = data.ActivityType;
                            matchedObj.ClientName = data.ClientName;
                            matchedObj.Descriptions = data.Descriptions;
                            matchedObj.ClientID = data.ClientID;
                            matchedObj.UserID = data.UserID;
                            matchedObj.UserName = data.UserName;
                            matchedObj.IsDeleted = data.IsDeleted;
                            matchedObj.ServerUpdate  = DateTime.UtcNow;
                            matchedObj.CreateDate = data.CreateDate.Value;
                            db.SubmitChanges();

                            res.UpdateDate = DateTime.UtcNow;
                            res.Success = true;
                        }
                        catch (Exception ex)
                        {
                            res.Message = ex.Message;
                            res.Success = false;
                        }
                    }

                }
                return res;
            }
        }

        [HttpPost]
        public APIResult UpdateConsultantLog(TblConsultantLog data)
        {
            APIResult res = new APIResult();
            using (Sonartez_server db = new Sonartez_server(connectionString))
            {
                var matchedObj = (from c in db.TblConsultantLog
                                  where c.ID == data.ID
                                  select c).SingleOrDefault();

                if (matchedObj == null)
                {
                    try
                    {
                        // does not exist
                        Table<TblConsultantLog> TblObj = db.TblConsultantLog;
                        data.ServerUpdate  = DateTime.UtcNow;
                        TblObj.InsertOnSubmit(data);
                        TblObj.Context.SubmitChanges();

                        res.UpdateDate = DateTime.UtcNow;
                        res.Success = true;

                    }
                    catch (Exception ex)
                    {
                        res.Message = ex.Message;
                        res.Success = false;
                    }
                }
                else
                {
                    try
                    {
                        matchedObj.AnswerRef = data.AnswerRef;
                        matchedObj.ClientCode = data.ClientCode;
                        matchedObj.ClientID = data.ClientID;
                        matchedObj.ClientName = data.ClientName;
                        matchedObj.ConsType = data.ConsType;
                        matchedObj.CreateDate = data.CreateDate;
                        matchedObj.Descriptions = data.Descriptions;
                        matchedObj.FinishDate = data.FinishDate;
                        matchedObj.FinishType = data.FinishType;
                        matchedObj.Question = data.Question;
                        matchedObj.Status = data.Status;
                        matchedObj.SubmitDate = data.SubmitDate;
                        matchedObj.TargetCount = data.TargetCount;
                        matchedObj.TargetCountry = data.TargetCountry;
                        matchedObj.TargetEmail = data.TargetEmail;
                        matchedObj.TargetName = data.TargetName;
                        matchedObj.TargetPhoneNumber = data.TargetPhoneNumber;
                        matchedObj.TargetType = data.TargetType;
                        matchedObj.UserID = data.UserID;
                        matchedObj.UserName = data.UserName;
                        matchedObj.ServerUpdate  = DateTime.UtcNow;
                        matchedObj.UpdateDate = data.UpdateDate.Value;
                        db.SubmitChanges();

                        res.UpdateDate = DateTime.UtcNow;
                        res.Success = true;
                    }
                    catch (Exception ex)
                    {
                        res.Message = ex.Message;
                        res.Success = false;
                    }
                }

            }
            return res;
        }

        [HttpPost]
        public APIResult UpdateConsultantLogs(IEnumerable<TblConsultantLog> dataList)
        {
              APIResult res = new APIResult();
              using (Sonartez_server db = new Sonartez_server(connectionString))
              {
                  foreach (var data in dataList)
                  {
                      var matchedObj = (from c in db.TblConsultantLog
                                        where c.ID == data.ID
                                        select c).SingleOrDefault();

                      if (matchedObj == null)
                      {
                          try
                          {
                              // does not exist
                              Table<TblConsultantLog> TblObj = db.TblConsultantLog;
                              data.ServerUpdate  = DateTime.UtcNow;
                              TblObj.InsertOnSubmit(data);
                              TblObj.Context.SubmitChanges();

                              res.UpdateDate = DateTime.UtcNow;
                              res.Success = true;

                          }
                          catch (Exception ex)
                          {
                              res.Message = ex.Message;
                              res.Success = false;
                          }
                      }
                      else
                      {
                          try
                          {
                              matchedObj.AnswerRef = data.AnswerRef;
                              matchedObj.ClientCode = data.ClientCode;
                              matchedObj.ClientID = data.ClientID;
                              matchedObj.ClientName = data.ClientName;
                              matchedObj.ConsType = data.ConsType;
                              matchedObj.CreateDate = data.CreateDate;
                              matchedObj.Descriptions = data.Descriptions;
                              matchedObj.FinishDate = data.FinishDate;
                              matchedObj.FinishType = data.FinishType;
                              matchedObj.Question = data.Question;
                              matchedObj.Status = data.Status;
                              matchedObj.SubmitDate = data.SubmitDate;
                              matchedObj.TargetCount = data.TargetCount;
                              matchedObj.TargetCountry = data.TargetCountry;
                              matchedObj.TargetEmail = data.TargetEmail;
                              matchedObj.TargetName = data.TargetName;
                              matchedObj.TargetPhoneNumber = data.TargetPhoneNumber;
                              matchedObj.TargetType = data.TargetType;
                              matchedObj.UserID = data.UserID;
                              matchedObj.UserName = data.UserName;
                              matchedObj.ServerUpdate  = DateTime.UtcNow;
                              matchedObj.UpdateDate = data.UpdateDate.Value;
                              matchedObj.IsDeleted = data.IsDeleted;
                              db.SubmitChanges();

                              res.UpdateDate = DateTime.UtcNow;
                              res.Success = true;
                          }
                          catch (Exception ex)
                          {
                              res.Message = ex.Message;
                              res.Success = false;
                          }
                      }

                  }
                 
              } 
            return res;
        }

        [HttpPost]
        public APIResult UpdateInfor(TblInfor data)
        {
            APIResult res = new APIResult();
            using (Sonartez_server db = new Sonartez_server(connectionString))
            {
                var matchedObj = (from c in db.TblInfor
                                  where c.ID == data.ID
                                  select c).SingleOrDefault();

                if (matchedObj == null)
                {
                    try
                    {
                        // does not exist
                        Table<TblInfor> TblObj = db.TblInfor;
                        data.ServerUpdate  = DateTime.UtcNow;
                        TblObj.InsertOnSubmit(data);
                        TblObj.Context.SubmitChanges();

                        res.UpdateDate = DateTime.UtcNow;
                        res.Success = true;

                    }
                    catch (Exception ex)
                    {
                        res.Message = ex.Message;
                        res.Success = false;
                    }
                }
                else
                {
                    try
                    {
                        matchedObj.BeginDate = data.BeginDate;
                        matchedObj.CreateDate = data.CreateDate;
                        matchedObj.CreateUserID = data.CreateUserID;
                        matchedObj.ExprieDate = data.ExprieDate;
                        matchedObj.InfoContent = data.InfoContent;
                        matchedObj.InfoTag = data.InfoTag;
                        matchedObj.InfoTitle = data.InfoTitle;
                        matchedObj.InfoType = data.InfoType;
                        matchedObj.Status = data.Status;
                        matchedObj.ServerUpdate  = DateTime.UtcNow;
                        matchedObj.Location = data.Location;
                        matchedObj.Category = data.Category;
                        matchedObj.IsDeleted = data.IsDeleted;
                        matchedObj.UpdateDate = data.UpdateDate.Value;
                        db.SubmitChanges();

                        res.UpdateDate = DateTime.UtcNow;
                        res.Success = true;
                    }
                    catch (Exception ex)
                    {
                        res.Message = ex.Message;
                        res.Success = false;
                    }
                }

            }
            return res;
        }

        [HttpPost]
        public APIResult UpdateInfors(IEnumerable<TblInfor> dataList)
        {
              APIResult res = new APIResult();
              using (Sonartez_server db = new Sonartez_server(connectionString))
              {
                  foreach (var data in dataList)
                  {
                      var matchedObj = (from c in db.TblInfor
                                        where c.ID == data.ID
                                        select c).SingleOrDefault();

                      if (matchedObj == null)
                      {
                          try
                          {
                              // does not exist
                              Table<TblInfor> TblObj = db.TblInfor;
                              data.ServerUpdate  = DateTime.UtcNow;
                              TblObj.InsertOnSubmit(data);
                              TblObj.Context.SubmitChanges();

                              res.UpdateDate = DateTime.UtcNow;
                              res.Success = true;

                          }
                          catch (Exception ex)
                          {
                              res.Message = ex.Message;
                              res.Success = false;
                          }
                      }
                      else
                      {
                          try
                          {
                              matchedObj.BeginDate = data.BeginDate;
                              matchedObj.CreateDate = data.CreateDate;
                              matchedObj.CreateUserID = data.CreateUserID;
                              matchedObj.ExprieDate = data.ExprieDate;
                              matchedObj.InfoContent = data.InfoContent;
                              matchedObj.InfoTag = data.InfoTag;
                              matchedObj.InfoTitle = data.InfoTitle;
                              matchedObj.InfoType = data.InfoType;
                              matchedObj.Status = data.Status;
                              matchedObj.ServerUpdate  = DateTime.UtcNow;
                              matchedObj.UpdateDate = data.UpdateDate.Value;
                              matchedObj.InfoContentHtml = data.InfoContentHtml;
                              matchedObj.IsDeleted = data.IsDeleted;
                              matchedObj.Category = data.Category;
                              matchedObj.Location = data.Location;
                              db.SubmitChanges();

                              res.UpdateDate = DateTime.UtcNow;
                              res.Success = true;
                          }
                          catch (Exception ex)
                          {
                              res.Message = ex.Message;
                              res.Success = false;
                          }
                      }

                  }
              }
            return res;
        }


        [HttpPost]
        public APIResult UpdateUser(TblUser data)
        {
            APIResult res = new APIResult();
            using (Sonartez_server db = new Sonartez_server(connectionString))
            {
                var matchedObj = (from c in db.TblUser
                                  where c.UserID == data.UserID
                                  select c).SingleOrDefault();

                if (matchedObj == null)
                {
                    try
                    {
                        // does not exist
                        Table<TblUser> TblObj = db.TblUser;
                        data.ServerUpdate  = DateTime.UtcNow;
                        TblObj.InsertOnSubmit(data);
                        TblObj.Context.SubmitChanges();

                        res.UpdateDate = DateTime.UtcNow;
                        res.Success = true;

                    }
                    catch (Exception ex)
                    {
                        res.Message = ex.Message;
                        res.Success = false;
                    }
                }
                else
                {
                    try
                    {
                        matchedObj.Active = data.Active;
                        matchedObj.Email = data.Email;
                        matchedObj.FullName = data.FullName;
                        matchedObj.LastLoginTime = data.LastLoginTime;
                        matchedObj.Password = data.Password;
                        matchedObj.PhoneNumber = data.PhoneNumber;
                        matchedObj.UserName = data.UserName;
                        matchedObj.ServerUpdate  = DateTime.UtcNow;
                        matchedObj.UpdateDate = data.UpdateDate.Value;
                        db.SubmitChanges();

                        res.UpdateDate = DateTime.UtcNow;
                        res.Success = true;
                    }
                    catch (Exception ex)
                    {
                        res.Message = ex.Message;
                        res.Success = false;
                    }
                }

            }
            return res;
        }


        [HttpPost]
        public APIResult UpdateUsers(IEnumerable<TblUser> dataList)
        {
           APIResult res = new APIResult();
           using (Sonartez_server db = new Sonartez_server(connectionString))
           {
               foreach (var data in dataList)
               {
                   var matchedObj = (from c in db.TblUser
                                     where c.UserID == data.UserID
                                     select c).SingleOrDefault();

                   if (matchedObj == null)
                   {
                       try
                       {
                           // does not exist
                           Table<TblUser> TblObj = db.TblUser;
                           data.ServerUpdate  = DateTime.UtcNow;

                           TblObj.InsertOnSubmit(data);
                           TblObj.Context.SubmitChanges();

                           res.UpdateDate = DateTime.UtcNow;
                           res.Success = true;

                       }
                       catch (Exception ex)
                       {
                           res.Message = ex.Message;
                           res.Success = false;
                       }
                   }
                   else
                   {
                       try
                       {
                           matchedObj.Active = data.Active;
                           matchedObj.Email = data.Email;
                           matchedObj.FullName = data.FullName;
                           matchedObj.LastLoginTime = data.LastLoginTime;
                           matchedObj.Password = data.Password;
                           matchedObj.PhoneNumber = data.PhoneNumber;
                           matchedObj.UserName = data.UserName;
                           matchedObj.ServerUpdate  = DateTime.UtcNow;
                           matchedObj.UpdateDate = data.UpdateDate.Value;
                           matchedObj.Permission = data.Permission;
                           matchedObj.IsDeleted = data.IsDeleted;
                           db.SubmitChanges();

                           res.UpdateDate = DateTime.UtcNow;
                           res.Success = true;
                       }
                       catch (Exception ex)
                       {
                           res.Message = ex.Message;
                           res.Success = false;
                       }
                   }

               }
           }
            return res;
        }
    }
}
