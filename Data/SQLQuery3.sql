ALTER TABLE tblUsers
ADD FOREIGN KEY (RoleId) REFERENCES tblRole(RoleId);

ALTER TABLE tblUsers
ADD CONSTRAINT FK_UsersRole
FOREIGN KEY (RoleId) REFERENCES Persons(RoleId);


CREATE TABLE tblMenu (
    MenuId int NOT NULL,
	Name nvarchar(50),
    ControllerName nvarchar(50) ,
    ActionName nvarchar(50),
    isParent bit,
    ParentId int,
    FontAwesome  nvarchar(50),
	CreatedBy int,
	CreatedDate datetime,
    EditBy int,
    EditDate datetime,
    DeletedBy int,
    DeletedDate datetime,
	isActive bit,
    PRIMARY KEY (MenuId),
    CONSTRAINT FK_MenuTable FOREIGN KEY (ParentId)
    REFERENCES tblMenu(MenuId)
);

CREATE TABLE tblAccessLevel (
    AccessId int NOT NULL,
    EditAccess bit,
    DeleteAccess bit,
    CreateAccess bit,
    MenuId int,
    RoleId int,
    CreatedBy int,
    CreatedDate datetime,
    EditBy int,
    EditDate datetime,
    DeletedBy int,
    DeletedDate datetime,
	isActive bit,
    PRIMARY KEY (AccessId),
    CONSTRAINT FK_AccessManu FOREIGN KEY (MenuId)
    REFERENCES tblMenu(MenuId),
    CONSTRAINT FK_AccessRole FOREIGN KEY (RoleId)
    REFERENCES tblRole(RoleId)
);

CREATE TABLE tblCountry(
    CountryId int NOT NULL,
    Code nvarchar(50),
    Name nvarchar(50),
    CreatedBy int,
    CreatedDate datetime,
    EditBy int,
    EditDate datetime,
    DeletedBy int,
    DeletedDate datetime,
	isActive bit,
    PRIMARY KEY (CountryId)
);


CREATE TABLE tblEye(
    EyeId int NOT NULL,
    Code nvarchar(50),
    Name nvarchar(50),
    CreatedBy int,
    CreatedDate datetime,
    EditBy int,
    EditDate datetime,
    DeletedBy int,
    DeletedDate datetime,
	isActive bit,
    PRIMARY KEY (EyeId)
);

CREATE TABLE tblOccupation(
    OccupationId int NOT NULL,
    Code nvarchar(50),
    Name nvarchar(50),
    CreatedBy int,
    CreatedDate datetime,
    EditBy int,
    EditDate datetime,
    DeletedBy int,
    DeletedDate datetime,
	isActive bit,
    PRIMARY KEY (OccupationId)
);


CREATE TABLE tblProduct(
    ProductId int NOT NULL,
    Code nvarchar(50),
    Name nvarchar(50),
    CreatedBy int,
    CreatedDate datetime,
    EditBy int,
    EditDate datetime,
    DeletedBy int,
    DeletedDate datetime,
	isActive bit,
    PRIMARY KEY (ProductId)
);

ALTER TABLE tblProduct
ADD ProductTypeId int;

ALTER TABLE tblProduct
ADD CONSTRAINT FK_ProductProductType
FOREIGN KEY (ProductTypeId) REFERENCES tblProductType(ProductTypeId);



CREATE TABLE tblProductType(
    ProductTypeId int NOT NULL,
    Code nvarchar(50),
    Name nvarchar(50),
    CreatedBy int,
    CreatedDate datetime,
    EditBy int,
    EditDate datetime,
    DeletedBy int,
    DeletedDate datetime,
	isActive bit,
    PRIMARY KEY (ProductTypeId)
);


CREATE TABLE tblStatus(
    StatusId int NOT NULL,
    Code nvarchar(50),
    Name nvarchar(50),
    CreatedBy int,
    CreatedDate datetime,
    EditBy int,
    EditDate datetime,
    DeletedBy int,
    DeletedDate datetime,
	isActive bit,
    PRIMARY KEY (StatusId)
);


CREATE TABLE tblSex(
    SexId int NOT NULL,
    Code nvarchar(50),
    Name nvarchar(50),
    CreatedBy int,
    CreatedDate datetime,
    EditBy int,
    EditDate datetime,
    DeletedBy int,
    DeletedDate datetime,
	isActive bit,
    PRIMARY KEY (SexId)
);


CREATE TABLE tblProductPackage(
    ProductPackageId int NOT NULL,
    Code nvarchar(50),
    Name nvarchar(50),
    CreatedBy int,
    CreatedDate datetime,
    EditBy int,
    EditDate datetime,
    DeletedBy int,
    DeletedDate datetime,
	isActive bit,
    PRIMARY KEY (ProductPackageId)
);

