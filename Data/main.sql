CREATE TABLE AddressTable(
id INTEGER PRIMARY KEY  UNIQUE NOT NULL ,
lineOne TEXT NOT NULL,
lineTwo TEXT,
postcode TEXT NOT NULL,
city TEXT NOT NULL,
contry TEXT NOT NULL,
landlord_id INTEGER,
FOREIGN KEY (Landlord_id) REFERENCES LandlordTable(id)


);