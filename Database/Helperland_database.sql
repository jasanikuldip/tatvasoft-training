use Helperland

CREATE TABLE contact_us (
	id int NOT NULL primary key IDENTITY(1,1),
	FName nvarchar(50) NOT NULL,
	LName nvarchar(50) NOT NULL,
	mobileNumber nvarchar(15) NOT NULL,
	email nvarchar(60) NOT NULL,
	subject int NOT NULL,
	message nvarchar(300) NOT NULL,
	attachment nvarchar(100) NOT NULL,
)
GO

CREATE TABLE [users] (
	id int NOT NULL primary key IDENTITY(1,1),
	FName nvarchar(50) NOT NULL,
	LName nvarchar(50) NOT NULL,
	email nvarchar(60) NOT NULL UNIQUE,
	password nvarchar(200) NOT NULL,
	phoneNumber nvarchar(15) NOT NULL,
	userType int NOT NULL
)
GO

CREATE TABLE [spExtra] (
	id int NOT NULL primary key IDENTITY(1,1),
	gender int NOT NULL,
	avatar int NOT NULL,
	isVerified bit NOT NULL,
	u_id int NOT NULL foreign key references users(id)
)
GO

CREATE TABLE [city] (
	cityId int NOT NULL primary key IDENTITY(1,1),
	cityName nvarchar(50) NOT NULL
)
GO

CREATE TABLE [zipcode] (
	zipcode int NOT NULL primary key,
	cirtId int NOT NULL foreign key references city(cityId)
)
GO


CREATE TABLE [FAQ] (
	id int NOT NULL primary key IDENTITY(1,1),
	faq nvarchar(100) NOT NULL,
	faqAnswer nvarchar(300) NOT NULL
)
GO

CREATE TABLE [userAddress] (
	aId int NOT NULL primary key IDENTITY(1,1),
	streetName nvarchar(100) NOT NULL,
	houseNumber nvarchar(60) NOT NULL,
	zipcode int NOT NULL foreign key references zipcode(zipcode),
	phoneNumber nvarchar(15) NOT NULL
)
GO

CREATE TABLE [services] (
	sId int NOT NULL primary key IDENTITY(1,1),
	serviceDate date NOT NULL,
	serviceStartTime nvarchar(10) NOT NULL,
	serviceEndTime nvarchar(10) NOT NULL,
	cId int NOT NULL foreign key references users(id),
	spId int NOT NULL,
	amount float NOT NULL,
	status int NOT NULL,
	address nvarchar(160) NOT NULL,
	phoneNumber nvarchar(15) NOT NULL,
	ratingOnTime float NOT NULL,
	ratingFriendly float NOT NULL,
	ratingQuality float NOT NULL,
	feedback nvarchar(100) NOT NULL
)
GO

CREATE TABLE [favouriteBlockedUser] (
	id int NOT NULL primary key IDENTITY(1,1),
	_user int NOT NULL foreign key references users(id),
	favouriteBlockedUser int NOT NULL,
	isFavourite bit NOT NULL,
	isBlocked bit NOT NULL
)
GO

CREATE TABLE [webNotification] (
	id int NOT NULL primary key IDENTITY(1,1),
	notification nvarchar(200) NOT NULL,
	time datetime NOT NULL,
	userId int NOT NULL foreign key references users(id)
)
GO

CREATE TABLE [rejectReason] (
	id int NOT NULL primary key IDENTITY(1,1),
	reason nvarchar(100) NOT NULL,
	spId int NOT NULL foreign key references users(id),
	serviceId int NOT NULL foreign key references [services]([sId])
)
GO