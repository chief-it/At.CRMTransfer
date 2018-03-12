using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crmtransfer
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger("At.DeliveryUtilsService");
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            Log.Info(">>>>>>>App started.");
            var dbTS = new TSEntities();
            var dbBPM = new AtBPMEntities();

            string outStr = "";
            Console.WriteLine("Сформируем таблицу преобразований места работы...");
            Log.Info("Сформируем таблицу преобразований места работы...");
            var dicJobsTable = new Dictionary<Guid, Guid>();
            var listTSJobs = dbTS.tbl_Job.ToList();
            foreach(var job in listTSJobs)
            {
                string jobName = job.Name;
                var dbBpmJob = dbBPM.Job.FirstOrDefault(x => x.Name == jobName);
                if (dbBpmJob == null)
                {
                    dbBpmJob = new Job()
                    {
                        Id = Guid.NewGuid(),
                        CreatedOn = DateTime.Now,
                        Name = jobName,
                        Description = "",
                        ProcessListeners = 0
                    };
                    dbBPM.Job.Add(dbBpmJob);
                }
                dicJobsTable.Add(job.ID, dbBpmJob.Id);
            }
            dbBPM.SaveChanges();
            Log.Info("Сохранили БД");

            outStr = "Грузим контакты...";
            Console.WriteLine(outStr); Log.Info(outStr);
            var listTSContacts = dbTS.tbl_Contact.ToList();
            var dicContactsTSBPMIds = new Dictionary<Guid, Guid>();
            int RId = 3;

            int progress = 0;
            double step = listTSContacts.Count / 20;

            dbBPM.Configuration.AutoDetectChangesEnabled = false;
            foreach (var contact in listTSContacts)
            {
                Log.Info($"Переносим контакт: {contact.Name}");
                var bpmcontact = new Contact();
                bpmcontact.Id = Guid.NewGuid();
                dicContactsTSBPMIds.Add(contact.ID, bpmcontact.Id);
                bpmcontact.CreatedOn = contact.CreatedOn;
                bpmcontact.ModifiedOn = DateTime.Now;
                bpmcontact.Name = contact.Name ?? "";
                bpmcontact.Dear = contact.Dear ?? "";
                bpmcontact.Description = ""; 
                switch (contact.SalutationID.ToString().ToUpper())
                {
                    case "E285E1C6-841C-45CE-B5CD-B256C445DFFB": //Г-н
                        bpmcontact.SalutationTypeId = new Guid("7426FFB3-56E6-DF11-971B-001D60E938C6");
                        break;
                    case "1F87FD97-A663-4C02-8530-48951F912C6B": //Г-жа
                        bpmcontact.SalutationTypeId = new Guid("7526FFB3-56E6-DF11-971B-001D60E938C6");
                        break;
                }
                switch (contact.ContactTypeID.ToString().ToUpper())
                {
                    case "3D51B409-B691-4F77-9723-359C65399AB4": //Контактное лицо
                        bpmcontact.TypeId = new Guid("806732EE-F36B-1410-A883-16D83CAB0980");
                        break;
                    case "47CBC6BB-D74E-4872-A488-75CC01122136": //Сотрудник нашей компании
                        bpmcontact.TypeId = new Guid("60733EFC-F36B-1410-A883-16D83CAB0980");
                        break;
                    case "D8052649-8AFA-4A31-A147-CD18498B155F": //Контакт по ПРОДАЖАМ
                        bpmcontact.TypeId = new Guid("FF789343-9C1A-42D2-BE3C-02F95482E213");
                        break;
                    case "75277E61-09B4-4D7E-BD9D-FA7F8E90476B": //Клиент
                        bpmcontact.TypeId = new Guid("00783EF6-F36B-1410-A883-16D83CAB0980");
                        break;
                    case "3A296783-B68E-4E60-B90B-1550763B52CA": //Контакт по СЕРВИСУ
                        bpmcontact.TypeId = new Guid("CD39F17A-8AB4-4DFF-A661-A89D99AEB2F8");
                        break;
                    case "04545691-A745-40D2-B349-D3ADFD01997F": //Контакт по ПРОДАЖАМ и СЕРВИСУ
                        bpmcontact.TypeId = new Guid("4F12EFBA-1688-42EC-A90E-5E6375CDCD86");
                        break;
                    case "BE2F1C27-C955-492F-9927-7E54A2DDF13B": //V I P
                        bpmcontact.TypeId = new Guid("BBED411F-55B0-44F3-BABF-EA71C265B091");
                        break;
                }
                bpmcontact.UsrDocumentBasis = contact.DocumentBasis ?? "";
                bpmcontact.UsrDocumentName = contact.DocumentName ?? "";
                switch (contact.GenderID)
                {
                    case "{264EF705-6CC4-4E2F-9611-45531D04CBE7}": //мужской
                        bpmcontact.GenderId = new Guid("EEAC42EE-65B6-DF11-831A-001D60E938C6");
                        break;
                    case "{8CB0B216-3E35-47CE-8C31-8DFAA3C1548D}": //женский
                        bpmcontact.GenderId = new Guid("FC2483F8-65B6-DF11-831A-001D60E938C6");
                        break;
                }
                bpmcontact.JobTitle = contact.JobTitle ?? "";
                if (contact.JobID != null)
                {
                    bpmcontact.JobId = dicJobsTable[contact.JobID ?? Guid.Empty];
                }
                switch (contact.DecisionRoleID.ToString().ToUpper())
                {
                    case "E4DDA556-4C53-414A-B4F6-5853EBCACAB5": //ЛПР
                        bpmcontact.DecisionRoleId = new Guid("ED46BB3A-57E6-DF11-971B-001D60E938C6");
                        break;
                    case "311109B8-A37C-42B4-B46A-6234E670CBE6": //ЛГР
                        bpmcontact.DecisionRoleId = new Guid("D1AB0E4E-57E6-DF11-971B-001D60E938C6");
                        break;
                    case "48521110-02CC-44A6-A510-83975EF63A6E": //ЛВР
                        bpmcontact.DecisionRoleId = new Guid("D2AB0E4E-57E6-DF11-971B-001D60E938C6");
                        break;
                    case "CA4F0B0C-D690-4D26-9773-A412CDC5CADE": //Исполнитель
                        bpmcontact.DecisionRoleId = new Guid("91E32C57-57E6-DF11-971B-001D60E938C6");
                        break;
                }
                switch (contact.DepartmentID.ToString().ToUpper())
                {
                    case "919FDC17-F56E-46E3-95C0-02A2C53846D4": //Продажи
                        bpmcontact.DepartmentId = new Guid("2076C4B6-7FE6-DF11-971B-001D60E938C6");
                        break;
                    case "E9B7AE79-A102-4710-AB02-49116B31CA5E": //Сервисное обслуживание
                        bpmcontact.DepartmentId = new Guid("18571055-EE88-4826-9222-567688F9DD78");
                        break;
                    case "2BC3C4F4-14CB-467D-83A7-85A4D2DB69DB": //Партнерский отдел
                        bpmcontact.DepartmentId = new Guid("45B7F797-FA4C-40DF-B38D-5B9B691CC04D");
                        break;
                    case "439C9EF6-A0B4-474F-81C3-8E412C2C46C8": //Производство
                        bpmcontact.DepartmentId = new Guid("769964A0-B4DA-DF11-9B2A-001D60E938C6");
                        break;
                    case "2B71DB52-EAA7-44BC-8B4B-9B49C5FE230B": //Маркетинг
                        bpmcontact.DepartmentId = new Guid("4791A98E-B4DA-DF11-9B2A-001D60E938C6");
                        break;
                    case "992E9820-B5C3-4D31-A1D4-C22B9DD598EA": //Финансы
                        bpmcontact.DepartmentId = new Guid("67B27CA5-117B-467A-B5E1-2249DF73884F");
                        break;
                    case "CD2EDDB5-62EE-4AC0-AD9D-F5FC137A4212": //Администрация
                        bpmcontact.DepartmentId = new Guid("66FFA487-B4DA-DF11-9B2A-001D60E938C6");
                        break;
                    case "D2C40447-2C1E-4750-B13D-FD34C4627838": //Обеспечение офиса
                        bpmcontact.DepartmentId = new Guid("A55CDE92-74AA-440E-B73B-F709FB2320FF");
                        break;
                    case "9768FD9A-7FFB-4838-91BD-A90FC0A9EBCB": //Продажи MB Vans
                        bpmcontact.DepartmentId = new Guid("8B87248C-9FBF-4A03-B568-63970CBF6697");
                        break;
                }
                bpmcontact.Notes = contact.Comment ?? "";

                bpmcontact.Phone = "";
                bpmcontact.MobilePhone = "";
                bpmcontact.HomePhone = "";
                bpmcontact.Skype = "";
                bpmcontact.Email = "";
                bpmcontact.Address = "";
                bpmcontact.Zip = "";
                bpmcontact.DoNotUseCall = false;
                bpmcontact.DoNotUseEmail = false;
                bpmcontact.DoNotUseFax = false;
                bpmcontact.DoNotUseMail = false;
                bpmcontact.DoNotUseSms = false;
                bpmcontact.Facebook = "";
                bpmcontact.Twitter = "";
                bpmcontact.FacebookId = "";
                bpmcontact.LinkedIn = "";
                bpmcontact.LinkedInId = "";
                bpmcontact.TwitterId = "";
                bpmcontact.ProcessListeners = 0;
                bpmcontact.GPSE = "";
                bpmcontact.GPSN = "";
                bpmcontact.Surname = "";
                bpmcontact.GivenName = "";
                bpmcontact.MiddleName = "";
                bpmcontact.Confirmed = true;
                bpmcontact.IsNonActualEmail = false;
                bpmcontact.RId = RId;
                RId++;
                bpmcontact.Completeness = 0;

                progress++;
                if ((progress % step) == 0)
                {
                    Log.Info($"{(int)(progress / step) * 5}%");
                    Console.WriteLine($"{(int)(progress / step) * 5}%");
                }
                dbBPM.Contact.Add(bpmcontact);
            }
            outStr = "Сохраняем БД";
            Console.WriteLine(outStr); Log.Info(outStr);
            dbBPM.Configuration.AutoDetectChangesEnabled = true;
            dbBPM.SaveChanges();
           

            Console.WriteLine("Грузим средства связи контактов...");
            Log.Info("Грузим средства связи контактов...");
            var listContactCommunication = dbTS.tbl_ContactCommunication.ToList();
            progress = 0;
            step = listContactCommunication.Count / 20;
            dbBPM.Configuration.AutoDetectChangesEnabled = false;
            foreach (var communication in listContactCommunication)
            {
                var bpmCommunication = new ContactCommunication()
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = communication.CreatedOn,
                    ModifiedOn = DateTime.Now
                };
                Guid tsContactId = communication.ContactID ?? Guid.Empty;
                if (tsContactId == Guid.Empty)
                {
                    string errorStr = $"Контакт с CommunicationId <{communication.ID}> не найден";
                    Console.WriteLine(errorStr);
                    Log.Info(errorStr);
                    break;
                }
                Guid bpmContactId = dicContactsTSBPMIds[tsContactId];
                var dbBpmContact = dbBPM.Contact.Find(bpmContactId);
                if (dbBpmContact == null)
                {
                    string errorStr = $"Контакт с BpmId <{bpmContactId}> не найден";
                    Console.WriteLine(errorStr);
                    Log.Info(errorStr);
                    break;
                }
                switch (communication.CommunicationTypeID.ToString().ToUpper())
                {
                    case "FA08FC2A-9D55-40C9-9576-0017EAED3E49": //Мобильный
                        bpmCommunication.CommunicationTypeId = new Guid("D4A2DC80-30CA-DF11-9B2A-001D60E938C6");
                        dbBpmContact.MobilePhone = communication.Number;
                        dbBPM.Entry(dbBpmContact).Property(c => c.MobilePhone).IsModified = true;
                        break;
                    case "DBCB6A43-D99F-45AE-9B41-037DE595242E": //Телефон
                        bpmCommunication.CommunicationTypeId = new Guid("3DDDB3CC-53EE-49C4-A71F-E9E257F59E49");
                        dbBpmContact.Phone = communication.Number;
                        dbBPM.Entry(dbBpmContact).Property(c => c.Phone).IsModified = true;
                        break;
                    case "82696D8B-71AE-4BA4-94FD-3F77474D74E7": //Факс
                        bpmCommunication.CommunicationTypeId = new Guid("9A7AB41B-67CC-DF11-9B2A-001D60E938C6");
                        break;
                    case "7A628D16-D7D0-4979-B8BA-B64EF54A0366": //Email
                        bpmCommunication.CommunicationTypeId = new Guid("EE1C85C3-CFCB-DF11-9B2A-001D60E938C6");
                        dbBpmContact.Email = communication.Number;
                        dbBPM.Entry(dbBpmContact).Property(c => c.Email).IsModified = true;
                        break;
                    case "7B77F07B-9976-47D6-95AA-D161FF369D6D": //Web
                        bpmCommunication.CommunicationTypeId = new Guid("6A8BA927-67CC-DF11-9B2A-001D60E938C6");
                        break;
                    default:
                        string number = communication.Number;
                        if (number.IndexOf("@") == (-1))
                        {   //телефон
                            bpmCommunication.CommunicationTypeId = new Guid("3DDDB3CC-53EE-49C4-A71F-E9E257F59E49");
                            dbBpmContact.Phone = communication.Number;
                            dbBPM.Entry(dbBpmContact).Property(c => c.Phone).IsModified = true;
                        }
                        else
                        {   //email
                            bpmCommunication.CommunicationTypeId = new Guid("EE1C85C3-CFCB-DF11-9B2A-001D60E938C6");
                            dbBpmContact.Email = communication.Number;
                            dbBPM.Entry(dbBpmContact).Property(c => c.Email).IsModified = true;
                        }
                        break;
                }
                bpmCommunication.Number = communication.Number;
                bpmCommunication.ContactId = bpmContactId;//dicContactsTSBPMIds[tsContactId];
                bpmCommunication.Position = 0;
                bpmCommunication.SocialMediaId = "";
                bpmCommunication.SearchNumber = communication.Number;
                bpmCommunication.ProcessListeners = 0;
                bpmCommunication.IsCreatedBySynchronization = false;
                bpmCommunication.NonActual = false;
                bpmCommunication.ExternalCommunicationType = "";
                dbBPM.ContactCommunication.Add(bpmCommunication);

                progress++;
                if ((progress % step) == 0)
                {
                    Log.Info($"{(int)(progress / step) * 5}%");
                    Console.WriteLine($"{(int)(progress / step) * 5}%");
                }

                //dbBPM.Entry(dbBpmContact).State = EntityState.Modified;
            }
            outStr = "Сохраняем БД";
            Console.WriteLine(outStr); Log.Info(outStr);
            dbBPM.Configuration.AutoDetectChangesEnabled = true;
            dbBPM.SaveChanges();

            outStr = "Сформируем таблицу преобразований отраслей контрагентов...";
            Console.WriteLine(outStr); Log.Info(outStr);
            var dicIndustriesTable = new Dictionary<Guid, Guid>();
            var listTSFields = dbTS.tbl_Field.ToList();
            foreach (var field in listTSFields)
            {
                string fieldName = field.Name;
                var dbBpmIndustry = dbBPM.AccountIndustry.FirstOrDefault(x => x.Name == fieldName);
                if (dbBpmIndustry == null)
                {
                    dbBpmIndustry = new AccountIndustry()
                    {
                        Id = Guid.NewGuid(),
                        CreatedOn = DateTime.Now,
                        Name = fieldName,
                        Description = "",
                        ProcessListeners = 0
                    };
                    dbBPM.AccountIndustry.Add(dbBpmIndustry);
                }
                dicIndustriesTable.Add(field.ID, dbBpmIndustry.Id);
            }
            outStr = "Сохраняем БД";
            Console.WriteLine(outStr); Log.Info(outStr);
            dbBPM.SaveChanges();

            outStr = "Грузим контрагентов...";
            Console.WriteLine(outStr); Log.Info(outStr);
            var listTSAccounts = dbTS.tbl_Account.ToList();
            var dicAccountsTSBPMIds = new Dictionary<Guid, Guid>();

            progress = 0;
            step = listTSAccounts.Count / 20;
            dbBPM.Configuration.AutoDetectChangesEnabled = false;
            foreach (var tsAccount in listTSAccounts)
            {
                Log.Info($"Переносим контрагента: {tsAccount.Name}");
                var bpmAccount = new Account();
                bpmAccount.Id = Guid.NewGuid();
                dicAccountsTSBPMIds.Add(tsAccount.ID, bpmAccount.Id);
                bpmAccount.CreatedOn = tsAccount.CreatedOn;
                bpmAccount.ModifiedOn = DateTime.Now;
                bpmAccount.Name = tsAccount.Name ?? "";
                bpmAccount.AlternativeName = tsAccount.OfficialAccountName ?? "";

                switch (tsAccount.AccountTypeID.ToString().ToUpper())
                {
                    case "BC3F7C11-BD05-4159-81DF-38B13F1824E3": //Клиент
                        bpmAccount.TypeId = new Guid("03A75490-53E6-DF11-971B-001D60E938C6");
                        break;
                    case "FA61C463-D98D-4FD6-860E-8E1D26ED3DC9": //Потенциальный клиент - Держать на контроле
                        bpmAccount.TypeId = new Guid("9F8EFF17-A1F4-45D3-8AAC-D8C4BB978F65");
                        break;
                    case "9E2ADEE3-F981-4D91-90E1-DDAA19FBB08D": //new MB СОТРАНС опт (купил >=10)
                        bpmAccount.TypeId = new Guid("F875FAF4-57A9-45B9-8E8C-64E3F480579C");
                        break;
                    case "8A202CCD-7F7E-451C-967D-D5F458CEF5D9": //Потенциальный клиент - Бороться (реально может, но не хочет)
                        bpmAccount.TypeId = new Guid("E869793B-75B9-4A31-B6DD-4D9903FB928F");
                        break;
                    case "58C23FD3-176D-45CD-9B89-B3389DFDA5AE": //Потенциальный клиент - Не безнадежно, но в далеком будущем
                        bpmAccount.TypeId = new Guid("F1BD9907-AE12-4794-9F6A-E8DD7586100F");
                        break;
                    case "C0572410-730E-4CB8-B173-A4BBB0E60102": //Не тратить время - не перевозчик, нет парка и т.п.
                        bpmAccount.TypeId = new Guid("0C79BBDE-7C89-43F0-A9EB-8709A5279A6B");
                        break;
                    case "10D14862-186D-47DB-A67C-11940401867B": //Другое
                        bpmAccount.TypeId = new Guid("18195D76-7663-4452-9944-A5CF66F133F6");
                        break;
                    case "E18781ED-5BD8-4FD8-9E09-0CBDB2383911": //new MB СОТРАНС розница (купил < 10)
                        bpmAccount.TypeId = new Guid("B35665DB-C25C-428B-8710-6B7AC5CDE6BF");
                        break;
                    case "5FE2CF34-77D6-4AAF-A9B8-FA86ED1B38A6": //Комиссионер
                        bpmAccount.TypeId = new Guid("917EDE7B-C6F4-4C15-8835-04C932FC7CD0");
                        break;
                    case "3CAFDB88-1513-4A5D-B4BA-0811FB109999": //new MB Восток/Звезда опт (купил >=10) пока не надо все работает02.03.18
                        bpmAccount.TypeId = new Guid("0CF8D4A8-CE7F-4025-9C88-087791F275E3");
                        break;
                    case "9C8E86C6-1DCF-4608-8E39-4BAFA20CE7EA": //new MB Восток/Звезда розница (купил <10)
                        bpmAccount.TypeId = new Guid("3BEA45E9-88E9-46C7-A0FD-F7A0CD537B24");
                        break;
                    case "E53002EF-2F64-440E-A647-F03A2ED50685": //жаров
                        bpmAccount.TypeId = new Guid("76EE559B-BBE3-4B2C-92F4-9D7D55AA88E3");
                        break;
                    case "40831A0A-EF24-4AD0-8549-31D594FA4EC0": //new ТЕНДЕР ТОЛЬКО
                        bpmAccount.TypeId = new Guid("C72C590C-59CB-4487-813E-E4F790CD6F04");
                        break;
                    case "4A0CBD93-3506-4D49-969B-C63ECEE56A9A": //new потенциальный клиент (покупка < полгода)
                        bpmAccount.TypeId = new Guid("F936230E-9032-4CA5-AEB5-CB4F5D90F594");
                        break;
                    case "B8516B6B-5D36-4001-B9BD-8F673C5BA4BA": //new потенциальный клиент (покупка > полгода)
                        bpmAccount.TypeId = new Guid("78B7B4E1-F3C8-4D9C-AADC-62EC80AAE33A");
                        break;
                }

                if (tsAccount.FieldID != null)
                {
                    bpmAccount.IndustryId = dicIndustriesTable[tsAccount.FieldID ?? Guid.Empty];
                }

                bpmAccount.Code = tsAccount.Code ?? "";
                if (tsAccount.PrimaryContactID != null)
                {
                    bpmAccount.PrimaryContactId = dicContactsTSBPMIds[tsAccount.PrimaryContactID ?? Guid.Empty];
                }
                if (tsAccount.AuthorID != null)
                {
                    bpmAccount.UsrAuthorId = dicContactsTSBPMIds[tsAccount.AuthorID ?? Guid.Empty];
                }
                if (tsAccount.OwnerID != null)
                {
                    bpmAccount.OwnerId = dicContactsTSBPMIds[tsAccount.OwnerID ?? Guid.Empty];
                }
                bpmAccount.Notes = tsAccount.Comment ?? "";
                if (tsAccount.AnnualRevenue != null)
                {
                    bpmAccount.UsrB7Count = tsAccount.AnnualRevenue ?? 0;
                }
                if (tsAccount.EmployeesNumber != null)
                {
                    bpmAccount.UsrScaniaCount = tsAccount.EmployeesNumber ?? 0;
                }


                bpmAccount.Description = "";
                bpmAccount.Phone = "";
                bpmAccount.AdditionalPhone = "";
                bpmAccount.Fax = "";
                bpmAccount.Web = "";
                bpmAccount.Address = "";
                bpmAccount.Zip = "";
                bpmAccount.ProcessListeners = 0;
                bpmAccount.GPSE = "";
                bpmAccount.GPSN = "";
                bpmAccount.Completeness = 0;

                progress++;
                if ((progress % step) == 0)
                {
                    Log.Info($"{(int)(progress / step) * 5}%");
                    Console.WriteLine($"{(int)(progress / step) * 5}%");
                }
                dbBPM.Account.Add(bpmAccount);
            }

            outStr = "Сохраняем БД";
            Console.WriteLine(outStr); Log.Info(outStr);
            dbBPM.Configuration.AutoDetectChangesEnabled = true;
            dbBPM.SaveChanges();


            outStr = "Грузим средства связи контрагентов...";
            Console.WriteLine(outStr); Log.Info(outStr);
            var listAccountCommunication = dbTS.tbl_AccountCommunication.ToList();
            progress = 0;
            step = listAccountCommunication.Count / 20;
            dbBPM.Configuration.AutoDetectChangesEnabled = false;
            foreach (var communication in listAccountCommunication)
            {
                var bpmCommunication = new AccountCommunication()
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = communication.CreatedOn,
                    ModifiedOn = DateTime.Now
                };
                Guid tsAccountId = communication.AccountID ?? Guid.Empty;
                if (tsAccountId == Guid.Empty)
                {
                    string errorStr = $"Контрагент с CommunicationId <{communication.ID}> не найден";
                    Console.WriteLine(errorStr);
                    Log.Info(errorStr);
                    break;
                }
                Guid bpmAccountId = dicAccountsTSBPMIds[tsAccountId];
                var dbBpmAccount = dbBPM.Account.Find(bpmAccountId);
                if (dbBpmAccount == null)
                {
                    string errorStr = $"Контрагент с BpmId <{bpmAccountId}> не найден";
                    Console.WriteLine(errorStr);
                    Log.Info(errorStr);
                    break;
                }
                switch (communication.CommunicationTypeID.ToString().ToUpper())
                {
                    case "FA08FC2A-9D55-40C9-9576-0017EAED3E49": //Мобильный
                        bpmCommunication.CommunicationTypeId = new Guid("D4A2DC80-30CA-DF11-9B2A-001D60E938C6");
                        dbBpmAccount.AdditionalPhone = communication.Number;
                        dbBPM.Entry(dbBpmAccount).Property(c => c.AdditionalPhone).IsModified = true;
                        break;
                    case "DBCB6A43-D99F-45AE-9B41-037DE595242E": //Телефон
                        bpmCommunication.CommunicationTypeId = new Guid("3DDDB3CC-53EE-49C4-A71F-E9E257F59E49");
                        dbBpmAccount.Phone = communication.Number;
                        dbBPM.Entry(dbBpmAccount).Property(c => c.Phone).IsModified = true;
                        break;
                    case "82696D8B-71AE-4BA4-94FD-3F77474D74E7": //Факс
                        bpmCommunication.CommunicationTypeId = new Guid("9A7AB41B-67CC-DF11-9B2A-001D60E938C6");
                        dbBpmAccount.Fax = communication.Number;
                        dbBPM.Entry(dbBpmAccount).Property(c => c.Fax).IsModified = true;
                        break;
                    case "7A628D16-D7D0-4979-B8BA-B64EF54A0366": //Email
                        bpmCommunication.CommunicationTypeId = new Guid("EE1C85C3-CFCB-DF11-9B2A-001D60E938C6");
                        break;
                    case "7B77F07B-9976-47D6-95AA-D161FF369D6D": //Web
                        bpmCommunication.CommunicationTypeId = new Guid("6A8BA927-67CC-DF11-9B2A-001D60E938C6");
                        dbBpmAccount.Web = communication.Number;
                        dbBPM.Entry(dbBpmAccount).Property(c => c.Web).IsModified = true;
                        break;
                    default:
                        string number = communication.Number;
                        if (number.IndexOf("@") == (-1))
                        {   //телефон
                            bpmCommunication.CommunicationTypeId = new Guid("3DDDB3CC-53EE-49C4-A71F-E9E257F59E49");
                            dbBpmAccount.Phone = communication.Number;
                            dbBPM.Entry(dbBpmAccount).Property(c => c.Phone).IsModified = true;
                        }
                        else
                        {   //email
                            bpmCommunication.CommunicationTypeId = new Guid("EE1C85C3-CFCB-DF11-9B2A-001D60E938C6");
                        }
                        break;
                }
                bpmCommunication.Number = communication.Number ?? "";
                bpmCommunication.AccountId = bpmAccountId;
                bpmCommunication.Position = 0;
                bpmCommunication.SocialMediaId = "";
                bpmCommunication.SearchNumber = communication.Number ?? "0";
                Log.Info($"communication.ID={communication}, communication.Number={communication.Number}, bpmCommunication.SearchNumber={bpmCommunication.SearchNumber}");
                bpmCommunication.ProcessListeners = 0;
                bpmCommunication.Primary = false;
                dbBPM.AccountCommunication.Add(bpmCommunication);

                progress++;
                if ((progress % step) == 0)
                {
                    Log.Info($"{(int)(progress / step) * 5}%");
                    Console.WriteLine($"{(int)(progress / step) * 5}%");
                }

                //dbBPM.Entry(dbBpmContact).State = EntityState.Modified;
            }
            outStr = "Сохраняем БД";
            Console.WriteLine(outStr); Log.Info(outStr);
            dbBPM.Configuration.AutoDetectChangesEnabled = true;
            try
            {
                dbBPM.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbExc)
            {
                string errorStr = "";
                foreach(var error in dbExc.EntityValidationErrors)
                {
                    foreach (var er in error.ValidationErrors)
                    {
                        errorStr += $"{er.PropertyName}\n";
                    }
                    errorStr += $"\n**********\n";
                }
                Log.Info(errorStr);
                Console.WriteLine(errorStr);
            }



            /*tStr = "Грузим карьеру контакта...";
            Console.WriteLine(outStr); Log.Info(outStr);
            var listContactCareer = dbTS.tbl_Contact.ToList();
            progress = 0;
            step = listContactCommunication.Count / 20;
            dbBPM.Configuration.AutoDetectChangesEnabled = false;
            foreach (var communication in listContactCommunication)
            {
                var bpmCommunication = new ContactCommunication()
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = communication.CreatedOn,
                    ModifiedOn = DateTime.Now
                };
                Guid tsContactId = communication.ContactID ?? Guid.Empty;
                if (tsContactId == Guid.Empty)
                {
                    string errorStr = $"Контакт с CommunicationId <{communication.ID}> не найден";
                    Console.WriteLine(errorStr);
                    Log.Info(errorStr);
                    break;
                }
                Guid bpmContactId = dicContactsTSBPMIds[tsContactId];
                var dbBpmContact = dbBPM.Contact.Find(bpmContactId);
                if (dbBpmContact == null)
                {
                    string errorStr = $"Контакт с BpmId <{bpmContactId}> не найден";
                    Console.WriteLine(errorStr);
                    Log.Info(errorStr);
                    break;
                }
                switch (communication.CommunicationTypeID.ToString().ToUpper())
                {
                    case "FA08FC2A-9D55-40C9-9576-0017EAED3E49": //Мобильный
                        bpmCommunication.CommunicationTypeId = new Guid("D4A2DC80-30CA-DF11-9B2A-001D60E938C6");
                        dbBpmContact.MobilePhone = communication.Number;
                        dbBPM.Entry(dbBpmContact).Property(c => c.MobilePhone).IsModified = true;
                        break;
                    case "DBCB6A43-D99F-45AE-9B41-037DE595242E": //Телефон
                        bpmCommunication.CommunicationTypeId = new Guid("3DDDB3CC-53EE-49C4-A71F-E9E257F59E49");
                        dbBpmContact.Phone = communication.Number;
                        dbBPM.Entry(dbBpmContact).Property(c => c.Phone).IsModified = true;
                        break;
                    case "82696D8B-71AE-4BA4-94FD-3F77474D74E7": //Факс
                        bpmCommunication.CommunicationTypeId = new Guid("9A7AB41B-67CC-DF11-9B2A-001D60E938C6");
                        break;
                    case "7A628D16-D7D0-4979-B8BA-B64EF54A0366": //Email
                        bpmCommunication.CommunicationTypeId = new Guid("EE1C85C3-CFCB-DF11-9B2A-001D60E938C6");
                        dbBpmContact.Email = communication.Number;
                        dbBPM.Entry(dbBpmContact).Property(c => c.Email).IsModified = true;
                        break;
                    case "7B77F07B-9976-47D6-95AA-D161FF369D6D": //Web
                        bpmCommunication.CommunicationTypeId = new Guid("6A8BA927-67CC-DF11-9B2A-001D60E938C6");
                        break;
                    default:
                        string number = communication.Number;
                        if (number.IndexOf("@") == (-1))
                        {   //телефон
                            bpmCommunication.CommunicationTypeId = new Guid("3DDDB3CC-53EE-49C4-A71F-E9E257F59E49");
                            dbBpmContact.Phone = communication.Number;
                            dbBPM.Entry(dbBpmContact).Property(c => c.Phone).IsModified = true;
                        }
                        else
                        {   //email
                            bpmCommunication.CommunicationTypeId = new Guid("EE1C85C3-CFCB-DF11-9B2A-001D60E938C6");
                            dbBpmContact.Email = communication.Number;
                            dbBPM.Entry(dbBpmContact).Property(c => c.Email).IsModified = true;
                        }
                        break;
                }
                bpmCommunication.Number = communication.Number;
                bpmCommunication.ContactId = bpmContactId;//dicContactsTSBPMIds[tsContactId];
                bpmCommunication.Position = 0;
                bpmCommunication.SocialMediaId = "";
                bpmCommunication.SearchNumber = communication.Number;
                bpmCommunication.ProcessListeners = 0;
                bpmCommunication.IsCreatedBySynchronization = false;
                bpmCommunication.NonActual = false;
                bpmCommunication.ExternalCommunicationType = "";
                dbBPM.ContactCommunication.Add(bpmCommunication);

                progress++;
                if ((progress % step) == 0)
                {
                    Log.Info($"{(int)(progress / step) * 5}%");
                    Console.WriteLine($"{(int)(progress / step) * 5}%");
                }

                //dbBPM.Entry(dbBpmContact).State = EntityState.Modified;
            }
            outStr = "Сохраняем БД";
            Console.WriteLine(outStr); Log.Info(outStr);
            dbBPM.Configuration.AutoDetectChangesEnabled = true;
            dbBPM.SaveChanges();
            */

            outStr = "Грузим Author, Owner, Account для контактов...";
            Console.WriteLine(outStr); Log.Info(outStr);
            progress = 0;
            step = listTSContacts.Count / 20;
            dbBPM.Configuration.AutoDetectChangesEnabled = false;
            foreach (var contact in listTSContacts)
            {
                Guid bpmContactId = dicContactsTSBPMIds[contact.ID];
                var dbBpmContact = dbBPM.Contact.Find(bpmContactId);
                if (dbBpmContact != null)
                {
                    Guid tsAccountId = contact.AccountID ?? Guid.Empty;
                    if (tsAccountId != Guid.Empty)
                    {
                        dbBpmContact.AccountId = dicAccountsTSBPMIds[tsAccountId];
                        dbBPM.Entry(dbBpmContact).Property(c => c.AccountId).IsModified = true;
                    }
                    Guid authorId = contact.AuthorID ?? Guid.Empty;
                    if (authorId != Guid.Empty)
                    {
                        Guid bpmAuthorId = dicContactsTSBPMIds[authorId];
                        dbBpmContact.UsrAuthorId = bpmAuthorId;
                        dbBPM.Entry(dbBpmContact).Property(c => c.UsrAuthorId).IsModified = true;
                    }
                    Guid ownerId = contact.OwnerID ?? Guid.Empty;
                    if (ownerId != Guid.Empty)
                    {
                        Guid bpmOwnerId = dicContactsTSBPMIds[ownerId];
                        dbBpmContact.OwnerId = bpmOwnerId;
                        dbBPM.Entry(dbBpmContact).Property(c => c.OwnerId).IsModified = true;
                    }
                }

                progress++;
                if ((progress % step) == 0)
                {
                    Log.Info($"{(int)(progress / step) * 5}%");
                    Console.WriteLine($"{(int)(progress / step) * 5}%");
                }
            }
            outStr = "Сохраняем БД";
            Console.WriteLine(outStr); Log.Info(outStr);
            dbBPM.Configuration.AutoDetectChangesEnabled = true;
            dbBPM.SaveChanges();

            dbBPM.Dispose();
            dbTS.Dispose();
            Console.Write("Готово. Жми любую клавишу...");
            Console.Read();
            Log.Info("=======App stopped.");
        }
    }
}
