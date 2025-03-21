using AtlasCellData;
using PPC.Core.Models;
using PPC.Core.Models.Jwt;
using PPC.Response.DTOs;
using System.Collections.Generic;
using System.Linq;
using static System.Collections.Specialized.BitVector32;
using PPC.Base.Extensions;
using System;
using AtlasCellData.ADO;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using AC_PPC.Response.DTOs;
using PPC.Base.Utility;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PPC.Core.Extensions
{

    public partial class ExtAutoMapper
    {
        public static TDestination JsonMap<TSource, TDestination>(TSource source)
        {
            var src = JsonConvert.SerializeObject(source, Formatting.None
                        , new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }
                        );
            var dest= JsonConvert.DeserializeObject<TDestination>(src
                        ,new JsonSerializerSettings()
                        //{
                        //    NullValueHandling = NullValueHandling.Ignore
                        //}
                        );

            return dest;
        }

    }
    public partial class ExtAutoMapper
    {
        private static Mapper _initializeAutomapper = null;
        public static Mapper Mapper { get; } = InitializeAutomapper();
        public static Mapper InitializeAutomapper()
        {

            //singletone
            if (_initializeAutomapper != null)
                return _initializeAutomapper;

            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {



                #region ModelDTO to Model

                //Configuring 
                cfg.CreateMap<Temp, TempDTO>();
                //cfg.CreateMap<List<Temp>, List<TempDTO>>();


                cfg.CreateMap<Users, UsersDTO>().MaxDepth(15);
                cfg.CreateMap<Stations, StationsDTO>().MaxDepth(15);
                cfg.CreateMap<Units, UnitsDTO>().MaxDepth(15);
                cfg.CreateMap<RawMaterialGroups, RawMaterialGroupsDTO>().MaxDepth(15);
                cfg.CreateMap<RawMaterials, RawMaterialsDTO>().MaxDepth(15);
                cfg.CreateMap<Provinces, ProvincesDTO>().MaxDepth(15);
                cfg.CreateMap<Customers, CustomersDTO>().MaxDepth(15);
                cfg.CreateMap<Domain, DomainDTO>().MaxDepth(15);
                cfg.CreateMap<CustomerGrades, CustomerGradesDTO>().MaxDepth(15);
                cfg.CreateMap<SaleAgents, SaleAgentsDTO>().MaxDepth(15);
                cfg.CreateMap<PrintingTechniques, PrintingTechniquesDTO>().MaxDepth(15);
                cfg.CreateMap<ProductGroupTypes, ProductGroupTypesDTO>().MaxDepth(15);
                cfg.CreateMap<ProductGroups, ProductGroupsDTO>().MaxDepth(15);
                cfg.CreateMap<ProductTypes, ProductTypesDTO>().MaxDepth(15);
                cfg.CreateMap<ProductSeries, ProductSeriesDTO>().MaxDepth(15);
                cfg.CreateMap<Products, ProductsDTO>().MaxDepth(15);
                cfg.CreateMap<ProductSerieTechniqueAssigns, ProductSerieTechniqueAssignsDTO>().MaxDepth(15);
                cfg.CreateMap<RawMaterialGroupTypes, RawMaterialGroupTypesDTO>().MaxDepth(15);
                cfg.CreateMap<Suppliers, SuppliersDTO>().MaxDepth(15);
                cfg.CreateMap<TestPlanGroups, TestPlanGroupsDTO>().MaxDepth(15);
                cfg.CreateMap<TestPlanIndexes, TestPlanIndexesDTO>().MaxDepth(15);
                cfg.CreateMap<Countries, CountriesDTO>().MaxDepth(15);
                cfg.CreateMap<Instructions, InstructionsDTO>().MaxDepth(15);
                cfg.CreateMap<TestPlans, TestPlansDTO>().MaxDepth(15);
                cfg.CreateMap<TestPlanDetails, TestPlanDetailsDTO>().MaxDepth(15);
                cfg.CreateMap<TestPlanGroupTypeAssigns, TestPlanGroupTypeAssignsDTO>().MaxDepth(15);
                cfg.CreateMap<Settings, SettingsDTO>().MaxDepth(15);
                cfg.CreateMap<SettingUpdates, SettingUpdatesDTO>().MaxDepth(15);
                cfg.CreateMap<SettingGenerals, SettingGeneralsDTO>().MaxDepth(15);
                cfg.CreateMap<MenuAccessStates, MenuAccessStatesDTO>().MaxDepth(15);
                cfg.CreateMap<DenyAccesses, DenyAccessesDTO>().MaxDepth(15);
                cfg.CreateMap<LoginLogs, LoginLogsDTO>().MaxDepth(15);
                cfg.CreateMap<Logs, LogsDTO>().MaxDepth(15);
                cfg.CreateMap<UserGroups, UserGroupsDTO>().MaxDepth(15);
                cfg.CreateMap<UserGroupStations, UserGroupStationsDTO>().MaxDepth(15);
                cfg.CreateMap<UserGroupAssigns, UserGroupAssignsDTO>().MaxDepth(15);
                cfg.CreateMap<StationTypes, StationTypesDTO>().MaxDepth(15);
                cfg.CreateMap<PackagingPlans, PackagingPlansDTO>().MaxDepth(15);
                cfg.CreateMap<Orders, OrdersDTO>().MaxDepth(15);
                cfg.CreateMap<OrderDetails, OrderDetailsDTO>().MaxDepth(15);
                cfg.CreateMap<DensityOfProducts, DensityOfProductsDTO>().MaxDepth(15);
                cfg.CreateMap<RawMaterialLotNumbers, RawMaterialLotNumbersDTO>().MaxDepth(15);
                cfg.CreateMap<TestPlanAssign, TestPlanAssignDTO>().MaxDepth(15);
                cfg.CreateMap<TestPlanAssignDetail, TestPlanAssignDetailDTO>().MaxDepth(15);
                cfg.CreateMap<PackagingTypes, PackagingTypesDTO>().MaxDepth(15);
                cfg.CreateMap<InvRawMaterials, InvRawMaterialsDTO>().MaxDepth(15);
                cfg.CreateMap<InvRawMaterialLots, InvRawMaterialLotsDTO>().MaxDepth(15);
                cfg.CreateMap<TestPlanCodeChar, TestPlanCodeCharDTO>().MaxDepth(15);
                cfg.CreateMap<OrderDetailPackagings, OrderDetailPackagingsDTO>().MaxDepth(15);
                cfg.CreateMap<AutoCompleteField, AutoCompleteFieldDTO>().MaxDepth(15);
                cfg.CreateMap<TestPlanBasicIndex, TestPlanBasicIndexDTO>().MaxDepth(15);
                cfg.CreateMap<RMWhiteLists, RMWhiteListsDTO>().MaxDepth(15);
                cfg.CreateMap<RawMaterialWhiteListAssign, RawMaterialWhiteListAssignDTO>().MaxDepth(15);
                cfg.CreateMap<RawMaterialConfirmation, RawMaterialConfirmationDTO>().MaxDepth(15);
                cfg.CreateMap<BOM, BOMDTO>().MaxDepth(15);
                cfg.CreateMap<BOMDetail, BOMDetailDTO>().MaxDepth(15);
                cfg.CreateMap<BOMComplementary, BOMComplementaryDTO>().MaxDepth(15);
                cfg.CreateMap<CustomerDossier, CustomerDossierDTO>().MaxDepth(15);
                cfg.CreateMap<CustomerDossierBOMs, CustomerDossierBOMsDTO>().MaxDepth(15);
                cfg.CreateMap<ProductionPlanPatilsCapacity, ProductionPlanPatilsCapacityDTO>().MaxDepth(15);
                cfg.CreateMap<ProductionPlanPackaging, ProductionPlanPackagingDTO>().MaxDepth(15);
                cfg.CreateMap<ProductionPlans, ProductionPlansDTO>().MaxDepth(15);
                cfg.CreateMap<ProductionPlanBOMDetailRevised, ProductionPlanBOMDetailRevisedDTO>().MaxDepth(15);
                cfg.CreateMap<ProductionPlanBOMDetail, ProductionPlanBOMDetailDTO>().MaxDepth(15);
                cfg.CreateMap<ProductionPlanPatils, ProductionPlanPatilsDTO>().MaxDepth(15);
                cfg.CreateMap<DeliveryRawMaterialToProduction, DeliveryRawMaterialToProductionDTO>().MaxDepth(15);//.MaxDepth(5).ForMember(x=>x.DeliveryRawMaterialToProductionDetailList, x=>x.Ignore().MaxDepth(15)).ForMember(x=>x.DeliveryRawMaterialToProductionPatilList, x=>x.Ignore().MaxDepth(15));
                cfg.CreateMap<DeliveryRawMaterialToProductionDetail, DeliveryRawMaterialToProductionDetailDTO>().MaxDepth(15);
                cfg.CreateMap<DeliveryRawMaterialToProductionPatils, DeliveryRawMaterialToProductionPatilsDTO>().MaxDepth(15);
                cfg.CreateMap<RawMaterialsDeliveredToProduction, RawMaterialsDeliveredToProductionDTO>().MaxDepth(15);
                cfg.CreateMap<RawMaterialsDeliveredToProductionDetail, RawMaterialsDeliveredToProductionDetailDTO>().MaxDepth(15);//.ForMember(x => x.RawMaterials, x => x.DoNotAllowNull().MaxDepth(15));
                cfg.CreateMap<DataProduction, DataProductionDTO>().MaxDepth(15);
                cfg.CreateMap<DataGrindingDetail, DataGrindingDetailDTO>().MaxDepth(15);
                cfg.CreateMap<DataDosingDetail, DataDosingDetailDTO>().MaxDepth(15);
                cfg.CreateMap<Patils, PatilsDTO>().MaxDepth(15);

                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);

                #endregion ModelDTO to Model

                #region ModelDTO to Model

                //cfg.CreateMap<UsersDTO, Users>();
                //cfg.CreateMap<StationsDTO, Stations>();
                //cfg.CreateMap<UnitsDTO, Units>();
                //cfg.CreateMap<RawMaterialGroupsDTO, RawMaterialGroups>();
                //cfg.CreateMap<RawMaterialsDTO, RawMaterials>();
                //cfg.CreateMap<ProvincesDTO, Provinces>();
                //cfg.CreateMap<CustomersDTO, Customers>();
                //cfg.CreateMap<DomainDTO, Domain>();
                //cfg.CreateMap<CustomerGradesDTO, CustomerGrades>();
                //cfg.CreateMap<SaleAgentsDTO, SaleAgents>();
                //cfg.CreateMap<PrintingTechniquesDTO, PrintingTechniques>();
                //cfg.CreateMap<ProductGroupTypesDTO, ProductGroupTypes>();
                //cfg.CreateMap<ProductGroupsDTO, ProductGroups>();
                //cfg.CreateMap<ProductTypesDTO, ProductTypes>();
                //cfg.CreateMap<ProductSeriesDTO, ProductSeries>();
                //cfg.CreateMap<ProductsDTO, Products>();
                //cfg.CreateMap<ProductSerieTechniqueAssignsDTO, ProductSerieTechniqueAssigns>();
                //cfg.CreateMap<RawMaterialGroupTypesDTO, RawMaterialGroupTypes>();
                //cfg.CreateMap<SuppliersDTO, Suppliers>();
                //cfg.CreateMap<TestPlanGroupsDTO, TestPlanGroups>();
                //cfg.CreateMap<TestPlanIndexesDTO, TestPlanIndexes>();
                //cfg.CreateMap<CountriesDTO, Countries>();
                //cfg.CreateMap<InstructionsDTO, Instructions>();
                //cfg.CreateMap<TestPlansDTO, TestPlans>();
                //cfg.CreateMap<TestPlanDetailsDTO, TestPlanDetails>();
                //cfg.CreateMap<TestPlanGroupTypeAssignsDTO, TestPlanGroupTypeAssigns>();
                //cfg.CreateMap<SettingsDTO, Settings>();
                //cfg.CreateMap<SettingUpdatesDTO, SettingUpdates>();
                //cfg.CreateMap<SettingGeneralsDTO, SettingGenerals>();
                //cfg.CreateMap<MenuAccessStatesDTO, MenuAccessStates>();
                //cfg.CreateMap<DenyAccessesDTO, DenyAccesses>();
                //cfg.CreateMap<LoginLogsDTO, LoginLogs>();
                //cfg.CreateMap<LogsDTO, Logs>();
                //cfg.CreateMap<UserGroupsDTO, UserGroups>();
                //cfg.CreateMap<UserGroupStationsDTO, UserGroupStations>();
                //cfg.CreateMap<UserGroupAssignsDTO, UserGroupAssigns>();
                //cfg.CreateMap<StationTypesDTO, StationTypes>();
                //cfg.CreateMap<PackagingPlansDTO, PackagingPlans>();
                //cfg.CreateMap<OrdersDTO, Orders>();
                //cfg.CreateMap<OrderDetailsDTO, OrderDetails>();
                //cfg.CreateMap<DensityOfProductsDTO, DensityOfProducts>();
                //cfg.CreateMap<RawMaterialLotNumbersDTO, RawMaterialLotNumbers>();
                //cfg.CreateMap<TestPlanAssignDTO, TestPlanAssign>();
                //cfg.CreateMap<TestPlanAssignDetailDTO, TestPlanAssignDetail>();
                //cfg.CreateMap<PackagingTypesDTO, PackagingTypes>();
                //cfg.CreateMap<InvRawMaterialsDTO, InvRawMaterials>();
                //cfg.CreateMap<InvRawMaterialLotsDTO, InvRawMaterialLots>();
                //cfg.CreateMap<TestPlanCodeCharDTO, TestPlanCodeChar>();
                //cfg.CreateMap<OrderDetailPackagingsDTO, OrderDetailPackagings>();
                //cfg.CreateMap<AutoCompleteFieldDTO, AutoCompleteField>();
                //cfg.CreateMap<TestPlanBasicIndexDTO, TestPlanBasicIndex>();
                //cfg.CreateMap<RMWhiteListsDTO, RMWhiteLists>();
                //cfg.CreateMap<RawMaterialWhiteListAssignDTO, RawMaterialWhiteListAssign>();
                //cfg.CreateMap<RawMaterialConfirmationDTO, RawMaterialConfirmation>();
                //cfg.CreateMap<BOMDTO, BOM>();
                //cfg.CreateMap<BOMDetailDTO, BOMDetail>();
                //cfg.CreateMap<BOMComplementaryDTO, BOMComplementary>();
                //cfg.CreateMap<CustomerDossierDTO, CustomerDossier>();
                //cfg.CreateMap<CustomerDossierBOMsDTO, CustomerDossierBOMs>();
                //cfg.CreateMap<ProductionPlanPatilsCapacityDTO, ProductionPlanPatilsCapacity>();
                //cfg.CreateMap<ProductionPlanPackagingDTO, ProductionPlanPackaging>();
                //cfg.CreateMap<ProductionPlansDTO, ProductionPlans>();
                //cfg.CreateMap<ProductionPlanBOMDetailRevisedDTO, ProductionPlanBOMDetailRevised>();
                //cfg.CreateMap<ProductionPlanBOMDetailDTO, ProductionPlanBOMDetail>();
                //cfg.CreateMap<ProductionPlanPatilsDTO, ProductionPlanPatils>();
                //cfg.CreateMap<DeliveryRawMaterialToProductionDTO, DeliveryRawMaterialToProduction>();
                //cfg.CreateMap<DeliveryRawMaterialToProductionDetail, DeliveryRawMaterialToProductionDetail>();
                //cfg.CreateMap<DeliveryRawMaterialToProductionPatils, DeliveryRawMaterialToProductionPatils>();
                //cfg.CreateMap<RawMaterialsDeliveredToProduction, RawMaterialsDeliveredToProduction>();
                //cfg.CreateMap<RawMaterialsDeliveredToProductionDetail, RawMaterialsDeliveredToProductionDetail>();
                #endregion ModelDTO to Model

            });

            //Create an Instance of Mapper and return that Instance

            _initializeAutomapper = new Mapper(config);


            return _initializeAutomapper;
        }

    }

    public partial class ExtAutoMapper
    {

        //public static void TempMapper<TSource, TDestination>(TSource obj)
        //{
        //    //Initializing AutoMapper
        //    var mapper = AutoMapperConfig.InitializeAutomapper();
        //    //Way1: Specify the Destination Type and to The Map Method pass the Source Object
        //    //Now, empDTO1 object will having the same values as emp object
        //    //var empDTO1 = mapper.Map<T>(tt);
        //    var empDTO1 = mapper.Map<TDestination>(obj);
        //    //var empDTO2 = mapper.Map<Temp, TempDTO>(tt);

        //}

        public static void TempMapper<TSource, TDestination>(TSource obj)
        {
            //Initializing AutoMapper
            var mapper = ExtAutoMapper.InitializeAutomapper();



            var empDTO1 = mapper.Map<TDestination>(obj);
            var empDTO2 = mapper.Map<TDestination>(obj);
            //var empDTO2 = mapper.Map<Temp, TempDTO>(tt);

        }

        /// <summary>
        /// پس از مپ کردن رشته جیسون بازمیگرداند
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string MapToJson<TSource, TDestination>(TSource obj)
        {
            try
            {
                var mapped = ExtAutoMapper.Mapper.Map<TSource, TDestination>(obj);

                var jStr = JSON.ToJson(mapped).Result;

                return jStr;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// پس از مپ کردن رشته جیسون بازمیگرداند
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<string> MapToJsonList<TSource, TDestination>(TSource obj)
        {
            try
            {
                var mapped = ExtAutoMapper.Mapper.Map<TSource, TDestination>(obj);

                var jStr = JSON.ToJson(mapped).Result;

                return new List<string>() { jStr };
            }
            catch
            {
                throw;
            }
        }


    }

    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> IncludeMultiple<TEntity>(
            this IQueryable<TEntity> query,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class
        {
            if (includes == null || includes.Length == 0)
                return query;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }
    }

    public static partial class ModelExtensions
    {
        public static List<T> ToListIfNotEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Count() == 0 ? null : enumerable.ToList();
        }

        public static TokenDto ConvertToDto(this JwtTokensData token)
        {
            return new TokenDto
            {

                Token = "Bearer " + token.AccessToken,
                //   RefreshToken = token.RefreshToken,
            };
        }
        public static List<TokenDto> ConvertToListDto(this JwtTokensData token)
        {
            List<TokenDto> list2 = new List<TokenDto>();
            list2.Add(token.ConvertToDto());
            return list2;

        }

        #region ConvertToDto

        public static SysUserDto ConvertToDto(this SysUserAccount token)
        {
            return new SysUserDto
            {
                Username = token.Username,
                FirstName = token.FirstName,
                LastName = token.LastName,
                IsActive = token.IsActive,
            };
        }
        public static UsersDTO ConvertToDto(this Users user)
        {
            if (user == null)
                return null;

            return new UsersDTO
            {
                //UserID = user.UserID,
                //Username = user.Username,
                //FullName = user.FullName ?? string.Empty,
                //MessageSignature = user.MessageSignature ?? string.Empty,
                //Description = user.Description ?? string.Empty,
                //CanLogin = user.CanLogin,
                //IsActive = user.IsActive,

                UserID = user.UserID,
                FullName = user.FullName,
                Username = user.Username,
                Password = user.Password,
                Last = user.Last,
                StationID = user.StationID,
                AuthenticationType = user.AuthenticationType,
                Description = user.Description,
                DomainID = user.DomainID,
                LoginType = user.LoginType,
                CanLogin = (bool)user.CanLogin,
                IsEntered = user.IsEntered,
                IsActive = user.IsActive,
                IsAdmin = user.IsAdmin,
                IsSysAdmin = user.IsSysAdmin,
                IsManager = user.IsManager,
                IsSupervisor = user.IsSupervisor,
                IsExpert = user.IsExpert,
                IsOperator = user.IsOperator,
                IsSpecialUser = user.IsSpecialUser,
                GetUrgentRequest = user.GetUrgentRequest,
                MessageSignature = user.MessageSignature,
                InsDate = user.InsDate,
                InsTime = user.InsTime,
                InsUserID = user.InsUserID,
                EditDate = user.EditDate,
                EditTime = user.EditTime,
                EditUserID = user.EditUserID,


            };
        }
        public static StationsDTO ConvertToDto(this Stations station)
        {
            if (station == null)
                return null;


            return new StationsDTO
            {
                StationID = station.StationID,
                StationName = station.StationName ?? string.Empty,
                StationLatinName = station.StationLatinName ?? string.Empty,
                StationTypeID = station.StationTypeID,
                AllowableStopsInDay = System.Convert.ToInt32(station.AllowableStopsInDay),
                BarcodeSign = station.BarcodeSign ?? string.Empty,
                IsActive = station.IsActive,
                FWWidth = station.FWWidth,
                MinNoOfEmptyBobins = station.MinNoOfEmptyBobins,
                SpeedMMin = station.SpeedMMin,
                InsUserID = station.InsUserID,
                InsDate = station.InsDate,
                InsTime = station.InsTime,
                EditUserID = station.EditUserID,
                EditDate = station.EditDate,
                EditTime = station.EditTime,
                StationType = station.StationType.ConvertToDto(),
                User_InsUser = station.User_InsUser.ConvertToDto(),
                //User_EditUser = station.User_EditUser.ConvertToDto(),

            };
        }

        public static StationTypesDTO ConvertToDto(this StationTypes stationTypes)
        {
            if (stationTypes == null)
                return null;

            return new StationTypesDTO
            {
                StationTypeID = stationTypes.StationTypeID,
                StationTypeName = stationTypes.StationTypeName,
                StationTypeLatinName = stationTypes.StationTypeLatinName,
                IsActive = stationTypes.IsActive,
                InsDate = stationTypes.InsDate,
                InsTime = stationTypes.InsTime,
                InsUserID = stationTypes.InsUserID,
                EditDate = stationTypes.EditDate,
                EditTime = stationTypes.EditTime,
                EditUserID = stationTypes.EditUserID,


            };
        }

        public static UnitsDTO ConvertToDto(this Units unit)
        {
            if (unit == null)
                return null;

            return new UnitsDTO
            {
                UnitID = unit.UnitID,
                UnitName = unit.UnitName ?? string.Empty,
                UnitLatinName = unit.UnitLatinName ?? string.Empty,
                Abbreviation = unit.Abbreviation,
            };
        }

        public static DomainDTO ConvertToDto(this Domain domain)
        {
            if (domain == null)
                return null;

            return new DomainDTO
            {
                DomainID = domain.DomainID,
                DomainName = domain.DomainName ?? string.Empty,
                DomainAddress = domain.DomainAddress ?? string.Empty,
                Describe = domain.Describe ?? string.Empty,
                IsActive = domain.IsActive,
            };
        }


        public static CustomerGradesDTO ConvertToDto(this CustomerGrades customerGrades)
        {
            if (customerGrades == null)
                return null;

            return new CustomerGradesDTO
            {
                CustomerGradeID = customerGrades.CustomerGradeID,
                CustomerGradeName = customerGrades.CustomerGradeName,
                IsActive = customerGrades.IsActive,
            };
        }


        public static ProvincesDTO ConvertToDto(this Provinces provinces)
        {
            if (provinces == null)
                return null;

            return new ProvincesDTO
            {
                ProvinceID = provinces.ProvinceID,
                CountryID = provinces.CountryID,
                Countries = provinces.Countries.ConvertToDto(),
                ProvinceCode = provinces.ProvinceCode ?? string.Empty,
                ProvinceName = provinces.ProvinceName ?? string.Empty,
                ProvinceLatinName = provinces.ProvinceLatinName ?? string.Empty,
                IsActive = provinces.IsActive,
            };
        }

        public static SaleAgentsDTO ConvertToDto(this SaleAgents saleAgents)
        {
            if (saleAgents == null)
                return null;

            return new SaleAgentsDTO
            {
                SaleAgentID = saleAgents.SaleAgentID,
                SaleAgentCode = saleAgents.SaleAgentCode,
                SaleAgentName = saleAgents.SaleAgentName,
                SaleAgentLatinName = saleAgents.SaleAgentLatinName,
                SaleAgentLocalizedName = saleAgents.SaleAgentLocalizedName,
                ProvinceID = saleAgents.ProvinceID,
                Province = saleAgents.Province.ConvertToDto(),
                IsForeign = saleAgents.IsForeign,
                ContactPerson = saleAgents.ContactPerson,
                IsActive = saleAgents.IsActive,
                Rating = saleAgents.Rating,
                CustomerGradeID = saleAgents.CustomerGradeID,
                CustomerGrade = saleAgents.CustomerGrade.ConvertToDto(),
                StartDate = saleAgents.StartDate,
                Address = saleAgents.Address,
                Tel = saleAgents.Tel,
                ZipCode = saleAgents.ZipCode,


            };
        }

        public static CustomersDTO ConvertToDto(this Customers customers)
        {
            if (customers == null)
                return null;

            return new CustomersDTO
            {
                CustomerID = customers.CustomerID,
                CustomerCode = customers.CustomerCode,
                CustomerName = customers.CustomerName,
                CustomerLatinName = customers.CustomerLatinName,
                CustomerLableName = customers.CustomerLableName,
                ProvinceID = customers.ProvinceID,
                Province = customers.Province.ConvertToDto(),
                Address = customers.Address,
                Tel = customers.Tel,
                IsForeign = customers.IsForeign,
                ContactPerson = customers.ContactPerson,
                InvoicingAddress = customers.InvoicingAddress,
                DeliveryAddress = customers.DeliveryAddress,
                IsConfirmed = customers.IsConfirmed,
                IsActive = customers.IsActive,
                Rating = customers.Rating,
                StartDate = customers.StartDate,
                CustomerGradeID = customers.CustomerGradeID,
                CustomerGrade = customers.CustomerGrade.ConvertToDto(),
                ZipCode = customers.ZipCode,
                NationalIdentity = customers.NationalIdentity,
                RegistrationNumber = customers.RegistrationNumber,
                EconomicCode = customers.EconomicCode,
                CEO = customers.CEO,
                InvoiceRecipient = customers.InvoiceRecipient,
                InsUserID = customers.InsUserID,
                InsDate = customers.InsDate,
                InsTime = customers.InsTime,
                EditUserID = customers.EditUserID,
                EditDate = customers.EditDate,
                EditTime = customers.EditTime,
                User_InsUser = customers.User_InsUser.ConvertToDto(),
                User_EditUser = customers.User_EditUser.ConvertToDto(),


            };
        }

        public static PrintingTechniquesDTO ConvertToDto(this PrintingTechniques printingTechniques)
        {
            if (printingTechniques == null)
                return null;

            return new PrintingTechniquesDTO
            {
                PrintingTechniqueID = printingTechniques.PrintingTechniqueID,
                PrintingTechniqueName = printingTechniques.PrintingTechniqueName,
                PrintingTechniqueLatinName = printingTechniques.PrintingTechniqueLatinName,
                IsActive = printingTechniques.IsActive,
            };
        }

        public static ProductGroupTypesDTO ConvertToDto(this ProductGroupTypes productGroupTypes)
        {
            if (productGroupTypes == null)
                return null;

            return new ProductGroupTypesDTO
            {
                ProductGroupTypeID = productGroupTypes.ProductGroupTypeID,
                ProductGroupTypeName = productGroupTypes.ProductGroupTypeName,
                ProductGroupTypeLatinName = productGroupTypes.ProductGroupTypeLatinName,
                IsActive = productGroupTypes.IsActive,


            };
        }

        public static ProductGroupsDTO ConvertToDto(this ProductGroups productGroups)
        {
            if (productGroups == null)
                return null;

            return new ProductGroupsDTO
            {
                ProductGroupID = System.Convert.ToInt16(productGroups.ProductGroupID),
                ProductGroupName = productGroups.ProductGroupName,
                ProductGroupLatinName = productGroups.ProductGroupLatinName,
                ProductGroupTypeID = productGroups.ProductGroupTypeID,
                BOMSerialCode = productGroups.BOMSerialCode,
                IsActive = productGroups.IsActive,
                ProductGroupType = productGroups.ProductGroupType.ConvertToDto(),
            };
        }

        public static ProductTypesDTO ConvertToDto(this ProductTypes productTypes)
        {
            if (productTypes == null)
                return null;

            return new ProductTypesDTO
            {
                ProductTypeID = productTypes.ProductTypeID,
                ProductTypeName = productTypes.ProductTypeName,
                ProductTypeLatinName = productTypes.ProductTypeLatinName,
                ProductTypeLabelName = productTypes.ProductTypeLabelName,
                ProductTypeLabelLatinName = productTypes.ProductTypeLabelLatinName,
                ProductGroupID = productTypes.ProductGroupID,
                ProductGroup = productTypes.ProductGroup.ConvertToDto(),
                BOMSerialCode = productTypes.BOMSerialCode,
                IsActive = productTypes.IsActive,


            };
        }

        public static ProductSeriesDTO ConvertToDto(this ProductSeries productSeries)
        {
            if (productSeries == null)
                return null;

            return new ProductSeriesDTO
            {
                ProductSerieID = productSeries.ProductSerieID,
                ProductSerieName = productSeries.ProductSerieName,
                ProductTypeID = productSeries.ProductTypeID,
                ProductType = productSeries.ProductType.ConvertToDto(),
                ProductSerieLabelName = productSeries.ProductSerieLabelName,
                ProductSerieLatinLabelName = productSeries.ProductSerieLatinLabelName,
                Usages = productSeries.Usages,
                BOMSerialCode = productSeries.BOMSerialCode,
                IsActive = productSeries.IsActive,
                ProductSerieTechniqueList = productSeries.ProductSerieTechniqueList?.ConvertToListDto(),
            };
        }


        public static ProductsDTO ConvertToDto(this Products products)
        {
            if (products == null)
                return null;

            return new ProductsDTO
            {
                ProductID = products.ProductID,
                ProductCode = products.ProductCode,
                SerialCode = products.SerialCode,
                ProductName = products.ProductName,
                ProductLatinName = products.ProductLatinName,
                ProductLabelName = products.ProductLabelName,
                ProductLatinLabelName = products.ProductLatinLabelName,
                ProductSerieID = products.ProductSerieID,
                ProductSerie = products.ProductSerie.ConvertToDto(),
                PrintingTechniqueID = products.PrintingTechniqueID,
                PrintingTechniques = products.PrintingTechniques.ConvertToDto(),
                TestPlanID = products.TestPlanID,
                ShelfLifeMonth = products.ShelfLifeMonth,
                TestPlan = products.TestPlan.ConvertToDto(),
                //TestPlanAssign = products.TestPlanAssign.ConvertToDto(),
                IsSemiProduct = products.IsSemiProduct,
                Final_RawMaterialID = products.Final_RawMaterialID,
                Final_ProductID = products.Final_ProductID,
                IsPaste = products.IsPaste,
                BOMSerialCode = products.BOMSerialCode,
                IsActive = products.IsActive,


            };
        }


        public static ProductSerieTechniqueAssignsDTO ConvertToDto(this ProductSerieTechniqueAssigns productSerieTechniqueAssigns)
        {
            if (productSerieTechniqueAssigns == null)
                return null;

            return new ProductSerieTechniqueAssignsDTO
            {
                ProductSerieTechniqueAssignID = productSerieTechniqueAssigns.ProductSerieTechniqueAssignID,
                ProductSerieID = productSerieTechniqueAssigns.ProductSerieID,
                ProductSerie = productSerieTechniqueAssigns.ProductSerie.ConvertToDto(),
                PrintingTechniqueID = productSerieTechniqueAssigns.PrintingTechniqueID,
                PrintingTechnique = productSerieTechniqueAssigns.PrintingTechnique.ConvertToDto(),


            };
        }

        public static RawMaterialGroupTypesDTO ConvertToDto(this RawMaterialGroupTypes rawMaterialGroupTypes)
        {
            if (rawMaterialGroupTypes == null)
                return null;

            return new RawMaterialGroupTypesDTO
            {
                RawMaterialGroupTypeID = rawMaterialGroupTypes.RawMaterialGroupTypeID,
                RawMaterialGroupTypeName = rawMaterialGroupTypes.RawMaterialGroupTypeName,
                RawMaterialGroupTypeLatinName = rawMaterialGroupTypes.RawMaterialGroupTypeLatinName,
                IsLiquid = rawMaterialGroupTypes.IsLiquid,
                IsActive = rawMaterialGroupTypes.IsActive,


            };
        }

        public static RawMaterialGroupsDTO ConvertToDto(this RawMaterialGroups rawMaterialGroups)
        {
            if (rawMaterialGroups == null)
                return null;

            return new RawMaterialGroupsDTO
            {
                RawMaterialGroupID = rawMaterialGroups.RawMaterialGroupID,
                RawMaterialGroupName = rawMaterialGroups.RawMaterialGroupName,
                RawMaterialGroupLatinName = rawMaterialGroups.RawMaterialGroupLatinName,
                RawMaterialGroupTypeID = rawMaterialGroups.RawMaterialGroupTypeID,
                RawMaterialGroupType = rawMaterialGroups.RawMaterialGroupType.ConvertToDto(),
                StorageConditions = rawMaterialGroups.StorageConditions,
                IsActive = rawMaterialGroups.IsActive,
            };
        }

        public static RawMaterialsDTO ConvertToDto(this RawMaterials rawMaterials)
        {
            if (rawMaterials == null)
                return null;

            ///break loop
            rawMaterials.RMWhiteListAssign?.Where(x => x.RawMaterial?.RawMaterialID == x.RawMaterialID).ToList().ForEach(x => x.RawMaterial = null);
            rawMaterials.LotNosList?.Where(x => x.RawMaterial?.RawMaterialID == x.RawMaterialID).ToList().ForEach(x => x.RawMaterial = null);
            //productionPlans.ProductionPlanPackagingList?.Where(x => x.ProductionPlan?.ProductionPlanID == x.ProductionPlanID).ToList().ForEach(x => x.ProductionPlan = null);

            return new RawMaterialsDTO
            {
                RawMaterialID = rawMaterials.RawMaterialID,
                RawMaterialOriginCode = rawMaterials.RawMaterialOriginCode,
                RawMaterialOriginName = rawMaterials.RawMaterialOriginName,
                RawMaterialCode = rawMaterials.RawMaterialCode,
                RawMaterialName = rawMaterials.RawMaterialName,
                RawMaterialLatinName = rawMaterials.RawMaterialLatinName,
                UnitID = rawMaterials.UnitID,
                Units = rawMaterials.Units.ConvertToDto(),
                RawMaterialGroupID = rawMaterials.RawMaterialGroupID,
                RawMaterialGroups = rawMaterials.RawMaterialGroups.ConvertToDto(),
                SupplierID = rawMaterials.SupplierID,
                Supplier = rawMaterials.Supplier.ConvertToDto(),
                IsRecycled = rawMaterials.IsRecycled,
                StorageConditions = rawMaterials.StorageConditions,
                IsConfirmed = rawMaterials.IsConfirmed,
                IsActive = rawMaterials.IsActive,
                IsSample = rawMaterials.IsSample,
                IsSemiProduct = rawMaterials.IsSemiProduct,
                HasBOMFormula = rawMaterials.HasBOMFormula,
                SolidPercentage = rawMaterials.SolidPercentage,
                RawMaterialSampleID = rawMaterials.RawMaterialSampleID,
                RawMaterial_Sample = rawMaterials.RawMaterial_Sample.ConvertToDto(),
                TestPlanAssignID = rawMaterials.TestPlanAssignID,
                TestPlanAssign = rawMaterials.TestPlanAssign.ConvertToDto(),
                InsUserID = rawMaterials.InsUserID,
                InsDate = rawMaterials.InsDate,
                InsTime = rawMaterials.InsTime,
                LotNosList = rawMaterials.LotNosList.ConvertToListDto(),
                RMWhiteListAssign = rawMaterials.RMWhiteListAssign.ConvertToListDto(),
                //ParentID = rawMaterials.ParentID,
                //Parent = rawMaterials.Parent.ConvertToDto(),

            };
        }

        public static SuppliersDTO ConvertToDto(this Suppliers suppliers)
        {
            if (suppliers == null)
                return null;

            return new SuppliersDTO
            {
                SupplierID = suppliers.SupplierID,
                SupplierCode = suppliers.SupplierCode,
                SupplierName = suppliers.SupplierName,
                SupplierLatinName = suppliers.SupplierLatinName,
                SupplierOriginName = suppliers.SupplierOriginName,
                ContactPerson = suppliers.ContactPerson,
                ProvinceID = suppliers.ProvinceID,
                Province = suppliers.Province.ConvertToDto(),
                Tel = suppliers.Tel,
                Address = suppliers.Address,
                ZipCode = suppliers.ZipCode,
                NationalIdentity = suppliers.NationalIdentity,
                RegistrationNumber = suppliers.RegistrationNumber,
                EconomicCode = suppliers.EconomicCode,
                Rating = suppliers.Rating,
                CustomerGradeID = suppliers.CustomerGradeID,
                CustomerGrade = suppliers.CustomerGrade.ConvertToDto(),
                StartDate = suppliers.StartDate,
                CEO = suppliers.CEO,
                InsUserID = suppliers.InsUserID,
                InsDate = suppliers.InsDate,
                InsTime = suppliers.InsTime,
                EditUserID = suppliers.EditUserID,
                EditDate = suppliers.EditDate,
                EditTime = suppliers.EditTime,
                IsForeign = suppliers.IsForeign,
                IsActive = suppliers.IsActive,


            };
        }


        public static TestPlanGroupsDTO ConvertToDto(this TestPlanGroups testPlanGroups)
        {
            if (testPlanGroups == null)
                return null;

            return new TestPlanGroupsDTO
            {
                TestPlanGroupID = testPlanGroups.TestPlanGroupID,
                TestPlanGroupCode = testPlanGroups.TestPlanGroupCode,
                TestPlanGroupName = testPlanGroups.TestPlanGroupName,
                TestPlanGroupSign = testPlanGroups.TestPlanGroupSign,
                IsActive = testPlanGroups.IsActive,


            };
        }

        public static TestPlanIndexesDTO ConvertToDto(this TestPlanIndexes testPlanIndexes)
        {
            if (testPlanIndexes == null)
                return null;

            return new TestPlanIndexesDTO
            {
                TestPlanIndexID = testPlanIndexes.TestPlanIndexID,
                TestPlanIndexName = testPlanIndexes.TestPlanIndexName,
                Describe = testPlanIndexes.Describe,
                IsRawMaterialIndex = testPlanIndexes.IsRawMaterialIndex,
                IsProductIndex = testPlanIndexes.IsProductIndex,
                TestPlanIndexFieldTypeID = testPlanIndexes.TestPlanIndexFieldTypeID,
                IsActive = testPlanIndexes.IsActive,


            };
        }

        public static CountriesDTO ConvertToDto(this Countries countries)
        {
            if (countries == null)
                return null;

            return new CountriesDTO
            {
                CountryID = countries.CountryID,
                CountryName = countries.CountryName,
                CountryLatinName = countries.CountryLatinName,
                IsActive = countries.IsActive,

            };
        }

        public static InstructionsDTO ConvertToDto(this Instructions instructions)
        {
            if (instructions == null)
                return null;

            return new InstructionsDTO
            {
                InstructionID = instructions.InstructionID,
                InstructionCode = instructions.InstructionCode,
                InstructionName = instructions.InstructionName,
                IsActive = instructions.IsActive,


            };
        }

        public static TestPlansDTO ConvertToDto(this TestPlans testPlans)
        {
            if (testPlans == null)
                return null;

            //Ignor Loop
            testPlans.TestPlanAssign?.Where(x => x.TestPlan?.TestPlanID == x.TestPlanID).ToList().ForEach(x => x.TestPlan = null);
            testPlans.TestPlanDetails?.Where(x => x.TestPlan?.TestPlanID == x.TestPlanID).ToList().ForEach(x => x.TestPlan = null);

            return new TestPlansDTO
            {
                TestPlanID = testPlans.TestPlanID,
                MaterialTypeID = testPlans.MaterialTypeID,
                ProductTypeID = testPlans.ProductTypeID,
                ProductGroup = testPlans.ProductGroup.ConvertToDto(),
                RawMaterialGroupTypeID = testPlans.RawMaterialGroupTypeID,
                RawMaterialGroupType = testPlans.RawMaterialGroupType.ConvertToDto(),
                TestPlanMCode = testPlans.TestPlanMCode,
                TestPlanCode = testPlans.TestPlanCode,
                TestPlanCodeChar = testPlans.TestPlanCodeChar,
                TestPlanCodeNum = testPlans.TestPlanCodeNum,
                TestPlanCodeSeri = testPlans.TestPlanCodeSeri,
                TestPlanCodeVersion = testPlans.TestPlanCodeVersion,
                Version = testPlans.Version,
                InsUserID = testPlans.InsUserID,
                InsUserName = testPlans.InsUserName,
                InsUserFullName = testPlans.InsUserFullName,
                InsDate = testPlans.InsDate,
                InsTime = testPlans.InsTime,
                EditUserID = testPlans.EditUserID,
                EditUserName = testPlans.EditUserName,
                EditUserFullName = testPlans.EditUserFullName,
                EditDate = testPlans.EditDate,
                EditTime = testPlans.EditTime,
                IsActive = testPlans.IsActive,
                LastNodeID = testPlans.LastNodeID,
                LastNode = testPlans.LastNodeID == testPlans.TestPlanID ? null : testPlans.LastNode?.ConvertToDto(),
                ParentID = testPlans.ParentID,
                Parent = testPlans.ParentID == testPlans.TestPlanID ? null : testPlans.Parent?.ConvertToDto(),
                Status = testPlans.Status,
                IsConfirmed = testPlans.IsConfirmed,
                TestPlanAssign = testPlans.TestPlanAssign.ConvertToListDto(),
                TestPlanDetails = testPlans.TestPlanDetails.ConvertToListDto(),

            };
        }

        public static TestPlanDetailsDTO ConvertToDto(this TestPlanDetails testPlanDetails)
        {
            if (testPlanDetails == null)
                return null;

            return new TestPlanDetailsDTO
            {
                TestPlanDetailID = testPlanDetails.TestPlanDetailID,
                TestPlanID = testPlanDetails.TestPlanID,
                TestPlan = testPlanDetails.TestPlan.ConvertToDto(),
                TestPlanIndexID = testPlanDetails.TestPlanIndexID,
                TestPlanIndex = testPlanDetails.TestPlanIndex.ConvertToDto(),
                MinVal = testPlanDetails.MinVal,
                MaxVal = testPlanDetails.MaxVal,
                TextPhrase = testPlanDetails.TextPhrase,
                UnitID = testPlanDetails.UnitID,
                Unit = testPlanDetails.Unit.ConvertToDto(),
                DiagnosisMethod = testPlanDetails.DiagnosisMethod,
                TestTool = testPlanDetails.TestTool,
                TestStage = testPlanDetails.TestStage,
                InstructionID = testPlanDetails.InstructionID,
                Instruction = testPlanDetails.Instruction.ConvertToDto(),
                Describe = testPlanDetails.Describe,


            };
        }

        public static SettingsDTO ConvertToDto(this Settings settings)
        {
            if (settings == null)
                return null;

            return new SettingsDTO
            {
                SettingID = settings.SettingID,
                LastVersion = settings.LastVersion,
                LastVersionWarninType = settings.LastVersionWarninType,
                UserID = settings.UserID,
                User = settings.User.ConvertToDto(),
                StationID = settings.StationID,
                Station = settings.Station.ConvertToDto(),
                IsActive = settings.IsActive,
            };
        }

        public static SettingUpdatesDTO ConvertToDto(this SettingUpdates settingUpdates)
        {
            if (settingUpdates == null)
                return null;

            return new SettingUpdatesDTO
            {
                UpdateID = settingUpdates.UpdateID,
                Version = settingUpdates.Version,
                ServerMap = settingUpdates.ServerMap,
                FilesName = settingUpdates.FilesName,
                Date = settingUpdates.Date,
                Describe = settingUpdates.Describe,
            };
        }


        public static SettingUpdateViewModelDTO ConvertToDto(this SettingUpdateViewModel settingUpdateViewModel)
        {
            if (settingUpdateViewModel == null)
                return null;

            return new SettingUpdateViewModelDTO
            {
                SettingID = settingUpdateViewModel.SettingID,
                LastVersion = settingUpdateViewModel.LastVersion,
                LastVersionWarninType = settingUpdateViewModel.LastVersionWarninType,
                UserID = settingUpdateViewModel.UserID,
                User = settingUpdateViewModel.User.ConvertToDto(),
                Users = settingUpdateViewModel.Users.ConvertToListDto(),
                StationID = settingUpdateViewModel.StationID,
                Station = settingUpdateViewModel.Station.ConvertToDto(),
                Stations = settingUpdateViewModel.Stations.ConvertToListDto(),
                IsActive = settingUpdateViewModel.IsActive,
                UpdateID = settingUpdateViewModel.UpdateID,
                Version = settingUpdateViewModel.Version,
                ServerMap = settingUpdateViewModel.ServerMap,
                FilesName = settingUpdateViewModel.FilesName,
                Date = settingUpdateViewModel.Date,
                Describe = settingUpdateViewModel.Describe,

            };
        }

        public static SettingUserViewModelDTO ConvertToDto(this SettingUserViewModel settingUserViewModel)
        {
            if (settingUserViewModel == null)
                return null;

            return new SettingUserViewModelDTO
            {
                LastVersion = settingUserViewModel.LastVersion,
                UserID = settingUserViewModel.UserID,
                FullName = settingUserViewModel.FullName,
                LastVersionWarninType = settingUserViewModel.LastVersionWarninType,
                IsActive = settingUserViewModel.IsActive,
            };
        }

        public static SettingStationViewModelDTO ConvertToDto(this SettingStationViewModel settingStationViewModel)
        {
            if (settingStationViewModel == null)
                return null;

            return new SettingStationViewModelDTO
            {
                StationID = settingStationViewModel.StationID,
                StationName = settingStationViewModel.StationName,
                LastVersionWarninType = settingStationViewModel.LastVersionWarninType,
                IsActive = settingStationViewModel.IsActive,
            };
        }

        public static SettingGeneralsDTO ConvertToDto(this SettingGenerals settingGenerals)
        {
            if (settingGenerals == null)
                return null;

            return new SettingGeneralsDTO
            {
                SettingGeneralID = settingGenerals.SettingGeneralID,
                Version = settingGenerals.Version,
                FactoryNameEn = settingGenerals.FactoryNameEn,
                FactoryNameFa = settingGenerals.FactoryNameFa,
                CalendarCultureInfo = settingGenerals.CalendarCultureInfo,
                CurrencyDecimalSeparator = settingGenerals.CurrencyDecimalSeparator,
                ReportCustomerDraftFormCode = settingGenerals.ReportCustomerDraftFormCode,
                LogOpeningForm = Convert.ToBoolean(settingGenerals.LogOpeningForm),
                LogClosingForm = Convert.ToBoolean(settingGenerals.LogClosingForm),
                LogButtonsClick = Convert.ToBoolean(settingGenerals.LogButtonsClick),
                FactoryCode = settingGenerals.FactoryCode,


            };
        }

        public static MenuAccessStatesDTO ConvertToDto(this MenuAccessStates menuAccessStates)
        {
            if (menuAccessStates == null)
                //return new MenuAccessStatesDTO();
                return null;

            return new MenuAccessStatesDTO
            {
                MenuAccessStateID = menuAccessStates.MenuAccessStateID,
                MenuName = menuAccessStates.MenuName,
                MenuText = menuAccessStates.MenuText,
                State = menuAccessStates.State,
                MenuGroupID = menuAccessStates.MenuGroupID,
            };
        }

        public static DenyAccessesDTO ConvertToDto(this DenyAccesses denyAccesses)
        {
            if (denyAccesses == null)
                return null;

            return new DenyAccessesDTO
            {
                DenyAccessID = denyAccesses.DenyAccessID,
                UserID = denyAccesses.UserID,
                StationID = denyAccesses.StationID,
                MenuGroupID = denyAccesses.MenuGroupID,
                MenuID = denyAccesses.MenuID,
                MenuName = denyAccesses.MenuName,
                Caption = denyAccesses.Caption,
                CaptionPath = denyAccesses.CaptionPath,
                State = denyAccesses.State,
            };
        }

        public static LoginLogsDTO ConvertToDto(this LoginLogs loginLogs)
        {
            if (loginLogs == null)
                return null;

            return new LoginLogsDTO
            {
                LoginLogID = loginLogs.LoginLogID,
                UserID = loginLogs.UserID,
                User = loginLogs.User.ConvertToDto(),
                MachineName = loginLogs.MachineName,
                SystemUserName = loginLogs.SystemUserName,
                StationID = loginLogs.StationID,
                Station = loginLogs.Station.ConvertToDto(),
                LoginDate = loginLogs.LoginDate,
                LoginTime = loginLogs.LoginTime,
                LogoutDate = loginLogs.LogoutDate,
                LogoutTime = loginLogs.LogoutTime,
                Version = loginLogs.Version,
                IPAddresses = loginLogs.IPAddresses,


            };
        }

        public static LogsDTO ConvertToDto(this Logs logs)
        {
            if (logs == null)
                return null;

            return new LogsDTO
            {
                LogID = logs.LogID,
                Date = logs.Date,
                Time = logs.Time,
                UserID = logs.UserID,
                User = logs.User.ConvertToDto(),
                Action = logs.Action,
                Details = logs.Details,
                LoginLogID = logs.LoginLogID,
                LoginLog = logs.LoginLog.ConvertToDto(),
                ServerDateTime = logs.ServerDateTime,
            };
        }

        public static UserGroupsDTO ConvertToDto(this UserGroups userGroups)
        {
            if (userGroups == null)
                return null;

            return new UserGroupsDTO
            {
                UserGroupID = userGroups.UserGroupID,
                UserGroupName = userGroups.UserGroupName,
                Describe = userGroups.Describe,


            };
        }

        public static UserGroupStationsDTO ConvertToDto(this UserGroupStations userGroupStations)
        {
            if (userGroupStations == null)
                return null;

            return new UserGroupStationsDTO
            {
                UserGroupStationID = userGroupStations.UserGroupStationID,
                UserGroupID = userGroupStations.UserGroupID,
                StationID = userGroupStations.StationID,


            };
        }

        public static UserGroupAssignsDTO ConvertToDto(this UserGroupAssigns userGroupAssigns)
        {
            if (userGroupAssigns == null)
                return null;

            return new UserGroupAssignsDTO
            {
                UserGroupAssignID = userGroupAssigns.UserGroupAssignID,
                UserID = userGroupAssigns.UserID,
                User = userGroupAssigns.User.ConvertToDto(),
                UserGroupID = userGroupAssigns.UserGroupID,
                UserGroup = userGroupAssigns.UserGroup.ConvertToDto(),


            };
        }

        public static PackagingPlansDTO ConvertToDto(this PackagingPlans packagingPlans)
        {
            if (packagingPlans == null)
                return null;

            return new PackagingPlansDTO
            {
                PackagingPlanID = packagingPlans.PackagingPlanID,
                PackagingPlanCode = packagingPlans.PackagingPlanCode,
                PackagingPlanName = packagingPlans.PackagingPlanName,
                PackagingPlanDesc = packagingPlans.PackagingPlanDesc,
                EmptyWeight = packagingPlans.EmptyWeight,
                Capacity = packagingPlans.Capacity,
                MinCapacity = packagingPlans.MinCapacity,
                Tolerance = packagingPlans.Tolerance,
                Describe = packagingPlans.Describe,
                EditUserID = packagingPlans.EditUserID,
                EditDate = packagingPlans.EditDate,
                EditTime = packagingPlans.EditTime,
                IsActive = packagingPlans.IsActive,


            };
        }

        //public static PackagingTypesDTO ConvertToDto(this PackagingTypes packagingTypes)
        //{
        //    if (packagingTypes == null)
        //        return null;

        //    return new PackagingTypesDTO
        //    {
        //        PackagingTypeID = packagingTypes.PackagingTypeID,
        //        PackagingTypeCode = packagingTypes.PackagingTypeCode,
        //        PackagingTypeName = packagingTypes.PackagingTypeName,
        //        PackagingTypeDesc = packagingTypes.PackagingTypeDesc,
        //        Describe = packagingTypes.Describe,
        //        Capacity = packagingTypes.Capacity,
        //        Weight = packagingTypes.Weight,
        //        MinCapacity = packagingTypes.MinCapacity,
        //        Tolerance = packagingTypes.Tolerance,
        //        EditUserID = packagingTypes.EditUserID,
        //        EditDate = packagingTypes.EditDate,
        //        EditTime = packagingTypes.EditTime,
        //        IsActive = packagingTypes.IsActive,


        //    };
        //}

        public static OrdersDTO ConvertToDto(this Orders orders)
        {
            if (orders == null)
                return null;

            return new OrdersDTO
            {
                OrderID = orders.OrderID,
                OrderNo = orders.OrderNo,
                CustomerID = orders.CustomerID,
                Customer = orders.Customer.ConvertToDto(),
                SubCustomerID = orders.SubCustomerID,
                SubCustomer = orders.SubCustomer.ConvertToDto(),
                ConfirmDate = orders.ConfirmDate,
                CustomerByeNomber = orders.CustomerByeNomber,
                Remark = orders.Remark,
                Tolerance = orders.Tolerance,
                DeliverFromDate = orders.DeliverFromDate,
                DeliverToDate = orders.DeliverToDate,
                DeliveredDate = orders.DeliveredDate,
                RegisterDate = orders.RegisterDate,
                Status = orders.Status,
                IsSample = orders.IsSample,
                DeliverySample = orders.DeliverySample,
                DeliveryTestReport = orders.DeliveryTestReport,
                PestControlCertificate = orders.PestControlCertificate,
                IsPlanningOrder = orders.IsPlanningOrder,
                PaymentMethod = orders.PaymentMethod,
                SendingReason = orders.SendingReason,
                CustomerIndustry = orders.CustomerIndustry,
                UserID = orders.UserID,
                User = orders.User.ConvertToDto(),
                OrderType = orders.OrderType,
                InsUserID = orders.InsUserID,
                User_InsUser = orders.User_InsUser.ConvertToDto(),
                InsUserName = orders.InsUserName,
                InsUserFullName = orders.InsUserFullName,
                InsDate = orders.InsDate,
                InsTime = orders.InsTime,
                EditUserID = orders.EditUserID,
                User_EditUser = orders.User_EditUser.ConvertToDto(),
                EditUserName = orders.EditUserName,
                EditUserFullName = orders.EditUserFullName,
                EditDate = orders.EditDate,
                EditTime = orders.EditTime,
                OrderDetailList = orders.OrderDetailList.ConvertToListDto(),

            };
        }

        public static OrderDetailsDTO ConvertToDto(this OrderDetails orderDetails)
        {
            if (orderDetails == null)
                return null;

            return new OrderDetailsDTO
            {
                OrderDetailID = orderDetails.OrderDetailID,
                OrderID = orderDetails.OrderID,
                Order = orderDetails.Order.ConvertToDto(),
                ProductID = orderDetails.ProductID,
                Product = orderDetails.Product.ConvertToDto(),
                Quantity = orderDetails.Quantity,
                ProgrammedQuantity = orderDetails.ProgrammedQuantity,
                Status = orderDetails.Status,
                ProducedNo = orderDetails.ProducedNo,
                DeliveredNo = orderDetails.DeliveredNo,
                ProducedWeight = orderDetails.ProducedWeight,
                DeliveredWeight = orderDetails.DeliveredWeight,
                InPlan = orderDetails.InPlan,
                PackagingPlanID = orderDetails.PackagingPlanID,
                PackagingPlan = orderDetails.PackagingPlan.ConvertToDto(),
                Priority = orderDetails.Priority,
                Remark = orderDetails.Remark,
                DeliverDate = orderDetails.DeliverDate,
                OrderRequestDetailID = orderDetails.OrderRequestDetailID,
                PlannedRemain = orderDetails.PlannedRemain,
                WarehouseAmount = orderDetails.WarehouseAmount,
                ConfirmUserID = orderDetails.ConfirmUserID,
                BOMID = orderDetails.BOMID,
                BOM = orderDetails.BOM.ConvertToDto(),
                //PackagingPlanList = orderDetails.PackagingPlanList,
                OrderDetailPackagingList = orderDetails.OrderDetailPackagingList.ConvertToListDto(),
                Radif = orderDetails.Radif,


            };
        }

        public static DensityOfProductsDTO ConvertToDto(this DensityOfProducts densityOfProducts)
        {
            if (densityOfProducts == null)
                return null;

            return new DensityOfProductsDTO
            {
                DensityID = densityOfProducts.DensityID,
                ProductID = densityOfProducts.ProductID,
                Product = densityOfProducts.Product.ConvertToDto(),
                Density = densityOfProducts.Density,


            };
        }

        public static RawMaterialLotNumbersDTO ConvertToDto(this RawMaterialLotNumbers rawMaterialLotNumbers)
        {
            if (rawMaterialLotNumbers == null)
                return null;

            return new RawMaterialLotNumbersDTO
            {
                RawMaterialLotNumberID = rawMaterialLotNumbers.RawMaterialLotNumberID,
                RawMaterialID = rawMaterialLotNumbers.RawMaterialID,
                RepeatNo = rawMaterialLotNumbers.RepeatNo,
                LotNumber = rawMaterialLotNumbers.LotNumber,
                Describe = rawMaterialLotNumbers.Describe,
                InsUserID = rawMaterialLotNumbers.InsUserID,
                InsDate = rawMaterialLotNumbers.InsDate,
                InsTime = rawMaterialLotNumbers.InsTime,
                EditUserID = rawMaterialLotNumbers.EditUserID,
                EditDate = rawMaterialLotNumbers.EditDate,
                EditTime = rawMaterialLotNumbers.EditTime,


            };
        }

        public static TestPlanAssignDTO ConvertToDto(this TestPlanAssign testPlanAssign)
        {
            if (testPlanAssign == null)
                return null;

            testPlanAssign.TestPlanAssignDetails?.Where(x => x.TestPlanAssign?.TestPlanAssignID == x.TestPlanAssignID).ToList().ForEach(x => x.TestPlanAssign = null);


            return new TestPlanAssignDTO
            {
                TestPlanAssignID = testPlanAssign.TestPlanAssignID,
                MaterialTypeID = testPlanAssign.MaterialTypeID,
                ProductID = testPlanAssign.ProductID,
                Product = testPlanAssign.Product.ConvertToDto(),
                RawMaterialGroupTypeID = testPlanAssign.RawMaterialGroupTypeID,
                RawMaterialGroupType = testPlanAssign.RawMaterialGroupType.ConvertToDto(),
                TestPlanID = testPlanAssign.TestPlanID,
                TestPlan = testPlanAssign.TestPlan.ConvertToDto(),
                TestPlanAssignedCode = testPlanAssign.TestPlanAssignedCode,
                AssignedCodeNum = testPlanAssign.AssignedCodeNum,
                Version = testPlanAssign.Version,
                InsUserID = testPlanAssign.InsUserID,
                User_InsUser = testPlanAssign.User_InsUser.ConvertToDto(),
                InsUserName = testPlanAssign.InsUserName,
                InsUserFullName = testPlanAssign.InsUserFullName,
                InsDate = testPlanAssign.InsDate,
                InsTime = testPlanAssign.InsTime,
                EditUserID = testPlanAssign.EditUserID,
                User_EditUser = testPlanAssign.User_EditUser.ConvertToDto(),
                EditUserName = testPlanAssign.EditUserName,
                EditUserFullName = testPlanAssign.EditUserFullName,
                EditDate = testPlanAssign.EditDate,
                EditTime = testPlanAssign.EditTime,
                IsActive = testPlanAssign.IsActive,
                TestPlanAssignDetails = testPlanAssign.TestPlanAssignDetails.ConvertToListDto(),


            };
        }

        public static TestPlanAssignViewModelDTO ConvertToDto(this TestPlanAssignViewModel testPlanAssignViewModel)
        {
            if (testPlanAssignViewModel == null)
                return null;

            return new TestPlanAssignViewModelDTO
            {
                TestPlanAssign_TestPlanAssignID = testPlanAssignViewModel.TestPlanAssign_TestPlanAssignID,
                TestPlanAssign_MaterialTypeID = testPlanAssignViewModel.TestPlanAssign_MaterialTypeID,
                TestPlanAssign_ProductID = testPlanAssignViewModel.TestPlanAssign_ProductID,
                TestPlanAssign_RawMaterialGroupTypeID = testPlanAssignViewModel.TestPlanAssign_RawMaterialGroupTypeID,
                TestPlanAssign_TestPlanID = testPlanAssignViewModel.TestPlanAssign_TestPlanID,
                TestPlanAssign_TestPlanAssignedCode = testPlanAssignViewModel.TestPlanAssign_TestPlanAssignedCode,
                TestPlanAssign_AssignedCodeNum = testPlanAssignViewModel.TestPlanAssign_AssignedCodeNum,
                TestPlanAssign_Version = testPlanAssignViewModel.TestPlanAssign_Version,
                TestPlanAssign_InsSysTime = testPlanAssignViewModel.TestPlanAssign_InsSysTime,
                TestPlanAssign_InsUserID = testPlanAssignViewModel.TestPlanAssign_InsUserID,
                TestPlanAssign_InsUserName = testPlanAssignViewModel.TestPlanAssign_InsUserName,
                TestPlanAssign_InsUserFullName = testPlanAssignViewModel.TestPlanAssign_InsUserFullName,
                TestPlanAssign_InsDate = testPlanAssignViewModel.TestPlanAssign_InsDate,
                TestPlanAssign_InsTime = testPlanAssignViewModel.TestPlanAssign_InsTime,
                TestPlanAssign_EditUserID = testPlanAssignViewModel.TestPlanAssign_EditUserID,
                TestPlanAssign_EditUserName = testPlanAssignViewModel.TestPlanAssign_EditUserName,
                TestPlanAssign_EditUserFullName = testPlanAssignViewModel.TestPlanAssign_EditUserFullName,
                TestPlanAssign_EditDate = testPlanAssignViewModel.TestPlanAssign_EditDate,
                TestPlanAssign_EditTime = testPlanAssignViewModel.TestPlanAssign_EditTime,
                TestPlanAssign_IsActive = testPlanAssignViewModel.TestPlanAssign_IsActive,
                TestPlan_MaterialTypeID = testPlanAssignViewModel.TestPlan_MaterialTypeID,
                TestPlan_TestPlanMCode = testPlanAssignViewModel.TestPlan_TestPlanMCode,
                TestPlan_TestPlanCode = testPlanAssignViewModel.TestPlan_TestPlanCode,
                TestPlan_TestPlanCodeChar = testPlanAssignViewModel.TestPlan_TestPlanCodeChar,
                TestPlan_TestPlanCodeNum = testPlanAssignViewModel.TestPlan_TestPlanCodeNum,
                TestPlan_TestPlanCodeSeri = testPlanAssignViewModel.TestPlan_TestPlanCodeSeri,
                TestPlan_TestPlanCodeVersion = testPlanAssignViewModel.TestPlan_TestPlanCodeVersion,
                TestPlan_Version = testPlanAssignViewModel.TestPlan_Version,
                TestPlanGroup_TestPlanGroupCode = testPlanAssignViewModel.TestPlanGroup_TestPlanGroupCode,
                TestPlanGroup_TestPlanGroupName = testPlanAssignViewModel.TestPlanGroup_TestPlanGroupName,
                TestPlanGroup_TestPlanGroupSign = testPlanAssignViewModel.TestPlanGroup_TestPlanGroupSign,
                ProductGroupType_ProductGroupTypeName = testPlanAssignViewModel.ProductGroupType_ProductGroupTypeName,
                RawMaterialGroupType_RawMaterialGroupTypeName = testPlanAssignViewModel.RawMaterialGroupType_RawMaterialGroupTypeName,

            };
        }

        public static TestPlanAssignDetailDTO ConvertToDto(this TestPlanAssignDetail testPlanAssignDetail)
        {
            if (testPlanAssignDetail == null)
                return null;

            return new TestPlanAssignDetailDTO
            {
                TestPlanAssignDetailID = testPlanAssignDetail.TestPlanAssignDetailID,
                TestPlanAssignID = testPlanAssignDetail.TestPlanAssignID,
                TestPlanAssign = testPlanAssignDetail.TestPlanAssign.ConvertToDto(),
                TestPlanIndexID = testPlanAssignDetail.TestPlanIndexID,
                TestPlanIndex = testPlanAssignDetail.TestPlanIndex.ConvertToDto(),
                MinVal = testPlanAssignDetail.MinVal,
                MaxVal = testPlanAssignDetail.MaxVal,
                TextPhrase = testPlanAssignDetail.TextPhrase,
                UnitID = testPlanAssignDetail.UnitID,
                Unit = testPlanAssignDetail.Unit.ConvertToDto(),
                DiagnosisMethod = testPlanAssignDetail.DiagnosisMethod,
                TestTool = testPlanAssignDetail.TestTool,
                TestStage = testPlanAssignDetail.TestStage,
                InstructionID = testPlanAssignDetail.InstructionID,
                Instruction = testPlanAssignDetail.Instruction.ConvertToDto(),
                Describe = testPlanAssignDetail.Describe,

            };
        }

        //public static InvRawMaterialsDTO ConvertToDto(this InvRawMaterials invRawMaterials)
        //{
        //    if (invRawMaterials == null)
        //        return null;

        //    return new InvRawMaterialsDTO
        //    {
        //        InvRawMaterialID = invRawMaterials.InvRawMaterialID,
        //        RawMaterialID = invRawMaterials.RawMaterialID,
        //        RawMaterial = invRawMaterials.RawMaterial.ConvertToDto(),
        //        //LotNo = invRawMaterials.LotNo,
        //        FinancialRequestNo = invRawMaterials.FinancialRequestNo,
        //        InvProductID = invRawMaterials.InvProductID,
        //        InvProduct = invRawMaterials.InvProduct.ConvertToDto(),
        //        EntryDate = invRawMaterials.EntryDate,
        //        //Weight = invRawMaterials.Weight,
        //        //NetWeight = invRawMaterials.NetWeight,
        //        //PalletQty = invRawMaterials.PalletQty,
        //        //ProducedDate = invRawMaterials.ProducedDate,
        //        //EnProducedDate = invRawMaterials.EnProducedDate,
        //        //ExpireDate = invRawMaterials.ExpireDate,
        //        //EnExpireDate = invRawMaterials.EnExpireDate,
        //        //ShelfLife = invRawMaterials.ShelfLife,
        //        //EnShelfLife = invRawMaterials.EnShelfLife,
        //        //PackagingTypeID = invRawMaterials.PackagingTypeID,
        //        SupplierID = invRawMaterials.SupplierID,
        //        Describe = invRawMaterials.Describe,
        //        IsSample = invRawMaterials.IsSample,
        //        Status = invRawMaterials.Status,
        //        //QcStatus = invRawMaterials.QcStatus,
        //        InsUserID = invRawMaterials.InsUserID,
        //        InsDate = invRawMaterials.InsDate,
        //        InsTime = invRawMaterials.InsTime,
        //        EditUserID = invRawMaterials.EditUserID,
        //        EditDate = invRawMaterials.EditDate,
        //        EditTime = invRawMaterials.EditTime,
        //        //LotNumbers = invRawMaterials.LotNumbers,
        //    };
        //}

        //public static InvRawMaterialLotsDTO ConvertToDto(this InvRawMaterialLots invRawMaterialLots)
        //{
        //    if (invRawMaterialLots == null)
        //        return null;

        //    return new InvRawMaterialLotsDTO
        //    {
        //        InvRawMaterialLotID = invRawMaterialLots.InvRawMaterialLotID,
        //        InvRawMaterialID = invRawMaterialLots.InvRawMaterialID,
        //        LotNo = invRawMaterialLots.LotNo,
        //        IsGenerated = invRawMaterialLots.IsGenerated,
        //        ProducedDate = invRawMaterialLots.ProducedDate,
        //        EnProducedDate = invRawMaterialLots.EnProducedDate,
        //        ExpireDate = invRawMaterialLots.ExpireDate,
        //        EnExpireDate = invRawMaterialLots.EnExpireDate,
        //        ShelfLife = invRawMaterialLots.ShelfLife,
        //        EnShelfLife = invRawMaterialLots.EnShelfLife,
        //        SolidPercentage = invRawMaterialLots.SolidPercentage,
        //        QcStatus = invRawMaterialLots.QcStatus,
        //        RNDStatus = invRawMaterialLots.RNDStatus,
        //        Weight
        //        NetWeight
        //        Describe
        //        PalletQty
        //         = invRawMaterialLots.,
        //    };
        //}

        public static TestPlanCodeCharDTO ConvertToDto(this TestPlanCodeChar testPlanCodeChar)
        {
            if (testPlanCodeChar == null)
                return null;

            return new TestPlanCodeCharDTO
            {
                TestPlanCodeCharID = testPlanCodeChar.TestPlanCodeCharID,
                CodeChar = testPlanCodeChar.CodeChar,
                IsProductType = testPlanCodeChar.IsProductType,


            };
        }

        public static OrderDetailPackagingsDTO ConvertToDto(this OrderDetailPackagings orderDetailPackagings)
        {
            if (orderDetailPackagings == null)
                return null;

            return new OrderDetailPackagingsDTO
            {
                OrderDetailPackagingID = orderDetailPackagings.OrderDetailPackagingID,
                OrderDetailID = orderDetailPackagings.OrderDetailID,
                PackagingPlanID = orderDetailPackagings.PackagingPlanID,
                Priority = orderDetailPackagings.Priority,
            };
        }

        public static AutoCompleteFieldDTO ConvertToDto(this AutoCompleteField autoCompleteField)
        {
            if (autoCompleteField == null)
                return null;

            return new AutoCompleteFieldDTO
            {
                AutoCompleteFieldID = autoCompleteField.AutoCompleteFieldID,
                FieldName = autoCompleteField.FieldName,
                FieldValue = autoCompleteField.FieldValue,


            };
        }

        public static TestPlanBasicIndexDTO ConvertToDto(this TestPlanBasicIndex testPlanBasicIndex)
        {
            if (testPlanBasicIndex == null)
                return null;

            return new TestPlanBasicIndexDTO
            {
                TestPlanBasicIndexID = testPlanBasicIndex.TestPlanBasicIndexID,
                TestPlanIndexID = testPlanBasicIndex.TestPlanIndexID,
                MinVal = testPlanBasicIndex.MinVal,
                MaxVal = testPlanBasicIndex.MaxVal,
                TextPhrase = testPlanBasicIndex.TextPhrase,
                UnitID = testPlanBasicIndex.UnitID,
                DiagnosisMethod = testPlanBasicIndex.DiagnosisMethod,
                TestTool = testPlanBasicIndex.TestTool,
                TestStage = testPlanBasicIndex.TestStage,
                InstructionID = testPlanBasicIndex.InstructionID,


            };
        }

        public static RMWhiteListsDTO ConvertToDto(this RMWhiteLists rMWhiteLists)
        {
            if (rMWhiteLists == null)
                return null;

            return new RMWhiteListsDTO
            {
                RMWhiteListID = rMWhiteLists.RMWhiteListID,
                RMWhiteListCode = rMWhiteLists.RMWhiteListCode,
                RMWhiteListName = rMWhiteLists.RMWhiteListName,
                ProductSerieID = rMWhiteLists.ProductSerieID,
                ProductSerie = rMWhiteLists.ProductSerie.ConvertToDto(),
                IsActive = rMWhiteLists.IsActive,
            };
        }

        public static RawMaterialWhiteListAssignDTO ConvertToDto(this RawMaterialWhiteListAssign rawMaterialWhiteListAssign)
        {
            if (rawMaterialWhiteListAssign == null)
                return null;

            return new RawMaterialWhiteListAssignDTO
            {
                RawMaterialWhiteListAssignID = rawMaterialWhiteListAssign.RawMaterialWhiteListAssignID,
                RawMaterialID = rawMaterialWhiteListAssign.RawMaterialID,
                RawMaterial = rawMaterialWhiteListAssign.RawMaterial.ConvertToDto(),
                RMWhiteListID = rawMaterialWhiteListAssign.RMWhiteListID,
                RMWhiteList = rawMaterialWhiteListAssign.RMWhiteList.ConvertToDto(),
            };
        }

        public static RawMaterialConfirmationDTO ConvertToDto(this RawMaterialConfirmation rawMaterialConfirmation)
        {
            if (rawMaterialConfirmation == null)
                return null;

            return new RawMaterialConfirmationDTO
            {
                RawMaterialConfirmationID = rawMaterialConfirmation.RawMaterialConfirmationID,
                RawMaterialID = rawMaterialConfirmation.RawMaterialID,
                Status = rawMaterialConfirmation.Status,
                IsConfirmed = rawMaterialConfirmation.IsConfirmed,
                InsUserID = rawMaterialConfirmation.InsUserID,
                InsDate = rawMaterialConfirmation.InsDate,
                InsTime = rawMaterialConfirmation.InsTime,
                ConfirmerID = rawMaterialConfirmation.ConfirmerID,
                ConfirmDate = rawMaterialConfirmation.ConfirmDate,
                ConfirmTime = rawMaterialConfirmation.ConfirmTime,
                ConfirmDescribe = rawMaterialConfirmation.ConfirmDescribe,
            };
        }

        public static BOMDTO ConvertToDto(this BOM bom)
        {

            if (bom == null)
                return null;


            //Ignor loop
            bom.BOMDetailList?.Where(x => x.BOM?.BOMID == x.BOMID).ToList().ForEach(x => x.BOM = null);


            return new BOMDTO
            {
                BOMID = bom.BOMID,
                BOMCode = bom.BOMCode,
                ProductID = bom.ProductID,
                Product = bom.Product.ConvertToDto(),
                Status = bom.Status,
                Version = bom.Version,
                ParentID = bom.ParentID,
                Parent = bom.Parent.ConvertToDto(),
                IsMainBOM = bom.IsMainBOM,
                Describe = bom.Describe,
                Ver = bom.Ver,
                CustomerVer = bom.CustomerVer,
                InsUserID = bom.InsUserID,
                User_InsUser = bom.User_InsUser.ConvertToDto(),
                InsUserName = bom.InsUserName,
                InsUserFullName = bom.InsUserFullName,
                InsDate = bom.InsDate,
                InsTime = bom.InsTime,
                IsDraft = bom.IsDraft,
                EditUserID = bom.EditUserID,
                User_EditUser = bom.User_EditUser.ConvertToDto(),
                EditUserName = bom.EditUserName,
                EditUserFullName = bom.EditUserFullName,
                EditDate = bom.EditDate,
                EditTime = bom.EditTime,
                IsActive = bom.IsActive,
                BOMDetailList = bom.BOMDetailList.ConvertToListDto(),
            };
        }

        public static BOMDetailDTO ConvertToDto(this BOMDetail bOMDetail)
        {
            if (bOMDetail == null)
                return null;

            //Ignor loop
            bOMDetail.BOMComplementaryList?.Where(x => x.BOMDetail?.BOMDetailID == x.BOMDetailID).ToList().ForEach(x => x.BOMDetail = null);

            return new BOMDetailDTO
            {
                BOMDetailID = bOMDetail.BOMDetailID,
                BOMID = bOMDetail.BOMID,
                BOM = bOMDetail.BOM.ConvertToDto(),
                RawMaterialID = bOMDetail.RawMaterialID,
                RawMaterial = bOMDetail.RawMaterial.ConvertToDto(),
                RMWhiteListID = bOMDetail.RMWhiteListID,
                RMWhiteList = bOMDetail.RMWhiteList.ConvertToDto(),
                Priority = bOMDetail.Priority,
                Percentage = bOMDetail.Percentage,
                IsFinalRM = bOMDetail.IsFinalRM,
                Describe = bOMDetail.Describe,
                BOMComplementaryList = bOMDetail.BOMComplementaryList.ConvertToListDto(),


            };
        }

        public static BOMComplementaryDTO ConvertToDto(this BOMComplementary bOMComplementary)
        {
            if (bOMComplementary == null)
                return null;

            ////ignor loop
            //if (bOMComplementary.BOMDetail != null)
            //    bOMComplementary.BOMDetail.BOMComplementaryList = null;

            //bOMComplementary.BOMDetail?.BOMComplementaryList?.Where(x => x.BOMDetail?.BOMDetailID == x.BOMDetailID).ToList().ForEach(x => x.BOMDetail = null);
            bOMComplementary.BOMDetail?.BOMComplementaryList?.ForEach(x =>
            {
                if (x.BOMDetail != null && x.BOMDetail?.BOMDetailID == x.BOMDetailID)
                    x.BOMDetail.BOMComplementaryList = null;
            });
            //Where(x => x.BOMDetail?.BOMDetailID == x.BOMDetailID).ToList().ForEach(x => x.BOMDetail = null);

            var complementaryDto = new BOMComplementaryDTO
            {
                BOMComplementaryID = bOMComplementary.BOMComplementaryID,
                BOMDetailID = bOMComplementary.BOMDetailID,
                BOMDetail = bOMComplementary.BOMDetail.ConvertToDto(),
                RawMaterialID = bOMComplementary.RawMaterialID,
                RawMaterial = bOMComplementary.RawMaterial.ConvertToDto(),
                Priority = bOMComplementary.Priority,
                Percentage = bOMComplementary.Percentage,
                Describe = bOMComplementary.Describe,
            };

            return complementaryDto;
        }

        public static CustomerDossierDTO ConvertToDto(this CustomerDossier customerDossier)
        {
            if (customerDossier == null)
                return null;

            return new CustomerDossierDTO
            {
                CustomerDossierID = customerDossier.CustomerDossierID,
                DossierNo = customerDossier.DossierNo,
                RefDossierID = customerDossier.RefDossierID,
                RefDossier = customerDossier.RefDossier.ConvertToDto(),
                CustomerID = customerDossier.CustomerID,
                Customer = customerDossier.Customer.ConvertToDto(),
                ProductID = customerDossier.ProductID,
                Product = customerDossier.Product.ConvertToDto(),
                DefaultBOMID = customerDossier.DefaultBOMID,
                DefaultBOM = customerDossier.DefaultBOM.ConvertToDto(),
                IsActive = customerDossier.IsActive,
                IsDraft = customerDossier.IsDraft,
                TestPlanAssignID = customerDossier.TestPlanAssignID,
                InsUserID = customerDossier.InsUserID,
                User_InsUser = customerDossier.User_InsUser.ConvertToDto(),
                InsDate = customerDossier.InsDate,
                InsTime = customerDossier.InsTime,
                EditUserID = customerDossier.EditUserID,
                User_EditUser = customerDossier.User_EditUser.ConvertToDto(),
                EditDate = customerDossier.EditDate,
                EditTime = customerDossier.EditTime,
                Describe = customerDossier.Describe,
                Status = customerDossier.Status,
            };
        }


        public static CustomerDossierBOMsDTO ConvertToDto(this CustomerDossierBOMs customerDossierBOMs)
        {
            if (customerDossierBOMs == null)
                return null;

            return new CustomerDossierBOMsDTO
            {
                CustomerDossierBOMID = customerDossierBOMs.CustomerDossierBOMID,
                CustomerDossierID = customerDossierBOMs.CustomerDossierID,
                CustomerDossier = customerDossierBOMs.CustomerDossier.ConvertToDto(),
                BOMID = customerDossierBOMs.BOMID,
                BOM = customerDossierBOMs.BOM.ConvertToDto(),
                StartDate = customerDossierBOMs.StartDate,
                StartTime = customerDossierBOMs.StartTime,
                EndDate = customerDossierBOMs.EndDate,
                EndTime = customerDossierBOMs.EndTime,
                Ver = customerDossierBOMs.Ver,
                SerialNumber = customerDossierBOMs.SerialNumber,
                Describe = customerDossierBOMs.Describe,
                IsActive = customerDossierBOMs.IsActive,


            };
        }

        public static ProductionPlanPatilsCapacityDTO ConvertToDto(this ProductionPlanPatilsCapacity productionPlanPatilsCapacity)
        {
            if (productionPlanPatilsCapacity == null)
                return null;

            return new ProductionPlanPatilsCapacityDTO
            {
                ProductionPlanPatilCapacityID = productionPlanPatilsCapacity.ProductionPlanPatilCapacityID,
                ProductionPlanID = productionPlanPatilsCapacity.ProductionPlanID,
                ProductionPlan = productionPlanPatilsCapacity.ProductionPlan.ConvertToDto(),
                Capacity = productionPlanPatilsCapacity.Capacity,
                QTY = productionPlanPatilsCapacity.QTY,


            };
        }

        public static ProductionPlanPackagingDTO ConvertToDto(this ProductionPlanPackaging productionPlanPackaging)
        {
            if (productionPlanPackaging == null)
                return null;

            return new ProductionPlanPackagingDTO
            {
                ProductionPlanPackagingID = productionPlanPackaging.ProductionPlanPackagingID,
                ProductionPlanID = productionPlanPackaging.ProductionPlanID,
                ProductionPlan = productionPlanPackaging.ProductionPlan.ConvertToDto(),
                Priority = productionPlanPackaging.Priority,
                PackagingPlanID = productionPlanPackaging.PackagingPlanID,
                PackagingPlan = productionPlanPackaging.PackagingPlan.ConvertToDto(),
                QTY = productionPlanPackaging.QTY,


            };
        }

        public static ProductionPlansDTO ConvertToDto(this ProductionPlans productionPlans)
        {
            if (productionPlans == null)
                return null;

            productionPlans.ProductionPlanPatilsCapacityList?.Where(x => x.ProductionPlan?.ProductionPlanID == x.ProductionPlanID).ToList().ForEach(x => x.ProductionPlan = null);
            productionPlans.ProductionPlanPackagingList?.Where(x => x.ProductionPlan?.ProductionPlanID == x.ProductionPlanID).ToList().ForEach(x => x.ProductionPlan = null);
            productionPlans.ProductionPlanBOMDetailList?.Where(x => x.ProductionPlan?.ProductionPlanID == x.ProductionPlanID).ToList().ForEach(x => x.ProductionPlan = null);
            productionPlans.ProductionPlanPatilList?.Where(x => x.ProductionPlan?.ProductionPlanID == x.ProductionPlanID).ToList().ForEach(x => x.ProductionPlan = null);

            return new ProductionPlansDTO
            {
                ProductionPlanID = productionPlans.ProductionPlanID,
                OrderDetailID = productionPlans.OrderDetailID,
                OrderDetail = productionPlans.OrderDetail.ConvertToDto(),
                ProducibleQuantity = productionPlans.ProducibleQuantity,
                StartDate = productionPlans.StartDate,
                EndDate = productionPlans.EndDate,
                BatchNo = productionPlans.BatchNo,
                ProductionProcessCirculation = productionPlans.ProductionProcessCirculation,
                ProductionProcessType = productionPlans.ProductionProcessType,
                TransferToInvRM = productionPlans.TransferToInvRM,
                TransferToWarehouse = productionPlans.TransferToWarehouse,
                Describe = productionPlans.Describe,
                Status = productionPlans.Status,
                IsDraft = productionPlans.IsDraft,
                InsUserID = productionPlans.InsUserID,
                User_InsUser = productionPlans.User_InsUser.ConvertToDto(),
                InsDate = productionPlans.InsDate,
                InsTime = productionPlans.InsTime,
                EditUserID = productionPlans.EditUserID,
                User_EditUser = productionPlans.User_EditUser.ConvertToDto(),
                EditDate = productionPlans.EditDate,
                EditTime = productionPlans.EditTime,
                ProductionPlanPatilsCapacityList = productionPlans.ProductionPlanPatilsCapacityList.ConvertToListDto(),
                ProductionPlanPackagingList = productionPlans.ProductionPlanPackagingList.ConvertToListDto(),
                ProductionPlanBOMDetailList = productionPlans.ProductionPlanBOMDetailList.ConvertToListDto(),
                ProductionPlanPatilList = productionPlans.ProductionPlanPatilList.ConvertToListDto(),

            };
        }

        public static ProductionPlanBOMDetailDTO ConvertToDto(this ProductionPlanBOMDetail productionPlanBOMDetail)
        {
            if (productionPlanBOMDetail == null)
                return null;

            return new ProductionPlanBOMDetailDTO
            {
                ProductionPlanBOMDetailID = productionPlanBOMDetail.ProductionPlanBOMDetailID,
                ProductionPlanID = productionPlanBOMDetail.ProductionPlanID,
                BomDetailID = productionPlanBOMDetail.BOMDetailID,
                BOMDetail = productionPlanBOMDetail.BOMDetail.ConvertToDto(),
                RawMaterialID = productionPlanBOMDetail.RawMaterialID,
                RawMaterial = productionPlanBOMDetail.RawMaterial.ConvertToDto(),
                RawMaterialType = productionPlanBOMDetail.RawMaterialType,
                ComplementaryCount = productionPlanBOMDetail.ComplementaryCount,
                Priority = productionPlanBOMDetail.Priority,
                BOMComplementaryDesc = productionPlanBOMDetail.BOMComplementaryDesc,
                Planned = productionPlanBOMDetail.Planned,
                Stock = productionPlanBOMDetail.Stock,
                PlanningReserved = productionPlanBOMDetail.PlanningReserved,
                Expiration = productionPlanBOMDetail.Expiration,
                IsFinalRM = productionPlanBOMDetail.IsFinalRM,
                Describe = productionPlanBOMDetail.Describe,
                Percentage = productionPlanBOMDetail.Percentage,
                RequiredWeight = productionPlanBOMDetail.RequiredWeight,
                EditUserID = productionPlanBOMDetail.EditUserID,
                EditDate = productionPlanBOMDetail.EditDate,
                EditTime = productionPlanBOMDetail.EditTime,
                RowVer = productionPlanBOMDetail.RowVer,


            };
        }

        public static ProductionPlanBOMDetailRevisedDTO ConvertToDto(this ProductionPlanBOMDetailRevised productionPlanBOMDetailRevised)
        {
            if (productionPlanBOMDetailRevised == null)
                return null;

            return new ProductionPlanBOMDetailRevisedDTO
            {
                ProductionPlanBOMDetailRevisedID = productionPlanBOMDetailRevised.ProductionPlanBOMDetailRevisedID,
                ProductionPlanID = productionPlanBOMDetailRevised.ProductionPlanID,
                BOMDetailID = productionPlanBOMDetailRevised.BOMDetailID,
                RawMaterialType = productionPlanBOMDetailRevised.RawMaterialType,
                Priority = productionPlanBOMDetailRevised.Priority,
                Planned = productionPlanBOMDetailRevised.Planned,
                Stock = productionPlanBOMDetailRevised.Stock,
                PlanningReserved = productionPlanBOMDetailRevised.PlanningReserved,
                Expiration = productionPlanBOMDetailRevised.Expiration,
                Describe = productionPlanBOMDetailRevised.Describe,
                PlaningDescribe = productionPlanBOMDetailRevised.PlaningDescribe,
                Percentage = productionPlanBOMDetailRevised.Percentage,
                RequiredWeight = productionPlanBOMDetailRevised.RequiredWeight,
                EditUserID = productionPlanBOMDetailRevised.EditUserID,
                EditDate = productionPlanBOMDetailRevised.EditDate,
                EditTime = productionPlanBOMDetailRevised.EditTime,
                InsDate = productionPlanBOMDetailRevised.InsDate,
            };
        }

        public static ProductionPlanPatilsDTO ConvertToDto(this ProductionPlanPatils productionPlanPatils)
        {
            if (productionPlanPatils == null)
                return null;

            return new ProductionPlanPatilsDTO
            {
                ProductionPlanPatilID = productionPlanPatils.ProductionPlanPatilID,
                ProductionPlanID = productionPlanPatils.ProductionPlanID,
                LotNoNum = productionPlanPatils.LotNoNum,
                LotNo = productionPlanPatils.LotNo,
                PlannedCapacity = productionPlanPatils.PlannedCapacity,


            };
        }

        public static DeliveryRawMaterialToProductionDTO ConvertToDto(this DeliveryRawMaterialToProduction deliveryRawMaterialToProduction)
        {
            if (deliveryRawMaterialToProduction == null)
                return null;

            deliveryRawMaterialToProduction.DeliveryRawMaterialToProductionDetailList?
                .Where(x => x.DeliveryRawMaterialToProduction?.DeliveryRawMaterialToProductionID == x.DeliveryRawMaterialToProductionID).ToList().ForEach(x => x.DeliveryRawMaterialToProduction = null);

            deliveryRawMaterialToProduction.DeliveryRawMaterialToProductionPatilList?
                .Where(x => x.DeliveryRawMaterialToProduction?.DeliveryRawMaterialToProductionID == x.DeliveryRawMaterialToProductionID).ToList().ForEach(x => x.DeliveryRawMaterialToProduction = null);


            return new DeliveryRawMaterialToProductionDTO
            {
                DeliveryRawMaterialToProductionID = deliveryRawMaterialToProduction.DeliveryRawMaterialToProductionID,
                RequestNo = deliveryRawMaterialToProduction.RequestNo,
                RequestDate = deliveryRawMaterialToProduction.RequestDate,
                RequesterID = deliveryRawMaterialToProduction.RequesterID,
                Requester = deliveryRawMaterialToProduction.Requester.ConvertToDto(),
                ProductionPlanID = deliveryRawMaterialToProduction.ProductionPlanID,
                ProductionPlan = deliveryRawMaterialToProduction.ProductionPlan.ConvertToDto(),
                Status = deliveryRawMaterialToProduction.Status,
                InsUserID = deliveryRawMaterialToProduction.InsUserID,
                User_InsUser = deliveryRawMaterialToProduction.User_InsUser.ConvertToDto(),
                InsDate = deliveryRawMaterialToProduction.InsDate,
                InsTime = deliveryRawMaterialToProduction.InsTime,
                IsDraft = deliveryRawMaterialToProduction.IsDraft,
                EditUserID = deliveryRawMaterialToProduction.EditUserID,
                User_EditUser = deliveryRawMaterialToProduction.User_EditUser.ConvertToDto(),
                EditDate = deliveryRawMaterialToProduction.EditDate,
                EditTime = deliveryRawMaterialToProduction.EditTime,
                //RowVer = deliveryRawMaterialToProduction.RowVer,
                DeliveryRawMaterialToProductionDetailList = deliveryRawMaterialToProduction.DeliveryRawMaterialToProductionDetailList.ConvertToListDto(),
                DeliveryRawMaterialToProductionPatilList = deliveryRawMaterialToProduction.DeliveryRawMaterialToProductionPatilList.ConvertToListDto(),


            };
        }

        public static DeliveryRawMaterialToProductionDetailDTO ConvertToDto(this DeliveryRawMaterialToProductionDetail deliveryRawMaterialToProductionDetail)
        {
            if (deliveryRawMaterialToProductionDetail == null)
                return null;

            return new DeliveryRawMaterialToProductionDetailDTO
            {
                DeliveryRawMaterialToProductionDetailID = deliveryRawMaterialToProductionDetail.DeliveryRawMaterialToProductionDetailID,
                DeliveryRawMaterialToProductionID = deliveryRawMaterialToProductionDetail.DeliveryRawMaterialToProductionID,
                DeliveryRawMaterialToProduction = deliveryRawMaterialToProductionDetail.DeliveryRawMaterialToProduction.ConvertToDto(),
                RawMaterialID = deliveryRawMaterialToProductionDetail.RawMaterialID,
                RawMaterial = deliveryRawMaterialToProductionDetail.RawMaterial.ConvertToDto(),
                Planned = deliveryRawMaterialToProductionDetail.Planned,
                InvProduction = deliveryRawMaterialToProductionDetail.InvProduction,
                RemainingToProduction = deliveryRawMaterialToProductionDetail.RemainingToProduction,
                RequestedAmount = deliveryRawMaterialToProductionDetail.RequestedAmount,
                Describe = deliveryRawMaterialToProductionDetail.Describe,


            };
        }

        public static DeliveryRawMaterialToProductionPatilsDTO ConvertToDto(this DeliveryRawMaterialToProductionPatils deliveryRawMaterialToProductionPatils)
        {
            if (deliveryRawMaterialToProductionPatils == null)
                return null;

            return new DeliveryRawMaterialToProductionPatilsDTO
            {
                DeliveryRawMaterialToProductionPatilID = deliveryRawMaterialToProductionPatils.DeliveryRawMaterialToProductionPatilID,
                DeliveryRawMaterialToProductionID = deliveryRawMaterialToProductionPatils.DeliveryRawMaterialToProductionID,
                DeliveryRawMaterialToProduction = deliveryRawMaterialToProductionPatils.DeliveryRawMaterialToProduction.ConvertToDto(),
                ProductionPlanPatilID = deliveryRawMaterialToProductionPatils.ProductionPlanPatilID,
                ProductionPlanPatil = deliveryRawMaterialToProductionPatils.ProductionPlanPatil.ConvertToDto(),


            };
        }

        public static RawMaterialsDeliveredToProductionDTO ConvertToDto(this RawMaterialsDeliveredToProduction rawMaterialsDeliveredToProduction)
        {
            if (rawMaterialsDeliveredToProduction == null)
                return null;

            rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionDetailList?
                .Where(x => x.RawMaterialsDeliveredToProduction?.RawMaterialsDeliveredToProductionID == x.RawMaterialsDeliveredToProductionID).ToList().ForEach(x => x.RawMaterialsDeliveredToProduction = null);

            return new RawMaterialsDeliveredToProductionDTO
            {
                RawMaterialsDeliveredToProductionID = rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionID,
                DeliveryRawMaterialToProductionID = rawMaterialsDeliveredToProduction.DeliveryRawMaterialToProductionID,
                DeliveryRawMaterialToProduction = rawMaterialsDeliveredToProduction.DeliveryRawMaterialToProduction.ConvertToDto(),
                DeliverDate = rawMaterialsDeliveredToProduction.DeliverDate,
                DeliverTime = rawMaterialsDeliveredToProduction.DeliverTime,
                DeliveryUserID = rawMaterialsDeliveredToProduction.DeliveryUserID,
                DeliveryUser = rawMaterialsDeliveredToProduction.DeliveryUser.ConvertToDto(),
                ReceivingUserID = rawMaterialsDeliveredToProduction.ReceivingUserID,
                ReceivingUser = rawMaterialsDeliveredToProduction.ReceivingUser.ConvertToDto(),
                Describe = rawMaterialsDeliveredToProduction.Describe,
                Status = rawMaterialsDeliveredToProduction.Status,
                InsUserID = rawMaterialsDeliveredToProduction.InsUserID,
                User_InsUser = rawMaterialsDeliveredToProduction.User_InsUser.ConvertToDto(),
                InsDate = rawMaterialsDeliveredToProduction.InsDate,
                InsTime = rawMaterialsDeliveredToProduction.InsTime,
                IsDraft = rawMaterialsDeliveredToProduction.IsDraft,
                EditUserID = rawMaterialsDeliveredToProduction.EditUserID,
                User_EditUser = rawMaterialsDeliveredToProduction.User_EditUser.ConvertToDto(),
                EditDate = rawMaterialsDeliveredToProduction.EditDate,
                EditTime = rawMaterialsDeliveredToProduction.EditTime,
                //RowVer = rawMaterialsDeliveredToProduction.RowVer,
                RawMaterialsDeliveredToProductionDetailList = rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionDetailList.ConvertToListDto(),




            };
        }

        public static RawMaterialsDeliveredToProductionDetailDTO ConvertToDto(this RawMaterialsDeliveredToProductionDetail rawMaterialsDeliveredToProductionDetail)
        {
            if (rawMaterialsDeliveredToProductionDetail == null)
                return null;

            return new RawMaterialsDeliveredToProductionDetailDTO
            {
                RawMaterialsDeliveredToProductionDetailID = rawMaterialsDeliveredToProductionDetail.RawMaterialsDeliveredToProductionDetailID,
                RawMaterialsDeliveredToProductionID = rawMaterialsDeliveredToProductionDetail.RawMaterialsDeliveredToProductionID,
                RawMaterialsDeliveredToProduction = rawMaterialsDeliveredToProductionDetail.RawMaterialsDeliveredToProduction.ConvertToDto(),
                RawMaterialID = rawMaterialsDeliveredToProductionDetail.RawMaterialID,
                RawMaterial = rawMaterialsDeliveredToProductionDetail.RawMaterial.ConvertToDto(),
                RequestedAmount = rawMaterialsDeliveredToProductionDetail.RequestedAmount,
                DeliveredAmount = rawMaterialsDeliveredToProductionDetail.DeliveredAmount,
                GeneralLotNumber = rawMaterialsDeliveredToProductionDetail.GeneralLotNumber,
                Describe = rawMaterialsDeliveredToProductionDetail.Describe,


            };
        }

        //public static DataProductionDTO ConvertToDto(this DataProduction dataProduction)
        //{
        //    if (dataProduction == null)
        //        return null;

        //    return new DataProductionDTO
        //    {
        //        DataProductionID = dataProduction.DataProductionID,
        //        ProductionPlanPatilID = dataProduction.ProductionPlanPatilID,
        //        StartDate = dataProduction.StartDate,
        //        StartTime = dataProduction.StartTime,
        //        EndDate = dataProduction.EndDate,
        //        EndTime = dataProduction.EndTime,
        //        Duration = dataProduction.Duration,
        //        Describe = dataProduction.Describe,
        //        PatilID = dataProduction.PatilID,
        //        Patil_Capacity = dataProduction.Patil_Capacity,
        //        Patil_EmptyWeight = dataProduction.Patil_EmptyWeight,
        //        Patil_AfterChargeWeight = dataProduction.Patil_AfterChargeWeight,
        //        Patil_AfterFirstMixWeight = dataProduction.Patil_AfterFirstMixWeight,
        //        Patil_DuringGrindingWeight = dataProduction.Patil_DuringGrindingWeight,
        //        Patil_FinalWeight = dataProduction.Patil_FinalWeight,
        //        Patil_NetWeight = dataProduction.Patil_NetWeight,
        //        Patil_MaterialEvaporation = dataProduction.Patil_MaterialEvaporation,
        //        Patil_Wastes = dataProduction.Patil_Wastes,
        //        Patil_Describe = dataProduction.Patil_Describe,
        //        Dosing_StartDate = dataProduction.Dosing_StartDate,
        //        Dosing_StartTime = dataProduction.Dosing_StartTime,
        //        Dosing_EndDate = dataProduction.Dosing_EndDate,
        //        Dosing_EndTime = dataProduction.Dosing_EndTime,
        //        Dosing_Duration = dataProduction.Dosing_Duration,
        //        Dosing_WeighbridgeNo = dataProduction.Dosing_WeighbridgeNo,
        //        Dosing_ShiftNo = dataProduction.Dosing_ShiftNo,
        //        Dosing_Operators = dataProduction.Dosing_Operators,
        //        Dosing_Wastes = dataProduction.Dosing_Wastes,
        //        Dosing_Stopes = dataProduction.Dosing_Stopes,
        //        Dosing_StopesDesc = dataProduction.Dosing_StopesDesc,
        //        Dosing_Describe = dataProduction.Dosing_Describe,
        //        Mixer_StationID = dataProduction.Mixer_StationID,
        //        Mixer_StartDate = dataProduction.Mixer_StartDate,
        //        Mixer_StartTime = dataProduction.Mixer_StartTime,
        //        Mixer_EndDate = dataProduction.Mixer_EndDate,
        //        Mixer_EndTime = dataProduction.Mixer_EndTime,
        //        Mixer_Duration = dataProduction.Mixer_Duration,
        //        Mixer_ShiftNo = dataProduction.Mixer_ShiftNo,
        //        Mixer_Operators = dataProduction.Mixer_Operators,
        //        Mixer_Wastes = dataProduction.Mixer_Wastes,
        //        Mixer_Stopes = dataProduction.Mixer_Stopes,
        //        Mixer_StopesDesc = dataProduction.Mixer_StopesDesc,
        //        Mixer_StationSpeed = dataProduction.Mixer_StationSpeed,
        //        Mixer_Describe = dataProduction.Mixer_Describe,
        //        Reactor_StationID = dataProduction.Reactor_StationID,
        //        Reactor_StartDate = dataProduction.Reactor_StartDate,
        //        Reactor_StartTime = dataProduction.Reactor_StartTime,
        //        Reactor_EndDate = dataProduction.Reactor_EndDate,
        //        Reactor_EndTime = dataProduction.Reactor_EndTime,
        //        Reactor_Duration = dataProduction.Reactor_Duration,
        //        Reactor_ShiftNo = dataProduction.Reactor_ShiftNo,
        //        Reactor_Operators = dataProduction.Reactor_Operators,
        //        Reactor_Wastes = dataProduction.Reactor_Wastes,
        //        Reactor_Stopes = dataProduction.Reactor_Stopes,
        //        Reactor_StopesDesc = dataProduction.Reactor_StopesDesc,
        //        Reactor_MixerSpeed = dataProduction.Reactor_MixerSpeed,
        //        Reactor_Temperature = dataProduction.Reactor_Temperature,
        //        Reactor_MaterialTemperature = dataProduction.Reactor_MaterialTemperature,
        //        Reactor_Describe = dataProduction.Reactor_Describe,
        //        Premix_StationID = dataProduction.Premix_StationID,
        //        Premix_StartDate = dataProduction.Premix_StartDate,
        //        Premix_StartTime = dataProduction.Premix_StartTime,
        //        Premix_EndDate = dataProduction.Premix_EndDate,
        //        Premix_EndTime = dataProduction.Premix_EndTime,
        //        Premix_Duration = dataProduction.Premix_Duration,
        //        Premix_ShiftNo = dataProduction.Premix_ShiftNo,
        //        Premix_Operators = dataProduction.Premix_Operators,
        //        Premix_Wastes = dataProduction.Premix_Wastes,
        //        Premix_Stopes = dataProduction.Premix_Stopes,
        //        Premix_StopesDesc = dataProduction.Premix_StopesDesc,
        //        Premix_StationSpeed = dataProduction.Premix_StationSpeed,
        //        Premix_Describe = dataProduction.Premix_Describe,
        //        Grinding_StationID = dataProduction.Grinding_StationID,
        //        Grinding_StartDate = dataProduction.Grinding_StartDate,
        //        Grinding_StartTime = dataProduction.Grinding_StartTime,
        //        Grinding_EndDate = dataProduction.Grinding_EndDate,
        //        Grinding_EndTime = dataProduction.Grinding_EndTime,
        //        Grinding_Duration = dataProduction.Grinding_Duration,
        //        Grinding_ShiftNo = dataProduction.Grinding_ShiftNo,
        //        Grinding_Operators = dataProduction.Grinding_Operators,
        //        Grinding_Stopes = dataProduction.Grinding_Stopes,
        //        Grinding_StopesDesc = dataProduction.Grinding_StopesDesc,
        //        Grinding_StationSpeed = dataProduction.Grinding_StationSpeed,
        //        Grinding_Describe = dataProduction.Grinding_Describe,
        //        InsUserID = dataProduction.InsUserID,
        //        InsDate = dataProduction.InsDate,
        //        InsTime = dataProduction.InsTime,
        //        EditUserID = dataProduction.EditUserID,
        //        EditDate = dataProduction.EditDate,
        //        EditTime = dataProduction.EditTime,
        //        RowVer = dataProduction.RowVer,

        //    };
        //}


        //public static DataDosingDetailDTO ConvertToDto(this DataDosingDetail dataDosingDetail)
        //{
        //    if (dataDosingDetail == null)
        //        return null;

        //    return new DataDosingDetailDTO
        //    {
        //        DataDosingDetailID = dataDosingDetail.DataDosingDetailID,
        //        DataProductionID = dataDosingDetail.DataProductionID,
        //        DataProduction = dataDosingDetail.DataProduction.ConvertToDto(),
        //        RawMaterialID = dataDosingDetail.RawMaterialID,
        //        RawMaterial = dataDosingDetail.RawMaterial.ConvertToDto(),
        //        RawMaterialType = dataDosingDetail.RawMaterialType,
        //        Priority = dataDosingDetail.Priority,
        //        PlannedWeight = dataDosingDetail.PlannedWeight,
        //        ChargedWeight = dataDosingDetail.ChargedWeight,
        //        LotNumber = dataDosingDetail.LotNumber,
        //        Wastes = dataDosingDetail.Wastes,
        //        Operator = dataDosingDetail.Operator,
        //        IsFinalRM = dataDosingDetail.IsFinalRM,
        //        Describe = dataDosingDetail.Describe,


        //    };
        //}

        public static DataGrindingDetailDTO ConvertToDto(this DataGrindingDetail dataGrindingDetail)
        {
            if (dataGrindingDetail == null)
                return null;

            return new DataGrindingDetailDTO
            {
                DataGrindingDetailID = dataGrindingDetail.DataGrindingDetailID,
                DataProductionID = dataGrindingDetail.DataProductionID,
                Date = dataGrindingDetail.Date,
                Time = dataGrindingDetail.Time,
                DateTimeSaveDistance = dataGrindingDetail.DateTimeSaveDistance,
                PressurePump = dataGrindingDetail.PressurePump,
                MaterialFlowSpeed = dataGrindingDetail.MaterialFlowSpeed,
                Duration = dataGrindingDetail.Duration,
                GrindingSpeed = dataGrindingDetail.GrindingSpeed,
                EnginePower = dataGrindingDetail.EnginePower,
                MaterialTemp = dataGrindingDetail.MaterialTemp,
                MixerSpeed = dataGrindingDetail.MixerSpeed,
                Operator = dataGrindingDetail.Operator,
                Energy = dataGrindingDetail.Energy,
                RotorSpeed = dataGrindingDetail.RotorSpeed,
                Describe = dataGrindingDetail.Describe,

            };
        }

        public static PatilsDTO ConvertToDto(this Patils patils)
        {
            if (patils == null)
                return null;

            return new PatilsDTO
            {
                PatilID = patils.PatilID,
                PatilNo = patils.PatilNo,
                Capacity = patils.Capacity,
                MinCapacity = patils.MinCapacity,
                EmptyWeight = patils.EmptyWeight,
                InUse = patils.InUse,
                IsActive = patils.IsActive,


            };
        }

        public static WeightingProductsDTO ConvertToDto(this WeightingProducts weightingProducts)
        {
            if (weightingProducts == null)
                return null;

            return new WeightingProductsDTO
            {
                WeightingProductID = weightingProducts.WeightingProductID,
                ProductionPlanPatilID = weightingProducts.ProductionPlanPatilID,
                InvProductID = weightingProducts.InvProductID,
                StartDate = weightingProducts.StartDate,
                StartTime = weightingProducts.StartTime,
                EndDate = weightingProducts.EndDate,
                EndTime = weightingProducts.EndTime,
                EntryWeight = weightingProducts.EntryWeight,
                PackagedWeight = weightingProducts.PackagedWeight,
                Waste = weightingProducts.Waste,
                InsUserID = weightingProducts.InsUserID,
                InsDate = weightingProducts.InsDate,
                InsTime = weightingProducts.InsTime,
                EditUserID = weightingProducts.EditUserID,
                EditDate = weightingProducts.EditDate,
                EditTime = weightingProducts.EditTime,
                RowVer = weightingProducts.RowVer,


            };
        }

        public static WeightingProductDetailDTO ConvertToDto(this WeightingProductDetail weightingProductDetail)
        {
            if (weightingProductDetail == null)
                return null;

            return new WeightingProductDetailDTO
            {
                WeightingProductDetailID = weightingProductDetail.WeightingProductDetailID,
                WeightingProductID = weightingProductDetail.WeightingProductID,
                PackagingPlanID = weightingProductDetail.PackagingPlanID,
                QTY = weightingProductDetail.QTY,
                EmptyWeight = weightingProductDetail.EmptyWeight,
                NetWeight = weightingProductDetail.NetWeight,


            };
        }

        public static InvProductsDTO ConvertToDto(this InvProducts invProducts)
        {
            if (invProducts == null)
                return null;

            return new InvProductsDTO
            {
                InvProductID = invProducts.InvProductID,
                InvProductCode = invProducts.InvProductCode,
                DataProductionID = invProducts.DataProductionID,
                ProductID = invProducts.ProductID,
                WeightingProductDetailID = invProducts.WeightingProductDetailID,
                Weight = invProducts.Weight,
                NetWeight = invProducts.NetWeight,
                EntryDate = invProducts.EntryDate,
                ProducedDate = invProducts.ProducedDate,
                ExpireDate = invProducts.ExpireDate,
                ShelfLife = invProducts.ShelfLife,
                EnProducedDate = invProducts.EnProducedDate,
                EnExpireDate = invProducts.EnExpireDate,
                EnShelfLife = invProducts.EnShelfLife,
                PackagingTypeID = invProducts.PackagingPlanID,
                SupplierID = invProducts.SupplierID,
                Remark = invProducts.Remark,
                Status = invProducts.Status,
                QcStatus = invProducts.QcStatus,
                PaletID = invProducts.PaletID,
                ParentID = invProducts.ParentID,
                InsUserID = invProducts.InsUserID,
                InsDate = invProducts.InsDate,
                InsTime = invProducts.InsTime,
                EditUserID = invProducts.EditUserID,
                EditDate = invProducts.EditDate,
                EditTime = invProducts.EditTime,
            };
        }

        public static PaletsDTO ConvertToDto(this Palets palets)
        {
            if (palets == null)
                return null;

            return new PaletsDTO
            {
                PaletID = palets.PaletID,
                PaletNo = palets.PaletNo,
                CustomerID = palets.CustomerID,
                OrderDetailID = palets.OrderDetailID,
                ProductID = palets.ProductID,
                NetWeight = palets.NetWeight,
                Weight = palets.Weight,
                QTY = palets.QTY,
                PaletDate = palets.PaletDate,
                PaletTime = palets.PaletTime,
                UserID = palets.UserID,
                StationID = palets.StationID,
                QualityClass = palets.QualityClass,
                Status = palets.Status,
                ProductsQuality = palets.ProductsQuality,
                Remarks = palets.Remarks,
                QcStatus = palets.QcStatus,


            };
        }



        #endregion

    }

    public static partial class ModelExtensions
    {


        #region ConvertToListDto


        public static List<SysUserDto> ConvertToListDto(this SysUserAccount token)
        {
            List<SysUserDto> list2 = new List<SysUserDto>();
            list2.Add(token.ConvertToDto());
            return list2;

        }

        public static List<UsersDTO> ConvertToListDto(this Users users)
        {
            List<UsersDTO> list2 = new List<UsersDTO>();
            list2.Add(users.ConvertToDto());
            return list2;
        }
        public static List<UsersDTO> ConvertToListDto(this List<Core.Models.Users> users)
        {
            if (users == null) return null;

            List<UsersDTO> list2 = new List<UsersDTO>();
            users.ForEach
                (s => list2.Add(s.ConvertToDto())
                );
            return list2;
        }


        public static List<StationsDTO> ConvertToListDto(this List<Core.Models.Stations> stations)
        {
            if (stations == null) return null;

            List<StationsDTO> list2 = new List<StationsDTO>();
            stations.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<UnitsDTO> ConvertToListDto(this List<Core.Models.Units> unit)
        {
            List<UnitsDTO> list2 = new List<UnitsDTO>();
            unit.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        //public static List<RawMaterialGroupsDTO> ConvertToListDto(this List<Core.Models.RawMaterialGroups> rawMaterialGroups)
        //{
        //    List<RawMaterialGroupsDTO> list2 = new List<RawMaterialGroupsDTO>();
        //    rawMaterialGroups.ForEach(s => list2.Add(s.ConvertToDto()));
        //    return list2;
        //}

        //public static List<RawMaterialsDTO> ConvertToListDto(this List<Core.Models.RawMaterials> rawMaterial)
        //{
        //    List<RawMaterialsDTO> list2 = new List<RawMaterialsDTO>();
        //    rawMaterial.ForEach(s => list2.Add(s.ConvertToDto()));
        //    return list2;
        //}

        public static List<ProvincesDTO> ConvertToListDto(this List<Core.Models.Provinces> province)
        {
            List<ProvincesDTO> list2 = new List<ProvincesDTO>();
            province.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }


        //public static List<CustomerDraftPaletsBobinsDTO> ConvertToListDto(this List<Core.Models.CustomerDraftPaletsBobins> customerDraftPaletsBobins)
        //{
        //    List<CustomerDraftPaletsBobinsDTO> list2 = new List<CustomerDraftPaletsBobinsDTO>();
        //    customerDraftPaletsBobins.ForEach(s => list2.Add(s.ConvertToDto()));
        //    return list2;
        //}


        public static List<DomainDTO> ConvertToListDto(this Domain domains)
        {
            List<DomainDTO> list2 = new List<DomainDTO>();
            list2.Add(domains.ConvertToDto());
            return list2;
        }
        public static List<DomainDTO> ConvertToListDto(this List<Core.Models.Domain> domains)
        {
            List<DomainDTO> list2 = new List<DomainDTO>();
            domains.ForEach
                (s => list2.Add(s.ConvertToDto())
                );
            return list2;
        }

        public static List<CustomerGradesDTO> ConvertToListDto(this List<Core.Models.CustomerGrades> customerGrades)
        {
            List<CustomerGradesDTO> list2 = new List<CustomerGradesDTO>();
            customerGrades.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<SaleAgentsDTO> ConvertToListDto(this List<Core.Models.SaleAgents> saleAgents)
        {
            List<SaleAgentsDTO> list2 = new List<SaleAgentsDTO>();
            saleAgents.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<CustomersDTO> ConvertToListDto(this List<Core.Models.Customers> customers)
        {
            List<CustomersDTO> list2 = new List<CustomersDTO>();
            customers.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<RawMaterialsDTO> ConvertToListDto(this List<Core.Models.RawMaterials> rawMaterials)
        {
            List<RawMaterialsDTO> list2 = new List<RawMaterialsDTO>();
            rawMaterials.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        //public static List<EmployeeDto> ConvertToDto(this List<EmployeeBIG> emp)
        //{
        //    return new EmployeeDto
        //    {
        //        EMPLOYEEID = emp.EMP_ID,
        //        NAME = emp.NAME,
        //        FAMILY = emp.FAMILY,
        //        //EMP_NO = emp.EMP_NO,
        //        //LE_NO = emp.LE_NO,
        //        //PERS_NO = emp.PERS_NO,
        //        PASSWORD = emp.PASSWORD,
        //    };
        //}

        //public static EmployeeDto ConvertToDto(this EmployeeBIG garden)
        //{
        //        //.Select(p => p.ConvertToDto()).ToListIfNotEmpty()

        //}

        public static List<PrintingTechniquesDTO> ConvertToListDto(this List<Core.Models.PrintingTechniques> printingTechniques)
        {
            List<PrintingTechniquesDTO> list2 = new List<PrintingTechniquesDTO>();
            printingTechniques.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<ProductGroupTypesDTO> ConvertToListDto(this List<Core.Models.ProductGroupTypes> productGroupTypes)
        {
            List<ProductGroupTypesDTO> list2 = new List<ProductGroupTypesDTO>();
            productGroupTypes.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<ProductGroupsDTO> ConvertToListDto(this List<Core.Models.ProductGroups> productGroups)
        {
            List<ProductGroupsDTO> list2 = new List<ProductGroupsDTO>();
            productGroups.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<ProductTypesDTO> ConvertToListDto(this List<Core.Models.ProductTypes> productTypes)
        {
            List<ProductTypesDTO> list2 = new List<ProductTypesDTO>();
            productTypes.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<ProductSeriesDTO> ConvertToListDto(this List<Core.Models.ProductSeries> productSeries)
        {
            List<ProductSeriesDTO> list2 = new List<ProductSeriesDTO>();
            productSeries.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<ProductsDTO> ConvertToListDto(this List<Core.Models.Products> products)
        {
            List<ProductsDTO> list2 = new List<ProductsDTO>();
            products.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }


        public static List<ProductSerieTechniqueAssignsDTO> ConvertToListDto(this List<Core.Models.ProductSerieTechniqueAssigns> productSerieTechniqueAssigns)
        {
            List<ProductSerieTechniqueAssignsDTO> list2 = new List<ProductSerieTechniqueAssignsDTO>();
            productSerieTechniqueAssigns.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<RawMaterialGroupTypesDTO> ConvertToListDto(this List<Core.Models.RawMaterialGroupTypes> rawMaterialGroupTypes)
        {
            List<RawMaterialGroupTypesDTO> list2 = new List<RawMaterialGroupTypesDTO>();
            rawMaterialGroupTypes.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }


        public static List<RawMaterialGroupsDTO> ConvertToListDto(this List<Core.Models.RawMaterialGroups> rawMaterialGroups)
        {
            List<RawMaterialGroupsDTO> list2 = new List<RawMaterialGroupsDTO>();
            rawMaterialGroups.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<SuppliersDTO> ConvertToListDto(this List<Core.Models.Suppliers> suppliers)
        {
            List<SuppliersDTO> list2 = new List<SuppliersDTO>();
            suppliers.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<TestPlanGroupsDTO> ConvertToListDto(this List<Core.Models.TestPlanGroups> testPlanGroups)
        {
            List<TestPlanGroupsDTO> list2 = new List<TestPlanGroupsDTO>();
            testPlanGroups.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<TestPlanIndexesDTO> ConvertToListDto(this List<Core.Models.TestPlanIndexes> testPlanIndexes)
        {
            List<TestPlanIndexesDTO> list2 = new List<TestPlanIndexesDTO>();
            testPlanIndexes.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<CountriesDTO> ConvertToListDto(this List<Core.Models.Countries> countries)
        {
            List<CountriesDTO> list2 = new List<CountriesDTO>();
            countries.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<InstructionsDTO> ConvertToListDto(this List<Core.Models.Instructions> instructions)
        {
            List<InstructionsDTO> list2 = new List<InstructionsDTO>();
            instructions.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<TestPlansDTO> ConvertToListDto(this List<Core.Models.TestPlans> testPlans)
        {
            List<TestPlansDTO> list2 = new List<TestPlansDTO>();
            testPlans.ForEach(
                s =>
                list2.Add(s.ConvertToDto()
                ));
            return list2;
        }

        public static List<TestPlanDetailsDTO> ConvertToListDto(this List<Core.Models.TestPlanDetails> testPlanDetails)
        {
            List<TestPlanDetailsDTO> list2 = new List<TestPlanDetailsDTO>();
            testPlanDetails?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<SettingsDTO> ConvertToListDto(this List<Core.Models.Settings> settings)
        {
            List<SettingsDTO> list2 = new List<SettingsDTO>();
            settings.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<SettingUpdatesDTO> ConvertToListDto(this List<Core.Models.SettingUpdates> settingUpdates)
        {
            List<SettingUpdatesDTO> list2 = new List<SettingUpdatesDTO>();
            settingUpdates.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }


        public static List<SettingUpdateViewModelDTO> ConvertToListDto(this List<Core.Models.SettingUpdateViewModel> settingUpdateViewModel)
        {
            List<SettingUpdateViewModelDTO> list2 = new List<SettingUpdateViewModelDTO>();
            settingUpdateViewModel.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<SettingUserViewModelDTO> ConvertToListDto(this List<Core.Models.SettingUserViewModel> settingUpdateViewModel)
        {
            if (settingUpdateViewModel == null) return null;

            List<SettingUserViewModelDTO> list2 = new List<SettingUserViewModelDTO>();
            settingUpdateViewModel.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }


        public static List<SettingStationViewModelDTO> ConvertToListDto(this List<Core.Models.SettingStationViewModel> settingUpdateViewModel)
        {
            if (settingUpdateViewModel == null) return null;

            List<SettingStationViewModelDTO> list2 = new List<SettingStationViewModelDTO>();
            settingUpdateViewModel.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<SettingGeneralsDTO> ConvertToListDto(this List<Core.Models.SettingGenerals> settingGenerals)
        {
            List<SettingGeneralsDTO> list2 = new List<SettingGeneralsDTO>();
            settingGenerals.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<MenuAccessStatesDTO> ConvertToListDto(this List<Core.Models.MenuAccessStates> menuAccessStates)
        {
            List<MenuAccessStatesDTO> list2 = new List<MenuAccessStatesDTO>();
            menuAccessStates.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<DenyAccessesDTO> ConvertToListDto(this List<Core.Models.DenyAccesses> denyAccesses)
        {
            List<DenyAccessesDTO> list2 = new List<DenyAccessesDTO>();
            denyAccesses.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<LoginLogsDTO> ConvertToListDto(this List<Core.Models.LoginLogs> loginLogs)
        {
            List<LoginLogsDTO> list2 = new List<LoginLogsDTO>();
            loginLogs.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<LogsDTO> ConvertToListDto(this List<Core.Models.Logs> logs)
        {
            List<LogsDTO> list2 = new List<LogsDTO>();
            logs.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<UserGroupsDTO> ConvertToListDto(this List<Core.Models.UserGroups> userGroups)
        {
            List<UserGroupsDTO> list2 = new List<UserGroupsDTO>();
            userGroups.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<UserGroupStationsDTO> ConvertToListDto(this List<Core.Models.UserGroupStations> userGroupStations)
        {
            List<UserGroupStationsDTO> list2 = new List<UserGroupStationsDTO>();
            userGroupStations.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<UserGroupAssignsDTO> ConvertToListDto(this List<Core.Models.UserGroupAssigns> userGroupAssigns)
        {
            List<UserGroupAssignsDTO> list2 = new List<UserGroupAssignsDTO>();
            userGroupAssigns.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<StationTypesDTO> ConvertToListDto(this List<Core.Models.StationTypes> stationTypes)
        {
            List<StationTypesDTO> list2 = new List<StationTypesDTO>();
            stationTypes.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<PackagingPlansDTO> ConvertToListDto(this List<Core.Models.PackagingPlans> packagingPlans)
        {
            List<PackagingPlansDTO> list2 = new List<PackagingPlansDTO>();
            packagingPlans.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        //public static List<PackagingTypesDTO> ConvertToListDto(this List<Core.Models.PackagingTypes> packagingtypes)
        //{
        //    List<PackagingTypesDTO> list2 = new List<PackagingTypesDTO>();
        //    packagingtypes.ForEach(s => list2.Add(s.ConvertToDto()));
        //    return list2;
        //}

        public static List<OrdersDTO> ConvertToListDto(this List<Core.Models.Orders> orders)
        {
            List<OrdersDTO> list2 = new List<OrdersDTO>();
            orders.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<OrderDetailsDTO> ConvertToListDto(this List<Core.Models.OrderDetails> orderDetails)
        {
            List<OrderDetailsDTO> list2 = new List<OrderDetailsDTO>();
            orderDetails.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<DensityOfProductsDTO> ConvertToListDto(this List<Core.Models.DensityOfProducts> densityOfProducts)
        {
            List<DensityOfProductsDTO> list2 = new List<DensityOfProductsDTO>();
            densityOfProducts.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<RawMaterialLotNumbersDTO> ConvertToListDto(this List<Core.Models.RawMaterialLotNumbers> rawMaterialSampleLotNumbers)
        {
            List<RawMaterialLotNumbersDTO> list2 = new List<RawMaterialLotNumbersDTO>();
            rawMaterialSampleLotNumbers?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<TestPlanAssignDTO> ConvertToListDto(this List<Core.Models.TestPlanAssign> testPlanAssign)
        {
            List<TestPlanAssignDTO> list2 = new List<TestPlanAssignDTO>();
            testPlanAssign?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }
        public static List<TestPlanAssignViewModelDTO> ConvertToListDto(this List<Core.Models.TestPlanAssignViewModel> testPlanAssign)
        {
            List<TestPlanAssignViewModelDTO> list2 = new List<TestPlanAssignViewModelDTO>();
            testPlanAssign?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<TestPlanAssignDetailDTO> ConvertToListDto(this List<Core.Models.TestPlanAssignDetail> testPlanAssignDetail)
        {
            List<TestPlanAssignDetailDTO> list2 = new List<TestPlanAssignDetailDTO>();
            testPlanAssignDetail?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        //public static List<InvRawMaterialsDTO> ConvertToListDto(this List<Core.Models.InvRawMaterials> invRawMaterials)
        //{
        //    List<InvRawMaterialsDTO> list2 = new List<InvRawMaterialsDTO>();
        //    invRawMaterials?.ForEach(s => list2.Add(s.ConvertToDto()));
        //    return list2;
        //}

        //public static List<InvRawMaterialLotsDTO> ConvertToListDto(this List<Core.Models.InvRawMaterialLots> invRawMaterialLots)
        //{
        //    List<InvRawMaterialLotsDTO> list2 = new List<InvRawMaterialLotsDTO>();
        //    invRawMaterialLots?.ForEach(s => list2.Add(s.ConvertToDto()));
        //    return list2;
        //}

        public static List<TestPlanCodeCharDTO> ConvertToListDto(this List<Core.Models.TestPlanCodeChar> testPlanCodeChar)
        {
            List<TestPlanCodeCharDTO> list2 = new List<TestPlanCodeCharDTO>();
            testPlanCodeChar?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<OrderDetailPackagingsDTO> ConvertToListDto(this List<Core.Models.OrderDetailPackagings> orderDetailPackagings)
        {
            List<OrderDetailPackagingsDTO> list2 = new List<OrderDetailPackagingsDTO>();
            orderDetailPackagings?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<AutoCompleteFieldDTO> ConvertToListDto(this List<Core.Models.AutoCompleteField> autoCompleteField)
        {
            List<AutoCompleteFieldDTO> list2 = new List<AutoCompleteFieldDTO>();
            autoCompleteField?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<TestPlanBasicIndexDTO> ConvertToListDto(this List<Core.Models.TestPlanBasicIndex> testPlanBasicIndex)
        {
            List<TestPlanBasicIndexDTO> list2 = new List<TestPlanBasicIndexDTO>();
            testPlanBasicIndex?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<RMWhiteListsDTO> ConvertToListDto(this List<Core.Models.RMWhiteLists> rMWhiteLists)
        {
            List<RMWhiteListsDTO> list2 = new List<RMWhiteListsDTO>();
            rMWhiteLists?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<RawMaterialWhiteListAssignDTO> ConvertToListDto(this List<Core.Models.RawMaterialWhiteListAssign> rawMaterialWhiteListAssign)
        {
            List<RawMaterialWhiteListAssignDTO> list2 = new List<RawMaterialWhiteListAssignDTO>();
            rawMaterialWhiteListAssign?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<RawMaterialConfirmationDTO> ConvertToListDto(this List<Core.Models.RawMaterialConfirmation> rawMaterialConfirmation)
        {
            List<RawMaterialConfirmationDTO> list2 = new List<RawMaterialConfirmationDTO>();
            rawMaterialConfirmation?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }


        public static List<BOMDTO> ConvertToListDto(this List<Core.Models.BOM> bOM)
        {
            List<BOMDTO> list2 = new List<BOMDTO>();
            bOM?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<BOMDetailDTO> ConvertToListDto(this List<Core.Models.BOMDetail> bOMDetail)
        {
            List<BOMDetailDTO> list2 = new List<BOMDetailDTO>();
            bOMDetail?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<BOMComplementaryDTO> ConvertToListDto(this List<Core.Models.BOMComplementary> bOMComplementary)
        {
            List<BOMComplementaryDTO> list2 = new List<BOMComplementaryDTO>();
            bOMComplementary?.ForEach(s =>
            {
                list2.Add(s.ConvertToDto());
            }
            );
            return list2;
        }

        public static List<CustomerDossierDTO> ConvertToListDto(this List<Core.Models.CustomerDossier> customerDossier)
        {
            List<CustomerDossierDTO> list2 = new List<CustomerDossierDTO>();
            customerDossier?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }
        public static List<CustomerDossierBOMsDTO> ConvertToListDto(this List<Core.Models.CustomerDossierBOMs> customerDossierBOMs)
        {
            List<CustomerDossierBOMsDTO> list2 = new List<CustomerDossierBOMsDTO>();
            customerDossierBOMs?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<ProductionPlanPatilsCapacityDTO> ConvertToListDto(this List<Core.Models.ProductionPlanPatilsCapacity> productionPlanPatilsCapacity)
        {
            List<ProductionPlanPatilsCapacityDTO> list2 = new List<ProductionPlanPatilsCapacityDTO>();
            productionPlanPatilsCapacity?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<ProductionPlanPackagingDTO> ConvertToListDto(this List<Core.Models.ProductionPlanPackaging> productionPlanPackaging)
        {
            List<ProductionPlanPackagingDTO> list2 = new List<ProductionPlanPackagingDTO>();
            productionPlanPackaging?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<ProductionPlansDTO> ConvertToListDto(this List<Core.Models.ProductionPlans> productionPlans)
        {
            List<ProductionPlansDTO> list2 = new List<ProductionPlansDTO>();
            productionPlans?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<ProductionPlanBOMDetailDTO> ConvertToListDto(this List<Core.Models.ProductionPlanBOMDetail> productionPlanBOMDetail)
        {
            List<ProductionPlanBOMDetailDTO> list2 = new List<ProductionPlanBOMDetailDTO>();
            productionPlanBOMDetail?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<ProductionPlanBOMDetailRevisedDTO> ConvertToListDto(this List<Core.Models.ProductionPlanBOMDetailRevised> productionPlanBOMDetailRevised)
        {
            List<ProductionPlanBOMDetailRevisedDTO> list2 = new List<ProductionPlanBOMDetailRevisedDTO>();
            productionPlanBOMDetailRevised?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<ProductionPlanPatilsDTO> ConvertToListDto(this List<Core.Models.ProductionPlanPatils> productionPlanPatils)
        {
            List<ProductionPlanPatilsDTO> list2 = new List<ProductionPlanPatilsDTO>();
            productionPlanPatils?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<DeliveryRawMaterialToProductionDTO> ConvertToListDto(this List<Core.Models.DeliveryRawMaterialToProduction> deliveryRawMaterialToProduction)
        {
            List<DeliveryRawMaterialToProductionDTO> list2 = new List<DeliveryRawMaterialToProductionDTO>();
            deliveryRawMaterialToProduction?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<DeliveryRawMaterialToProductionDetailDTO> ConvertToListDto(this List<Core.Models.DeliveryRawMaterialToProductionDetail> deliveryRawMaterialToProductionDetail)
        {

            if (deliveryRawMaterialToProductionDetail == null)
                return null;

            List<DeliveryRawMaterialToProductionDetailDTO> list2 = new List<DeliveryRawMaterialToProductionDetailDTO>();
            deliveryRawMaterialToProductionDetail?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<DeliveryRawMaterialToProductionPatilsDTO> ConvertToListDto(this List<Core.Models.DeliveryRawMaterialToProductionPatils> deliveryRawMaterialToProductionPatils)
        {

            if (deliveryRawMaterialToProductionPatils == null)
                return null;

            List<DeliveryRawMaterialToProductionPatilsDTO> list2 = new List<DeliveryRawMaterialToProductionPatilsDTO>();
            deliveryRawMaterialToProductionPatils?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<RawMaterialsDeliveredToProductionDTO> ConvertToListDto(this List<Core.Models.RawMaterialsDeliveredToProduction> rawMaterialsDeliveredToProduction)
        {
            List<RawMaterialsDeliveredToProductionDTO> list2 = new List<RawMaterialsDeliveredToProductionDTO>();
            rawMaterialsDeliveredToProduction?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<RawMaterialsDeliveredToProductionDetailDTO> ConvertToListDto(this List<Core.Models.RawMaterialsDeliveredToProductionDetail> rawMaterialsDeliveredToProductionDetail)
        {
            List<RawMaterialsDeliveredToProductionDetailDTO> list2 = new List<RawMaterialsDeliveredToProductionDetailDTO>();
            rawMaterialsDeliveredToProductionDetail?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        //public static List<DataProductionDTO> ConvertToListDto(this List<Core.Models.DataProduction> dataProduction)
        //{
        //    List<DataProductionDTO> list2 = new List<DataProductionDTO>();
        //    dataProduction?.ForEach(s => list2.Add(s.ConvertToDto()));
        //    return list2;
        //}

        //public static List<DataDosingDetailDTO> ConvertToListDto(this List<Core.Models.DataDosingDetail> dataDosingDetail)
        //{
        //    List<DataDosingDetailDTO> list2 = new List<DataDosingDetailDTO>();
        //    dataDosingDetail?.ForEach(s => list2.Add(s.ConvertToDto()));
        //    return list2;
        //}

        public static List<DataGrindingDetailDTO> ConvertToListDto(this List<Core.Models.DataGrindingDetail> dataGrindingDetail)
        {
            List<DataGrindingDetailDTO> list2 = new List<DataGrindingDetailDTO>();
            dataGrindingDetail?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<PatilsDTO> ConvertToListDto(this List<Core.Models.Patils> patils)
        {
            List<PatilsDTO> list2 = new List<PatilsDTO>();
            patils?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<WeightingProductsDTO> ConvertToListDto(this List<Core.Models.WeightingProducts> weightingProducts)
        {
            List<WeightingProductsDTO> list2 = new List<WeightingProductsDTO>();
            weightingProducts?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<WeightingProductDetailDTO> ConvertToListDto(this List<Core.Models.WeightingProductDetail> weightingProductDetail)
        {
            List<WeightingProductDetailDTO> list2 = new List<WeightingProductDetailDTO>();
            weightingProductDetail?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<InvProductsDTO> ConvertToListDto(this List<Core.Models.InvProducts> invProducts)
        {
            List<InvProductsDTO> list2 = new List<InvProductsDTO>();
            invProducts?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<PaletsDTO> ConvertToListDto(this List<Core.Models.Palets> palets)
        {
            List<PaletsDTO> list2 = new List<PaletsDTO>();
            palets?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }


        #endregion


        #region other 

        #endregion
    }
}
//Weight
//NetWeight
//Describe
//PalletQty