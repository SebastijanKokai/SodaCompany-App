using SodaCompany.Core.Entities;
using SodaCompany.Infrastructure.Data;
using System;

namespace SodaCompany.Infrastructure.Extensions
{
    public static class MockDataExtension
    {
        public static SodaCompanyContext PrefillData(this SodaCompanyContext context)
        {
            context.PrefillEmployeeType();
            context.PrefillOrganizationUnit();
            context.PrefillEmployee();
            context.PrefillWarehouse();
            context.PrefillPart();
            context.PrefillProductModel();
            context.PrefillWorkProcedure();
            context.PrefillProduct();
            context.PrefillProductionPlan();
            context.PrefillWarehousePart();
            context.PrefillWorkProcedurePart();
            context.PrefillProductionPlanWorkProcedure();
            context.PrefillProductionOrder();
            context.PrefillProductionOrderProduct();
            context.SaveChanges();
            return context;
        }
        public static SodaCompanyContext PrefillEmployeeType(this SodaCompanyContext context)
        {
            context.EmployeeType.Add(new EmployeeType()
            {
                Id = Guid.Parse("9937d382-097e-43d4-9d28-051844261e06"),
                Type = "Manager"
            });
            context.EmployeeType.Add(new EmployeeType()
            {
                Id = Guid.Parse("ff6078f5-6ef9-4828-b889-4f840e94c29e"),
                Type = "Worker"
            });
            return context;
        }
        public static SodaCompanyContext PrefillOrganizationUnit(this SodaCompanyContext context)
        {
            context.OrganizationalUnit.Add(new OrganizationalUnit()
            {
                Id = Guid.Parse("9c4f4fd1-78f5-40c6-abc1-6219425212c1"),
                Name = "Coca-cola"
            });
            return context;
        }
        public static SodaCompanyContext PrefillEmployee(this SodaCompanyContext context)
        {
            context.Employee.Add(new Employee()
            {
                EmployeeTypeId = Guid.Parse("9937d382-097e-43d4-9d28-051844261e06"),
                OrganizationalUnitId = Guid.Parse("9c4f4fd1-78f5-40c6-abc1-6219425212c1"),
                Id = Guid.Parse("9d6f01e7-a53e-4c4a-a9ea-653732fe4af3"),
                Name = "Marko",
                Surname = "Puzovic",
                PhoneNumber = "+38163388371",
                Salt = "aeb6827e9bcd6d83ffe706a059b7bcc009cca16375e6c93d5a9706ea1e56e206",
                //password : 123
                Password = "cc7198577c2f6216d04bc5ac8aaaa66308599f245118176c10b406f13e01bb66",
                Username = "123"
            });
            context.Employee.Add(new Employee()
            {
                EmployeeTypeId = Guid.Parse("ff6078f5-6ef9-4828-b889-4f840e94c29e"),
                OrganizationalUnitId = Guid.Parse("9c4f4fd1-78f5-40c6-abc1-6219425212c1"),
                Id = Guid.Parse("d29a42c5-8f94-4b2d-a96c-632ed7ca9f22"),
                Name = "Sebastijan",
                Surname = "Kokai",
                PhoneNumber = "+381647723678",
                Salt = "081b85d21a56f4b6a2109dca641299c84ad42a812e1a1892e8fd91be2058fd15",
                //password : 321
                Password = "674d8a9e585ae8a1266e8040d995d93e9e82d7a7fff8ee6159ed15da64499f5b",
                Username = "321"
            });
            return context;
        }
        public static SodaCompanyContext PrefillWarehouse(this SodaCompanyContext context)
        {
            context.Warehouse.Add(new Warehouse()
            {
                Id = Guid.Parse("fb41bbab-5ba2-428e-a682-7462b509dff3"),
                Location = "Subotica Serbia",
                Name = "Coca-cola Subotica"
            });
            return context;
        }
        public static SodaCompanyContext PrefillPart(this SodaCompanyContext context)
        {
            context.Part.Add(new Part()
            {
                Id = Guid.Parse("b5785e30-8e41-4a95-9beb-b00ed4581171"),
                Name = "Coca-cola aluminijumski cep",
                Price = 10
            });
            context.Part.Add(new Part()
            {
                Id = Guid.Parse("ef966bf2-7394-4713-b4d2-06a5a3580ada"),
                Name = "Coca-cola flasa staklo 0.33",
                Price = 40
            });

            context.Part.Add(new Part()
            {
                Id = Guid.Parse("ae9aac89-ec04-4b6f-840b-bfdf2a5ce03a"),
                Name = "Coca-cola flasa staklo etiketa",
                Price = 10
            });

            context.Part.Add(new Part()
            {
                Id = Guid.Parse("3b47892d-f2fd-4e5e-8a65-44c5d046b8a3"),
                Name = "Coca-cola sok",
                Price = 50
            });

            return context;
        }
        public static SodaCompanyContext PrefillProductModel(this SodaCompanyContext context)
        {
            context.ProductModel.Add(new ProductModel()
            {
                Id = Guid.Parse("ba07bbab-8a70-430f-b5a4-7581cc6db76b"),
                Height = 120,
                Type = "staklo",
                Unit = "l",
                Value = .33m,
                Width = 30
            });
            context.ProductModel.Add(new ProductModel()
            {
                Id = Guid.Parse("1a59820a-8ed2-4247-8e62-6f8561fec2c2"),
                Height = 240,
                Type = "plastika",
                Unit = "l",
                Value = .5m,
                Width = 30
            });
            context.ProductModel.Add(new ProductModel()
            {
                Id = Guid.Parse("2047f2d0-8fdd-46c2-958b-5e5aeea3c604"),
                Height = 120,
                Type = "staklo",
                Unit = "l",
                Value = .25m,
                Width = 30
            });
            return context;
        }
        public static SodaCompanyContext PrefillWorkProcedure(this SodaCompanyContext context)
        {
            context.WorkProcedure.Add(new WorkProcedure()
            {
                Id = Guid.Parse("9e18c8d2-5106-4b81-9187-5540ac0b66cc"),
                Name = "Standardna procedura coca-cola 0.33 staklo",
                Description = "Punjenje, zatvaranje flase, dodavanje nalepnice, pakovanje",
                ProductionPrice = 50,
                ProductId = Guid.Parse("af07e0c0-fb0a-46fc-9dbb-9ab4d9a0c839")
            });
            context.WorkProcedure.Add(new WorkProcedure()
            {
                Id = Guid.Parse("8f3e8330-f665-45dc-bb5b-0bf7275c654d"),
                Name = "Standardna procedura sprite plastika",
                Description = "Punjenje, zatvaranje flase, dodavanje nalepnice, pakovanje",
                ProductionPrice = 50,
                ProductId = Guid.Parse("f620e5eb-80c6-46f7-be3f-55c0fe633eac")
            });
            context.WorkProcedure.Add(new WorkProcedure()
            {
                Id = Guid.Parse("b38a6a37-7849-48b2-8023-895ee05c9a5f"),
                Name = "Standardna procedura fanta",
                Description = "Punjenje, zatvaranje flase, dodavanje nalepnice, pakovanje",
                ProductionPrice = 50,
                ProductId = Guid.Parse("89945a5d-3eb5-4c65-88d6-9f0864bdc376")
            });
            return context;
        }
        public static SodaCompanyContext PrefillProduct(this SodaCompanyContext context)
        {
            context.Product.Add(new Product()
            {
                ProductModelId = Guid.Parse("ba07bbab-8a70-430f-b5a4-7581cc6db76b"),
                Id = Guid.Parse("af07e0c0-fb0a-46fc-9dbb-9ab4d9a0c839"),
                Name = "Coca-cola staklo 0.33"
            });
            context.Product.Add(new Product()
            {
                ProductModelId = Guid.Parse("1a59820a-8ed2-4247-8e62-6f8561fec2c2"),
                Id = Guid.Parse("f620e5eb-80c6-46f7-be3f-55c0fe633eac"),
                Name = "Sprite plastika 0.5"
            });
            context.Product.Add(new Product()
            {
                ProductModelId = Guid.Parse("2047f2d0-8fdd-46c2-958b-5e5aeea3c604"),
                Id = Guid.Parse("89945a5d-3eb5-4c65-88d6-9f0864bdc376"),
                Name = "Fanta staklo 0.25"
            });
            return context;
        }
        public static SodaCompanyContext PrefillProductionPlan(this SodaCompanyContext context)
        {
            context.ProductionPlan.Add(new ProductionPlan()
            {
                CreatedBy = Guid.Parse("9d6f01e7-a53e-4c4a-a9ea-653732fe4af3"),
                CreationDate = DateTime.Now,
                Id = Guid.Parse("dc99bbcb-1eca-44ad-9aad-742f33b15e6e"),
                Name = "Plan proizvodnje 1",
                ProductionDeadline = DateTime.Now.AddDays(50),
                ProductionOrderId = Guid.Parse("b6b84d05-f84c-44a0-80c1-4652992d36b1")
            });
            context.ProductionPlan.Add(new ProductionPlan()
            {
                CreatedBy = Guid.Parse("9d6f01e7-a53e-4c4a-a9ea-653732fe4af3"),
                CreationDate = DateTime.Now,
                Id = Guid.Parse("ba67615f-af28-49c7-8028-ca009193c1dc"),
                Name = "Plan proizvodnje 2",
                ProductionDeadline = DateTime.Now.AddDays(75),
                ProductionOrderId = Guid.Parse("4b10db55-5a02-4842-868f-41bdc1d5b3e4")
            });
            //context.ProductionPlan.Add(new ProductionPlan()
            //{
            //    CreatedBy = Guid.Parse("9d6f01e7-a53e-4c4a-a9ea-653732fe4af3"),
            //    CreationDate = DateTime.Now,
            //    Id = Guid.Parse("ba67615f-af28-49c7-8028-ca009193c1dc"),
            //    Name = "Plan proizvodnje 2",
            //    ProductionDeadline = DateTime.Now.AddDays(75),
            //    ProductionOrderId = Guid.Parse("4b10db55-5a02-4842-868f-41bdc1d5b3e4")
            //});
            return context;
        }
        public static SodaCompanyContext PrefillWarehousePart(this SodaCompanyContext context)
        {
            context.WarehousePart.Add(new WarehousePart()
            {
                Id = Guid.Parse("88282fa8-663f-4b91-b7de-000d20a0db83"),
                PartId = Guid.Parse("b5785e30-8e41-4a95-9beb-b00ed4581171"),
                WarehouseId = Guid.Parse("fb41bbab-5ba2-428e-a682-7462b509dff3"),
                Quantity = 30000
            });
            context.WarehousePart.Add(new WarehousePart()
            {
                Id = Guid.Parse("f638e002-0f12-4e20-8749-2477b7ca07aa"),
                PartId = Guid.Parse("ae9aac89-ec04-4b6f-840b-bfdf2a5ce03a"),
                WarehouseId = Guid.Parse("fb41bbab-5ba2-428e-a682-7462b509dff3"),
                Quantity = 50000
            });
            context.WarehousePart.Add(new WarehousePart()
            {
                Id = Guid.Parse("fa042e08-5b16-4b2e-b858-ec380f7fb778"),
                PartId = Guid.Parse("ef966bf2-7394-4713-b4d2-06a5a3580ada"),
                WarehouseId = Guid.Parse("fb41bbab-5ba2-428e-a682-7462b509dff3"),
                Quantity = 10000
            });
            context.WarehousePart.Add(new WarehousePart()
            {
                Id = Guid.Parse("6b6ac4cb-e21c-4e4c-b0e6-1242ac193a6e"),
                PartId = Guid.Parse("3b47892d-f2fd-4e5e-8a65-44c5d046b8a3"),
                WarehouseId = Guid.Parse("fb41bbab-5ba2-428e-a682-7462b509dff3"),
                Quantity = 5000
            });
            return context;
        }
        public static SodaCompanyContext PrefillWorkProcedurePart(this SodaCompanyContext context)
        {
            context.WorkProcedurePart.Add(new WorkProcedurePart()
            {
                Id = Guid.Parse("b3570401-4cb1-42c9-b9a9-00501206e5e3"),
                WorkProcedureId = Guid.Parse("9e18c8d2-5106-4b81-9187-5540ac0b66cc"),
                Quantity = 1,
                PartId = Guid.Parse("b5785e30-8e41-4a95-9beb-b00ed4581171"),
            });
            context.WorkProcedurePart.Add(new WorkProcedurePart()
            {
                Id = Guid.Parse("6a774e1a-976b-44c3-b6a2-fa24f81df497"),
                WorkProcedureId = Guid.Parse("9e18c8d2-5106-4b81-9187-5540ac0b66cc"),
                Quantity = 1,
                PartId = Guid.Parse("ef966bf2-7394-4713-b4d2-06a5a3580ada"),
            });
            context.WorkProcedurePart.Add(new WorkProcedurePart()
            {
                Id = Guid.Parse("37fefa43-f968-498b-856c-a556b2a1c07e"),
                WorkProcedureId = Guid.Parse("9e18c8d2-5106-4b81-9187-5540ac0b66cc"),
                Quantity = 1,
                PartId = Guid.Parse("ae9aac89-ec04-4b6f-840b-bfdf2a5ce03a"),
            });
            context.WorkProcedurePart.Add(new WorkProcedurePart()
            {
                Id = Guid.Parse("c160a3a8-261d-421d-b443-00131941a075"),
                WorkProcedureId = Guid.Parse("9e18c8d2-5106-4b81-9187-5540ac0b66cc"),
                Quantity = .33m,
                PartId = Guid.Parse("3b47892d-f2fd-4e5e-8a65-44c5d046b8a3"),
            });
            return context;
        }
        public static SodaCompanyContext PrefillProductionPlanWorkProcedure(this SodaCompanyContext context)
        {
            context.ProductionPlanWorkProcedure.Add(new ProductionPlanWorkProcedure()
            {
                Id = Guid.Parse("09dbfeb1-df41-4302-b076-88bccff48f8c"),
                ProductionPlanId = Guid.Parse("dc99bbcb-1eca-44ad-9aad-742f33b15e6e"),
                WorkProcedureId = Guid.Parse("9e18c8d2-5106-4b81-9187-5540ac0b66cc"),
                Quantity = 100
            });
            return context;
        }
        public static SodaCompanyContext PrefillProductionOrder(this SodaCompanyContext context)
        {
            context.ProductionOrder.Add(new ProductionOrder()
            {
                CreatedBy = Guid.Parse("d29a42c5-8f94-4b2d-a96c-632ed7ca9f22"),
                CreationDate = DateTime.Now,
                Id = Guid.Parse("b6b84d05-f84c-44a0-80c1-4652992d36b1"),
                Name = "Maxi coca cola .33 nalog"
            });
            context.ProductionOrder.Add(new ProductionOrder()
            {
                CreatedBy = Guid.Parse("d29a42c5-8f94-4b2d-a96c-632ed7ca9f22"),
                CreationDate = DateTime.Now,
                Id = Guid.Parse("13ad389f-f5c1-4378-af98-12a20db1516a"),
                Name = "Fanta .5 nalog"
            });
            context.ProductionOrder.Add(new ProductionOrder()
            {
                CreatedBy = Guid.Parse("d29a42c5-8f94-4b2d-a96c-632ed7ca9f22"),
                CreationDate = DateTime.Now,
                Id = Guid.Parse("4b10db55-5a02-4842-868f-41bdc1d5b3e4"),
                Name = "Sprite .5 nalog"
            });
            return context;
        }
        public static SodaCompanyContext PrefillProductionOrderProduct(this SodaCompanyContext context)
        {
            context.ProductionOrderProduct.Add(new ProductionOrderProduct()
            {
                Id = Guid.Parse("78917025-7730-49f9-bc32-a151a453d8e1"),
                ProductId = Guid.Parse("af07e0c0-fb0a-46fc-9dbb-9ab4d9a0c839"),
                ProductionOrderId = Guid.Parse("b6b84d05-f84c-44a0-80c1-4652992d36b1"),
                Quantity = 500
            });
            context.ProductionOrderProduct.Add(new ProductionOrderProduct()
            {
                Id = Guid.Parse("600ffc78-9638-4f54-bbad-b9148a34b780"),
                ProductId = Guid.Parse("af07e0c0-fb0a-46fc-9dbb-9ab4d9a0c839"),
                ProductionOrderId = Guid.Parse("13ad389f-f5c1-4378-af98-12a20db1516a"),
                Quantity = 150
            });
            context.ProductionOrderProduct.Add(new ProductionOrderProduct()
            {
                Id = Guid.Parse("66c8fc91-a35b-4507-a130-3d6739eb6f72"),
                ProductId = Guid.Parse("89945a5d-3eb5-4c65-88d6-9f0864bdc376"),
                ProductionOrderId = Guid.Parse("13ad389f-f5c1-4378-af98-12a20db1516a"),
                Quantity = 200
            });
            context.ProductionOrderProduct.Add(new ProductionOrderProduct()
            {
                Id = Guid.Parse("212c13bf-7148-4f01-bfff-023b9dc1cd9f"),
                ProductId = Guid.Parse("89945a5d-3eb5-4c65-88d6-9f0864bdc376"),
                ProductionOrderId = Guid.Parse("4b10db55-5a02-4842-868f-41bdc1d5b3e4"),
                Quantity = 200
            });
            return context;
        }
    }
}