CREATE TABLE tblProductPackageProduct(
    ProductPackageProductId int NOT NULL,
    ProductId int,
	ProductPackageId int,
    CreatedBy int,
    CreatedDate datetime,
    EditBy int,
    EditDate datetime,
    DeletedBy int,
    DeletedDate datetime,
	isActive bit,
    PRIMARY KEY (ProductPackageProductId),
	CONSTRAINT FK_ManyProduct FOREIGN KEY (ProductId)
    REFERENCES tblProduct(ProductId),
    CONSTRAINT FK_ManyProductPackage FOREIGN KEY (ProductPackageId)
    REFERENCES tblProductPackage(ProductPackageId)
);


CREATE TABLE tblSetting(
    SettingId int NOT NULL,
    DateFormat nvarchar(50),
    NumberOfRetrieves nvarchar(50),
    NextWSA nvarchar(50),
    NextPassport nvarchar(50),
    CreatedBy int,
    CreatedDate datetime,
    EditBy int,
    EditDate datetime,
    DeletedBy int,
    DeletedDate datetime,
	isActive bit,
    PRIMARY KEY (SettingId)
);


CREATE TABLE tblPerson (
    PersonIDNumber int IDENTITY(1,1) NOT NULL,
	LastName nvarchar(max),
	FirstName nvarchar(max),
    CountryOfApplication int ,
    CityOfBirth nvarchar(max),
    CountryOfBirth int ,
    Phone nvarchar(max),
    Fax nvarchar(max),
    EMail nvarchar(max),
    Website nvarchar(max),
    DateOfBirth datetime,
	BirthDay int,
	BirthMonth int,
	BirthYear int,
	Sex int,
    Height float,
    Eyes int,
    Marks nvarchar(max),
    OccupationId int,
	OccupationCode int,
    Title nvarchar(max),
    FatherName nvarchar(max),
    MotherName nvarchar(max),
	WSANumber int,
    Comments nvarchar(max),
	Status int,
	TransactionCount int,
	SignaturePath nvarchar(max),
	Photo nvarchar(max),
	Photograph image,
	Signature image,
	CountryOfBirthStatistical int,
	CreatedBy int,
	EntryDate datetime,
    LastEditedBy int,
    LastModifiedDate datetime,
    DeletedBy int,
    DeletedDate datetime,
	isActive bit,
    PRIMARY KEY (PersonIDNumber),
    CONSTRAINT FK_PersonCountryAppli FOREIGN KEY (CountryOfApplication)
    REFERENCES tblCountry(CountryId),
	CONSTRAINT FK_PersonCountryBirth FOREIGN KEY (CountryOfBirth)
    REFERENCES tblCountry(CountryId),
	CONSTRAINT FK_PersonCountryStatis FOREIGN KEY (CountryOfBirthStatistical)
    REFERENCES tblCountry(CountryId),
	CONSTRAINT FK_PersonSex FOREIGN KEY (Sex)
    REFERENCES tblSex(SexId),
	CONSTRAINT FK_PersonEye FOREIGN KEY (Eyes)
    REFERENCES tblEye(EyeId),
	CONSTRAINT FK_PersonOccupation FOREIGN KEY (OccupationId)
    REFERENCES tblOccupation(OccupationId),
	CONSTRAINT FK_PersonStatus FOREIGN KEY (Status)
    REFERENCES tblStatus(StatusId),
	CONSTRAINT FK_PersonUserCre FOREIGN KEY (CreatedBy)
    REFERENCES tblUsers(UserId),
	CONSTRAINT FK_PersonUserEdit FOREIGN KEY (LastEditedBy)
    REFERENCES tblUsers(UserId),
	CONSTRAINT FK_PersonUserDel FOREIGN KEY (DeletedBy)
    REFERENCES tblUsers(UserId),
);

INSERT INTO tblMenu (Name, ControllerName, ActionName,isParent,ParentId,isActive,ElementId)
VALUES ('User Management', '', '',0,0,1,''),('Users', 'UserManagement', 'Users',1,1,1,'Users'),('Roles & Permissions', 'UserManagement', 'RolesPermission',1,1,1,'Roles'),('Reference Codes', '', '',0,0,1,''),('Countries', 'Home', 'Countries',1,4,1,'Country'),('Eyes', 'Home', 'Eyes',1,4,1,'Eye'),('Occupations', 'Home', 'Occupations',1,4,1,'Occupation'),('Products', 'Home', 'Products',1,4,1,'Product'),('Product types', 'Home', 'ProductTypes',1,4,1,'ProductType'),('Status', 'Home', 'Status',1,4,1,'Status'),('Sex', 'Home', 'Sex',1,4,1,'Sex'),('Product packages', 'Home', 'Productpackages',1,4,1,'Productpackage'),('Settings', '', '',0,0,1,''),('Setting/Configuration', 'Home', 'Settings',1,14,1,'Setting');

INSERT INTO tblMenu (ElementId)
VALUES ('Users') where MenuId=1;

UPDATE tblProduct
SET ProductTypeId = 1
WHERE ProductId=2;

ALTER TABLE tblProduct
ADD Price double(5,2);

	ALTER TABLE tblAccessLevel
ADD isActive bit;

ALTER TABLE tblMenu
ADD ElementId nvarchar(50);

delete from tblMenu where MenuId=29;
TRUNCATE TABLE tblAccessLevel;
TRUNCATE TABLE tblMenu;