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


INSERT INTO tblMenu (Name, ControllerName, ActionName,isParent,isActive,ElementId)
VALUES ('Setting/Configuration', 'Home', 'Settings',0,1,'Setting');

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

delete from tblMenu where MenuId=2;